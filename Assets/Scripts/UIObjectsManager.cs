using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using UI;
using Zenject;

public class UIObjectsManager<TUIObject,TResourcesLoader> : AdvancedMonoBehaviour 
    where TUIObject : UIObject
    where TResourcesLoader : ResourcesLoader<TUIObject>
{
    public event Action<TUIObject> PreShown;
    public event Action<TUIObject> Shown;
    public event Action<TUIObject> Hidden;
    
    [Inject] protected DiContainer _container;
    [Inject] protected TResourcesLoader resourcesLoader;
    
    protected List<TUIObject> Actives;

    private Archive<TUIObject> _archive;

    protected override void Awake()
    {
        base.Awake();
        Actives = new List<TUIObject>();
        _archive = new Archive<TUIObject>();
    }
    
    public TUIObject Get(string id)
    {
        return _archive.Contains(id) ? _archive.GetFromArchive(id) : CreateNew(id);
    }
    
    public virtual void Show(string id)
    {
        TUIObject toShowObject = Get(id);
        AddToActive(toShowObject);
    }
    
    public void Show(TUIObject uiObject)
    {
        _archive.TryRemoveFromArchive(uiObject.Id);
        AddToActive(uiObject);
    }
    
    private TUIObject CreateNew(string id)
    {
        var prefab = resourcesLoader.GetObject(id);
        var instantiated = Instantiate(prefab);
        return instantiated;
    }
    
    protected virtual void AddToActive(TUIObject uiObject)
    {
        PreShown?.Invoke(uiObject);
        
        uiObject.gameObject.SetActive(true);
        uiObject.Shown += OnShown;
        uiObject.Show();
            
        Actives.Add(uiObject);
    }
    
    public TUIObject Instantiate(TUIObject uiObjectPrefab)
    {
        return _container.InstantiatePrefabForComponent<TUIObject>(uiObjectPrefab, transform);
    }

    public bool HasActive()
    {
        var last = GetLast();
        return !ReferenceEquals(last, null);
    }
    
    public TUIObject GetLast()
    {
        return Actives.LastOrDefault();
    }

    public string GetLastId()
    {
        var last = GetLast();

        return last == null ? string.Empty : last.Id;
    }
    
    protected bool IsLastActiveHasId(string id)
    {
        var l = GetLast();
        return l != null && l.Id.Equals(id);
    }
    
    public void Hide(string id)
    {
        var uiobject = Actives.FirstOrDefault(u => u.Id.Equals(id));
        Hide(uiobject);
    }
    
    public void Hide(TUIObject uiObject)
    {
        Actives.Remove(uiObject);
            
        uiObject.Hidden += OnHidden;
        uiObject.Hide();
        
        _archive.Add(uiObject.Id, uiObject);
    }

    protected virtual void OnShown(UIObject uiObject)
    {
        uiObject.Shown -= OnShown;
        Shown?.Invoke(uiObject as TUIObject);
    }
    
    protected virtual void OnHidden(UIObject uiObject)
    {
        uiObject.Hidden -= OnHidden;
        uiObject.gameObject.SetActive(false);
        
        Hidden?.Invoke(uiObject as TUIObject);
    }

    public void TryHideLast()
    {
        var uiObject = Actives.LastOrDefault();

        if (uiObject == null)
        {
            //Debug.Log($"{name} {nameof(TryHideLast)} there is not last popup");
            return;
        }
        Hide(uiObject);
    }
    
    public void HideLast()
    {
        var uiObject = Actives.Last();
        Hide(uiObject);
    }
}
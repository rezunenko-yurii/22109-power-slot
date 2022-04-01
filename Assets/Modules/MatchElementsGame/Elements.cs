using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Popups;
using DefaultNamespace;
using GameCores.MatchElementsGame;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace MatchGame
{
    public class Elements : AdvancedMonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Inject] private DiContainer container;
        [Inject] private PopupsManager _popupsManager;
        [Inject] private MatchLevels matchLevels;
        [Inject] private SignalBus signalBus;

        [SerializeField] private Element prefab;
        [SerializeField] private Sprite[] images;
        [SerializeField] private ElementPointer pointer;
        [SerializeField] private RectTransform parent;
        [SerializeField] private ElementsComparer comparer;
        [SerializeField] private TimerMonoBehaviour timer;
        [SerializeField] private BoosterButtons boosterButtons;
        [SerializeField] private GameLevelPanel levelPanel;

        [SerializeField] private string WinPopupId;
        [SerializeField] private string LosePopupId;
        [SerializeField] private string PausePopupId;

        private int halfWidth;
        private int halfHeight;

        private List<Element> list;
        private MatchLevel level;
        
        protected override void Initialize()
        {
            base.Initialize();

            list = new List<Element>();

            var sizeDelta = parent.sizeDelta;
            halfWidth = (int)(sizeDelta.x / 2);
            halfHeight = (int)(sizeDelta.y / 2);
            
        }

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            
            pointer.Clean();
            Restart();
        }

        private void Restart()
        {
            var currentLevelNum = PlayerPrefs.GetInt("level", 1);
            level = matchLevels.MatchLevel(currentLevelNum);

            levelPanel.UpdateText();
            
            Spawn();
            Shuffle();

            //timer.timeRemaining = level.Time;
            timer.Reset(level.Time);
            timer.StartCount();
        }

        protected override void OnDisableInitialized()
        {
            base.OnDisableInitialized();

            Clean();
        }

        private void Clean()
        {
            comparer.Clean();

            timer.Stop();
            pointer.Clean();

            list.ForEach(element => Destroy(element.gameObject));
            list.Clear();
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            
            signalBus.Subscribe<MatchSignals.Restart>(OnRestart);
            
            comparer.Matched += OnMatched;
            timer.Over += OnTimerOver;
            boosterButtons.BoosterClicked += UseBooster;
        }

        private void OnRestart()
        {
            Clean();
            Restart();
        }

        private void UseBooster(string obj)
        {
            if (obj.Equals("shuffle"))
            {
                Shuffle();
                comparer.Clean();
            }
            else if (obj.Equals("magnet"))
            {
                Magnet();
            }
            else if (obj.Equals("stoptime"))
            {
                timer.frozenTime += 30;
            }
            else if (obj.Equals("extratime"))
            {
                timer.timeRemaining += 120;
            }
        }

        private void Magnet()
        {
            var first = list.First();
            var second = list.First(x => !x.Equals(first) && x.Sprite.Equals(first.Sprite));
            
            OnMatched(first,second);
        }

        private void OnTimerOver()
        {
            _popupsManager.Show(LosePopupId);
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            
            signalBus.Unsubscribe<MatchSignals.Restart>(OnRestart);
            
            comparer.Matched -= OnMatched;
            timer.Over -= OnTimerOver;
            boosterButtons.BoosterClicked -= UseBooster;
        }

        private void OnMatched(Element arg1, Element arg2)
        {
            //_products.Give(rewardCoins);
            
            list.Remove(arg1);
            list.Remove(arg2);
        
            Destroy(arg1.gameObject);
            Destroy(arg2.gameObject);

            if (list.Count == 0)
            {
                PlayerPrefs.SetInt("level", level.Level + 1);
                _popupsManager.Show(WinPopupId);
                timer.Stop();
            }
        }

        private void Spawn()
        {
            for (int i = 0; i < level.ChipsAmount; i++)
            {
                var s = images[i];

                for (int j = 0; j < 2; j++)
                {
                    var element = container.InstantiatePrefabForComponent<Element>(prefab, parent);
                    element.SetData(s);
                    list.Add(element);
                }
            }
        }
    
        private void Shuffle()
        {
            var rnd = new System.Random();
        
            foreach (var element in list)
            {
                var x = rnd.Next(-halfWidth, halfWidth);
                var y = rnd.Next(-halfHeight, halfHeight);
            
                element.SetPosition(x, y);
            }
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            var ee = GetObject<Element>(results);
            if (ee == null)
            {
                return;
            }
        
            AddToPointer(ee);
        
            var er = GetObject<ElementReceiver>(results);
            if (er != null)
            {
                if (er.pickedElement != null && er.pickedElement.Equals(ee))
                {
                    er.Clean();
                }
            }
        }

        private void AddToPointer(Element element)
        {
            element.transform.SetAsLastSibling();
            Debug.Log("Found");

            pointer.SetData(element);
            pointer.Follow = true;
        
            element.gameObject.SetActive(false);
        
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
        
            var er = GetObject<ElementReceiver>(results);
            if (er != null)
            {
                if (er.pickedElement == null)
                {
                    er.SetData(pointer.PickedElement);
                }
            }
            else
            {
                var p = pointer.transform.localPosition;
                if (IsXInBoundaries(p.x) && IsYInBoundaries(p.y))
                {
                    pointer.PickedElement.transform.position = pointer.transform.position;
                }
            }

            pointer.PickedElement.gameObject.SetActive(true);
            pointer.Clean();
        }
    
        private bool IsXInBoundaries(float x)
        {
            if (x >= -halfWidth && x <= halfWidth)
            {
                return true;
            }

            return false;
        }

        private bool IsYInBoundaries(float y)
        {
            if (y >= -halfHeight && y <= halfHeight)
            {
                return true;
            }

            return false;
        }

        private T GetObject<T>(List<RaycastResult> results)
        {
            var elementReceiverResult = results.FirstOrDefault(x =>
            {
                var a = x.gameObject.GetComponent<T>();
                return a != null;
            });

            if (elementReceiverResult.gameObject != null)
            {
                var elementReceiver = elementReceiverResult.gameObject.GetComponent<T>();
                return elementReceiver;
            }
            else
            {
                return default;
            }
        }
    }
}

using Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace LevelsModule
{
    public class ExperienceLevelPanel : AdvancedMonoBehaviour
    {
        [Inject] private ExperienceManager _experienceManager;
        
        [SerializeField] protected TextMeshProUGUI textField;
        [SerializeField] protected string additionalText;
        

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            ChangeText(_experienceManager.GetCurrentLevel());
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            _experienceManager.Increased += ChangeText;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            _experienceManager.Increased -= ChangeText;
        }

        private void ChangeText(int obj)
        {
            Debug.Log($"{nameof(ExperienceLevelPanel)} {nameof(ChangeText)} {obj}");
            textField.text = $"{additionalText}{obj.ToString()}";
        }
    }
}
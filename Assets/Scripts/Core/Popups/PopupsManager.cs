using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;
using Zenject;

namespace Core.Popups
{
    public class PopupsManager : UIObjectsManager<Popup, Popups>
    {
        /*public Transform GetRoot => transform;
        public void ShowOneShot(Popup popup, bool needInstantiate = true)
        {
            Popup p = needInstantiate ? InstantiateUIObject(popup) : popup;
            AddToActive(p);
        }*/
    }
}
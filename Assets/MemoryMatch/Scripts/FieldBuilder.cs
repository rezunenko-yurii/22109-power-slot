using System.Collections.Generic;
using Core;
using MemoryMatch.Scripts;
using UnityEngine;
using Zenject;

namespace GameCores.MemoryMatchGame
{
    public class FieldBuilder : AdvancedMonoBehaviour
    {
        [Inject] private DiContainer _container;

        [SerializeField] private Element _prefab;
        [SerializeField] private List<Sprite> _sprites;
        [SerializeField] private RectTransform _elementsContainer;
        
        public List<Element> Build(Level level)
        {
            var elements = new List<Element>();
            var prefabSize = _prefab.GetComponent<RectTransform>().sizeDelta;
            
            _elementsContainer.sizeDelta = new Vector2(prefabSize.x * level.Cols, prefabSize.y * level.Rows);
            var fieldSize = _elementsContainer.sizeDelta;
            
            var startX = fieldSize.x / 2 - prefabSize.x / 2;
            var startY = fieldSize.y / 2 - prefabSize.y / 2;
            
            var posX = -startX;
            var posY = startY;

            for (var i = 0; i < level.Rows; i++)
            {
                for (var j = 0; j < level.Cols; j++)
                {
                    var spriteNum = level.Field[i, j];

                    if (spriteNum > 0)
                    {
                        var element =  _container.InstantiatePrefabForComponent<Element>(_prefab, _elementsContainer);
                        element.SetData(spriteNum, _sprites[spriteNum]);
                        element.transform.localPosition = new Vector3(posX, posY);
                    
                        elements.Add(element);
                    }
                    
                    posX += prefabSize.x;
                }

                posX = -startX;
                posY -= prefabSize.y;
            }

            return elements;
        }

        public void Clear()
        {
            foreach (Transform child in _elementsContainer)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}

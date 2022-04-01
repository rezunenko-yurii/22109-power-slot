using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Core
{
    public abstract class ResourcesLoader<T>
    {
        public Dictionary<string, T> All { get; protected set; }
        protected abstract string FolderName { get; }
        
        public virtual void Init(TextAsset config)
        {
            All = new Dictionary<string, T>();
            var jArray = JArray.Parse(config.text);

            foreach (var jToken in jArray)
            {
                HandleItem(jToken);
            }
            
            AddListeners();
        }

        protected void Add(string id, T obj)
        {
            CheckForEmptyId(id);
            CheckObjectForNull(id, obj);
            
            All.Add(id, obj);
        }

        protected virtual void AddListeners() { }

        protected abstract void HandleItem(JToken jToken);
        
        public T FindObject(string id)
        {
            CheckForEmptyId(id);
            
            return All[id];
        }
        
        public T GetObject(string id)
        {
            CheckForEmptyId(id);
            
            if (All.ContainsKey(id))
            {
                return All[id];
            }
            else
            {
                throw new Exception($"{this} {nameof(GetObject)} item with id {id} isn't contains in dictionary");
            }
        }

        private void CheckForEmptyId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception($"{this} {nameof(CheckForEmptyId)} id is empty");
            }
        }
        
        private void CheckObjectForNull(string id, T obj)
        {
            if (obj == null)
            {
                throw new Exception($"{this} {nameof(CheckObjectForNull)} object with id {id} is null");
            }
        }
    }
}
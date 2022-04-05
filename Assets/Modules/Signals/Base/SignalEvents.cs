using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Core.Signals.Base
{
    public class SignalEvents : ResourcesLoader<SignalEvent>
    {
        protected override string FolderName { get; }
        protected override void HandleItem(JToken jToken)
        {
            var signalEvent = jToken.ToObject<SignalEvent>();
            Add(signalEvent.Id, signalEvent);
        }

        public List<SignalEvent> GetObjects(string signalName, string targetName)
        {
            var list = new List<SignalEvent>();
            
            foreach (var (key, signalEvent) in All)
            {
                var isSignalNamesEquals = signalEvent.SignalName.Equals(signalName);
                var isTargetNamesEquals = signalEvent.TargetName.Equals(targetName);

                if (isSignalNamesEquals && isTargetNamesEquals)
                {
                    list.Add(signalEvent);
                }
            }

            return list;
        }
    }
}
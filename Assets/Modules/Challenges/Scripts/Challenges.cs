using Core;
using Newtonsoft.Json.Linq;
using Zenject;

namespace Modules.Challenges.Scripts
{
    public class Challenges : ResourcesLoader<Challenge>
    {
        [Inject] private Modules.Tasks.Tasks _tasks;
        
        protected override string FolderName { get; }
        protected override void HandleItem(JToken jToken)
        {
            var challenge = jToken.ToObject<Challenge>();
            var task = _tasks.GetObject(challenge.TaskId);
            challenge.Task = task;
            challenge.Init();
            
            Add(challenge.Id, challenge);
        }
    }
}
using Core.GameScreens;
using Zenject;

namespace Modules.Filters.Scripts
{
    public class ScreensFilter : IFilter
    {
        [Inject] private ScreensManager _screensManager;
        public string[] ScreenIds { get; init; }
        public string Id { get; init; }
        
        public void Init()
        {
            
        }

        public bool IsRequestSatisfied()
        {
            foreach (var screenId in ScreenIds)
            {
                if (_screensManager.Current.Id.Equals(screenId))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
using RH.Utilities.UI;

namespace RoofRace.UI
{
    public class StartLevelButton : BaseActionButton
    {
        protected override void PerformOnClick() =>
            LevelStateMachine.Instance.StartLevel();
    }
}
using RH.Utilities.UI;

namespace RoofRace.UI
{
    public class FailLevelButton : BaseActionButton
    {
        protected override void PerformOnClick() =>
            LevelStateMachine.Instance.RestartLevel();
    }
}
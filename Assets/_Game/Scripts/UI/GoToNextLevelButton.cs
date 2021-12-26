using RH.Utilities.UI;

namespace RoofRace.UI
{
    public class GoToNextLevelButton : BaseActionButton
    {
        protected override void PerformOnClick() =>
            LevelStateMachine.Instance.GoToNextLevel();
    }
}
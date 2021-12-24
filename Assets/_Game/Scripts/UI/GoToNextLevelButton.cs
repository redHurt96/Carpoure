using RH.Utilities.UI;

public class GoToNextLevelButton : BaseActionButton
{
    protected override void PerformOnClick() =>
        LevelStateMachine.Instance.GoToNextLevel();
}

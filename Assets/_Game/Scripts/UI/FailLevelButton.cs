using RH.Utilities.UI;

public class FailLevelButton : BaseActionButton
{
    protected override void PerformOnClick() =>
        LevelStateMachine.Instance.RestartLevel();
}
using RH.Utilities.UI;

public class StartLevelButton : BaseActionButton
{
    protected override void PerformOnClick() => 
        LevelStateMachine.Instance.StartLevel();
}

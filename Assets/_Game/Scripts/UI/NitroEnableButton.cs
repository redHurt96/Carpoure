using RH.Utilities.UI;
using RoofRace.Logic;

namespace RoofRace.UI
{
    public class NitroEnableButton : BaseActionButton
    {
        protected override void PerformOnClick() => NitroManager.Instance.Enable();
    }
}
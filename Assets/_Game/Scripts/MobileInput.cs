using KartGame.KartSystems;

public class MobileInput : BaseInput
{
    public override InputData GenerateInput()
    {
        return new InputData
        {
            Accelerate = true,
            Brake = false,
            TurnInput = SimpleInput.GetAxis("Horizontal")
        };
    }
}

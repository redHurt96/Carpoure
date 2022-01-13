using UnityEngine;

namespace KartGame.KartSystems {

    public class KeyboardInput : BaseInput
    {
        public override InputData GenerateInput() {
            return new InputData
            {
                Accelerate = Input.GetKey(KeyCode.W),
                Brake = Input.GetKey(KeyCode.S),
                TurnInput = Input.GetAxis("Horizontal")
            };
        }
    }
}

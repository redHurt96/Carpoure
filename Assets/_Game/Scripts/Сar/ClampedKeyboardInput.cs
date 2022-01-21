using KartGame.KartSystems;
using UnityEngine;

public class ClampedKeyboardInput : BaseInput
{
    public float HorizontalDirection
    {
        get
        {
            var direction = Input.GetAxis("Horizontal");

            if (direction != 0f && CanRotateAtDirection(direction))
                return direction;
            if (Mathf.Approximately(direction, 0f) && _needRotateToOrigin)
                return -Mathf.Sign(_localRotation);

            return 0f;
        }
    }

    public float RotationTreshhold => _rotationTreshhold;

    private const float AUTO_ROTATION_TRESHHOLD = .04f;

    [SerializeField] private float _rotationTreshhold = .1f;

    private float _localRotation => transform.localRotation.y;
    private bool _needRotateToOrigin => Mathf.Abs(_localRotation) > AUTO_ROTATION_TRESHHOLD;

    public override InputData GenerateInput()
    {
        return new InputData
        {
            Accelerate = true,
            Brake = false,
            TurnInput = HorizontalDirection
        };
    }

    public void ChangeRotationTreshhold(float value) => _rotationTreshhold = value;

    private bool CanRotateAtDirection(float direction) =>
        (direction > 0f && _localRotation < _rotationTreshhold) || (direction < 0f && _localRotation > -_rotationTreshhold);
}

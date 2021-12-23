using System.Collections.Generic;
using UnityEngine;

public class GravityChangerToDirection : MonoBehaviour
{
    private const float GRAVITY_FORCE = 10;

    private static readonly Dictionary<Direction, Vector3> DIRECTIONS = new Dictionary<Direction, Vector3>
    {
        { Direction.Left, Vector3.left * GRAVITY_FORCE },
        { Direction.Right, Vector3.right * GRAVITY_FORCE },
        { Direction.Default, Vector3.down * GRAVITY_FORCE }
    };

    [SerializeField] private Direction _nextDirecton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Physics.gravity = DIRECTIONS[_nextDirecton];
    }

    private enum Direction
    {
        Default = 0,
        Left,
        Right,
    }
}

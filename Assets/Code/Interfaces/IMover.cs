using UnityEngine;

namespace SpaceShooter
{
    public interface IMover
    {
        //The position of this object in world space
        Vector3 Position { get; set; }

        //The rotation of this object in world space
        Quaternion Rotation { get; set; }

        //The speed of this mover
        float Speed { get; }

        //Move toward targetPosition
        void MoveTowardPosition(Vector3 targetPosition);

        //Move to direction
        void MoveToDirection(Vector3 direction);

        //Rotate toward targetPosition
        void RotateTowardPosition(Vector3 targetPosition);
    }
}

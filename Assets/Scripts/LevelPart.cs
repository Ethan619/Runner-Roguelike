using UnityEngine;

public class LevelPart : MonoBehaviour
{
    public Transform leftMidpoint;
    public Transform rightMidpoint;

    public Vector3 GetRightMidpointPosition()
    {
        return rightMidpoint.position;
    }

    public Vector3 GetLeftMidpointPosition()
    {
        return leftMidpoint.position;
    }
}

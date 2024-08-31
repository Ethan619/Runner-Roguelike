using UnityEngine;

public class LevelPart : MonoBehaviour
{
    public Transform rightMidpoint;

    public Vector3 GetRightMidpointPosition()
    {
        return rightMidpoint.position;
    }
}

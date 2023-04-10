using UnityEngine;

[CreateAssetMenu(fileName = "New MovementRange", menuName = "Stats/MovementRange")]
public class DetectionRangeScriptable : ScriptableObject
{
    [SerializeField] private float detectionRange;
    [SerializeField] private float movementSpeed;

    public float DetectionRange
    {
        get { return detectionRange; }
        set { detectionRange = value; }
    }

    public float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }
}

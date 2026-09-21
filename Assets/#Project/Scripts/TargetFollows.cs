using UnityEngine;

public class TargetFollows : MonoBehaviour
{
    [SerializeField] private Transform target;

    [Tooltip("Offset on z axis between the gameObject and target")]
    [SerializeField] private float zOffset = -3f;
    [SerializeField] private float speed = 5.5f;

    void Update()
    {
        float z = target.position.z + zOffset;
        Vector3 position = transform.position;
        position.z = z;

        transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }
}

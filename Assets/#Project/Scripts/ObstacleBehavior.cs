using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ObstacleBehavior : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerControl pc))
        {
            pc.Respawn();
        }
    }
}

using UnityEngine;

public class EndBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerControl pc))
        {
            pc.Stop();
        }
    }
}

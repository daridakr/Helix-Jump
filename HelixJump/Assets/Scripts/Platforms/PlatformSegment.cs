using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformSegment : MonoBehaviour
{
    public void Bounce(float force, Vector3 center, float radius)
    {
        if (TryGetComponent(out Rigidbody body))
        {
            body.isKinematic = false;
            body.AddExplosionForce(force, center, radius);
        }
    }
}

using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;

    private PlatformSegment[] _segments;

    private void Start()
    {
        _segments = GetComponentsInChildren<PlatformSegment>();
    }

    public void Break()
    {
        foreach (PlatformSegment segment in _segments)
        {
            segment.Bounce(_bounceForce, transform.position, _bounceRadius);
        }
    }
}

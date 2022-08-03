using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody _body;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlatformSegment platformSegment))
        {
            Jump();
        }
    }

    private void Jump()
    {
        _body.velocity = Vector3.zero;
        _body.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
}

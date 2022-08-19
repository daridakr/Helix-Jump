using UnityEngine;

public class BallTraking : MonoBehaviour
{
    [SerializeField] private float _directionOffsetY;
    [SerializeField] private float _length;

    private Ball _ball;
    private Tower _tower;

    private Vector3 _observPosition;
    private Vector3 _minimumBallPosition;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _tower = FindObjectOfType<Tower>();

        _minimumBallPosition = _ball.transform.position;
    }

    private void Update()
    {
        if (IsBallFliesDown())
        {
            _observPosition = _ball.transform.position;
            _minimumBallPosition = _ball.transform.position;
            Track();
        }
    }

    private void Track()
    {
        Vector3 viewDirection = GetViewDirection(_tower.transform.position, _ball.transform.position);
        viewDirection.y += _directionOffsetY;
        _observPosition -= viewDirection * _length;

        transform.position = _observPosition;
        transform.LookAt(_ball.transform.position);
    }

    private Vector3 GetViewDirection(Vector3 towerPosition, Vector3 ballPosition)
    {
        towerPosition.y = ballPosition.y;
        return (towerPosition - _ball.transform.position).normalized;
    }

    private bool IsBallFliesDown()
    {
        return _ball.transform.position.y < _minimumBallPosition.y;
    }
}

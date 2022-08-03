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
        if (_ball.transform.position.y < _minimumBallPosition.y) 
        {
            Track();
            _minimumBallPosition = _ball.transform.position;
        }
    }

    private void Track()
    {
        _observPosition = _ball.transform.position;

        Vector3 towerPosition = _tower.transform.position;
        towerPosition.y = _ball.transform.position.y;
        
        Vector3 viewDirection = (towerPosition - _ball.transform.position).normalized;
        viewDirection.y += _directionOffsetY;
        _observPosition -= viewDirection * _length;
        transform.position = _observPosition;
        transform.LookAt(_ball.transform);
    }
}

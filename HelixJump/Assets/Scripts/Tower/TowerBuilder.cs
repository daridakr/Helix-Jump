using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _tower;
    [SerializeField] private int _levelCount;
    [SerializeField] private float _topAdditionalScale;

    [SerializeField] private SpawnPlatform _startPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Platform[] _platforms;

    private float _startAndFinishAdditionalScale = 0.5f;
    private int _platformSpawnStepY = 1;

    public float TowerScaleY => (_levelCount / 2f) + (_topAdditionalScale / 2f) + _startAndFinishAdditionalScale;

    private void Start()
    {
        Build();
    }

    private void Build()
    {
        GameObject tower = Instantiate(_tower, parent: transform);
        tower.transform.localScale = new Vector3(1, TowerScaleY, 1);

        Vector3 spawnPosition = tower.transform.position;
        spawnPosition.y += tower.transform.localScale.y - _topAdditionalScale;

        SpawnPlatform(_startPlatform, ref spawnPosition, parent: tower.transform);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], ref spawnPosition, parent: tower.transform);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, parent: tower.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= _platformSpawnStepY;
    }
}

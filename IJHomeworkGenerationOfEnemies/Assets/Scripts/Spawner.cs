using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private DirectionChooser _directionChooser;
    [SerializeField] private SpawnPointChooser _pointChosser;
    [SerializeField] private Mover _mover;   
    [SerializeField] private Enemy _enemy;

    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _maxSize = 5;

    private Coroutine _coroutine;
    private float _delay = 0.2f;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>
        (
        createFunc: () => Instantiate(_enemy),
        actionOnGet: (enemy) => OnActionGet(enemy),
        actionOnRelease: (enemy) => OnActionRelease(enemy),
        actionOnDestroy: (enemy) => Destroy(enemy),
        collectionCheck: true,
        defaultCapacity: _poolCapacity,
        maxSize: _maxSize
        );
    }

    private void Start()
    {
        _coroutine = StartCoroutine(nameof(StartPooling));
    }

    private IEnumerator StartPooling()
    {
        WaitForSeconds wait = new(_delay);

        while (enabled)
        {
            _pool.Get();

            yield return wait;
        }
    }

    private void OnActionGet(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);

        enemy.transform.position = _pointChosser.GetSpawnerPoint();

        _mover.MoveEnemy(enemy, _directionChooser.GetDirection());

    }

    private void OnActionRelease(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);

        _pool.Release(enemy);
    }
}




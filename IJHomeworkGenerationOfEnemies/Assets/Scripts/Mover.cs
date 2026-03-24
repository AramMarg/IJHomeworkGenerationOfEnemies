using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Enemy _enemy;
    private Vector3 _direction;

    private void Update()
    {
        if (_enemy != null)
        {
            _enemy.transform.Translate(_direction * _moveSpeed * Time.deltaTime);
        }
    }

    public void MoveEnemy(Enemy enemy, Vector3 direction)
    {
        _enemy = enemy;

        _direction = direction;
    }
}

using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;
    private Vector3 _direction;

    private void Update()
    {
        transform.Translate(_direction * _moveSpeed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}

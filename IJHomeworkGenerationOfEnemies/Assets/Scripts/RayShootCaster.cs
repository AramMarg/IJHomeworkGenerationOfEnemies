using UnityEngine;

public class RayShootCaster : MonoBehaviour
{
    private readonly float _maxDistanceRay = 30;

    [SerializeField] private MouseShootReader _mouseShootReader;
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private LayerMask _layerMask;

    private void OnEnable()
    {
        _mouseShootReader.MouseButtonShootClicked += OnMouseButtonClicked;
    }

    private void OnDisable()
    {
        _mouseShootReader.MouseButtonShootClicked -= OnMouseButtonClicked;
    }

    private void OnMouseButtonClicked(Vector3 mousePossition)
    {
        _ray = _camera.ScreenPointToRay(mousePossition);

        Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.red);

        if (Physics.Raycast(_ray.origin, _ray.direction, out RaycastHit hit, _maxDistanceRay, _layerMask))
        {
            if (hit.collider.TryGetComponent(out Enemy enemy))
            {
                enemy.Die();
            }
        }
    }
}

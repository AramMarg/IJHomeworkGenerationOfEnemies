using System;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Mover))]
public class Enemy : MonoBehaviour
{
    private Mover _mover;

    public event Action<Enemy> Died;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    public void SetDirection(Vector3 direction)
    {
        _mover.SetDirection(direction);
    }

    public void Die()
    {
        Died?.Invoke(this);
    }

}

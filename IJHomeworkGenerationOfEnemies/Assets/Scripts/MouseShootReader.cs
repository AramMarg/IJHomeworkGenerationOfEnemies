using System;
using UnityEngine;

public class MouseShootReader : MonoBehaviour
{
    private const int MouseButton = 0;

    public event Action<Vector3> MouseButtonShootClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseButton))
        {
            MouseButtonShootClicked?.Invoke(Input.mousePosition);
        }
    }
}

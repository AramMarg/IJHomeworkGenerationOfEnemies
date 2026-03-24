 using Random = System.Random;
using UnityEngine;

public class DirectionChooser : MonoBehaviour
{
    public Vector3 GetDirection()
    {
        const int  CommandForward = 0;
        const int  CommandBack = 1;
        const int  CommandrRight = 2;
        const int  CommandLeft = 3;

        Vector3 direction = new();

        Random random = new();
        int minForRandom = 0;
        int maxForRandom = 3;
        int tempForMaxBorder = 1;

        int tempForSwitch = random.Next(minForRandom, maxForRandom + tempForMaxBorder);

        switch (tempForSwitch)
        {
            case CommandForward:
                direction = Vector3.forward;
                break;

            case CommandBack:
                direction = Vector3.back;
                break;

            case CommandrRight:
                direction = Vector3.right;
                break;

            case CommandLeft:
                direction = Vector3.left;
                break;
        }

        return direction;
    }
}

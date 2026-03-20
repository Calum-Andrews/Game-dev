
using UnityEngine;
using UnityEngine.InputSystem;

public class FourWayMovement : MonoBehaviour
{
    [SerializeField]
    private float MovementSpeed;

    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        { 
            transform.position += Vector3.forward * MovementSpeed * Time.deltaTime;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            transform.position += Vector3.back * MovementSpeed * Time.deltaTime;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            transform.position += Vector3.left * MovementSpeed * Time.deltaTime;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            transform.position += Vector3.right * MovementSpeed * Time.deltaTime;
        }





    }
}

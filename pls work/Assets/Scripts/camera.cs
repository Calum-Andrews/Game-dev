using UnityEngine;
using UnityEngine.InputSystem;
public class camera_script : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private Transform player_body;


    float x_rotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
       
        Vector2 mouse = Mouse.current.delta.ReadValue();
        
        float mouseX = mouse.x * sensitivity * Time.deltaTime;
        float mouseY = mouse.y * sensitivity * Time.deltaTime;

        x_rotation -= mouseY;
        x_rotation = Mathf.Clamp(x_rotation, -90f, 90f);

        transform.localEulerAngles = new Vector3(x_rotation, 0f, 0f);

        player_body.Rotate(0f, mouseX, 0f);
    }
}

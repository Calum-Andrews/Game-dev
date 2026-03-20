using System.Runtime.CompilerServices;  
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEditor.Build;
using Unity.VisualScripting;

public class RotationBasedMovement : MonoBehaviour
{
    //Movement behaviours
    [SerializeField] private float move_speed;
    [SerializeField] private float rotate_speed;
    [SerializeField] private float jump_height;
    [SerializeField] private float jump_speed;
    [SerializeField] private float air_control_speed = 0.3f;


    [SerializeField] private float health;

    // Attacks
    [SerializeField] private GameObject little_embers;
    [SerializeField] private Transform embers_fired;
    [SerializeField] private float embers_power;
    [SerializeField] private float fire_rate;
    [SerializeField]private float next_fire_cooldown;

    //Other
    [SerializeField] private float capsule_respawn;
    [SerializeField] private Transform capsule_object;
    private Rigidbody rb;
    private float raycast_distance = 1f;
    

    // Wall Jump
    [SerializeField] private float wall_check_distance;
    [SerializeField] private float wall_jump_force;
    [SerializeField] private LayerMask wall_layer;

    // Camera Tilt While wall running
    [SerializeField] private Transform player_camera;
    [SerializeField] private float camera_rotate_angle;
   


    private bool is_touching_wall;
    private Vector3 normal_wall;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.name == "Power Shifter" || other.name == "Shifter Potion")
        {
            
            other.gameObject.SetActive(false);
            
            Scale_Mover arrow = GameObject.Find("Arrow").GetComponent<Scale_Mover>();
            if (arrow != null)
            {
                arrow.toggle_direction();
            }
            
            StartCoroutine(RespawnCapsule(other.gameObject));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "Enemy" || collision.gameObject.name == "embers")
        {
            health -= 1;

        }


        
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            health -= 1;

        }
    }

    private bool is_grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, raycast_distance + 0.1f);
    }

    IEnumerator RespawnCapsule(GameObject capsule)
    {
        yield return new WaitForSeconds(capsule_respawn);
        capsule.SetActive(true);
    }
    void Update()
    {

        if (Mouse.current.leftButton.isPressed && Time.time >= next_fire_cooldown)
        {
            next_fire_cooldown = Time.time + fire_rate;
            flame_thrower();
        }

        bool is_wall_running = is_touching_wall && !is_grounded() && rb.linearVelocity.y <= 0;

       
        // wall on the right of you
        if (is_wall_running && wall_side == 1)
        {
            player_camera.transform.Rotate(0, camera_rotate_angle * Time.deltaTime, 0);
        }
        // wall on the left of you
        if (is_wall_running && wall_side == -1)
        {
            player_camera.transform.Rotate(0, -camera_rotate_angle * Time.deltaTime, 0);
        }





    }

    void FixedUpdate()
    {
        wall_checker();
        bool jumped = Keyboard.current.spaceKey.isPressed;
        bool is_wall_running = is_touching_wall && !is_grounded();
        float current_move_speed = is_grounded() ? move_speed : move_speed * air_control_speed;

        Vector3 movement = Vector3.zero;

        if (Keyboard.current.wKey.isPressed)
            movement += transform.forward;

        if (Keyboard.current.sKey.isPressed)
            movement -= transform.forward;

        if (Keyboard.current.aKey.isPressed)
            movement -= transform.right;

        if (Keyboard.current.dKey.isPressed)
            movement += transform.right;

        movement.Normalize();

        Vector3 velocity = rb.linearVelocity;

        
        velocity.x = movement.x * current_move_speed;
        velocity.z = movement.z * current_move_speed;


        rb.linearVelocity = velocity;


        if (is_touching_wall && !is_grounded() && rb.linearVelocity.y < 0 )
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, -2f, rb.linearVelocity.z);
        }


        if (jumped && is_grounded())
        {
            rb.AddForce(transform.up * jump_height, ForceMode.Impulse);
        }
        
        else if (jumped && !is_grounded() && is_touching_wall)
        {
            
            Vector3 jump_direction = normal_wall + Vector3.up;
            rb.AddForce(jump_direction.normalized * wall_jump_force, ForceMode.Impulse);
            
        }
    }
    

    private int wall_side = 0; // -1 = left, 1 = right, 0 = none

    private void wall_checker()
    {
        
        Vector3 middle_of_player = transform.position + Vector3.up * 0.5f;
        RaycastHit hit;

        if (Physics.Raycast(middle_of_player, transform.right, out hit, wall_check_distance, wall_layer))
        {
            Debug.Log("wall running");
            is_touching_wall = true;
            normal_wall = hit.normal;
            wall_side = 1;
        }
        else if (Physics.Raycast(middle_of_player, -transform.right, out hit, wall_check_distance, wall_layer))
        {
            Debug.Log("wall running");
            is_touching_wall = true;
            normal_wall = hit.normal;
            wall_side = -1;
        }
        else
        {
            //Debug.Log("not touching");
            is_touching_wall = false;
            wall_side = 0;
        }
    }

    void flame_thrower()
    {
        Transform camera = Camera.main.transform;
        GameObject embers = Instantiate(little_embers, embers_fired);
        embers.name = "embers";
        embers.transform.position = camera.position + camera.forward * 1.5f;

        Rigidbody embers_body = embers.GetComponent<Rigidbody>();
        embers_body.AddForce(camera.forward * embers_power);

    }

    
}
    
    

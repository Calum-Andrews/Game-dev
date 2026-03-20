using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Flame_behaviour : MonoBehaviour
{
    [SerializeField] float burn_time;
    [SerializeField] float flame_distance;
    private Vector3 spawn_position;
    private bool gravity_enabled = false;
    

    float start_time;
    void Start()
    {
         start_time = Time.time;
         spawn_position = transform.position;
         
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody ember_body = gameObject.GetComponent<Rigidbody>();
        ember_body.useGravity = true;
        
    }



    void Update()
    {
        float alive_time = Time.time - start_time;
        float distance = Vector3.Distance(spawn_position,transform.position);

        if (distance >= flame_distance && !gravity_enabled)
        {
            Rigidbody ember_body = gameObject.GetComponent<Rigidbody>();
            ember_body.useGravity = true;
            gravity_enabled = true;

        }
        if (alive_time >= burn_time)
        {
            Destroy(gameObject);
        }
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
            

        }
    }
}

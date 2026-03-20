using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private float move_speed;


    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "embers")
        {
            
            Rigidbody enemy_body = gameObject.AddComponent<Rigidbody>();
            
        }


    }
    void Start()
    {
        Debug.Assert(Target != null);   
    }

    void Update()
    {
        Vector3 full_vector_to_target = Target.position - transform.position;
        Vector3 normalised_vector_to_target = full_vector_to_target.normalized;

        transform.position += normalised_vector_to_target * Time.deltaTime * move_speed;
    }
}

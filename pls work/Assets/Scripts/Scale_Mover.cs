using UnityEngine;

public class Scale_Mover : MonoBehaviour
{

    [SerializeField] private bool scale_direction;
    [SerializeField] private float scale_speed;
    [SerializeField] private Transform left_end;
    [SerializeField] private Transform right_end;
    [SerializeField] private GameObject player;
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == left_end || other.transform == right_end)
        {
            if (player != null) 
            {
            Destroy(player);
            }
        }

    }


    void Update()
    {
        if (scale_direction == true) 
        {
            transform.position -= transform.right * scale_speed * Time.deltaTime;


        }
        if (scale_direction == false)
        {
            transform.position += transform.right *scale_speed * Time.deltaTime;


        }
        
    }
    public void toggle_direction()
    {
        scale_direction = !scale_direction;
    }
}

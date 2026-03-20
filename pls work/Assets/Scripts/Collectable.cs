using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Vector3 start_size;
    [SerializeField] private Vector3 rotation_speed;
    [SerializeField] private float bob_speed;
    [SerializeField] private float bob_height;
    void Start()
    {
        start_size = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // grows and shrinks the collectable
        transform.localScale = (1 + Mathf.Sin(Time.time * 3) * 0.2f) * start_size;

        // rotates at speed that user sets it to
        transform.Rotate(rotation_speed);

        //makes the cube bob up and down
        Vector3 position = transform.position;
        position.y = bob_speed + Mathf.Sin(Time.time * 5) * bob_height;
        transform.position = position;
    }
}

using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotation_speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation_speed);
    }
}

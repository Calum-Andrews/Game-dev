using UnityEngine;

public class mover : MonoBehaviour
{
    [SerializeField]
    private Vector3 speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = speed;
    }
}

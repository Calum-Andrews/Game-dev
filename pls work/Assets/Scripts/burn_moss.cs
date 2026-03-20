using UnityEngine;

public class burn_moss : MonoBehaviour
{
    [SerializeField] Material regular_bricks;
    Material mossy_bricks;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "embers")
        {
            Debug.Log("hit");

            GetComponent<Renderer>().material = regular_bricks;
        }
    }
}
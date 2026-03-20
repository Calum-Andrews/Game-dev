using UnityEngine;

public class Pulser : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        float size = Mathf.Sin(Time.time);
        size += 1;
        size /= 2;
        transform.localScale = Vector3.one * size;
    }
}

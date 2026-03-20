using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class Torch : MonoBehaviour
{

    [SerializeField] private float torches_lit;
    [SerializeField] private ParticleSystem flames;
    [SerializeField] private AudioSource audio_source_on_start;
    [SerializeField] private AudioSource audio_source_ambient;
    
    
    private bool lighted_sound_played;
    private float sound_length = 3;
    

    private void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "embers")
        {
            audio_source_on_start.Play();
            lighted_sound_played = true;
            if (torches_lit <= 0)
            {
                Light light = gameObject.AddComponent<Light>();
                torches_lit += 1f;
                light.color = new Color32(255, 160, 70, 255);
                light.intensity = 100f;
                flames.Play();
                Destroy(collision.gameObject);
                StartCoroutine(sound_played());
            }

        }
    }

    IEnumerator sound_played()
    {
        yield return new WaitForSeconds(sound_length);
        audio_source_ambient.Play();
        
        
    }
    public float get_torches_amount()
    {
        return torches_lit;
    
    }
    
}

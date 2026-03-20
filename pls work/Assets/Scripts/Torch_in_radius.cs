using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class Torch_in_radius : MonoBehaviour
{
    [SerializeField] private float torches_lit;
    [SerializeField] private ParticleSystem flames;
    [SerializeField] private AudioSource audio_source_on_start;
    [SerializeField] private AudioSource audio_source_ambient;
    [SerializeField] private GameObject player_in_range;

    private bool lighted_sound_played;
    private float sound_length = 3;


    private void Update()
    {
        Vector3 player_range = player_in_range.transform.position;
        float dist = Vector3.Distance(player_range, transform.position);
        if (dist < 10)
        {
            audio_source_on_start.Play();
            lighted_sound_played = true;
            Light light = gameObject.AddComponent<Light>();
            light.color = new Color32(255, 160, 70, 255);
            light.intensity = 100f;
            flames.Play();
            StartCoroutine(sound_played());
            
        }
        
    }
    

    IEnumerator sound_played()
    {
        yield return new WaitForSeconds(sound_length);
        audio_source_ambient.Play();
    }
    

}


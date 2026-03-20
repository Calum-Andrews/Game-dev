using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class door : MonoBehaviour
{
    [SerializeField] private List<Torch> torches;
    [SerializeField] private float door_open_angle;
    [SerializeField] private float door_opening_speed;
    private AudioSource audio_source;
    [SerializeField] private AudioClip creaking_door_sound;
    [SerializeField] private float door_volume;
    private float door_opened;


    private bool door_opening = false;
    private float target_y;

    void Start()
    {
        target_y = transform.eulerAngles.y + door_open_angle;
        audio_source = GetComponent<AudioSource>();
    }

    void Update()
    {
        int litTorches = 0;

        foreach (Torch torch in torches)
        {
            if (torch.get_torches_amount() > 0)
            {
                litTorches++;
            }
        }

        if (litTorches == torches.Count)
        {
            door_opening = true;
            door_opened += 1;
        }


        if (door_opening)
        {
           
            float new_y = Mathf.MoveTowards(transform.eulerAngles.y, target_y, door_opening_speed * Time.deltaTime);

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, new_y, transform.eulerAngles.z);
        }
        if (door_opened == 1)
        {
            audio_source.volume = door_volume;
            audio_source.PlayOneShot(creaking_door_sound);
            
        }
    }
}


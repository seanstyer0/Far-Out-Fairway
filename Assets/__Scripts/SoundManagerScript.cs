using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip playerPuttSound, playerSwingSound;
    static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        playerPuttSound = Resources.Load<AudioClip>("golfPutt");
        playerSwingSound = Resources.Load<AudioClip>("golfSwing");

        audioSrc = GetComponent<AudioSource>();



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "golfPutt":
                audioSrc.PlayOneShot(playerPuttSound);
                break;
            case "golfSwing":
                audioSrc.PlayOneShot(playerSwingSound);
                break;
        }
    }
}

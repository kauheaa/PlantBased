using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioClip plant, plop, money, birds;
    static AudioSource src;

    // Start is called before the first frame update
    void Start()
    {
        plant = Resources.Load<AudioClip>("plant");
        plop = Resources.Load<AudioClip>("plop");
        money = Resources.Load<AudioClip>("money");
        birds = Resources.Load<AudioClip>("birds");
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "plop":
                    src.PlayOneShot(plop);
                    break;
            case "money":
                    src.PlayOneShot(money);
                    break;
            case "plant":
                    src.PlayOneShot(plant);
                    break;
        }
    }
    public void PlayBirds()
    {
        src.clip = birds;
        src.Play();
    }
}

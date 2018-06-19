using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractOneTimeSound : ObjectInteraction {

    [SerializeField]
    private AudioSource sound;

    [SerializeField]
    private float timeBeforePlaying;

    [SerializeField]
    private GameObject conversationPhone;

    private bool soundIsPlaying;

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(timeBeforePlaying > 0)
        {
            timeBeforePlaying -= Time.deltaTime;
        }

        if(timeBeforePlaying <= 0 && !soundIsPlaying)
        {
            sound.Play();
            soundIsPlaying = true;
        }

        if (Input.GetKeyDown(KeyCode.F) && base.interactable && timeBeforePlaying <= 0)
        {
            sound.Stop();
            if(gameObject.tag == "Phone")
            {
                interactable = false;
                Instantiate(conversationPhone, gameObject.transform);
            }
        }
        base.Update();
    }
}

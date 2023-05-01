using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    public AudioSource Footstep;
    public AudioSource Cardflip;
    public AudioSource Card;
    public AudioSource Combinecard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Footstep.Play();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Cardflip.Play();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Card.Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Combinecard.Play();
        }
    }
}

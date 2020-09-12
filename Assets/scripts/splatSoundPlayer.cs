using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splatSoundPlayer : MonoBehaviour {
    public AudioClip[] splatSounds;
    private AudioSource source;
	// This is so terribly unoptimal but to have real 3d-positioned sounds per paintball, this is how to do it.
	void Start () {
        source = this.GetComponent<AudioSource>();
        var theClip = splatSounds[Random.Range(0, splatSounds.Length - 1)];
        source.clip = theClip;
        source.PlayOneShot(theClip, 1f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

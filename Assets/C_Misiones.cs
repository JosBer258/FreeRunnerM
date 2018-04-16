using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Misiones : MonoBehaviour {
    private AudioSource musicPlayer;
    // Use this for initialization
    void Start () {
        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

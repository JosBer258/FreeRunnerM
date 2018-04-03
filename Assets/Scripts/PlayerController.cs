using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
	private Animator animator;
	public GameObject game;
	public GameObject enemy;
    public AudioClip jumpClip;
    public AudioClip pointClip;
    public AudioClip DieClip;
    private AudioSource audioPlayer;
    private float startY;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		UpdateState("PlayerIdle");
        audioPlayer = GetComponent<AudioSource>();
        startY = transform.position.y;
    }

    // Update is called once per frame
    public void Update () {
        bool isGround = transform.position.y == startY;

		bool gamePlaying = game.GetComponent<GameController>().gameState == GameState.Playing;
		if (isGround && gamePlaying && Input.GetKeyDown ("up") || Input.GetMouseButtonDown (0)){
			UpdateState("PlayerJump");
            audioPlayer.clip = jumpClip;
            audioPlayer.Play();

         
        }
	}


	public void UpdateState(string state=null){
		if(state!=null){
			animator.Play(state);}
	}



	public void OnTriggerEnter2D(Collider2D other){
	
	if(other.gameObject.tag == "Enemy"){

			UpdateState("PlayerDeath");
			game.GetComponent<GameController>().gameState = GameState.End;
			enemy.SendMessage ("CancelGenerator", true);
            game.SendMessage("ResetTimeScale");
            game.GetComponent<AudioSource>().Stop();
            audioPlayer.clip = DieClip;
            audioPlayer.Play();
        }
        else 
   if(other.gameObject.tag == "Point")
   {
            audioPlayer.clip = pointClip;
            audioPlayer.Play();
            game.SendMessage("IncreasePoints");
   }

	}

	public void GetReady(){
		game.GetComponent<GameController>().gameState = GameState.Ready;
	}
}

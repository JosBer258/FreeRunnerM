using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	private Animator animator;
	public GameObject game;
	public GameObject enemy;
    public AudioClip jumpClip;
    public AudioClip pointClip;
    public AudioClip hitEnemy;
    public AudioClip DieClip;
    private AudioSource audioPlayer;
    private float startY;


    public GameObject Corazon_1;
    public GameObject Corazon_2;
    public GameObject Corazon_3;

    private int Lives=3;
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

            Lives = Lives - 1;
            Fun_ReducirCoraz(Lives);
            if (Lives > 0)
            {
                Debug.Log("vive");
                audioPlayer.clip = hitEnemy;
                audioPlayer.Play();
            }
            else
            {
                Debug.Log("Muere");
                Fun_Morir();
                

            }
        }
        else 
   if(other.gameObject.tag == "Point")
   {
            audioPlayer.clip = pointClip;
            audioPlayer.Play();
            game.SendMessage("IncreasePoints");
            Debug.Log("sdfghjhjhgvghjhgvbhu");
        }
        else 
   if (other.gameObject.tag == "MuerteEnemigo")
        {
            game.SendMessage("IncreasePoints");
            game.SendMessage("IncreasePoints");
            Destroy(other);
            if (Lives < 4)
            {
                Lives = Lives + 1;
            }
            audioPlayer.clip = pointClip;
            audioPlayer.Play();
        }
        else if(other.gameObject.tag == "Espina"){

            Lives = Lives - 1;
            Fun_ReducirCoraz(Lives);
            if (Lives > 0)
            {
                Debug.Log("vive");
                audioPlayer.clip = hitEnemy;
                audioPlayer.Play();
            }
            else
            {
                Debug.Log("Muere");
                Fun_Morir();


            }
        }

    }

	public void GetReady(){
		game.GetComponent<GameController>().gameState = GameState.Ready;
	}

    public void Fun_Morir()
    {
        
        UpdateState("PlayerDeath");
        game.GetComponent<GameController>().gameState = GameState.End;
        enemy.SendMessage("CancelGenerator", true);
        game.SendMessage("ResetTimeScale");
        game.GetComponent<AudioSource>().Stop();
        audioPlayer.clip = DieClip;
        audioPlayer.Play();
        SceneManager.LoadScene("Misiones");
    }



    private void Fun_ReducirCoraz(int Vida)
    {
        if (Vida == 3)
        {
            Corazon_1.SetActive(true);
            Corazon_2.SetActive(true);
            Corazon_3.SetActive(true);
        }
        else
        if (Vida == 2)
        {
            Corazon_1.SetActive(false);
            Corazon_2.SetActive(true);
            Corazon_3.SetActive(true);
        }
        else
            if (Vida == 1)
        {
            Corazon_1.SetActive(false);
            Corazon_2.SetActive(false);
            Corazon_3.SetActive(true);
        }
        else
            if (Vida == 0)
        {
            Corazon_1.SetActive(false);
            Corazon_2.SetActive(false);
            Corazon_3.SetActive(false);
        }
    }

    
}

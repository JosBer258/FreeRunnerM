using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public enum GameState{Idle, Playing, End, Ready};
public class GameController : MonoBehaviour {

	[Range (0f, 0.20f)]
	public float parallaxSpeed = 0.02f;
	public RawImage background;
	public RawImage platform;
	public GameObject uiIdle;
    public GameObject Score;
    public Text pointsText;
    public Text recordText;
	public GameState gameState = GameState.Idle;

	public GameObject player;
	public GameObject enemyGenerator;
    private AudioSource musicPlayer;
    private int points;
    public float scaleTime = 30f;
    public float scaleInc=1;
    // Use this for initialization
    void Start() {
        musicPlayer = GetComponent<AudioSource>();
        recordText.text = "BEST: " + GetMazScore().ToString();
    }

	void Update () {

		if (gameState == GameState.Idle && (Input.GetKeyDown ("up") || Input.GetMouseButtonDown (0))) {
		
			gameState = GameState.Playing;
			uiIdle.SetActive (false);
            Score.SetActive(true);

			player.SendMessage ("UpdateState", "PlayerRun");

			enemyGenerator.SendMessage ("StartGenerator");
            musicPlayer.Play();
            
            InvokeRepeating("GameTimeScale",scaleTime, scaleTime);
		} else if (gameState == GameState.Playing) 
		{
			Parallax ();

		} else 
			if (gameState == GameState.Ready) 
		{
			if (Input.GetKeyDown ("up") || Input.GetMouseButtonDown (0)) {
				Restart ();
			}
		}


	}

	void Parallax(){
		float finalSpeed = parallaxSpeed * Time.deltaTime;
		background.uvRect = new Rect (background.uvRect.x + finalSpeed, 0f, 1f, 1f);
		platform.uvRect = new Rect (platform.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);
	}

	public void Restart(){
		SceneManager.LoadScene ("Start");
	}

    public void GameTimeScale()
    {
        Time.timeScale += (scaleInc /2);
        Debug.Log("Aumento" +  Time.timeScale.ToString());
    }

    public void ResetTimeScale()
    {
        CancelInvoke("GameTimeScale");
        Time.timeScale = 1f;
        Debug.Log("Ritmo establecido");
    }


    public void IncreasePoints()
    {
        pointsText.text = (++points).ToString();
        if (points >= GetMazScore()) {
            recordText.text = "BEST: " + points.ToString();
            SaveScore(points);
        }
    }

    public int GetMazScore()
    {
        return PlayerPrefs.GetInt("Max Points", 0);
    }

    public void SaveScore(int currentPoints)
    {
        PlayerPrefs.SetInt("Max Points", currentPoints);
    }
}

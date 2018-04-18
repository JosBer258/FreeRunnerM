using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour {

	public float generatorTimer = 5.75f;
	public GameObject enemyPrefab;
    public GameObject enemyEspin;
    private float time = 8.75f;

	// Use this for initialization
	void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateEnemy(){
		Instantiate (enemyPrefab, transform.position, Quaternion.identity);
        Instantiate(enemyEspin, transform.position, Quaternion.identity);

    }

	public void StartGenerator(){
		InvokeRepeating ("CreateEnemy",0f, time);
	}

	public void CancelGenerator(bool clean = false){
		CancelInvoke ("CreateEnemy");
		if(clean){
			Object[] allEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach (GameObject enemy in allEnemies) {
				Destroy (enemy);
			}
		}

	}


}

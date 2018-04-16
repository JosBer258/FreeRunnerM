using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public float velocity = 1f;
	private Rigidbody2D rb2d;
    public bool Var_Verificar = true;

    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = Vector2.left * velocity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
        

        if (other.gameObject.tag == "Destroyer") {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            Var_Verificar = false;
            Debug.Log(Var_Verificar.ToString());
        }


        if (other.gameObject.tag == "MatarEnemigo" && Var_Verificar==true)
        {

            Destroy(gameObject);
            Debug.Log(Var_Verificar.ToString());
        }

	}

}

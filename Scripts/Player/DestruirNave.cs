using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirNave : MonoBehaviour {


	public GameObject explosion;
	private Enemigo enemigo;

	// Use this for initialization
	void Start () {

		GameObject objectGameController = GameObject.Find("GameController");

		if (objectGameController != null)
		{
			
			enemigo = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemigo>();		
			
		}
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.CompareTag("Player"))
		{

			GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.vida = GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.vida - enemigo.danio;

			if (GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.vida <= 0)
			{

				Instantiate(explosion, transform.position, transform.rotation);
				Destroy(other.gameObject, 0.1f);

			}
		}

	}
}

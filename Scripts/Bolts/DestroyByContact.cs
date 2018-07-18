using UnityEngine;
using System.Collections;


public class DestroyByContact : MonoBehaviour
{
	
    public GameObject explosion;
    private GameController gameController;
	private Enemigo enemigo;


	void Start()
    {
		GameObject objectGameController = GameObject.Find("GameController");

		if (objectGameController != null) {

			gameController = objectGameController.GetComponent<GameController>();

			if(GameObject.FindObjectOfType<SingletonPlayer>().enemigosTmp.Count != 0)
			{

				enemigo = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemigo>();

			}
		}
	}

    void OnTriggerEnter(Collider other)
    {
		
		if (other.CompareTag("Enemy") ) {

			
			enemigo.vida = enemigo.vida - GameObject.FindObjectOfType<SingletonPlayer>().playerTmp.danio;
			gameController.txtVidaEnemigo.text = "Enemigo: " + enemigo.vida;			
			

			if (enemigo.vida <= 0)
			{
				
				gameController.txtVidaEnemigo.text = "Enemigo: 0";
				Instantiate(explosion, transform.position, transform.rotation);

				Destroy(other.gameObject, 0.1f);
				GameObject.FindObjectOfType<SingletonPlayer>().enemigosTmp.RemoveAt(0);
			}
		}		
	}                     
 }

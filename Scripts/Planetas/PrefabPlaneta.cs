using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabPlaneta : MonoBehaviour
{

	public Planeta planeta;
	private Canvas canvasSistemaAtaque;


	void Awake()
	{

		GameObject objectCanvasSistemaAtaque = GameObject.Find("CanvasSistemaAtaque");

		if (objectCanvasSistemaAtaque != null)
		{
			canvasSistemaAtaque = objectCanvasSistemaAtaque.GetComponent<Canvas>();

			if (canvasSistemaAtaque != null)
			{
				canvasSistemaAtaque.enabled = false;
				
			}
			else
			{
				Debug.Log("canvas no encontrado");
			}			
		}	
	}

	public void cargarPlanetas()
	{
		
		SceneManager.LoadScene("SistemaPlanetario", LoadSceneMode.Single);
	}


	private void OnMouseEnter()
	{
		//cargarPlanetas();

		if (GameObject.FindObjectOfType<Singleton>().nebulosaTemp.danger == true)
		{
			GameObject.FindObjectOfType<Singleton>().planetaAtacar.x = this.transform.position.x;
			GameObject.FindObjectOfType<Singleton>().planetaAtacar.z = this.transform.position.z;
			canvasSistemaAtaque.GetComponent<Canvas>().enabled = true;
			Debug.Log("Ataque a" + " : " + this.planeta.nombre);
		}
	}




	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabNebulosa : MonoBehaviour {

	public Nebulosa nebulosa;

	
	public void cargarSistemaPlanetario()
	{

		GameObject.FindObjectOfType<Singleton>().nebulosaTemp = nebulosa;


		foreach (var sistema in nebulosa.sistemasPlanetarios)
		{
			foreach (var planeta in sistema.nodos)
			{

				if (planeta.teletransportador.planetaFK == 1)
				{
					GameObject.FindObjectOfType<Singleton>().planetaTempTeletransportador = planeta;
					GameObject.FindObjectOfType<Singleton>().sistemaTemp = sistema;
					

				}

			}

		}


		SceneManager.LoadScene("SistemaPlanetario", LoadSceneMode.Single);
	}

	
	private void OnMouseDown()
	{
		cargarSistemaPlanetario();
		
	}
}

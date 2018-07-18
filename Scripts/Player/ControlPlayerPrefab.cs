using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerPrefab : MonoBehaviour {

	public GameObject player;


	void Awake()
	{
		//DE LA VIA LACTEA A SISTEMA PLANETARIO CON TELETRANSPORTADOR DE LA NEBULOSA SELECCIONADA
		if(GameObject.FindObjectOfType<Singleton>().bandera == 0)
		{
			cargarPlayerSistemaPlanetario(GameObject.FindObjectOfType<SingletonPlayer>().playerTmp);
			
		}
		//DEL SISTEMA PLANETARIO A LA NEBULOSA
		else if (GameObject.FindObjectOfType<Singleton>().bandera == 1)
		{
			
			cargarPlayerNebulosa(GameObject.FindObjectOfType<SingletonPlayer>().playerTmp);
		}

		//DE LA NEBULOSA AL SISTEMA PLANETARIO
		else if (GameObject.FindObjectOfType<Singleton>().bandera == 2)
		{
			
			cargarPlayerDeNebulosaSistemaPlanetario(GameObject.FindObjectOfType<SingletonPlayer>().playerTmp);

		}else if (GameObject.FindObjectOfType<Singleton>().banderaDropdown == 1)
		{

			cargarPlayerDeNebulosaSistemaPlanetarioDropdown(GameObject.FindObjectOfType<SingletonPlayer>().playerTmp);
		}


	}

	


	public void cargarPlayerSistemaPlanetario(Player playerTmp)
	{
		    var PlanetaTeletransportador = GameObject.FindObjectOfType<Singleton>().planetaTempTeletransportador;


			Vector3 pos = new Vector3(PlanetaTeletransportador.x+35 , PlanetaTeletransportador.y, PlanetaTeletransportador.z);

			GameObject playerPref = Instantiate(player, pos, Quaternion.Euler(0, 0, 0));
			playerPref.GetComponent<PrefabPlayer>().player = playerTmp;
		

	}

	public void cargarPlayerDeNebulosaSistemaPlanetario(Player playerTmp)
	{
		var planeta = GameObject.FindObjectOfType<Singleton>().sistemaTemp.nodos[0];//SELECCIONO EL PRIMER PLANETA EN LA LISTA


		Vector3 pos = new Vector3(planeta.x + 35, planeta.y, planeta.z);

		GameObject playerPref = Instantiate(player, pos, Quaternion.Euler(0, 0, 0));
		playerPref.GetComponent<PrefabPlayer>().player = playerTmp;


	}

	public void cargarPlayerDeNebulosaSistemaPlanetarioDropdown(Player playerTmp)
	{
		var planeta = GameObject.FindObjectOfType<Singleton>().planetaTemp;//SELECCIONO EL PRIMER PLANETA EN LA LISTA


		Vector3 pos = new Vector3(planeta.x + 35, planeta.y, planeta.z);

		GameObject playerPref = Instantiate(player, pos, Quaternion.Euler(0, 0, 0));
		playerPref.GetComponent<PrefabPlayer>().player = playerTmp;


	}

	public void cargarPlayerNebulosa(Player playerTmp)
	{

	
		var nebulosaActual = GameObject.FindObjectOfType<Singleton>().nebulosaTemp;
		var sistemaActual = GameObject.FindObjectOfType<Singleton>().sistemaTemp.id;

		foreach (var sol in nebulosaActual.sistemasPlanetarios) {

			if (sol.id == sistemaActual) {

				Vector3 pos = new Vector3(sol.x+100, sol.y, sol.z);
				GameObject playerPref = Instantiate(player, pos, Quaternion.Euler(0,0,0));
				playerPref.GetComponent<PrefabPlayer>().player = playerTmp;

			}			

		}

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SondaEspacial : MonoBehaviour
{

	public string recolectarElemento1;
	public string recolectarElemento2;
	public int toneladasParaRecolectar;


	void OnTriggerEnter(Collider other)
	{


		if (other.tag == "SpaceScene_Planet")
		{


			Planeta planetaColisionado = other.GetComponent<PrefabPlaneta>().planeta;
			Player player = GameObject.FindObjectOfType<SingletonPlayer>().playerTmp;

			Debug.Log("Recolectando recursos : " + planetaColisionado.nombre + recolectarElemento1 + "," + recolectarElemento2);

			if ((player.capacidadDisponibleMateriales() == true && planetaColisionado.paladio >= 1500))
			{
				planetaColisionado.paladio -= 1500;
				player.paladioRecolectado += 1500;

				planetaColisionado.elementoZero -= 1500;
				player.elementoZeroRecolectado += 1500;

				planetaColisionado.platino -= 1500;
				player.platinoRecolectado += 1500;

				planetaColisionado.iridio -= 1500;
				player.iridioRecolectado += 1500;

			}
			else
			{
				Debug.Log("El planeta no cuenta con recursos necesarios, usa tus sondas sabiamente.");

			}

			
			

		}
		}

	}
	

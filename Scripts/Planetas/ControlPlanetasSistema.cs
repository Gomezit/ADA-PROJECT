using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;





public class ControlPlanetasSistema : MonoBehaviour {

	public GameObject[] modelosPlanetas;
	public GameObject planetaTeletransporteModel;
	public GameObject ModeloplanetaEstacionGasolina;

	void Start()
	{

		cargarPlanetas(GameObject.FindObjectOfType<Singleton>().sistemaTemp.nodos);

	}

	
	private int generarIndexAleatorio() {


		int indexAleatorio = Random.Range(0, modelosPlanetas.Length);
		
		return indexAleatorio;

	}

	public void cargarPlanetas(List<Planeta> planetas)
	{
	
			
	
		foreach (var item in planetas)
		{
			Vector3 pos = new Vector3(item.x, item.y, item.z);

			if (item.teletransportador.planetaFK == 1  )
			{
				
				GameObject planetaTeletransporte = Instantiate(planetaTeletransporteModel, pos, Quaternion.identity);
				planetaTeletransporte.GetComponent<PrefabPlaneta>().planeta = item;
			}

			else if (item.deposito.planetaFK == 1)
			{

				GameObject planetaEstacionGasolina = Instantiate(ModeloplanetaEstacionGasolina, pos, Quaternion.identity);
				planetaEstacionGasolina.GetComponent<PrefabPlaneta>().planeta = item;

			}
			else
			{

				GameObject planeta = Instantiate(modelosPlanetas[generarIndexAleatorio()], pos, Quaternion.identity);
				planeta.GetComponent<PrefabPlaneta>().planeta = item;

			}
			
			
		}

	}




	

}

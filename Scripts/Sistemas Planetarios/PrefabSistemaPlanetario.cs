using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabSistemaPlanetario : MonoBehaviour {

	public SistemaPlanetario sistema;

	public void cargarSistemas()
	{
		GameObject.FindObjectOfType<Singleton>().sistemaTemp = sistema;
		
	}

		
}

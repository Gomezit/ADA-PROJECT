using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GuardarJson : MonoBehaviour {

	public void Guardar() {

		string path = "Assets/ViaLactea.json";
		string json = JsonUtility.ToJson(GameObject.FindObjectOfType<Singleton>().ViaLactea);
		File.WriteAllText(path, json);
		Debug.Log("Cambios Guardados!!");

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Corrutina : MonoBehaviour {

	public Text text;
	// Use this for initialization
	void Start () {

		StartCoroutine(Fade());
		
	}
	
	// Update is called once per frame

	
	void Update () {

		
		
	}


	IEnumerator Fade()
	{
		int cont = 0;
		while(true)
		{
			cont++;
			this.text.GetComponent<Text>().text = "" + cont;
			yield return new WaitForSeconds(.1f);
		}
	}


}


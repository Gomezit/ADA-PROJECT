using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabPlayer : MonoBehaviour {

	public Player player;

	public void cargarPlayer()
	{
		player = new Player();
		GameObject.FindObjectOfType<SingletonPlayer>().playerTmp = player;
		
	}


	
}

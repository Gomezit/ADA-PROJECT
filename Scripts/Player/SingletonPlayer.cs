using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonPlayer : MonoBehaviour {


	public Player playerTmp;
	public List<GameObject> enemigosTmp;




	public static SingletonPlayer singletonPlayer;

	void Awake ()
	{
		enemigosTmp = new List<GameObject>();

		if (SingletonPlayer.singletonPlayer == null)
		{
			singletonPlayer = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
		
	}

	
}

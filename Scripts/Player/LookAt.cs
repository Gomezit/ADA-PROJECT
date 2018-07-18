using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LookAt : MonoBehaviour
{

	//public GameObject target;
	Transform target;

	void Awake()
	{


	}

	// Use this for initialization
	void Start()
	{

		target = GameObject.FindGameObjectWithTag("Player") != null ? GameObject.FindGameObjectWithTag("Player").transform : null;
		StartCoroutine(lookAt());

	}


	IEnumerator lookAt()
	{
		
		while (target != null)
		{
			
			transform.LookAt(target.position);

			yield return new WaitForSeconds(0.3f);

		}

		if (target == null)
		{

			SceneManager.LoadScene("Menu");
		}

	}

}

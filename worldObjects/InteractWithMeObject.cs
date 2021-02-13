using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractWithMeObject : InteractWithMe_Abstract {

	public delegate void AteMe_Del(string objectName);
	public static event AteMe_Del AteMe_Ev;

	protected override void DoThisWhenTouched(string objectName)
	{
		if (objectName == gameObject.name)
		{
			AteMe_Ev(gameObject.name);
			gameObject.SetActive(false);
		}

	}

	protected override void DoThisWhenLookedAt(){


	}



}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractWithMeObject : InteractWithMe_Abstract {

	public delegate void AteMe_Del(string objectName, bool yes);
	public static event AteMe_Del AteMe_Ev;

	protected override void DoThisWhenTouched(string objectName)
	{
		if (objectName == gameObject.name)
		{
			AteMe_Ev(gameObject.name, true);
			gameObject.SetActive(false);
		}

	}

	protected override void DoThisWhenLookedAt(){


	} /// !!! Prawy przycisk myszy też zbiera przedmiot!



}
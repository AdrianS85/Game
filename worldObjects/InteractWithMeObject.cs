using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractWithMeObject : InteractWithMe_Abstract {

	public delegate void AteMe_Del(string objectName, bool yes);
	public static event AteMe_Del AteMe_Ev;

	protected override void DoThisInResponse(bool touched, bool looked, bool interacted, string myName, string interactorName)
	{
		if (myName == gameObject.name && touched)
		{
			AteMe_Ev(gameObject.name, true);
			gameObject.SetActive(false);
		}

	}



}
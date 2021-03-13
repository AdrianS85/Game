using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractWithMeObject : InteractWithMe_Abstract {

	public delegate void AteMe_Del(bool touched, bool looked, bool interacted, string myName, string interactorName, bool ui);
	public static event AteMe_Del AteMe_Ev;

	protected override void DoThisInResponse(bool touched, bool looked, bool interacted, string myName, string interactorName, bool ui)
	{
		if (myName == gameObject.name && touched)
		{
			AteMe_Ev(true, false, false, gameObject.name, "dummy", false);
			gameObject.SetActive(false);
		}

	}



}
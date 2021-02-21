using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //

public class InteractWithMePerson : InteractWithMe_Abstract {
	
	public delegate void IWasTalkedTo_Del(string objectName, bool yes);
	public static event IWasTalkedTo_Del IWasTalkedTo_Ev;

	protected override void DoThisInResponse(bool touched, bool looked, bool interacted, string myName, string interactorName)
	{
		if (myName == gameObject.name && touched)
		{
			IWasTalkedTo_Ev(objectName : gameObject.name, true);
		}
	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //

public class InteractWithMePerson : InteractWithMe_Abstract {
	
	public delegate void IWasTalkedTo_Del(string objectName, bool yes);
	public static event IWasTalkedTo_Del IWasTalkedTo_Ev;

	protected override void DoThisWhenTouched(string objectName)
	{
		if (objectName == gameObject.name)
		{
			IWasTalkedTo_Ev(objectName : gameObject.name, true);
		}
	}

	protected override void DoThisWhenLookedAt(){


	}

}
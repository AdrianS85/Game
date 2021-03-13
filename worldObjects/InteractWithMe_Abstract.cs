using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //

public abstract class InteractWithMe_Abstract : MonoBehaviour {

	//[SerializeField] bool isInteractionPermitedCurrently = false;
	protected abstract void DoThisInResponse(bool touched, bool looked, bool interacted, string myName, string interactorName, bool ui);



	/*void InteractionPermisionSetter(string myName, bool permit){
		if (myName == gameObject.name)
		{
			isInteractionPermitedCurrently = permit;
		}
	}



	public void IWasInteractedWith(bool touched, bool looked, bool combined, string myName, string interactorName){
		

		if (myName == gameObject.name && isInteractionPermitedCurrently == true) // interaction permit doesnt work at all
		{
			Debug.Log("Hello?");
			if (touched && this.enabled)
			{
				Debug.Log("DoThisWhenTouched");
				DoThisWhenTouched(gameObject.name);
			} 
			
			if (looked && this.enabled)
			{
				Debug.Log("DoThisWhenLookedAt");
				DoThisWhenLookedAt();
			}
		}
	}*/

    void Start() {
		//IWasClicked.HeClickedMe_Ev += IWasInteractedWith;
		//ActivateMyParentOnTriggeringMyCollider.HeroReachedMyReach_Ev += InteractionPermisionSetter;
		MoveToMeStopAndDoStuff.StopMoving_Ev += DoThisInResponse;
	}

}
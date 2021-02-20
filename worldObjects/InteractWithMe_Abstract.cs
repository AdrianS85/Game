using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //

public abstract class InteractWithMe_Abstract : MonoBehaviour {

	[SerializeField] bool isInteractionPermitedCurrently = false;
	protected abstract void DoThisWhenTouched(string objectName);
	protected abstract void DoThisWhenLookedAt();



	void InteractionPermisionSetter(string myName, bool permit){
		if (myName == gameObject.name)
		{
			isInteractionPermitedCurrently = permit;
		}
	}



	public void IWasInteractedWith(bool touched, bool looked, bool combined, string myName, string interactorName){
		if (myName == gameObject.name && isInteractionPermitedCurrently == true)
		{
			if (touched && this.enabled)
			{
				DoThisWhenTouched(gameObject.name);
			} 
			
			if (looked && this.enabled)
			{
				DoThisWhenLookedAt();
			}
		}
	}

    void Start() {
		IWasClicked.HeClickedMe_Ev += IWasInteractedWith;
		ActivateMyParentOnTriggeringMyCollider.HeroReachedMyReach_Ev += InteractionPermisionSetter;
		MoveToMeStopAndDoStuff.StopMoving_Ev += DoThisWhenTouched;
	}

}
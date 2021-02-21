using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the target set on this component.
namespace Pathfinding
{
	

	public class AIDestinationSetterCustom : VersionedMonoBehaviour {


		public scriptableObjectSpawner so;
		IAstarAI ai;
		Camera cam;
		GameObject movementTarget_go;
		Transform target;
		GraphicRaycaster m_Raycaster;/// for blocking setting path when on UI
		PointerEventData m_PointerEventData;/// for blocking setting path when on UI
		EventSystem m_EventSystem;/// for blocking setting path when on UI
		bool dontMove = false;


		

		public delegate void heroMovementDelegate(bool doesHeMove, Vector3 currentVelocity);
		public static event heroMovementDelegate heroMovementEvent;


		
		void DontMove(string dummy, bool shallINotMove){
				dontMove = true;
		}

		IEnumerator CancelMovement(){
			ai.isStopped = true;

			Vector2 movementTarget = cam.ScreenToWorldPoint(Input.mousePosition);
			target = GameObject.Find("hero").GetComponent<Transform>();
			ai.destination = target.position;

			yield return new WaitForSeconds(0.5f);
			
			ai.isStopped = false;
		}

		void StopMovingNow(bool touched_, bool looked_, bool interacted_, string myName_, string interactorName_){

			StartCoroutine(CancelMovement());
		}


		void Start()
		{
			cam = Camera.main;

			InteractWithMePerson.IWasTalkedTo_Ev += DontMove;
			InteractWithMeObject.AteMe_Ev += DontMove;
			UISpawner.UIActive_Ev += DontMove;
			MoveToMeStopAndDoStuff.StopMoving_Ev += StopMovingNow;
			
			
			m_Raycaster = GameObject.Find("Canvas").GetComponent<GraphicRaycaster>();/// for blocking setting path when on UI
			m_EventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();/// for blocking setting path when on UI
		}



		void OnEnable () {
			ai = GetComponent<AILerp>(); //IAstarAI
			// Update the destination right before searching for a path as well. This is enough in theory, but this script will also update the destination every frame as the destination is used for debugging and may be used for other things by other scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}



		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		//using at the same tine AIPath and AI Lerp introduces jitter at the end of movement. But jitter during movement is present when using only AIPath too.
		//Picking to small choosing of next waypoint may cause jitter. Just remember to set graphs with larger value in colider diameter (2x should be enough)
		// slowdown helps to elimitate overshooting 
		// Turning of interpolation of path switches removes sligh jitter after fhinishing the movement

		/// !!! if you click very close to sprite, than proper animation does not play, but the one in which direction the sprite is rotated. This comes from eventmenger heroMovementToAnimation function which sends wrong signal about direction of animation. To jest spowodowane chyba tym, że klatka animacji generowana jest na podstawie poprzedniej klatki i następnej klatki. 




		/// Updates the AI's destination every frame
		void Update () {

			
			if (Input.GetMouseButtonDown(so.mouseButtonForUse) == true)
			{
				/// for blocking setting path when on UI
				m_PointerEventData = new PointerEventData(m_EventSystem);
				m_PointerEventData.position = Input.mousePosition;
				List<RaycastResult> results = new List<RaycastResult>();
				m_Raycaster.Raycast(m_PointerEventData, results);
				foreach (RaycastResult result in results)
				{
					dontMove = true;
				}


				if (dontMove == true)
				{
					target = null;
				} else {
					Vector2 movementTarget = cam.ScreenToWorldPoint(Input.mousePosition);
					movementTarget_go = new GameObject("movementTarget_go");
					movementTarget_go.GetComponent<Transform>().position = movementTarget;
					target = movementTarget_go.GetComponent<Transform>();
				}
			}



			if (target != null && ai != null)
			{
				ai.destination = target.position;

				if (movementTarget_go != null)
				{
					Object.Destroy(movementTarget_go);
				}
			} 



			if (ai.velocity == new Vector3(0,0,0))
			{
				heroMovementEvent(false, currentVelocity : ai.velocity);
			} else
			{
				heroMovementEvent(true, currentVelocity : ai.velocity);
			}

			dontMove = false;
		}
	}
}
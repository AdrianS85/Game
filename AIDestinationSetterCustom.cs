using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")] 



	public class AIDestinationSetterCustom : VersionedMonoBehaviour {


		public scriptableObjectSpawner so;
		IAstarAI ai;
        Camera cam;
        private Vector2 movementTarget;
        private GameObject movementTarget_go;
        public Transform target;


		public float test_postion;
		public Vector3 test_vector;
		public Quaternion test_quaternion;
		public bool test_bool = false;
		public Vector2 tempVector2 = new Vector2(1,1);



		public delegate void heroMovementDelegate(bool doesHeMove, Vector3 currentVelocity);
		public static event heroMovementDelegate heroMovementEvent;



		[SerializeField]
		GraphicRaycaster m_Raycaster;/// for blocking setting path when on UI
		PointerEventData m_PointerEventData;/// for blocking setting path when on UI
		[SerializeField]
		EventSystem m_EventSystem;/// for blocking setting path when on UI
		[SerializeField]
		bool blockMovement = false;










        void Start()
        {
            cam = Camera.main;

			m_Raycaster = GameObject.Find("Canvas").GetComponent<GraphicRaycaster>();/// for blocking setting path when on UI
        	m_EventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();/// for blocking setting path when on UI




			//ateMeEMBroadcastEvent(item_name, button_used, didIJustInteractedWithItem);

        }



		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
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




		/// <summary>Updates the AI's destination every frame</summary>
		void Update () {

			blockMovement = false; /// for blocking setting path when on UI
			
			if (Input.GetMouseButtonDown(so.mouseButtonForUse) == true)
            {
				/// for blocking setting path when on UI
				m_PointerEventData = new PointerEventData(m_EventSystem);
            	m_PointerEventData.position = Input.mousePosition;
				List<RaycastResult> results = new List<RaycastResult>();
				m_Raycaster.Raycast(m_PointerEventData, results);
				foreach (RaycastResult result in results)
				{
					Debug.Log("Hit " + result.gameObject.name);
					blockMovement = true;
					Debug.Log(blockMovement);
				}
				/// for blocking setting path when on UI

				movementTarget = cam.ScreenToWorldPoint(Input.mousePosition);
                movementTarget_go = new GameObject("movementTarget_go");
                movementTarget_go.GetComponent<Transform>().position = movementTarget;
                target = movementTarget_go.GetComponent<Transform>();
            }



            if (target != null && ai != null && blockMovement == false) /// for blocking setting path when on UI
			{
				//Debug.Log("wanna move");
				ai.destination = target.position;

				if (movementTarget_go != null)
				{
					Object.Destroy(movementTarget_go);
				}
			} 

			//







			if (ai.velocity == new Vector3(0,0,0))
			{
				heroMovementEvent(false, currentVelocity : ai.velocity);
			} else
			{
				heroMovementEvent(true, currentVelocity : ai.velocity);
			}

			//test_postion = ai.steeringTarget.x;
			//test_vector = ai.velocity; // This is good - it returns 0,0,0 if char is stopped
			//test_quaternion = ai.rotation;

			

			

			//Debug.Log("stopped? " + ai.rotation);






			//if (target != null && ai != null) ai.destination = target.position;
		}





	}


}            
/*
if (target != null && ai != null) ai.destination = target.position;

			if (ai.hasPath == true)
			{
				DestroyObject(movementTarget_go);
			}
            isTargetReached = false;*/

/*if (ai.velocity == new Vector3(0,0,0))
{
	heroMovementEvent(false, currentPosition : ai.steeringTarget);
	//heroMovedInPreviousFrame = false;
} else
{
	heroMovementEvent(true, currentPosition : ai.steeringTarget);
	//heroMovedInPreviousFrame = true;
}*/
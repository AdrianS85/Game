using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivateBehavior
{
	string whoCanActivateMe {get; set;}
	void OnTriggerEnter2D(Collider2D other);
	void OnTriggerExit2D(Collider2D other);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
public class ScriptStatCounter : MonoBehaviour
{
	public int _value;

	public int value
	{
		get { return _value; }
		set { _value = Mathf.Clamp(value, valueMin, valueMax); }
	}



	public int valueMax = 100;
	public int valueMin = 0;
	public int valueStarting = 100;

	public delegate void ValueIs0(); // This only shows template for function subscribing to this delegate?
	public static event ValueIs0 ValueIs0Variable;

	public void valueChangeBy(int change)
	{
		//Need to change
		_value = Mathf.Clamp(_value + change, valueMin, valueMax);
		if(_value == valueMin && ValueIs0Variable != null)
		{
			ValueIs0Variable(); // This method will be run in subscribing objects
			Debug.Log("DEAD");
		}
	}





    void Start()
    {
		this.value = valueStarting; // This is to be changed due to need to save vitality throughout stages
    }

    void Update()
    {
		this.valueChangeBy(-1);
    }
}

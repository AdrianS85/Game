﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CounterDownerAbstraction : MonoBehaviour
{
	[SerializeField]
	private int _value;
    public int value
	{
		get { return _value; }
		set { _value = Mathf.Clamp(value, valueMin, valueMax); }
	}



	public int valueMax;
	public int valueMin;
	public int valueStarting;

	public virtual void SetDefaultValues(int max, int min, int start)
	{
		valueMax = max;
		valueMin = min;
		valueStarting = start;
	}



	public delegate void ValueIsChanged(); // This only shows template for function subscribing to this delegate?
	public static event ValueIsChanged ValueIsChangedVariable;

	public delegate void ValueIs0();
	public static event ValueIs0 ValueIs0Variable;

	public virtual void valueChangeBy(int change)
	{
		//Need to change
		_value = Mathf.Clamp(_value + change, valueMin, valueMax);

		ValueIsChangedVariable(); // This outputs info, that something changed. Therefore, child class knows to update UI appropriately

		if(_value == valueMin && ValueIs0Variable != null)
		{
			ValueIs0Variable(); // This method will be run when counter reaches minimum. This should have some special effect, such as death of a character
			Debug.Log("DEAD");
		}
	}



    void Start()
    {
		 this.value = valueStarting;// This is to be changed due to need to save vitality throughout stages
    }

}

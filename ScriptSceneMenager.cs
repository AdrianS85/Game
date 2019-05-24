using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptSceneMenager : MonoBehaviour
{

    public V_CounterDowner ssc;



    void ValueIs0_Reciever()
    {
        SceneManager.LoadScene("SceneDeath");
    }


    void Start()
    {
        ssc = GameObject.Find("GO_Vitality").GetComponent("V_CounterDowner") as V_CounterDowner;
        V_CounterDowner.ValueIs0Variable += ValueIs0_Reciever;
    }


    void Update()
    {

    }
}

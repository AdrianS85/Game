using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UISpawner : MonoBehaviour
{
    public scriptableObjectSpawner so;
    protected bool isUIActive = false;
    protected Vector3 whereToSpawnMe;
    protected Vector3 whereToDespawnMe;
    public delegate void UIActive_Del(string dummy);
    public static event UIActive_Del UIActive_Ev;



    /*Dictionary<string, string> dict = new Dictionary<string, string>()        {
            { "pickup", "Anal virginity is like leftover pasta. Sweet and suculent, but soon forgotten" }
        };*/

    public IEnumerator HoldMovement(){
        while(isUIActive)
        {
            Debug.Log("HoldMovement1");
            UIActive_Ev("dummy");
            yield return null;
        }
    }



    public void SpawnUI(string objectName){
        foreach (Transform child in gameObject.transform)
            child.gameObject.SetActive(true);

        isUIActive = true;

        gameObject.GetComponent<RectTransform>().localPosition = whereToSpawnMe; /// !!! will need to convert coordinates to viewport, as here: https://forum.unity.com/threads/solved-how-to-convert-recttransform-localposition-to-viewport-coordinates-for-opengl.382353/ , but i don wanna do it now

        StartCoroutine(HoldMovement());

        //if(GameObject.Find("dialogue1") == null){
            /*dialogueOptions = Resources.Load<GameObject>("prefabs/dialogue_select");

            dialogueOptions.transform.SetParent(this.GetComponent<Transform>());

            dialogueOptions.transform.localPosition = new Vector2(0.5f, 0.2f);

            dialogueOptions.GetComponent<Text>().text = "ass";*/
        }


            // Here we need to send another signal to block movement. Coś generalnie chyba trzeba zrobić z tym blokowaniem ruchu. Żeby był jeden punkt zbiorczy - metoda - blokujący ruch którą mogą wywołać  wszystkie elementy. 
            // factory pattern



    public void DeSpawnUI(){
        foreach (Transform child in gameObject.transform)
            child.gameObject.SetActive(false);

        isUIActive = false;

        gameObject.GetComponent<RectTransform>().localPosition = whereToDespawnMe; /// !!! will need to convert coordinates to viewport, as here: https://forum.unity.com/threads/solved-how-to-convert-recttransform-localposition-to-viewport-coordinates-for-opengl.382353/ , but i don wanna do it now
    }




    void Awake() {
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(false); //https://answers.unity.com/questions/594210/get-all-children-gameobjects.html 
        }


        gameObject.GetComponent<RectTransform>().localPosition = whereToDespawnMe;

        whereToSpawnMe = new Vector3(0.5f,0.5f,1f); /// !!! To be changed based on UI object
        whereToDespawnMe = new Vector3(0.5f,0.5f,1f); /// !!! To be changed based on UI object
    }
}

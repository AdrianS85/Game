using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectFactoryAbstraction : MonoBehaviour
{
    public GameObject ObjectPrefab;
    public string whichPrefab;
    public Vector3 whereTo;
    public int howMany;


    // This is function localizing objects. It is specific to object class
    public abstract Vector3 Location();

    // This function actually produces object in given location
    public virtual GameObject produceObject(string gameobjectName, Vector3 gameobjectLocation){
        ObjectPrefab = Instantiate( Resources.Load(gameobjectName) as GameObject );
        ObjectPrefab.GetComponent<Transform>().position = gameobjectLocation;
        return ObjectPrefab;
    }

    //This allows to repeat producing function multiple times
    IEnumerator createThisManyObjects(int nbOfObjects)
        {
            int i = 0;
            while(i < nbOfObjects)
            {
                whereTo = Location();
                produceObject(whichPrefab, whereTo);
                yield return new WaitForSeconds(0.01f);
                i++;
            }
        }


    void Start() {
        StartCoroutine( createThisManyObjects(howMany) ); //Corutine call is neccesary to run IEnumerator properly
    }

}

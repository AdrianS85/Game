using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrDotObjectFactory : ObjectFactoryAbstraction
{
    //Function to generate Vectors3 - where to put the object?
    public override Vector3 Location(){
        return new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
    }



    void Awake(){
        whichPrefab = "MrDot";
        howMany = 10;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPath : MonoBehaviour
{
    [SerializeField] GameObject newCube;



    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();   
        var path = pathfinder.GetPath();


        foreach(Waypoint waypoint in path) {
            var cube =  waypoint.gameObject;
            var cubeChild = cube.transform.Find("Block_Friendly").gameObject; // string dependent
            Transform childTransform = cubeChild.transform;
            Quaternion childRotation = childTransform.localRotation;
            Destroy(cubeChild);

            var instCube = Instantiate(newCube, childTransform.position, childRotation);
            instCube.transform.parent = cube.transform;


        }
    }


}

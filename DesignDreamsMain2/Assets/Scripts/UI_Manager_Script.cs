using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager_Script : MonoBehaviour
{
    // Start is called before the first frame update
    // Reference to the GameObject to instantiate
    public GameObject chair1;

    public GameObject[] chairPrefabs; // Assign chair1, chair2, chair3 prefabs in the Inspector


    // Reference to the target GameObject whose position we'll use
    public GameObject targetPosChair;
    public GameObject brokenTable;
    private GameObject currentChair;


    public GameObject panelHolder;
    public GameObject transitionButton;
    public GameObject buttonPos;

    public GameObject newDb;  // prefab of the new db
    // public GameObject currentDb;  
    public GameObject oldDb;  // this is the reference to the instantiation position
    private Vector3 newDbPos;
    private Quaternion newDbRot;


    private Vector3 targetPositionChair;
    private Quaternion targetRotationChair;



    void Start()
    {
        targetPositionChair = targetPosChair.transform.position;

        newDbPos = oldDb.transform.position;
        newDbRot = Quaternion.identity;

    }

    // Update is called once per frame
    void Update()
    {

    }

    /* public void SetChair1()
     {
         // Get the position of the target GameObject
         //Vector3 targetPosition = targetPos.transform.position;

         Destroy(brokenTable);
         // Set the rotation to zero since we're working in 2D
        // Quaternion targetRotation = Quaternion.identity;

         // Instantiate the object at the target position
         Instantiate(chair1, targetPosition, targetRotation);

         print("We have set chair1");
     }
    */

    private void InstantiateChair(int index)
    {
        // Check if there's an existing chair and destroy it
        if (currentChair != null)
        {
            Destroy(currentChair);
        } 

        // Instantiate the new chair and keep a reference to it
        currentChair = Instantiate(chairPrefabs[index], targetPositionChair, targetRotationChair);
    }

    public void InstantiateChair0()
    {
        if (brokenTable != null)
        {
            Destroy(brokenTable);
        }
        InstantiateChair(0);

    }
    public void InstantiateChair1()
    {
        if (brokenTable != null)
        {
            Destroy(brokenTable);
        }
        InstantiateChair(1);

    }
    public void InstantiateChair2()
    {
        if (brokenTable != null)
        {
            Destroy(brokenTable);
        }
        InstantiateChair(2);

    }

    /*public void CheckAndExit()
    {
        Vector3 pos = buttonPos.transform.position;
        Destroy(panelHolder);
        targetShelfDbPos = targetShelfDb.transform.position;
        targetShelfDbRot = Quaternion.identity;

        currentDb = Instantiate(targetShelfDb, targetShelfDbPos, targetShelfDbRot);


    }
    */

    public void CheckAndExit()
    {
        Destroy(panelHolder);

        Instantiate(newDb, newDbPos, newDbRot);
        // at this point diaogue box 2 should appear
        // Ensure we get the correct position and rotation from the target position
        //targetShelfDbPos = targetShelfDb.transform.position;
        //targetShelfDbRot = targetShelfDb.transform.rotation;

        // Check if there's an existing currentDb and destroy it
        //if (currentDb != null)
        //{
        //    Destroy(currentDb);
        //}

        // Instantiate the new dialogue box at the target position and rotation
        //currentDb = Instantiate(targetShelfDb, targetShelfDbPos, targetShelfDbRot);
    }



}




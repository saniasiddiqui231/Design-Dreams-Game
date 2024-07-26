using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster_Script : MonoBehaviour
{
    // Start is called before the first frame update
    // Reference to the GameObject to instantiate
   // public GameObject toaster1;

    public GameObject[] toasterPrefabs; // Assign toaster1, toaster2, toaster3 prefabs in the Inspector


    // Reference to the target GameObject whose position we'll use
    public GameObject targetPosToaster;
    public GameObject brokenToaster;
    private GameObject currentToaster;


    public GameObject panelHolder;
   // public GameObject transitionButton;
    //public GameObject buttonPos;

    public GameObject UtensilsPanelHolder;

    // public GameObject newDb;  // prefab of the new db
    // public GameObject currentDb;  
    // public GameObject oldDb;  // this is the reference to the instantiation position
    // private Vector3 newDbPos;
    // private Quaternion newDbRot;


    private Vector3 targetPositionToaster;
    private Quaternion targetRotationToaster;



    void Start()
    {
        targetPositionToaster = targetPosToaster.transform.position;
        targetRotationToaster = Quaternion.identity;

        // newDbPos = oldDb.transform.position;
        // newDbRot = Quaternion.identity;

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

    private void InstantiateToaster(int index)
    {
        // Check if there's an existing chair and destroy it
        if (currentToaster != null)
        {
            Destroy(currentToaster);
        } 

        // Instantiate the new chair and keep a reference to it
        currentToaster = Instantiate(toasterPrefabs[index], targetPositionToaster, targetRotationToaster);

        currentToaster.SetActive(true);
    }

    public void InstantiateToaster0()
    {
        if (brokenToaster != null)
        {
            Destroy(brokenToaster);
        }
        InstantiateToaster(0);
        print("Toaster0 instantiate it");

    }
    public void InstantiateToaster1()
    {
        if (brokenToaster != null)
        {
            Destroy(brokenToaster);
        }
        InstantiateToaster(1);
        print("Toaster1 instantiate it");

    }
    public void InstantiateToaster2()
    {
        if (brokenToaster != null)
        {
            Destroy(brokenToaster);
        }
        InstantiateToaster(2);
        print("Toaster2 instantiate it");


    }

    /*public void CheckAndExit()
    {s
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

        // Instantiate(newDb, newDbPos, newDbRot);

        StartCoroutine("EnableUtPanel");

        //shelfPanelHolder.SetActive(true);

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

    IEnumerator EnableUtPanel()
    {
        yield return new WaitForSeconds(2f);
        UtensilsPanelHolder.SetActive(true);

    }



}




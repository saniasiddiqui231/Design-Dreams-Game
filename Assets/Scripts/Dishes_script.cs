using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dishes_script : MonoBehaviour
{
    // Start is called before the first frame update
    // Reference to the GameObject to instantiate
    public GameObject dish1;

    public GameObject[] dishPrefabs; // Assign chair1, chair2, chair3 prefabs in the Inspector


    // Reference to the target GameObject whose position we'll use
    public GameObject targetPosDish;
    public GameObject brokenDish;
    private GameObject currentDish;


    public GameObject panelHolderDish;
    //public GameObject transitionButton;
    //public GameObject buttonPos;


    private Vector3 targetPositionDish;
    private Quaternion targetRotationDish;



    void Start()
    {
        targetPositionDish = targetPosDish.transform.position;
        targetRotationDish = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InstantiateDish(int index)
    {
        // Check if there's an existing chair and destroy it
        if (currentDish != null)
        {
            Destroy(currentDish);
        }

        // Instantiate the new chair and keep a reference to it
        currentDish = Instantiate(dishPrefabs[index], targetPositionDish, targetRotationDish);
    }

    public void InstantiateDish0()
    {
        if (brokenDish != null)
        {
            Destroy(brokenDish);
        }
        InstantiateDish(0);

    }
    public void InstantiateDish1()
    {
        if (brokenDish != null)
        {
            Destroy(brokenDish);
        }
        InstantiateDish(1);

    }
    public void InstantiateDish2()
    {
        if (brokenDish != null)
        {
            Destroy(brokenDish);
        }
        InstantiateDish(2);

    }



    public void CheckAndExit()
    {
        Destroy(panelHolderDish);

    }

}





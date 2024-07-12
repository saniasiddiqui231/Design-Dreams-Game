using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager_Script_Shelf : MonoBehaviour
{
    // Start is called before the first frame update
    // Reference to the GameObject to instantiate
    public GameObject shelf1;

    public GameObject[] shelfPrefabs; // Assign chair1, chair2, chair3 prefabs in the Inspector


    // Reference to the target GameObject whose position we'll use
    public GameObject targetPosShelf;
    public GameObject brokenShelf;
    private GameObject currentShelf;


    public GameObject panelHolderShelf;
    //public GameObject transitionButton;
    public GameObject buttonPos;


    private Vector3 targetPositionShelf;
    private Quaternion targetRotationShelf;



    void Start()
    {
        targetPositionShelf = targetPosShelf.transform.position;
        targetRotationShelf = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InstantiateShelf(int index)
    {
        // Check if there's an existing chair and destroy it
        if (currentShelf != null)
        {
            Destroy(currentShelf);
        }

        // Instantiate the new chair and keep a reference to it
        currentShelf = Instantiate(shelfPrefabs[index], targetPositionShelf, targetRotationShelf);
    }

    public void InstantiateShelf0()
    {
        if (brokenShelf != null)
        {
            Destroy(brokenShelf);
        }
        InstantiateShelf(0);

    }
    public void InstantiateShelf1()
    {
        if (brokenShelf != null)
        {
            Destroy(brokenShelf);
        }
        InstantiateShelf(1);

    }
    public void InstantiateShelf2()
    {
        if (brokenShelf != null)
        {
            Destroy(brokenShelf);
        }
        InstantiateShelf(2);

    }



    public void CheckAndExit()
    {
        Destroy(panelHolderShelf);

    }

}




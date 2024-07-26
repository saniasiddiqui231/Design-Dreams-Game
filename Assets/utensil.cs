using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class utensil : MonoBehaviour
{
    // Start is called before the first frame update
    // Reference to the GameObject to instantiate
    public GameObject utensil1;

    public GameObject[] utPrefabs; // Assign chair1, chair2, chair3 prefabs in the Inspector


    // Reference to the target GameObject whose position we'll use
    public GameObject targetPosUt;
    public GameObject brokenUt;
    private GameObject currentUt;

    public Button proceed;


    public GameObject panelHolderUt;
    //public GameObject transitionButton;
    


    private Vector3 targetPositionUt;
    private Quaternion targetRotationUt;



    void Start()
    {
        targetPositionUt = targetPosUt.transform.position;
        targetRotationUt = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InstantiateUt(int index)
    {
        // Check if there's an existing chair and destroy it
        if (currentUt != null)
        {
            Destroy(currentUt);
        }

        // Instantiate the new chair and keep a reference to it
        currentUt = Instantiate(utPrefabs[index], targetPositionUt, targetRotationUt);
        currentUt.SetActive(true);
        
    }

    public void InstantiateUt0()
    {
        if (brokenUt != null)
        {
            Destroy(brokenUt);
        }
        InstantiateUt(0);

    }
    public void InstantiateUt1()
    {
        if (brokenUt != null)
        {
            Destroy(brokenUt);
        }
        InstantiateUt(1);

    }
    public void InstantiateUt2()
    {
        if (brokenUt != null)
        {
            Destroy(brokenUt);
        }
        InstantiateUt(2);

    }



    public void CheckAndExit()
    {
        Destroy(panelHolderUt);
        proceed.gameObject.SetActive(true);

    }

}




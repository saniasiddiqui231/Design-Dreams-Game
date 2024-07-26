using System.Collections;
using UnityEngine;

public class painting : MonoBehaviour
{
    public GameObject chair1;
    public GameObject[] chairPrefabs; // Assign chair1, chair2, chair3 prefabs in the Inspector
    public GameObject targetPosChair;
    public GameObject brokenTable;
    private GameObject currentChair;
    public GameObject panelHolder;
    public GameObject buttonPos;
    public GameObject shelfPanelHolder;
    // public GameObject newDb;  // prefab of the new db
    // public GameObject oldDb;  // reference to the instantiation position
    // private Vector3 newDbPos;
    // private Quaternion newDbRot;
    private Vector3 targetPositionChair;
    private Quaternion targetRotationChair;

    void Start()
    {
        targetPositionChair = targetPosChair.transform.position;
        targetRotationChair = Quaternion.identity;
        // newDbPos = oldDb.transform.position;
        // newDbRot = Quaternion.identity;
    }

    void Update()
    {
        // Optional: Update logic if needed
    }

    private void InstantiateChair(int index)
    {
        if (currentChair != null)
        {
            Destroy(currentChair);
        } 

        // Debugging: Log position and rotation before instantiation
        Debug.Log("Instantiating chair at position: " + targetPositionChair);
        Debug.Log("With rotation: " + targetRotationChair);

        currentChair = Instantiate(chairPrefabs[index], targetPositionChair, targetRotationChair);
        currentChair.SetActive(true);
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

    public void CheckAndExit()
    {
        Destroy(panelHolder);
        //Instantiate(newDb, newDbPos, newDbRot);
        StartCoroutine("EnableShelfPanel");
    }

    IEnumerator EnableShelfPanel()
    {
        yield return new WaitForSeconds(2f);
        shelfPanelHolder.SetActive(true);
    }
}

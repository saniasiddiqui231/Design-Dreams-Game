using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    public bool box1Appeared = false;
    public static BoxManager instance;
    public bool enableBox2 = false;

     void Awake()
    {
        if(instance ==null)
        {
            instance = this;
        }
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if(gmove.instance.enableDialogBox)
    //     {
    //         anim.Play("fadeOut");
    //         print("fade out animation played");
    //         box1Appeared = true;

    //     }
    //     /*if (Input.GetMouseButtonDown(0)) // 0 is for the left mouse button
    //     {
    //        print("left mouse button clicked");
    //        enableBox2 = true;
    //     }*/
        
    // }
    

    // public void TransitionToBedrom()
    // {
    //     SceneManagementScript.instance.TransitionToScene("LivingRoom 1");
    // }
    public void EnableBox2()
    {
        enableBox2 = true;
    }
}

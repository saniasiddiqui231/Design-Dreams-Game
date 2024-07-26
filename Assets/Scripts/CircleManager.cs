using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
         anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*bool temp = BoxManager.instance.box1Appeared;
        bool temp1 = BoxManager.instance.enableBox2;
        if(temp1 && temp)
        {
            gameObject.SetActive(true);
        }*/
        if(BoxManager.instance.enableBox2)
        {
           // anim.Play("fadeOut");
            print("fade out animation played");
           // box1Appeared = true;

        }
        
    }
}

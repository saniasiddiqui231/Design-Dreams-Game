using UnityEngine;

public class gmove : MonoBehaviour
{
    public float speed = 5.0f;
    public bool enableDialogBox = false;

    public static gmove instance;

    void Awake()
    {
        if(instance ==null)
        {
            instance = this;
        }
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
       // print("This is update function");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        //transform.position += movement * speed * Time.deltaTime;
    }
    public void EnableBox()
    {
        enableDialogBox = true;
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenChangePlay : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Exterior");
    }
}

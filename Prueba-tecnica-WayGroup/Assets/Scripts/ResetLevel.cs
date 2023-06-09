using UnityEngine.SceneManagement;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene()
    {
        SceneManager.LoadScene("Level");
    }
}

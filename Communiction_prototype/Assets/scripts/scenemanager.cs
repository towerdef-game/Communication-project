using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    // Start is called before the first frame update
    public void scenechange()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreanManager : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
}

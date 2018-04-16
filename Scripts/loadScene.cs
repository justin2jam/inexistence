using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public int level;

    public void loadlevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene : MonoBehaviour
{
    public void GoToPlayScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HamaBead");
    }
}

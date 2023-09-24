using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
class NextScene : MonoBehaviour
{
    public void StarttheGame(int nomor)
    {
        SceneManager.LoadScene(nomor);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

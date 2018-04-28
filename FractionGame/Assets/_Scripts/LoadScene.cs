using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public void LoadByIndex(int index)
    {
        StartCoroutine(DelaySceneLoad(index));
    }

    IEnumerator DelaySceneLoad(int index)
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

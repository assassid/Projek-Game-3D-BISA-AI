using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime;
    private PauseMenu pauseMenu;

    public GameObject pauseMenuObj;
    IEnumerator LevelLoaderFunc(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadLevel()
    {
        StartCoroutine(LevelLoaderFunc(SceneManager.GetActiveScene().buildIndex + 1));
    }


    public void UnloadLevel()
    {
        pauseMenu = pauseMenuObj.GetComponent<PauseMenu>();
        pauseMenu.DeactivateMenu();
        StartCoroutine(LevelLoaderFunc(SceneManager.GetActiveScene().buildIndex - 1));
        PlayerUI.LockPointer(false);
    }
}

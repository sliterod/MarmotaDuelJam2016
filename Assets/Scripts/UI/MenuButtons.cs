using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuButtons : MonoBehaviour {

    GameObject loader;

    void Awake() {
        loader = GameObject.Find("Loader");
    }

	public void Credits()
    {
        SceneManager.LoadScene("credits");
    }

    public void Easy()
    {
        Debug.Log("Difficulty set to EASY");
        loader.GetComponent<SelectRooms>().RandomizeScenes(Difficulty.easy);
    }

    public void Normal()
    {
        Debug.Log("Difficulty set to NORMAL");
        loader.GetComponent<SelectRooms>().RandomizeScenes(Difficulty.normal);
    }

    public void Hard()
    {
        Debug.Log("Difficulty set to INSANE");
        loader.GetComponent<SelectRooms>().RandomizeScenes(Difficulty.insane);
    }

    public void Exit() {
        StartCoroutine(ExitCoroutine());
    }

    IEnumerator ExitCoroutine() {
        yield return new WaitForSeconds(1.0f);

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}

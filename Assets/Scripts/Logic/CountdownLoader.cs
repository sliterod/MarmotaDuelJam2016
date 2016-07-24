using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CountdownLoader : MonoBehaviour {

    SelectRooms selectRooms;

	// Use this for initialization
	void Start () {
        selectRooms = GameObject.Find("Loader")
                        .GetComponent<SelectRooms>();

        StartCoroutine(LoadScene());
	}

    IEnumerator LoadScene() {

        string targetScene = "";

        if (selectRooms.CurrentDifficulty == Difficulty.easy) {
            targetScene = "Easy1";
        }
        else if (selectRooms.CurrentDifficulty == Difficulty.normal)
        {
            targetScene = "Normal1";
        }

        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene(targetScene);
    }
}

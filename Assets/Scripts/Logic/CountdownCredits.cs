using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CountdownCredits : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(ReturnToMain());
	}

    IEnumerator ReturnToMain() {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("menu");
    }
}

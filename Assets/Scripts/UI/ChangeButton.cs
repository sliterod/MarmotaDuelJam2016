using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeButton : MonoBehaviour {

    public GameObject[] easy;
    public GameObject[] normal;
    public GameObject[] hard;
    public GameObject[] credits;
    public GameObject[] exit;

    /// <summary>
    /// Changes current sprite
    /// </summary>
    /// <param name="sprite"></param>
    public void ChangeSprite(string name){
        switch (name) {
            case "easy":
                easy[0].SetActive(false);
                easy[1].SetActive(true);
                break;

            case "normal":
                normal[0].SetActive(false);
                normal[1].SetActive(true);
                break;

            case "hard":
                hard[0].SetActive(false);
                hard[1].SetActive(true);
                break;

            case "credits":
                credits[0].SetActive(false);
                credits[1].SetActive(true);
                break;

            case "exit":
                exit[0].SetActive(false);
                exit[1].SetActive(true);
                break;
        }
    }

}

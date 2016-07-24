using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeButton : MonoBehaviour {

    public GameObject[] easy;
    public GameObject[] normal;
    public GameObject[] hard;
    public GameObject[] credits;

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
                break;

            case "hard":
                break;

            case "credits":
                break;
        }
    }

}

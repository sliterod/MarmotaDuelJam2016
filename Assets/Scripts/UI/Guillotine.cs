using UnityEngine;
using System.Collections;

public class Guillotine : MonoBehaviour {

    public Sprite[] bloodyGuillotine;
    public Transform blade;

    /// <summary>
    /// Changes the sprite and the position of guillotine 
    /// </summary>
    void DropGuillotine() {
        ChangeSprite();
        ChangeSpritePosition();
    }

    /// <summary>
    /// Changes sprite position
    /// </summary>
    void ChangeSpritePosition() {
        blade.localPosition = new Vector2 (0.0f, -0.10f);
    }

    /// <summary>
    /// Changes guillotine sprite
    /// </summary>
    void ChangeSprite() {
        blade.GetComponent<SpriteRenderer>().sprite = bloodyGuillotine[1];
    }

    /// <summary>
    /// Reset guillotine values
    /// </summary>
    void ResetGuillotine() {
        blade.localPosition = new Vector2(0.0f, 0.50f);
        blade.GetComponent<SpriteRenderer>().sprite = bloodyGuillotine[0];
    }

    /// <summary>
    /// Disables this hazard
    /// </summary>
    void DisableHazard()
    {
        Debug.Log("Hazard disabled");
        blade.localPosition = new Vector2(0.0f, 1.20f);
    }
}

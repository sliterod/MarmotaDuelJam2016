using UnityEngine;
using System.Collections;

public class CamFade : MonoBehaviour {

    public RectTransform cameraBackground;

	// Use this for initialization
	void Awake () {
        CameraFade(false);
	}

    /// <summary>
    /// Sets the size of the camera background
    /// </summary>
    /// <param name="width">Current width</param>
    /// <param name="height">Current height</param>
    void SetFadeSpriteSize(float width, float height) {
        cameraBackground.sizeDelta = new Vector2(width, height);
    }

    /// <summary>
    /// Activates the camera fade
    /// </summary>
    /// <param name="state"></param>
    public void CameraFade(bool state) {
        if (state)
        {
            SetFadeSpriteSize(2000.0f, 2000.0f);
        }
        else
        {
            SetFadeSpriteSize(0, 0);
        }
    }
}

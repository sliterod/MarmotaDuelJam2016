using UnityEngine;
using System.Collections;

public class CamZoom : MonoBehaviour {

    public bool zoom;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    /// <summary>
    /// Sets zoom values to the camera
    /// </summary>
    /// <param name="position">New camera position</param>
    /// <param name="size">New camera size</param>
    /// <param name="time">Time to make the change from older to newer size</param>
    void Zoom(float position, float size, float time) {

        float currentCameraSize = this.GetComponent<Camera>().orthographicSize;

        this.GetComponent<CamFollow>().CameraXposAddedValue = position;
        this.GetComponent<Camera>().orthographicSize = Mathf.Lerp(currentCameraSize, size, time);
    }

    /// <summary>
    /// Zooms in the camera
    /// </summary>
    public void ZoomIn() {
        Zoom(1.5f, 1.0f, 1.0f);
    }

    /// <summary>
    /// Zooms out the camera
    /// </summary>
    public void ZoomOut()
    {
        Zoom(3.8f, 2.5f, 1.0f);
    }

    /// <summary>
    /// Restores camera to its initial state
    /// </summary>
    public void RestoreCamera() {
        Zoom(2.5f, 1.7f, 1.0f);
    }
}

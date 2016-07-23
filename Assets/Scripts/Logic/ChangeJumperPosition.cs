using UnityEngine;
using System.Collections;

public class ChangeJumperPosition : MonoBehaviour {

    public Transform jumper;

	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetMouseButtonDown(1))
        {
            MoveJumper();
        }
    }

    /// <summary>
    /// Move jumper from one position to another
    /// </summary>
    void MoveJumper() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);

        if (hit)
        {
            if (hit.collider.name == "ColliderPlane") {
                Debug.Log(hit.point.x);
                jumper.transform.position = new Vector2(hit.point.x,
                                                         jumper.transform.position.y);
            }
        }
    }
}

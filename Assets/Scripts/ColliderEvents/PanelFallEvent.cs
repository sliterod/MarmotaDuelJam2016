using UnityEngine;
using System.Collections;

public class PanelFallEvent : MonoBehaviour
{

    public GameObject particles;
    public GameObject floorSprite;

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        particles.SetActive(true);
        floorSprite.SetActive(false);
    }
}

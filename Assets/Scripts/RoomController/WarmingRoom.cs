using UnityEngine;
using System.Collections;

public class WarmingRoom : RoomController{

    public GameObject Deco1;
    public GameObject Deco2;
    public GameObject Deco3;

    // Use this for initialization
    void Start () {
        float RNG = Random.value * 3;
        if(RNG <= 1.0f)
        {
            Deco1.SetActive(true);
        }else if(RNG <= 2.0f)
        {
            Deco2.SetActive(true);
        }
        else
        {
            Deco3.SetActive(true);
        }

	}
}

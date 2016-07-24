using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {

    private int lifeAmount;

    public int LifeAmount
    {
        get
        {
            return lifeAmount;
        }

        set
        {
            lifeAmount = value;
        }
    }

    void Awake() {
        LifeAmount = 9;
    }
}

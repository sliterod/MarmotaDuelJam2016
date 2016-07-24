using UnityEngine;
using System.Collections;

public class SkipTheSignController : RoomController {

    public GameObject Rock1;
    public GameObject Rock2;
    public GameObject Rock3;

    void ActivateTrap()
    {
        Rock1.SendMessage("DropBall");
        Rock2.SendMessage("DropBall");
        Rock3.SendMessage("DropBall");
    }
}

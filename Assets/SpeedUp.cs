using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : ItemBase
{

    public override void Activate()
    {
        FindObjectOfType<Player>().SpeedUp();
    }
}

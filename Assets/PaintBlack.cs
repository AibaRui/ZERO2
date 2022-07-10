using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBlack : ItemBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        FindObjectOfType<Player>().ColorChange(0, 0, 0);
    }

}

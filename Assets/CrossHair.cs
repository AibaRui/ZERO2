using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // マウスカーソルを消す
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    
        // Camera.main でメインカメラ（MainCamera タグの付いた Camera）を取得する
        // Camera.ScreenToWorldPoint 関数で、スクリーン座標をワールド座標に変換する
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Z 座標がカメラと同じになっているので、リセットする

        mousePosition.z = 0;
        this.transform.position = mousePosition;


    }
}

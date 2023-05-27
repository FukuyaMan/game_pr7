using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f; // プレイヤーの移動速度
    public float limit = 10.4f; // 移動制限値

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InvAStart.appearinv)
        {
            // キーの入力を取得
            float moveInput = Input.GetAxisRaw("Horizontal");
            // プレイヤーの現在のx座標
            float newX = transform.position.x + moveInput * speed * Time.deltaTime;
            // 移動範囲の制限
            if(newX >= limit)
            {
                // 右に進む場合，制限値以上に進まないようにする
                newX = limit;
            }
            else if(newX <= -limit)
            {
                newX = -limit;
            }
            // プレイヤーの位置を更新
            transform.position = new Vector2(newX, transform.position.y);

        }
    }
}

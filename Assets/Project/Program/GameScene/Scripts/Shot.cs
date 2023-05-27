using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shot : MonoBehaviour
{
    public UnityEvent OnShotDestroyed; // 弾が破棄された際に発生するイベント
    public float speed = 10f; // 弾の速度
    public string wallName = "Wall";

    void Update()
    {
        // 弾を前方向に移動
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        // もし衝突したオブジェクトが壁でなかったら
        if(collisionInfo.gameObject.name != wallName)
        {
            // 衝突したオブジェクトを破棄
            Destroy(collisionInfo.gameObject);
        }
        // 弾自体を破棄
        Destroy(gameObject);

        // 弾が破棄されたことを通知
        OnShotDestroyed.Invoke();
    }
}

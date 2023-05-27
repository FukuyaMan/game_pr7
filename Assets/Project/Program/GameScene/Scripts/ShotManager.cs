using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : MonoBehaviour
{
    public GameObject shotPrefab; // 弾のプレハブ
    public Vector3 shotSpawnOffset = new Vector3(0, 0.66f, 0); // 弾の発射位置
    private Vector3 initialOffset; // 初期オフセットを保持する変数
    public Transform shotSpawnPoint; // 弾の発射位置
    public int maxShots = 1; // 最大弾数

    private int currentShots; // 現在の弾数

    // Start is called before the first frame update
    void Start()
    {
        currentShots = 0;
        initialOffset = transform.position + shotSpawnOffset;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの現在位置にオフセットを加えて弾の発射位置を計算する
        Vector3 spawnPosition = transform.position + shotSpawnOffset;

        // 初期オフセットと現在のオフセットの差分を計算し，弾の発射位置を修正する
        Vector3 positionOffset = spawnPosition - initialOffset;
        shotSpawnPoint.transform.position = shotSpawnPoint.transform.position + positionOffset;

        // 初期オフセットを更新する
        initialOffset = spawnPosition;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // 弾が最大数未満の場合のみ生成
            if(currentShots < maxShots)
            {
                FireShot();
            }
        }
    }

    private void FireShot()
    {
        GameObject shot = Instantiate(shotPrefab, shotSpawnPoint.position, shotSpawnPoint.rotation);
        currentShots++;
        shot.GetComponent<Shot>().OnShotDestroyed.AddListener(DecreaseShotCount);        
    }

    private void DecreaseShotCount()
    {
        currentShots--;
    }
}

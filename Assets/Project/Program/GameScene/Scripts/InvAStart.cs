using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvAStart : MonoBehaviour
{
    [SerializeField] int waitFrame = 40; // 何フレームおきにインベーダーを出現させるか
    [SerializeField] GameObject parent; // 親オブジェクトを取得する
    [SerializeField] GameObject dummy; // ダミーの敵を取得する
    [SerializeField] float limitXRight = 10f;
    [SerializeField] float limitXLeft = -1f;
    [SerializeField] float limitY = -3f;

    public float speedX = 5f;
    public float speedY = 3f;
    public static bool isClear = false;
    public static bool appearinv=false; // インベーダーが全て出現し終えた後にtrueに変える

    private float currentY;
    private bool amRight=true; // 進行方向が右である時はtrue反対はfalseに変える
    private bool reachLimitX=false; // x軸方向の限界値まで行ったときにtrueに変える

    // Start is called before the first frame update
    void Start()
    {
        appearinv=false;
        isClear = false;
        currentY = parent.transform.position.y;

        foreach(Transform child in parent.transform)
        {
            // 親である場合は処理をスキップ
            if(child.gameObject == gameObject) continue;
            child.gameObject.SetActive(false);
        }
        StartCoroutine(InvActiveCoroutine());
    }

    void Update()
    {
        if(!reachLimitX)
        {
            if(appearinv)
            {
                if(amRight)
                {
                    parent.transform.Translate(Vector3.right * speedX * Time.deltaTime);
                    if(parent.transform.position.x >= limitXRight)
                    {
                        // 左向きに変える
                        amRight = false;
                        reachLimitX=true;
                    }
                }
                else
                {
                    parent.transform.Translate(Vector3.left * speedX * Time.deltaTime);
                    if(parent.transform.position.x <= limitXLeft)
                    {
                        // 右向きに変える
                        amRight = true;
                        reachLimitX=true;
                    }
                }
            }
        }
        else
        {
            if(parent.transform.position.y > (currentY-1f))
            {
                parent.transform.Translate(Vector3.down * speedY * Time.deltaTime);
                if(parent.transform.position.y < limitY)
                {
                    isClear=false;
                    SceneManager.LoadScene("EndScene");
                }
            }
            else
            {
                currentY = parent.transform.position.y;
                reachLimitX = false;
            }
        }
    }

    private IEnumerator InvActiveCoroutine()
    {
        // 子オブジェクトを順にアクティブにする
        foreach(Transform child in parent.transform)
        {
            // waitFrame 待つ
            for (var i=0; i < waitFrame; i++)
            {
                yield return null;
            }

            // 親である場合は処理をスキップ
            if(child.gameObject == gameObject) continue;
            child.gameObject.SetActive(true);
        }
        Destroy(dummy);
        // 全てのインベーダーが出現し終えたことを通知
        appearinv=true;
    }
}

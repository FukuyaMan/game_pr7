using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoInv : MonoBehaviour
{
    private GameObject[] invBox;

    // Update is called once per frame
    void Update()
    {
        invBox = GameObject.FindGameObjectsWithTag("Invader");
        // print(invBox.Length);
        if(invBox.Length == 0)
        {
            InvAStart.isClear = true;
            SceneManager.LoadScene("EndScene");
        }
    }
}

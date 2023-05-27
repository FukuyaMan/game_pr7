using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IsClear : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI clear;

    // Start is called before the first frame update
    void Start()
    {
        if(InvAStart.isClear)
        {
            clear.text = "game\nclear";
        }
        else
        {
            clear.text = "game\nover";
        }
    }
}

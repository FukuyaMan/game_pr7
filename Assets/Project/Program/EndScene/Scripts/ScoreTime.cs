using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTime : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI showScore;
    // Start is called before the first frame update
    void Start()
    {
        if(InvAStart.isClear)
        {
            showScore.text = "time " + TimeManage.clearTime.ToString();
        }
        else
        {
            showScore.text = "";
        }
    }
}

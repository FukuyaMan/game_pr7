using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursolControl : MonoBehaviour
{
    [SerializeField] GameObject cursol;
    private string currentPos = "continue";
    private Vector3 cursolContinue = new Vector3(-2.2f, -3.2f);
    private Vector3 cursolQuit = new Vector3(-2.2f, -4.1f);

    // Start is called before the first frame update
    void Start()
    {
        currentPos = "continue";
        cursol.transform.position = cursolContinue;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentPos != "quit")
            {
                cursol.transform.position = cursolQuit;
                currentPos = "quit";
            } else {
                cursol.transform.position = cursolContinue;
                currentPos = "continue";
            }
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(currentPos != "continue")
            {
                cursol.transform.position = cursolContinue;
                currentPos = "continue";
            } else {
                cursol.transform.position = cursolQuit;
                currentPos = "quit";   
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(currentPos == "continue")
            {
                SceneManager.LoadScene("GameScene");
            } else if(currentPos == "quit")
            {
                SceneManager.LoadScene("StartScene");
            }
        }
    }
}

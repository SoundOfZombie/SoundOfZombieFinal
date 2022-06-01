using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMain : MonoBehaviour
{
    public void ToBackBtn()
    {
        if(this.gameObject.name  == "GoBack")
        {
            SceneManager.LoadScene("StartScene");
        }


    }
}
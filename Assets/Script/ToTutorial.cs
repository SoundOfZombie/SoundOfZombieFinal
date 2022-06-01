using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTutorial : MonoBehaviour
{
    public void ToTutorialBtn()
    {
        if(this.gameObject.name  == "Tutorial")
        {
            SceneManager.LoadScene("Tutorial");
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{

    GameObject BackgroundMusic;
    AudioSource backmusic;

    public void ChangeSceneBtn()
    {
        if(this.gameObject.name  == "StartButton")
        {
            BackgroundMusic = GameObject.Find("BackgroundMusic");
            backmusic = BackgroundMusic.GetComponent<AudioSource>();
            if (backmusic.isPlaying) backmusic.Pause();

            SceneManager.LoadScene("Main");
        }


    }





}

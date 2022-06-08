using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour
{
    public Text TimerText;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        TimerText.text = SceneVariable.time.ToString();
        ScoreText.text = SceneVariable.music.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

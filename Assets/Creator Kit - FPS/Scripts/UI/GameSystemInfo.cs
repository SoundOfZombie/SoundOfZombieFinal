using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystemInfo : MonoBehaviour
{
    public static GameSystemInfo Instance { get; private set; }
    
    public Text TimerText;
    public Text ScoreText;
    public Text LifeText;
    public Text PointText;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateTimer(float time)
    {
        TimerText.text = time.ToString("N1");
    }

    public void UpdateScore(int score)
    {
        ScoreText.text = score.ToString();
    }
    public void UpdateLife(int count)
    {
        //UpdateLife() 함수가 호출되면 현재 목숨 값을 가져와
        //정수로 변경 후 +1을 한 값을 다시 UI에 적용한다.
        int life = int.Parse(LifeText.text) + count;
        LifeText.text = life.ToString();
    }
    public void UpdateMusicBox(int count)
    {
        int musicbox = int.Parse(PointText.text)+count;
        PointText.text = musicbox.ToString();

    }
}


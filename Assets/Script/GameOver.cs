using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [Header("Source")]
    public GameObject tilePrefab;
    public Transform backgroundNode;
    public Transform boardNode;
    public Transform tetrominoNode;
    public GameObject gameoverPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 오버 처리
        if(gameoverPanel.activeSelf)
        {
            // 타이머 다 되었을 때

            // 목숨 사라졌을 때

            // 음악상자 다 찾았을 때
        }
    }
}

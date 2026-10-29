using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MenuUiStartUp : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public TMP_InputField EnterPlayerName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetBestScore();
        SetPlayerName();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SetBestScore()
    {
        Score.text = "Best Score: " + MenuUiManager.Instance.bestScore;
    }
    private void SetPlayerName()
    {
        EnterPlayerName.text = MenuUiManager.Instance.playerName;
    }
}

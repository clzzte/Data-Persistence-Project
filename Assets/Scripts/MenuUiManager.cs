using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUiManager : MonoBehaviour
{
    public static MenuUiManager Instance;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI EnterPlayerName;
    public string bestScorePlayerName;
    public string playerName;
    public int bestScore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {  
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPlayerName()
    {
        playerName = EnterPlayerName.text;
        SaveGames();
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    SaveData data = new SaveData();
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string bestScorePlayerName;
        public int bestScore;
    }

    public void SaveGames()
    {
        data.bestScorePlayerName = bestScorePlayerName;
        data.bestScore = bestScore;
        data.playerName = playerName;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            playerName = data.playerName;
            bestScorePlayerName = data.bestScorePlayerName;
        }
    }
}

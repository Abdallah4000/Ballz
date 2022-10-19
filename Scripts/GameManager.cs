using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI highScoreText;

    public int score = 0 ;
    public int level = 0;
    public int highScore = 0;
    void Awake()
    {
        if(gm == null)
            gm = this;
        else
            GameObject.Destroy(this);

            
        LoadPlayerScore();
    }
    void Update()
    {
        scoreText.text = $"Score : {score.ToString()}" ;
        levelText.text = $"Level : {level.ToString()}" ;
        highScoreText.text = $"High Score : {highScore.ToString()}";
    }

    [System.Serializable]
    class HighScore
    {
        public int Score;
    }

    public void SaveHihgScore()
    {
        HighScore PlayerScore = new HighScore ();

        PlayerScore.Score = highScore;

        string json = JsonUtility.ToJson(PlayerScore);
        File.WriteAllText(Application.persistentDataPath +"/bubble.json",json);
    }

    public void LoadPlayerScore()
    {
        string path = Application.persistentDataPath + "/bubble.json";
        if(File.Exists(path))
        { 
            string json = File.ReadAllText(path);
            HighScore PlayerScore = JsonUtility.FromJson<HighScore>(json);
            highScore = PlayerScore.Score;
        }
    }

}

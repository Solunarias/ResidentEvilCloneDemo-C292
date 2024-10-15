using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI healthTxt;

    private int globalScore = 0;

    public delegate void OnZombieDie(int score);
    public static OnZombieDie zombieDeath;
    void Start()
    {
        scoreTxt = GameObject.Find("ScoreTxt").GetComponent<TextMeshProUGUI>();
        healthTxt = GameObject.Find("HealthTxt").GetComponent<TextMeshProUGUI>();

        //zombieDeath += TestFunction;
        zombieDeath += UpdateScore;

        if (zombieDeath != null)
        {
            zombieDeath.Invoke(10);
        }
    }

    // Update is called once per frame
    public void TestFunction()
    {
        Debug.Log("Test");
    }

    private void UpdateScore(int score)
    {
        globalScore += score;
        scoreTxt.text = "Score: " + globalScore;
    }
}

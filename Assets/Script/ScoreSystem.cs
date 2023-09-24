using UnityEngine;
using UnityEngine.UI;
using TMPro;
class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI apalah;
    [HideInInspector] public int Score;
    private void Start()
    {
        Score = 0;
        apalah.text = "Score: 0";
        if (!PlayerPrefs.HasKey("High"))
        {
            PlayerPrefs.SetInt("High", 0);
        }
    }
    public void ScoreUpdate(int Score)
    {
        apalah.text = "Score: " + Score.ToString();
    }
}

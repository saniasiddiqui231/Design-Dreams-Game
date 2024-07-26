using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public sealed class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance { get; private set; }
    private int _score;
    public Button backButton;
    
    public int Score
    {
        get => _score;
        set
        {
            if (_score == value) return;

            _score = value;

            if (scoreText != null)
            {
                scoreText.SetText($"{_score}");
            }
            else
            {
                Debug.LogError("Score TextMeshProUGUI is not assigned in the Inspector");
            }
        }
    }
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        backButton.interactable = false;
        // Ensure this is the only instance of the score
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Update()
    {

        print("Score = " + Score);

        if (Score >= 50){
            //ButtonManagerScript.bms.EnableButton();
            backButton.interactable = true;
            

        }
    }
}

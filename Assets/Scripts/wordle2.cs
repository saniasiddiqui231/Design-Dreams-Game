using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections; 

public class wordle2 : MonoBehaviour
{
    private static readonly KeyCode[] SUPPORTED_KEYS = new KeyCode[]{
        KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F,
        KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, 
        KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R,
        KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X,
        KeyCode.Y, KeyCode.Z,
    };
    private row_w[] rows;
    private string[] solutions;
    private string[] validwords;
    private string word;
    private int rowIndex;
    private int columnIndex;
    [Header("States")]
    public tile_w.State emptyState;
    public tile_w.State occupiedState;
    public tile_w.State correctState;
    public tile_w.State wrongSpotState;
    public tile_w.State incorrectState;
    [Header("UI")]
    public TextMeshProUGUI invalidWordText;
    public TextMeshProUGUI feedbackMessageText; // New TextMeshProUGUI for feedback messages

    public TextMeshProUGUI tryAgain;
    public Button playAgainButton;
    public Button proceedButton;
    // public GameObject girl;

    public float buttonActiveTime = 3f;

    private void Awake(){
        rows = GetComponentsInChildren<row_w>();
    }

    private void Start() {
        LoadData();
        PlayAgain();
        
    }

    public void PlayAgain(){
        ClearBoard();
        SetRandomWord();
        enabled = true;
    }
    
    private void LoadData(){
       TextAsset textFile = Resources.Load("all_words") as TextAsset;
       validwords = textFile.text.Split('\n');

       textFile = Resources.Load("common_words") as TextAsset;
       solutions = textFile.text.Split('\n');
    }

    private void SetRandomWord() {
        word = solutions[Random.Range(0, solutions.Length)];
        word = word.ToLower().Trim();
        //word = "games";
    }

    private void Update()
    {
        row_w currentRow = rows[rowIndex];
        if (Input.GetKeyDown(KeyCode.Backspace)){
            columnIndex = Mathf.Max(columnIndex - 1, 0);
            currentRow.tiles[columnIndex].SetLetter('\0');
            currentRow.tiles[columnIndex].SetState(emptyState);

            invalidWordText.gameObject.SetActive(false);
        }
        else if (columnIndex >= currentRow.tiles.Length){
            if (Input.GetKeyDown(KeyCode.Return)){
                SubmitRow(currentRow);
                //rowIndex++;
                //columnIndex = 0;
            }
        }
        else {
            for (int i =0; i < SUPPORTED_KEYS.Length; i++){
                if (Input.GetKeyDown(SUPPORTED_KEYS[i])){
                    currentRow.tiles[columnIndex].SetLetter((char)SUPPORTED_KEYS[i]);
                    currentRow.tiles[columnIndex].SetState(occupiedState);
                    columnIndex++;
                    break;
                }
            }
        }
    }

    private void SubmitRow(row_w row){
        row_w currentRow = rows[rowIndex];
        if (!IsValidWord(row.word)){
            invalidWordText.gameObject.SetActive(true);
            return;
        }

        string remaining = word;
        bool hasGreen = false;
        bool hasYellow = false;
        
        for (int i = 0; i < row.tiles.Length; i++){
            tile_w tile1 = row.tiles[i];

            if (tile1.letter == word[i]){
                tile1.SetState(correctState);
                remaining = remaining.Remove(i, 1);
                remaining = remaining.Insert(i, " ");
                hasGreen = true;
            }
            else if (!word.Contains(tile1.letter)){
                tile1.SetState(incorrectState);
            }
        }

        for (int i = 0; i < row.tiles.Length; i++){
            tile_w tile1 = row.tiles[i];

            if (tile1.state != correctState && tile1.state != incorrectState){
                if (remaining.Contains(tile1.letter)){
                    tile1.SetState(wrongSpotState);
                    // betweenButton.gameObject.SetActive(true);
                    StartCoroutine(HideButtonAfterDelay());
                    int index = remaining.IndexOf(tile1.letter);
                    remaining = remaining.Remove(index, 1);
                    remaining = remaining.Insert(index, " ");
                    hasYellow = true;
                }
                else {
                    tile1.SetState(incorrectState);
                }
            }
        }

        DisplayFeedbackMessage(hasGreen, hasYellow);

        if (HasWon(row)){
            enabled = false;
            proceedButton.gameObject.SetActive(true);
            feedbackMessageText.gameObject.SetActive(false);
            tryAgain.gameObject.SetActive(false);
        }

        rowIndex++;
        columnIndex = 0;
        if (rowIndex >= rows.Length){
            enabled = false;
        }
    }

    private void DisplayFeedbackMessage(bool hasGreen, bool hasYellow) {
        if (hasGreen && hasYellow) {
            feedbackMessageText.text = "Great! You have some letters in the correct spots and some in the wrong spots.😁😁";
        } else if (hasGreen) {
            feedbackMessageText.text = "Spot on! You got some letters in the correct place ;)";
        } else if (hasYellow) {
            feedbackMessageText.text = "Good job! You have some letters in the word but in the wrong spots :)";
        } else {
            feedbackMessageText.text = "Keep trying! No correct letters this time :(";
        }
    }

    IEnumerator HideButtonAfterDelay()
    {
        // Wait for the specified time
        yield return new WaitForSeconds(buttonActiveTime);

    
    }

    private void ClearBoard() {
        Debug.Log("ClearBoard called");
        for (int row = 0; row < rows.Length; row++) {
            for (int col = 0; col < rows[row].tiles.Length; col++) {
                rows[row].tiles[col].SetLetter('\0');
                rows[row].tiles[col].SetState(emptyState);
                Debug.Log($"Cleared tile at row {row}, col {col}");
            }
        }
        rowIndex = 0;
        columnIndex = 0;
        Debug.Log("Board cleared and indices reset");
    }

    private bool IsValidWord(string word){
        for (int i =0; i < validwords.Length; i++){
            if (validwords[i] == word){
                return true;
            }
        }
        return false;
    }

    private bool HasWon(row_w row){
        for (int i = 0; i < row.tiles.Length; i++){
            if (row.tiles[i].state != correctState){
                return false;
            }
        }
        return true;
    }

    private void OnEnable(){
        proceedButton.gameObject.SetActive(false);
        playAgainButton.gameObject.SetActive(false);
    }

    private void OnDisable(){
        playAgainButton.gameObject.SetActive(true);
        feedbackMessageText.gameObject.SetActive(false);
        tryAgain.text = "Oh oh! You need to play again to proceed to the next step :(";
        //proceedButton.gameObject.SetActive(true);
    }
}
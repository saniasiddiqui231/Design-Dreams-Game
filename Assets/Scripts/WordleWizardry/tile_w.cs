using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class tile_w : MonoBehaviour
{
    [System.Serializable]
    public class State{
        public Color fillColor;
        public Color outlineColor;
    }
    private TextMeshProUGUI text;
    private Image fill;
    private Outline outline;
    public State state {get; private set;}
    public char letter {get; private set;}
    private void Awake(){
        text = GetComponentInChildren<TextMeshProUGUI>();
        fill = GetComponent<Image>();
        outline = GetComponent<Outline>();

    }
    public void SetLetter(char letter){
        this.letter = letter;
        text.text = letter.ToString();
    }
    public void SetState(State state){
        this.state = state;
        fill.color = state.fillColor;
        outline.effectColor = state.outlineColor;

        

    }

    
}

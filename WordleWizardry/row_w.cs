using UnityEngine;

public class row_w : MonoBehaviour
{
    public tile_w[] tiles {get; private set;}
    public string word{
        get{
            string word = "";
            for (int i = 0; i < tiles.Length; i++){
                word += tiles[i].letter;
            }
            return word;
        }
    }
    private void Awake(){
        tiles = GetComponentsInChildren<tile_w>();

    }
}

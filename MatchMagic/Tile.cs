using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public sealed class Tile : MonoBehaviour
{
    public int x;
    public int y;
    private Item item;
    public Item Item
    {
        get => item;
        set
        {
            if (item == value) return;
            item = value;

            if (item == null)
            {
                Debug.LogWarning($"Item is null for Tile at position ({x}, {y})");
            }

            if (icon != null)
            {
                icon.sprite = item != null ? item.sprite : null;
            }
            else
            {
                Debug.LogWarning($"Icon is not assigned for Tile at position ({x}, {y})");
            }
        }
    }
    public Image icon;
    public Button button;

    private Tile GetNeighbor(int offsetX, int offsetY)
    {
        int newX = x + offsetX;
        int newY = y + offsetY;
        if (newX >= 0 && newX < Board.Instance.Width && newY >= 0 && newY < Board.Instance.Height)
        {
            return Board.Instance.Tiles[newX, newY];
        }
        return null;
    }

    public Tile Left => GetNeighbor(-1, 0);
    public Tile Top => GetNeighbor(0, -1);
    public Tile Right => GetNeighbor(1, 0);
    public Tile Bottom => GetNeighbor(0, 1);

    public Tile[] Neighbors => new[] { Left, Top, Right, Bottom };

    private void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(() => OnTileClicked().ConfigureAwait(false));
        }
        else
        {
            Debug.LogWarning($"Button component is not assigned for Tile at position ({x}, {y})");
        }
    }

    private async Task OnTileClicked()
    {
        if (Board.Instance != null)
        {
            await Board.Instance.Select(this);
        }
        else
        {
            Debug.LogError("Board.Instance is null. Ensure Board is properly initialized.");
        }
    }

    public List<Tile> GetConnectedTiles(List<Tile> exclude = null)
    {
        var result = new List<Tile> { this };
        if (exclude == null)
        {
            exclude = new List<Tile> { this };
        }
        else
        {
            exclude.Add(this);
        }
        foreach (var neighbor in Neighbors)
        {
            if (neighbor == null || exclude.Contains(neighbor) || neighbor.Item != Item)
                continue;
            result.AddRange(neighbor.GetConnectedTiles(exclude));
        }
        return result;
    }
}

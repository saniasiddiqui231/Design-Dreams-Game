using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using System;

public sealed class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private AudioSource audioSource;
    public Row[] rows;
    public Tile[,] Tiles { get; private set; }
    public GameObject tilePrefab; 

    public int Width => Tiles.GetLength(0);
    public int Height => Tiles.GetLength(1);
    private readonly List<Tile> selection = new List<Tile>();
    private const float TweetDuration = 0.25f;

    private void Awake() => Instance = this;

    private void Start()
    {
       
        if (ItemDatabase.Item == null || ItemDatabase.Item.Length == 0)
        {
            Debug.LogError("ItemDatabase.Item is not initialized or empty");
            return;
        }

        
        if (rows == null || rows.Length == 0)
        {
            Debug.LogError("Rows array is not initialized or empty");
            return;
        }

        int maxRowLength = rows.Max(row => row.tiles?.Length ?? 0);
        Tiles = new Tile[maxRowLength, rows.Length];

        for (var y = 0; y < rows.Length; y++)
        {
            if (rows[y] == null || rows[y].tiles == null)
            {
                Debug.LogError($"Row {y} or its tiles array is not initialized");
                continue;
            }

            for (var x = 0; x < rows[y].tiles.Length; x++)
            {
                var tile = rows[y].tiles[x];
                if (tile == null)
                {
                    Debug.LogError($"Tile at position ({y}, {x}) is not initialized");
                    continue;
                }

                tile.x = x;
                tile.y = y;

                
                Item randomItem = ItemDatabase.Item[UnityEngine.Random.Range(0, ItemDatabase.Item.Length)];
                if (randomItem == null)
                {
                    Debug.LogError($"Random item is null for Tile at position ({x}, {y})");
                    continue;
                }
                tile.Item = randomItem;
                Tiles[x, y] = tile;

               
                SpriteRenderer spriteRenderer = tile.GetComponent<SpriteRenderer>();
                if (spriteRenderer == null)
                {
                    Debug.LogWarning($"Tile at position ({y}, {x}) does not have a SpriteRenderer component. Adding one.");
                    spriteRenderer = tile.gameObject.AddComponent<SpriteRenderer>();
                }

                if (tile.icon != null)
                {
                    tile.icon.sprite = randomItem.sprite;
                }
                else
                {
                    Debug.LogError($"Tile at position ({y}, {x}) does not have an icon assigned.");
                }
            }
        }
       
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.A)) return;
        foreach (var connectedTile in Tiles[0, 0].GetConnectedTiles()) 
            connectedTile.icon.transform.DOScale(1.25f, TweetDuration).Play();
    }

    public async Task Select(Tile tile)
    {
        if (!selection.Contains(tile))
        {
            if (selection.Count > 0){
                if (Array.IndexOf(selection[0].Neighbors, tile) != -1){
                    selection.Add(tile);
                }

            }
            else{
                selection.Add(tile);

            }
            
        }
        
        if (selection.Count < 2)
        {
            return;
        }

        
        await Swap(selection[0], selection[1]);
        if (CanPop())
        {
            Pop();
        }
        else
        {
            await Swap(selection[0], selection[1]);
        }
        selection.Clear();
    }

    public async Task Swap(Tile tile1, Tile tile2)
    {
        var icon1 = tile1.icon;
        var icon2 = tile2.icon;
        var icon1Transform = icon1.transform;
        var icon2Transform = icon2.transform;

        var sequence = DOTween.Sequence();
        sequence.Join(icon1Transform.DOMove(icon2Transform.position, TweetDuration))
                .Join(icon2Transform.DOMove(icon1Transform.position, TweetDuration));
        await sequence.Play().AsyncWaitForCompletion();

        icon1Transform.SetParent(tile2.transform);
        icon2Transform.SetParent(tile1.transform);

        tile1.icon = icon2;
        tile2.icon = icon1;

        var tileItem = tile1.Item;
        tile1.Item = tile2.Item;
        tile2.Item = tileItem;
    }

    private bool CanPop()
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                if (Tiles[x, y].GetConnectedTiles().Skip(1).Count() >= 2)
                    return true;
            }
        }
        return false;
    }

    private async void Pop()
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var tile = Tiles[x, y];
                var connectedTiles = tile.GetConnectedTiles();
                if (connectedTiles.Skip(1).Count() < 2) continue;

                var deflateSequence = DOTween.Sequence();
                foreach (var connectedTile in connectedTiles) 
                    deflateSequence.Join(connectedTile.icon.transform.DOScale(Vector3.zero, TweetDuration)); 

                audioSource.PlayOneShot(collectSound);
                ScoreCounter.Instance.Score += tile.Item.value * connectedTiles.Count;
                await deflateSequence.Play().AsyncWaitForCompletion(); 

                

                var inflateSequence = DOTween.Sequence();
                foreach (var connectedTile in connectedTiles)
                {
                    connectedTile.Item = ItemDatabase.Item[UnityEngine.Random.Range(0, ItemDatabase.Item.Length)];
                    inflateSequence.Join(connectedTile.icon.transform.DOScale(Vector3.one, TweetDuration));
                }
                await inflateSequence.Play().AsyncWaitForCompletion();   

                x = 0;
                y = 0;         
            }
        }
    }
}

using UnityEngine;

public static class ItemDatabase
{
    public static Item[] Item { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        Item = Resources.LoadAll<Item>("Items/");

        if (Item == null || Item.Length == 0)
        {
            Debug.LogError("ItemDatabase is not properly initialized or is empty.");
        }
        else
        {
            Debug.Log($"ItemDatabase initialized with {Item.Length} items.");
            foreach (var item in Item)
            {
                Debug.Log($"Loaded item: {item.name} with sprite: {(item.sprite != null ? item.sprite.name : "None")}");
            }
        }
    }
}

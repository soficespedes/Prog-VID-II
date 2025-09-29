using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    private List<string> items = new List<string>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Agregar un item
    public void AddItem(string item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
            Debug.Log(item + " agregado al inventario");
        }
    }

    // Verificar si tienes el item
    public bool HasItem(string item)
    {
        return items.Contains(item);
    }

    // Remover item del inventario
    public void RemoveItem(string item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log(item + " removido del inventario");
        }
    }
}

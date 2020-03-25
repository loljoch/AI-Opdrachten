using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gridmaker : MonoBehaviour
{
    public Vector2Int gridSize;
    [HideInInspector] public static Node[,] grid;
    [SerializeField] private Node nodePrefab;

    private void Awake()
    {
        MakeGrid();
    }

    [EasyButtons.Button]
    private void MakeGrid()
    {
        grid = new Node[gridSize.x, gridSize.y];

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                grid[x, y] = SpawnNode(x, y);
            }
        }
    }

    [EasyButtons.Button]
    private void DestroyGrid()
    {
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child != transform)
            {
                DestroyImmediate(child.gameObject);
            }
        }

        grid = new Node[0,0];
    }

    private Node SpawnNode(int x, int y)
    {
        Node current = Instantiate(nodePrefab, transform, true);
        current.transform.position = new Vector3(x, y, 0);
        current.position = new Vector2Int(x, y);

        return current;
    }
}


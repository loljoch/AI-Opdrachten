using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotentialFields : MonoBehaviour
{
    public void FloodBoard(Node[,] grid, Node targetNode)
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                int newVal = CalculateValue(grid[x, y].position, targetNode.position);
                if (newVal < grid[x,y].value)
                {
                    grid[x, y].ChangeValue(newVal);
                }
            }
        }

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                if (!grid[x, y].IsWalkable)
                {
                    List<Node> neighbours = GetNeighbours(grid[x, y], grid);
                    for (int i = 0; i < neighbours.Count; i++)
                    {
                        neighbours[i].ChangeValue(neighbours[i].value + 2);
                    }
                }
            }
        }
    }

    public List<Node> GetNeighbours(Node fromNode, Node[,] grid)
    {
        List<Node> nodeList = new List<Node>();

        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                int cellX = fromNode.position.x + x;
                int cellY = fromNode.position.y + y;

                if (cellX < 0 || cellX >= grid.GetLength(0) || cellY < 0 || cellY >= grid.GetLength(1) || (x == 0 && y == 0))
                {
                    continue;
                }

                if (!grid[cellX, cellY].IsWalkable)
                {
                    continue;
                }

                nodeList.Add(grid[cellX, cellY]);
            }
        }

        return nodeList;
    }

    public Node GetLowestNeighbour(Vector2Int fromNode, Node[,] grid)
    {
        Node lowestValue = grid[fromNode.x, fromNode.y];
        if (lowestValue.value == 0)
        {
            return null;
        }

        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                int cellX = fromNode.x + x;
                int cellY = fromNode.y + y;

                if (cellX < 0 || cellX >= grid.GetLength(0) || cellY < 0 || cellY >= grid.GetLength(1) || (x == 0 && y == 0))
                {
                    continue;
                }

                if (!grid[cellX, cellY].IsWalkable)
                {
                    continue;
                }

                if (grid[cellX, cellY].value <= lowestValue.value)
                {
                    lowestValue = grid[cellX, cellY];
                }
            }
        }

        return lowestValue;
    }

    public int CalculateValue(Vector2Int cPos, Vector2Int targetPos)
    {
        int xDistance = Mathf.Abs(cPos.x - targetPos.x);
        int yDistance = Mathf.Abs(cPos.y - targetPos.y);

        return xDistance + yDistance;
    }
}

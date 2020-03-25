using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extensions.Singleton;

public class MouseInput : GenericSingleton<MouseInput, MouseInput>
{
    public Node focusedNode;
    public Agent[] agentList = new Agent[10];
    [HideInInspector] public static PotentialFields potentialFields = new PotentialFields();

    private void Update()
    {
        if (focusedNode != null)
        {
            if (Input.GetMouseButtonDown(0)) // left
            {
                WalkToThisNode();
            } else if (Input.GetMouseButtonDown(1)) //right
            {
                focusedNode.IsWalkable = !focusedNode.IsWalkable;
            } else if (Input.GetMouseButtonDown(2)) //middle
            {
                ResetGrid(Gridmaker.grid);
            }
        }
    }

    private void ResetGrid(Node[,] grid)
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                grid[x, y].ResetNode();
            }
        }
    }

    private void WalkToThisNode()
    {
        potentialFields.FloodBoard(Gridmaker.grid, focusedNode);
        if (agentList[0] == null)
        {
            agentList = FindObjectsOfType<Agent>();
        }
        for (int i = 0; i < agentList.Length; i++)
        {
            agentList[i].shouldWalk = true;
        }
    }
}

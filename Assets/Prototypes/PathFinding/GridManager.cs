
using System.Collections.Generic;
using UnityEngine;

using PathFinding;
using System;

//[RequireComponent(typeof(GridLayout))]
public class GridManager : MonoBehaviour
{
    #region in scene fields

    [SerializeField]
    private GridItem prefabItem;

    [SerializeField]
    private int xItems;

    [SerializeField]
    private int yItems;

    [SerializeField]
    private Point from;

    [SerializeField]
    private Point to;

    #endregion

    private Dictionary<Point, GridItem> items = new Dictionary<Point, GridItem>();
    private PathFinding.Grid grid;
    private PathFinder pathFinder = new PathFinder();

    void Start()
    {
        grid = new PathFinding.Grid(yItems, xItems);

        for (int j = 0; j < yItems; j++)
        {
            for (int i = 0; i < xItems; i++)
            {
                var point = new Point(i, j);
                var tile = grid[point];
                var item = Instantiate(prefabItem, transform);
                item.Init(this, tile);
                items[point] = item;
            }
        }

        prefabItem.gameObject.SetActive(false);
    }

    [ContextMenu("Render")]
    public void Render()
    {
        // Reset color
        foreach (var entry in items)
        {
            entry.Value.SetColor(GridItem.Selected.Nothing);
        }

        foreach (var node in grid.FindPath(pathFinder, from, to))
        {
            GridItem item = null;

            if (!this.items.TryGetValue(node.point, out item))
            {
                throw new Exception("WTF!");
            }

            Debug.Log(node);

            item.SetColor(GridItem.Selected.Path);
        }
    }
}

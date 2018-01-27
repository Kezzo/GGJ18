using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathFinding;

[RequireComponent(typeof(Button))]
public class GridItem : MonoBehaviour 
{
    public enum Type { Start, Target }
    public enum Selected { Start, Target, Path, Nothing }

    #region in scene fields

    [SerializeField]
    private Type type;

    #endregion

    private Button button;
    private GridManager gridManager;
    private Tile tile;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnSelect);
    }

    public void Init(GridManager gridManager, Tile tile)
    {
        this.gridManager = gridManager;
        this.tile = tile;
    }

    private void OnSelect()
    {
        tile.Passable = !tile.Passable;

        this.gridManager.Render();
    }

    public void SetColor(Selected selected)
    {
        switch (selected)
        {
            case Selected.Start:
                button.image.color = Color.green;
                break;

            case Selected.Target:
                button.image.color = Color.blue;
                break;

            case Selected.Path:
                button.image.color = new Color(.5f, .5f, .5f);
                break;

            case Selected.Nothing:
                button.image.color = Color.white;
                break;
        }
    }
}

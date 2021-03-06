using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileBehaviour : MonoBehaviour
{
    public Vector2Int coords;

    //Parameters for the pathfinding algorithm
    public float gCost;
    public float hCost;
    public float fCost;
    public bool isWalkable;
    public TileBehaviour cameFromNode;

    private SpriteRenderer tileSprite;

    // Start is called before the first frame update
    void Start()
    {
        isWalkable = true;
        tileSprite = GetComponentInChildren<SpriteRenderer>();
        tileSprite.enabled = false;
    }

    public void SetCoords(int x, int y)
    {
        coords = new Vector2Int(x, y);
    }

    public void SetScale(Vector3 newScale)
    {
        transform.localScale = newScale;
    }

    public void SetSprite(bool isActive, Sprite sprite)
    {
        tileSprite.enabled = isActive;
        tileSprite.sprite = sprite;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    private void OnMouseEnter()
    {
        if (!GameManager.Instance.Player.IsMoving)
        {
            GridManager.Instance.HighlightPath(false, 0);
            GridManager.Instance.highlightedPath = GridManager.Instance.FindPath(GameManager.Instance.Player.playerPosition, coords);
            GridManager.Instance.HighlightPath(true, GridManager.Instance.highlightedPath.Count <= GameManager.Instance.Player.maxMoveDistance ? 0 : 1);
        }
    }

    private void OnMouseDown()
    {
        //List<TileBehaviour> path = manager.FindPath(manager.PlayerPosition, Coords);
        //foreach(TileBehaviour tile in path)
        //{
        //  tile.Test(true);
        //}
        if (!EventSystem.current.IsPointerOverGameObject())
            GameManager.Instance.PlayerMove(coords);
    }

    private void OnTriggerEnter(Collider other)
    {
        isWalkable = false;

    }

    private void OnTriggerExit(Collider other)
    {
        isWalkable = true;
    }
}

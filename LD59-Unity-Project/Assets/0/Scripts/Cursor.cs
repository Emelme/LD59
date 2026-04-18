using UnityEngine;

public class Cursor : MonoBehaviour, IRoadHolder, ISignalHolder
{
    public bool isSelectCursor = true;

    public GridSystem targetGrid;

    public RoadTile roadTile;
    public Signal signal;

    public Transform roadTileHoldTransform;
    public Transform signalHoldTransform;

    private void Update()
    {
        transform.position = GameInput.Instance.GetMousePositionInWorld();

        if (!isSelectCursor)
        {
            UpdateGhostGrid();
        }
    }

    private void UpdateGhostGrid()
    {
        G.i.ghostGrid.ClearAllTiles();

        G.i.ghostGrid.GetXY(transform.position, out int x, out int y);

        GhostTile ghostTile = G.i.ghostGrid.GetTile(x, y) as GhostTile;

        if (ghostTile == null)
            return;

        if (roadTile != null && signal == null)
        {
            ghostTile.ChangeSprite(
                roadTile.GetSprite(),
                roadTile.GetSpriteRotation()
            );
        }
        else if (signal != null && roadTile == null)
        {
            ghostTile.ChangeSprite(
                signal.GetSprite(),
                signal.GetSpriteRotation()
            );
        }
    }

    public void SetItem(IItem item)
    {
        ClearRoad();
        ClearSignal();

        if (item is RoadTile road)
        {
            SetRoad(road);
        }
        else if (item is Signal signal)
        {
            SetSignal(signal);
        }
    }

    public RoadTile GetRoad()
    {
        return roadTile;
    }

    public void SetRoad(RoadTile roadTile)
    {
        this.roadTile = roadTile;
    }

    public void ClearRoad()
    {
        roadTile = null;
    }

    public bool HasRoad()
    {
        return roadTile != null;
    }

    public Transform GetRoadHoldTransform()
    {
        return roadTileHoldTransform;
    }

    public Signal GetSignal()
    {
        return signal;
    }

    public void SetSignal(Signal signal)
    {
        this.signal = signal;
    }

    public void ClearSignal()
    {
        signal = null;
    }

    public bool HasSignal()
    {
        return signal != null;
    }

    public Transform GetSignalHoldTransform()
    {
        return signalHoldTransform;
    }
}
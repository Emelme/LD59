using UnityEngine;

public class Cursor : MonoBehaviour, IRoadHolder, ISignalHolder
{
    public bool isSelectCursor = true;

    public RoadTileHolder targetGrid;

    public RoadTile roadTile;
    public Signal signal;

    public Transform roadTileHoldTransform;
    public Transform signalHoldTransform;

    private void Awake()
    {
        GameInput.Instance.OnLeftMouseButtonPerformed += HandleLeftClick;
        GameInput.Instance.OnRightMouseButtonPerformed += HandleRightClick;
    }

    private void OnDestroy()
    {
        if (GameInput.Instance != null)
        {
            GameInput.Instance.OnLeftMouseButtonPerformed -= HandleLeftClick;
            GameInput.Instance.OnRightMouseButtonPerformed -= HandleRightClick;
        }
    }

    private void Update()
    {
        transform.position = GameInput.Instance.GetMousePositionInWorld();

        UpdateTargetGrid();

        if (!isSelectCursor)
        {
            UpdateGhostGrid();
        }
    }

    private void HandleRightClick(Vector2 mouseWorldPosition)
    {
        if (targetGrid == null) return;
        if (!targetGrid.HasRoad()) return;

        RoadTile road = targetGrid.GetRoad();
        if (road.HasCar()) return;

        BasicCar.CreateCar(G.i.basicCarPrefab, road);
    }

    private void HandleLeftClick(Vector2 mouseWorldPosition)
    {
        if (isSelectCursor)
            return;

        if (targetGrid == null)
            return;

        if (roadTile != null)
        {
            if (targetGrid.HasRoad())
            {
                Destroy(targetGrid.GetRoad().gameObject);
                targetGrid.ClearRoad();
            }

            RoadTile.CreateRoadTile(roadTile, targetGrid);
        }

        if (signal != null)
        {
            if (targetGrid.HasRoad())
            {
                if (targetGrid.GetRoad().HasSignal())
                {
                    Destroy(targetGrid.GetRoad().GetSignal().gameObject);
                    targetGrid.GetRoad().ClearSignal();
                }
            }

            Signal.CreateSignal(signal, targetGrid.GetRoad());
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

    public void UpdateTargetGrid()
    {
        G.i.firstRoadGrid.GetXY(transform.position, out int x, out int y);
        targetGrid = (RoadTileHolder)G.i.firstRoadGrid.GetTile(x, y);
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
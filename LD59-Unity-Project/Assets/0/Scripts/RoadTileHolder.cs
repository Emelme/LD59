using UnityEngine;

public class RoadTileHolder : GridTile, IRoadHolder
{
	
	
	
	
	public RoadTile roadTile;
	public Transform roadTileHoldTransform;
	
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
}
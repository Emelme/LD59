using UnityEngine;

public interface IRoadHolder 
{
	public RoadTile GetRoad();

	public void SetRoad(RoadTile roadTile);

	public void ClearRoad();

	public bool HasRoad();

	public Transform GetRoadHoldTransform();
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class G : MonoBehaviour
{
	[Header("Prefabs")]
	
	public List<RoadTile> roadTilePrefabs;
	
	
	[Header("Managers")]
	public GridSystem firstRoadGrid;
	public GridSystem ghostGrid;


	public static G i { get; private set; }

	private void Awake()
	{
		i = this;
		
		firstRoadGrid.InitializeBoard(128, 128, 1, new Vector2(-64f, -64f));
		ghostGrid.InitializeBoard(128, 128, 1, new Vector2(-64f, -64f));
	}

	public void Start()
	{
		
	}

	public enum RoadTileType
	{
		I_Vertical,
		I_Horizontal,
		L_Down_Left,
		L_Down_Right,
		L_Up_Left,
		L_Up_Right,
		T_Down_Left,
		T_Down_Right,
		T_Up_Left,
		T_Up_Right,
		X
	}
	
	public RoadTile getRoadTile(RoadTileType type)
	{
		return roadTilePrefabs[(int)type];
	}
}

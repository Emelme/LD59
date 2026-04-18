using System;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
	[SerializeField] private GridTile tilePrefab;

	private int width;
	private int height;
	private float tileSize;
	private Vector2 originPosition;

	private GridTile[,] tileArray;

	public void InitializeBoard(
		int width,
		int height,
		float tileSize,
		Vector2 originPosition)
	{
		this.width = width;
		this.height = height;
		this.tileSize = tileSize;
		this.originPosition = originPosition;

		tileArray = new GridTile[width, height];

		for (int x = 0; x < tileArray.GetLength(0); x++)
		{
			for (int y = 0; y < tileArray.GetLength(1); y++)
			{
				GridTile tile = Instantiate(
					tilePrefab,
					GetWorldPosition(x, y),
					Quaternion.identity,
					transform);

				tileArray[x, y] = tile;
			}
		}
	}

	#region Get / Set

	public GridTile[,] GetTileArray() => tileArray;

	public Vector2 GetWorldPosition(int x, int y)
	{
		Vector2 worldPosition = new Vector2(x, y) * tileSize + originPosition;

		float halfTileSize = tileSize / 2f;
		worldPosition.x += halfTileSize;
		worldPosition.y += halfTileSize;

		return worldPosition;
	}

	public void GetXY(Vector2 worldPosition, out int x, out int y)
	{
		x = Mathf.FloorToInt((worldPosition.x - originPosition.x) / tileSize);
		y = Mathf.FloorToInt((worldPosition.y - originPosition.y) / tileSize);
	}

	public GridTile GetTile(int x, int y)
	{
		if (!IsXYValid(x, y))
			return null;

		return tileArray[x, y];
	}

	public GridTile GetTile(Vector2 worldPosition)
	{
		GetXY(worldPosition, out int x, out int y);
		return GetTile(x, y);
	}

	public void SetTile(int x, int y, GridTile tile)
	{
		if (!IsXYValid(x, y))
			return;

		tileArray[x, y] = tile;
	}

	public void SetTile(Vector2 worldPosition, GridTile tile)
	{
		GetXY(worldPosition, out int x, out int y);
		SetTile(x, y, tile);
	}

	public void GetWidthAndHeight(out int width, out int height)
	{
		width = this.width;
		height = this.height;
	}

	#endregion

	public void ClearAllTiles()
	{
		foreach (GridTile tile in tileArray)
		{
			GhostTile ghostTile = tile as GhostTile;

			if (ghostTile != null)
			{
				ghostTile.ChangeSprite(null, Vector3.zero);
			}
		}
	}

	public bool IsWorldPositionValid(Vector2 worldPosition)
	{
		GetXY(worldPosition, out int x, out int y);
		return IsXYValid(x, y);
	}

	public bool IsXYValid(int x, int y)
	{
		return x >= 0 &&
			   y >= 0 &&
			   x < width &&
			   y < height;
	}
}
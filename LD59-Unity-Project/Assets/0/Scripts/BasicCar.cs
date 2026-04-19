using System.Collections;
using UnityEngine;

public class BasicCar : Car
{
	public float speed = 5f;
	public int money = 100;
	
	public ICarHolder carHolder;

	private void Start()
	{
		StartCoroutine(MoveRoutine());
	}

	private IEnumerator MoveRoutine()
	{
		while (true)
		{
			UpdateTick();
			yield return new WaitForSeconds(1f);
		}
	}

	public void UpdateTick()
	{
		if (!(carHolder is RoadTile currentRoad)) return;
		if (!(currentRoad.roadHolder is RoadTileHolder currentHolder)) return;

		bool canMove = direction switch
		{
			Direction.Up    => currentRoad.canMoveUp,
			Direction.Down  => currentRoad.canMoveDown,
			Direction.Left  => currentRoad.canMoveLeft,
			Direction.Right => currentRoad.canMoveRight,
			_               => false
		};

		if (!canMove) return;

		GridSystem grid = G.i.firstRoadGrid;
		grid.GetXY(currentHolder.transform.position, out int x, out int y);

		int nx = x + (direction == Direction.Right ? 1 : direction == Direction.Left ? -1 : 0);
		int ny = y + (direction == Direction.Up    ? 1 : direction == Direction.Down ? -1 : 0);

		GridTile nextTile = grid.GetTile(nx, ny);
		if (!(nextTile is RoadTileHolder nextHolder)) return;
		if (!nextHolder.HasRoad()) return;

		RoadTile nextRoad = nextHolder.GetRoad();
		if (nextRoad.HasCar()) return;

		currentRoad.ClearCar();
		SetCarHolder(nextRoad);
	}

	public static Car CreateCar(Car carPrefab, ICarHolder carHolder)
	{
		Car car = Instantiate(carPrefab);

		car.SetCarHolder(carHolder);
		car.SetDirection(Direction.Up);

		return car;
	}
	
	public override void SetCarHolder(ICarHolder carHolder)
	{
		this.carHolder = carHolder;
		carHolder.SetCar(this);
		transform.parent = carHolder.GetCarHoldTransform();

		transform.localPosition = Vector2.zero;
	}
}

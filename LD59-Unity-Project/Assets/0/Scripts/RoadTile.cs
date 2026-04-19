using UnityEngine;

public class RoadTile : MonoBehaviour, ISignalHolder, IItem, ICarHolder
{
	public bool canMoveRight;
	public bool canMoveLeft;
	public bool canMoveDown;
	public bool canMoveUp;
	
	public Signal signal;
	public Transform signalHoldTransform;
	public Car car;
	public Transform carHoldTransform;
	
	public IRoadHolder roadHolder;
	
	public GameObject spriteGameObject;
	public SpriteRenderer spriteSpriteRenderer;

	private void Start()
	{
		signalHoldTransform = transform;
		carHoldTransform = transform;
	}

	public static RoadTile CreateRoadTile(RoadTile roadTilePrefab, IRoadHolder roadHolder)
	{
		RoadTile roadTile = Instantiate(roadTilePrefab);
		
		roadTile.SetRoadTileHolder(roadHolder);
		
		return roadTile;
	}
	
	public void SetRoadTileHolder(IRoadHolder roadHolder)
	{
		this.roadHolder = roadHolder;
		roadHolder.SetRoad(this);
		transform.parent = roadHolder.GetRoadHoldTransform();

		transform.localPosition = Vector2.zero;
	}
	
	public Vector3 GetSpriteRotation()
	{
		return spriteGameObject.transform.localEulerAngles;
	}

	public Sprite GetSprite()
	{
		return spriteSpriteRenderer.sprite;
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

	public Car GetCar()
	{
		return car;
	}

	public void SetCar(Car car)
	{
		this.car = car;
	}

	public void ClearCar()
	{
		car = null;
	}

	public bool HasCar()
	{
		return car != null;
	}

	public Transform GetCarHoldTransform()
	{
		return carHoldTransform;
	}
}
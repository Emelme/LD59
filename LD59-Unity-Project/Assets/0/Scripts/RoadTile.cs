using UnityEngine;

public class RoadTile : MonoBehaviour, ISignalHolder, IItem
{
	public bool canMoveRight;
	public bool canMoveLeft;
	public bool canMoveDown;
	public bool canMoveUp;
	
	public Signal signal;
	public Transform signalHoldTransform;
	
	public GameObject spriteGameObject;
	public SpriteRenderer spriteSpriteRenderer;

	private void Start()
	{
		signalHoldTransform = transform;
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
}
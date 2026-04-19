using UnityEngine;

public class Signal : MonoBehaviour, IItem
{
	public SignalType signalType;
	
	public enum SignalType
	{
		arrowBlueUp,
		arrowBlueDown,
		arrowBlueLeft,
		arrowBlueRight,
		arrowRedUp,
		arrowRedDown,
		arrowRedLeft,
		arrowRedRight,
		arrowGreenUp,
		arrowGreenDown,
		arrowGreenLeft,
		arrowGreenRight,
		arrowYellowUp,
		arrowYellowDown,
		arrowYellowLeft,
		arrowYellowRight,
	}
	
	public static Signal CreateSignal(Signal signalPrefab, ISignalHolder siganlHolder)
	{
		Signal signal = Instantiate(signalPrefab);
		
		signal.SetSignalHolder(siganlHolder);
		
		return signal;
	}
	
	public ISignalHolder signalHolder;
	
	public void SetSignalHolder(ISignalHolder signalHolder)
	{
		this.signalHolder = signalHolder;
		signalHolder.SetSignal(this);
		transform.parent = signalHolder.GetSignalHoldTransform();

		transform.localPosition = Vector2.zero;
	}
	
	public GameObject spriteGameObject;
	public SpriteRenderer spriteSpriteRenderer;

	public Vector3 GetSpriteRotation()
	{
		return spriteGameObject.transform.localEulerAngles;
	}

	public Sprite GetSprite()
	{
		return spriteSpriteRenderer.sprite;
	}
}
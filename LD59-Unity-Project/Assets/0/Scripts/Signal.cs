using UnityEngine;

public class Signal : MonoBehaviour, IItem
{
	
	
	
	
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
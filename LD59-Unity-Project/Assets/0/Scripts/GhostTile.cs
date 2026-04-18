using UnityEngine;

public class GhostTile : GridTile
{
	public Sprite sprite;
	public SpriteRenderer spriteRenderer;

	public void ChangeSprite(Sprite newSprite, Vector3 rotation)
	{
		spriteRenderer.sprite = newSprite;
		spriteRenderer.transform.rotation = Quaternion.Euler(rotation);
	}
}
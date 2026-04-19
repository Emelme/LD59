using UnityEngine;

public class Car : MonoBehaviour
{
	public virtual void SetCarHolder(ICarHolder carHolder)
	{
		
	}
	
	public enum Direction
	{
		Up,
		Down,
		Left,
		Right
	}
	
	public Direction direction = Direction.Up;
	
	public void SetDirection(Direction newDirection)
	{
		direction = newDirection;

		switch (direction)
		{
			case Direction.Up:
				transform.rotation = Quaternion.Euler(0, 0, 0);
				break;

			case Direction.Down:
				transform.rotation = Quaternion.Euler(0, 0, 180);
				break;

			case Direction.Left:
				transform.rotation = Quaternion.Euler(0, 0, 90);
				break;

			case Direction.Right:
				transform.rotation = Quaternion.Euler(0, 0, -90);
				break;
		}
	}
}

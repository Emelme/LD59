using UnityEngine;

public interface ICarHolder
{
	public Car GetCar();

	public void SetCar(Car car);

	public void ClearCar();

	public bool HasCar();

	public Transform GetCarHoldTransform();
}
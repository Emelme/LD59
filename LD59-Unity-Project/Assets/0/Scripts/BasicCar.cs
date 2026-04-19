using UnityEngine;

public class BasicCar : Car
{
	public static Car CreateCar(Car carPrefab, ICarHolder carHolder)
	{
		Car car = Instantiate(carPrefab);

		car.SetCarHolder(carHolder);

		return car;
	}

	public ICarHolder carHolder;

	public override void SetCarHolder(ICarHolder carHolder)
	{
		this.carHolder = carHolder;
		carHolder.SetCar(this);
		transform.parent = carHolder.GetCarHoldTransform();

		transform.localPosition = Vector2.zero;
	}
}

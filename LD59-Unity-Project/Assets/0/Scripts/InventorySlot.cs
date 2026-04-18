using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	public Toggle toggle;
	
	public Image boxImage;
	public Sprite checkedImage;
	public Sprite uncheckedImage;
	
	public Image itemImage;

	public List<RoadTile> roads = new List<RoadTile>();
	public List<Signal> signals = new List<Signal>();

	private int index;

	private void Update()
	{
		if  (toggle.isOn)
		{
			boxImage.sprite = checkedImage;
		}
		else
		{
			boxImage.sprite = uncheckedImage;
		}
	}

	public void NextItem()
	{
		int total = roads.Count + signals.Count;
		if (total == 0) return;

		index = (index + 1) % total;

		if (roads.Count > 0)
		{
			itemImage.sprite = roads[index].GetSprite();
			itemImage.gameObject.transform.rotation = Quaternion.Euler(roads[index].GetSpriteRotation());
		}
		else if (signals.Count > 0)
		{
			itemImage.sprite = signals[index].GetSprite();
			itemImage.gameObject.transform.rotation = Quaternion.Euler(signals[index].GetSpriteRotation());
		}
		
		Debug.Log(index);
	}

	public void PreviousItem()
	{
		int total = roads.Count + signals.Count;
		if (total == 0) return;

		index--;

		if (index < 0)
			index = total - 1;
		
		
		if (roads.Count > 0)
		{
			itemImage.sprite = roads[index].GetSprite();
			itemImage.gameObject.transform.rotation = Quaternion.Euler(roads[index].GetSpriteRotation());
		}
		else if (signals.Count > 0)
		{
			itemImage.sprite = signals[index].GetSprite();
			itemImage.gameObject.transform.rotation = Quaternion.Euler(signals[index].GetSpriteRotation());
		}
	}

	public bool TryGetCurrentItem(out RoadTile road)
	{
		if (index < roads.Count)
		{
			road = roads[index];
			return true;
		}

		road = null;
		return false;
	}

	public bool TryGetCurrentItem(out Signal signal)
	{
		int signalIndex = index - roads.Count;

		if (signalIndex >= 0 && signalIndex < signals.Count)
		{
			signal = signals[signalIndex];
			return true;
		}

		signal = null;
		return false;
	}
}

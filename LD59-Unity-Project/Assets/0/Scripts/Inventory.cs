using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField] private List<InventorySlot> slots;
	[SerializeField] private Cursor cursor;

	private InventorySlot currentSlot;
	private int currentIndex;

	private void Start()
	{
		for (int i = 0; i < slots.Count; i++)
		{
			int index = i;

			slots[i].toggle.onValueChanged.AddListener((isOn) =>
			{
				if (!isOn) return;

				SelectSlot(index);
			});
		}

		if (slots.Count > 0)
		{
			SelectSlot(0);
		}

		foreach (InventorySlot slot in slots)
		{
			slot.NextItem();
			slot.PreviousItem();
		}
	}

	private void OnEnable()
	{
		GameInput.Instance.OnScrollPerformed += HandleScroll;
	}

	private void OnDisable()
	{
		if (GameInput.Instance != null)
		{
			GameInput.Instance.OnScrollPerformed -= HandleScroll;
		}
	}

	private void HandleScroll(float scroll)
	{
		Debug.Log(scroll);
		if (currentSlot == null || slots.Count == 0)
			return;

		if (scroll > 0)
		{
			currentSlot.NextItem();
		}
		else if (scroll < 0)
		{
			currentSlot.PreviousItem();
		}

		ApplyCurrentItem();
	}

	private void SelectSlot(int index)
	{
		if (index < 0 || index >= slots.Count)
			return;

		currentIndex = index;
		currentSlot = slots[index];

		currentSlot.toggle.isOn = true;

		ApplyCurrentItem();
	}

	private void ApplyCurrentItem()
	{
		if (currentSlot == null)
			return;

		if (currentSlot.TryGetCurrentItem(out RoadTile road))
		{
			cursor.SetRoad(road);
			cursor.ClearSignal();
		}
		else if (currentSlot.TryGetCurrentItem(out Signal signal))
		{
			cursor.SetSignal(signal);
			cursor.ClearRoad();
		}
	}
}

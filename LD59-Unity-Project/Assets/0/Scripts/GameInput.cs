using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
	[SerializeField] private Camera mainCamera;

	public static GameInput Instance { get; private set; }

	private PlayerInputActions playerInputActions;

	public event Action<Vector2> OnLeftMouseButtonPerformed;
	public event Action<Vector2> OnLeftMouseButtonCanceled;
	public event Action<Vector2> OnRightMouseButtonPerformed;
	public event Action<Vector2> OnRightMouseButtonCanceled;
	public event Action<float> OnScrollPerformed;

	private void Awake()
	{
		#region Singleton
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogError("There are two GameInput Instances!");
		}
		#endregion Singleton

		playerInputActions = new PlayerInputActions();
		playerInputActions.Enable();

		playerInputActions.Player.LeftMouseButton.performed += LeftMouseButton_performed;
		playerInputActions.Player.LeftMouseButton.canceled += LeftMouseButton_canceled;
		playerInputActions.Player.RightMouseButton.performed += RightMouseButton_performed;
		playerInputActions.Player.RightMouseButton.canceled += RightMouseButton_canceled;
		playerInputActions.Player.Scroll.performed += Scroll_performed;
	}

	private void LeftMouseButton_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		OnLeftMouseButtonPerformed?.Invoke(GetMousePositionInWorld());
	}

	private void LeftMouseButton_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		OnLeftMouseButtonCanceled?.Invoke(GetMousePositionInWorld());
	}

	private void RightMouseButton_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		OnRightMouseButtonPerformed?.Invoke(GetMousePositionInWorld());
	}

	private void RightMouseButton_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		OnRightMouseButtonCanceled?.Invoke(GetMousePositionInWorld());
	}
	
	public Vector2 GetMousePositionInWorld()
	{
		return mainCamera.ScreenToWorldPoint(playerInputActions.Player.MousePosition.ReadValue<Vector2>());
	}
	
	private void Scroll_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		float scrollY = obj.ReadValue<Vector2>().y;

		OnScrollPerformed?.Invoke(scrollY);
	}
}

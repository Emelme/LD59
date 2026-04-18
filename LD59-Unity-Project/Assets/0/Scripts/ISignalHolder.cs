using UnityEngine;

public interface ISignalHolder 
{
	public Signal GetSignal();

	public void SetSignal(Signal signal);

	public void ClearSignal();

	public bool HasSignal();

	public Transform GetSignalHoldTransform();
}

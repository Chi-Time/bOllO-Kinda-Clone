using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	[Tooltip("The target object for the camera to follow.")]
	[SerializeField] private Transform _Target;
	[Tooltip("If ticked, the camera will follow the tagged player object")]
	[SerializeField] private bool _UsePlayer = true;
	[Tooltip("The smoothing applied to the camera's movement.")]
	[SerializeField] private float _SmoothTime = 0.15f;

	private Transform _Transform = null;
	private Vector3 _Velocity = Vector3.zero;

	void Awake ()
	{
		GetReferences ();
	}

	void GetReferences ()
	{
		if (_UsePlayer)
			_Target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();

		_Transform = GetComponent<Transform> ();
	}

	void LateUpdate () 
	{
		if (_Target)
		{
			Vector3 point = Camera.main.WorldToViewportPoint (_Target.position);
			Vector3 delta = _Target.position - Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, point.z));
			Vector3 destination = _Transform.position + delta;
			_Transform.position = Vector3.SmoothDamp (_Transform.position, destination, ref _Velocity, _SmoothTime);
		}
	}
}

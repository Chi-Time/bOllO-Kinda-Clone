using UnityEngine;
using System.Collections;

public class SpeedPickup : MonoBehaviour
{
	private float _SpeedIncrease = 2f;

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.CompareTag ("Player"))
		{
			var p = other.GetComponent<PlayerController> ();
			p.Speed += _SpeedIncrease;

			Destroy (this.gameObject);
		}
	}
}

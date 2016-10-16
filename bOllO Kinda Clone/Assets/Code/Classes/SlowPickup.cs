using UnityEngine;
using System.Collections;

public class SlowPickup : MonoBehaviour
{
	private float _SpeedDecrease = 2f;

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.CompareTag ("Player"))
		{
			var p = other.GetComponent<PlayerController> ();
			p.Speed -= _SpeedDecrease;

			Destroy (this.gameObject);
		}
	}
}

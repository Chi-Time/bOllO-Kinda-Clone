using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour
{
	[SerializeField] private int _Stages = 3;
	[SerializeField] private float _Parts = 0.0f;

	void Start ()
	{
		_Parts = 1f / _Stages;
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.CompareTag ("Player"))
			ChangeScale ();
	}

	void ChangeScale ()
	{
		if (StagesLeft ())
			transform.localScale = new Vector3 (transform.localScale.x - _Parts, transform.localScale.y - _Parts, transform.localScale.z - _Parts);
		else
			Destroy (this.gameObject);
	}

	bool StagesLeft ()
	{
		if (_Stages > 0)
		{
			_Stages--;
			return true;
		}

		return false;
	}
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float _Speed = 5.0f;

	private Directions _CurrentDirection = Directions.Still;
	private Vector3 _Direction = Vector3.zero;
	private Rigidbody _Rigidbody = null;
	private bool _IsFirstClick = false;

	void Awake ()
	{
		GetReferences ();
	}

	void GetReferences ()
	{
		_Rigidbody = GetComponent<Rigidbody> ();
	}

	void Update ()
	{
		GroundCheck ();
		Move ();
	}

	void GroundCheck ()
	{
		if (IsGrounded ())
			GetInput ();
	}

	bool IsGrounded ()
	{
		if (Physics.Raycast (transform.position, Vector3.down, 0.5f))
			return true;

		return false;
	}

	void GetInput ()
	{
		if (Input.GetMouseButtonDown (0))
			ChangeDirection (GetDirection ());
	}

	Directions GetDirection ()
	{
		if (_IsFirstClick)
		{
			_IsFirstClick = !_IsFirstClick;
			return Directions.Left;
		}

		_IsFirstClick = !_IsFirstClick;
		return Directions.Forward;
	}

	void ChangeDirection (Directions direction)
	{
		_CurrentDirection = direction;

		switch (_CurrentDirection)
		{
		case Directions.Still:
			_Direction = Vector3.zero;
			break;
		case Directions.Forward:
			_Direction = Vector3.forward;
			break;
		case Directions.Back:
			_Direction = Vector3.back;
			break;
		case Directions.Left:
			_Direction = Vector3.left;
			break;
		case Directions.Right:
			_Direction = Vector3.right;
			break;
		}
	}

	void Move ()
	{
		transform.Translate (_Direction * _Speed * Time.deltaTime);
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.CompareTag ("Barrier"))
		{
			if(_CurrentDirection == Directions.Forward)
			{
				ChangeDirection (Directions.Back);
				return;
			}
			else if(_CurrentDirection == Directions.Back)
			{
				ChangeDirection (Directions.Forward);
				return;
			}
			else if(_CurrentDirection == Directions.Left)
			{
				ChangeDirection (Directions.Right);
				return;
			}
			else if(_CurrentDirection == Directions.Right)
			{
				ChangeDirection (Directions.Left);
				return;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour
{
	[SerializeField] private int _MinPlatforms = 5;
	[SerializeField] private int _MaxPlatforms = 11;
	[SerializeField] private GameObject _PlatformPrefab = null;
	[SerializeField] private GameObject _BarrierPrefab = null;
	[SerializeField] private GameObject _HSpawnTrigger = null;
	[SerializeField] private GameObject _VSpawnTrigger = null;

	void Awake ()
	{
		InitialPlatforms ();
	}

	void InitialPlatforms ()
	{
		int platformAmount = Random.Range (_MinPlatforms, _MaxPlatforms);

		for (int i = 0; i <= platformAmount; i++)
		{
			if(i == 0)
			{
				SpawnObject (_PlatformPrefab, Vector3.zero);
				SpawnObject (_BarrierPrefab, new Vector3 (0, .25f, 0f));
			}

			SpawnObject (_PlatformPrefab, new Vector3 (-i, 0f, 0f));

			if(i == platformAmount)
			{
				SpawnObject (_BarrierPrefab, new Vector3 (-i, .25f, 0f));
			}
		}
	}

	void SpawnPlatforms ()
	{
		
	}

	GameObject SpawnObject (GameObject go, Vector3 position)
	{
		return (GameObject)Instantiate (go, position, Quaternion.identity);
	}
}

//public class PlatformGenerator : MonoBehaviour
//{
//	[SerializeField] private GameObject _PlatformPrefab = null;
//	[SerializeField] private GameObject _BarrierPrefab = null;
//
//	private int _PreviousPlatforms = 0;
//	private int _CurrentX = 0;
//	private int _CurrentZ = 0;
//
//	void Awake ()
//	{
//		SpawnInitialHorizontalPlatforms ();
//	}
//
//	void SpawnInitialHorizontalPlatforms ()
//	{
//		int platformAmount = Random.Range (5, 10);
//
//		for(int i = 0; i <= platformAmount; i++)
//		{
//			if(i == 0)
//			{
//				SpawnObject (_PlatformPrefab, Vector3.zero);
//				SpawnObject (_BarrierPrefab, new Vector3(0, .25f, 0));
//			}
//
//			SpawnObject (_PlatformPrefab, new Vector3 (-i, 0f, 0f));
//
//			if (i == platformAmount)
//				SpawnObject (_BarrierPrefab, new Vector3 (-i, .25f, 0f));
//		}
//
//		_PreviousPlatforms = platformAmount;
//
//		Invoke ("SpawnInitialVerticalPlatforms", 2f);
//	}
//
//	void SpawnInitialVerticalPlatforms ()
//	{
//		int platformAmount = Random.Range (5, 10);
//		int axis = Random.Range (5, _PreviousPlatforms);
//
//		for(int i = 1; i <= platformAmount; i++)
//		{
//			if(i == 1)
//			{
//				SpawnObject (_PlatformPrefab, Vector3.zero);
//				SpawnObject (_BarrierPrefab, new Vector3(-axis, .25f, i));
//			}
//
//			SpawnObject (_PlatformPrefab, new Vector3 (-axis, 0f, i));
//
//			if (i == platformAmount)
//				SpawnObject (_BarrierPrefab, new Vector3 (-axis, .25f, i));
//		}
//
//		_PreviousPlatforms = platformAmount;
//	}
//
//	void SpawnPlatforms ()
//	{
//
//	}
//
//	GameObject SpawnObject (GameObject go, Vector3 position)
//	{
//		return (GameObject)Instantiate (go, position, Quaternion.identity);
//	}
//}

using System;
using UnityEngine;

[Serializable]
public class Unlockable
{
	public string name;
	public GameObject gameObject;
	public int minMuffins;

	public void Unlock()
	{
		Debug.Log($"Unlocked {name}");
		gameObject.SetActive(true);
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}
}
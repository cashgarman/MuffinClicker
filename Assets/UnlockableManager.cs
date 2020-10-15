using UnityEngine;

public class UnlockableManager : MonoBehaviour
{
	public Unlockable[] unlockables;

	private void Start()
	{
		// Hide all the unlockable objects
		foreach (var unlockable in unlockables)
		{
			unlockable.Hide();
		}
	}

	public void OnNewNumMuffins(int numMuffins)
	{
		// Unlock any unlockables that we have enough muffins for
		foreach (var unlockable in unlockables)
		{
			if (unlockable.minMuffins <= numMuffins)
			{
				unlockable.Show();
			}
		}
	}
}
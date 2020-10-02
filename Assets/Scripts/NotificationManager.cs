using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class NotificationManager : MonoBehaviour
{
	// The singleton instance
	private static NotificationManager instance;
	
	public GameObject notificationPrefab;
	public float notificationFloatHeight;
	public float notificationFloatDuration;
	public float notificationFadeDuration;
	public float notificationDriftAmount;

	private void Awake()
	{
		if (instance != null)
		{
			throw new Exception("A new NotificationManager singleton was being created when one already exists");
		}
		
		// Assign the singleton
		instance = this;
	}

	public static void Notify(string message)
	{
		// Create the notification
		var notification =
			Instantiate(instance.notificationPrefab, instance.transform.position,
				Quaternion.LookRotation(Camera.main.transform.forward), instance.transform).GetComponent<TMP_Text>();
		notification.text = message;
        
		// Float the notification upwards before removing it
		notification.transform.DOPunchScale(Vector3.one * 1.2f, 0.2f);
		notification.transform.DOMove(
				(instance.transform.up +
				 new Vector3(Random.Range(-instance.notificationDriftAmount, instance.notificationDriftAmount), 0f, 0f)
				) * instance.notificationFloatHeight, instance.notificationFloatDuration).OnComplete(
				() =>
				{
					notification.GetComponent<CanvasGroup>().DOFade(0f, instance.notificationFadeDuration).OnComplete(
						() =>
						{
							Destroy(notification.gameObject);
						});
				});
	}
	}
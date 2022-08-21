using UnityEngine;
using SB;
using DG.Tweening;

public class CoffeeMachine : MonoBehaviour 
{
	private AudioSource beepSound;
	private AudioSource machineSound;
	private GameObject _player;
	private float coefficient = 1.15f;
	private float secondsBetweenBeep = 1;

	private void Awake()
	{
		machineSound = GetComponent<AudioSource>();
		beepSound = GetComponentInChildren<AudioSource>();
		_player = FindObjectOfType<PlayerMovementController>().gameObject;
	}

	private void Update()
	{
		if(machineSound.isPlaying) 
		{
			machineSound.volume = GetVolumeValueByDistance();
		}	
	}

	private void OnTriggerStay(Collider other)
	{
		if(InputManager.InteractButton && other.CompareTag("Player"))
		{
			if(!machineSound.isPlaying)
			{
				machineSound.Play();
				PlayBeepSequence(2,3,1);
			}
		}
	}

	private float GetVolumeValueByDistance() 
	{
		var distance = Vector3.Distance(_player.transform.position,transform.position);
		return 1/distance * coefficient;
	}

	private void PlayBeepSequence(float a,float b, float c) 
	{
		Sequence beepSequence = DOTween.Sequence();

		for(int j=0; j<a; j++) 
		{
			beepSequence.AppendCallback(PlayBeepSound);
			beepSequence.AppendInterval(secondsBetweenBeep);
		}
		
		beepSequence.AppendInterval(secondsBetweenBeep);

		for(int j=0; j<b; j++) 
		{
			beepSequence.AppendCallback(PlayBeepSound);
			beepSequence.AppendInterval(secondsBetweenBeep);
		}

		beepSequence.AppendInterval(secondsBetweenBeep);

		for(int j=0; j<c; j++) 
		{
			beepSequence.AppendCallback(PlayBeepSound);
			beepSequence.AppendInterval(secondsBetweenBeep);
		}
		
		beepSequence.PlayForward();
	}

	private void PlayBeepSound() => beepSound.Play();
}

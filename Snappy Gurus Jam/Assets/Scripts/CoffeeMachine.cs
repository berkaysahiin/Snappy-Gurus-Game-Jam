using UnityEngine;
using SB;

public class CoffeeMachine : MonoBehaviour 
{
	private float coefficient => 1.15f;
	private AudioSource machineSound;
	private GameObject _player;


	private void Awake()
	{
		machineSound = GetComponent<AudioSource>();	
		_player = FindObjectOfType<PlayerCharacterController>().gameObject;
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
			}
		}
	}

	private float GetVolumeValueByDistance() 
	{
		var distance = Vector3.Distance(_player.transform.position,transform.position);
		return 1/distance * coefficient;
	}
}

using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{
	[SerializeField] private GameObject door;
	private bool isDoorOpen;


	private void OnTriggerStay(Collider other)
	{
		var pickable = other.GetComponent<Pickable>(); 
		if(pickable == null) return;
		OpenDoorIfItemTypeMatches(ItemType.GoldenFish,pickable);
		pickable.enabled = false;
	}	

	private void OpenDoorIfItemTypeMatches(ItemType itemType,Pickable pickable) 
	{
		if(!isDoorOpen && itemType == pickable.ItemType ) isDoorOpen = true;
		door.SetActive(false);
	}
	
}

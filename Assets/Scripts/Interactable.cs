using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

	bool playerInside;
	GameManager gm;

	protected virtual void Start()
	{
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	protected virtual void Update()
	{
		if(playerInside && gm.interactKeyDown) {
			Interact();
		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player" ) {
			playerInside = true;
		}
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			playerInside = false;
		}
	}

	public abstract void Interact();

}

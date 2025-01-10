using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace m
{

	public class CollectCoin : MonoBehaviour
	{

		void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				
				GameManager.instance.FncCollectCoins();
				this.gameObject.SetActive(false);
			}
		}
	}
}

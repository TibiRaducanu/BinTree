﻿using UnityEngine;
using System.Collections;

namespace UnitedTAD {

	public class Inventory_Button : MonoBehaviour {

		public void OpenCloseInventory(){
			// Open or close the inventory.
			Grid.inventory.OpenCloseInventory();
		}
	}
}

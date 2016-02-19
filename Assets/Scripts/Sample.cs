using UnityEngine;
using System.Collections;

public class Sample : MonoBehaviour {

	void OnGUI() {
		if (GUI.Button(new Rect(50f, 50f, 200f, 150f), "Available Storage")) {
			Debug.Log("CHECK DEVICE STORAGE");
			Debug.Log(" |__ AVAILABLE STORAGE : " + StorageUtil.GetAvailableStorageMB() + " MB");
			Debug.Log(" |__ TOTAL STORAGE : " + StorageUtil.GetTotalStorageMB() + " MB");
		}
	}
}

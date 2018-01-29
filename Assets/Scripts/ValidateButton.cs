using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ValidateButton : MonoBehaviour {

	Button butn;

	void Start () {
		butn = this.gameObject.GetComponent<Button>();
	}
	

	void Update () {
	if (QuestionHandler.currentAnswer == 0)
			butn.interactable = false;
		else
			butn.interactable = true;
	}
}

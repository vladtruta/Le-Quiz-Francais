using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionNumber : MonoBehaviour {

	int questioncount=1;
	Text text;

	void Start()
	{
		text = this.transform.Find("Text").gameObject.GetComponent<Text>();
		ChangeNumber ();
	}
	public void Increment()
	{
		questioncount++;
		if (questioncount == 4)
			questioncount = 1;
		ChangeNumber ();
	}
	public void ChangeNumber()
	{
		switch (questioncount) {
		case 1:
			QuestionHandler.questionNumber=5;
			break;
		case 2:
			QuestionHandler.questionNumber=10;
			break;
		case 3:
			QuestionHandler.questionNumber=15;
			break;
		}
		text.text="B. Nombre de questions: "+QuestionHandler.questionNumber.ToString();

	}

}

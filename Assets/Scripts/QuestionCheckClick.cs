using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class QuestionCheckClick : MonoBehaviour {

	GameObject questionChecker;
	Text question;
	Text[] answers=new Text[5];
	QuestionHandler handler;
	int i;
	public GameObject button;

	void Start()
	{
		questionChecker = this.transform.parent.Find ("QuestionChecker").gameObject;
		question=questionChecker.transform.Find ("Question").GetComponent<Text>();
		handler = this.transform.root.GetComponent<QuestionHandler> ();

		for (int i=0; i<4; i++)
			answers [i] = questionChecker.transform.Find ("Text " + (i + 1).ToString ()).Find ("Text").GetComponent<Text>();
	}
public void Display()
	{
		int number;
		int.TryParse (this.gameObject.name.Substring (1), out number);


		question.text = number.ToString ()+". "+handler.answered[number].question; //intrebarea

	for (i=0; i<handler.answered[number].answers.Length; i++) { //raspunsurile
		switch(i)
			{
			case 0:
				answers [i].text = "A. "+ handler.answered [number].answers [i];
				break;
			case 1:
				answers [i].text ="B. "+ handler.answered [number].answers [i];
				break;
			case 2:
				answers [i].text ="C. "+ handler.answered [number].answers [i];
				break;
			case 3:
				answers [i].text ="D. "+ handler.answered [number].answers [i];
				break;
			}
		

		}
	

		for (i=handler.answered[number].answers.Length; i<4; i++) 
			answers [i].gameObject.SetActive (false);

	if (handler.answered [number].correct == true)
			answers [handler.answered [number].answer-1].transform.parent.GetComponent<Image> ().color = Color.green;
		else {
			answers [handler.answered [number].answer-1].transform.parent.GetComponent<Image> ().color = Color.red;
			answers [handler.answered [number].correctAnswer-1].transform.parent.GetComponent<Image> ().color = Color.green;
		}
	}
public void Reset()
	{
		for (i=0; i<4; i++)
			answers [i].transform.parent.GetComponent<Image> ().color = Color.white;

		
		for (i=0; i<4; i++)
			answers [i].gameObject.SetActive (true);
	}
public void Interactable()
	{
		button.GetComponent<Button> ().interactable = true;
	}
}

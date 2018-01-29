using UnityEngine;
using System.Collections;

public class Answers : MonoBehaviour {


	public void ChangeAnswer()
	{
		int.TryParse (this.gameObject.name.Substring (1), out QuestionHandler.currentAnswer);
	}
}

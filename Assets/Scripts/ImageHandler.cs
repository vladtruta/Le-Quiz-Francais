using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageHandler : MonoBehaviour
{

//	QuestionHandler handler;
	Sprite imageSprite;
	public int question;

	public void SendInfoToQuestionHandler ()
	{
		try {
		//	handler = this.transform.root.GetComponent<QuestionHandler> ();
		} catch {
			print ("nu mere!");
		}

	}
}

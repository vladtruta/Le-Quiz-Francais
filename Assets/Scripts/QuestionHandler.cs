using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionHandler : MonoBehaviour
{

	[System.Serializable]
	public struct Questions
	{
		public string question;
		public string[] answers;
		public int correctAnswer;
	}
	public Questions[] questions;
	public static int currentQuestion = 0;
	public static int questionNumber = 5;
	public static int currentAnswer;
	public static bool[] visited;
	AdMob admob;

	public struct Answered
	{
		public string[] answers;
		public string question;
		public bool correct;
		public int answer;
		public int correctAnswer;
	}
	[System.NonSerialized]
	public Answered[] answered;

	Text questionCurrentText;
	Text intrebare;
	public static Text[] answers = new Text[4];
	GameObject GameScreen;
	GameObject EndScreen;
	private int i;
	GameObject[] scoreTextsEnd = new GameObject[16];
	GameObject[] scoreTextsAux = new GameObject[16];
	public GameObject button;
	public GameObject blockRaycasts2;

	void Start ()
	{
		intrebare = this.transform.Find ("GameScreen").Find ("QuestionText").GetComponent<Text> ();
		questionCurrentText = this.transform.Find ("GameScreen").Find ("QuestionCurrent").GetComponent<Text> ();
		GameScreen = this.transform.Find ("GameScreen").gameObject;
		EndScreen = this.transform.Find ("EndScreen").gameObject;
		admob = this.gameObject.GetComponent<AdMob> ();
		PlayerPrefs.DeleteAll ();


		for (i=0; i<=3; i++)
			answers [i] = this.transform.Find ("GameScreen").Find ("B" + (i + 1).ToString ()).Find ("Text").GetComponent<Text> ();

		visited = new bool[questions.Length];
		answered = new Answered[16]; //modificat dupa nr maxim de intrebari ce vin in total!

		for (i=1; i<=15; i++) {
			scoreTextsEnd [i] = this.transform.Find ("EndScreen").Find ("Q" + i.ToString ()).gameObject;
			scoreTextsAux [i] = this.transform.Find ("EndScreen").Find ("QuestionTexts" + i.ToString ()).gameObject;
		}

	}

	int randomq;

	public void QHandle ()
	{
	
		if (currentQuestion <= questionNumber) {
			do {
				randomq = Random.Range (1, questions.Length);
			} while(visited[randomq]);

			visited [randomq] = true;

			LoadLevels (randomq);

		} else {

			GameScreen.SetActive (false);
			EndScreen.SetActive (true);
			EndScores();

		}

	
	}
	public void Raycasts2Enable()
	{
			blockRaycasts2.gameObject.SetActive (true);
	}
	public void Raycasts2Disable()
	{
		blockRaycasts2.gameObject.SetActive (false);
	}
	void EndScores ()
	{
		for (i=1; i<=questionNumber; i++) {

			scoreTextsEnd [i].SetActive (true);
			scoreTextsAux [i].SetActive (true);

			Text aux = scoreTextsEnd[i].transform.Find("Text").GetComponent<Text>();
			if (answered[i].correct)
			{
				aux.color=Color.green;
				aux.text="Correct!";
			}
		else 
			{
				aux.color=Color.red;
				aux.text="Incorrect!";
			}
		}
		for (i=questionNumber+1; i<=15; i++) {
			scoreTextsEnd [i].SetActive (false);
			scoreTextsAux [i].SetActive (false);
		}
		admob.ShowInterstitial ();
	}

	public void Increment()
	{
		currentQuestion++;
	}

	public void Reset ()
	{
		currentQuestion = 0;

		for (i=1; i<answered.Length; i++) {
			answered [i].correct = false;
			answered [i].answer = 0;
			answered [i].correctAnswer = 0;

		}

		for (i=1; i<questions.Length; i++) {
			visited[i]=false;
		}
	}

	public void AHandle ()
	{
		if (currentAnswer == questions [randomq].correctAnswer) 
			answered [currentQuestion].correct = true;

		answered [currentQuestion].answers=new string[questions[randomq].answers.Length];
		for (i=0; i<questions[randomq].answers.Length; i++)
			answered [currentQuestion].answers [i] = questions [randomq].answers [i];


		answered [currentQuestion].question = questions[randomq].question;
		answered [currentQuestion].answer = currentAnswer;
		answered [currentQuestion].correctAnswer = questions [randomq].correctAnswer;


		currentAnswer = 0;
			AnswerColor ();

	}

	public void AnswerColor ()
	{
		for (i=0; i<=3; i++)
			if (i == currentAnswer - 1)
				answers [i].transform.parent.gameObject.GetComponent<Image> ().color = new Color (204f / 255f, 204f / 255f, 204f / 255f);
			else
				answers [i].transform.parent.gameObject.GetComponent<Image> ().color = Color.white;
	}

	public void LoadLevels (int qpar)
	{

		intrebare.text = questions [qpar].question;
		questionCurrentText.text = currentQuestion.ToString () + " / " + questionNumber;
		int z;

		for (i=0; i<4; i++) 
			answers [i].transform.parent.gameObject.SetActive (true);

		for (i=0; i<questions[qpar].answers.Length; i++) {
			z = i + 1;
			switch (z) {
			case 1:
				answers [i].text = "A. ";
				break;
			case 2:
				answers [i].text = "B. ";
				break;
			case 3:
				answers [i].text = "C. ";
				break;
			case 4:
				answers [i].text = "D. ";
				break;

			}
		}
		for (i=questions[qpar].answers.Length; i<4; i++) 
			answers [i].transform.parent.gameObject.SetActive (false);

		for (i=0; i<questions[qpar].answers.Length; i++)
			answers [i].text += questions [qpar].answers [i];

	}
	public void Interactable()
	{
		button.GetComponent<Button> ().interactable = true;
	}

}

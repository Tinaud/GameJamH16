using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Examen : MonoBehaviour
{
    private List<string> notes = new List<string>();
    private List<string> notes_2;
    private List<string> answers = new List<string>();
    private List<string> questions = new List<string>();
    private int playerNotes = 1;
    private int good = 0;
    private int ques = 12, Y = 320, x = 0;
    public GameObject canvas;
    GameObject InstObject;
    bool question = false;
    public Text goods;
    public Text total;
	public Text Res;
	public Text score;
	GameObject world;
	bool game = false;


	void Awake() {
		world = GameObject.Find ("World");
	}
    // Use this for initialization
    void Start()
    {

		setupData ();
		Res.text = "";
		score.text = "";
<<<<<<< HEAD
=======
        playerNotes = Player.instance.Note;
        ques = GameManager.instance.NotesMax;
>>>>>>> 8428b5c70d7aba5be73b4abba4f54a19198a8f19
        switch (ques)
        {
            case (12):
                notes.Add("Everywhere");
                questions.Add("Following the explosion, where is little Juliet?");
                goto case 11;
            case (11):
                notes.Add("Oui");
                questions.Add("Just say yes!");
                goto case 10;
            case (10):
                notes.Add("Canada");
                questions.Add("Your friendly neighourhood country.");
                goto case 9;
            case (9):
                notes.Add("Grilled Cheese");
                questions.Add("Quebec's most famous meal.");
                goto case 8;
            case (8):
                notes.Add("Purple");
                questions.Add("The colour of sleep deprivation.");
                goto case 7;
            case (7):
                notes.Add("Trump");
                questions.Add("Kill it with fire.");
                goto case 6;
            case (6):
                notes.Add("Recess");
                questions.Add("Everyone's favourite school subject.");
                goto case 5;
            case (5):
                notes.Add("(a)jar");
                questions.Add("A common type of door.");
                goto case 4;
            case (4):
                notes.Add("socks");
                questions.Add("A wizard's favourite clothing article.");
                goto case 3;
            case (3):
                notes.Add("21-12-2012");
                questions.Add("This is the way the world end.");
                goto case 2;
            case (2):
                notes.Add("Beaver");
                questions.Add("Little ball of fur.");
                goto case 1;
			case (1):
				notes.Add ("Procrastination");
				questions.Add ("A national sport.");
                break;
        }
        notes_2 = new List<string>(notes);
        total.text = ques + "";
		InstObject = (GameObject)Instantiate(Resources.Load("Answers"), new Vector3(0, 0, 0), Quaternion.identity);
		InstObject.transform.parent = canvas.transform;
		InstObject.transform.localScale = new Vector3(1, 1, 1);
		InstObject.transform.localPosition = new Vector3(560, Y, 0);
		InstObject.GetComponentInChildren<Text>().text = "I don't know";
		InstObject.tag = "I don't know";
        for (int i = 1; i < playerNotes+1; i++)
        {
            InstObject = (GameObject)Instantiate(Resources.Load("Answers"), new Vector3(0, 0, 0), Quaternion.identity);
            InstObject.transform.parent = canvas.transform;
            InstObject.transform.localScale = new Vector3(1, 1, 1);
            InstObject.transform.localPosition = new Vector3(560, (Y - 60 * i), 0);
            int rnd = Random.Range(0, notes.Count);
            InstObject.GetComponentInChildren<Text>().text = notes[rnd];
            InstObject.tag = notes[rnd];
            notes.RemoveAt(rnd);
        }
    }

    // Update is called once per frame
    void Update()
    {
        goods.text = good + " /";
		if (!question && x < ques) {
			askquestion (x);
		}	

		if(game)
			SceneManager.LoadScene ("Menu");
    }

    void askquestion(int i)
    {
        int N = 300;
        question = true;
        InstObject = (GameObject)Instantiate(Resources.Load("Text"), new Vector3(0, 0, 0), Quaternion.identity);
        InstObject.transform.parent = canvas.transform;
        InstObject.transform.localScale = new Vector3(1, 1, 1);
        InstObject.transform.localPosition = new Vector3(100, (N - 43 * x), 0);
        int rnd = Random.Range(0, questions.Count);
        InstObject.GetComponentInChildren<Text>().text = questions[rnd];
        answers.Add(notes_2[rnd]);
        notes_2.RemoveAt(rnd);
        questions.RemoveAt(rnd);
    }

    public void verification(string name)
    {
        if (answers[x] == name)
            good++;
        x++;
		question = false;
		if (x >= ques) {
			Cote ();
		}
    }

    public void Cote()
    {
        char cote;
        float resultat = (good / ques) * 100;
		cote = 'E';
        if (resultat > 90)
            cote = 'A';

        if (resultat <= 90)
            cote = 'B';

        if (resultat <= 80)
            cote = 'C';

        if (resultat <= 70)
            cote = 'D';

		if (resultat < 60)
            cote = 'E';
		Res.text = cote + "";
		score.text = "Score: " + Player.instance.PointTotal ();
		StartCoroutine (waitBeforeRestart ());
	}

	void setupData() {
		playerNotes = Player.instance.Note;
		Debug.Log (playerNotes);
		ques = GameManager.instance.NotesMax;
		Debug.Log (ques);

		Destroy (world);
	}
<<<<<<< HEAD
=======

	IEnumerator waitBeforeRestart() {
		yield return new WaitForSeconds (8f);
		game = true;
	}
>>>>>>> 8428b5c70d7aba5be73b4abba4f54a19198a8f19
        
}
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{

	public int score = 0;
	public Text scoreText;
	public Text resultText;
	public string coinTagString;
	public string badCoinTagString;
	public GameObject menu;
	public PlayerMover mymover;
	public Rigidbody body;
	public string losestring;
	public string winstring;
	public string draw;
	int targetscore;
    int finalscore = 0;



	void Start() {
		targetscore = GameObject.FindGameObjectsWithTag(coinTagString).Length;
		menu.SetActive (false);


	}


	void OnCollisionEnter(Collision col)
	{
		Debug.Log("Collision " + col.gameObject.name);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == coinTagString) {
			score = score + 1;
		} else if (other.tag == badCoinTagString) {
			menu.SetActive (true);
			mymover.enabled = false;
			body.isKinematic = true;
			resultText.text = losestring;


		}

		Debug.Log ("Triggered " + score + " " + other.gameObject.name);

		scoreText.text = "1st Score: " + score;


		Destroy (other.gameObject);
	}



		void Update() {
		
		if (menu.activeSelf) {
			mymover.enabled = false;
			body.isKinematic = true;
			finalscore = targetscore - GameObject.FindGameObjectsWithTag (coinTagString).Length;
			if (score > finalscore / 2 && GameObject.FindGameObjectsWithTag (badCoinTagString).Length == 11) {
				resultText.text = winstring;


			}
			else if (score == finalscore / 2 &&  GameObject.FindGameObjectsWithTag (badCoinTagString).Length == 11) {
				resultText.text = draw;
			}

		}
		 else if (GameObject.FindGameObjectsWithTag (coinTagString).Length == 0) {
			menu.SetActive (true);
			mymover.enabled = false;
			body.isKinematic = true;
			if (score > targetscore / 2) {

				resultText.text = winstring;
				
			} else {
				resultText.text = losestring;
			}



		} else if (GameObject.FindGameObjectsWithTag (badCoinTagString).Length == 10) {
			menu.SetActive (true);
			mymover.enabled = false;
			body.isKinematic = true;
		}


	}
}











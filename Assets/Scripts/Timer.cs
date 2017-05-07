using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public int timeLeft;
	public Text countdownText;
	public GameObject menu;


	void Start()
	{
		StartCoroutine("LoseTime");
		menu.SetActive (false);
	}


	void Update()
	{
		countdownText.text = ("Time Left = " + timeLeft);

		if (timeLeft <= 0)
		{
			StopCoroutine("LoseTime");
			countdownText.text = "Times Up!";
			menu.SetActive (true);


		}
	}

	IEnumerator LoseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			timeLeft--;
		}
	}
}
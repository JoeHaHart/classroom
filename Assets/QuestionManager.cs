using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour {
	public string QuestionText;
	public GameObject questionPrefab;
	private GameObject questionInstance;
	public Transform questionSpawnLocation;

	public void askQuestion () {
		questionInstance = Instantiate (questionPrefab, questionSpawnLocation.position, questionSpawnLocation.rotation);
		questionInstance.GetComponent<TextMesh>().text = QuestionText;
	}

	public void answerQuestion() {
		if (questionInstance != null) {
			Destroy(questionInstance);
		}
	}
}
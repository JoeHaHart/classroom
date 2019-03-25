using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[ExecuteInEditMode]
public class SpeechBubbly : MonoBehaviour {

	[TextArea]
	public string mainText;
	private string mainTextWithLines;
	public float lineScale = 0.25f;
	public Transform bubble;
	// Use this for initialization
	void Start () {
		SetText();
		SetBubble();
	}


	void SetBubble() {
		int numLines = mainTextWithLines.Split('\n').Length;
        bubble.localScale = new Vector3(2.231f, lineScale * numLines, 1);

	}

	// Update is called once per frame
	void SetText () {
		mainTextWithLines = splitLines(mainText, 20);
		GetComponentInChildren<TextMesh>().text = mainTextWithLines;
	}

	private string splitLines (string tInp, int n) {
		string ln = "", tOut = "";
		int x = 0, y = 0;

		while (x < tInp.Length  - 1) {
			if (x + n < tInp.Length)
				ln = tInp.Substring (x, n);
			else
				ln = tInp.Substring (x, tInp.Length - x);

			y = ln.LastIndexOf (" ");
			y = y > 0 ? y : ln.Length;

			ln = ln.Substring (0, y);
			tOut = tOut + "\n" + ln;
			x = x + ln.Length;
		};

		return tOut;
	}
}
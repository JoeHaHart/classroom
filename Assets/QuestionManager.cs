using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    private GameObject questionInstance;
    private VectorSelector vectorSelector;
    public GameObject vectorSelectorPrefab;
    public GameObject arrowSelectorPrefab;
    Transform JoeJeffTransform;
    public Vector3 vectorSelectorOffset;
    public Vector3 arrowSelectorSpawnOffset;

    public GameObject speechBubblePrefab;
    public Vector3 speechBubbleRotation;
    public Vector3 speechBubbleOffset;
    public float questionscale;
    float timeSelected;
    float timerSeconds;
    float timeToLaunch;
    bool answered = false;
    bool launched = false;

    Vector3 launchDirection;
    void Start()
    {
        JoeJeffTransform = GameObject.Find("JoeJeff").transform;
    }


    public void askQuestion()
    {
        questionInstance = Instantiate(speechBubblePrefab, JoeJeffTransform.position + speechBubbleOffset, Quaternion.Euler(speechBubbleRotation));
        questionInstance.transform.localScale = Vector3.one * questionscale;
        GameObject selector = Instantiate(vectorSelectorPrefab, JoeJeffTransform.position + vectorSelectorOffset, Quaternion.Euler(0, 90, 0));
        selector.transform.localScale = Vector3.one * 2;
        vectorSelector = selector.GetComponent<VectorSelector>();
        GameObject arrowSelector = Instantiate(arrowSelectorPrefab, JoeJeffTransform.position + arrowSelectorSpawnOffset, new Quaternion());
        vectorSelector.Selector = arrowSelector.transform;
        arrowSelector.GetComponent<VectorSelectionHandler>().vectorSelector = vectorSelector;
    }


    public void answerQuestion(Vector3 unitVectorForce)
    {
        timeSelected = Time.time;
        timerSeconds = 1;
        timeToLaunch = timeSelected + timerSeconds;
        answered = true;
        launchDirection = unitVectorForce;

    }

    private void Update()
    {
        if (answered && !launched)
        {
            TextMesh tm = questionInstance.GetComponentInChildren<TextMesh>();
            if (Time.time < timeToLaunch)
            {
                float secondsRemaining = timeToLaunch - Time.time;
                int displaySeconds = (int)Mathf.Ceil(secondsRemaining);
                tm.text = displaySeconds.ToString();
            }
            else
            {
                launched = true;
                questionInstance.SetActive(false);
                JoeJeffTransform.gameObject.GetComponent<FreezeMe>().UnFreeze(launchDirection);
            }
        }
    }
}
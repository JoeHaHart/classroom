using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public string QuestionText;
    public GameObject questionPrefab;
    private GameObject questionInstance;
    public Transform questionSpawnLocation;
    private VectorSelector vectorSelector;
    public GameObject vectorSelectorPrefab;
    Transform JoeJeffTransform;

    void Start()
    {
        JoeJeffTransform = GameObject.Find("JoeJeff").transform;
    }


    public void askQuestion()
    {
        questionInstance = Instantiate(questionPrefab, questionSpawnLocation.position, questionSpawnLocation.rotation);
        questionInstance.GetComponent<TextMesh>().text = QuestionText;
        GameObject selector = Instantiate(vectorSelectorPrefab, JoeJeffTransform);
        vectorSelector = selector.GetComponent<VectorSelector>();
    }


    public void answerQuestion()
    {
        if (questionInstance != null)
        {
            Destroy(questionInstance);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public static int theScore;



    public void Update()
    {
        //theScore += 1;
        scoreText.GetComponent<Text>().text = "Memories: " + theScore + "/8";
    }
}

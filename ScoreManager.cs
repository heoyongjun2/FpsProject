using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HYJ
{
    public class ScoreManager : MonoBehaviour
    {
        public static int score; // static으로 선언
        Text scoreText;

        void Awake()
        {
            scoreText = this.GetComponent<Text>();
            score = 0;
        }
        void Start()
        {

        }


        void Update()
        {
            scoreText.text = "Score : " + score;
        }
    }
}

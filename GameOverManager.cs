using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HYJ
{
    public class GameOverManager : MonoBehaviour
    {
        void Start()
        {

        }

        void Update()
        {

        }

        public void ResetLevel()
        {
            MyScoreManager.score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
namespace JIT 
{ 
    public class TeamMyEnemyMovement : MonoBehaviour
    {


        public float detectingDistance; //디텍팅거리
        
        float xRandomPosition; //디텍팅에 실패했을때 약간의 움직임을 위한 변수
        float zRandomPosition;
        public float randomNum = 10f;//혼자움직일때 움직이는 범위값(-random부터random사이값을벡터로가질예정)
        Transform player;
        //TeamMyPlayerHealth playerHealth;
        //TeamMyEnemyHealth enemyHealth;
        NavMeshAgent nav;
        PlayerHealth playerHealth;
        MyEnemyHealth enemyHealth;

        // Start is called before the first frame update
        void Awake()
        {
            player = GameObject.FindGameObjectWithTag( "Player").transform;
            //playerHealth = player.GetComponent<TeamMyPlayerHealth>();
            playerHealth = player.GetComponent<PlayerHealth>();
            enemyHealth = this.GetComponent<MyEnemyHealth>();
            nav = GetComponent<NavMeshAgent>();
            
        }


        void OnEnable()//활성화 상태가 될때마다 호출되는 함수
        {
            nav.enabled = true;
            ClearPath();//네비가 가지고있는 길 리셋


        }

        private void Update()
        {
            if (enemyHealth.currentHP > 0 && playerHealth.currentHealth > 0) 
            {
                Sense(player.position, detectingDistance);
            }
            else 
            {
                nav.enabled = false;
            }
        }
        void ClearPath() 
        {
            if (nav.hasPath) 
            {
                nav.ResetPath();
            }
        }


        private void Sense(Vector3 position, float senseRange)//거리를 측정하고 무조건적인 추격이아닌 감지범위에서 걸리면 추격하게끔
        {
            if (Vector3.Distance(transform.position, position) <= senseRange) 
            {
                Chase(position);
            }
            else 
            {
                ClearPath();
                HoldOnPosition();
            }
        }

        private void Chase(Vector3 position) //추격코드
        {
            
            if (enemyHealth.currentHP>0) 
            {
                nav.SetDestination(position);
            }
        }

        private void HoldOnPosition() //위치를 지키며 약간의 움직임을 위해
        {
            xRandomPosition = Random.Range(-randomNum, randomNum);
            zRandomPosition = Random.Range(-randomNum, randomNum);
            Vector3 randomPosition = new Vector3(xRandomPosition, 0f, zRandomPosition);
            
            if (!nav.hasPath) 
            {
                nav.SetDestination(transform.position + randomPosition);
            }
        }


    }
}
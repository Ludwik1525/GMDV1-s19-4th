using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

public class BoardManager : MonoBehaviour {
	
        [Serializable]
        public class Count
        {
            public int minimum;             //Minimum value for our Count class.
            public int maximum;             //Maximum value for our Count class.
            
            
            //Assignment constructor.
            public Count (int min, int max)
            {
                minimum = min;
                maximum = max;
            }
        }


        //static int to make it belong to the class and not the specific instance of it. Should make rows persist right?
        public static int rows = 19;
        
        //might use this
        // public Count checkpoints = new Count (1, 2);                      //Lower and upper limit for our random number of walls per level.

        //Prefab containers
        // public GameObject floorTiles;                                 //Array of floor prefabs.
        public GameObject start;
        public GameObject checkPoint;                                  //Array of checkpoint prefabs - should have collider for saving the score on collenter -> set rgbd2d to is trigger.
        public GameObject end;
        public GameObject enemy, player;
        public GameObject [] enemies;
                                        //Array of enemy prefabs.
        // public GameObject outerWallTiles;                             //Array of outer tile prefabs.

         private Transform boardHolder,boardContainer, enemyContainer;                                  //A variable to store a reference to the transform of our Board object.
        private List <Vector3> gridPositions = new List <Vector3> ();   //A list of possible locations to place tiles.

        public void setRows(int row){
                rows = row;
        }
       

        public void setupBoard(){

                //Container for board pieces, keep the order!
                boardContainer = new GameObject ("BoardContainer").transform;
                float heightOfRow = 0;
                int midpoint = rows / 2;
                int testingStuff = rows / 3;
                

                for(int i = 0; i < rows + 1; i++)
                {
                        
                Vector3 offset = new Vector3(0,heightOfRow,0);

                        GameObject toInstantiate = null;
                        if(i == 0)
                        {                               
                                toInstantiate = start;
                        }
                        else if (i == rows)
                        {
                                toInstantiate = end;
                        }

                        
                        else if(rows >= 10 && i == midpoint - 3|| rows >= 10 && i == midpoint + 2)
                        {
                                toInstantiate = checkPoint;
                        } 
                        else if (rows <= 10 && i == (rows / 2))
                        {
                                toInstantiate = checkPoint;
                        }
                        else 
                        {                        
                        toInstantiate = enemy;
                        }


                        if(toInstantiate)
                        {

                        GameObject instance =
                        Instantiate (toInstantiate, offset,Quaternion.identity) as GameObject;

                        instance.transform.SetParent(boardContainer); 
                        heightOfRow += toInstantiate.transform.localScale.y; 
                        }
                        
                }
                rows = (int)1.5f * rows;
                Spawn(); 
        }

        void Spawn(){
                enemyContainer = new GameObject("EnemyContainer").transform;
                GameObject toInstantiate = null;
                foreach(Transform enemyRow in boardContainer)
                {
                        print(enemyRow.CompareTag("EnemyRow"));
                        if(enemyRow.CompareTag("EnemyRow")){
                                toInstantiate = enemies[Random.Range(0,enemies.Length)];
                        GameObject instance = Instantiate(toInstantiate,enemyRow.position,Quaternion.identity) as GameObject;
                        instance.transform.SetParent(enemyContainer);
                        }else if (enemyRow.CompareTag("StartRow")){
                                toInstantiate = player;
                        GameObject instance = Instantiate(toInstantiate,enemyRow.position,Quaternion.identity) as GameObject;
                        }
                }
        }

       void Start(){
               setupBoard();
       }

      

}



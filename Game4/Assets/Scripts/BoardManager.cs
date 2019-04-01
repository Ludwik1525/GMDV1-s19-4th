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
        public static int rows = 7;
        
        //might use this
        // public Count checkpoints = new Count (1, 2);                      //Lower and upper limit for our random number of walls per level.

        //Prefab containers
        // public GameObject floorTiles;                                 //Array of floor prefabs.
        public GameObject start,checkpoint,end, outerWallStart,outerWallSide;
        
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
                

                        GameObject toInstantiate = null;
                for(int i = 0; i <= rows + 1; i++)
                {
                        
                Vector3 offset = new Vector3(0,heightOfRow,0);

                        if(i == 0)
                        {                               
                                toInstantiate = outerWallStart;
                        }
                        else if(i == 1)
                        {
                                toInstantiate = start;
                        }
                        else if (i == rows)
                        {
                                toInstantiate = end;
                        }                        
                        else if(rows >= 10 && i == midpoint - 3|| rows >= 10 && i == midpoint + 2)
                        {
                                toInstantiate = checkpoint;
                        } 
                        else if (rows <= 10 && i == (rows / 2))
                        {
                                toInstantiate = checkpoint;
                        }
                        
                        else if (i == rows +1)
                        {       
                                
                                float x = toInstantiate.transform.localScale.x / 2;
                                float y = (rows * 100) / 2;
                                float scale = rows * 100;

                                Vector3 rightOuter = new Vector2(x,y);
                                Vector3 leftOuter = new Vector2(-x,y);
                                toInstantiate = outerWallSide;
                                toInstantiate.transform.localScale = new Vector2(50,scale);
                                
                                //2nd instantiaten of outer side walls
                                GameObject instance =
                        Instantiate (toInstantiate, rightOuter,Quaternion.identity) as GameObject;
                        instance.transform.SetParent(boardContainer);

                        instance =
                        Instantiate (toInstantiate, leftOuter,Quaternion.identity) as GameObject;
                        instance.transform.SetParent(boardContainer);

                        toInstantiate = null;
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
                //difficulty setting
                rows = (int)1.5f * rows;
                Spawn(); 
        }

        void Spawn(){
                enemyContainer = new GameObject("EnemyContainer").transform;
                GameObject toInstantiate = null;
                foreach(Transform enemyRow in boardContainer)
                {                       
                        if(enemyRow.CompareTag("EnemyRow")){
                                toInstantiate = enemies[Random.Range(0,enemies.Length)];
                        GameObject instance = Instantiate(toInstantiate,enemyRow.position,Quaternion.identity) as GameObject;
                        instance.transform.SetParent(enemyContainer);
                        }
                        else if (enemyRow.CompareTag("StartRow"))
                        {
                                toInstantiate = player;
                        GameObject instance = Instantiate(toInstantiate,enemyRow.position,Quaternion.identity) as GameObject;
                        }
                }
        }

       void Start(){
               setupBoard();
       }

      

}



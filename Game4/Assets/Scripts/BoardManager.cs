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
        public static int rows = 8;
        
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
                float midpoint = rows / 2;

                for(int i = 0; i < rows + 1; i++)
                {
                        
                Vector3 offset = new Vector3(0,heightOfRow,0);

                        GameObject toInstantiate = null;
                        if(i == 0)
                        {
                                //instantiate start
                                toInstantiate = start;
                        }
                        else if (i == rows)
                        {
                                //instantiate end
                                toInstantiate = end;
                        }

                        //not entirely sure about this evalutation 
                        else if(rows >= 10 && i == midpoint - 2 || rows >= 10 && i == midpoint + 2)
                        {                                        
                                //instantiate checkpoint
                                toInstantiate = checkPoint;
                                
                        } 
                        else if (rows <= 10 && i == (rows / 2) + 1)
                        {
                                toInstantiate = checkPoint;
                        }
                        else 
                        {
                        //instantiate enemyRows
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
                        if(enemyRow.CompareTag("EnemyRow")){
                                toInstantiate = enemies[Random.Range(0,enemies.Length)];
                        }else if (enemyRow.CompareTag("StartRow")){
                                toInstantiate = player;
                        }
                        GameObject instance = Instantiate(toInstantiate,enemyRow.position,Quaternion.identity) as GameObject;
                        instance.transform.SetParent(enemyContainer);
                }
        }

       

      

}

// //Sets up the outer walls and floor (background) of the game board.
//         void BoardSetup ()
//         {
//             //Instantiate Board and set boardHolder to its transform.
//             boardHolder = new GameObject ("Board").transform;
            
//             //Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
//             for(int x = -1; x < columns + 1; x++)
//             {
//                 //Loop along y axis, starting from -1 to place floor or outerwall tiles.
//                 for(int y = -1; y < rows + 1; y++)
//                 {
//                     //Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
//                     GameObject toInstantiate = floorTiles[Random.Range (0,floorTiles.Length)];
                    
//                     //Check if we current position is at board edge, if so choose a random outer wall prefab from our array of outer wall tiles.
//                     if(x == -1 || x == columns || y == -1 || y == rows)
//                         toInstantiate = outerWallTiles [Random.Range (0, outerWallTiles.Length)];
                    
//                     //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
//                     GameObject instance =
//                         Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
                    
//                     //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
//                     instance.transform.SetParent (boardHolder);
//                 }
//             }
//         }
        
        
//         //RandomPosition returns a random position from our list gridPositions.
//         Vector3 RandomPosition ()
//         {
//             //Declare an integer randomIndex, set it's value to a random number between 0 and the count of items in our List gridPositions.
//             int randomIndex = Random.Range (0, gridPositions.Count);
            
//             //Declare a variable of type Vector3 called randomPosition, set it's value to the entry at randomIndex from our List gridPositions.
//             Vector3 randomPosition = gridPositions[randomIndex];
            
//             //Remove the entry at randomIndex from the list so that it can't be re-used.
//             gridPositions.RemoveAt (randomIndex);
            
//             //Return the randomly selected Vector3 position.
//             return randomPosition;
//         }
        
        
//         //LayoutObjectAtRandom accepts an array of game objects to choose from along with a minimum and maximum range for the number of objects to create.
//         void LayoutObjectAtRandom (GameObject[] tileArray, int minimum, int maximum)
//         {
//             //Choose a random number of objects to instantiate within the minimum and maximum limits
//             int objectCount = Random.Range (minimum, maximum+1);
            
//             //Instantiate objects until the randomly chosen limit objectCount is reached
//             for(int i = 0; i < objectCount; i++)
//             {
//                 //Choose a position for randomPosition by getting a random position from our list of available Vector3s stored in gridPosition
//                 Vector3 randomPosition = RandomPosition();
                
//                 //Choose a random tile from tileArray and assign it to tileChoice
//                 GameObject tileChoice = tileArray[Random.Range (0, tileArray.Length)];
                
//                 //Instantiate tileChoice at the position returned by RandomPosition with no change in rotation
//                 Instantiate(tileChoice, randomPosition, Quaternion.identity);
//             }
//         }
        
        
//         //SetupScene initializes our level and calls the previous functions to lay out the game board
//         public void SetupScene (int level)
//         {
//             //Creates the outer walls and floor.
//             BoardSetup ();
            
//             //Reset our list of gridpositions.
//             InitialiseList ();
            
//             //Instantiate a random number of wall tiles based on minimum and maximum, at randomized positions.
//             LayoutObjectAtRandom (wallTiles, wallCount.minimum, wallCount.maximum);
            
//             //Instantiate a random number of food tiles based on minimum and maximum, at randomized positions.
//             LayoutObjectAtRandom (foodTiles, foodCount.minimum, foodCount.maximum);
            
//             //Determine number of enemies based on current level number, based on a logarithmic progression
//             int enemyCount = (int)Mathf.Log(level, 2f);
            
//             //Instantiate a random number of enemies based on minimum and maximum, at randomized positions.
//             LayoutObjectAtRandom (enemyTiles, enemyCount, enemyCount);
            
//             //Instantiate the exit tile in the upper right hand corner of our game board
//             Instantiate (exit, new Vector3 (columns - 1, rows - 1, 0f), Quaternion.identity);
//         }
//     }
// }


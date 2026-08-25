using System;
using UnityEngine;

namespace Workshop.Student
{
    public class MapGenerator : MonoBehaviour
    {
        public int columns = 10;
        public int rows = 10;

        public GameObject[] floorTiles;
        public GameObject[] wallTiles;
        public GameObject[] foodTiles;

        public string[,] saveItemMap = new string[3, 3] {
            { " ", "Soda", " "},
            { " ", " ", " "},
            { " ", " ", "Food"},
        };

        // 1. declare Players variable

        // 7. declare Exit variable 


        public void Start()
        {
            // 1. random player at the position <0, 0> map

            // 2. create obstacles

            // 3. create floor

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    int r = UnityEngine.Random.Range(0, floorTiles.Length);
                    GameObject floor = Instantiate(floorTiles[r],
                        new Vector2(x, y),
                        Quaternion.identity);
                    floor.name = $"{x}-{y}";
                }
            }


            // 4. create walls

            for (int y = -1; y < 11; y++)
            {
                for (int x = -1; x < 11; x++)
                {
                    if (x == -1 || x == 10 || y == -1 || y == 10)
                    {
                        int r = UnityEngine.Random.Range(0, wallTiles.Length);
                        GameObject floor = Instantiate(wallTiles[r],
                            new Vector2(x, y),
                            Quaternion.identity);
                        floor.name = $"{x}-{y}";
                    }
                }
            }

            // 5. random foods

            int numberOfFoods = UnityEngine.Random.Range(2, 3);
            for (int i = 0; i < numberOfFoods; i++)
            {
                int x = UnityEngine.Random.Range(0, columns);
                int y = UnityEngine.Random.Range(0, rows);
                GameObject toInstantiate = foodTiles[UnityEngine.Random.Range(0, foodTiles.Length)];
                Instantiate(toInstantiate, new Vector2(x, y), Quaternion.identity);
            }

            // 6. generate item along with the saveItemMap

            for (int y =  0; y < saveItemMap.GetLength(0); y++)
            {
                for (int x = 0; x < saveItemMap.GetLength(1); x++)
                {
                    string item = saveItemMap[y, x];
                    int foodIndex = -1;
                    for (int i = 0; i < foodTiles.Length; i++)
                    {
                        if ( foodTiles[i].name == item )
                        {
                            foodIndex = i; 
                        }
                    }
                    if (foodIndex > -1)
                    {
                        Instantiate(foodTiles[foodIndex],
                            new Vector2(x, y),
                            Quaternion.identity);
                    }
                }
            }

            // 7. place exit

        }
    }

}
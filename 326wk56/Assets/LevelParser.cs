using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelParser : MonoBehaviour
{
    public TextAsset levelFile; // 在 Inspector 面板指定TXT文件
    public GameObject[] enemyPrefabs; // 在 Inspector 面板指定 4 种敌人 Prefab
    public Transform enemyRoot; // Enemy Root 作为生成的父对象

    public float spacing = 1.5f; // 敌人间距

    void Start()
    {
        ParseLevel();
    }

    void ParseLevel()
    {
        string[] lines = levelFile.text.Split('\n');
        int rows = lines.Length;
        int cols = lines[0].Split(' ').Length;

        Vector2 centerOffset = new Vector2((cols - 1) * spacing / 2, (rows - 1) * spacing / 2);

        for (int row = 0; row < rows; row++)
        {
            string[] numbers = lines[row].Trim().Split(' ');

            for (int col = 0; col < cols; col++)
            {
                int enemyType = int.Parse(numbers[col]) - 1;

                if (enemyType >= 0 && enemyType < enemyPrefabs.Length)
                {
                    Vector2 spawnPos = new Vector2(col * spacing, -row * spacing + 5) - centerOffset;
                    Vector3 worldPos = enemyRoot.position + new Vector3(spawnPos.x, spawnPos.y, 0);
                    GameObject enemy = Instantiate(enemyPrefabs[enemyType], worldPos, Quaternion.identity, enemyRoot);
                }
            }
        }
    }
}

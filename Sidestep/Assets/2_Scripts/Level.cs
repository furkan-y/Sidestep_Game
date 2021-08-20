using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    Enemies enemies;

    [Header("Game Settings")]
    public float playerSpeed;
    public float verWallSpeed;
    public float horWallSpeed;
    public float followerEnemySpeed;
    public float normalEnemySpeed;
    public int timeBetweenEnemySpawns;
    public int SpawnEnemyCount;
    public int TotalEnemyCount;
    public int LevelOfFollowerEnemy;
    public int LevelOfNormalEnemy;

    [Header("Others")]
    public TMPro.TextMeshProUGUI score_tmp;
    public int score = 0;

    private int level = 1;

    public GameObject Diamond;
    public GameObject[] DiamondPrefabs;
    SpriteRenderer DiaSpriteRenderer;
    PolygonCollider2D polygonCollider2D;

    void Start()
    {
        enemies = GameObject.FindObjectOfType<Enemies>();
        score_tmp.text = score.ToString();
        StartCoroutine(ThreeSecondCountdown());

        Diamond = GameObject.FindWithTag("Diamond");
    }

    public void IncreaseScore()
    {
        score++;
        score_tmp.text = score.ToString();
    }

    public void IncreaseLevel()
    {
        level++;

        if (level == LevelOfFollowerEnemy)
        {
            enemies.followerEnemyPre.SetActive(true);
        }
        if (level == LevelOfNormalEnemy)
        {
            InvokeRepeating("CallEnemySpawner", 9f, timeBetweenEnemySpawns);
        }

        if (score < 91)
        {
            Diamond = GameObject.FindWithTag("Diamond");
            Destroy(Diamond);
            InstantiateDiamond();
        }
        else
        {
            TranslateDiamond();
        }

        IncreaseTheDifficulty();
    }

    public void IncreaseTheDifficulty()
    {
        playerSpeed += 0.1f;
        verWallSpeed += 0.06f;
        horWallSpeed += 0.06f;
        if (SpawnEnemyCount < TotalEnemyCount)
        {
            SpawnEnemyCount += 1;
        }
        normalEnemySpeed += 0.1f;
    }

    public void CallEnemySpawner()
    {
        enemies.NormalEnemySpawn();
    }

    public void TranslateDiamond()
    {
        StartCoroutine(WaitAndTranslateDia());
    }

    private void InstantiateDiamond()
    {
        StartCoroutine(WaitAndInstantiateDia());
    }

    IEnumerator WaitAndTranslateDia()
    {
        Diamond = GameObject.FindWithTag("Diamond");
        DiaSpriteRenderer = Diamond.GetComponent<SpriteRenderer>();
        DiaSpriteRenderer.enabled = false;
        polygonCollider2D = Diamond.GetComponent<PolygonCollider2D>();
        polygonCollider2D.enabled = false;

        yield return new WaitForSeconds(1f);

        float xValue = Random.Range(-2.5f, 2.5f);
        float yValue = Random.Range(-4f, 4f);
        Vector3 nextPosition = new Vector3(xValue, yValue, 0);
        Diamond.transform.position = nextPosition;

        polygonCollider2D.enabled = true;
        DiaSpriteRenderer.enabled = true;
    }

    IEnumerator WaitAndInstantiateDia()
    {
        yield return new WaitForSeconds(1f);

        float xValue = Random.Range(-2.5f, 2.5f);
        float yValue = Random.Range(-4f, 4f);
        Vector3 nextPosition = new Vector3(xValue, yValue, 0f);
        Instantiate(DiamondPrefabs[level - 1], nextPosition, Quaternion.identity);

        Diamond = GameObject.FindWithTag("Diamond");
        DiaSpriteRenderer = Diamond.GetComponent<SpriteRenderer>();
        DiaSpriteRenderer.enabled = false;
        polygonCollider2D = Diamond.GetComponent<PolygonCollider2D>();
        polygonCollider2D.enabled = false;

        DiaSpriteRenderer.enabled = true;
        polygonCollider2D.enabled = true;
    }

    IEnumerator ThreeSecondCountdown()
    {
        yield return new WaitForSeconds(3);

        float xValue = Random.Range(-2.5f, 2.5f);
        float yValue = Random.Range(-4f, 4f);
        Vector3 nextPosition = new Vector3(xValue, yValue, 0f);
        Instantiate(DiamondPrefabs[level - 1], nextPosition, Quaternion.identity);
    }

}

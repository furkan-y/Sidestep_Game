using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    Level level;

    [SerializeField] GameObject Player;

    public GameObject followerEnemyPre;

    public GameObject dangerSymbol;
    public GameObject enemyPrefab;
    public List<GameObject> enemyList;
    int sayac = 0;

    public AudioSource normalEnemySpawnSound;

    void Start()
    {
        level = GameObject.FindObjectOfType<Level>();
        enemyList = new List<GameObject>();

        Create(enemyPrefab, enemyList);
    }

    void Update()
    {
        if (followerEnemyPre.activeSelf == true)
        {
            FollowerEnemyMove();
        }
    }

    private void Create(GameObject Enemy, List<GameObject> list)
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject newEnemy = Instantiate(Enemy, gameObject.transform);
            newEnemy.SetActive(false);    // hepsini bir anda Instantiate etmemesi için üretilen yeni nesneyi pasif yapýyoruz
            list.Add(newEnemy);
        }
    }

    public void NormalEnemySpawn()
    {
        StartCoroutine("NormalEnemySpawn2");
    }

    IEnumerator NormalEnemySpawn2()
    {
        float xValue = Random.Range(-1.6f, 1.6f);
        float yValue = Random.Range(-3f, 3f);
        Vector3 nextPosition = new Vector3(xValue, yValue, 0);
        gameObject.transform.position = nextPosition;

        dangerSymbol.transform.position = nextPosition;
        dangerSymbol.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        dangerSymbol.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        normalEnemySpawnSound.Play();

        foreach (GameObject enemyPrefab in enemyList)
        {
            if (sayac < level.SpawnEnemyCount)
            {
                sayac++;
                int randRotate = Random.Range(1, 360);
                enemyPrefab.transform.Rotate(0, 0, randRotate);
                enemyPrefab.transform.position = nextPosition;
                if (enemyPrefab.activeSelf == false)
                {
                    enemyPrefab.SetActive(true);
                }
            }
        }
        StartCoroutine(EnemySetFalse(nextPosition));
    }

    IEnumerator EnemySetFalse(Vector3 nextPostion)
    {
        gameObject.transform.position = nextPostion;
        yield return new WaitForSeconds(5);
        foreach(GameObject enemyPrefab in enemyList)
        {
            if(enemyPrefab.activeSelf == true)
            {
                enemyPrefab.SetActive(false);
                enemyPrefab.transform.position = nextPostion;
            }
        }
        sayac = 0;
    }

    private void FollowerEnemyMove()
    {
        followerEnemyPre.transform.position = Vector3.MoveTowards
            (followerEnemyPre.transform.position, Player.transform.position, level.followerEnemySpeed * Time.deltaTime);
    }

}

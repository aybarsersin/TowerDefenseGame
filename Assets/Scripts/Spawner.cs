using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy; //oluşturulacak enemy prefabi referansı
    public GameObject[] enemies; //Enemyler için bir liste oluşturduk
    public static Spawner instance;
    [SerializeField] Enemy[] enemyTypes;
    public float byteCoin=50;
    [SerializeField] Text goldText;

    void Start()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        goldText.text = "" + byteCoin;
        StartCoroutine(Spawn());
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); //enemyleri listeye aldık
    }
    public void EditCoin(float amount)
    {
        byteCoin += amount;
        goldText.text = "" + byteCoin;
    }
    IEnumerator Spawn() //bekleme yapabilmek için bir coroutine oluşturduk 
    {
         while (true) //Sonsuz bir döndüye aldık 
         {
             yield return new WaitForSeconds(2);//2 saniye beklem yaptık
             GameObject enm= Instantiate(enemy, transform);//Enemy objesini spawn objesinin olduğu yerde oluşturduk
             enm.GetComponent<EnemyBehaviour>().myType = enemyTypes[Random.Range(0, enemyTypes.Length)];
             yield return new WaitForSeconds(0.2f);
             GameObject enm2 = Instantiate(enemy, transform);
             enm2.GetComponent<EnemyBehaviour>().myType = enemyTypes[Random.Range(0, enemyTypes.Length)];
             yield return new WaitForSeconds(0.2f);
             GameObject enm3 = Instantiate(enemy, transform);
             enm3.GetComponent<EnemyBehaviour>().myType = enemyTypes[Random.Range(0, enemyTypes.Length)];
         }

    }
}

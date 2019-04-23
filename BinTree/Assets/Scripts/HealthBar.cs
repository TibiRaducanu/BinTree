using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    public float initialHealth;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        initialHealth = boss.GetComponent<SpawnAnnoyingEnemy>().health;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if (!boss)
        {
            GameObject healthBar = GameObject.Find("HealthBar");
            Destroy(healthBar.gameObject);
            return;
        }
        float health = boss.GetComponent<SpawnAnnoyingEnemy>().health;
        bar.localScale = new Vector3(health / initialHealth, 1);
    }
}

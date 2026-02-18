using System;
using TMPro;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Config")]
    public float fireInterval = 5.0f;
    public float clickTimeValue = 1.0f;
    public int[] costs = new int[4];
    public Transform projectilePrefab;

    public TextMeshProUGUI countdownText;
    
    private float timer;

    private void Awake()
    {
        timer = fireInterval;
        countdownText.text = (Mathf.CeilToInt(timer)).ToString();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Fire();
            timer = fireInterval;
        }
        
        countdownText.text = (Mathf.CeilToInt(timer)).ToString();
    }
    
    private void Fire()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity, transform);
    }

    public void Upgrade()
    {
        fireInterval -= 1.0f;
    }

    public void OnClick()
    {
        timer -= clickTimeValue;
        // let update handle fire
    }
}

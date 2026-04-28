using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{   
    private int coinCount = 0;
    public TextMeshProUGUI coinText;
    public GameObject particle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateCoinUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Coin"))
        {
            coinCount++;
            UpdateCoinUI();
            Destroy(other.gameObject);
            Instantiate(particle,transform.position,transform.rotation);
        }
    }

    void UpdateCoinUI()
    {
        coinText.text = coinCount.ToString();
    }
}

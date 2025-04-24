using UnityEngine;
using TMPro;
public class CoinsHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Texto;
    [SerializeField] int Value;
     // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnEnable()
    {
        Player.OnCollect += CollectPoints;

    }
    private void OnDisable()
    {
        Player.OnCollect -= CollectPoints;
    }
    // Update is called once per frame
    void Update()
    {
        Texto.text = "Monedas : " + Value;
    }
    public void CollectPoints()
    {
        Value++;
    }
}

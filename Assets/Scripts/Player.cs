using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
public class Player : MonoBehaviour
{
    [SerializeField] float   Vida = 1f;
    [SerializeField] Image BarraVida;
    public static event Action OnDie;
    [SerializeField] bool CanCure;
    [SerializeField] float time = 5;
    [SerializeField] float Count;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BarraVida.fillAmount = Vida;
    }

    // Update is called once per frame
    void Update()
    {
        BarraVida.fillAmount = Vida;
        if(Vida <= 0){
            OnDie?.Invoke();
            //muerte
        }

        if (CanCure) {
            Count += Time.deltaTime;
            if (Count >= time)
            {
                Vida = Vida + 0.1f;
                Count = 0;
            }
        }
        if (Vida >1)
        {
            Vida = 1;
        }

    }
    private void OnTriggerStay(Collider collider)
    {
        if(collider.tag == "Recover") {

            CanCure = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Recover")
        {

            CanCure = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemigo")
        {

            CanCure = false;
        }
    }
}

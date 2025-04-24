using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
public class Player : MonoBehaviour
{
    [SerializeField] float   Vida = 1f;
    [SerializeField] Image BarraVida;
    public static event Action OnDie;
    public static event Action OnCollect;
    [SerializeField] bool CanCure;
    [SerializeField] float time = 5;
    [SerializeField] float Count;
    public bool CanJump;
    public bool Pass;
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
    private void OnEnable()
    {
        OnCollect += Collect;
    }
    private void OnDisable()
    {

        OnCollect -= Collect;
    }
    private void OnCollisionStay(Collision collision)
    {
        CanJump = true;
        if (collision.gameObject.tag == "Recover"|| collision.gameObject.tag == "Fin")
        {

            CanCure = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Moneda" || other.gameObject.tag == "Fin")
        {
            OnCollect?.Invoke();
            Destroy(other.gameObject);

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        CanJump = false;
        if (collision.gameObject.tag == "Recover")
        {

            CanCure = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {

            Vida -= 0.1f;
        }
        else if (collision.gameObject.tag == "Dead")
        {
            Vida = Vida - Vida;
        }
    }
    public void Collect()
    {
        Debug.Log("Recolecto 1 moneda");
    }

}

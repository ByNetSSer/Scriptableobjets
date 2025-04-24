using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class PlayerManagement : MonoBehaviour
{
    [SerializeField] GameObject[] Jugadores;
    [SerializeField] int PositionSelected = 0;
    public static event Action OnChangePlayer;
    public static event Action OnWin;
    [SerializeField] GameObject PlayerSelected;
    float DireccionV;
    float DireccionH;
    [SerializeField]float JumpForce;
    [SerializeField] float MovementForce;
    public int all;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        PlayerSelected = Jugadores[PositionSelected];
    }

    // Update is called once per frame
    void Update()
    {
        all = 0;
        for (int i = 0; i <Jugadores.Length; i++)
        {
            if (Jugadores[i].GetComponent<Player>().Pass)
            {
                all++;
            }
            
        }
        if (all == Jugadores.Length)
        {
            OnWin?.Invoke();
        }

        PlayerSelected =  Jugadores[PositionSelected];
    }
    private void FixedUpdate()
    {
        PlayerSelected.GetComponent<Rigidbody>().linearVelocity = new Vector3(DireccionH* MovementForce, PlayerSelected.GetComponent<Rigidbody>().linearVelocity.y, DireccionV* MovementForce);
    }
    public void OnMovementV(InputAction.CallbackContext context)
    {
        DireccionV = context.ReadValue<float>();
    }
    public void OnMovementH(InputAction.CallbackContext context)
    {
        DireccionH = context.ReadValue<float>();
    }
    public void OnChangePlayerButton(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (PositionSelected+ 1 > Jugadores.Length)
        {
            PositionSelected = 0;
        }
        else
        {
            PositionSelected++;
        }
        
    }
    public void Onjump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (PlayerSelected.GetComponent<Player>().CanJump)
        {
            PlayerSelected.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
        
    }
    public void Win()
    {
        Debug.Log("ganaste");
    }
    private void OnEnable()
    {
        OnWin += Win;
    }
    private void OnDisable()
    {
        OnWin -= Win;
    }
}

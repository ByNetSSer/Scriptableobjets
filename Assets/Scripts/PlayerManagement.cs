using UnityEngine;
using System;
using UnityEngine.InputSystem;
public class PlayerManagement : MonoBehaviour
{
    [SerializeField] GameObject[] Jugadores;
    [SerializeField] int PositionSelected = 0;
    public static event Action OnChangePlayer;
    [SerializeField] GameObject PlayerSelected;
    float DireccionV;
    float DireccionH;
    [SerializeField]float JumpForce;
    [SerializeField] float MovementForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        PlayerSelected = Jugadores[PositionSelected];
    }

    // Update is called once per frame
    void Update()
    {
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

}

using UnityEngine;

public class Pantallas : MonoBehaviour
{
    [SerializeField] GameObject pantallaDead;
    [SerializeField] GameObject pantallaWin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        Player.OnDie += ActivateDead;
        PlayerManagement.OnWin += ActivateWin;
    }
    private void OnDisable()
    {
        Player.OnDie -= ActivateDead;
        PlayerManagement.OnWin -= ActivateWin;
    }
    public void ActivateDead()
    {
        pantallaDead.SetActive(true);
    }
    public void ActivateWin()
    {
        pantallaWin.SetActive(true);
    }
}

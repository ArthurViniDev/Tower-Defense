using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject currentTowerSelected;
    [HideInInspector] public int money = 100;

    public static PlayerController PlayerControllerSingleton;

    private void Awake()
    {
        if (PlayerControllerSingleton == null)
        {
            PlayerControllerSingleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}

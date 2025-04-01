using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject currentTowerSelected;
    [HideInInspector] public int money = 100;

    public static PlayerController playerControllerSingleton;

    private void Awake()
    {
        if (playerControllerSingleton == null)
        {
            playerControllerSingleton = this;
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

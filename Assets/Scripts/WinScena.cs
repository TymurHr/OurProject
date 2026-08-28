using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] public GameObject winScreen;
 
    public string targetTag = "DestructibleItem";

    private GameObject[] items;

    void Start()
    {

        if (winScreen != null)
        {
            winScreen.SetActive(false);
        }
        items = GameObject.FindGameObjectsWithTag(targetTag);
    }

    void Update()
    {
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        GameObject[] remainingItems = GameObject.FindGameObjectsWithTag(targetTag);

        if (remainingItems.Length == 0)
        {
            TriggerWin();
        }
    }

    void TriggerWin()
    {
        if (winScreen != null && !winScreen.activeSelf)
        {
            winScreen.SetActive(true);
            Debug.Log("??????! ??? ???????? ??????????.");
        }
    }
}

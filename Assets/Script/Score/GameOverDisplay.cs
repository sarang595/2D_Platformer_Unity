using UnityEngine;

public class GameOverDisplay : MonoBehaviour
{
    public void displayegameover()
    {
        bool canDisplay = !gameObject.activeSelf;
        if (canDisplay)
        {
            gameObject.SetActive(true);
        }
       
    }
}

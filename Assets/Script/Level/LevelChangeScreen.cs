using UnityEngine;

public class LevelChangeScreen : MonoBehaviour
{
    public void displayloading()
    {
        bool canDisplay = !gameObject.activeSelf;
        if (canDisplay)
        {
            gameObject.SetActive(true);
        }

    }
}

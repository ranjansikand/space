// Script attached to the Menus canvas
// Controls menu buttons


using UnityEngine;

public class Menus : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void OpenPauseMenu() {
        pauseMenu.SetActive(true);
    }
}

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu_manager : MonoBehaviour
{
    [SerializeField] private Button first_select_button;
    [SerializeField] private Canvas level_canvas_opener;

    private void Start()
    {
        first_select_button.Select();
    }
    public void play()
    {
        Debug.Log("gaming");
        SceneManager.LoadScene("SampleScene");
    
    }

    public void play_level_1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void end_game()
    {
        Application.Quit();
    }

    public void level_canvas()
    { 
        level_canvas_opener.gameObject.SetActive(true);
    
    }


}

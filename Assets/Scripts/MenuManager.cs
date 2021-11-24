using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button start_button;
    [SerializeField] private Button options_button;
    [SerializeField] private Button exit_button;

    private void Start()
    {
        start_button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });

        options_button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(2);
        });

        exit_button.onClick.AddListener(() =>
        {
            QuitGame();
        });
    }

    void QuitGame () {
        Application.Quit ();
    }
}
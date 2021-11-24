using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;

    private void Start()
    {
        button1.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });

        button2.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(2);
        });

        button3.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(3);
        });
    }
}
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionMenuManager : MonoBehaviour
{
    [SerializeField] private Button back_button;

    private void Start()
    {
        back_button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
    }
}

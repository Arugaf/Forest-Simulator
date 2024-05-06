using Unity.VisualScripting;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    [SerializeField] private Canvas canvas;

    public void Start() {
        TreesFileLoader.GotSuccessfulLoad += OnSuccessfulLoad;
    }

    private void Hide() {
        if (canvas == null) return;
        canvas.GameObject().SetActive(false);
    }

    public void Show() {
        if (canvas == null) return;
        canvas.GameObject().SetActive(true);
    }

    public void AppExit() {
        Application.Quit();
    }

    private void OnSuccessfulLoad() {
        Hide();
    }
}
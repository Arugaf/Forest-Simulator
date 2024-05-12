using UnityEngine;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour {
    [SerializeField] private GameObject mainPageGroup;
    [SerializeField] private GameObject builtInModelsPageGroup;

    public void GoToBuiltInModelsPage() {
        builtInModelsPageGroup.SetActive(true);
        mainPageGroup.SetActive(false);
    }

    public void GoToMainPage() {
        mainPageGroup.SetActive(true);
        builtInModelsPageGroup.SetActive(false);
    }
}
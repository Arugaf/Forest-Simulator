using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour {
    public static InputHandler Instance { get; private set; }

    public static event UnityAction GotEscapeKeyDown;

    public void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) GotEscapeKeyDown?.Invoke();
    }
}
using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    [SerializeField] private GameObject pauseMenuGroup;

    private bool _active = false;

    public void Start() {
        InputHandler.GotEscapeKeyDown += OnEscapeKeyDown;
    }

    public void ClosePauseMenu() {
        pauseMenuGroup.SetActive(false);
        Time.timeScale = 1;
        _active = false;
    }

    public void OnDestroy() {
        InputHandler.GotEscapeKeyDown -= OnEscapeKeyDown;
        Time.timeScale = 1;
    }

    private void OnEscapeKeyDown() {
        if (!_active) {
            pauseMenuGroup.SetActive(true);
            Time.timeScale = 0;
            // todo: freeze rotation
            _active = true;
        }
        else {
            ClosePauseMenu();
        }
    }
}
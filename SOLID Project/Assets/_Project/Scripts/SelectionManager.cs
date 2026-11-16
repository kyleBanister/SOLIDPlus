﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager: MonoBehaviour {
    [SerializeField] private GameObject _responseHandler;
    private ISelectionResponse _selectionResponse;
    private IRayProvider _rayProvider;
    private ISelector _selector;
    private Transform _currentSelection; 

    private void Awake() {
        SceneManager.LoadScene("Environment", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        _selectionResponse = _responseHandler.GetComponent<ISelectionResponse>();
        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<ISelector>();
    }

    private void Update() {
        if (_currentSelection != null) {
            _selectionResponse.OnDeselect(_currentSelection);
        }
        
        _selector.Check(_rayProvider.CreateRay());
        _currentSelection = _selector.GetSelection();

        if (_currentSelection != null) {
            _selectionResponse.OnSelect(_currentSelection);
        }
    }
}
using UnityEngine;
using System.Collections.Generic;


public class SwitcherSelector: MonoBehaviour, ISelector, IChangeable {
    [SerializeField] private List<Selectable> selectables;
    [SerializeField] private Transform _selection;
    [SerializeField] private GameObject _responseHandler;
    private ISelectionResponse responseMethod;
    private int iterator = 0;
    

    public void Start() {
        responseMethod = _responseHandler.GetComponent<ISelectionResponse>();
    }

    public void Check(Ray ray) {
        _selection = null;
        if(iterator != 0) {
            _selection = selectables[iterator-1].transform;
        }
    }

    public void Next() {
        if(iterator != 0) {
            responseMethod.OnDeselect(_selection);
        }
        iterator = (iterator+1) % (selectables.Count+1);
    }

    public Transform GetSelection() {
        return _selection;
    }
}
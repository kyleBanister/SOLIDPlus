using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Switcher: MonoBehaviour {
    public List<GameObject> ChangeableObjects;
    [SerializeField] private List<IChangeable> _changeableObjects = new List<IChangeable>();

    private void Start() {
        for(var i = 0; i < ChangeableObjects.Count; ++i) {
            var changeableObjectsList = ChangeableObjects[i].GetComponents<IChangeable>().ToList();
            for(var j = 0; j < changeableObjectsList.Count; ++j) {
                _changeableObjects.Add(changeableObjectsList[j]);
            }
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.N)) {
            for(var i = 0; i < _changeableObjects.Count; ++i) {
                _changeableObjects[i].Next();
            }
        }
    }
}

public interface IChangeable {
    void Next();
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.InputSystem;

[Serializable]
public class SphereData
{
    public bool isGreen;
    public float x;
    public float y;
    public float z;
}

[RequireComponent(typeof(NavMeshAgent))]
public class SphereBehavior : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>();
    private int index = -1;

    private NavMeshAgent agent;

    private bool _isGreen = true;

    private string dataPath;

    public bool isGreen {
        get { return _isGreen; }
        set {
            if (value) {
                GetComponent<Renderer>().material.SetColor(
                    "_Color", Color.green);
            }
            else {
                GetComponent<Renderer>().material.SetColor(
                    "_Color", Color.red);
            }
            _isGreen = value;
        }
    }
    // Start is called before the first frame update
    void Start() {
        dataPath =
            Application.persistentDataPath + "/sphere" + gameObject.name + ".dat";

        if (File.Exists(dataPath)) {
            Load();
        }
        else {
            isGreen = true;
        }
        agent = GetComponent<NavMeshAgent>();
        NextDestination(false);
    }

    // Update is called once per frame
    void Update() {
        if (agent.remainingDistance <= agent.stoppingDistance) {
            NextDestination();
        }
    }

    private void NextDestination(bool change=true) {
        Save();
        int oldIndex = index;
        while (oldIndex == index) {
            index = UnityEngine.Random.Range(0, targets.Count);
        }
        agent.SetDestination(targets[index].position);
        if(change)
            isGreen = !isGreen;
    }

    public void Save() {
        FileStream file = File.Create(dataPath);

        try {
            BinaryFormatter bf = new BinaryFormatter();
            SphereData sd = new SphereData();
            sd.isGreen = isGreen;
            sd.x = transform.position.x;
            sd.y = transform.position.y;
            sd.z = transform.position.z;
            bf.Serialize(file, sd);
        }
        finally {
            file.Close();
        }
    }

    public void Load() {
        FileStream file = File.Open(dataPath, FileMode.Open);

        try {
            BinaryFormatter bf = new BinaryFormatter();
            SphereData sd = bf.Deserialize(file) as SphereData;
            isGreen = sd.isGreen;
            Vector3 position = new Vector3(sd.x, sd.y, sd.z);
            transform.position = position;
        }
        finally {
            file.Close();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour, ITriggerable
{
    public List<GameObjectListWrapper> Waves = new List<GameObjectListWrapper>();
    public float Delay = 0f;
    public GameObject ObjectToTrigger;
    private int _currentWave = 0;
    private bool _enableSpawning = false;

    [System.Serializable]
    public class GameObjectListWrapper
    {
        public List<GameObject> GameObjects = new List<GameObject>();
    }

    public void Trigger()
    {
        Invoke("EnableSpawner", Delay);
        
    }

    public void EnableSpawner()
    {
        SpawnWave(0);
        _enableSpawning = true;
    }

    public bool IsWaveDead()
    {
        bool ret = true;
        foreach(GameObject o in Waves[_currentWave].GameObjects)
        {
            if (o == null) { continue; }
            if(o.GetComponent<HealthSystem>().Health > 0)
            {
                ret = false;
            }
        }
        return ret;
    }

    private void Update()
    {
        if(IsWaveDead() && _enableSpawning && _currentWave < Waves.Count-1)
        {
            SpawnWave(_currentWave+1);
        }
        if(IsWaveDead() && _currentWave == Waves.Count - 1)
        {
            var component = ObjectToTrigger.GetComponent<ITriggerable>();
            if(component != null)
            {
                component.Trigger();
            }
            Destroy(this);
        }
    }

    public void SpawnWave(int index = 0)
    {
        foreach(GameObject o in Waves[index].GameObjects)
        {
            o.SetActive(true);
        }
        _currentWave = index;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // Serialized variable for linking to the prefab object
    [SerializeField] private GameObject enemyPrefab;

    // Private variable to keep track of the enemy instance in the scene
    private GameObject _enemy;

    // Update is called once per frame
    void Update()
    {
        // Only spawn a new enemy if there isn’t already one in the scene
        if (_enemy == null)
        {
            // Make a copy of the prefab object
            _enemy = Instantiate(enemyPrefab) as GameObject; // cast generic to GameObject

            _enemy.transform.position = new Vector3(30, 1, -10);

            float rotation = Random.Range(0, 360);
            _enemy.transform.Rotate(0, rotation, 0);
        }
    }
}

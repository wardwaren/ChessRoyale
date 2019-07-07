using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{

    WaveConfig waveConfig;
    List<Transform> Path;


    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Path = waveConfig.getWaypoints();
        transform.position = Path[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }


    private void Move()
    {
        if (waypointIndex <= Path.Count - 1)
        {

            var targetPosition = Path[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.getMoveSpeed() * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);


            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}

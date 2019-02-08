using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour
{
  private Transform goal;
  private NavMeshAgent agent;

  void Start () {
    goal = Camera.main.transform;
    agent = GetComponent<NavMeshAgent>();
    agent.destination = goal.position;
    GetComponent<Animation>().Play ("walk_in_place");
  }

  void Update(){
    goal = Camera.main.transform;
    agent.destination = goal.position;
    if(Vector3.Distance (transform.position, Camera.main.transform.position) <= 3) {
      GetComponent<Animation>().Play ("attack");
    }
  }

  void OnTriggerEnter (Collider col)
  {
    GetComponent<CapsuleCollider>().enabled = false;
    Destroy(col.gameObject);
    agent.destination = gameObject.transform.position;
    GetComponent<Animation>().Stop ();
    GetComponent<Animation>().Play ("fallingback");
    Destroy (gameObject, 16);

    GameObject zombie = Instantiate(Resources.Load("zombie", typeof(GameObject))) as GameObject;

    float randomX = UnityEngine.Random.Range (-12f,12f);
    float constantY = .01f;
    float randomZ = UnityEngine.Random.Range (-13f,13f);
    zombie.transform.position = new Vector3 (randomX, constantY, randomZ);

    while (Vector3.Distance (zombie.transform.position, Camera.main.transform.position) <= 3) {
      randomX = UnityEngine.Random.Range (-12f,12f);
      randomZ = UnityEngine.Random.Range (-13f,13f);
      zombie.transform.position = new Vector3 (randomX, constantY, randomZ);
    }
  }
}
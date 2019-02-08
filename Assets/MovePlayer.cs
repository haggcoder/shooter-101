using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 0.3f;
    public GameObject player;

	public AudioSource steps;
    public bool move = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space)||Input.GetButtonDown("Fire1")){
			if(move==false){
				steps.Play();
				move=true;
			}else{
				steps.Stop();
				move=false;
			}
		}
        Vector3 movePos = new Vector3(
			player.transform.forward.x,
			0,
			player.transform.forward.z
		);
		if(move==true){
		this.transform.position += movePos * speed * Time.deltaTime;
		}
    }
}

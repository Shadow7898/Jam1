using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public TextMeshProUGUI countText;
    
    public float speed = 5.0f;
    private Rigidbody body;

    private int count;
    void Start()
    {
        count = 0;
        body = GetComponent<Rigidbody>();

        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        float xforce = Input.GetAxis("Horizontal");
        float zforce = Input.GetAxis("Vertical");

        body.AddForce(new Vector3(xforce * speed, 0f, zforce * speed));
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
			count = count + 100;

			// Run the 'SetCountText()' function (see below)
			SetCountText();
        }
    }

    void SetCountText(){
        countText.text = "Score: " + count.ToString();
    }
}

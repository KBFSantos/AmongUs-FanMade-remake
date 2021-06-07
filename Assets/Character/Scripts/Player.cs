using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public Camera PlayerCamera;
    public float Speed;
    private Rigidbody2D Playerrgidbody;
    private Vector3 movement;
    public TypePlayer Playert = TypePlayer.Crew;
    private GameObject PlayerHud;

    public enum TypePlayer
    {
        Impostor,
        Crew

    }


    // Start is called before the first frame update
    void Start()
    {
        PlayerHud = GameObject.FindWithTag("PlayerUI");
        Playerrgidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHud.GetComponentInChildren<Slider>().value = ProgressTasks.GetProgress();
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0f);
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        if (Input.GetAxis("Horizontal") < 0) {
            transform.localScale = new Vector3(-2.53772f, transform.localScale.y,transform.localScale.z);
        }

        if(Input.GetAxis("Horizontal") > 0.001f)
        {
            transform.localScale = new Vector3(2.53772f, transform.localScale.y, transform.localScale.z);
        }


    }

    private void FixedUpdate()
    {
        Playerrgidbody.MovePosition(transform.position + movement * Speed * Time.fixedDeltaTime);
        PlayerCamera.transform.position = new Vector3(transform.position.x, transform.position.y, PlayerCamera.transform.position.z);

    }

}

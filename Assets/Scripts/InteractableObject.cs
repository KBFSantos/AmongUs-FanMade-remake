using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    protected bool CanInteract = true;
    public Sprite CustomActionSprite;
    private Sprite BaseUseSprite;
    protected Player PlayerEnt;
    protected Button ActionButton;
    protected bool InArea = false;
    protected bool Using = false;


    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        PlayerEnt = GameObject.FindWithTag("Player").GetComponentInChildren<Player>();
        ActionButton = GameObject.FindWithTag("PlayerUI").GetComponentInChildren<Button>();
        BaseUseSprite = ActionButton.gameObject.GetComponent<Image>().sprite;
    }

    public virtual void CheckInteractionInput()
    {
        if (InArea && !Using)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerEnt.enabled = false;
                Using = true;

            }

        }

        if (Using)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ExitAction();

            }
        }
    }

    void Update()
    {
        CheckInteractionInput();

    }

    public virtual void Interact()
    {
        if (!CanInteract)
            return;

        PlayerEnt.enabled = false;
        Using = true;
        ActionButton.interactable = false;
    }

    public virtual void ExitAction()
    {
        Using = false;
        PlayerEnt.enabled = true;
        ActionButton.interactable = true;
    }

    public virtual void ExitArea()
    {
        ActionButton.gameObject.GetComponent<Image>().sprite = BaseUseSprite;
        Using = false;
        ActionButton.interactable = false;
        InArea = false;
        ActionButton.onClick.RemoveAllListeners();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!CanInteract)
                return;

            ActionButton.onClick.AddListener((UnityEngine.Events.UnityAction)this.Interact);
            if (CustomActionSprite)
            {
                ActionButton.gameObject.GetComponent<Image>().sprite = CustomActionSprite;
            }
            ActionButton.interactable = true;
            InArea = true;


        }
    }

    public void SetCanInteract(bool value)
    {
        CanInteract = value;
        if (InArea && !value)
        {
            ExitArea();
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            ExitArea();

        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    public GameObject curInteractGameObject;
    private IInteractable curInteractable;

    public TextMeshProUGUI promptText;
    private Camera _camera;

    private Safe currentSafe;
    public InputField passwordInput;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    SetPromptText();
                }
            }
            else
            {
                curInteractGameObject = null;
                curInteractable = null;
                promptText.gameObject.SetActive(false);
            }
        }
    }
    private void SetPromptText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = curInteractable.GetInteractPrompt();
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curInteractable != null)
        {
            curInteractable.OnInteract();
            curInteractGameObject = null;
            curInteractable = null;
            promptText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Escape"))
        {
            currentSafe = other.GetComponent<Safe>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Escape"))
        {
            currentSafe = null;
        }
    }
}

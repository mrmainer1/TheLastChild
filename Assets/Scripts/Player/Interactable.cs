using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Переписать
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out IInteract interact))
        {
            Debug.Log("O");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("1");
                interact.Interacte(GetComponent<Player>());
            }
        }
    }
}

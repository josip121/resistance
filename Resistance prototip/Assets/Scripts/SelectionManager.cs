using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
   // [SerializeField] private Material highlightMaterial;
    [SerializeField] private string selectableTag = "Selectable";
    //[SerializeField] private Material defaultMaterial;

    private Transform _selection;
    public GameObject cameraPicture;
    public GameObject player;
    public PlayerController playercontroler;

    

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playercontroler.interactPressed)
            {
                playercontroler.interactPressed = false;
                cameraPicture.SetActive(false);
                player.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                if (_selection != null)
                {
                    var selectionRenderer = _selection.GetComponent<Renderer>();
                    cameraPicture.SetActive(false);
                    _selection = null;

                }

                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    var selection = hit.transform;
                    if (selection.CompareTag(selectableTag))
                    {
                        var selectionRenderer = selection.GetComponent<Renderer>();
                        if (selectionRenderer != null)
                        {
                            Debug.Log("Hit !!!!!!!!!!!!!!!!!!!!");
                            cameraPicture.SetActive(true);
                            player.SetActive(false);
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            playercontroler.interactPressed = true;
                        }
                        _selection = selection;
                    }
                }
            }
        }
       
    }
}

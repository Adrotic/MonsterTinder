using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private List<GameObject> buttons;

    public InputActionAsset controls;
    public List<string> scenes;

    public int crSelection;
    public List<Sprite> sprites;

    // Start is called before the first frame update
    void Start()
    {
        buttons = new List<GameObject>();
        CreateButtons();
        crSelection = 0;
        buttons[crSelection].GetComponent<SpriteRenderer>().color = Color.red;
        SetupKeybinds();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateButtons()
    {
        for (int i = 0; i < 4; i++)
        {
            buttons.Add(new GameObject($"MenuButton {i+1}"));
            buttons[i].transform.parent = transform;
            buttons[i].AddComponent<SpriteRenderer>();
            buttons[i].GetComponent<SpriteRenderer>().sprite = sprites[i];
            buttons[i].transform.position = new Vector3(0, 1f +(i*-1.7f), -5);
        }  
    }
    private void SetupKeybinds()
    {
        controls["SelectionDown"].started += SelectionDown;
        controls["SelectionUp"].started += SelectionUp;
        controls["Select"].started += Select;
    }
    private void SelectionDown(InputAction.CallbackContext context)
    {
        buttons[crSelection].GetComponent<SpriteRenderer>().color = Color.white;
        crSelection++;
        if (crSelection > buttons.Count - 1) crSelection = 0;
        buttons[crSelection].GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void SelectionUp(InputAction.CallbackContext context)
    {
        buttons[crSelection].GetComponent<SpriteRenderer>().color = Color.white;
        crSelection--;
        if (crSelection < 0) crSelection = buttons.Count - 1;
        buttons[crSelection].GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void Select(InputAction.CallbackContext context)
    {
        if (scenes[crSelection] != "") {
            SceneManager.LoadScene(scenes[crSelection]);
        }
    }
}
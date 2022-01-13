using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField] private RectTransform pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }
    }

    public void OpenPanel(RectTransform panel)
    {
        panel.gameObject.SetActive(true);
    }

    public void ClosePanel(RectTransform panel)
    {
        panel.gameObject.SetActive(true);
    }

    public void Resume()
    {
        pausePanel.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Pause()
    {
        pausePanel.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}

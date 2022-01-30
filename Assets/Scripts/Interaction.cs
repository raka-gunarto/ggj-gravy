using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class Interaction : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    private Station _station;

    void Start()
    {
        _station = GetComponent<Station>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(interactKey))
            interactAction.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            if (_station)
            {
                var speechBubble = collision.gameObject.transform.Find("Speech Bubble");
                speechBubble.gameObject.SetActive(true);
                speechBubble.Find("Text").GetComponent<TextMeshPro>().text = _station.task.Name;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            if (_station)
            {
                var speechBubble = collision.gameObject.transform.Find("Speech Bubble");
                speechBubble.gameObject.SetActive(false);
            }
        }
    }
}

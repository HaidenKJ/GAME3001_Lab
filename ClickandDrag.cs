using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClickandDrag : MonoBehaviour
{
    //Need to track if we are clicking on the spaceship

    private Vector2 offset; //
    private Rigidbody2D currentlyDraggedObject;
    private bool isDragging;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Raycast to detect mouse click location based on screen click location
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            //if we click on something that has a collider
            if (hit.collider != null)
            {
                //Check if clicked gameObject has rigidbody2D
                Rigidbody2D rb2d = hit.collider.GetComponent<Rigidbody2D>();
                if (rb2d != null)
                {
                    //Start dragging only if no object is currently being dragged
                    //Make sure we are only dragging around what we want 
                    isDragging = true;
                    currentlyDraggedObject = rb2d;

                    //The gap between where the mouse is and the actual location of the clicked object
                    offset = rb2d.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            currentlyDraggedObject = null;
            isDragging = false;
        }

        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentlyDraggedObject.MovePosition(mousePosition + offset);
        }


    }
}

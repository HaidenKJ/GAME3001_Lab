using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentObject : MonoBehaviour
{
    //by default this is made a private field, and cannot be assecced by other scripts under normal circumstances
    //By adding our own modifier we change the accessibility level for other scripts
    [SerializeField] protected Transform m_target;
    public Vector3 targetPosition
    {
        get { return m_target.position; }
        set { m_target.position = value; }
    }



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Agent...");
        targetPosition = m_target.position;
    }


}

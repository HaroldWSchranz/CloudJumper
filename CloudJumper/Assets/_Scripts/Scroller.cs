using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float scrollingSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * scrollingSpeed * Time.deltaTime; //time.deltatime smooths movement per frame
    }
}

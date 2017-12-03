using UnityEngine;

public class AudioScript : MonoBehaviour {

    private bool open = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (open)
                gameObject.GetComponent<AudioSource>().enabled = false;
            else
                gameObject.GetComponent<AudioSource>().enabled = true;

            open = !open;
        }
    }
}

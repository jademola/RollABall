using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) {
            inputVector += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector += Vector2.right;
        }
        if(Input.GetKeyDown(KeyCode.Space) && GetComponent<Rigidbody>().transform.position.y < 0.6f) {
            Vector3 jumpVector = new Vector3(0, 5f, 0);
            GetComponent<Rigidbody>().AddForce(jumpVector, ForceMode.Impulse);
        }

        OnMove?.Invoke(inputVector);
    }
}

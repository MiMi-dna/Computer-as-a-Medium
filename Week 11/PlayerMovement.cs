using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedX = 0f;
    private float speedY = 0f;
    public Rigidbody2D rb; //need to declare the specific component to modify or play with that component, since this modifies mvmnt, need access to the rigidboy of the game object
// Start is called once before the first execution of Update after the MonoBehaviour is created

void Start(){

}
// Update is called once per frame
void Update(){
        Movement();
}

void Movement(){
    // Horizontal Movement
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed){
            speedX = -moveSpeed;
        }

        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed){
            speedX = moveSpeed;
        }

        else{
            speedX = 0;
        }

        // Vertical Movement
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed){
            speedY = moveSpeed;
        }

        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            speedY = -moveSpeed;
        }

        else{
            speedY = 0;
        }
        rb.linearVelocity = new Vector2(speedX, speedY);
    }
}




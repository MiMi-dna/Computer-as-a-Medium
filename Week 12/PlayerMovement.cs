using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedX = 0f;
    private float speedY = 0f;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Transform weaponPivot;
    public GameObject firePoint;
    public Knockback knockback;

    public Sprite beartop;
    public Sprite beardown;
    public Sprite bearleft;
    public Sprite bearright;

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // Horizontal Movement
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            speedX = -moveSpeed;
            swordOrientation(bearleft, 90f);
            fireOrientation(firePoint, 0f);
        }
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            speedX = moveSpeed;
            swordOrientation(bearright, 0f);
            fireOrientation(firePoint, -90f);
        }
        else
        {
            speedX = 0;
        }

        // Vertical Movement
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            speedY = moveSpeed;
            spriteRenderer.sprite = beartop;
            swordOrientation(beartop, 90f);//good
            fireOrientation(firePoint, 270f);
        }
        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            speedY = -moveSpeed;
            spriteRenderer.sprite = beardown;
            swordOrientation(beardown, 0f);
            fireOrientation(firePoint, 180f);
        }
        else
        {
            speedY = 0;
        }

        // don't overwrite the knockback push while it's happening
        if (knockback == null || !knockback.isKnockedBack)
        {
            rb.linearVelocity = new Vector2(speedX, speedY);
        }
    }

    //manages the orientation of the sword based on the player's sprite and the angle of the sword
    void swordOrientation(Sprite playerSprite, float angle)
    {
        spriteRenderer.sprite = playerSprite;

        if (weaponPivot != null)
        {
            bool flipX = spriteRenderer.flipX;
            weaponPivot.localRotation = flipX ? Quaternion.Euler(0f, 180f, -angle) : Quaternion.Euler(0f, 0f, angle);
        }
    }

    //manages the orientation of the fire point based on the player's sprite and the angle of the fire point
    //"up" in bullet script is the direction of the bullet, so we need to rotate the fire point to match the player's sprite and the angle of the fire point (down) which is 180 degrees from the player's sprite
    void fireOrientation(GameObject firePoint, float angle)
    {
        bool flipX = spriteRenderer.flipX;
        firePoint.transform.localRotation = flipX ? Quaternion.Euler(0f, 180f, -angle) : Quaternion.Euler(0f, 0f, angle);

        bool flipY = spriteRenderer.flipY;
        firePoint.transform.localRotation = flipY ? Quaternion.Euler(0f, 180f, -angle) : Quaternion.Euler(0f, 0f, angle);
    }
}
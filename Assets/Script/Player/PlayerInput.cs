using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerControl PlayerControl;
    private float horizontal;
    private float vertical;
    private bool crouch;

    public float Horizontal()
    {
        return horizontal;
    }
    public float Vertical()
    {
        return vertical;
    }
    public bool Crouch()
    {
        return crouch;
    }
    public void Readinput()
    {
         horizontal = Input.GetAxisRaw("Horizontal");
       vertical = Input.GetAxisRaw("Jump");
       crouch = Input.GetKey(KeyCode.LeftControl);
    }
}

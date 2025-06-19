using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerControl PlayerControl;
    private float horizontal;
    private float vertical;
    private bool crouch;
    private bool attack;
   
    int RightButtonClick =1 ;
    public float Horizontal()=>horizontal;
    public float Vertical() => vertical;
    public bool Crouch() => crouch;
    public bool Attack() => attack;
   
    public void Readinput()
    {
       horizontal = Input.GetAxisRaw("Horizontal");
       vertical = Input.GetAxisRaw("Jump");
       crouch = Input.GetKey(KeyCode.LeftControl);
       attack = Input.GetMouseButtonUp(RightButtonClick);
        
      
    }
}

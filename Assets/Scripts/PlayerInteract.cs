using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float distance = 2f;
    private Camera cam;
    private PlayerUI playerUI;
    //private InputSystem_Actions actions;
    //private LayerMask mask;
    
    
    void Start()
    {
        cam = Camera.main;
        playerUI = GetComponent<PlayerUI>();
        //actions = GetComponent<InputSystem_Actions>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin,ray.direction * distance);

        RaycastHit hitinfo;


        if (Physics.Raycast(ray, out hitinfo, distance))
        {
            if (hitinfo.collider.GetComponent<Interactable>() != null) 
            {
                playerUI.UpdateText(hitinfo.collider.GetComponent<Interactable>().promptMessage);
                
            }//if

        }//if



    }// update()

   





}//end

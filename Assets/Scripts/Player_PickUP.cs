using UnityEngine;
using UnityEngine.UI;

public class Player_PickUP : MonoBehaviour
{
    public bool canPickUp;
    public GameObject Pickup_Box;
    public GameObject items;
    public int itemsNum; // 替换为图片
    public Text itemsText;
    public Image image;

    public Transform flashlightSlot; 
    public GameObject flashlight;
    private bool isHoldingFlashlight = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        canPick();
    }

    void canPick()
    {
        if(canPickUp == true)
        {
            Pickup_Box.SetActive(true);
        }
        else
        {
            Pickup_Box.SetActive(false);
        }

        if(canPickUp == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                canPickUp = false;
                print("PICK UP");
                if (items != null && items.CompareTag("items1"))
                {
                    
                    Destroy(items);
                    itemsNum += 1;
                    image.gameObject.SetActive(true);
                    //itemsText.text = " ITEM O: " + itemsNum;
                }

                if (items != null && items.CompareTag("flashlight") && !isHoldingFlashlight)
                {
                    TryPickupFlashlight();
                }


            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "items1" || other.tag == "flashlight")
        {
            items = other.gameObject;
            canPickUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "items1"|| other.tag == "flashlight")
        {
            items = null;
            canPickUp = false;
        }
    }

    void TryPickupFlashlight()
    {
        if (flashlight != null)
        {
            // 让手电筒成为角色手电筒插槽的子对象
            flashlight.transform.SetParent(flashlightSlot);

            // 位置和旋转对齐插槽
            flashlight.transform.localPosition = Vector3.zero;
            flashlight.transform.localRotation = Quaternion.identity;

            // 禁用物理效果，使其不会掉落
            Rigidbody rb = flashlight.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }

            isHoldingFlashlight = true;
        }
    }

}

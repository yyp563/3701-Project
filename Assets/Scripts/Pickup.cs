using UnityEngine;

public class Pickup : Interactable
{
    [SerializeField] private GameObject flashLight; // 需要在Inspector中手动拖入手电筒对象

    private bool isPickedUp = false;

    private void Start()
    {
        if (flashLight != null)
        {
            flashLight.SetActive(false); // 初始时手电筒隐藏
        }
    }

    protected override void Interact()
    {
        if (!isPickedUp)
        {
            Debug.Log("Picked up: " + gameObject.name);
            isPickedUp = true;

            if (flashLight != null)
            {
                flashLight.SetActive(true); // 拾取后启用手电筒
            }

            Destroy(gameObject); // 拾取后销毁 Pickup 物品
        }
    }
}

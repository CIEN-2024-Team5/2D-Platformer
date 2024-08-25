using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    // ȹ���� ������ ���
    private List<Item> pickedUpItems = new List<Item>();

    // UI �гο� ǥ���� �θ� ������Ʈ�� UI ������
    public GameObject inventoryPanel;
    public GameObject itemUIPrefab;

    private void Awake()
    {
        // Singleton ������ ����Ͽ� �ν��Ͻ��� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �������� �߰��ϰ� UI�� ǥ��
    public void AddItem(Item item)
    {
        if (!pickedUpItems.Contains(item))
        {
            pickedUpItems.Add(item);
            UpdateInventoryUI(item);
        }
    }

    // ȹ���� �������� UI�� ǥ��
    private void UpdateInventoryUI(Item item)
    {
        GameObject newItemUI = Instantiate(itemUIPrefab, inventoryPanel.transform);
        Image itemImage = newItemUI.GetComponent<Image>();
        Text itemDescription = newItemUI.GetComponentInChildren<Text>();

        // �������� ��������Ʈ�� ������ UI�� �ݿ�
        itemImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
        itemDescription.text = item.descriptionText;
    }

    // ���� �ε�� �� ������ ȹ���� �������� �ٽ� ǥ��
    private void Start()
    {
        foreach (var item in pickedUpItems)
        {
            UpdateInventoryUI(item);
        }
    }
}


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIManager : MonoBehaviour
{
    public Image[] itemIcons;  // ������ ������ ���� �迭
    private Dictionary<string, Image> itemIconMap = new Dictionary<string, Image>();

    // �Ͻ����� ȭ�� UI ��ҵ�
    [System.Serializable]
    public class PauseMenuItem
    {
        public string itemID;
        public GameObject iconObject;   // ������ ������Ʈ
        public Text descriptionText;    // ���� �ؽ�Ʈ
    }
    public PauseMenuItem[] pauseMenuItems;

    private string[] scenesToShow = { "Stage1-1", "Stage1-2", "Stage1-3", "Stage2-1", "Stage2-2", "Stage2-3", "Stage3-1", "Stage3-2", "Stage3-3" };

    void Start()
    {
        // �������� �ʱ�ȭ�ϰ� ������ ���¸� üũ�մϴ�.
        InitializeIcons();
        CheckSceneAndUpdateIcons();
        InitializePauseMenuItems();
    }

    void InitializeIcons()
    {
        // ������ ������ ID�� �����մϴ�.
        itemIconMap.Add("BulsonShotRedItem", itemIcons[0]);
        itemIconMap.Add("DoubleJumpItem", itemIcons[1]);
        itemIconMap.Add("BulsonShotBlueItem", itemIcons[2]);

        // PlayerPrefs�� ����Ͽ� �̹� ȹ��� �������� �������� Ȱ��ȭ�մϴ�.
        foreach (var itemID in itemIconMap.Keys)
        {
            if (PlayerPrefs.GetInt(itemID, 0) == 1)
            {
                itemIconMap[itemID].gameObject.SetActive(true);
            }
        }
    }

    void InitializePauseMenuItems()
    {
        foreach (var item in pauseMenuItems)
        {
            if (PlayerPrefs.GetInt(item.itemID, 0) == 1)
            {
                item.iconObject.SetActive(true);
                item.descriptionText.gameObject.SetActive(true);
            }
            else
            {
                item.iconObject.SetActive(false);
                item.descriptionText.gameObject.SetActive(false);
            }
        }
    }

    void CheckSceneAndUpdateIcons()
    {
        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (System.Array.Exists(scenesToShow, scene => scene == currentScene))
        {
            // �ش� ���̶�� �������� �����ݴϴ�.
            foreach (var icon in itemIcons)
            {
                if (icon.gameObject.activeSelf)
                    icon.gameObject.SetActive(true);
            }
        }
        else
        {
            // �ش� ���� �ƴ϶�� �������� ����ϴ�.
            foreach (var icon in itemIcons)
            {
                icon.gameObject.SetActive(false);
            }
        }
    }

    public void AddItemIcon(string itemID)
    {
        if (itemIconMap.ContainsKey(itemID))
        {
            itemIconMap[itemID].gameObject.SetActive(true);
        }

        // �Ͻ����� ȭ�鿡���� �ش� �������� �����ܰ� ������ Ȱ��ȭ
        foreach (var item in pauseMenuItems)
        {
            if (item.itemID == itemID)
            {
                item.iconObject.SetActive(true);
                item.descriptionText.gameObject.SetActive(true);
            }
        }
    }

    private void OnEnable()
    {
        // ���� ����� ������ ������ ���¸� ������Ʈ
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // ���� ����� ������ ������ ���¸� ������Ʈ
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        CheckSceneAndUpdateIcons();
    }
}

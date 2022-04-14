using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("[ top menu ]")]
    public InputField generateInput;
    public Button generateBtn;
    public event Action OnGenerateItem;
    [Space]
    public InputField searchInput;
    public Button searchBtn;
    public event Action OnSearchItem;
    [Space]
    public Dropdown sortDropDown;
    public event Action<int> OnSortItem;
    [SerializeField] string[] optionDataArr;
    [Header("[ bottom menu ]")]
    public Image itemImageShow;
    public Text itemNameShow;
    public Text itemPropertiesShow;

    private void Start()
    {
        generateInput.onEndEdit.AddListener(EndEditGenerateInput);
        generateBtn.onClick.AddListener(ClickGenerate);
        searchBtn.onClick.AddListener(ClickSearch);
        InitSortDropdown();
    }

    private void InitSortDropdown()
    {
        sortDropDown.ClearOptions();
        List<string> optionDatas = new List<string>();
        for (int i = 0; i < optionDataArr.Length; i++)
        {
            optionDatas.Add(optionDataArr[i]);
        }

        sortDropDown.AddOptions(optionDatas);

        sortDropDown.onValueChanged.AddListener(ChangeSortItem);
    }

    private void ChangeSortItem(int arg0)
    {
        OnSortItem?.Invoke(arg0);
    }

    private void EndEditGenerateInput(string arg0)
    {
        if (int.Parse(arg0) > 5000)
        {
            generateInput.text = "5000";
        }
    }

    private void ClickSearch()
    {
        OnSearchItem?.Invoke();
    }

    private void ClickGenerate()
    {
        OnGenerateItem?.Invoke();
    }
}

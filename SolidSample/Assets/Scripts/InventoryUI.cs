using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("[ top menu ]")]
    public Button generateBtn;
    [Space]
    public InputField searchInput;
    public Button searchBtn;
    [Header("[ bottom menu ]")]
    public Image ItemImageShow;
    public Text ItemNameShow;
    public Text ItemPropertiesShow;

}

using UnityEngine;
using UnityEngine.UI; // Import the UnityEngine.UI namespace for Button
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    // [SerializeField] // Serialize the field to make it visible in the Unity Editor
    [SerializeField] private RawImage buttonImage; 

    private Button btn;

    private int _itemId;
    private Sprite _buttonTexture;
    public Sprite ButtonTexture
    {
        set
        {
            _buttonTexture = value;
            buttonImage.texture = _buttonTexture.texture;
        }
    } 

    public int ItemId
    {
        set {_itemId = value;}
    }

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the GameObject this script is attached to has a Button component
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObject); // Register the method with onClick
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic if needed
        if(UIManager.Instance.OnEntered(gameObject))
        {
            transform.DOScale(Vector3.one*2, 0.3f);
            // transform.localScale = Vector3.one*2;
        }
        else
        {
            transform.DOScale(Vector3.one, 0.3f);
            // transform.localScale = Vector3.one;
        }
    }

    void SelectObject()
    {
        // Access the furniture through the public or serialized field
        DataHandler.Instance.SetFurniture(_itemId);
    }
}

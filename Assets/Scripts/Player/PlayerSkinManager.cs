using UnityEngine;

public class PlayerSkinManager : MonoBehaviour {
    public static PlayerSkinManager instance;

    [SerializeField] SpriteRenderer helmetSprite;
    [SerializeField] SpriteRenderer pickaxeSprite;
    [SerializeField] SpriteRenderer beardSprite;
    [SerializeField] SpriteRenderer pantsSprite;
    [SerializeField] SpriteRenderer faceSprite;
    [SerializeField] SpriteRenderer[] armSprite;

    void Awake() {
        if(!instance) instance = this;
        else Destroy(gameObject);
    }

    public void ChangePlayerSkin(EquipmentType equipementType, Sprite craftVisual) {
        switch (equipementType)
        {
            case EquipmentType.HELMET:
                helmetSprite.sprite = craftVisual;
                break;
            case EquipmentType.PICKAXE:
                pickaxeSprite.sprite = craftVisual;
                break;
            case EquipmentType.BEARD:
                beardSprite.sprite = craftVisual;
                break;
            case EquipmentType.PANTS:
                pantsSprite.sprite = craftVisual;
                break;
            case EquipmentType.FACE:
                faceSprite.sprite = craftVisual;
                break;
            case EquipmentType.ARM:
                foreach (SpriteRenderer item in armSprite) {
                    item.sprite = craftVisual;
                }
                break;

            default:
                break;
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WeaponClassManager : MonoBehaviour
{
    [SerializeField] TwoBoneIKConstraint leftHandIK;
    public Transform recoilFollowPos;
    ActionStateManager actions;

    public WeaponMananger[] weapons;
    int currentWeaponIndex;

    [SerializeField] TMP_Text ammoUIText;  // Referencia para la UI de munición


    private void Awake()
    {
        currentWeaponIndex = 0;
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == 0) weapons[i].gameObject.SetActive(true);
            else weapons[i].gameObject.SetActive(false);
        }
    }

    public void SetCurrentWeapon(WeaponMananger weapon)
    {
        if (actions == null) actions = GetComponent<ActionStateManager>();
        leftHandIK.data.target = weapon.leftHandTarget;
        leftHandIK.data.hint = weapon.leftHandHint;
        actions.SetWeapon(weapon);

        // Actualizar la UI de munición al cambiar de arma
        weapon.ammo.SetAmmoUIText(ammoUIText);  // Actualiza la UI con la munición del arma activa
    }

    public void ChangeWeapon(float direction)
    {
        weapons[currentWeaponIndex].gameObject.SetActive(false);
        if (direction < 0)
        {
            if (currentWeaponIndex == 0) currentWeaponIndex = weapons.Length - 1;
            else currentWeaponIndex--;
        }
        else
        {
            if (currentWeaponIndex == weapons.Length - 1) currentWeaponIndex = 0;
            else currentWeaponIndex++;
        }
        weapons[currentWeaponIndex].gameObject.SetActive(true);
        SetCurrentWeapon(weapons[currentWeaponIndex]);
    }

    public void WeaponPutAway()
    {
        ChangeWeapon(actions.Default.scrollDirection);
    }

    public void WeaponPulledOut()
    {
        actions.SwitchState(actions.Default);
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponControl : MonoBehaviour
{
    private ShootingScripts shootingScripts;
    private bool m_enable = true;

    private void Awake()
    {
        shootingScripts = GetComponentInChildren<ShootingScripts>();
    }

    public void Shooting(InputAction.CallbackContext callbackContext)
    {
        if (m_enable)
        {
            if (callbackContext.phase == InputActionPhase.Started)
            {
                shootingScripts = GetComponentInChildren<ShootingScripts>();
                shootingScripts.CheckAuto();
            }
            else if (callbackContext.phase == InputActionPhase.Performed)
            {
                shootingScripts = GetComponentInChildren<ShootingScripts>();
                shootingScripts.CheckAuto();
                shootingScripts.Fire = true;
            }
            else if (callbackContext.phase == InputActionPhase.Canceled)
            {
                shootingScripts.Fire = false;
            }
        }
    }

    public void Reloading(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            shootingScripts = GetComponentInChildren<ShootingScripts>();
            shootingScripts.Reloading();
        }
    }

    public void ToggleEnable()
    {
        m_enable = !m_enable;
    }

}

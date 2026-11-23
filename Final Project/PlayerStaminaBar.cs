using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.UI
{
    public class PlayerStaminaBar : MonoBehaviour
    {
        [Tooltip("Image component representing augment stamina")]
        public Image StaminaFillImage;

        [Tooltip("Component to animate the color when empty or full")]
        public FillBarColorChange FillBarColorChange;

        AugmentStamina m_sprintAugment;

        void Awake()
        {
            m_sprintAugment = FindAnyObjectByType<AugmentStamina>();
            DebugUtility.HandleErrorIfNullFindObject<AugmentStamina, PlayerStaminaBar>(m_sprintAugment, this);

            // FillBarColorChange.Initialize(1f, 0f);
        }

        void Update()
        {
                StaminaFillImage.fillAmount = m_sprintAugment.CurrentAugmentFillRatio;
                // FillBarColorChange.UpdateVisual(m_sprintAugment.CurrentAugmentFillRatio);
        }
    }
}
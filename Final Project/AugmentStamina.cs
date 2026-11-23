using Unity.FPS.Game;
using UnityEngine;


namespace Unity.FPS.Gameplay //namespace is a wrapper - In Unity, script namespaces are used to logically organize scripts and prevent class name conflicts. They help keep custom code separate from Unity’s core classes and third-party assets. 
{

    [RequireComponent(typeof(PlayerCharacterController))]
    [RequireComponent(typeof(PlayerInputHandler))]
    [RequireComponent(typeof(AudioSource))] //need to find audio component for augmented run sound

    public class AugmentStamina : MonoBehaviour
    {
        [Header("References")] [Tooltip("Audio source for augment sfx")]
        public AudioSource AudioSource;

        //particle effect like dash lines?
        //[Tooltip("Particles for augmented sprint vfx")] public ParticleSystem[] AugmentVfx;

        [Header("Durations")] [Tooltip("Time it takes to consume all augment stamina")]
        public float ConsumeStaminaDuration = 1.5f;
        
        [Tooltip("Time it takes to completely refill stamina gauge")]
        public float RefillStaminaGauge = 2f;

        [Tooltip("Delay after last use before starting to refill stamina")]
        public float RefillStaminaDelay = 1f;

        [Tooltip("Displays the minimum amount of stamina")]
        public float minStamina = 0f;

        [Tooltip("Displays the maximum amount of stamina")]
        public float maxStamina = 1f;

        [Header("Audio")] [Tooltip("Sound played when using the augment")]
        public AudioClip SprintAugmentSFX;

        bool m_CanUseAugment = false;
        bool m_augmentIsInUse = false;
        PlayerCharacterController m_PlayerCharacterController;
        PlayerInputHandler m_InputHandler;
        float m_LastTimeOfUse;

        //stamina resource management
        public float CurrentAugmentFillRatio { get; private set; } = 1f; //represents "current stamina"
        // public float refillRate = 1;
        public bool IsPlayerGrounded() => m_PlayerCharacterController.IsGrounded;

        void Start()
        {

            m_PlayerCharacterController = GetComponent<PlayerCharacterController>();
            DebugUtility.HandleErrorIfNullGetComponent<PlayerCharacterController, AugmentStamina>(m_PlayerCharacterController, this, gameObject);

            m_InputHandler = GetComponent<PlayerInputHandler>(); DebugUtility.HandleErrorIfNullGetComponent<PlayerInputHandler, AugmentStamina>(m_InputHandler, this, gameObject);

            CurrentAugmentFillRatio = 1f;

            AudioSource.clip = SprintAugmentSFX;
            AudioSource.loop = true;
        }

        void Update()
        {
            //verify if player can use grounded & current stamina > 0
            if (IsPlayerGrounded() && (CurrentAugmentFillRatio > minStamina)){
                m_CanUseAugment = true;
            }

            //apply augment usage
            m_augmentIsInUse = m_CanUseAugment && CurrentAugmentFillRatio > minStamina && m_InputHandler.GetSprintInputHeld();
            
            if (m_augmentIsInUse)
            {
                //handle refill delay
                m_LastTimeOfUse = Time.time;
                m_PlayerCharacterController.IsSpeedAugmentActive = m_augmentIsInUse;

                //consume stamina
                CurrentAugmentFillRatio -= Time.deltaTime / ConsumeStaminaDuration; //short hand for CurrentAugmentFillRatio = CurrentAugmentFillRatio - (Time.deltaTime / ConsumerDuration);
                //keeps ratio consistent (between 0 and 1) and pevents negative output
                CurrentAugmentFillRatio = Mathf.Clamp01(CurrentAugmentFillRatio);

                if(CurrentAugmentFillRatio <= minStamina || !IsPlayerGrounded() || !m_InputHandler.GetSprintInputHeld())
                {
                    CurrentAugmentFillRatio = minStamina;
                    m_PlayerCharacterController.IsSpeedAugmentActive = false;
                    m_CanUseAugment = false;
                    m_augmentIsInUse = false;
                }

                //apply VFX for use duration
                // for (int i = 0; i < AugmentVfx.Length; i++) 
                // {
                //     var emissionModulesVfx = AugmentVfx[i].emission;
                //     emissionModulesVfx.enabled = true;
                // }

                // //apply SFX for use duration
                // if (!AudioSource.isPlaying)
                //     AudioSource.Play();
            }
            else
            {
                // refill stamina guage over time
                if (Time.time - m_LastTimeOfUse >= RefillStaminaDelay)
                {
                    // refillRate /= RefillStaminaGauge; //shorthand for refillRate = refillRate / RefillStaminaGauge
                    float refillRate = 1f / RefillStaminaGauge;
                    CurrentAugmentFillRatio += Time.deltaTime * refillRate;

                    //keeps ratio consistent (between 0 and 1)
                    CurrentAugmentFillRatio = Mathf.Clamp01(CurrentAugmentFillRatio);

                    if(CurrentAugmentFillRatio >= maxStamina)
                    {
                        CurrentAugmentFillRatio = maxStamina;
                    }
                }
                // //verifies audio source stops playing
                // if (AudioSource.isPlaying)
                //     AudioSource.Stop();
            }

        // //verifies usage state at end of frame
        m_PlayerCharacterController.IsSpeedAugmentActive = m_augmentIsInUse;

        } //end of update
    }//end of class
}//end of name space

//design reasoning
                //apply velocity increase to character's speed modifier - 
                // note, the Character Controller manages the speed multiplier (rate of velocity) and this script manages usage/stamina 
                // consumption. Chose to do it this way in the even the game were to manage more than one type of player character
using UnityEngine;



    public class SimpleKeyboard : MonoBehaviour
    {
    //------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------
    private GamePlayManager m_GamePlay;
    private AnimationController m_AnimationController;

    [Header("Steering Settings")]
        public float m_Speed = 4.0f;

    public void Start()
    {
        m_GamePlay = FindObjectOfType<GamePlayManager>();
        m_AnimationController = GetComponent<AnimationController>();
    }

    private void Update()
    {

        if (!m_GamePlay.AllowedToMove)
            return;

        Vector3 velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * m_Speed;
        transform.position += velocity * Time.deltaTime;
        m_AnimationController.SetAnimation(velocity);

        Debug.DrawRay(transform.position, velocity, Color.red);
    }

    //------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------

    }

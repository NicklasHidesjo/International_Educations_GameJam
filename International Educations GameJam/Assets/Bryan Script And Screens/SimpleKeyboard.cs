using UnityEngine;



    public class SimpleKeyboard : MonoBehaviour
    {
    //------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------


    [Header("Steering Settings")]
        public float m_Speed = 4.0f;

        private void Update()
        {
            Vector3 velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * m_Speed;
            transform.position += velocity * Time.deltaTime;
            
            Debug.DrawRay(transform.position, velocity, Color.red);
        }

    //------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------

    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour
{
	[System.Serializable]
	public class MouseInput {
		public Vector2 Damping;
		public Vector2 Sensitivity;
	}

	[SerializeField]float speed;
	[SerializeField]MouseInput MouseControl;

	private MoveController m_MoveController;
	public MoveController MoveController{
		get{
			if(m_MoveController == null)
				m_MoveController = GetComponent<MoveController>();
			return m_MoveController;
		}
	}

	private Crosshair m_Crosshair;
    private Crosshair Crosshair
    {
        get 
        {
            if(m_Crosshair == null)
                m_Crosshair = GetComponentInChildren<Crosshair>();
            return m_Crosshair;
        }
    }

	InputController playerInput;

	Vector2 mouseInput;
	
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;

    }

    // Update is called once per frame
    void Update()
    {
    	Vector2 direction = new Vector2(playerInput.Vertical * speed, playerInput.Horizontal * speed);
    	MoveController.Move(direction);

		mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
		mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);
		
		transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);
		
		Crosshair.LookHeight(mouseInput.y * MouseControl.Sensitivity.y);

    }
}

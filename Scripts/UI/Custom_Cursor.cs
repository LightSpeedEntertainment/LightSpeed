using UnityEngine;

public class Custom_Cursor : MonoBehaviour {

	public Texture m_Texture;

	public float sizeScale = 0.1f;
	public bool startMenu;

	enum AlignAt { CENTER, MOUSE };
	[SerializeField]AlignAt position = AlignAt.MOUSE;

	private void Start()
	{
		Cursor.visible = false;
	}

	private void OnGUI()
	{
		float cursorSizeX = m_Texture.width * sizeScale;
		float cursorSizeY = m_Texture.height * sizeScale;

		float xPos_AtCenter = Event.current.mousePosition.x - cursorSizeX / 2f;
		float yPos_AtCenter = Event.current.mousePosition.y - cursorSizeX / 2f;

		float xPos_AtMouse = Event.current.mousePosition.x;
		float yPos_AtMouse = Event.current.mousePosition.y;

		if (position == AlignAt.CENTER)
			GUI.DrawTexture(new Rect(xPos_AtCenter, yPos_AtCenter, cursorSizeX, cursorSizeY), m_Texture);

		if (position == AlignAt.MOUSE)
			GUI.DrawTexture(new Rect(xPos_AtMouse, yPos_AtMouse, cursorSizeX, cursorSizeY), m_Texture);
	}
}
using UnityEngine;

public class SubMenuLoader : MonoBehaviour {

	public SubMenu[] subMenus;

	public SubMenu previousSubMenu;
	public SubMenu currentSubMenu;

	private void Start()
	{
		subMenus = FindObjectsOfType<SubMenu>();

		foreach (SubMenu sM in subMenus)
			sM.active = false;
	}

	private void Update()
	{
		if (previousSubMenu != null)
			previousSubMenu.active = false;
	}

	public void UpdateMenus(SubMenu _new)
	{
		if (currentSubMenu != null)
		{
			previousSubMenu = currentSubMenu;
			currentSubMenu = _new;
		}

		if (previousSubMenu == _new)
		{
			previousSubMenu = null;
			currentSubMenu = _new;
		}
		
		currentSubMenu = _new;
		currentSubMenu.active = true;
	}

	public void DisableAll()
	{
		if (currentSubMenu != null)
		{
			currentSubMenu.active = false;
		}
	}
}
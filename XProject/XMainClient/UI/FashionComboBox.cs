using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FashionComboBox
	{

		public FashionComboBox(GameObject go, ComboboxClickEventHandler handler, int PerRow = 2)
		{
			this._handler = handler;
			this.itemPerRow = PerRow;
			this.selector = (go.transform.FindChild("Difficulty").GetComponent("XUISprite") as IXUISprite);
			this.close = (go.transform.FindChild("Difficulty/DropList/Close").GetComponent("XUISprite") as IXUISprite);
			this.selecttext = (go.transform.FindChild("Difficulty/SelectedText").GetComponent("XUILabel") as IXUILabel);
			this.droplist = go.transform.FindChild("Difficulty/DropList");
			Transform transform = go.transform.FindChild("Difficulty/DropList/ItemTpl");
			this.itempool.SetupPool(this.droplist.gameObject, transform.gameObject, 6U, false);
			this.droplist.gameObject.SetActive(false);
			this.selector.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectorClick));
			this.close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClick));
		}

		private void OnSelectorClick(IXUISprite sp)
		{
			this.droplist.gameObject.SetActive(true);
		}

		private void OnCloseClick(IXUISprite sp)
		{
			this.droplist.gameObject.SetActive(false);
		}

		public void AddItem(string text, int value)
		{
			GameObject gameObject = this.itempool.FetchGameObject(false);
			int num = this.itemcount % this.itemPerRow;
			int num2 = this.itemcount / this.itemPerRow;
			gameObject.transform.localPosition = this.itempool.TplPos + new Vector3((float)(num * this.itempool.TplWidth), (float)(-(float)num2 * this.itempool.TplHeight));
			IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)value);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClick));
			IXUILabel ixuilabel = gameObject.transform.FindChild("ItemText").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(text);
			this.value2string.Add(value, text);
			this.itemcount++;
		}

		private void OnItemClick(IXUISprite sp)
		{
			this.selecttext.SetText(this.value2string[(int)sp.ID]);
			this.droplist.gameObject.SetActive(false);
			this._handler((int)sp.ID);
		}

		public void SetSelect(int value)
		{
			string text;
			bool flag = this.value2string.TryGetValue(value, out text);
			if (flag)
			{
				this.selecttext.SetText(text);
				this.droplist.gameObject.SetActive(false);
				this._handler(value);
			}
		}

		private ComboboxClickEventHandler _handler;

		private IXUISprite selector = null;

		private Transform droplist = null;

		private IXUISprite close = null;

		private IXUILabel selecttext = null;

		private XUIPool itempool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private int itemPerRow = 0;

		private int itemcount = 0;

		private Dictionary<int, string> value2string = new Dictionary<int, string>();
	}
}

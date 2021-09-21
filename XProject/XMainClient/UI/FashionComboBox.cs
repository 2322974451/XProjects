using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001827 RID: 6183
	internal class FashionComboBox
	{
		// Token: 0x060100D7 RID: 65751 RVA: 0x003D3BBC File Offset: 0x003D1DBC
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

		// Token: 0x060100D8 RID: 65752 RVA: 0x003D3D20 File Offset: 0x003D1F20
		private void OnSelectorClick(IXUISprite sp)
		{
			this.droplist.gameObject.SetActive(true);
		}

		// Token: 0x060100D9 RID: 65753 RVA: 0x003D3D35 File Offset: 0x003D1F35
		private void OnCloseClick(IXUISprite sp)
		{
			this.droplist.gameObject.SetActive(false);
		}

		// Token: 0x060100DA RID: 65754 RVA: 0x003D3D4C File Offset: 0x003D1F4C
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

		// Token: 0x060100DB RID: 65755 RVA: 0x003D3E34 File Offset: 0x003D2034
		private void OnItemClick(IXUISprite sp)
		{
			this.selecttext.SetText(this.value2string[(int)sp.ID]);
			this.droplist.gameObject.SetActive(false);
			this._handler((int)sp.ID);
		}

		// Token: 0x060100DC RID: 65756 RVA: 0x003D3E88 File Offset: 0x003D2088
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

		// Token: 0x04007260 RID: 29280
		private ComboboxClickEventHandler _handler;

		// Token: 0x04007261 RID: 29281
		private IXUISprite selector = null;

		// Token: 0x04007262 RID: 29282
		private Transform droplist = null;

		// Token: 0x04007263 RID: 29283
		private IXUISprite close = null;

		// Token: 0x04007264 RID: 29284
		private IXUILabel selecttext = null;

		// Token: 0x04007265 RID: 29285
		private XUIPool itempool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007266 RID: 29286
		private int itemPerRow = 0;

		// Token: 0x04007267 RID: 29287
		private int itemcount = 0;

		// Token: 0x04007268 RID: 29288
		private Dictionary<int, string> value2string = new Dictionary<int, string>();
	}
}

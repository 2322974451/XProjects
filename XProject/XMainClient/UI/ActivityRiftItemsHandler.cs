using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016CC RID: 5836
	internal class ActivityRiftItemsHandler : DlgHandlerBase
	{
		// Token: 0x1700373A RID: 14138
		// (get) Token: 0x0600F0B7 RID: 61623 RVA: 0x0034FE2C File Offset: 0x0034E02C
		protected override string FileName
		{
			get
			{
				return "GameSystem/TeamMysteriousItemList";
			}
		}

		// Token: 0x0600F0B8 RID: 61624 RVA: 0x0034FE44 File Offset: 0x0034E044
		protected override void Init()
		{
			base.Init();
			this.m_btnClose = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_goTpl = base.transform.FindChild("Bg/ScrollView/ItemTpl").gameObject;
			this.m_pos = this.m_goTpl.transform.localPosition;
			GameObject gameObject = base.transform.FindChild("Bg/ScrollView").gameObject;
			this.m_scroll = (gameObject.GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_ItemsPool.SetupPool(gameObject, this.m_goTpl, 8U, false);
		}

		// Token: 0x0600F0B9 RID: 61625 RVA: 0x0034FEF0 File Offset: 0x0034E0F0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
		}

		// Token: 0x0600F0BA RID: 61626 RVA: 0x0034FF12 File Offset: 0x0034E112
		public void ShowItemList(List<uint> list)
		{
			this.m_data = list;
			base.SetVisible(true);
		}

		// Token: 0x0600F0BB RID: 61627 RVA: 0x0034FF24 File Offset: 0x0034E124
		protected override void OnShow()
		{
			base.OnShow();
			this.m_ItemsPool.FakeReturnAll();
			for (int i = 0; i < this.m_data.Count; i++)
			{
				GameObject gameObject = this.m_ItemsPool.FetchGameObject(false);
				this.SetitemInfo(gameObject, this.m_data[i]);
				IXUILabel ixuilabel = gameObject.transform.FindChild("Intro").GetComponent("XUILabel") as IXUILabel;
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this.m_data[i]);
				ixuilabel.SetText(itemConf.ItemDescription);
				gameObject.transform.localPosition = new Vector3(this.m_pos.x, this.m_pos.y - (float)(110 * i), this.m_pos.z);
			}
			this.m_ItemsPool.ActualReturnAll(false);
		}

		// Token: 0x0600F0BC RID: 61628 RVA: 0x00350010 File Offset: 0x0034E210
		private void SetitemInfo(GameObject obj, uint itemID)
		{
			IXUISprite ixuisprite = obj.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)itemID;
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(obj, (int)itemID, 0, false);
		}

		// Token: 0x0600F0BD RID: 61629 RVA: 0x0035005C File Offset: 0x0034E25C
		private bool OnClose(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x040066B0 RID: 26288
		public GameObject m_goTpl;

		// Token: 0x040066B1 RID: 26289
		public IXUIButton m_btnClose;

		// Token: 0x040066B2 RID: 26290
		public IXUIScrollView m_scroll;

		// Token: 0x040066B3 RID: 26291
		public XUIPool m_ItemsPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040066B4 RID: 26292
		private List<uint> m_data;

		// Token: 0x040066B5 RID: 26293
		private Vector3 m_pos;
	}
}

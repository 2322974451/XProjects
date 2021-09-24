using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ActivityRiftItemsHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/TeamMysteriousItemList";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
		}

		public void ShowItemList(List<uint> list)
		{
			this.m_data = list;
			base.SetVisible(true);
		}

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

		private void SetitemInfo(GameObject obj, uint itemID)
		{
			IXUISprite ixuisprite = obj.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)itemID;
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(obj, (int)itemID, 0, false);
		}

		private bool OnClose(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		public GameObject m_goTpl;

		public IXUIButton m_btnClose;

		public IXUIScrollView m_scroll;

		public XUIPool m_ItemsPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private List<uint> m_data;

		private Vector3 m_pos;
	}
}

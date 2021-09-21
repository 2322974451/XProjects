using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C54 RID: 3156
	internal class AncientBox : DlgBase<AncientBox, AnicientBoxBahaviour>
	{
		// Token: 0x17003199 RID: 12697
		// (get) Token: 0x0600B2EF RID: 45807 RVA: 0x0022B644 File Offset: 0x00229844
		public override string fileName
		{
			get
			{
				return "OperatingActivity/AncientBox";
			}
		}

		// Token: 0x1700319A RID: 12698
		// (get) Token: 0x0600B2F0 RID: 45808 RVA: 0x0022B65C File Offset: 0x0022985C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700319B RID: 12699
		// (get) Token: 0x0600B2F1 RID: 45809 RVA: 0x0022B670 File Offset: 0x00229870
		public override bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700319C RID: 12700
		// (get) Token: 0x0600B2F2 RID: 45810 RVA: 0x0022B684 File Offset: 0x00229884
		public override bool pushstack
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700319D RID: 12701
		// (get) Token: 0x0600B2F3 RID: 45811 RVA: 0x0022B698 File Offset: 0x00229898
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B2F4 RID: 45812 RVA: 0x0022B6AB File Offset: 0x002298AB
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_sprRed.SetVisible(false);
		}

		// Token: 0x0600B2F5 RID: 45813 RVA: 0x0022B6C8 File Offset: 0x002298C8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btnClaim.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClick));
			base.uiBehaviour.m_black.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClose));
		}

		// Token: 0x0600B2F6 RID: 45814 RVA: 0x0022B717 File Offset: 0x00229917
		public void Show(AncientTimesTable.RowData r)
		{
			this.row = r;
			this.SetVisible(true, true);
			this.RefreshPoint();
			this.RefreshRwd();
		}

		// Token: 0x0600B2F7 RID: 45815 RVA: 0x0022B738 File Offset: 0x00229938
		private void RefreshPoint()
		{
			base.uiBehaviour.m_title.SetText(this.row.Title);
			base.uiBehaviour.m_point.SetText(XStringDefineProxy.GetString("AncientPoint", new object[]
			{
				this.row.nPoints[1]
			}));
		}

		// Token: 0x0600B2F8 RID: 45816 RVA: 0x0022B79C File Offset: 0x0022999C
		private void RefreshRwd()
		{
			base.uiBehaviour.m_rwdpool.ReturnAll(false);
			int tplWidth = base.uiBehaviour.m_rwdpool.TplWidth;
			int i = 0;
			int count = (int)this.row.Items.count;
			while (i < count)
			{
				GameObject gameObject = base.uiBehaviour.m_rwdpool.FetchGameObject(false);
				XSingleton<UiUtility>.singleton.AddChild(base.uiBehaviour.itemTpl.transform.parent.gameObject, gameObject);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)this.row.Items[i, 0], (int)this.row.Items[i, 1], false);
				Vector3 localPosition = base.uiBehaviour.itemTpl.transform.localPosition;
				localPosition.x = (float)((count % 2 == 0) ? ((int)((float)i - (float)count / 2f) * tplWidth + tplWidth / 2) : ((int)((float)i - (float)(count - 1) / 2f) * tplWidth));
				gameObject.transform.localPosition = localPosition;
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)this.row.Items[i, 0];
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				i++;
			}
		}

		// Token: 0x0600B2F9 RID: 45817 RVA: 0x0022B910 File Offset: 0x00229B10
		private bool OnClick(IXUIButton btn)
		{
			XAncientDocument specificDocument = XDocuments.GetSpecificDocument<XAncientDocument>(XAncientDocument.uuID);
			specificDocument.ReqPoint(this.row.ID);
			return true;
		}

		// Token: 0x0600B2FA RID: 45818 RVA: 0x0022B940 File Offset: 0x00229B40
		private void OnClose(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x04004528 RID: 17704
		private AncientTimesTable.RowData row;
	}
}

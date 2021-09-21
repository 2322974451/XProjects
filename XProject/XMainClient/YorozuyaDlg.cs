using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E94 RID: 3732
	internal class YorozuyaDlg : DlgBase<YorozuyaDlg, YorozuyaBehaviour>
	{
		// Token: 0x170034B2 RID: 13490
		// (get) Token: 0x0600C72D RID: 50989 RVA: 0x002C3148 File Offset: 0x002C1348
		public override string fileName
		{
			get
			{
				return "GameSystem/YorozuyaDlg";
			}
		}

		// Token: 0x170034B3 RID: 13491
		// (get) Token: 0x0600C72E RID: 50990 RVA: 0x002C3160 File Offset: 0x002C1360
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170034B4 RID: 13492
		// (get) Token: 0x0600C72F RID: 50991 RVA: 0x002C3174 File Offset: 0x002C1374
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170034B5 RID: 13493
		// (get) Token: 0x0600C730 RID: 50992 RVA: 0x002C3188 File Offset: 0x002C1388
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170034B6 RID: 13494
		// (get) Token: 0x0600C731 RID: 50993 RVA: 0x002C319C File Offset: 0x002C139C
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170034B7 RID: 13495
		// (get) Token: 0x0600C732 RID: 50994 RVA: 0x002C31B0 File Offset: 0x002C13B0
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C733 RID: 50995 RVA: 0x002C31C3 File Offset: 0x002C13C3
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x170034B8 RID: 13496
		// (get) Token: 0x0600C734 RID: 50996 RVA: 0x002C31D0 File Offset: 0x002C13D0
		public override int sysid
		{
			get
			{
				return 440;
			}
		}

		// Token: 0x0600C735 RID: 50997 RVA: 0x002C31E7 File Offset: 0x002C13E7
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClosedBtn));
		}

		// Token: 0x0600C736 RID: 50998 RVA: 0x002C320E File Offset: 0x002C140E
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600C737 RID: 50999 RVA: 0x002C3218 File Offset: 0x002C1418
		protected override void Init()
		{
			base.Init();
			this.m_doc = XYorozuyaDocument.Doc;
		}

		// Token: 0x0600C738 RID: 51000 RVA: 0x002C322D File Offset: 0x002C142D
		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XInput>.singleton.Freezed = false;
		}

		// Token: 0x0600C739 RID: 51001 RVA: 0x002C3243 File Offset: 0x002C1443
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0600C73A RID: 51002 RVA: 0x002C3254 File Offset: 0x002C1454
		private void FillContent()
		{
			base.uiBehaviour.m_itemPool.ReturnAll(true);
			for (int i = 0; i < this.m_doc.YorozuyaTab.Table.Length; i++)
			{
				YorozuyaTable.RowData rowData = this.m_doc.YorozuyaTab.Table[i];
				bool flag = rowData == null;
				if (!flag)
				{
					GameObject gameObject = base.uiBehaviour.m_itemPool.FetchGameObject(false);
					gameObject.transform.parent = base.uiBehaviour.m_parentTra;
					gameObject.transform.localScale = Vector3.one;
					gameObject.transform.localPosition = base.uiBehaviour.m_itemPool.TplPos + new Vector3((float)(i % 3 * base.uiBehaviour.m_itemPool.TplWidth), (float)(-(float)(i / 3) * base.uiBehaviour.m_itemPool.TplHeight), 0f);
					IXUISprite ixuisprite = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)rowData.ID;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickIcon));
					IXUILabel ixuilabel = gameObject.transform.FindChild("shopname").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(rowData.Name);
					IXUITexture ixuitexture = gameObject.transform.FindChild("Icon").GetComponent("XUITexture") as IXUITexture;
					ixuitexture.SetTexturePath(rowData.IconName);
					ixuitexture.SetEnabled(rowData.IsOpen == 0);
				}
			}
		}

		// Token: 0x0600C73B RID: 51003 RVA: 0x002C33F8 File Offset: 0x002C15F8
		private bool OnClickClosedBtn(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600C73C RID: 51004 RVA: 0x002C3414 File Offset: 0x002C1614
		private void OnClickIcon(IXUISprite spr)
		{
			YorozuyaTable.RowData rowData = this.m_doc.GetRowData((byte)spr.ID);
			bool flag = rowData == null;
			if (!flag)
			{
				bool flag2 = rowData.IsOpen == 1;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ERR_CUSTOM_NOTOPEN"), "fece00");
				}
				else
				{
					this.m_doc.ReqEnterScene((int)spr.ID);
				}
			}
		}

		// Token: 0x04005786 RID: 22406
		private XYorozuyaDocument m_doc;
	}
}

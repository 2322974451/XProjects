using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017C3 RID: 6083
	internal class JadeComposeHandler : DlgHandlerBase
	{
		// Token: 0x1700388C RID: 14476
		// (get) Token: 0x0600FBE7 RID: 64487 RVA: 0x003A9AE4 File Offset: 0x003A7CE4
		protected override string FileName
		{
			get
			{
				return "ItemNew/JadeComposePanel";
			}
		}

		// Token: 0x0600FBE8 RID: 64488 RVA: 0x003A9AFC File Offset: 0x003A7CFC
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
			this.m_ComposeMenu = base.PanelObject.transform.FindChild("ComposeMenu").gameObject;
			this.m_IconComposeSource = this.m_ComposeMenu.transform.FindChild("SourceJade/JadeTpl").gameObject;
			this.m_IconComposeTarget = this.m_ComposeMenu.transform.FindChild("TargetJade/JadeTpl").gameObject;
			this.m_ComposeCost = (this.m_ComposeMenu.transform.FindChild("Cost").GetComponent("XUILabel") as IXUILabel);
			this.m_BtnComposeOne = (this.m_ComposeMenu.transform.FindChild("BtnComposeOne").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnCompose = (this.m_ComposeMenu.transform.FindChild("BtnCompose").GetComponent("XUIButton") as IXUIButton);
			this.m_ComposeMax = (this.m_ComposeMenu.transform.FindChild("ComposeMax").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_ComposeOne = (this.m_ComposeMenu.transform.FindChild("ComposeOne").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_ComposeMenuTitle = (this.m_ComposeMenu.transform.FindChild("Title").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600FBE9 RID: 64489 RVA: 0x003A9C80 File Offset: 0x003A7E80
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BtnComposeOne.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnComposeJadeEquipClicked));
			this.m_BtnCompose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOnComposeJadeBagClicked));
			this.m_ComposeMax.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnComposeMaxCheckBoxClicked));
			this.m_ComposeOne.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnComposeOneCheckBoxClicked));
			IXUIButton ixuibutton = this.m_ComposeMenu.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnComposeCloseClicked));
		}

		// Token: 0x0600FBEA RID: 64490 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x0600FBEB RID: 64491 RVA: 0x00209F22 File Offset: 0x00208122
		public override void RefreshData()
		{
			base.RefreshData();
		}

		// Token: 0x0600FBEC RID: 64492 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void _OnCloseClicked(IXUISprite iSp)
		{
			base.SetVisible(false);
		}

		// Token: 0x0600FBED RID: 64493 RVA: 0x003A9D30 File Offset: 0x003A7F30
		public void ToggleComposeMenu(bool open, int type = 0, int sourceID = 0, int sourceCount = 0, int requiredCount = 0, int targetID = 0, int sourceBindCount = -1)
		{
			base.SetVisible(open);
			if (open)
			{
				this._sourceID = sourceID;
				this._sourceCount = sourceCount;
				this._requiredCount = requiredCount;
				this._targetID = targetID;
				this._sourceBindCount = sourceBindCount;
				bool flag = type == -1;
				if (flag)
				{
					this.m_ComposeMax.gameObject.SetActive(true);
					this.m_ComposeOne.gameObject.SetActive(true);
					this.m_BtnCompose.gameObject.SetActive(true);
					this.m_BtnComposeOne.gameObject.SetActive(false);
					this.DrawComposeItem(true);
					this.m_ComposeMax.bChecked = true;
					this.m_BtnCompose.ID = 1UL;
				}
				else
				{
					bool flag2 = type >= 0;
					if (flag2)
					{
						this.m_ComposeMax.gameObject.SetActive(false);
						this.m_ComposeOne.gameObject.SetActive(false);
						this.m_BtnCompose.gameObject.SetActive(false);
						this.m_BtnComposeOne.gameObject.SetActive(true);
						this.DrawComposeItem(false);
						this.m_BtnComposeOne.ID = (ulong)((long)type);
					}
				}
			}
		}

		// Token: 0x0600FBEE RID: 64494 RVA: 0x003A9E5C File Offset: 0x003A805C
		protected bool OnComposeCloseClicked(IXUIButton btn)
		{
			this.ToggleComposeMenu(false, 0, 0, 0, 0, 0, -1);
			return true;
		}

		// Token: 0x0600FBEF RID: 64495 RVA: 0x003A9E80 File Offset: 0x003A8080
		protected bool OnComposeJadeEquipClicked(IXUIButton btn)
		{
			this.ToggleComposeMenu(false, 0, 0, 0, 0, 0, -1);
			return true;
		}

		// Token: 0x0600FBF0 RID: 64496 RVA: 0x003A9EA4 File Offset: 0x003A80A4
		private bool _Compose(IXUIButton btn)
		{
			bool flag = this.BtnComposeID == 1U;
			if (flag)
			{
				this.ToggleComposeMenu(false, 0, 0, 0, 0, 0, -1);
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600FBF1 RID: 64497 RVA: 0x003A9EE0 File Offset: 0x003A80E0
		private bool _NoCompose(IXUIButton btn)
		{
			return true;
		}

		// Token: 0x0600FBF2 RID: 64498 RVA: 0x003A9EF4 File Offset: 0x003A80F4
		protected bool OnOnComposeJadeBagClicked(IXUIButton btn)
		{
			this.BtnComposeID = (uint)btn.ID;
			bool flag = false;
			bool flag2 = false;
			XJadeDocument specificDocument = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
			JadeTable.RowData byJadeID = specificDocument.jadeTable.GetByJadeID((uint)this._sourceID);
			bool flag3 = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
			bool result;
			if (flag3)
			{
				result = false;
			}
			else
			{
				uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				int num = specificDocument.JadeLevelToMosaicLevel(byJadeID.JadeLevel + 1U);
				bool flag4 = (long)num > (long)((ulong)level) && !DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_JADE_UPGRADE_NO_EQUIP);
				if (flag4)
				{
					flag2 = true;
				}
				bool flag5 = this._sourceBindCount < this._useCount && this._sourceBindCount < this._sourceCount && this._useCount <= this._sourceCount && !DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_JADE_UPGRADE_NO_BIND);
				if (flag5)
				{
					flag = true;
				}
				bool flag6 = flag2 && !flag;
				if (flag6)
				{
					XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("JADE_COMPOSE_TIP_EQUIP"), num), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._Compose), null, false, XTempTipDefine.OD_JADE_UPGRADE_NO_EQUIP, 50);
					result = false;
				}
				else
				{
					bool flag7 = !flag2 && flag;
					if (flag7)
					{
						XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("JADE_COMPOSE_TIP_BIND"), new object[0]), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._Compose), null, false, XTempTipDefine.OD_JADE_UPGRADE_NO_BIND, 50);
						result = false;
					}
					else
					{
						bool flag8 = flag2 && flag;
						if (flag8)
						{
							XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("JADE_COMPOSE_TIP_BIND_EQUIP"), num), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._Compose));
							result = false;
						}
						else
						{
							bool flag9 = this.BtnComposeID == 1U;
							if (flag9)
							{
								this.ToggleComposeMenu(false, 0, 0, 0, 0, 0, -1);
							}
							result = true;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600FBF3 RID: 64499 RVA: 0x003AA100 File Offset: 0x003A8300
		protected bool OnComposeAllClicked(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("JADE_DIALOG_COMPOSE_ALL"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._DoComposeAll));
			return true;
		}

		// Token: 0x0600FBF4 RID: 64500 RVA: 0x003AA148 File Offset: 0x003A8348
		private bool _DoComposeAll(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600FBF5 RID: 64501 RVA: 0x003AA168 File Offset: 0x003A8368
		private bool OnComposeOneCheckBoxClicked(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.m_BtnCompose.ID = 0UL;
				this.DrawComposeItem(false);
				result = true;
			}
			return result;
		}

		// Token: 0x0600FBF6 RID: 64502 RVA: 0x003AA1A4 File Offset: 0x003A83A4
		private bool OnComposeMaxCheckBoxClicked(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.m_BtnCompose.ID = 1UL;
				this.DrawComposeItem(true);
				result = true;
			}
			return result;
		}

		// Token: 0x0600FBF7 RID: 64503 RVA: 0x003AA1E0 File Offset: 0x003A83E0
		private bool DrawComposeItem(bool isAll)
		{
			int num2;
			int num3;
			if (isAll)
			{
				bool flag = this._requiredCount == 0;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Jade RequiredCount Is 0", null, null, null, null, null);
				}
				int num = this._sourceCount / this._requiredCount;
				bool flag2 = num == 0;
				if (flag2)
				{
					num = 1;
				}
				num2 = num * this._requiredCount;
				num3 = num;
				this._useCount = num2;
			}
			else
			{
				num2 = this._requiredCount;
				num3 = 1;
				this._useCount = num2;
			}
			JadeTable.RowData byJadeID = this._doc.jadeTable.GetByJadeID((uint)this._sourceID);
			bool flag3 = (ulong)byJadeID.JadeLevel < (ulong)((long)this._doc.JadeLevelUpCost.Length);
			if (flag3)
			{
				int num4 = this._doc.JadeLevelUpCost[(int)byJadeID.JadeLevel] * num3;
				this.m_ComposeCost.SetText(num4.ToString());
			}
			else
			{
				this.m_ComposeCost.SetText("");
				XSingleton<XDebug>.singleton.AddErrorLog("Jade Level Up Cost No Find!\nJade Level:" + byJadeID.JadeLevel + 1, null, null, null, null, null);
			}
			XSingleton<XItemDrawerMgr>.singleton.jadeItemDrawer.DrawItem(this.m_IconComposeSource, this._sourceID, num2, true, this._sourceCount);
			XSingleton<XItemDrawerMgr>.singleton.jadeItemDrawer.DrawItem(this.m_IconComposeTarget, this._targetID, num3, true);
			XJadeItem jade = XBagDocument.MakeXItem(this._sourceID, false) as XJadeItem;
			XJadeItem jade2 = XBagDocument.MakeXItem(this._targetID, false) as XJadeItem;
			JadeEquipHandler.DrawAttr(this.m_IconComposeSource.gameObject.transform.parent.gameObject, jade);
			JadeEquipHandler.DrawAttr(this.m_IconComposeTarget.gameObject.transform.parent.gameObject, jade2);
			return true;
		}

		// Token: 0x0600FBF8 RID: 64504 RVA: 0x003AA3B4 File Offset: 0x003A85B4
		public void RefreshComposeItem()
		{
			bool activeSelf = this.m_ComposeMenu.activeSelf;
			if (activeSelf)
			{
				this._sourceCount = (int)XBagDocument.BagDoc.GetItemCount(this._sourceID);
				this._sourceBindCount = (int)XBagDocument.BagDoc.GetItemCount(this._sourceID, true);
				this.DrawComposeItem(false);
			}
		}

		// Token: 0x04006EAF RID: 28335
		private XJadeDocument _doc = null;

		// Token: 0x04006EB0 RID: 28336
		public GameObject m_ComposeMenu;

		// Token: 0x04006EB1 RID: 28337
		public IXUIButton m_BtnComposeOne;

		// Token: 0x04006EB2 RID: 28338
		public IXUILabel m_ComposeMenuTitle;

		// Token: 0x04006EB3 RID: 28339
		public IXUILabel m_ComposeCost;

		// Token: 0x04006EB4 RID: 28340
		public uint BtnComposeID;

		// Token: 0x04006EB5 RID: 28341
		public IXUIButton m_BtnCompose;

		// Token: 0x04006EB6 RID: 28342
		public IXUICheckBox m_ComposeMax;

		// Token: 0x04006EB7 RID: 28343
		public IXUICheckBox m_ComposeOne;

		// Token: 0x04006EB8 RID: 28344
		public GameObject m_IconComposeSource;

		// Token: 0x04006EB9 RID: 28345
		public GameObject m_IconComposeTarget;

		// Token: 0x04006EBA RID: 28346
		private int _sourceID;

		// Token: 0x04006EBB RID: 28347
		private int _sourceCount;

		// Token: 0x04006EBC RID: 28348
		private int _requiredCount;

		// Token: 0x04006EBD RID: 28349
		private int _targetID;

		// Token: 0x04006EBE RID: 28350
		private int _sourceBindCount;

		// Token: 0x04006EBF RID: 28351
		private int _useCount;
	}
}

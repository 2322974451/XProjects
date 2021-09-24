using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class JadeComposeHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "ItemNew/JadeComposePanel";
			}
		}

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

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		public override void RefreshData()
		{
			base.RefreshData();
		}

		private void _OnCloseClicked(IXUISprite iSp)
		{
			base.SetVisible(false);
		}

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

		protected bool OnComposeCloseClicked(IXUIButton btn)
		{
			this.ToggleComposeMenu(false, 0, 0, 0, 0, 0, -1);
			return true;
		}

		protected bool OnComposeJadeEquipClicked(IXUIButton btn)
		{
			this.ToggleComposeMenu(false, 0, 0, 0, 0, 0, -1);
			return true;
		}

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

		private bool _NoCompose(IXUIButton btn)
		{
			return true;
		}

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

		protected bool OnComposeAllClicked(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("JADE_DIALOG_COMPOSE_ALL"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._DoComposeAll));
			return true;
		}

		private bool _DoComposeAll(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

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

		private XJadeDocument _doc = null;

		public GameObject m_ComposeMenu;

		public IXUIButton m_BtnComposeOne;

		public IXUILabel m_ComposeMenuTitle;

		public IXUILabel m_ComposeCost;

		public uint BtnComposeID;

		public IXUIButton m_BtnCompose;

		public IXUICheckBox m_ComposeMax;

		public IXUICheckBox m_ComposeOne;

		public GameObject m_IconComposeSource;

		public GameObject m_IconComposeTarget;

		private int _sourceID;

		private int _sourceCount;

		private int _requiredCount;

		private int _targetID;

		private int _sourceBindCount;

		private int _useCount;
	}
}

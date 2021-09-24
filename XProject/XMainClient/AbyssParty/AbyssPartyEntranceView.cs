using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AbyssPartyEntranceView : DlgBase<AbyssPartyEntranceView, AbyssPartyEntranceBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/AbyssPartyDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_AbyssParty);
			}
		}

		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XAbyssPartyDocument>(XAbyssPartyDocument.uuID);
			this.doc.View = this;
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_Join.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinClicked));
			base.uiBehaviour.m_Fall.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFallClicked));
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_AbyssParty);
			return true;
		}

		public bool OnJoinClicked(IXUIButton btn)
		{
			bool flag = XTeamDocument.GoSingleBattleBeforeNeed(new ButtonClickEventHandler(this.OnJoinClicked), btn);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				int[] titan = this.GetTitan();
				int num = 0;
				ItemList.RowData rowData = null;
				bool flag2 = titan != null && titan.Length != 0;
				if (flag2)
				{
					num = (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(titan[0]);
					rowData = XBagDocument.GetItemConf(titan[0]);
				}
				bool flag3 = num < this.curCostNum;
				if (flag3)
				{
					int num2 = this.doc.CanUseCostMAXNum();
					bool flag4 = num2 < this.curCostNum;
					if (flag4)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ERR_ITEM_NOT_ENOUGH"), "fece00");
					}
					else
					{
						bool flag5 = !DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_ABYSS_PARTY_COST_REPLACE);
						if (flag5)
						{
							bool flag6 = rowData == null;
							if (flag6)
							{
								return true;
							}
							UiUtility singleton = XSingleton<UiUtility>.singleton;
							string @string = XSingleton<XStringTable>.singleton.GetString("ABYSS_COST_NOT_ENOUGH");
							object[] itemName = rowData.ItemName;
							singleton.ShowModalDialog(string.Format(@string, itemName), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._Enter), null, false, XTempTipDefine.OD_ABYSS_PARTY_COST_REPLACE, 50);
						}
						else
						{
							this._Enter(null);
						}
					}
				}
				else
				{
					this._Enter(null);
				}
				result = true;
			}
			return result;
		}

		private bool _Enter(IXUIButton btn)
		{
			this.doc.AbyssPartyEnter(this.doc.CurSelectedID);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private bool OnFallClicked(IXUIButton btn)
		{
			AbyssPartyTypeTable.RowData abyssPartyType = this.doc.GetAbyssPartyType();
			bool flag = abyssPartyType == null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				DlgHandlerBase.EnsureCreate<ItemListHandler>(ref this._itemListHandler, base.uiBehaviour.transform, false, null);
				PandoraDocument specificDocument = XDocuments.GetSpecificDocument<PandoraDocument>(PandoraDocument.uuID);
				specificDocument.GetShowItemList((uint)abyssPartyType.PandoraID);
				this._itemListHandler.ShowItemList(PandoraDocument.ItemList);
				result = true;
			}
			return result;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshPage();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<ItemListHandler>(ref this._itemListHandler);
			this.doc.View = null;
			base.OnUnload();
		}

		public override int[] GetTitanBarItems()
		{
			return this.GetTitan();
		}

		public override void StackRefresh()
		{
			this.RefreshPage();
		}

		public void RefreshPage()
		{
			this.RefreshTab();
			this.RefreshLevelFrame();
		}

		public void RefreshTab()
		{
			base.uiBehaviour.m_TabPool.FakeReturnAll();
			for (int i = 0; i < XAbyssPartyDocument.GetAbyssPartyTypeCount(); i++)
			{
				AbyssPartyTypeTable.RowData abyssPartyTypeLine = XAbyssPartyDocument.GetAbyssPartyTypeLine(i);
				bool flag = abyssPartyTypeLine == null;
				if (!flag)
				{
					GameObject gameObject = base.uiBehaviour.m_TabPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)i * base.uiBehaviour.m_TabPool.TplHeight), 0f) + base.uiBehaviour.m_TabPool.TplPos;
					IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
					IXUILabel ixuilabel = gameObject.transform.Find("Label").GetComponent("XUILabel") as IXUILabel;
					IXUISprite ixuisprite2 = gameObject.transform.Find("Fx").GetComponent("XUISprite") as IXUISprite;
					IXUISprite ixuisprite3 = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
					Transform transform = gameObject.transform.Find("Lock");
					ixuisprite.ID = (ulong)((long)abyssPartyTypeLine.AbyssPartyId);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnTabClicked));
					ixuilabel.SetText(abyssPartyTypeLine.Name);
					ixuisprite2.SetVisible(this.doc.CurSelectedType == abyssPartyTypeLine.AbyssPartyId);
					ixuisprite3.SetSprite(abyssPartyTypeLine.Icon);
					transform.gameObject.SetActive((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)abyssPartyTypeLine.OpenLevel));
				}
			}
			base.uiBehaviour.m_TabPool.ActualReturnAll(false);
			this.RefreshDetailFrame();
		}

		public void RefreshDetailFrame()
		{
			AbyssPartyListTable.RowData abyssPartyList = this.doc.GetAbyssPartyList();
			bool flag = abyssPartyList != null;
			if (flag)
			{
				base.uiBehaviour.m_SugPPT.SetText(abyssPartyList.SugPPT.ToString());
			}
			AbyssPartyTypeTable.RowData abyssPartyType = this.doc.GetAbyssPartyType();
			bool flag2 = abyssPartyType != null;
			if (flag2)
			{
				base.uiBehaviour.m_Name.SetText(abyssPartyType.Name);
				base.uiBehaviour.m_SugLevel.SetText(abyssPartyType.SugLevel);
			}
			base.uiBehaviour.m_CurPPT.SetText(XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic).ToString("0"));
		}

		public int[] GetTitan()
		{
			AbyssPartyTypeTable.RowData abyssPartyType = this.doc.GetAbyssPartyType();
			bool flag = abyssPartyType != null;
			int[] result;
			if (flag)
			{
				result = abyssPartyType.TitanItemID;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public void RefreshTitan()
		{
			DlgBase<TitanbarView, TitanBarBehaviour>.singleton.SetTitanItems(this.GetTitan());
		}

		public void RefreshLevelFrame()
		{
			base.uiBehaviour.m_AbyssPool.FakeReturnAll();
			int num = 0;
			while ((long)num < (long)((ulong)AbyssPartyEntranceView.ABYSS_MAX))
			{
				GameObject gameObject = base.uiBehaviour.m_AbyssPool.FetchGameObject(false);
				IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = gameObject.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite2 = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				Transform transform = gameObject.transform.Find("Select");
				Transform transform2 = gameObject.transform.Find("Lock");
				List<AbyssPartyListTable.RowData> list = XAbyssPartyDocument.RefreshAbyssPartyListList(this.doc.CurSelectedType);
				bool flag = num < list.Count;
				if (flag)
				{
					ixuilabel.SetText(list[num].Name);
					ixuisprite2.SetSprite(list[num].Icon);
					uint abyssIndex = this.doc.GetAbyssIndex(this.doc.CurSelectedType);
					transform2.gameObject.SetActive((ulong)abyssIndex < (ulong)((long)list[num].Index));
					bool flag2 = this.doc.CurSelectedID == list[num].ID;
					if (flag2)
					{
						transform.gameObject.SetActive(true);
						base.uiBehaviour.m_SugPPT.SetText(list[num].SugPPT.ToString());
					}
					else
					{
						transform.gameObject.SetActive(false);
					}
					ixuisprite.ID = (ulong)((long)list[num].ID);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAbyssClicked));
				}
				num++;
			}
			base.uiBehaviour.m_AbyssPool.ActualReturnAll(true);
			this.RefreshCost();
		}

		public void RefreshCost()
		{
			AbyssPartyListTable.RowData abyssPartyList = this.doc.GetAbyssPartyList();
			bool flag = abyssPartyList != null;
			if (flag)
			{
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(base.uiBehaviour.m_CostItem.gameObject, abyssPartyList.Cost[0], abyssPartyList.Cost[1], true);
				IXUISprite ixuisprite = base.uiBehaviour.m_CostItem.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)abyssPartyList.Cost[0]);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClick));
				this.curCostNum = abyssPartyList.Cost[1];
			}
		}

		private void SelectedIndex(int index)
		{
		}

		private void OnTabClicked(IXUISprite iSp)
		{
			AbyssPartyTypeTable.RowData abyssPartyType = XAbyssPartyDocument.GetAbyssPartyType((int)iSp.ID);
			bool flag = abyssPartyType == null;
			if (!flag)
			{
				bool flag2 = (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)abyssPartyType.OpenLevel);
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("UnlockByLevel", new object[]
					{
						abyssPartyType.OpenLevel,
						abyssPartyType.Name
					}), "fece00");
				}
				else
				{
					bool flag3 = (long)this.doc.CurSelectedType == (long)((ulong)((uint)iSp.ID));
					if (!flag3)
					{
						bool flag4 = this.doc.SetSelectedType((int)iSp.ID);
						if (flag4)
						{
							this.RefreshPage();
							this.RefreshTitan();
						}
					}
				}
			}
		}

		private void OnAbyssClicked(IXUISprite iSp)
		{
			AbyssPartyListTable.RowData abyssPartyList = XAbyssPartyDocument.GetAbyssPartyList((int)iSp.ID);
			uint abyssIndex = this.doc.GetAbyssIndex(this.doc.CurSelectedType);
			bool flag = (ulong)abyssIndex < (ulong)((long)abyssPartyList.Index);
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("UnlockByPreDiff"), "fece00");
			}
			else
			{
				bool flag2 = (long)this.doc.CurSelectedID == (long)((ulong)((uint)iSp.ID));
				if (!flag2)
				{
					bool flag3 = this.doc.SetSelectedID((int)iSp.ID);
					if (flag3)
					{
						this.RefreshLevelFrame();
					}
				}
			}
		}

		private void _OnItemClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
		}

		private XAbyssPartyDocument doc = null;

		public static readonly uint ABYSS_MAX = 6U;

		private ItemListHandler _itemListHandler;

		private int curCostNum = 0;
	}
}

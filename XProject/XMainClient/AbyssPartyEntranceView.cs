using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C8D RID: 3213
	internal class AbyssPartyEntranceView : DlgBase<AbyssPartyEntranceView, AbyssPartyEntranceBehaviour>
	{
		// Token: 0x1700321A RID: 12826
		// (get) Token: 0x0600B572 RID: 46450 RVA: 0x0023CCEC File Offset: 0x0023AEEC
		public override string fileName
		{
			get
			{
				return "GameSystem/AbyssPartyDlg";
			}
		}

		// Token: 0x1700321B RID: 12827
		// (get) Token: 0x0600B573 RID: 46451 RVA: 0x0023CD04 File Offset: 0x0023AF04
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700321C RID: 12828
		// (get) Token: 0x0600B574 RID: 46452 RVA: 0x0023CD18 File Offset: 0x0023AF18
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700321D RID: 12829
		// (get) Token: 0x0600B575 RID: 46453 RVA: 0x0023CD2C File Offset: 0x0023AF2C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700321E RID: 12830
		// (get) Token: 0x0600B576 RID: 46454 RVA: 0x0023CD40 File Offset: 0x0023AF40
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700321F RID: 12831
		// (get) Token: 0x0600B577 RID: 46455 RVA: 0x0023CD54 File Offset: 0x0023AF54
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003220 RID: 12832
		// (get) Token: 0x0600B578 RID: 46456 RVA: 0x0023CD68 File Offset: 0x0023AF68
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003221 RID: 12833
		// (get) Token: 0x0600B579 RID: 46457 RVA: 0x0023CD7C File Offset: 0x0023AF7C
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_AbyssParty);
			}
		}

		// Token: 0x0600B57A RID: 46458 RVA: 0x0023CD98 File Offset: 0x0023AF98
		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XAbyssPartyDocument>(XAbyssPartyDocument.uuID);
			this.doc.View = this;
		}

		// Token: 0x0600B57B RID: 46459 RVA: 0x0023CDB8 File Offset: 0x0023AFB8
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_Join.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinClicked));
			base.uiBehaviour.m_Fall.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFallClicked));
		}

		// Token: 0x0600B57C RID: 46460 RVA: 0x0023CE3C File Offset: 0x0023B03C
		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600B57D RID: 46461 RVA: 0x0023CE58 File Offset: 0x0023B058
		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_AbyssParty);
			return true;
		}

		// Token: 0x0600B57E RID: 46462 RVA: 0x0023CE7C File Offset: 0x0023B07C
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

		// Token: 0x0600B57F RID: 46463 RVA: 0x0023CFD4 File Offset: 0x0023B1D4
		private bool _Enter(IXUIButton btn)
		{
			this.doc.AbyssPartyEnter(this.doc.CurSelectedID);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600B580 RID: 46464 RVA: 0x0023D00C File Offset: 0x0023B20C
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

		// Token: 0x0600B581 RID: 46465 RVA: 0x0023D079 File Offset: 0x0023B279
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshPage();
		}

		// Token: 0x0600B582 RID: 46466 RVA: 0x0023D08A File Offset: 0x0023B28A
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B583 RID: 46467 RVA: 0x0023D094 File Offset: 0x0023B294
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<ItemListHandler>(ref this._itemListHandler);
			this.doc.View = null;
			base.OnUnload();
		}

		// Token: 0x0600B584 RID: 46468 RVA: 0x0023D0B8 File Offset: 0x0023B2B8
		public override int[] GetTitanBarItems()
		{
			return this.GetTitan();
		}

		// Token: 0x0600B585 RID: 46469 RVA: 0x0023D0D0 File Offset: 0x0023B2D0
		public override void StackRefresh()
		{
			this.RefreshPage();
		}

		// Token: 0x0600B586 RID: 46470 RVA: 0x0023D0DA File Offset: 0x0023B2DA
		public void RefreshPage()
		{
			this.RefreshTab();
			this.RefreshLevelFrame();
		}

		// Token: 0x0600B587 RID: 46471 RVA: 0x0023D0EC File Offset: 0x0023B2EC
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

		// Token: 0x0600B588 RID: 46472 RVA: 0x0023D2B4 File Offset: 0x0023B4B4
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

		// Token: 0x0600B589 RID: 46473 RVA: 0x0023D36C File Offset: 0x0023B56C
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

		// Token: 0x0600B58A RID: 46474 RVA: 0x0023D39D File Offset: 0x0023B59D
		public void RefreshTitan()
		{
			DlgBase<TitanbarView, TitanBarBehaviour>.singleton.SetTitanItems(this.GetTitan());
		}

		// Token: 0x0600B58B RID: 46475 RVA: 0x0023D3B4 File Offset: 0x0023B5B4
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

		// Token: 0x0600B58C RID: 46476 RVA: 0x0023D5AC File Offset: 0x0023B7AC
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

		// Token: 0x0600B58D RID: 46477 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void SelectedIndex(int index)
		{
		}

		// Token: 0x0600B58E RID: 46478 RVA: 0x0023D66C File Offset: 0x0023B86C
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

		// Token: 0x0600B58F RID: 46479 RVA: 0x0023D730 File Offset: 0x0023B930
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

		// Token: 0x0600B590 RID: 46480 RVA: 0x001EECC3 File Offset: 0x001ECEC3
		private void _OnItemClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
		}

		// Token: 0x040046F8 RID: 18168
		private XAbyssPartyDocument doc = null;

		// Token: 0x040046F9 RID: 18169
		public static readonly uint ABYSS_MAX = 6U;

		// Token: 0x040046FA RID: 18170
		private ItemListHandler _itemListHandler;

		// Token: 0x040046FB RID: 18171
		private int curCostNum = 0;
	}
}

using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E67 RID: 3687
	internal class XTeamDungeonSelectorHandler : DlgHandlerBase
	{
		// Token: 0x0600C594 RID: 50580 RVA: 0x002BA120 File Offset: 0x002B8320
		protected override void Init()
		{
			base.Init();
			this.m_BtnDungeonSelector = (base.PanelObject.transform.FindChild("CurrentCategory/Btn").GetComponent("XUIButton") as IXUIButton);
			this.m_CurrentDungeon = (base.PanelObject.transform.FindChild("CurrentDungeon").GetComponent("XUILabel") as IXUILabel);
			this.m_CurrentCategory = (base.PanelObject.transform.FindChild("CurrentCategory").GetComponent("XUILabel") as IXUILabel);
			this.m_SelectorFrame = base.PanelObject.transform.Find("Selector").gameObject;
			this.m_DungeonScrollView = (this.m_SelectorFrame.transform.FindChild("Main/Dungeons/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_CategoryScrollView = (this.m_SelectorFrame.transform.FindChild("Main/Categories/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_Close = (this.m_SelectorFrame.transform.FindChild("Close").GetComponent("XUISprite") as IXUISprite);
			this._TeamDoc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this._ExpDoc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			this._TeamDoc.DungeonSelector = this;
		}

		// Token: 0x0600C595 RID: 50581 RVA: 0x002BA27D File Offset: 0x002B847D
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCloseClicked));
			this.m_BtnDungeonSelector.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnDungeonSelectorClick));
		}

		// Token: 0x0600C596 RID: 50582 RVA: 0x002BA2B8 File Offset: 0x002B84B8
		protected override void _DelayInit()
		{
			base._DelayInit();
			Transform transform = this.m_DungeonScrollView.gameObject.transform.FindChild("Tpl");
			this.m_DungeonPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			transform = this.m_CategoryScrollView.gameObject.transform.FindChild("List/CategoryTpl");
			this.m_CategoryPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
		}

		// Token: 0x0600C597 RID: 50583 RVA: 0x002BA341 File Offset: 0x002B8541
		protected override void OnShow()
		{
			base.OnShow();
			this.SetCurrentDungeon(true);
		}

		// Token: 0x0600C598 RID: 50584 RVA: 0x002BA353 File Offset: 0x002B8553
		public override void RefreshData()
		{
			base.RefreshData();
			this.SetCurrentDungeon(false);
		}

		// Token: 0x0600C599 RID: 50585 RVA: 0x002BA365 File Offset: 0x002B8565
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.SetCurrentDungeon(false);
		}

		// Token: 0x0600C59A RID: 50586 RVA: 0x002BA378 File Offset: 0x002B8578
		public void ToggleSelector(bool bShow)
		{
			this.m_SelectorFrame.SetActive(bShow);
			if (bShow)
			{
				this._Setup();
				this._DefaultSelect();
			}
		}

		// Token: 0x0600C59B RID: 50587 RVA: 0x002BA3A8 File Offset: 0x002B85A8
		public override void OnUnload()
		{
			this._TeamDoc.DungeonSelector = null;
			base.OnUnload();
		}

		// Token: 0x0600C59C RID: 50588 RVA: 0x002BA3BE File Offset: 0x002B85BE
		private void _OnCloseClicked(IXUISprite iSp)
		{
			this.ToggleSelector(false);
		}

		// Token: 0x0600C59D RID: 50589 RVA: 0x002BA3CC File Offset: 0x002B85CC
		private bool _OnDungeonSelectorClick(IXUIButton go)
		{
			this.ToggleSelector(true);
			return true;
		}

		// Token: 0x0600C59E RID: 50590 RVA: 0x002BA3E8 File Offset: 0x002B85E8
		public void SetCurrentDungeon(bool bCloseSelection)
		{
			bool flag = this._TeamDoc.currentDungeonID == 0U;
			if (flag)
			{
				this.m_CurrentDungeon.SetText(XStringDefineProxy.GetString("TEAM_NO_TARGET"));
			}
			else
			{
				this.m_CurrentDungeon.SetText(string.Format("{0} {1}", this._TeamDoc.currentCategoryName, this._TeamDoc.currentDungeonName));
			}
			if (bCloseSelection)
			{
				this.ToggleSelector(false);
			}
			this.m_BtnDungeonSelector.SetEnable(!this._TeamDoc.bInTeam || this._TeamDoc.bIsLeader, false);
		}

		// Token: 0x0600C59F RID: 50591 RVA: 0x002BA488 File Offset: 0x002B8688
		private void _DefaultSelect()
		{
			bool flag = this._TeamDoc.currentDungeonID == 0U;
			if (!flag)
			{
				ExpeditionTable.RowData expeditionDataByID = this._ExpDoc.GetExpeditionDataByID((int)this._TeamDoc.currentDungeonID);
				bool flag2 = expeditionDataByID == null;
				if (!flag2)
				{
					ulong num = (ulong)((long)expeditionDataByID.Category);
					for (int i = 0; i < this.m_CategoryList.Count; i++)
					{
						bool flag3 = num == this.m_CategoryList[i].ID;
						if (flag3)
						{
							this.m_CategoryList[i].bChecked = true;
							break;
						}
					}
				}
			}
		}

		// Token: 0x0600C5A0 RID: 50592 RVA: 0x002BA528 File Offset: 0x002B8728
		private void _Setup()
		{
			this.m_DungeonPool.ReturnAll(false);
			this.m_CategoryPool.ReturnAll(false);
			this.m_CategoryList.Clear();
			List<XTeamCategory> categories = this._ExpDoc.TeamCategoryMgr.m_Categories;
			int num = 0;
			for (int i = 0; i < categories.Count; i++)
			{
				XTeamCategory xteamCategory = categories[i];
				bool flag = !xteamCategory.HasOpened();
				if (!flag)
				{
					GameObject gameObject = this.m_CategoryPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(this.m_CategoryPool.TplPos.x, this.m_CategoryPool.TplPos.y - (float)(this.m_CategoryPool.TplHeight * num));
					IXUICheckBox ixuicheckBox = gameObject.transform.FindChild("BtnToggle/Normal").GetComponent("XUICheckBox") as IXUICheckBox;
					ixuicheckBox.ID = (ulong)((long)xteamCategory.category);
					ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._CategoryCheckEventHandler));
					IXUILabel ixuilabel = gameObject.transform.FindChild("BtnToggle/Text").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = gameObject.transform.FindChild("BtnToggle/SelectedText").GetComponent("XUILabel") as IXUILabel;
					string categoryName = XTeamCategory.GetCategoryName(xteamCategory.category);
					ixuilabel.SetText(categoryName);
					ixuilabel2.SetText(categoryName);
					this.m_CategoryList.Add(ixuicheckBox);
					num++;
					ixuicheckBox.ForceSetFlag(false);
				}
			}
			this.m_CategoryScrollView.ResetPosition();
		}

		// Token: 0x0600C5A1 RID: 50593 RVA: 0x002BA6D0 File Offset: 0x002B88D0
		private bool _CategoryCheckEventHandler(IXUICheckBox ckb)
		{
			bool flag = !ckb.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_DungeonPool.FakeReturnAll();
				XTeamCategory xteamCategory = this._ExpDoc.TeamCategoryMgr.FindCategory((int)ckb.ID);
				bool flag2 = xteamCategory != null;
				if (flag2)
				{
					XPlayerAttributes playerAttributes = XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes;
					uint num = (uint)playerAttributes.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
					uint level = playerAttributes.Level;
					int i = 0;
					int num2 = 0;
					while (i < xteamCategory.expList.Count)
					{
						ExpeditionTable.RowData rowData = xteamCategory.expList[i];
						bool flag3 = rowData == null;
						if (!flag3)
						{
							bool flag4 = !xteamCategory.IsExpOpened(rowData);
							if (!flag4)
							{
								GameObject gameObject = this.m_DungeonPool.FetchGameObject(false);
								gameObject.transform.localPosition = new Vector3(this.m_DungeonPool.TplPos.x, this.m_DungeonPool.TplPos.y - (float)(this.m_DungeonPool.TplHeight * num2++));
								IXUILabel ixuilabel = gameObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
								ixuilabel.SetText(XExpeditionDocument.GetFullName(rowData));
								ixuilabel = (gameObject.transform.FindChild("PPT").GetComponent("XUILabel") as IXUILabel);
								ixuilabel.SetText(rowData.DisplayPPT.ToString());
								ixuilabel.SetColor((rowData.DisplayPPT <= num) ? XTeamDungeonSelectorHandler.GOOD_COLOR : XTeamDungeonSelectorHandler.BAD_COLOR);
								ixuilabel = (gameObject.transform.FindChild("Level").GetComponent("XUILabel") as IXUILabel);
								ixuilabel.SetText(XStringDefineProxy.GetString("LEVEL", new object[]
								{
									rowData.DisplayLevel.ToString()
								}));
								ixuilabel.SetColor((rowData.DisplayLevel <= level) ? XTeamDungeonSelectorHandler.GOOD_COLOR : XTeamDungeonSelectorHandler.BAD_COLOR);
								Transform transform = gameObject.transform.FindChild("Normal");
								IXUICheckBox ixuicheckBox = transform.GetComponent("XUICheckBox") as IXUICheckBox;
								ixuicheckBox.ID = (ulong)((long)rowData.DNExpeditionID);
								ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._DungeonCheckEventHandler));
								IXUIButton ixuibutton = transform.GetComponent("XUIButton") as IXUIButton;
								ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._DungeonClickEventHandler));
								ixuicheckBox.ForceSetFlag((ulong)this._TeamDoc.currentDungeonID == (ulong)((long)rowData.DNExpeditionID));
								IXUISprite ixuisprite = gameObject.transform.Find("SisterTA").GetComponent("XUISprite") as IXUISprite;
								ixuisprite.ID = 0UL;
								ixuisprite.SetVisible(this._TeamDoc.ShowTarja((uint)rowData.DNExpeditionID));
								ixuisprite.RegisterSpritePressEventHandler(new SpritePressEventHandler(this.OnShowTarjaTipHandle));
							}
						}
						i++;
					}
				}
				this.m_DungeonPool.ActualReturnAll(false);
				this.m_DungeonScrollView.ResetPosition();
				result = true;
			}
			return result;
		}

		// Token: 0x0600C5A2 RID: 50594 RVA: 0x002BA9F8 File Offset: 0x002B8BF8
		private bool OnShowTarjaTipHandle(IXUISprite sprite, bool pressed)
		{
			IXUILabel ixuilabel = sprite.transform.Find("Info").GetComponent("XUILabel") as IXUILabel;
			bool flag = ixuilabel == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = sprite.ID == 1UL;
				if (flag2)
				{
					ixuilabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("TEAM_TARJA_DESC_TEAM")));
				}
				else
				{
					ixuilabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("TEAM_TARJA_DESC")));
				}
				ixuilabel.SetVisible(pressed);
				result = false;
			}
			return result;
		}

		// Token: 0x0600C5A3 RID: 50595 RVA: 0x002BAA88 File Offset: 0x002B8C88
		private bool _DungeonClickEventHandler(IXUIButton btn)
		{
			IXUICheckBox ixuicheckBox = btn.gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
			bool bChecked = ixuicheckBox.bChecked;
			if (bChecked)
			{
				this.ToggleSelector(false);
			}
			return true;
		}

		// Token: 0x0600C5A4 RID: 50596 RVA: 0x002BAAC4 File Offset: 0x002B8CC4
		private bool _DungeonCheckEventHandler(IXUICheckBox ckb)
		{
			bool flag = !ckb.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._TeamDoc.TryChangeToExpID((int)ckb.ID);
				result = true;
			}
			return result;
		}

		// Token: 0x04005680 RID: 22144
		private static readonly Color BAD_COLOR = new Color(1f, 0.23921569f, 0.13725491f);

		// Token: 0x04005681 RID: 22145
		private static readonly Color GOOD_COLOR = new Color(0.39215687f, 0.7176471f, 0.21568628f);

		// Token: 0x04005682 RID: 22146
		private XTeamDocument _TeamDoc;

		// Token: 0x04005683 RID: 22147
		private XExpeditionDocument _ExpDoc;

		// Token: 0x04005684 RID: 22148
		private IXUIScrollView m_DungeonScrollView;

		// Token: 0x04005685 RID: 22149
		private IXUIScrollView m_CategoryScrollView;

		// Token: 0x04005686 RID: 22150
		private XUIPool m_DungeonPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04005687 RID: 22151
		private XUIPool m_CategoryPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04005688 RID: 22152
		private List<IXUICheckBox> m_CategoryList = new List<IXUICheckBox>();

		// Token: 0x04005689 RID: 22153
		private IXUISprite m_Close;

		// Token: 0x0400568A RID: 22154
		public IXUIButton m_BtnDungeonSelector;

		// Token: 0x0400568B RID: 22155
		public IXUILabel m_CurrentDungeon;

		// Token: 0x0400568C RID: 22156
		public IXUILabel m_CurrentCategory;

		// Token: 0x0400568D RID: 22157
		public GameObject m_SelectorFrame;
	}
}

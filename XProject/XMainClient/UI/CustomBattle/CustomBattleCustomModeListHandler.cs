using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI.CustomBattle
{
	// Token: 0x02001934 RID: 6452
	internal class CustomBattleCustomModeListHandler : DlgHandlerBase
	{
		// Token: 0x17003B29 RID: 15145
		// (get) Token: 0x06010F68 RID: 69480 RVA: 0x004508F4 File Offset: 0x0044EAF4
		private int wrapCount
		{
			get
			{
				bool flag = this._doc == null;
				int result;
				if (flag)
				{
					result = 0;
				}
				else
				{
					result = ((this._doc.SelfCustomData == null) ? this._doc.CustomList.Count : (this._doc.CustomList.Count + 1));
				}
				return result;
			}
		}

		// Token: 0x17003B2A RID: 15146
		// (get) Token: 0x06010F69 RID: 69481 RVA: 0x00450948 File Offset: 0x0044EB48
		protected override string FileName
		{
			get
			{
				return "GameSystem/CustomBattle/CustomModeListFrame";
			}
		}

		// Token: 0x06010F6A RID: 69482 RVA: 0x00450960 File Offset: 0x0044EB60
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
			this._input = (base.transform.Find("Bg/Input").GetComponent("XUIInput") as IXUIInput);
			this._search = (base.transform.Find("Bg/Input/Search").GetComponent("XUISprite") as IXUISprite);
			this._create_game = (base.transform.Find("Bg/BtnCreateGame").GetComponent("XUIButton") as IXUIButton);
			this._my_game = (base.transform.Find("Bg/BtnMyGame").GetComponent("XUIButton") as IXUIButton);
			this._red_point = base.transform.Find("Bg/BtnMyGame/RedPoint");
			this._refresh = (base.transform.Find("Bg/BtnRefresh").GetComponent("XUIButton") as IXUIButton);
			this._show_other = (base.transform.Find("Bg/BtnOther").GetComponent("XUISprite") as IXUISprite);
			this._show_flag = base.transform.Find("Bg/BtnOther/Flag");
			this._empty_game = base.transform.Find("Bg/EmptyGame");
			this._scroll_view = (base.transform.Find("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this._wrap_content = (base.transform.Find("Bg/Panel/List").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._wrap_content.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentUpdated));
		}

		// Token: 0x06010F6B RID: 69483 RVA: 0x00450B08 File Offset: 0x0044ED08
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._search.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSearchClicked));
			this._create_game.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCreateGameButtonClicked));
			this._my_game.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnMyGameButtonClicked));
			this._refresh.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRefreshButtonClicked));
			this._show_other.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnShowOtherClicked));
		}

		// Token: 0x06010F6C RID: 69484 RVA: 0x00450B98 File Offset: 0x0044ED98
		protected override void OnShow()
		{
			base.OnShow();
			this._input.SetText("");
			this._show_flag.gameObject.SetActive(this._doc.QueryCross);
			this._doc.SendCustomBattleQueryCustomModeList(this._doc.QueryCross);
			this._doc.SendCustomBattleQueryCustomModeSelfInfo();
			this.RefreshData();
		}

		// Token: 0x06010F6D RID: 69485 RVA: 0x00450C04 File Offset: 0x0044EE04
		public override void RefreshData()
		{
			base.RefreshData();
			bool flag = this._doc.SelfCustomData != null;
			if (flag)
			{
				this._create_game.SetVisible(false);
				this._my_game.SetVisible(true);
				this._red_point.gameObject.SetActive(this._doc.SelfCustomData.selfStatus == CustomBattleRoleState.CustomBattle_RoleState_Reward && this._doc.SelfCustomData.boxLeftTime == 0U);
			}
			else
			{
				this._create_game.SetVisible(true);
				this._my_game.SetVisible(false);
			}
			this._wrap_content.SetContentCount(this.wrapCount, false);
			this._empty_game.gameObject.SetActive(this.wrapCount == 0);
			this._scroll_view.ResetPosition();
		}

		// Token: 0x06010F6E RID: 69486 RVA: 0x00450CD8 File Offset: 0x0044EED8
		private void WrapContentUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this.wrapCount;
			if (flag)
			{
				t.gameObject.SetActive(false);
			}
			else
			{
				this.SetupCustom(t, index);
			}
		}

		// Token: 0x06010F6F RID: 69487 RVA: 0x00450D18 File Offset: 0x0044EF18
		private void SetupCustom(Transform t, int index)
		{
			Transform transform = t.Find("FairMode");
			IXUILabelSymbol ixuilabelSymbol = t.Find("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabel ixuilabel = t.Find("Type").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = t.Find("Creator").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = t.Find("JoinCount").GetComponent("XUILabel") as IXUILabel;
			IXUIButton ixuibutton = t.Find("JoinBtn").GetComponent("XUIButton") as IXUIButton;
			IXUIButton ixuibutton2 = t.Find("DetailBtn").GetComponent("XUIButton") as IXUIButton;
			bool flag = this._doc.SelfCustomData == null;
			XCustomBattleDocument.CustomModeData customModeData;
			if (flag)
			{
				customModeData = this._doc.CustomList[index];
			}
			else
			{
				bool flag2 = index == 0;
				if (flag2)
				{
					customModeData = this._doc.SelfCustomData;
				}
				else
				{
					customModeData = this._doc.CustomList[index - 1];
				}
			}
			transform.gameObject.SetActive(customModeData.fairMode);
			string text = " ";
			uint num = 1U << XFastEnumIntEqualityComparer<CustomBattleTag>.ToInt(CustomBattleTag.CustomBattle_Tag_Friend);
			bool flag3 = (customModeData.tagMask & num) == num;
			num = 1U << XFastEnumIntEqualityComparer<CustomBattleTag>.ToInt(CustomBattleTag.CustomBattle_Tag_Guild);
			bool flag4 = (customModeData.tagMask & num) == num;
			num = 1U << XFastEnumIntEqualityComparer<CustomBattleTag>.ToInt(CustomBattleTag.CustomBattle_Tag_Cross);
			bool flag5 = (customModeData.tagMask & num) == num;
			num = 1U << XFastEnumIntEqualityComparer<CustomBattleTag>.ToInt(CustomBattleTag.CustomBattle_Tag_GM);
			bool flag6 = (customModeData.tagMask & num) == num;
			bool flag7 = flag3;
			if (flag7)
			{
				text += XLabelSymbolHelper.FormatImage("common/Universal", "chat_tag_8");
			}
			bool flag8 = flag4;
			if (flag8)
			{
				text += XLabelSymbolHelper.FormatImage("common/Universal", "chat_tag_2");
			}
			bool flag9 = flag5;
			if (flag9)
			{
				text += XLabelSymbolHelper.FormatImage("common/Universal", "chat_tag_11");
			}
			bool flag10 = flag6;
			if (flag10)
			{
				text += XLabelSymbolHelper.FormatImage("common/Universal", "chat_tag_12");
			}
			ixuilabelSymbol.InputText = customModeData.gameName + text;
			CustomBattleTypeTable.RowData customBattleTypeData = this._doc.GetCustomBattleTypeData((int)customModeData.gameType);
			ixuilabel.SetText((customBattleTypeData != null) ? customBattleTypeData.name : "");
			ixuilabel2.SetText(customModeData.gameCreator);
			ixuilabel3.SetText(customModeData.joinText);
			ixuibutton.ID = (ulong)((long)index);
			ixuibutton2.ID = (ulong)((long)index);
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinButtonClicked));
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDetailButtonClicked));
			bool flag11 = this._doc.SelfCustomData != null && this._doc.SelfCustomData.gameID == customModeData.gameID;
			if (flag11)
			{
				ixuibutton.SetEnable(false, false);
			}
			else
			{
				ixuibutton.SetEnable(true, false);
			}
		}

		// Token: 0x06010F70 RID: 69488 RVA: 0x00451029 File Offset: 0x0044F229
		private void OnSearchClicked(IXUISprite sp)
		{
			this._doc.SendCustomBattleSearch(this._input.GetText());
			this._input.SetText("");
		}

		// Token: 0x06010F71 RID: 69489 RVA: 0x00451054 File Offset: 0x0044F254
		private bool OnCreateGameButtonClicked(IXUIButton button)
		{
			DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowCustomModeCreateHandler();
			return true;
		}

		// Token: 0x06010F72 RID: 69490 RVA: 0x00451074 File Offset: 0x0044F274
		private bool OnMyGameButtonClicked(IXUIButton button)
		{
			bool flag = this._doc.SelfCustomData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._doc.CurrentCustomData = this._doc.SelfCustomData;
				DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowCustomModeDetailHandler();
				result = true;
			}
			return result;
		}

		// Token: 0x06010F73 RID: 69491 RVA: 0x004510C0 File Offset: 0x0044F2C0
		private bool OnRefreshButtonClicked(IXUIButton button)
		{
			this._doc.SendCustomBattleQueryCustomModeList(this._doc.QueryCross);
			this._doc.SendCustomBattleQueryCustomModeSelfInfo();
			this._input.SetText("");
			return true;
		}

		// Token: 0x06010F74 RID: 69492 RVA: 0x00451107 File Offset: 0x0044F307
		private void OnShowOtherClicked(IXUISprite sp)
		{
			this._doc.QueryCross = !this._doc.QueryCross;
			this._show_flag.gameObject.SetActive(this._doc.QueryCross);
			this.OnRefreshButtonClicked(null);
		}

		// Token: 0x06010F75 RID: 69493 RVA: 0x00451148 File Offset: 0x0044F348
		private bool OnJoinButtonClicked(IXUIButton button)
		{
			bool flag = (int)button.ID >= this.wrapCount;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this._doc.SelfCustomData != null;
				if (flag2)
				{
					bool flag3 = button.ID == 0UL;
					if (flag3)
					{
						this._doc.CurrentCustomData = this._doc.SelfCustomData;
						this._doc.SendCustomBattleJoin(this._doc.SelfCustomData.gameID, this._doc.SelfCustomData.hasPassword, "");
					}
					else
					{
						this._doc.CurrentCustomData = this._doc.CustomList[(int)button.ID - 1];
						this._doc.SendCustomBattleJoin(this._doc.CustomList[(int)button.ID - 1].gameID, this._doc.CustomList[(int)button.ID - 1].hasPassword, "");
					}
				}
				else
				{
					this._doc.CurrentCustomData = this._doc.CustomList[(int)button.ID];
					this._doc.SendCustomBattleJoin(this._doc.CustomList[(int)button.ID].gameID, this._doc.CustomList[(int)button.ID].hasPassword, "");
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06010F76 RID: 69494 RVA: 0x004512D0 File Offset: 0x0044F4D0
		private bool OnDetailButtonClicked(IXUIButton button)
		{
			this.ShowDetailByIndex((int)button.ID);
			return true;
		}

		// Token: 0x06010F77 RID: 69495 RVA: 0x004512F4 File Offset: 0x0044F4F4
		public bool ShowDetailByIndex(int index)
		{
			bool flag = index >= this.wrapCount;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this._doc.SelfCustomData != null;
				if (flag2)
				{
					bool flag3 = index == 0;
					if (flag3)
					{
						this._doc.CurrentCustomData = this._doc.SelfCustomData;
					}
					else
					{
						this._doc.CurrentCustomData = this._doc.CustomList[index - 1];
					}
				}
				else
				{
					this._doc.CurrentCustomData = this._doc.CustomList[index];
				}
				DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowCustomModeDetailHandler();
				result = true;
			}
			return result;
		}

		// Token: 0x06010F78 RID: 69496 RVA: 0x0045139C File Offset: 0x0044F59C
		public void ShowSelfDetail()
		{
			this._doc.CurrentCustomData = this._doc.SelfCustomData;
			DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowCustomModeDetailHandler();
		}

		// Token: 0x04007CFD RID: 31997
		private XCustomBattleDocument _doc = null;

		// Token: 0x04007CFE RID: 31998
		private IXUIInput _input;

		// Token: 0x04007CFF RID: 31999
		private IXUISprite _search;

		// Token: 0x04007D00 RID: 32000
		private IXUIButton _create_game;

		// Token: 0x04007D01 RID: 32001
		private IXUIButton _my_game;

		// Token: 0x04007D02 RID: 32002
		private Transform _red_point;

		// Token: 0x04007D03 RID: 32003
		private IXUIButton _refresh;

		// Token: 0x04007D04 RID: 32004
		private IXUISprite _show_other;

		// Token: 0x04007D05 RID: 32005
		private Transform _show_flag;

		// Token: 0x04007D06 RID: 32006
		private Transform _empty_game;

		// Token: 0x04007D07 RID: 32007
		private IXUIScrollView _scroll_view;

		// Token: 0x04007D08 RID: 32008
		private IXUIWrapContent _wrap_content;
	}
}

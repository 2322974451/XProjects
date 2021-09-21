using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI.CustomBattle
{
	// Token: 0x02001933 RID: 6451
	internal class CustomBattleCustomModeDetailHandler : DlgHandlerBase
	{
		// Token: 0x17003B28 RID: 15144
		// (get) Token: 0x06010F55 RID: 69461 RVA: 0x0044F8B8 File Offset: 0x0044DAB8
		protected override string FileName
		{
			get
			{
				return "GameSystem/CustomBattle/CustomModeDetailFrame";
			}
		}

		// Token: 0x06010F56 RID: 69462 RVA: 0x0044F8D0 File Offset: 0x0044DAD0
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
			this._scroll_view = (base.transform.Find("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this._wrap_content = (base.transform.Find("Bg/Panel/List").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._wrap_content.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentUpdated));
			this._selfinfo_rankimage = (base.transform.Find("Bg/MyInfo/RankImage").GetComponent("XUISprite") as IXUISprite);
			this._selfinfo_rank = (base.transform.Find("Bg/MyInfo/Rank").GetComponent("XUILabel") as IXUILabel);
			this._selfinfo_name = (base.transform.Find("Bg/MyInfo/Name").GetComponent("XUILabel") as IXUILabel);
			this._selfinfo_point = (base.transform.Find("Bg/MyInfo/Point").GetComponent("XUILabel") as IXUILabel);
			this._selfinfo_reward = (base.transform.Find("Bg/MyInfo/Reward").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this._game_info_button = (base.transform.Find("Bg/GameInfo/Info").GetComponent("XUISprite") as IXUISprite);
			this._game_type = (base.transform.Find("Bg/GameInfo/Type").GetComponent("XUILabel") as IXUILabel);
			this._game_name = (base.transform.Find("Bg/GameInfo/Name").GetComponent("XUILabel") as IXUILabel);
			this._game_id = (base.transform.Find("Bg/GameInfo/ID").GetComponent("XUILabel") as IXUILabel);
			this._game_creater = (base.transform.Find("Bg/GameInfo/Creater").GetComponent("XUILabel") as IXUILabel);
			this._game_size = (base.transform.Find("Bg/GameInfo/Size").GetComponent("XUILabel") as IXUILabel);
			this._game_time = (base.transform.Find("Bg/GameInfo/Slider/Time").GetComponent("XUILabel") as IXUILabel);
			this._game_time_tip = (base.transform.Find("Bg/GameInfo/Slider/Time/T").GetComponent("XUILabel") as IXUILabel);
			this._game_time_slider = base.transform.Find("Bg/GameInfo/Slider");
			this._left_time = new XLeftTimeCounter(this._game_time, false);
			this._game_match = (base.transform.Find("Bg/GameInfo/BtnStart").GetComponent("XUIButton") as IXUIButton);
			this._game_join = (base.transform.Find("Bg/GameInfo/BtnJoin").GetComponent("XUIButton") as IXUIButton);
			this._game_exit = (base.transform.Find("Bg/GameInfo/BtnExit").GetComponent("XUIButton") as IXUIButton);
			this._game_box = (base.transform.Find("Bg/GameInfo/Box").GetComponent("XUISprite") as IXUISprite);
			this._game_box_time = (base.transform.Find("Bg/GameInfo/Box/Time").GetComponent("XUILabel") as IXUILabel);
			this._game_notice = (base.transform.Find("Bg/GameInfo/Notice").GetComponent("XUILabel") as IXUILabel);
			this._can_fetch = (base.transform.Find("Bg/GameInfo/Box/CanFetch").GetComponent("XUILabel") as IXUILabel);
			this._box_left_time = new XLeftTimeCounter(this._game_box_time, true);
			this._fx_point = base.transform.Find("Bg/GameInfo/Box/Fx");
			this._back = (base.transform.Find("Bg/Back").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x06010F57 RID: 69463 RVA: 0x0044FCB0 File Offset: 0x0044DEB0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._game_info_button.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGameInfoButtonClicked));
			this._game_match.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGameMatchButtonClicked));
			this._game_join.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGameJoinButtonClicked));
			this._game_exit.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGameExitButtonClicked));
			this._game_box.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGameBoxClicked));
			this._back.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBackButtonClicked));
		}

		// Token: 0x06010F58 RID: 69464 RVA: 0x0044FD55 File Offset: 0x0044DF55
		protected override void OnHide()
		{
			this._doc.DestoryFx(this._fx);
			this._fx = null;
			base.OnHide();
		}

		// Token: 0x06010F59 RID: 69465 RVA: 0x0044FD78 File Offset: 0x0044DF78
		public override void OnUnload()
		{
			this._doc.DestoryFx(this._fx);
			this._fx = null;
			base.OnUnload();
		}

		// Token: 0x06010F5A RID: 69466 RVA: 0x0044FD9B File Offset: 0x0044DF9B
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.SendCustomBattleSearchCustomModeList(this._doc.CurrentCustomData.gameID);
			this._doc.SendCustomBattleQueryCustomModeSelfInfo();
			this.RefreshData();
		}

		// Token: 0x06010F5B RID: 69467 RVA: 0x0044FDD4 File Offset: 0x0044DFD4
		public override void RefreshData()
		{
			base.RefreshData();
			CustomBattleTable.RowData customBattleData = this._doc.GetCustomBattleData(this._doc.CurrentCustomData.configID);
			bool flag = customBattleData == null || this._doc.CurrentCustomData == null;
			if (!flag)
			{
				this._game_type.SetText(customBattleData.desc);
				this._game_name.SetText(this._doc.CurrentCustomData.gameName);
				this._game_id.SetText(this._doc.CurrentCustomData.token);
				this._game_creater.SetText(this._doc.CurrentCustomData.gameCreator);
				this._game_size.SetText(this._doc.CurrentCustomData.joinText);
				this._doc.DestoryFx(this._fx);
				this._fx = null;
				bool flag2 = this._doc.SelfCustomData != null && this._doc.CurrentCustomData.gameID == this._doc.SelfCustomData.gameID;
				switch (this._doc.CurrentCustomData.gameStatus)
				{
				case CustomBattleState.CustomBattle_Ready:
					this._game_box.SetVisible(false);
					this._game_match.SetVisible(false);
					this._game_time_slider.gameObject.SetActive(true);
					this._game_time_tip.SetText(XSingleton<XStringTable>.singleton.GetString("WaitForStart"));
					this._left_time.SetLeftTime(this._doc.CurrentCustomData.gameStartLeftTime, -1);
					this._game_exit.SetVisible(flag2);
					this._game_join.SetVisible(!flag2);
					this._game_notice.SetText(flag2 ? XSingleton<XStringTable>.singleton.GetString("WaitForShowMatch") : "");
					break;
				case CustomBattleState.CustomBattle_Going:
					this._game_box.SetVisible(false);
					this._game_time_slider.gameObject.SetActive(true);
					this._game_time_tip.SetText(XSingleton<XStringTable>.singleton.GetString("WaitForEnd"));
					this._left_time.SetLeftTime(this._doc.CurrentCustomData.gameEndLeftTime, -1);
					this._game_match.SetVisible(flag2);
					this._game_exit.SetVisible(flag2);
					this._game_join.SetVisible(!flag2);
					this._game_notice.SetText("");
					break;
				case CustomBattleState.CustomBattle_End:
				{
					CustomBattleRoleState selfStatus = this._doc.CurrentCustomData.selfStatus;
					if (selfStatus != CustomBattleRoleState.CustomBattle_RoleState_Reward)
					{
						if (selfStatus != CustomBattleRoleState.Custombattle_RoleState_Taken)
						{
							this._game_box.SetVisible(false);
							this._game_match.SetVisible(false);
							this._game_join.SetVisible(false);
							this._game_exit.SetVisible(false);
							this._game_time_slider.gameObject.SetActive(false);
							this._game_notice.SetText(XSingleton<XStringTable>.singleton.GetString("GameEnd"));
						}
						else
						{
							this._game_box.SetVisible(false);
							this._game_match.SetVisible(false);
							this._game_join.SetVisible(false);
							this._game_exit.SetVisible(flag2);
							this._game_time_slider.gameObject.SetActive(false);
							this._game_notice.SetText(XSingleton<XStringTable>.singleton.GetString("GameEnd"));
						}
					}
					else
					{
						this._game_box.SetVisible(flag2);
						this._game_match.SetVisible(false);
						this._game_join.SetVisible(false);
						this._game_exit.SetVisible(flag2);
						this._game_time_slider.gameObject.SetActive(false);
						this._can_fetch.SetVisible(this._doc.CurrentCustomData.boxLeftTime <= 0U);
						this._box_left_time.SetLeftTime(this._doc.CurrentCustomData.boxLeftTime, -1);
						bool flag3 = this._doc.CurrentCustomData.boxLeftTime <= 0U;
						if (flag3)
						{
							this._fx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_BountyModeListFrame_Clip01", this._fx_point, false);
						}
						this._game_notice.SetText(flag2 ? "" : XSingleton<XStringTable>.singleton.GetString("GameEnd"));
					}
					break;
				}
				case CustomBattleState.CustomBattle_Destory:
					this._game_box.SetVisible(false);
					this._game_match.SetVisible(false);
					this._game_join.SetVisible(false);
					this._game_exit.SetVisible(false);
					this._game_time_slider.gameObject.SetActive(false);
					this._game_notice.SetText(XSingleton<XStringTable>.singleton.GetString("GameEnd"));
					break;
				}
				bool flag4 = this._doc.SelfCustomData != null && this._doc.CurrentCustomData.gameID == this._doc.SelfCustomData.gameID;
				if (flag4)
				{
				}
				this._wrap_content.SetContentCount(this._doc.CurrentCustomData.rankList.Count, false);
				this._scroll_view.ResetPosition();
				this.SetupSelf();
			}
		}

		// Token: 0x06010F5C RID: 69468 RVA: 0x0045031C File Offset: 0x0044E51C
		private void WrapContentUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this._doc.CurrentCustomData.rankList.Count;
			if (flag)
			{
				t.gameObject.SetActive(false);
			}
			else
			{
				this.SetupRank(t, index);
			}
		}

		// Token: 0x06010F5D RID: 69469 RVA: 0x0045036C File Offset: 0x0044E56C
		private void SetupRank(Transform t, int index)
		{
			IXUISprite ixuisprite = t.Find("RankImage").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = t.Find("Rank").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite2 = t.Find("ViewBattle").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel2 = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = t.Find("Point").GetComponent("XUILabel") as IXUILabel;
			IXUILabelSymbol ixuilabelSymbol = t.Find("Reward").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			CustomBattleRank customBattleRank = this._doc.CurrentCustomData.rankList[index];
			ixuisprite.SetVisible(index < 3);
			ixuilabel.SetVisible(index >= 3);
			ixuisprite2.SetVisible(false);
			ixuisprite.SetSprite(string.Format("N{0}", index + 1));
			ixuilabel.SetText((index + 1).ToString());
			ixuilabel2.SetText(customBattleRank.name);
			ixuilabel3.SetText(customBattleRank.point.ToString());
			SeqListRef<uint> customBattleRewardByRank = this._doc.GetCustomBattleRewardByRank(this._doc.CurrentCustomData.configID, (uint)(index + 1));
			string text = "";
			for (int i = 0; i < customBattleRewardByRank.Count; i++)
			{
				text = string.Concat(new string[]
				{
					text,
					(i == 0) ? "" : " ",
					XLabelSymbolHelper.FormatSmallIcon((int)customBattleRewardByRank[i, 0]),
					" ",
					customBattleRewardByRank[i, 1].ToString()
				});
			}
			ixuilabelSymbol.InputText = text;
		}

		// Token: 0x06010F5E RID: 69470 RVA: 0x00450550 File Offset: 0x0044E750
		private void SetupSelf()
		{
			bool flag = this._doc.CurrentCustomData.selfRank == 0U;
			if (flag)
			{
				this._selfinfo_rankimage.SetSprite("");
				this._selfinfo_rank.SetText("");
				this._selfinfo_name.SetText("");
				this._selfinfo_point.SetText("");
				this._selfinfo_reward.InputText = "";
			}
			else
			{
				this._selfinfo_rankimage.SetVisible(this._doc.CurrentCustomData.selfRank <= 3U);
				this._selfinfo_rank.SetVisible(this._doc.CurrentCustomData.selfRank > 3U);
				this._selfinfo_rankimage.SetSprite(string.Format("N{0}", this._doc.CurrentCustomData.selfRank));
				this._selfinfo_rank.SetText(this._doc.CurrentCustomData.selfRank.ToString());
				this._selfinfo_name.SetText(XSingleton<XAttributeMgr>.singleton.XPlayerData.Name);
				this._selfinfo_point.SetText(this._doc.CurrentCustomData.selfPoint.ToString());
				SeqListRef<uint> customBattleRewardByRank = this._doc.GetCustomBattleRewardByRank(this._doc.CurrentCustomData.configID, this._doc.CurrentCustomData.selfRank);
				string text = "";
				for (int i = 0; i < customBattleRewardByRank.Count; i++)
				{
					text = string.Concat(new string[]
					{
						text,
						(i == 0) ? "" : " ",
						XLabelSymbolHelper.FormatSmallIcon((int)customBattleRewardByRank[i, 0]),
						" ",
						customBattleRewardByRank[i, 1].ToString()
					});
				}
				this._selfinfo_reward.InputText = text;
			}
		}

		// Token: 0x06010F5F RID: 69471 RVA: 0x00450745 File Offset: 0x0044E945
		private void OnGameInfoButtonClicked(IXUISprite sp)
		{
			DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowCustomModeBriefHandler();
		}

		// Token: 0x06010F60 RID: 69472 RVA: 0x00450754 File Offset: 0x0044E954
		private bool OnGameMatchButtonClicked(IXUIButton button)
		{
			bool flag = this._doc.CurrentCustomData.expID == 0;
			if (flag)
			{
				bool flag2 = XTeamDocument.GoSingleBattleBeforeNeed(new ButtonClickEventHandler(this.OnGameMatchButtonClicked), button);
				if (flag2)
				{
					return true;
				}
				this._doc.SendCustomBattleMatch(this._doc.CurrentCustomData.gameID);
			}
			else
			{
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				specificDocument.SetAndMatch(this._doc.CurrentCustomData.expID);
			}
			return true;
		}

		// Token: 0x06010F61 RID: 69473 RVA: 0x004507DC File Offset: 0x0044E9DC
		private bool OnGameJoinButtonClicked(IXUIButton button)
		{
			this._doc.SendCustomBattleJoin(this._doc.CurrentCustomData.gameID, this._doc.CurrentCustomData.hasPassword, "");
			return true;
		}

		// Token: 0x06010F62 RID: 69474 RVA: 0x00450820 File Offset: 0x0044EA20
		private bool OnGameExitButtonClicked(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("UnJoinCustomModeTip"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnUnJoinOkClicked));
			return true;
		}

		// Token: 0x06010F63 RID: 69475 RVA: 0x00450868 File Offset: 0x0044EA68
		private bool OnUnJoinOkClicked(IXUIButton button)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this._doc.SendCustomBattleExit(this._doc.CurrentCustomData.gameID);
			return true;
		}

		// Token: 0x06010F64 RID: 69476 RVA: 0x0044C83C File Offset: 0x0044AA3C
		private void OnGameBoxClicked(IXUISprite sp)
		{
			DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowChestHandler();
		}

		// Token: 0x06010F65 RID: 69477 RVA: 0x004508A4 File Offset: 0x0044EAA4
		private bool OnBackButtonClicked(IXUIButton button)
		{
			DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowCustomModeListHandler();
			return true;
		}

		// Token: 0x06010F66 RID: 69478 RVA: 0x004508C2 File Offset: 0x0044EAC2
		public override void OnUpdate()
		{
			base.OnUpdate();
			this._left_time.Update();
			this._box_left_time.Update();
		}

		// Token: 0x04007CE0 RID: 31968
		private XCustomBattleDocument _doc = null;

		// Token: 0x04007CE1 RID: 31969
		private IXUIScrollView _scroll_view;

		// Token: 0x04007CE2 RID: 31970
		private IXUIWrapContent _wrap_content;

		// Token: 0x04007CE3 RID: 31971
		private IXUISprite _selfinfo_rankimage;

		// Token: 0x04007CE4 RID: 31972
		private IXUILabel _selfinfo_rank;

		// Token: 0x04007CE5 RID: 31973
		private IXUILabel _selfinfo_name;

		// Token: 0x04007CE6 RID: 31974
		private IXUILabel _selfinfo_point;

		// Token: 0x04007CE7 RID: 31975
		private IXUILabelSymbol _selfinfo_reward;

		// Token: 0x04007CE8 RID: 31976
		private IXUISprite _game_info_button;

		// Token: 0x04007CE9 RID: 31977
		private IXUILabel _game_type;

		// Token: 0x04007CEA RID: 31978
		private IXUILabel _game_name;

		// Token: 0x04007CEB RID: 31979
		private IXUILabel _game_id;

		// Token: 0x04007CEC RID: 31980
		private IXUILabel _game_creater;

		// Token: 0x04007CED RID: 31981
		private IXUILabel _game_size;

		// Token: 0x04007CEE RID: 31982
		private IXUILabel _game_time;

		// Token: 0x04007CEF RID: 31983
		private IXUILabel _game_time_tip;

		// Token: 0x04007CF0 RID: 31984
		private Transform _game_time_slider;

		// Token: 0x04007CF1 RID: 31985
		private IXUIButton _game_match;

		// Token: 0x04007CF2 RID: 31986
		private IXUIButton _game_join;

		// Token: 0x04007CF3 RID: 31987
		private IXUIButton _game_exit;

		// Token: 0x04007CF4 RID: 31988
		private IXUISprite _game_box;

		// Token: 0x04007CF5 RID: 31989
		private IXUILabel _game_notice;

		// Token: 0x04007CF6 RID: 31990
		private IXUILabel _game_box_time;

		// Token: 0x04007CF7 RID: 31991
		private IXUILabel _can_fetch;

		// Token: 0x04007CF8 RID: 31992
		private Transform _fx_point;

		// Token: 0x04007CF9 RID: 31993
		private XLeftTimeCounter _left_time;

		// Token: 0x04007CFA RID: 31994
		private XLeftTimeCounter _box_left_time;

		// Token: 0x04007CFB RID: 31995
		private IXUIButton _back;

		// Token: 0x04007CFC RID: 31996
		private XFx _fx;
	}
}

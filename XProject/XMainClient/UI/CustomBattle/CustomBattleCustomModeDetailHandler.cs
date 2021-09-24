using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI.CustomBattle
{

	internal class CustomBattleCustomModeDetailHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/CustomBattle/CustomModeDetailFrame";
			}
		}

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

		protected override void OnHide()
		{
			this._doc.DestoryFx(this._fx);
			this._fx = null;
			base.OnHide();
		}

		public override void OnUnload()
		{
			this._doc.DestoryFx(this._fx);
			this._fx = null;
			base.OnUnload();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc.SendCustomBattleSearchCustomModeList(this._doc.CurrentCustomData.gameID);
			this._doc.SendCustomBattleQueryCustomModeSelfInfo();
			this.RefreshData();
		}

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

		private void OnGameInfoButtonClicked(IXUISprite sp)
		{
			DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowCustomModeBriefHandler();
		}

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

		private bool OnGameJoinButtonClicked(IXUIButton button)
		{
			this._doc.SendCustomBattleJoin(this._doc.CurrentCustomData.gameID, this._doc.CurrentCustomData.hasPassword, "");
			return true;
		}

		private bool OnGameExitButtonClicked(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("UnJoinCustomModeTip"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnUnJoinOkClicked));
			return true;
		}

		private bool OnUnJoinOkClicked(IXUIButton button)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this._doc.SendCustomBattleExit(this._doc.CurrentCustomData.gameID);
			return true;
		}

		private void OnGameBoxClicked(IXUISprite sp)
		{
			DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowChestHandler();
		}

		private bool OnBackButtonClicked(IXUIButton button)
		{
			DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowCustomModeListHandler();
			return true;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this._left_time.Update();
			this._box_left_time.Update();
		}

		private XCustomBattleDocument _doc = null;

		private IXUIScrollView _scroll_view;

		private IXUIWrapContent _wrap_content;

		private IXUISprite _selfinfo_rankimage;

		private IXUILabel _selfinfo_rank;

		private IXUILabel _selfinfo_name;

		private IXUILabel _selfinfo_point;

		private IXUILabelSymbol _selfinfo_reward;

		private IXUISprite _game_info_button;

		private IXUILabel _game_type;

		private IXUILabel _game_name;

		private IXUILabel _game_id;

		private IXUILabel _game_creater;

		private IXUILabel _game_size;

		private IXUILabel _game_time;

		private IXUILabel _game_time_tip;

		private Transform _game_time_slider;

		private IXUIButton _game_match;

		private IXUIButton _game_join;

		private IXUIButton _game_exit;

		private IXUISprite _game_box;

		private IXUILabel _game_notice;

		private IXUILabel _game_box_time;

		private IXUILabel _can_fetch;

		private Transform _fx_point;

		private XLeftTimeCounter _left_time;

		private XLeftTimeCounter _box_left_time;

		private IXUIButton _back;

		private XFx _fx;
	}
}

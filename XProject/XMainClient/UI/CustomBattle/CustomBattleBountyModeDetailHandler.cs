using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI.CustomBattle
{

	internal class CustomBattleBountyModeDetailHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/CustomBattle/BountyModeDetailFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
			this._close = (base.transform.Find("Bg/Close").GetComponent("XUISprite") as IXUISprite);
			this._title = (base.transform.Find("Bg/Title").GetComponent("XUILabel") as IXUILabel);
			this._win_count = (base.transform.Find("Bg/Left/Win/Count").GetComponent("XUILabel") as IXUILabel);
			for (int i = 0; i < 3; i++)
			{
				this._fail_flag[i] = (base.transform.Find(string.Format("Bg/Left/Fail/Fail{0}/Flag", i)).GetComponent("XUISprite") as IXUISprite);
			}
			this._slider = (base.transform.Find("Bg/Left/Slider").GetComponent("XUISlider") as IXUISlider);
			this._slider_count = (base.transform.Find("Bg/Left/Slider/Count").GetComponent("XUILabel") as IXUILabel);
			this._reward_frame = base.transform.Find("Bg/Left/RewardTip");
			this._current_reward1 = (base.transform.Find("Bg/Left/RewardTip/Current/Reward1").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this._current_reward2 = (base.transform.Find("Bg/Left/RewardTip/Current/Reward2").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this._next_reward1 = (base.transform.Find("Bg/Left/RewardTip/Next/Reward1").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this._next_reward2 = (base.transform.Find("Bg/Left/RewardTip/Next/Reward2").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this._giveup = (base.transform.Find("Bg/Right/BtnGiveup").GetComponent("XUIButton") as IXUIButton);
			this._start = (base.transform.Find("Bg/Right/BtnStart").GetComponent("XUIButton") as IXUIButton);
			this._box = (base.transform.Find("Bg/Right/Box").GetComponent("XUISprite") as IXUISprite);
			this._box_time = (base.transform.Find("Bg/Right/Box/Time").GetComponent("XUILabel") as IXUILabel);
			this._canfetch = (base.transform.Find("Bg/Right/Box/CanFetch").GetComponent("XUILabel") as IXUILabel);
			this._fx_point = base.transform.Find("Bg/Right/Box/Fx");
			this._game_icon = (base.transform.Find("Bg/Right/GameIcon").GetComponent("XUISprite") as IXUISprite);
			this._boxCD = new XLeftTimeCounter(this._box_time, true);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
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

		public override void RefreshData()
		{
			base.RefreshData();
			this._title.SetText(this._doc.CurrentBountyData.gameName);
			this._win_count.SetText(this._doc.CurrentBountyData.winCount.ToString());
			for (int i = 0; i < 3; i++)
			{
				this._fail_flag[i].SetAlpha((float)(((long)i < (long)((ulong)this._doc.CurrentBountyData.loseCount)) ? 1 : 0));
			}
			this._slider.Value = this._doc.CurrentBountyData.winPrecent;
			this._slider_count.SetText(this._doc.CurrentBountyData.winText);
			SeqListRef<uint> systemBattleReward = this._doc.GetSystemBattleReward((uint)this._doc.CurrentBountyData.gameID, this._doc.CurrentBountyData.winCount);
			this._current_reward1.InputText = "";
			this._current_reward2.InputText = "";
			bool flag = systemBattleReward.Count > 0;
			if (flag)
			{
				this._current_reward1.InputText = XLabelSymbolHelper.FormatSmallIcon((int)systemBattleReward[0, 0]) + " " + systemBattleReward[0, 1].ToString();
			}
			bool flag2 = systemBattleReward.Count > 1;
			if (flag2)
			{
				this._current_reward2.InputText = XLabelSymbolHelper.FormatSmallIcon((int)systemBattleReward[1, 0]) + " " + systemBattleReward[1, 1].ToString();
			}
			SeqListRef<uint> systemBattleReward2 = this._doc.GetSystemBattleReward((uint)this._doc.CurrentBountyData.gameID, this._doc.CurrentBountyData.winCount + 1U);
			this._next_reward1.InputText = "";
			this._next_reward2.InputText = "";
			bool flag3 = systemBattleReward2.Count > 0;
			if (flag3)
			{
				this._next_reward1.InputText = XLabelSymbolHelper.FormatSmallIcon((int)systemBattleReward2[0, 0]) + " " + systemBattleReward2[0, 1].ToString();
			}
			else
			{
				this._next_reward1.InputText = XSingleton<XStringTable>.singleton.GetString("MaxRewardTip");
			}
			bool flag4 = systemBattleReward2.Count > 1;
			if (flag4)
			{
				this._next_reward2.InputText = XLabelSymbolHelper.FormatSmallIcon((int)systemBattleReward2[1, 0]) + " " + systemBattleReward2[1, 1].ToString();
			}
			this._doc.DestoryFx(this._fx);
			this._fx = null;
			switch (this._doc.CurrentBountyData.status)
			{
			case CustomBattleRoleState.CustomBattle_RoleState_Join:
				this._giveup.SetVisible(true);
				this._start.SetVisible(true);
				this._box.SetVisible(false);
				this._reward_frame.gameObject.SetActive(true);
				this._giveup.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGiveUpButtonClicked));
				this._start.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartButtonClicked));
				break;
			case CustomBattleRoleState.CustomBattle_RoleState_Reward:
			{
				this._giveup.SetVisible(false);
				this._start.SetVisible(false);
				this._box.SetVisible(true);
				this._boxCD.SetLeftTime(this._doc.CurrentBountyData.boxLeftTime, -1);
				this._reward_frame.gameObject.SetActive(false);
				this._canfetch.gameObject.SetActive(this._doc.CurrentBountyData.boxLeftTime <= 0U);
				bool flag5 = this._doc.CurrentBountyData.boxLeftTime <= 0U;
				if (flag5)
				{
					this._fx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_BountyModeListFrame_Clip01", this._fx_point, false);
				}
				this._box.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnBoxClicked));
				break;
			}
			case CustomBattleRoleState.Custombattle_RoleState_Taken:
				this._giveup.SetVisible(false);
				this._start.SetVisible(false);
				this._box.SetVisible(false);
				this._reward_frame.gameObject.SetActive(false);
				break;
			default:
				this._giveup.SetVisible(false);
				this._start.SetVisible(false);
				this._box.SetVisible(false);
				this._reward_frame.gameObject.SetActive(false);
				break;
			}
			CustomBattleSystemTable.RowData systemBattleData = this._doc.GetSystemBattleData((uint)this._doc.CurrentBountyData.gameID);
			bool flag6 = systemBattleData != null;
			if (flag6)
			{
				this._game_icon.SetSprite(systemBattleData.IconSpritePath);
			}
		}

		private void OnCloseClicked(IXUISprite sp)
		{
			base.SetVisible(false);
		}

		private bool OnGiveUpButtonClicked(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("UnJoinBountyModeTip"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnUnJoinOkClicked));
			return true;
		}

		private bool OnUnJoinOkClicked(IXUIButton button)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this._doc.SendCustomBattleDrop(this._doc.CurrentBountyData.gameID);
			return true;
		}

		private bool OnStartButtonClicked(IXUIButton button)
		{
			bool flag = this._doc.CurrentBountyData.expID == 0;
			if (flag)
			{
				bool flag2 = XTeamDocument.GoSingleBattleBeforeNeed(new ButtonClickEventHandler(this.OnStartButtonClicked), button);
				if (flag2)
				{
					return true;
				}
				this._doc.SendCustomBattleMatch(this._doc.CurrentBountyData.gameID);
			}
			else
			{
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				specificDocument.SetAndMatch(this._doc.CurrentBountyData.expID);
			}
			return true;
		}

		private void OnBoxClicked(IXUISprite sp)
		{
			DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowChestHandler();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this._boxCD.Update();
		}

		private XCustomBattleDocument _doc = null;

		private IXUISprite _close;

		private IXUILabel _title;

		private IXUILabel _win_count;

		private IXUISprite[] _fail_flag = new IXUISprite[3];

		private IXUISlider _slider;

		private IXUILabel _slider_count;

		private Transform _reward_frame;

		private IXUILabelSymbol _current_reward1;

		private IXUILabelSymbol _current_reward2;

		private IXUILabelSymbol _next_reward1;

		private IXUILabelSymbol _next_reward2;

		private IXUIButton _giveup;

		private IXUIButton _start;

		private IXUISprite _box;

		private IXUILabel _box_time;

		private IXUISprite _game_icon;

		private XLeftTimeCounter _boxCD;

		private IXUILabel _canfetch;

		private Transform _fx_point;

		private XFx _fx = null;
	}
}

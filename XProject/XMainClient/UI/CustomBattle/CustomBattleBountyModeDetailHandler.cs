using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI.CustomBattle
{
	// Token: 0x0200192E RID: 6446
	internal class CustomBattleBountyModeDetailHandler : DlgHandlerBase
	{
		// Token: 0x17003B23 RID: 15139
		// (get) Token: 0x06010F00 RID: 69376 RVA: 0x0044BF04 File Offset: 0x0044A104
		protected override string FileName
		{
			get
			{
				return "GameSystem/CustomBattle/BountyModeDetailFrame";
			}
		}

		// Token: 0x06010F01 RID: 69377 RVA: 0x0044BF1C File Offset: 0x0044A11C
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

		// Token: 0x06010F02 RID: 69378 RVA: 0x0044C1EE File Offset: 0x0044A3EE
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x06010F03 RID: 69379 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x06010F04 RID: 69380 RVA: 0x0044C210 File Offset: 0x0044A410
		protected override void OnHide()
		{
			this._doc.DestoryFx(this._fx);
			this._fx = null;
			base.OnHide();
		}

		// Token: 0x06010F05 RID: 69381 RVA: 0x0044C233 File Offset: 0x0044A433
		public override void OnUnload()
		{
			this._doc.DestoryFx(this._fx);
			this._fx = null;
			base.OnUnload();
		}

		// Token: 0x06010F06 RID: 69382 RVA: 0x0044C258 File Offset: 0x0044A458
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

		// Token: 0x06010F07 RID: 69383 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void OnCloseClicked(IXUISprite sp)
		{
			base.SetVisible(false);
		}

		// Token: 0x06010F08 RID: 69384 RVA: 0x0044C730 File Offset: 0x0044A930
		private bool OnGiveUpButtonClicked(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("UnJoinBountyModeTip"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnUnJoinOkClicked));
			return true;
		}

		// Token: 0x06010F09 RID: 69385 RVA: 0x0044C778 File Offset: 0x0044A978
		private bool OnUnJoinOkClicked(IXUIButton button)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this._doc.SendCustomBattleDrop(this._doc.CurrentBountyData.gameID);
			return true;
		}

		// Token: 0x06010F0A RID: 69386 RVA: 0x0044C7B4 File Offset: 0x0044A9B4
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

		// Token: 0x06010F0B RID: 69387 RVA: 0x0044C83C File Offset: 0x0044AA3C
		private void OnBoxClicked(IXUISprite sp)
		{
			DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowChestHandler();
		}

		// Token: 0x06010F0C RID: 69388 RVA: 0x0044C84A File Offset: 0x0044AA4A
		public override void OnUpdate()
		{
			base.OnUpdate();
			this._boxCD.Update();
		}

		// Token: 0x04007C84 RID: 31876
		private XCustomBattleDocument _doc = null;

		// Token: 0x04007C85 RID: 31877
		private IXUISprite _close;

		// Token: 0x04007C86 RID: 31878
		private IXUILabel _title;

		// Token: 0x04007C87 RID: 31879
		private IXUILabel _win_count;

		// Token: 0x04007C88 RID: 31880
		private IXUISprite[] _fail_flag = new IXUISprite[3];

		// Token: 0x04007C89 RID: 31881
		private IXUISlider _slider;

		// Token: 0x04007C8A RID: 31882
		private IXUILabel _slider_count;

		// Token: 0x04007C8B RID: 31883
		private Transform _reward_frame;

		// Token: 0x04007C8C RID: 31884
		private IXUILabelSymbol _current_reward1;

		// Token: 0x04007C8D RID: 31885
		private IXUILabelSymbol _current_reward2;

		// Token: 0x04007C8E RID: 31886
		private IXUILabelSymbol _next_reward1;

		// Token: 0x04007C8F RID: 31887
		private IXUILabelSymbol _next_reward2;

		// Token: 0x04007C90 RID: 31888
		private IXUIButton _giveup;

		// Token: 0x04007C91 RID: 31889
		private IXUIButton _start;

		// Token: 0x04007C92 RID: 31890
		private IXUISprite _box;

		// Token: 0x04007C93 RID: 31891
		private IXUILabel _box_time;

		// Token: 0x04007C94 RID: 31892
		private IXUISprite _game_icon;

		// Token: 0x04007C95 RID: 31893
		private XLeftTimeCounter _boxCD;

		// Token: 0x04007C96 RID: 31894
		private IXUILabel _canfetch;

		// Token: 0x04007C97 RID: 31895
		private Transform _fx_point;

		// Token: 0x04007C98 RID: 31896
		private XFx _fx = null;
	}
}

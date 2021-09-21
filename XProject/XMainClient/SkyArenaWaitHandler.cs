using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CB1 RID: 3249
	internal class SkyArenaWaitHandler : DlgHandlerBase
	{
		// Token: 0x0600B6DF RID: 46815 RVA: 0x00245460 File Offset: 0x00243660
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XSkyArenaEntranceDocument>(XSkyArenaEntranceDocument.uuID);
			this.doc.WaitHandler = this;
			this.m_Bg = base.transform.FindChild("Bg");
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUISprite") as IXUISprite);
			this.m_MapName = (base.transform.FindChild("Bg/MapName").GetComponent("XUILabel") as IXUILabel);
			this.m_Info = (base.transform.FindChild("Bg/Help/Info").GetComponent("XUILabel") as IXUILabel);
			this.m_Text = (base.transform.FindChild("Bg/Help/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_RewardBtn = (base.transform.FindChild("Bg/Reward").GetComponent("XUIButton") as IXUIButton);
			this._CDCounter = new XLeftTimeCounter(this.m_Info, false);
			this.m_Text.SetText("");
			this.m_Info.SetText("");
		}

		// Token: 0x17003252 RID: 12882
		// (get) Token: 0x0600B6E0 RID: 46816 RVA: 0x002455BC File Offset: 0x002437BC
		protected override string FileName
		{
			get
			{
				return "GameSystem/SkyArena/SkyArenaReadyArea";
			}
		}

		// Token: 0x0600B6E1 RID: 46817 RVA: 0x002455D4 File Offset: 0x002437D4
		public override void RegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			this.m_Help.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHelpClicked));
			this.m_RewardBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRewardClicked));
		}

		// Token: 0x0600B6E2 RID: 46818 RVA: 0x0024562C File Offset: 0x0024382C
		public bool OnCloseClicked(IXUIButton btn)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool bInTeam = specificDocument.bInTeam;
			string @string;
			if (bInTeam)
			{
				@string = XStringDefineProxy.GetString("SKY_ARENA_LEAVE_TEAM_TIP");
			}
			else
			{
				@string = XStringDefineProxy.GetString("SKY_ARENA_LEAVE_SINGLE_TIP");
			}
			XSingleton<UiUtility>.singleton.ShowModalDialog(@string, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._Leave));
			return true;
		}

		// Token: 0x0600B6E3 RID: 46819 RVA: 0x002456A4 File Offset: 0x002438A4
		private bool _Leave(IXUIButton btn)
		{
			this.isWaitEnd = false;
			XSingleton<XScene>.singleton.ReqLeaveScene();
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600B6E4 RID: 46820 RVA: 0x002456D4 File Offset: 0x002438D4
		private void OnHelpClicked(IXUISprite sp)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SKYCITY_WAITING;
			if (flag)
			{
				DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_MulActivity_SkyArena);
			}
			bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HORSE;
			if (flag2)
			{
				DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_MulActivity_Race);
			}
			bool flag3 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BIGMELEE_READY;
			if (flag3)
			{
				DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_BigMelee);
			}
			bool flag4 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BATTLEFIELD_READY;
			if (flag4)
			{
				DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Battlefield);
			}
		}

		// Token: 0x0600B6E5 RID: 46821 RVA: 0x00245774 File Offset: 0x00243974
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshMapName(0);
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SKYCITY_WAITING;
			if (flag)
			{
				this.m_RewardBtn.gameObject.SetActive(true);
			}
			else
			{
				this.m_RewardBtn.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600B6E6 RID: 46822 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B6E7 RID: 46823 RVA: 0x002457CD File Offset: 0x002439CD
		public override void OnUnload()
		{
			this.isLeftTime = true;
			this.doc.WaitHandler = null;
			DlgHandlerBase.EnsureUnload<PointRewardHandler>(ref this._PointRewardHandler);
			base.OnUnload();
		}

		// Token: 0x0600B6E8 RID: 46824 RVA: 0x002457F6 File Offset: 0x002439F6
		public override void OnUpdate()
		{
			base.OnUpdate();
			this._CDCounter.Update();
		}

		// Token: 0x0600B6E9 RID: 46825 RVA: 0x0024580C File Offset: 0x00243A0C
		public void RefreshMapName(int param = 0)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BIGMELEE_READY;
			if (flag)
			{
				XBigMeleeEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XBigMeleeEntranceDocument>(XBigMeleeEntranceDocument.uuID);
				this.m_MapName.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("BIG_MELEE_WAIT_TITLE"), specificDocument.GroupID));
			}
			bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BATTLEFIELD_READY;
			if (flag2)
			{
				this.m_MapName.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("BATTLEFIELD_WAIT_TITLE"), param));
			}
			else
			{
				this.m_MapName.SetText(XSingleton<XScene>.singleton.SceneData.Comment);
			}
		}

		// Token: 0x0600B6EA RID: 46826 RVA: 0x002458C0 File Offset: 0x00243AC0
		public void StartTime(uint time)
		{
			bool flag = this.isLeftTime;
			if (flag)
			{
				this._CDCounter.SetLeftTime(time, -1);
				this._CDCounter.SetFinishEventHandler(new TimeOverFinishEventHandler(this._OnLeftTimeOver), null);
				this.m_Text.SetText(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_BATTLE_LEFTTIME"));
				XSingleton<XDebug>.singleton.AddGreenLog("Time:" + time, null, null, null, null, null);
			}
		}

		// Token: 0x0600B6EB RID: 46827 RVA: 0x00245940 File Offset: 0x00243B40
		private void _OnLeftTimeOver(object o)
		{
			this.isLeftTime = false;
			bool flag = this.isWaitEnd;
			if (flag)
			{
				this.m_Text.SetText(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_MATCHING_END"));
			}
			else
			{
				this.m_Text.SetText(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_MATCHING"));
			}
		}

		// Token: 0x0600B6EC RID: 46828 RVA: 0x00245997 File Offset: 0x00243B97
		public void SetWaitEnd()
		{
			this.isWaitEnd = true;
			this.m_Text.SetText(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_MATCHING_END"));
		}

		// Token: 0x0600B6ED RID: 46829 RVA: 0x002459BC File Offset: 0x00243BBC
		public void NextWaitStart()
		{
			this.isLeftTime = true;
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BATTLEFIELD_READY;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("BATTLEFIELD_NEXT_WAIT"), "fece00");
			}
		}

		// Token: 0x0600B6EE RID: 46830 RVA: 0x00245A04 File Offset: 0x00243C04
		public bool OnRewardClicked(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<PointRewardHandler>(ref this._PointRewardHandler, this.m_Bg, false, null);
			DlgBase<SkyArenaEntranceView, SkyArenaEntranceBehaviour>.singleton.OpenReward(this._PointRewardHandler);
			return true;
		}

		// Token: 0x040047A7 RID: 18343
		private XSkyArenaEntranceDocument doc = null;

		// Token: 0x040047A8 RID: 18344
		private PointRewardHandler _PointRewardHandler;

		// Token: 0x040047A9 RID: 18345
		private XLeftTimeCounter _CDCounter;

		// Token: 0x040047AA RID: 18346
		private bool isWaitEnd = false;

		// Token: 0x040047AB RID: 18347
		private bool isLeftTime = true;

		// Token: 0x040047AC RID: 18348
		private Transform m_Bg;

		// Token: 0x040047AD RID: 18349
		private IXUIButton m_Close;

		// Token: 0x040047AE RID: 18350
		private IXUISprite m_Help;

		// Token: 0x040047AF RID: 18351
		private IXUILabel m_MapName;

		// Token: 0x040047B0 RID: 18352
		private IXUILabel m_Info;

		// Token: 0x040047B1 RID: 18353
		private IXUILabel m_Text;

		// Token: 0x040047B2 RID: 18354
		private IXUIButton m_RewardBtn;
	}
}

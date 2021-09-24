using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class SkyArenaWaitHandler : DlgHandlerBase
	{

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

		protected override string FileName
		{
			get
			{
				return "GameSystem/SkyArena/SkyArenaReadyArea";
			}
		}

		public override void RegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			this.m_Help.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHelpClicked));
			this.m_RewardBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRewardClicked));
		}

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

		private bool _Leave(IXUIButton btn)
		{
			this.isWaitEnd = false;
			XSingleton<XScene>.singleton.ReqLeaveScene();
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

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

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			this.isLeftTime = true;
			this.doc.WaitHandler = null;
			DlgHandlerBase.EnsureUnload<PointRewardHandler>(ref this._PointRewardHandler);
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this._CDCounter.Update();
		}

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

		public void SetWaitEnd()
		{
			this.isWaitEnd = true;
			this.m_Text.SetText(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_MATCHING_END"));
		}

		public void NextWaitStart()
		{
			this.isLeftTime = true;
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BATTLEFIELD_READY;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("BATTLEFIELD_NEXT_WAIT"), "fece00");
			}
		}

		public bool OnRewardClicked(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<PointRewardHandler>(ref this._PointRewardHandler, this.m_Bg, false, null);
			DlgBase<SkyArenaEntranceView, SkyArenaEntranceBehaviour>.singleton.OpenReward(this._PointRewardHandler);
			return true;
		}

		private XSkyArenaEntranceDocument doc = null;

		private PointRewardHandler _PointRewardHandler;

		private XLeftTimeCounter _CDCounter;

		private bool isWaitEnd = false;

		private bool isLeftTime = true;

		private Transform m_Bg;

		private IXUIButton m_Close;

		private IXUISprite m_Help;

		private IXUILabel m_MapName;

		private IXUILabel m_Info;

		private IXUILabel m_Text;

		private IXUIButton m_RewardBtn;
	}
}

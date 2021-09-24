using System;
using UILib;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class BattleDramaDlg : DlgBase<BattleDramaDlg, BattleDramaDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/BattleDramaDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool exclusive
		{
			get
			{
				return true;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override void RegisterEvent()
		{
			IXUISprite ixuisprite = base.uiBehaviour.m_TaskArea.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.GotoNextTalk));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("BattleDramaDlg");
			XSingleton<XLevelAIMgr>.singleton.EnableAllAI(false);
			bool autoPlayOn = XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.AutoPlayOn;
			if (autoPlayOn)
			{
				float interval = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("CloseDramaDlgTime"));
				this._close_timer = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.AutoClose), null);
			}
		}

		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<X3DAvatarMgr>.singleton.ClearDummy(this.m_dummPool);
			XSingleton<XTutorialHelper>.singleton.BattleNPCTalkEnd = true;
			XSingleton<XLevelAIMgr>.singleton.EnableAllAI(true);
			this.leftTalker = "";
			this.rightTalker = "";
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
			bool flag = base.uiBehaviour.m_rightSnapshot != null;
			if (flag)
			{
				base.uiBehaviour.m_rightSnapshot.RefreshRenderQueue = null;
			}
			bool flag2 = base.uiBehaviour.m_leftSnapshot != null;
			if (flag2)
			{
				base.uiBehaviour.m_leftSnapshot.RefreshRenderQueue = null;
			}
			this.m_leftDummy = null;
			this.m_rightDummy = null;
			bool flag3 = this._close_timer > 0U;
			if (flag3)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._close_timer);
				this._close_timer = 0U;
			}
		}

		protected override void OnUnload()
		{
			XSingleton<XShell>.singleton.Pause = false;
			this.leftTalker = "";
			this.rightTalker = "";
			base.Return3DAvatarPool();
			this.m_leftDummy = null;
			this.m_rightDummy = null;
			base.OnUnload();
		}

		private void AutoClose(object obj)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this.GotoNextTalk(null);
				this._close_timer = XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.AutoClose), null);
			}
		}

		protected void GotoNextTalk(IXUISprite sp)
		{
			XSingleton<XLevelScriptMgr>.singleton.ExecuteNextCmd();
		}

		public void SetRightAvatar(string talker, string content, string voice)
		{
			bool onReconnect = XSingleton<XClientNetwork>.singleton.XConnect.OnReconnect;
			if (!onReconnect)
			{
				XSingleton<XVirtualTab>.singleton.Cancel();
				bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.ResetPressState();
				}
				this.SetVisible(true, true);
				base.uiBehaviour.m_RightText.gameObject.SetActive(true);
				base.uiBehaviour.m_name.gameObject.SetActive(true);
				base.uiBehaviour.m_LeftText.gameObject.SetActive(false);
				base.uiBehaviour.m_rightSnapshot.transform.localPosition = base.uiBehaviour.m_rightDummyPos;
				base.uiBehaviour.m_leftSnapshot.transform.localPosition = XGameUI.Far_Far_Away;
				string text = "";
				bool flag2 = talker == "[player]";
				if (flag2)
				{
					XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
					XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, base.uiBehaviour.m_rightSnapshot);
					XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(XSingleton<XAttributeMgr>.singleton.XPlayerData.PresentID);
					bool flag3 = byPresentID != null && byPresentID.AvatarPos != null;
					if (flag3)
					{
						int num = XSingleton<XCommon>.singleton.RandomInt(0, byPresentID.AvatarPos.Length);
						XSingleton<X3DAvatarMgr>.singleton.SetMainAnimation(byPresentID.AvatarPos[num]);
					}
				}
				else
				{
					uint key = uint.Parse(talker);
					XNpcInfo.RowData byNPCID = XSingleton<XEntityMgr>.singleton.NpcInfo.GetByNPCID(key);
					text = byNPCID.Name;
					this.m_rightDummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, byNPCID.PresentID, base.uiBehaviour.m_rightSnapshot, this.m_rightDummy, 1f);
					XEntityPresentation.RowData byPresentID2 = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(byNPCID.PresentID);
					bool flag4 = byPresentID2 != null && byPresentID2.AvatarPos != null;
					if (flag4)
					{
						int num2 = XSingleton<XCommon>.singleton.RandomInt(0, byPresentID2.AvatarPos.Length);
						this.m_rightDummy.SetAnimation(byPresentID2.AvatarPos[num2]);
					}
				}
				base.uiBehaviour.m_name.SetText(text);
				base.uiBehaviour.m_RightText.SetText(content);
				bool flag5 = !string.IsNullOrEmpty(voice);
				if (flag5)
				{
					XSingleton<XAudioMgr>.singleton.PlayUISound(this.GetProfVoice(voice), true, AudioChannel.Action);
				}
				this.rightTalker = talker;
			}
		}

		public void SetLeftAvatar(string talker, string content, string voice)
		{
			bool onReconnect = XSingleton<XClientNetwork>.singleton.XConnect.OnReconnect;
			if (!onReconnect)
			{
				XSingleton<XVirtualTab>.singleton.Cancel();
				bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.ResetPressState();
				}
				this.SetVisible(true, true);
				base.uiBehaviour.m_RightText.gameObject.SetActive(false);
				base.uiBehaviour.m_name.gameObject.SetActive(false);
				base.uiBehaviour.m_LeftText.gameObject.SetActive(true);
				base.uiBehaviour.m_rightSnapshot.transform.localPosition = XGameUI.Far_Far_Away;
				base.uiBehaviour.m_leftSnapshot.transform.localPosition = base.uiBehaviour.m_leftDummyPos;
				string text = "";
				bool flag2 = talker == "[player]";
				if (flag2)
				{
					XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
					XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, base.uiBehaviour.m_leftSnapshot);
					XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(XSingleton<XAttributeMgr>.singleton.XPlayerData.PresentID);
					bool flag3 = byPresentID != null && byPresentID.AvatarPos != null;
					if (flag3)
					{
						int num = XSingleton<XCommon>.singleton.RandomInt(0, byPresentID.AvatarPos.Length);
						XSingleton<X3DAvatarMgr>.singleton.SetMainAnimation(byPresentID.AvatarPos[num]);
					}
				}
				else
				{
					uint key = uint.Parse(talker);
					XNpcInfo.RowData byNPCID = XSingleton<XEntityMgr>.singleton.NpcInfo.GetByNPCID(key);
					text = byNPCID.Name;
					this.m_leftDummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, byNPCID.PresentID, base.uiBehaviour.m_leftSnapshot, this.m_leftDummy, 1f);
					XEntityPresentation.RowData byPresentID2 = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(byNPCID.PresentID);
					bool flag4 = byPresentID2 != null && byPresentID2.AvatarPos != null;
					if (flag4)
					{
						int num2 = XSingleton<XCommon>.singleton.RandomInt(0, byPresentID2.AvatarPos.Length);
						this.m_leftDummy.SetAnimation(byPresentID2.AvatarPos[num2]);
					}
				}
				base.uiBehaviour.m_name.SetText(text);
				base.uiBehaviour.m_LeftText.SetText(content);
				bool flag5 = !string.IsNullOrEmpty(voice);
				if (flag5)
				{
					XSingleton<XAudioMgr>.singleton.PlayUISound(this.GetProfVoice(voice), true, AudioChannel.Action);
				}
				this.leftTalker = talker;
			}
		}

		protected string GetProfVoice(string voice)
		{
			string[] array = voice.Split(new char[]
			{
				'|'
			});
			uint basicTypeID = XSingleton<XAttributeMgr>.singleton.XPlayerData.BasicTypeID;
			bool flag = (ulong)basicTypeID <= (ulong)((long)array.Length);
			string result;
			if (flag)
			{
				result = array[(int)(basicTypeID - 1U)];
			}
			else
			{
				result = array[0];
			}
			return result;
		}

		private string leftTalker = "";

		private string rightTalker = "";

		private XDummy m_rightDummy;

		private XDummy m_leftDummy;

		private uint _close_timer = 0U;
	}
}

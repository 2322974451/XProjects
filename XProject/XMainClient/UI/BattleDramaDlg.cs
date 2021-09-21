using System;
using UILib;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001885 RID: 6277
	internal class BattleDramaDlg : DlgBase<BattleDramaDlg, BattleDramaDlgBehaviour>
	{
		// Token: 0x170039CD RID: 14797
		// (get) Token: 0x06010540 RID: 66880 RVA: 0x003F4DB0 File Offset: 0x003F2FB0
		public override string fileName
		{
			get
			{
				return "Battle/BattleDramaDlg";
			}
		}

		// Token: 0x170039CE RID: 14798
		// (get) Token: 0x06010541 RID: 66881 RVA: 0x003F4DC8 File Offset: 0x003F2FC8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170039CF RID: 14799
		// (get) Token: 0x06010542 RID: 66882 RVA: 0x003F4DDC File Offset: 0x003F2FDC
		public override bool exclusive
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170039D0 RID: 14800
		// (get) Token: 0x06010543 RID: 66883 RVA: 0x003F4DF0 File Offset: 0x003F2FF0
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010544 RID: 66884 RVA: 0x003F4E04 File Offset: 0x003F3004
		public override void RegisterEvent()
		{
			IXUISprite ixuisprite = base.uiBehaviour.m_TaskArea.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.GotoNextTalk));
		}

		// Token: 0x06010545 RID: 66885 RVA: 0x003F4E40 File Offset: 0x003F3040
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

		// Token: 0x06010546 RID: 66886 RVA: 0x003F4EBC File Offset: 0x003F30BC
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

		// Token: 0x06010547 RID: 66887 RVA: 0x003F4F9C File Offset: 0x003F319C
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

		// Token: 0x06010548 RID: 66888 RVA: 0x003F4FE8 File Offset: 0x003F31E8
		private void AutoClose(object obj)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this.GotoNextTalk(null);
				this._close_timer = XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.AutoClose), null);
			}
		}

		// Token: 0x06010549 RID: 66889 RVA: 0x003F502C File Offset: 0x003F322C
		protected void GotoNextTalk(IXUISprite sp)
		{
			XSingleton<XLevelScriptMgr>.singleton.ExecuteNextCmd();
		}

		// Token: 0x0601054A RID: 66890 RVA: 0x003F503C File Offset: 0x003F323C
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

		// Token: 0x0601054B RID: 66891 RVA: 0x003F52C0 File Offset: 0x003F34C0
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

		// Token: 0x0601054C RID: 66892 RVA: 0x003F5544 File Offset: 0x003F3744
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

		// Token: 0x04007598 RID: 30104
		private string leftTalker = "";

		// Token: 0x04007599 RID: 30105
		private string rightTalker = "";

		// Token: 0x0400759A RID: 30106
		private XDummy m_rightDummy;

		// Token: 0x0400759B RID: 30107
		private XDummy m_leftDummy;

		// Token: 0x0400759C RID: 30108
		private uint _close_timer = 0U;
	}
}

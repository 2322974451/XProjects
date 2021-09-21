using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018F2 RID: 6386
	internal class XWorldBossResultView : DlgBase<XWorldBossResultView, GuildDragonChallengeResultBehaviour>
	{
		// Token: 0x17003A8A RID: 14986
		// (get) Token: 0x06010A4A RID: 68170 RVA: 0x00420BDC File Offset: 0x0041EDDC
		public override string fileName
		{
			get
			{
				return "Battle/Comcotinue";
			}
		}

		// Token: 0x17003A8B RID: 14987
		// (get) Token: 0x06010A4B RID: 68171 RVA: 0x00420BF4 File Offset: 0x0041EDF4
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A8C RID: 14988
		// (get) Token: 0x06010A4C RID: 68172 RVA: 0x00420C08 File Offset: 0x0041EE08
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010A4D RID: 68173 RVA: 0x00420C1B File Offset: 0x0041EE1B
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
			this._Doc.WorldBossResultView = this;
		}

		// Token: 0x06010A4E RID: 68174 RVA: 0x00420C41 File Offset: 0x0041EE41
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_ReturnBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnReturn));
		}

		// Token: 0x06010A4F RID: 68175 RVA: 0x00420C68 File Offset: 0x0041EE68
		private void OnReturn(IXUISprite sp)
		{
			this._Doc.ReqQutiScene();
		}

		// Token: 0x06010A50 RID: 68176 RVA: 0x00420C78 File Offset: 0x0041EE78
		public void ShowResult(bool isWin)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.countDownTime.LeftTime = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("WorldBossGameEndCountDown"));
				this.SetVisibleWithAnimation(true, new DlgBase<XWorldBossResultView, GuildDragonChallengeResultBehaviour>.OnAnimationOver(this.StartCountDown));
				if (isWin)
				{
					base.uiBehaviour.m_Desription.SetText(XStringDefineProxy.GetString("WORLDBOSS_CHANGGLE_DES_WIN"));
				}
				else
				{
					base.uiBehaviour.m_Desription.SetText(XStringDefineProxy.GetString("WORLDBOSS_CHANGGLE_DES_FAILED"));
				}
			}
		}

		// Token: 0x06010A51 RID: 68177 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void StartCountDown()
		{
		}

		// Token: 0x06010A52 RID: 68178 RVA: 0x00420D0A File Offset: 0x0041EF0A
		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		// Token: 0x04007931 RID: 31025
		private XWorldBossDocument _Doc;

		// Token: 0x04007932 RID: 31026
		private XElapseTimer countDownTime = new XElapseTimer();
	}
}

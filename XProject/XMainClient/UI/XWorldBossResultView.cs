using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XWorldBossResultView : DlgBase<XWorldBossResultView, GuildDragonChallengeResultBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/Comcotinue";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
			this._Doc.WorldBossResultView = this;
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_ReturnBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnReturn));
		}

		private void OnReturn(IXUISprite sp)
		{
			this._Doc.ReqQutiScene();
		}

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

		private void StartCountDown()
		{
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		private XWorldBossDocument _Doc;

		private XElapseTimer countDownTime = new XElapseTimer();
	}
}

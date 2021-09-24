using System;
using UILib;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class BattleShareHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			this.mQQFrame = (base.PanelObject.transform.FindChild("/QQ").GetComponent("XUISprite") as IXUISprite);
			this.mWeChatFrame = (base.PanelObject.transform.FindChild("Wc").GetComponent("XUISprite") as IXUISprite);
			this.mQQBtn1 = (base.PanelObject.transform.FindChild("QQ/QQ1").GetComponent("XUIButton") as IXUIButton);
			this.mQQBtn2 = (base.PanelObject.transform.FindChild("QQ/QQ2").GetComponent("XUIButton") as IXUIButton);
			this.mWeChatBtn1 = (base.PanelObject.transform.FindChild("Wc/Wc1").GetComponent("XUIButton") as IXUIButton);
			this.mWeChatBtn2 = (base.PanelObject.transform.FindChild("Wc/Wc2").GetComponent("XUIButton") as IXUIButton);
			this.mQQBackClick = (base.transform.FindChild("QQ/back").GetComponent("XUISprite") as IXUISprite);
			this.mWeChatBackClick = (base.transform.FindChild("Wc/back").GetComponent("XUISprite") as IXUISprite);
			this.mReqShareBtn = (base.transform.FindChild("SwitchAccount").GetComponent("XUIButton") as IXUIButton);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.mReqShareBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ReqShare));
			this.mQQBackClick.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseShare));
			this.mWeChatBackClick.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseShare));
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		public bool ReqShare(IXUIButton btn)
		{
			bool flag = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ;
			if (flag)
			{
				this.mQQFrame.SetVisible(true);
				this.mWeChatFrame.SetVisible(false);
			}
			else
			{
				this.mQQFrame.SetVisible(false);
				this.mWeChatFrame.SetVisible(true);
			}
			return true;
		}

		public void OnCloseShare(IXUISprite sp)
		{
			this.mQQFrame.SetVisible(false);
			this.mWeChatFrame.SetVisible(false);
		}

		private XHeroBattleDocument _doc = null;

		public IXUISprite mQQFrame;

		public IXUISprite mWeChatFrame;

		public IXUIButton mQQBtn1;

		public IXUIButton mQQBtn2;

		public IXUIButton mWeChatBtn1;

		public IXUIButton mWeChatBtn2;

		public IXUISprite mQQBackClick;

		public IXUISprite mWeChatBackClick;

		public IXUIButton mReqShareBtn;
	}
}

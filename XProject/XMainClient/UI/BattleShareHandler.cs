using System;
using UILib;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001721 RID: 5921
	internal class BattleShareHandler : DlgHandlerBase
	{
		// Token: 0x0600F499 RID: 62617 RVA: 0x0036F5A0 File Offset: 0x0036D7A0
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

		// Token: 0x0600F49A RID: 62618 RVA: 0x0036F730 File Offset: 0x0036D930
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.mReqShareBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ReqShare));
			this.mQQBackClick.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseShare));
			this.mWeChatBackClick.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseShare));
		}

		// Token: 0x0600F49B RID: 62619 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600F49C RID: 62620 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600F49D RID: 62621 RVA: 0x0036F790 File Offset: 0x0036D990
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

		// Token: 0x0600F49E RID: 62622 RVA: 0x0036F7EE File Offset: 0x0036D9EE
		public void OnCloseShare(IXUISprite sp)
		{
			this.mQQFrame.SetVisible(false);
			this.mWeChatFrame.SetVisible(false);
		}

		// Token: 0x04006976 RID: 26998
		private XHeroBattleDocument _doc = null;

		// Token: 0x04006977 RID: 26999
		public IXUISprite mQQFrame;

		// Token: 0x04006978 RID: 27000
		public IXUISprite mWeChatFrame;

		// Token: 0x04006979 RID: 27001
		public IXUIButton mQQBtn1;

		// Token: 0x0400697A RID: 27002
		public IXUIButton mQQBtn2;

		// Token: 0x0400697B RID: 27003
		public IXUIButton mWeChatBtn1;

		// Token: 0x0400697C RID: 27004
		public IXUIButton mWeChatBtn2;

		// Token: 0x0400697D RID: 27005
		public IXUISprite mQQBackClick;

		// Token: 0x0400697E RID: 27006
		public IXUISprite mWeChatBackClick;

		// Token: 0x0400697F RID: 27007
		public IXUIButton mReqShareBtn;
	}
}

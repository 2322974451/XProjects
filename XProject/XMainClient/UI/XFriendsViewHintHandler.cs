using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200182E RID: 6190
	internal class XFriendsViewHintHandler : DlgHandlerBase
	{
		// Token: 0x0601011F RID: 65823 RVA: 0x003D5CC8 File Offset: 0x003D3EC8
		protected override void Init()
		{
			base.Init();
			this.mTweenTool = (base.PanelObject.GetComponent("XUIPlayTween") as IXUITweenTool);
			Transform transform = base.PanelObject.transform.Find("Bg");
			this.lbHintText1 = (transform.Find("T1").GetComponent("XUILabel") as IXUILabel);
			this.lbHintText2 = (transform.Find("T2").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x06010120 RID: 65824 RVA: 0x003D5D50 File Offset: 0x003D3F50
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			IXUISprite ixuisprite = base.PanelObject.transform.Find("BgBlack").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClose));
		}

		// Token: 0x06010121 RID: 65825 RVA: 0x003D5DA0 File Offset: 0x003D3FA0
		protected override void OnShow()
		{
			base.OnShow();
			this.lbHintText1.SetText(XStringDefineProxy.GetString("FRIEND_HINT_TIP1"));
			this.lbHintText2.SetText(XStringDefineProxy.GetString("FRIEND_HINT_TIP2", new object[]
			{
				XSingleton<XFriendsStaticData>.singleton.SendGiftMinDegree
			}));
		}

		// Token: 0x06010122 RID: 65826 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x06010123 RID: 65827 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void OnHideTweenFinished(IXUITweenTool tween)
		{
		}

		// Token: 0x06010124 RID: 65828 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void OnClose(IXUISprite sprClose)
		{
			base.SetVisible(false);
		}

		// Token: 0x0400729C RID: 29340
		private IXUILabel lbHintText1;

		// Token: 0x0400729D RID: 29341
		private IXUILabel lbHintText2;

		// Token: 0x0400729E RID: 29342
		private IXUITweenTool mTweenTool;
	}
}

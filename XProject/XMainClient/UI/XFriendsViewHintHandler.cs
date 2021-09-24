using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XFriendsViewHintHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.mTweenTool = (base.PanelObject.GetComponent("XUIPlayTween") as IXUITweenTool);
			Transform transform = base.PanelObject.transform.Find("Bg");
			this.lbHintText1 = (transform.Find("T1").GetComponent("XUILabel") as IXUILabel);
			this.lbHintText2 = (transform.Find("T2").GetComponent("XUILabel") as IXUILabel);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			IXUISprite ixuisprite = base.PanelObject.transform.Find("BgBlack").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClose));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.lbHintText1.SetText(XStringDefineProxy.GetString("FRIEND_HINT_TIP1"));
			this.lbHintText2.SetText(XStringDefineProxy.GetString("FRIEND_HINT_TIP2", new object[]
			{
				XSingleton<XFriendsStaticData>.singleton.SendGiftMinDegree
			}));
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		private void OnHideTweenFinished(IXUITweenTool tween)
		{
		}

		private void OnClose(IXUISprite sprClose)
		{
			base.SetVisible(false);
		}

		private IXUILabel lbHintText1;

		private IXUILabel lbHintText2;

		private IXUITweenTool mTweenTool;
	}
}

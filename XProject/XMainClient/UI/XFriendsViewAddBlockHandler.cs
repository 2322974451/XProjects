using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XFriendsViewAddBlockHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.mTweenTool = (base.PanelObject.GetComponent("XUIPlayTween") as IXUITweenTool);
			Transform transform = base.PanelObject.transform.Find("Bg");
			this.lbName = (transform.Find("textinput").GetComponent("XUIInput") as IXUIInput);
			this.btnAdd = (transform.Find("btnAdd").GetComponent("XUIButton") as IXUIButton);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			IXUISprite ixuisprite = base.PanelObject.transform.Find("BgBlack").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClose));
			this.btnAdd.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickAddBlockFriend));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.lbName.SetText(string.Empty);
		}

		protected override void OnHide()
		{
		}

		private void OnHideTweenFinished(IXUITweenTool tween)
		{
		}

		private void OnClose(IXUISprite sprClose)
		{
			base.SetVisible(false);
		}

		private bool OnClickAddBlockFriend(IXUIButton sp)
		{
			string text = this.lbName.GetText();
			bool flag = (text + string.Empty).Length <= 0;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_NAME_CANNOT_NULL"), "fece00");
				result = false;
			}
			else
			{
				DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddBlockFriend(text);
				result = true;
			}
			return result;
		}

		private IXUIInput lbName;

		private IXUIButton btnAdd;

		private IXUITweenTool mTweenTool;
	}
}

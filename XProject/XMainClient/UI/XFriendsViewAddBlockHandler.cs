using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200182D RID: 6189
	internal class XFriendsViewAddBlockHandler : DlgHandlerBase
	{
		// Token: 0x06010117 RID: 65815 RVA: 0x003D5B5C File Offset: 0x003D3D5C
		protected override void Init()
		{
			base.Init();
			this.mTweenTool = (base.PanelObject.GetComponent("XUIPlayTween") as IXUITweenTool);
			Transform transform = base.PanelObject.transform.Find("Bg");
			this.lbName = (transform.Find("textinput").GetComponent("XUIInput") as IXUIInput);
			this.btnAdd = (transform.Find("btnAdd").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x06010118 RID: 65816 RVA: 0x003D5BE4 File Offset: 0x003D3DE4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			IXUISprite ixuisprite = base.PanelObject.transform.Find("BgBlack").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClose));
			this.btnAdd.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickAddBlockFriend));
		}

		// Token: 0x06010119 RID: 65817 RVA: 0x003D5C49 File Offset: 0x003D3E49
		protected override void OnShow()
		{
			base.OnShow();
			this.lbName.SetText(string.Empty);
		}

		// Token: 0x0601011A RID: 65818 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnHide()
		{
		}

		// Token: 0x0601011B RID: 65819 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void OnHideTweenFinished(IXUITweenTool tween)
		{
		}

		// Token: 0x0601011C RID: 65820 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void OnClose(IXUISprite sprClose)
		{
			base.SetVisible(false);
		}

		// Token: 0x0601011D RID: 65821 RVA: 0x003D5C64 File Offset: 0x003D3E64
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

		// Token: 0x04007299 RID: 29337
		private IXUIInput lbName;

		// Token: 0x0400729A RID: 29338
		private IXUIButton btnAdd;

		// Token: 0x0400729B RID: 29339
		private IXUITweenTool mTweenTool;
	}
}

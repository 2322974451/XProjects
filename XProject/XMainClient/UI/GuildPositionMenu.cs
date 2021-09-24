using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildPositionMenu : DlgBase<GuildPositionMenu, GuildPositionBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildPositionMenu";
			}
		}

		public void ShowMenu(ulong MemberID)
		{
			this._MemberID = MemberID;
			bool flag = base.IsVisible();
			if (flag)
			{
				this.RefreshView();
			}
			else
			{
				this.SetVisibleWithAnimation(true, null);
			}
		}

		protected override void Init()
		{
			base.Init();
			this._memberDoc = XDocuments.GetSpecificDocument<XGuildMemberDocument>(XGuildMemberDocument.uuID);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshView();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_memuSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ClickClose));
		}

		private void RefreshView()
		{
			base.uiBehaviour.m_MenuPool.ReturnAll(false);
			float x = base.uiBehaviour.m_MenuPool.TplPos.x;
			float num = base.uiBehaviour.m_MenuPool.TplPos.y;
			float z = base.uiBehaviour.m_MenuPool.TplPos.z;
			int num2 = XFastEnumIntEqualityComparer<GuildPosition>.ToInt(GuildPosition.GPOS_COUNT);
			bool flag = num2 > 2;
			if (flag)
			{
				num += (float)((num2 - 2) * base.uiBehaviour.m_MenuPool.TplHeight / 2);
			}
			int spriteHeight = base.uiBehaviour.m_MenuPool.TplHeight * (num2 - 1);
			int num3 = XFastEnumIntEqualityComparer<GuildPosition>.ToInt(this._memberDoc.GetMemberPosition(this._MemberID));
			for (int i = 0; i < num2; i++)
			{
				bool flag2 = num3 == i;
				if (!flag2)
				{
					GameObject gameObject = base.uiBehaviour.m_MenuPool.FetchGameObject(false);
					bool flag3 = i < num3;
					if (flag3)
					{
						gameObject.transform.localPosition = new Vector3(x, num - (float)(base.uiBehaviour.m_MenuPool.TplHeight * i), z);
					}
					else
					{
						gameObject.transform.localPosition = new Vector3(x, num - (float)(base.uiBehaviour.m_MenuPool.TplHeight * (i - 1)), z);
					}
					IXUIButton ixuibutton = gameObject.transform.FindChild("button").GetComponent("XUIButton") as IXUIButton;
					IXUILabel ixuilabel = gameObject.transform.FindChild("button/name").GetComponent("XUILabel") as IXUILabel;
					ixuibutton.ID = (ulong)((long)i);
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickHandler));
					ixuilabel.SetText(XGuildDocument.GuildPP.GetPositionName((GuildPosition)i, false));
				}
			}
			base.uiBehaviour.m_memuSprite.spriteHeight = spriteHeight;
		}

		private bool ClickHandler(IXUIButton btn)
		{
			DlgBase<GuildPositionMenu, GuildPositionBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			this._SelectPosition = (GuildPosition)btn.ID;
			bool flag = this._SelectPosition == GuildPosition.GPOS_LEADER;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("GUILD_CHANGELEADER_CONFIRM", new object[]
				{
					XGuildDocument.GuildPP.GetPositionName(GuildPosition.GPOS_LEADER, false)
				}), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnSelectPositionHandler));
			}
			else
			{
				this.OnSelectPositionHandler(null);
			}
			return true;
		}

		private bool OnSelectPositionHandler(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._memberDoc.ReqChangePosition(this._MemberID, this._SelectPosition);
			return true;
		}

		private void ClickClose(IXUISprite sprite)
		{
			this.SetVisibleWithAnimation(false, null);
		}

		private GuildPosition _SelectPosition;

		private ulong _MemberID;

		private XGuildMemberDocument _memberDoc;
	}
}

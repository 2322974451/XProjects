using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200175F RID: 5983
	internal class GuildPositionMenu : DlgBase<GuildPositionMenu, GuildPositionBehaviour>
	{
		// Token: 0x17003807 RID: 14343
		// (get) Token: 0x0600F718 RID: 63256 RVA: 0x00382CEC File Offset: 0x00380EEC
		public override string fileName
		{
			get
			{
				return "Guild/GuildPositionMenu";
			}
		}

		// Token: 0x0600F719 RID: 63257 RVA: 0x00382D04 File Offset: 0x00380F04
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

		// Token: 0x0600F71A RID: 63258 RVA: 0x00382D35 File Offset: 0x00380F35
		protected override void Init()
		{
			base.Init();
			this._memberDoc = XDocuments.GetSpecificDocument<XGuildMemberDocument>(XGuildMemberDocument.uuID);
		}

		// Token: 0x0600F71B RID: 63259 RVA: 0x00382D4F File Offset: 0x00380F4F
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshView();
		}

		// Token: 0x0600F71C RID: 63260 RVA: 0x00382D60 File Offset: 0x00380F60
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_memuSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ClickClose));
		}

		// Token: 0x0600F71D RID: 63261 RVA: 0x00382D88 File Offset: 0x00380F88
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

		// Token: 0x0600F71E RID: 63262 RVA: 0x00382F74 File Offset: 0x00381174
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

		// Token: 0x0600F71F RID: 63263 RVA: 0x00383014 File Offset: 0x00381214
		private bool OnSelectPositionHandler(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._memberDoc.ReqChangePosition(this._MemberID, this._SelectPosition);
			return true;
		}

		// Token: 0x0600F720 RID: 63264 RVA: 0x0038304A File Offset: 0x0038124A
		private void ClickClose(IXUISprite sprite)
		{
			this.SetVisibleWithAnimation(false, null);
		}

		// Token: 0x04006B72 RID: 27506
		private GuildPosition _SelectPosition;

		// Token: 0x04006B73 RID: 27507
		private ulong _MemberID;

		// Token: 0x04006B74 RID: 27508
		private XGuildMemberDocument _memberDoc;
	}
}

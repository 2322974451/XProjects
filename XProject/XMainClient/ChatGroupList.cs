using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BD2 RID: 3026
	internal class ChatGroupList : DlgBase<ChatGroupList, ChatGroupBehaviour>
	{
		// Token: 0x17003089 RID: 12425
		// (get) Token: 0x0600ACEA RID: 44266 RVA: 0x00200124 File Offset: 0x001FE324
		public override string fileName
		{
			get
			{
				return "GameSystem/ChatGroupList";
			}
		}

		// Token: 0x1700308A RID: 12426
		// (get) Token: 0x0600ACEB RID: 44267 RVA: 0x0020013C File Offset: 0x001FE33C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700308B RID: 12427
		// (get) Token: 0x0600ACEC RID: 44268 RVA: 0x00200150 File Offset: 0x001FE350
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600ACED RID: 44269 RVA: 0x00200163 File Offset: 0x001FE363
		protected override void Init()
		{
			base.Init();
		}

		// Token: 0x0600ACEE RID: 44270 RVA: 0x00200170 File Offset: 0x001FE370
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_wrap.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			base.uiBehaviour.m_sprClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.m_add.ID = 1UL;
			base.uiBehaviour.m_add.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabSelectionChanged));
			base.uiBehaviour.m_rm.ID = 2UL;
			base.uiBehaviour.m_rm.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabSelectionChanged));
		}

		// Token: 0x0600ACEF RID: 44271 RVA: 0x00200218 File Offset: 0x001FE418
		protected override void OnShow()
		{
			base.OnShow();
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			specificDocument.ReqGetGroupInfo(DlgBase<XChatView, XChatBehaviour>.singleton.ChatGroupId);
		}

		// Token: 0x0600ACF0 RID: 44272 RVA: 0x00200249 File Offset: 0x001FE449
		protected override void OnHide()
		{
			DlgBase<XChatView, XChatBehaviour>.singleton.OnFocus();
			base.OnHide();
		}

		// Token: 0x0600ACF1 RID: 44273 RVA: 0x0020025E File Offset: 0x001FE45E
		public void SetCB()
		{
			this.state = ChatGroupList.State.Add;
			base.uiBehaviour.m_add.ForceSetFlag(true);
			this.Refresh();
		}

		// Token: 0x0600ACF2 RID: 44274 RVA: 0x00200284 File Offset: 0x001FE484
		public void Refresh()
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			bool flag = specificDocument.players != null;
			if (flag)
			{
				CGroupPlayerInfo[] array = new CGroupPlayerInfo[specificDocument.players.Count];
				specificDocument.players.CopyTo(array);
				this.SelectByState(array);
				base.uiBehaviour.m_wrap.SetContentCount(this.players.Count, false);
			}
		}

		// Token: 0x0600ACF3 RID: 44275 RVA: 0x002002F0 File Offset: 0x001FE4F0
		private bool OnTabSelectionChanged(IXUICheckBox ckb)
		{
			bool bChecked = ckb.bChecked;
			if (bChecked)
			{
				ulong id = ckb.ID;
				bool flag = id == 1UL;
				if (flag)
				{
					this.state = ChatGroupList.State.Add;
				}
				else
				{
					this.state = ChatGroupList.State.Rm;
				}
				this.Refresh();
			}
			return true;
		}

		// Token: 0x0600ACF4 RID: 44276 RVA: 0x00200338 File Offset: 0x001FE538
		private void SelectByState(CGroupPlayerInfo[] pp)
		{
			bool flag = this.players == null;
			if (flag)
			{
				this.players = new List<CGroupPlayerInfo>();
			}
			else
			{
				this.players.Clear();
			}
			int i = 0;
			int num = pp.Length;
			while (i < num)
			{
				bool flag2 = this.state == ChatGroupList.State.Add;
				if (flag2)
				{
					bool flag3 = pp[i].degree >= 0;
					if (flag3)
					{
						this.players.Add(pp[i]);
					}
				}
				else
				{
					bool flag4 = pp[i].degree < 0;
					if (flag4)
					{
						bool flag5 = pp[i].roleid != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
						if (flag5)
						{
							this.players.Add(pp[i]);
						}
					}
				}
				i++;
			}
			bool flag6 = this.state == ChatGroupList.State.Add;
			if (flag6)
			{
				this.players.Sort(new Comparison<CGroupPlayerInfo>(this.Sort));
			}
		}

		// Token: 0x0600ACF5 RID: 44277 RVA: 0x0020042C File Offset: 0x001FE62C
		private int Sort(CGroupPlayerInfo x, CGroupPlayerInfo y)
		{
			return y.degree - x.degree;
		}

		// Token: 0x0600ACF6 RID: 44278 RVA: 0x0020044B File Offset: 0x001FE64B
		private void OnCloseClick(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x0600ACF7 RID: 44279 RVA: 0x00200458 File Offset: 0x001FE658
		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = this.players == null || this.players[index] == null;
			if (!flag)
			{
				IXUISprite ixuisprite = t.Find("head").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = t.Find("level").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.Find("UID").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.Find("PPT").GetComponent("XUILabel") as IXUILabel;
				IXUILabelSymbol ixuilabelSymbol = t.Find("name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				IXUISprite ixuisprite2 = t.Find("agree").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel4 = t.Find("agree/T").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel5 = t.Find("guild").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite3 = t.Find("ProfIcon").GetComponent("XUISprite") as IXUISprite;
				int profession = (int)this.players[index].profession;
				ixuisprite3.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(profession);
				ixuisprite.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2(profession);
				string text = (this.state == ChatGroupList.State.Add) ? XStringDefineProxy.GetString("CHAT_GROUP_PUSH") : XStringDefineProxy.GetString("CHAT_GROUP_TICKOUT");
				ixuilabel4.SetText(text);
				ixuisprite2.ID = this.players[index].roleid;
				string text2 = this.players[index].guild;
				bool flag2 = string.IsNullOrEmpty(text2);
				if (flag2)
				{
					text2 = XStringDefineProxy.GetString("NONE");
				}
				ixuilabel5.SetText(text2);
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OpItemClick));
				ixuilabel.SetText(this.players[index].level.ToString());
				ixuilabel3.SetText(this.players[index].ppt.ToString());
				ixuilabelSymbol.InputText = this.players[index].rolename;
				ixuilabel2.SetText(this.players[index].uid.ToString());
			}
		}

		// Token: 0x0600ACF8 RID: 44280 RVA: 0x002006BC File Offset: 0x001FE8BC
		private void OpItemClick(IXUISprite spr)
		{
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			CGroupPlayerInfo cgroupPlayerInfo = null;
			bool flag = false;
			for (int i = 0; i < this.players.Count; i++)
			{
				bool flag2 = this.players[i].roleid == spr.ID;
				if (flag2)
				{
					cgroupPlayerInfo = this.players[i];
				}
			}
			List<ulong> list = new List<ulong>();
			List<ulong> list2 = new List<ulong>();
			bool flag3 = cgroupPlayerInfo.degree == -1;
			if (flag3)
			{
				CBrifGroupInfo currGroup = specificDocument.currGroup;
				bool flag4 = currGroup != null && currGroup.leaderid == cgroupPlayerInfo.roleid;
				if (flag4)
				{
					flag = true;
				}
				else
				{
					list2.Add(cgroupPlayerInfo.roleid);
				}
			}
			else
			{
				list.Add(cgroupPlayerInfo.roleid);
			}
			bool flag5 = flag;
			if (flag5)
			{
				DlgBase<XChatView, XChatBehaviour>.singleton.OnGroupQuitClick(null);
			}
			else
			{
				bool flag6 = DlgBase<XChatView, XChatBehaviour>.singleton.ChatGroupId > 0UL;
				if (flag6)
				{
					specificDocument.ReqChangePlayer(DlgBase<XChatView, XChatBehaviour>.singleton.ChatGroupId, list, list2);
				}
			}
		}

		// Token: 0x0400410E RID: 16654
		public ChatGroupList.State state = ChatGroupList.State.Add;

		// Token: 0x0400410F RID: 16655
		private List<CGroupPlayerInfo> players;

		// Token: 0x020019A1 RID: 6561
		public enum State
		{
			// Token: 0x04007F50 RID: 32592
			Add,
			// Token: 0x04007F51 RID: 32593
			Rm
		}
	}
}

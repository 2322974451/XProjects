using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BA7 RID: 2983
	internal class LevelRewardSkyArenaHandler : DlgHandlerBase
	{
		// Token: 0x1700304B RID: 12363
		// (get) Token: 0x0600AB0A RID: 43786 RVA: 0x001EFC20 File Offset: 0x001EDE20
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardSkyArenaFrame";
			}
		}

		// Token: 0x0600AB0B RID: 43787 RVA: 0x001EFC38 File Offset: 0x001EDE38
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.m_Return = (base.PanelObject.transform.Find("Bg/Return").GetComponent("XUIButton") as IXUIButton);
			this.m_Title = (base.PanelObject.transform.Find("Bg/Title/Title").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.PanelObject.transform.Find("Bg/Info/Info/InfoTpl");
			this.m_InfoPool.SetupPool(null, transform.gameObject, SkyArenaInfoHandler.TEAM_MEMBER_NUM, false);
			Transform transform2 = base.PanelObject.transform.Find("Bg/ItemList/Item/ItemTpl");
			this.m_ItemPool.SetupPool(null, transform2.gameObject, 5U, false);
		}

		// Token: 0x0600AB0C RID: 43788 RVA: 0x001EFD0B File Offset: 0x001EDF0B
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Return.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
		}

		// Token: 0x0600AB0D RID: 43789 RVA: 0x001EFD30 File Offset: 0x001EDF30
		private bool OnReturnButtonClicked(IXUIButton button)
		{
			this.doc.SendLeaveScene();
			return true;
		}

		// Token: 0x0600AB0E RID: 43790 RVA: 0x001EA11D File Offset: 0x001E831D
		private void OnAddFriendClick(IXUISprite sp)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(sp.ID);
		}

		// Token: 0x0600AB0F RID: 43791 RVA: 0x001EECC3 File Offset: 0x001ECEC3
		private void _OnItemClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
		}

		// Token: 0x0600AB10 RID: 43792 RVA: 0x001EFD4F File Offset: 0x001EDF4F
		protected override void OnShow()
		{
			base.OnShow();
			this.OnShowUI();
		}

		// Token: 0x0600AB11 RID: 43793 RVA: 0x001EFD60 File Offset: 0x001EDF60
		private void OnShowUI()
		{
			XLevelRewardDocument.SkyArenaData skyArenaBattleData = this.doc.SkyArenaBattleData;
			XSkyArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XSkyArenaBattleDocument>(XSkyArenaBattleDocument.uuID);
			specificDocument.HideVSInfo();
			int num = 0;
			this.m_InfoPool.FakeReturnAll();
			for (int i = 0; i < skyArenaBattleData.roleid.Count; i++)
			{
				XSkyArenaBattleDocument.RoleData roleData;
				bool flag = !specificDocument.UserIdToRole.TryGetValue(skyArenaBattleData.roleid[i], out roleData);
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("UID:" + skyArenaBattleData.roleid[i] + " No Find!", null, null, null, null, null);
				}
				else
				{
					bool flag2 = specificDocument.MyTeam != roleData.teamid;
					if (!flag2)
					{
						GameObject gameObject = this.m_InfoPool.FetchGameObject(false);
						gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)this.m_InfoPool.TplHeight * num), 0f);
						num++;
						Transform transform = gameObject.transform.Find("Member/MVP");
						transform.gameObject.SetActive(skyArenaBattleData.ismvp[i]);
						IXUISprite ixuisprite = gameObject.transform.Find("Member/Avatar").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)roleData.job));
						IXUILabel ixuilabel = gameObject.transform.Find("Member/Name").GetComponent("XUILabel") as IXUILabel;
						ixuilabel.SetText(roleData.name);
						IXUILabel ixuilabel2 = gameObject.transform.Find("Kill").GetComponent("XUILabel") as IXUILabel;
						ixuilabel2.SetText(skyArenaBattleData.killcount[i].ToString());
						IXUILabel ixuilabel3 = gameObject.transform.Find("Dead").GetComponent("XUILabel") as IXUILabel;
						ixuilabel3.SetText(skyArenaBattleData.deathcount[i].ToString());
						Transform transform2 = gameObject.transform.Find("AddFriend");
						IXUILabel ixuilabel4 = gameObject.transform.Find("Favorability").GetComponent("XUILabel") as IXUILabel;
						bool flag3 = skyArenaBattleData.roleid[i] == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
						if (flag3)
						{
							transform2.gameObject.SetActive(false);
							ixuilabel4.gameObject.SetActive(false);
						}
						else
						{
							bool flag4 = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsMyFriend(skyArenaBattleData.roleid[i]);
							if (flag4)
							{
								transform2.gameObject.SetActive(false);
								ixuilabel4.gameObject.SetActive(true);
								ixuilabel4.SetText(DlgBase<XFriendsView, XFriendsBehaviour>.singleton.GetFriendDegreeAll(skyArenaBattleData.roleid[i]).ToString());
							}
							else
							{
								transform2.gameObject.SetActive(true);
								ixuilabel4.gameObject.SetActive(false);
								IXUISprite ixuisprite2 = gameObject.transform.Find("AddFriend/Add").GetComponent("XUISprite") as IXUISprite;
								ixuisprite2.ID = skyArenaBattleData.roleid[i];
								ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddFriendClick));
							}
						}
					}
				}
			}
			this.m_InfoPool.ActualReturnAll(false);
			this.m_Title.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_REWARD"), this.doc.SkyArenaBattleData.floor.ToString()));
			this.m_ItemPool.FakeReturnAll();
			for (int j = 0; j < skyArenaBattleData.item.Count; j++)
			{
				GameObject gameObject2 = this.m_ItemPool.FetchGameObject(false);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)skyArenaBattleData.item[j].itemID, (int)skyArenaBattleData.item[j].itemCount, false);
				gameObject2.transform.localPosition = new Vector3(((float)j + 0.5f - (float)skyArenaBattleData.item.Count / 2f) * (float)this.m_ItemPool.TplWidth, 0f, 0f);
				IXUISprite ixuisprite3 = gameObject2.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite3.ID = (ulong)skyArenaBattleData.item[j].itemID;
				ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClick));
			}
			this.m_ItemPool.ActualReturnAll(false);
		}

		// Token: 0x04003FD8 RID: 16344
		private XLevelRewardDocument doc = null;

		// Token: 0x04003FD9 RID: 16345
		private IXUIButton m_Return;

		// Token: 0x04003FDA RID: 16346
		private IXUILabel m_Title;

		// Token: 0x04003FDB RID: 16347
		private XUIPool m_InfoPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003FDC RID: 16348
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}

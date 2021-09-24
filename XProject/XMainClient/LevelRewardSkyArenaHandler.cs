using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardSkyArenaHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardSkyArenaFrame";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Return.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
		}

		private bool OnReturnButtonClicked(IXUIButton button)
		{
			this.doc.SendLeaveScene();
			return true;
		}

		private void OnAddFriendClick(IXUISprite sp)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(sp.ID);
		}

		private void _OnItemClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.OnShowUI();
		}

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

		private XLevelRewardDocument doc = null;

		private IXUIButton m_Return;

		private IXUILabel m_Title;

		private XUIPool m_InfoPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}

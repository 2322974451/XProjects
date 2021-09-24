using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildArenaDuelResultInfo
	{

		public void Init(Transform t)
		{
			this.m_SccrollView = (t.FindChild("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (t.FindChild("ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_LoseTransform = t.FindChild("Result/Lose");
			this.m_WinTransform = t.FindChild("Result/Win");
			this.m_DamageLabel = (t.FindChild("Damage").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildName = (t.FindChild("GuildInfo/GuildName").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildIcon = (t.FindChild("GuildInfo/GuildIcon").GetComponent("XUISprite") as IXUISprite);
			this.m_TotalKiller = (t.FindChild("GuildInfo/TotalKiller").GetComponent("XUILabel") as IXUILabel);
			this.m_EmptyTransform = t.FindChild("Empty");
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContentUpdate));
		}

		public void Set(GVGDuelResult result)
		{
			this.m_LoseTransform.gameObject.SetActive(!result.isWinner);
			this.m_WinTransform.gameObject.SetActive(result.isWinner);
			this.m_GuildName.SetText(result.ToGuildNameString());
			this.m_GuildIcon.SetSprite(XGuildDocument.GetPortraitName((int)result.Guild.guildicon));
			this.m_combats = result.RoleCombats;
			this.m_TotalKiller.SetText(result.TotalKiller.ToString());
			this.m_DamageLabel.SetText(((int)result.TotalDamage).ToString());
			this.m_WrapContent.SetContentCount(this.m_combats.Count, false);
			this.m_SccrollView.ResetPosition();
			this.m_EmptyTransform.gameObject.SetActive(this.m_combats.Count == 0);
		}

		private void OnWrapContentUpdate(Transform t, int index)
		{
			bool flag = this.m_combats == null || index >= this.m_combats.Count;
			if (!flag)
			{
				GmfRoleCombat gmfRoleCombat = this.m_combats[index];
				IXUISprite ixuisprite = t.Find("Avatar").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite2 = t.Find("MVP").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.Find("Level").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.Find("Kill").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite3 = t.Find("AddFriend").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon((int)gmfRoleCombat.gmfrole.profession));
				ixuisprite2.SetAlpha(0f);
				ixuilabel.SetText(gmfRoleCombat.gmfrole.rolename);
				ixuilabel2.SetText(string.Format("Lv.{0}", 0));
				ixuilabel2.Alpha = 0f;
				ixuilabel3.SetText(gmfRoleCombat.combat.killcount.ToString());
				ixuisprite3.ID = gmfRoleCombat.gmfrole.roleid;
				ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddFriendClick));
				bool flag2 = gmfRoleCombat.gmfrole.roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag2)
				{
					ixuisprite3.SetVisible(false);
				}
			}
		}

		private void OnAddFriendClick(IXUISprite sp)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(sp.ID);
		}

		private IXUIScrollView m_SccrollView;

		private IXUIWrapContent m_WrapContent;

		private Transform m_LoseTransform;

		private Transform m_WinTransform;

		private IXUILabel m_DamageLabel;

		private IXUILabel m_GuildName;

		private IXUISprite m_GuildIcon;

		private IXUILabel m_TotalKiller;

		private List<GmfRoleCombat> m_combats;

		private Transform m_EmptyTransform;
	}
}

using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200174A RID: 5962
	internal class GuildArenaDuelResultInfo
	{
		// Token: 0x0600F682 RID: 63106 RVA: 0x0037ED1C File Offset: 0x0037CF1C
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

		// Token: 0x0600F683 RID: 63107 RVA: 0x0037EE38 File Offset: 0x0037D038
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

		// Token: 0x0600F684 RID: 63108 RVA: 0x0037EF28 File Offset: 0x0037D128
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

		// Token: 0x0600F685 RID: 63109 RVA: 0x001EA11D File Offset: 0x001E831D
		private void OnAddFriendClick(IXUISprite sp)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(sp.ID);
		}

		// Token: 0x04006AF9 RID: 27385
		private IXUIScrollView m_SccrollView;

		// Token: 0x04006AFA RID: 27386
		private IXUIWrapContent m_WrapContent;

		// Token: 0x04006AFB RID: 27387
		private Transform m_LoseTransform;

		// Token: 0x04006AFC RID: 27388
		private Transform m_WinTransform;

		// Token: 0x04006AFD RID: 27389
		private IXUILabel m_DamageLabel;

		// Token: 0x04006AFE RID: 27390
		private IXUILabel m_GuildName;

		// Token: 0x04006AFF RID: 27391
		private IXUISprite m_GuildIcon;

		// Token: 0x04006B00 RID: 27392
		private IXUILabel m_TotalKiller;

		// Token: 0x04006B01 RID: 27393
		private List<GmfRoleCombat> m_combats;

		// Token: 0x04006B02 RID: 27394
		private Transform m_EmptyTransform;
	}
}

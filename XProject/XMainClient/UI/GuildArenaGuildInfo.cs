using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x02001832 RID: 6194
	internal class GuildArenaGuildInfo : DlgHandlerBase
	{
		// Token: 0x0601014D RID: 65869 RVA: 0x003D708C File Offset: 0x003D528C
		protected override void Init()
		{
			base.Init();
			this.m_GuildNameLabel = (base.PanelObject.transform.FindChild("txt_GuildName").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildHeadSprite = (base.PanelObject.transform.FindChild("GuildIcon").GetComponent("XUISprite") as IXUISprite);
			this.m_unKnowSprite = (base.PanelObject.transform.FindChild("UnKnow").GetComponent("XUISprite") as IXUISprite);
			this.SetEmptyMember();
		}

		// Token: 0x0601014E RID: 65870 RVA: 0x003D7126 File Offset: 0x003D5326
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_GuildHeadSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGuildHeadClickHandle));
		}

		// Token: 0x0601014F RID: 65871 RVA: 0x003D7148 File Offset: 0x003D5348
		public void SetGuildMember(ulong guildID, ulong winnerID = 0UL, bool isCup = false)
		{
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			XGuildDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			XGuildBasicData xguildBasicData = null;
			bool flag = !specificDocument.TryGetGuildInfo(guildID, out xguildBasicData);
			if (flag)
			{
				this.SetEmptyMember();
				if (isCup)
				{
					this.m_unKnowSprite.SetVisible(false);
				}
			}
			else
			{
				this.SetShowMember();
				this.m_GuildHeadSprite.ID = guildID;
				this.m_GuildNameLabel.SetText(xguildBasicData.guildName);
				this.m_GuildHeadSprite.SetSprite(XGuildDocument.GetPortraitName(xguildBasicData.portraitIndex));
				this.m_GuildNameLabel.SetColor((specificDocument2.bInGuild && specificDocument2.BasicData.uid == guildID) ? Color.green : Color.white);
				bool flag2 = winnerID == 0UL;
				if (flag2)
				{
					this.m_GuildHeadSprite.SetGrey(true);
				}
				else
				{
					this.m_GuildHeadSprite.SetGrey(winnerID == guildID);
				}
			}
		}

		// Token: 0x06010150 RID: 65872 RVA: 0x003D7238 File Offset: 0x003D5438
		private void OnGuildHeadClickHandle(IXUISprite sprite)
		{
			bool flag = sprite.ID > 0UL;
			if (flag)
			{
				XGuildViewDocument specificDocument = XDocuments.GetSpecificDocument<XGuildViewDocument>(XGuildViewDocument.uuID);
				specificDocument.View(sprite.ID);
			}
		}

		// Token: 0x06010151 RID: 65873 RVA: 0x003D726E File Offset: 0x003D546E
		private void SetShowMember()
		{
			this.m_GuildNameLabel.SetVisible(true);
			this.m_GuildHeadSprite.SetVisible(true);
			this.m_unKnowSprite.SetVisible(false);
		}

		// Token: 0x06010152 RID: 65874 RVA: 0x003D7298 File Offset: 0x003D5498
		private void SetEmptyMember()
		{
			this.m_GuildHeadSprite.ID = 0UL;
			this.m_GuildNameLabel.SetVisible(false);
			this.m_GuildHeadSprite.SetVisible(false);
			this.m_unKnowSprite.SetVisible(true);
		}

		// Token: 0x040072BA RID: 29370
		private IXUILabel m_GuildNameLabel;

		// Token: 0x040072BB RID: 29371
		private IXUISprite m_GuildHeadSprite;

		// Token: 0x040072BC RID: 29372
		private IXUISprite m_unKnowSprite;
	}
}

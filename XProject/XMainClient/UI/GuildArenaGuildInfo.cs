using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	internal class GuildArenaGuildInfo : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_GuildNameLabel = (base.PanelObject.transform.FindChild("txt_GuildName").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildHeadSprite = (base.PanelObject.transform.FindChild("GuildIcon").GetComponent("XUISprite") as IXUISprite);
			this.m_unKnowSprite = (base.PanelObject.transform.FindChild("UnKnow").GetComponent("XUISprite") as IXUISprite);
			this.SetEmptyMember();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_GuildHeadSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGuildHeadClickHandle));
		}

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

		private void OnGuildHeadClickHandle(IXUISprite sprite)
		{
			bool flag = sprite.ID > 0UL;
			if (flag)
			{
				XGuildViewDocument specificDocument = XDocuments.GetSpecificDocument<XGuildViewDocument>(XGuildViewDocument.uuID);
				specificDocument.View(sprite.ID);
			}
		}

		private void SetShowMember()
		{
			this.m_GuildNameLabel.SetVisible(true);
			this.m_GuildHeadSprite.SetVisible(true);
			this.m_unKnowSprite.SetVisible(false);
		}

		private void SetEmptyMember()
		{
			this.m_GuildHeadSprite.ID = 0UL;
			this.m_GuildNameLabel.SetVisible(false);
			this.m_GuildHeadSprite.SetVisible(false);
			this.m_unKnowSprite.SetVisible(true);
		}

		private IXUILabel m_GuildNameLabel;

		private IXUISprite m_GuildHeadSprite;

		private IXUISprite m_unKnowSprite;
	}
}

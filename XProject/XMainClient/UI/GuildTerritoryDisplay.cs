using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001777 RID: 6007
	internal class GuildTerritoryDisplay
	{
		// Token: 0x0600F7F9 RID: 63481 RVA: 0x003893E4 File Offset: 0x003875E4
		public void Init(uint territoryID, Transform t)
		{
			this.transform = t;
			this.mTerritoryID = territoryID;
			this.mOccupy = this.transform.FindChild("guildname/Occupy");
			this.mGuildName = (this.transform.FindChild("guildname/Occupy/GuildName").GetComponent("XUILabel") as IXUILabel);
			this.mGuildIcon = (this.transform.FindChild("guildname/Occupy/GuildIcon").GetComponent("XUISprite") as IXUISprite);
			this.mTerritoryIcon = (this.transform.FindChild("guildname/Icon").GetComponent("XUISprite") as IXUISprite);
			this.mTerritoryName = (this.transform.FindChild("guildname/Name").GetComponent("XUILabel") as IXUILabel);
			this.mTerritorySprite = (this.transform.FindChild("Sprite").GetComponent("XUISprite") as IXUISprite);
			this.mTerritoryButton = (this.transform.GetComponent("XUIButton") as IXUIButton);
			this.mTerritoryButton.ID = (ulong)((long)int.Parse(this.transform.name));
			this.mCrossGVGPrimary = this.transform.Find("CrossGVGPrimary");
			this.mTerritoryButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTerritoryClick));
			this.Clear();
		}

		// Token: 0x0600F7FA RID: 63482 RVA: 0x0038953C File Offset: 0x0038773C
		private void Clear()
		{
			this.mOccupy.gameObject.SetActive(false);
			this.mCrossGVGPrimary.gameObject.SetActive(false);
		}

		// Token: 0x0600F7FB RID: 63483 RVA: 0x00389564 File Offset: 0x00387764
		public void Refresh()
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			XCrossGVGDocument specificDocument2 = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
			CityData cityData;
			bool flag = specificDocument.TryGetCityData(this.mTerritoryID, out cityData);
			if (flag)
			{
				this.mOccupy.gameObject.SetActive(cityData.guildid > 0UL);
				this.mGuildName.SetText(cityData.guildname);
				XSingleton<XDebug>.singleton.AddGreenLog("cityData Singlon :", cityData.type.ToString(), null, null, null, null);
				string sprite;
				float alpha;
				switch (cityData.type)
				{
				case GUILDTERRTYPE.ALLIANCE:
					sprite = "Guild_icon05";
					alpha = 1f;
					goto IL_DD;
				case GUILDTERRTYPE.TERR_WARING:
				case GUILDTERRTYPE.WAITING:
					sprite = "Guild_icon06";
					alpha = 1f;
					goto IL_DD;
				}
				sprite = string.Empty;
				alpha = 0f;
				IL_DD:
				this.mTerritoryIcon.SetAlpha(alpha);
				this.mTerritoryIcon.SetSprite(sprite);
				this.mTerritoryIcon.MakePixelPerfect();
				uint targetTerrioryType = specificDocument.GetTargetTerrioryType(this.mTerritoryID);
				uint @int = (uint)XSingleton<XGlobalConfig>.singleton.GetInt("CrossGvgTerrLevel");
				this.mCrossGVGPrimary.gameObject.SetActive(specificDocument2.TimeStep == CrossGvgTimeState.CGVG_Select && targetTerrioryType >= @int);
			}
			else
			{
				this.mOccupy.gameObject.SetActive(false);
				this.mTerritoryIcon.SetAlpha(0f);
				this.mCrossGVGPrimary.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600F7FC RID: 63484 RVA: 0x003896F8 File Offset: 0x003878F8
		private bool OnTerritoryClick(IXUIButton btn)
		{
			uint uid = (uint)btn.ID;
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.SendGuildTerritoryChallInfo(uid);
			XSingleton<XDebug>.singleton.AddGreenLog("OnTerritoryClick:", uid.ToString(), null, null, null, null);
			return true;
		}

		// Token: 0x04006C27 RID: 27687
		public Transform transform;

		// Token: 0x04006C28 RID: 27688
		public IXUILabel mGuildName;

		// Token: 0x04006C29 RID: 27689
		public IXUISprite mGuildIcon;

		// Token: 0x04006C2A RID: 27690
		public Transform mOccupy;

		// Token: 0x04006C2B RID: 27691
		public IXUISprite mTerritoryIcon;

		// Token: 0x04006C2C RID: 27692
		public IXUILabel mTerritoryName;

		// Token: 0x04006C2D RID: 27693
		public IXUISprite mTerritorySprite;

		// Token: 0x04006C2E RID: 27694
		public IXUIButton mTerritoryButton;

		// Token: 0x04006C2F RID: 27695
		public Transform mCrossGVGPrimary;

		// Token: 0x04006C30 RID: 27696
		public uint mTerritoryID = 0U;
	}
}

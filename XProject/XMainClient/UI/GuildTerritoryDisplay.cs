using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildTerritoryDisplay
	{

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

		private void Clear()
		{
			this.mOccupy.gameObject.SetActive(false);
			this.mCrossGVGPrimary.gameObject.SetActive(false);
		}

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

		private bool OnTerritoryClick(IXUIButton btn)
		{
			uint uid = (uint)btn.ID;
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.SendGuildTerritoryChallInfo(uid);
			XSingleton<XDebug>.singleton.AddGreenLog("OnTerritoryClick:", uid.ToString(), null, null, null, null);
			return true;
		}

		public Transform transform;

		public IXUILabel mGuildName;

		public IXUISprite mGuildIcon;

		public Transform mOccupy;

		public IXUISprite mTerritoryIcon;

		public IXUILabel mTerritoryName;

		public IXUISprite mTerritorySprite;

		public IXUIButton mTerritoryButton;

		public Transform mCrossGVGPrimary;

		public uint mTerritoryID = 0U;
	}
}

using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001779 RID: 6009
	internal class GuildTerritoryMessageDlg : DlgBase<GuildTerritoryMessageDlg, GuildTerritoryMessageBehaviour>
	{
		// Token: 0x17003824 RID: 14372
		// (get) Token: 0x0600F800 RID: 63488 RVA: 0x003897F8 File Offset: 0x003879F8
		public override string fileName
		{
			get
			{
				return "Guild/GuildTerritory/GuildTerritoryMessageDlg";
			}
		}

		// Token: 0x0600F801 RID: 63489 RVA: 0x00389810 File Offset: 0x00387A10
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			base.uiBehaviour.mNameLabel.SetText(string.Empty);
			base.uiBehaviour.mWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapUpdateItem));
		}

		// Token: 0x0600F802 RID: 63490 RVA: 0x00389868 File Offset: 0x00387A68
		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendReceiveTerritroyInfo();
		}

		// Token: 0x0600F803 RID: 63491 RVA: 0x0038987E File Offset: 0x00387A7E
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.mClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClose));
		}

		// Token: 0x0600F804 RID: 63492 RVA: 0x003898A5 File Offset: 0x00387AA5
		public void SetNewInfo(List<TerrData> dataList)
		{
			this.mCityDataList = dataList;
			this.ShowMessage();
			base.uiBehaviour.mWrapContent.SetContentCount(this.mCityDataList.Count, false);
			base.uiBehaviour.mScrollView.ResetPosition();
		}

		// Token: 0x0600F805 RID: 63493 RVA: 0x003898E4 File Offset: 0x00387AE4
		private void ShowMessage()
		{
			bool flag = false;
			string text = string.Empty;
			int i = 0;
			int count = this.mCityDataList.Count;
			while (i < count)
			{
				bool flag2 = this.mCityDataList[i].id == 13U;
				if (flag2)
				{
					bool flag3 = this.mCityDataList[i].guildid > 0UL;
					if (flag3)
					{
						flag = true;
						text = XStringDefineProxy.GetString("TERRITORY_RESULT1", new object[]
						{
							this.mCityDataList[i].name
						});
					}
					break;
				}
				i++;
			}
			bool flag4 = !flag;
			if (flag4)
			{
				text = XStringDefineProxy.GetString("TERRITORY_RESULT");
			}
			base.uiBehaviour.mNameLabel.SetText(text);
		}

		// Token: 0x0600F806 RID: 63494 RVA: 0x003899A4 File Offset: 0x00387BA4
		private bool OnClickClose(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

		// Token: 0x0600F807 RID: 63495 RVA: 0x003899C0 File Offset: 0x00387BC0
		private void OnWrapUpdateItem(Transform t, int index)
		{
			IXUISprite ixuisprite = t.FindChild("Sprite").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = t.FindChild("GuildName").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = t.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = t.FindChild("nb").GetComponent("XUILabel") as IXUILabel;
			TerrData terrData = this.mCityDataList[index];
			TerritoryBattle.RowData byID = XGuildTerritoryDocument.mGuildTerritoryList.GetByID(terrData.id);
			ixuisprite.SetSprite(byID.territoryIcon);
			ixuilabel2.SetText(byID.territoryname);
			ixuilabel3.SetText(byID.territorylevelname);
			ixuilabel.SetText(terrData.name);
		}

		// Token: 0x04006C35 RID: 27701
		private XGuildTerritoryDocument _Doc;

		// Token: 0x04006C36 RID: 27702
		private List<TerrData> mCityDataList;
	}
}

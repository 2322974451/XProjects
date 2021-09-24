using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildTerritoryMessageDlg : DlgBase<GuildTerritoryMessageDlg, GuildTerritoryMessageBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildTerritory/GuildTerritoryMessageDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			base.uiBehaviour.mNameLabel.SetText(string.Empty);
			base.uiBehaviour.mWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapUpdateItem));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendReceiveTerritroyInfo();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.mClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClose));
		}

		public void SetNewInfo(List<TerrData> dataList)
		{
			this.mCityDataList = dataList;
			this.ShowMessage();
			base.uiBehaviour.mWrapContent.SetContentCount(this.mCityDataList.Count, false);
			base.uiBehaviour.mScrollView.ResetPosition();
		}

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

		private bool OnClickClose(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

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

		private XGuildTerritoryDocument _Doc;

		private List<TerrData> mCityDataList;
	}
}

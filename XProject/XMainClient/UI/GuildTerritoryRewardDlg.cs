using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016FC RID: 5884
	internal class GuildTerritoryRewardDlg : DlgBase<GuildTerritoryRewardDlg, GuildTerritoryRewardBehaviour>
	{
		// Token: 0x1700376F RID: 14191
		// (get) Token: 0x0600F2A9 RID: 62121 RVA: 0x0035D454 File Offset: 0x0035B654
		private XGuildTerritoryDocument doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			}
		}

		// Token: 0x17003770 RID: 14192
		// (get) Token: 0x0600F2AA RID: 62122 RVA: 0x0035D470 File Offset: 0x0035B670
		public override string fileName
		{
			get
			{
				return "Guild/GuildTerritory/GuildTerritoryReward";
			}
		}

		// Token: 0x17003771 RID: 14193
		// (get) Token: 0x0600F2AB RID: 62123 RVA: 0x0035D488 File Offset: 0x0035B688
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003772 RID: 14194
		// (get) Token: 0x0600F2AC RID: 62124 RVA: 0x0035D49C File Offset: 0x0035B69C
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F2AD RID: 62125 RVA: 0x0035D4AF File Offset: 0x0035B6AF
		protected override void Init()
		{
			base.uiBehaviour.m_wrap.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateItem));
		}

		// Token: 0x0600F2AE RID: 62126 RVA: 0x0035D4CF File Offset: 0x0035B6CF
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour._close_btn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
		}

		// Token: 0x0600F2AF RID: 62127 RVA: 0x0035D4F6 File Offset: 0x0035B6F6
		protected override void OnShow()
		{
			this.CulResult();
			base.uiBehaviour.m_wrap.SetContentCount(this.list.Count, false);
			base.uiBehaviour.m_scrool.ResetPosition();
		}

		// Token: 0x0600F2B0 RID: 62128 RVA: 0x0035D530 File Offset: 0x0035B730
		private void CulResult()
		{
			XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
			uint sealType = specificDocument.SealType;
			this.list.Clear();
			foreach (TerritoryRewd.RowData rowData in XGuildTerritoryDocument.mTerritoryRewd.Table)
			{
				bool flag = (long)rowData.ID == (long)((ulong)sealType);
				if (flag)
				{
					this.list.Add(rowData);
				}
			}
		}

		// Token: 0x0600F2B1 RID: 62129 RVA: 0x0035D5A0 File Offset: 0x0035B7A0
		private void UpdateItem(Transform t, int index)
		{
			IXUILabel ixuilabel = t.transform.Find("Bg/Rank/RankNum").GetComponent("XUILabel") as IXUILabel;
			bool flag = this.list.Count > index;
			if (flag)
			{
				TerritoryRewd.RowData rowData = this.list[index];
				ixuilabel.SetText(rowData.Point.ToString());
				for (int i = 0; i < rowData.Reward.Count; i++)
				{
					GameObject gameObject = base.uiBehaviour.m_RewardItemPool.FetchGameObject(false);
					gameObject.transform.parent = t;
					gameObject.transform.localScale = Vector3.one;
					gameObject.transform.localPosition = new Vector3((float)(base.uiBehaviour.m_RewardItemPool.TplWidth * i) + base.uiBehaviour.m_RewardItemPool._tpl.transform.localPosition.x, 0f);
					IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)rowData.Reward[i, 0];
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)rowData.Reward[i, 0], (int)rowData.Reward[i, 1], false);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
			}
		}

		// Token: 0x0600F2B2 RID: 62130 RVA: 0x0035D724 File Offset: 0x0035B924
		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x04006803 RID: 26627
		private List<TerritoryRewd.RowData> list = new List<TerritoryRewd.RowData>();
	}
}

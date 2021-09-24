using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildTerritoryRewardDlg : DlgBase<GuildTerritoryRewardDlg, GuildTerritoryRewardBehaviour>
	{

		private XGuildTerritoryDocument doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			}
		}

		public override string fileName
		{
			get
			{
				return "Guild/GuildTerritory/GuildTerritoryReward";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.uiBehaviour.m_wrap.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateItem));
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour._close_btn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
		}

		protected override void OnShow()
		{
			this.CulResult();
			base.uiBehaviour.m_wrap.SetContentCount(this.list.Count, false);
			base.uiBehaviour.m_scrool.ResetPosition();
		}

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

		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		private List<TerritoryRewd.RowData> list = new List<TerritoryRewd.RowData>();
	}
}

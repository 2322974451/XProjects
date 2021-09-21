using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C0C RID: 3084
	internal class GuildCampRankHandler : DlgHandlerBase
	{
		// Token: 0x170030E3 RID: 12515
		// (get) Token: 0x0600AF32 RID: 44850 RVA: 0x00212764 File Offset: 0x00210964
		protected override string FileName
		{
			get
			{
				return "Guild/GuildSystem/GuildRankFrame";
			}
		}

		// Token: 0x0600AF33 RID: 44851 RVA: 0x0021277C File Offset: 0x0021097C
		protected override void Init()
		{
			base.Init();
			this.m_objTpl = base.transform.Find("Bg/Bg/ScrollView/wrapcontent/RewardTpl/Bg/tpl").gameObject;
			this.m_btnClose = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_scrool = (base.transform.Find("Bg/Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_wrapContent = (base.transform.Find("Bg/Bg/ScrollView/wrapcontent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._doc = XDocuments.GetSpecificDocument<XGuildSmallMonsterDocument>(XGuildSmallMonsterDocument.uuID);
			this.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.RefreshItems));
			this.m_RewardItemPool.SetupPool(base.transform.gameObject, this.m_objTpl, 30U, false);
		}

		// Token: 0x0600AF34 RID: 44852 RVA: 0x00212863 File Offset: 0x00210A63
		protected override void OnShow()
		{
			base.OnShow();
			this.DestroyItems();
			this.m_scrool.ResetPosition();
			this.m_wrapContent.SetContentCount(XGuildSmallMonsterDocument._guildRankTable.Table.Length, false);
		}

		// Token: 0x0600AF35 RID: 44853 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600AF36 RID: 44854 RVA: 0x00212899 File Offset: 0x00210A99
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(DlgBase<XGuildSmallMonsterView, XGuildSmallMonsterBehaviour>.singleton.CloseRankHandler));
		}

		// Token: 0x0600AF37 RID: 44855 RVA: 0x002128C0 File Offset: 0x00210AC0
		private void RefreshItems(Transform t, int index)
		{
			GuildCampRank.RowData[] table = XGuildSmallMonsterDocument._guildRankTable.Table;
			GuildCampRank.RowData rowData = table[index];
			IXUILabel ixuilabel = t.Find("Bg/Rank/RankNum").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(rowData.Rank.ToString());
			for (int i = 0; i < rowData.Reward.Count; i++)
			{
				GameObject gameObject = this.m_RewardItemPool.FetchGameObject(false);
				gameObject.transform.parent = t;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = new Vector3((float)(this.m_RewardItemPool.TplWidth * i) + this.m_RewardItemPool._tpl.transform.localPosition.x, 0f);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)rowData.Reward[i, 0];
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)rowData.Reward[i, 0], (int)rowData.Reward[i, 1], false);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
		}

		// Token: 0x0600AF38 RID: 44856 RVA: 0x00212A1C File Offset: 0x00210C1C
		private GameObject FetchItem()
		{
			GameObject gameObject = XCommon.Instantiate<GameObject>(this.m_objTpl);
			gameObject.SetActive(true);
			this.list.Add(gameObject);
			return gameObject;
		}

		// Token: 0x0600AF39 RID: 44857 RVA: 0x00212A50 File Offset: 0x00210C50
		private void DestroyItems()
		{
			for (int i = 0; i < this.list.Count; i++)
			{
				bool flag = this.list[i] != null;
				if (flag)
				{
					UnityEngine.Object.Destroy(this.list[i]);
				}
			}
			this.list.Clear();
		}

		// Token: 0x040042C6 RID: 17094
		private XGuildSmallMonsterDocument _doc = null;

		// Token: 0x040042C7 RID: 17095
		private GameObject m_objTpl;

		// Token: 0x040042C8 RID: 17096
		private IXUIWrapContent m_wrapContent;

		// Token: 0x040042C9 RID: 17097
		private IXUIScrollView m_scrool;

		// Token: 0x040042CA RID: 17098
		private IXUIButton m_btnClose;

		// Token: 0x040042CB RID: 17099
		public XUIPool m_RewardItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040042CC RID: 17100
		private List<GameObject> list = new List<GameObject>();
	}
}

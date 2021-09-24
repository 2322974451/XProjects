using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildCampRankHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Guild/GuildSystem/GuildRankFrame";
			}
		}

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

		protected override void OnShow()
		{
			base.OnShow();
			this.DestroyItems();
			this.m_scrool.ResetPosition();
			this.m_wrapContent.SetContentCount(XGuildSmallMonsterDocument._guildRankTable.Table.Length, false);
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(DlgBase<XGuildSmallMonsterView, XGuildSmallMonsterBehaviour>.singleton.CloseRankHandler));
		}

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

		private GameObject FetchItem()
		{
			GameObject gameObject = XCommon.Instantiate<GameObject>(this.m_objTpl);
			gameObject.SetActive(true);
			this.list.Add(gameObject);
			return gameObject;
		}

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

		private XGuildSmallMonsterDocument _doc = null;

		private GameObject m_objTpl;

		private IXUIWrapContent m_wrapContent;

		private IXUIScrollView m_scrool;

		private IXUIButton m_btnClose;

		public XUIPool m_RewardItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private List<GameObject> list = new List<GameObject>();
	}
}

using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardTerritoryHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/GuildTerritoryResult";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			this.InitUI();
		}

		public void InitUI()
		{
			this.m_btn_close = (base.PanelObject.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.mSprGuild = (base.transform.Find("Bg/Town").GetComponent("XUISprite") as IXUISprite);
			this.m_lblGuildName = (base.transform.Find("Bg/Town/GuildName").GetComponent("XUILabel") as IXUILabel);
			this.m_lblTown = (base.transform.Find("Bg/Town/TownName").GetComponent("XUILabel") as IXUILabel);
			this.mRankWrap = (base.transform.Find("Bg/RankPanel/wrap").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.mGuildWrap = (base.transform.Find("Bg/guilds/wrap").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_lblMyRank = (base.transform.Find("Bg/Reward/Rank").GetComponent("XUILabel") as IXUILabel);
			this.mRwdTpl = base.transform.Find("Bg/Reward/ItemTpl").gameObject;
			this.tplPos = this.mRwdTpl.transform.localPosition;
			this.mRankWrap.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapRankItemUpdate));
			this.mGuildWrap.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapGuildItemUpdate));
			this.mRwdPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			this.mRwdPool.SetupPool(this.mRwdTpl.transform.parent.gameObject, this.mRwdTpl, 2U, true);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btn_close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
		}

		private bool OnCloseClick(IXUIButton button)
		{
			PtcC2G_LeaveSceneReq proto = new PtcC2G_LeaveSceneReq();
			XSingleton<XClientNetwork>.singleton.Send(proto);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_FIGHT || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_WAIT;
			if (flag)
			{
				this._doc.SendGCFCommonReq(GCFReqType.GCF_FIGHT_RESULT);
			}
		}

		public void RefreshAll()
		{
			this.RefreshTitleInfo();
			this.RefreshGuildsInfo();
			this.RefreshMembersInfo();
			this.RefreshMyselfInfo();
			this.RefreshRwds();
		}

		private void RefreshTitleInfo()
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			TerritoryBattle.RowData byID = XGuildTerritoryDocument.mGuildTerritoryList.GetByID(specificDocument.territoryid);
			bool flag = byID == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("territory is nil, id: " + specificDocument.territoryid, null, null, null, null, null);
			}
			else
			{
				this.mSprGuild.SetSprite(byID.territoryIcon);
				this.m_lblGuildName.SetText(specificDocument.winguild.guildname);
				this.m_lblTown.SetText(byID.territoryname);
			}
		}

		public void RefreshGuildsInfo()
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.guilds.Sort(new Comparison<GCFGuild>(this.SortGuild));
			this.mGuildWrap.SetContentCount(specificDocument.guilds.Count, false);
		}

		private int SortGuild(GCFGuild x, GCFGuild y)
		{
			return (int)(y.brief.point - x.brief.point);
		}

		public void RefreshMembersInfo()
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			this.mRankWrap.SetContentCount(specificDocument.roles.Count, false);
		}

		private void RefreshMyselfInfo()
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			this.m_lblMyRank.SetText(specificDocument.mmyinfo.rank.ToString());
		}

		private void WrapGuildItemUpdate(Transform t, int index)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			List<GCFGuild> guilds = specificDocument.guilds;
			bool flag = guilds.Count > index;
			if (flag)
			{
				IXUILabel ixuilabel = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.Find("Score").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = t.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuilabel.SetText(specificDocument.guilds[index].brief.guildname);
				ixuilabel2.SetText(specificDocument.guilds[index].brief.point.ToString());
				ixuisprite.SetSprite(XGuildDocument.GetPortraitName((int)specificDocument.guilds[index].brief.guildicon));
			}
		}

		private void WrapRankItemUpdate(Transform t, int index)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			List<GCFRoleBrief> roles = specificDocument.roles;
			bool flag = roles.Count > index;
			if (flag)
			{
				IXUILabel ixuilabel = t.Find("Rank").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.Find("Kill").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = t.Find("Times").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel5 = t.Find("feats").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(roles[index].rank.ToString());
				ixuilabel2.SetText(roles[index].rolename);
				ixuilabel3.SetText(roles[index].killcount.ToString());
				ixuilabel4.SetText(roles[index].occupycount.ToString());
				ixuilabel5.SetText(roles[index].feats.ToString());
			}
		}

		private void RefreshRwds()
		{
			this.mRwdPool.ReturnAll(false);
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			List<ItemBrief> rwds = specificDocument.rwds;
			for (int i = 0; i < rwds.Count; i++)
			{
				GameObject gameObject = this.mRwdPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(this.tplPos.x + (float)(this.mRwdPool.TplWidth * i), this.tplPos.y, this.tplPos.z);
				XItem xitem = XBagDocument.MakeXItem((int)rwds[i].itemID, rwds[i].isbind);
				xitem.itemCount = (int)rwds[i].itemCount;
				XItemDrawerMgr.Param.bBinding = rwds[i].isbind;
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(gameObject, xitem);
				IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)rwds[i].itemID;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
		}

		private XGuildTerritoryDocument _doc = null;

		private IXUIButton m_btn_close;

		private IXUISprite mSprGuild;

		private IXUILabel m_lblGuildName;

		private IXUILabel m_lblTown;

		private IXUIWrapContent mGuildWrap;

		private IXUIWrapContent mRankWrap;

		public IXUILabel m_lblMyRank;

		private XUIPool mRwdPool;

		private GameObject mRwdTpl;

		private Vector3 tplPos;
	}
}

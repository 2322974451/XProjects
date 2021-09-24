using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildMineRankHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Guild/GuildMine/GuildMineRank";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.InitProperties();
			this.InitUIPool();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
			specificDocument.GuildResRankHanler = this;
			specificDocument.ReqResWarRank();
		}

		protected override void OnHide()
		{
			XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
			specificDocument.GuildResRankHanler = null;
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		private void InitUIPool()
		{
			Transform transform = base.transform.Find("ScrollView/GuildList/Tpl");
			this._curRankItemPool.SetupPool(this._wrapContent.gameObject, transform.gameObject, 1U, false);
		}

		private void InitProperties()
		{
			this._scrollview = (base.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform = base.transform.Find("ScrollView/GuildList");
			this._wrapContent = (transform.GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateContentItem));
			Transform transform2 = base.transform.Find("Bg/Close");
			IXUIButton ixuibutton = transform2.GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnclickCloseBtn));
			this._myRank = base.transform.Find("Self");
			this._noRankTag = base.transform.Find("Bg/EmptyRank");
		}

		private bool OnclickCloseBtn(IXUIButton button)
		{
			base.SetVisible(false);
			return true;
		}

		private void UpdateContentItem(Transform itemTransform, int index)
		{
			bool flag = index < this._resList.Count;
			if (flag)
			{
				ResRankInfo resRankInfo = this._resList[index];
				IXUILabel ixuilabel = itemTransform.Find("Name").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(resRankInfo.roleName);
				IXUILabel ixuilabel2 = itemTransform.Find("GuildName").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(resRankInfo.guildName);
				IXUILabel ixuilabel3 = itemTransform.Find("Mine").GetComponent("XUILabel") as IXUILabel;
				ixuilabel3.SetText(resRankInfo.donateValue.ToString());
				IXUISprite ixuisprite = itemTransform.Find("RankImage").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel4 = itemTransform.Find("Rank").GetComponent("XUILabel") as IXUILabel;
				bool flag2 = index < 3;
				if (flag2)
				{
					ixuisprite.gameObject.SetActive(true);
					ixuisprite.spriteName = ixuisprite.spriteName.Substring(0, ixuisprite.spriteName.Length - 1) + (index + 1);
					ixuilabel4.gameObject.SetActive(false);
				}
				else
				{
					ixuisprite.gameObject.SetActive(false);
					ixuilabel4.gameObject.SetActive(true);
					ixuilabel4.SetText((index + 1).ToString());
				}
			}
		}

		private uint GetMyRankIndex()
		{
			for (int i = 0; i < this._resList.Count; i++)
			{
				bool flag = this._resList[i].roleID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					return (uint)(i + 1);
				}
			}
			return 0U;
		}

		public void RefreshUI()
		{
			XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
			this._resList = specificDocument.ResRankInfoList;
			this._myRankIndex = this.GetMyRankIndex();
			this._curRankItemPool.ReturnAll(false);
			this._wrapContent.SetContentCount(this._resList.Count, false);
			this._scrollview.ResetPosition();
			bool flag = this._resList.Count > 0;
			if (flag)
			{
				this._noRankTag.gameObject.SetActive(false);
				bool flag2 = this._myRankIndex > 0U;
				if (flag2)
				{
					this._myRank.gameObject.SetActive(true);
					this.UpdateContentItem(this._myRank, (int)(this._myRankIndex - 1U));
				}
				else
				{
					this._myRank.gameObject.SetActive(false);
				}
			}
			else
			{
				this._noRankTag.gameObject.SetActive(true);
				this._myRank.gameObject.SetActive(false);
			}
		}

		private XUIPool _curRankItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIWrapContent _wrapContent;

		private List<ResRankInfo> _resList;

		private Transform _myRank;

		private Transform _noRankTag;

		private uint _myRankIndex = 0U;

		private IXUIScrollView _scrollview;
	}
}

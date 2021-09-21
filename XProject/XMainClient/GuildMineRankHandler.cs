using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C26 RID: 3110
	internal class GuildMineRankHandler : DlgHandlerBase
	{
		// Token: 0x1700311B RID: 12571
		// (get) Token: 0x0600B055 RID: 45141 RVA: 0x0021A02C File Offset: 0x0021822C
		protected override string FileName
		{
			get
			{
				return "Guild/GuildMine/GuildMineRank";
			}
		}

		// Token: 0x0600B056 RID: 45142 RVA: 0x0021A043 File Offset: 0x00218243
		protected override void Init()
		{
			base.Init();
			this.InitProperties();
			this.InitUIPool();
		}

		// Token: 0x0600B057 RID: 45143 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600B058 RID: 45144 RVA: 0x0021A05C File Offset: 0x0021825C
		protected override void OnShow()
		{
			base.OnShow();
			XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
			specificDocument.GuildResRankHanler = this;
			specificDocument.ReqResWarRank();
		}

		// Token: 0x0600B059 RID: 45145 RVA: 0x0021A08C File Offset: 0x0021828C
		protected override void OnHide()
		{
			XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
			specificDocument.GuildResRankHanler = null;
			base.OnHide();
		}

		// Token: 0x0600B05A RID: 45146 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600B05B RID: 45147 RVA: 0x0021A0B4 File Offset: 0x002182B4
		private void InitUIPool()
		{
			Transform transform = base.transform.Find("ScrollView/GuildList/Tpl");
			this._curRankItemPool.SetupPool(this._wrapContent.gameObject, transform.gameObject, 1U, false);
		}

		// Token: 0x0600B05C RID: 45148 RVA: 0x0021A0F4 File Offset: 0x002182F4
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

		// Token: 0x0600B05D RID: 45149 RVA: 0x0021A1C8 File Offset: 0x002183C8
		private bool OnclickCloseBtn(IXUIButton button)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600B05E RID: 45150 RVA: 0x0021A1E4 File Offset: 0x002183E4
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

		// Token: 0x0600B05F RID: 45151 RVA: 0x0021A35C File Offset: 0x0021855C
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

		// Token: 0x0600B060 RID: 45152 RVA: 0x0021A3B8 File Offset: 0x002185B8
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

		// Token: 0x0400438E RID: 17294
		private XUIPool _curRankItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400438F RID: 17295
		private IXUIWrapContent _wrapContent;

		// Token: 0x04004390 RID: 17296
		private List<ResRankInfo> _resList;

		// Token: 0x04004391 RID: 17297
		private Transform _myRank;

		// Token: 0x04004392 RID: 17298
		private Transform _noRankTag;

		// Token: 0x04004393 RID: 17299
		private uint _myRankIndex = 0U;

		// Token: 0x04004394 RID: 17300
		private IXUIScrollView _scrollview;
	}
}

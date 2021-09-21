using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C50 RID: 3152
	internal class BigMeleeEntranceView : DlgBase<BigMeleeEntranceView, BigMeleeEntranceBehaviour>
	{
		// Token: 0x17003190 RID: 12688
		// (get) Token: 0x0600B2CE RID: 45774 RVA: 0x0022A8D8 File Offset: 0x00228AD8
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003191 RID: 12689
		// (get) Token: 0x0600B2CF RID: 45775 RVA: 0x0022A8EC File Offset: 0x00228AEC
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003192 RID: 12690
		// (get) Token: 0x0600B2D0 RID: 45776 RVA: 0x0022A900 File Offset: 0x00228B00
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003193 RID: 12691
		// (get) Token: 0x0600B2D1 RID: 45777 RVA: 0x0022A914 File Offset: 0x00228B14
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003194 RID: 12692
		// (get) Token: 0x0600B2D2 RID: 45778 RVA: 0x0022A928 File Offset: 0x00228B28
		public override string fileName
		{
			get
			{
				return "GameSystem/BigMelee/BigMeleeEntrance";
			}
		}

		// Token: 0x17003195 RID: 12693
		// (get) Token: 0x0600B2D3 RID: 45779 RVA: 0x0022A940 File Offset: 0x00228B40
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_BigMelee);
			}
		}

		// Token: 0x0600B2D4 RID: 45780 RVA: 0x0022A95C File Offset: 0x00228B5C
		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XBigMeleeEntranceDocument>(XBigMeleeEntranceDocument.uuID);
		}

		// Token: 0x0600B2D5 RID: 45781 RVA: 0x0022A970 File Offset: 0x00228B70
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_Join.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinClicked));
			base.uiBehaviour.m_PointRewardBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPointRewardClicked));
			base.uiBehaviour.m_RankRewardBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankRewardClicked));
		}

		// Token: 0x0600B2D6 RID: 45782 RVA: 0x0022AA10 File Offset: 0x00228C10
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_Rule.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("BIG_MELEE_RULE")));
			base.uiBehaviour.m_Time.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("BIG_MELEE_TIME")));
			this.Refresh();
		}

		// Token: 0x0600B2D7 RID: 45783 RVA: 0x0022AA78 File Offset: 0x00228C78
		public void Refresh()
		{
			base.uiBehaviour.m_RewardShowPool.FakeReturnAll();
			for (int i = 0; i < this.reward.Length; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_RewardShowPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3((float)(i * base.uiBehaviour.m_RewardShowPool.TplWidth), 0f, 0f) + base.uiBehaviour.m_RewardShowPool.TplPos;
				uint num = uint.Parse(this.reward[i]);
				Transform transform = gameObject.transform.Find("Item");
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform.gameObject, (int)num, 0, false);
				IXUISprite ixuisprite = transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)num;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
			base.uiBehaviour.m_RewardShowPool.ActualReturnAll(false);
		}

		// Token: 0x0600B2D8 RID: 45784 RVA: 0x0022AB95 File Offset: 0x00228D95
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B2D9 RID: 45785 RVA: 0x0022AB9F File Offset: 0x00228D9F
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<PointRewardHandler>(ref this._PointRewardHandler);
			DlgHandlerBase.EnsureUnload<RankRewardHandler>(ref this._RankRewardHandler);
			base.OnUnload();
		}

		// Token: 0x0600B2DA RID: 45786 RVA: 0x0022ABC4 File Offset: 0x00228DC4
		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600B2DB RID: 45787 RVA: 0x0022ABE0 File Offset: 0x00228DE0
		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_BigMelee);
			return true;
		}

		// Token: 0x0600B2DC RID: 45788 RVA: 0x0022AC04 File Offset: 0x00228E04
		public bool OnJoinClicked(IXUIButton btn)
		{
			bool flag = XTeamDocument.GoSingleBattleBeforeNeed(new ButtonClickEventHandler(this.OnJoinClicked), btn);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.doc.ReqJoin();
				result = true;
			}
			return result;
		}

		// Token: 0x0600B2DD RID: 45789 RVA: 0x0022AC40 File Offset: 0x00228E40
		public bool OnPointRewardClicked(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<PointRewardHandler>(ref this._PointRewardHandler, base.uiBehaviour.m_Bg, false, null);
			bool flag = this._PointRewardHandler.Sys != XSysDefine.XSys_BigMelee;
			if (flag)
			{
				List<BigMeleePointReward.RowData> pointRewardList = this.doc.GetPointRewardList();
				List<PointRewardData> list = new List<PointRewardData>(pointRewardList.Count);
				for (int i = 0; i < pointRewardList.Count; i++)
				{
					PointRewardData pointRewardData = default(PointRewardData);
					pointRewardData.Init();
					pointRewardData.point = pointRewardList[i].point;
					for (int j = 0; j < pointRewardList[i].reward.Count; j++)
					{
						pointRewardData.rewardItem.Add(pointRewardList[i].reward[j, 0], pointRewardList[i].reward[j, 1]);
					}
					list.Add(pointRewardData);
				}
				this._PointRewardHandler.SetData(list, XSysDefine.XSys_BigMelee);
			}
			this._PointRewardHandler.SetVisible(true);
			return true;
		}

		// Token: 0x0600B2DE RID: 45790 RVA: 0x0022AD6C File Offset: 0x00228F6C
		public bool OnRankRewardClicked(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<RankRewardHandler>(ref this._RankRewardHandler, base.uiBehaviour.m_Bg, false, null);
			bool flag = this._RankRewardHandler.Sys != XSysDefine.XSys_BigMelee;
			if (flag)
			{
				List<BigMeleeRankReward.RowData> rankRewardList = this.doc.GetRankRewardList();
				List<RankRewardData> list = new List<RankRewardData>(rankRewardList.Count);
				for (int i = 0; i < rankRewardList.Count; i++)
				{
					list.Add(new RankRewardData
					{
						rankMIN = rankRewardList[i].rank[0],
						rankMAX = rankRewardList[i].rank[1],
						rewardID = 
						{
							rankRewardList[i].reward[i, 0]
						},
						rewardCount = 
						{
							rankRewardList[i].reward[i, 1]
						}
					});
				}
				this._RankRewardHandler.SetData(list, XSysDefine.XSys_BigMelee);
			}
			this._RankRewardHandler.SetVisible(true);
			return true;
		}

		// Token: 0x04004512 RID: 17682
		private XBigMeleeEntranceDocument doc = null;

		// Token: 0x04004513 RID: 17683
		private PointRewardHandler _PointRewardHandler;

		// Token: 0x04004514 RID: 17684
		private RankRewardHandler _RankRewardHandler;

		// Token: 0x04004515 RID: 17685
		private string[] reward = XSingleton<XGlobalConfig>.singleton.GetValue("BigMeleeShowReward").Split(new char[]
		{
			'|'
		});
	}
}

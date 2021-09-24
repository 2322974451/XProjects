using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class BigMeleeEntranceView : DlgBase<BigMeleeEntranceView, BigMeleeEntranceBehaviour>
	{

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
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

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/BigMelee/BigMeleeEntrance";
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_BigMelee);
			}
		}

		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XBigMeleeEntranceDocument>(XBigMeleeEntranceDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_Join.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinClicked));
			base.uiBehaviour.m_PointRewardBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPointRewardClicked));
			base.uiBehaviour.m_RankRewardBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankRewardClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_Rule.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("BIG_MELEE_RULE")));
			base.uiBehaviour.m_Time.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("BIG_MELEE_TIME")));
			this.Refresh();
		}

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

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<PointRewardHandler>(ref this._PointRewardHandler);
			DlgHandlerBase.EnsureUnload<RankRewardHandler>(ref this._RankRewardHandler);
			base.OnUnload();
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_BigMelee);
			return true;
		}

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

		private XBigMeleeEntranceDocument doc = null;

		private PointRewardHandler _PointRewardHandler;

		private RankRewardHandler _RankRewardHandler;

		private string[] reward = XSingleton<XGlobalConfig>.singleton.GetValue("BigMeleeShowReward").Split(new char[]
		{
			'|'
		});
	}
}

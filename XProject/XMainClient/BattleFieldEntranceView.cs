using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A22 RID: 2594
	internal class BattleFieldEntranceView : DlgBase<BattleFieldEntranceView, BattleFieldEntranceBehaviour>
	{
		// Token: 0x17002EC0 RID: 11968
		// (get) Token: 0x06009E89 RID: 40585 RVA: 0x001A1248 File Offset: 0x0019F448
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002EC1 RID: 11969
		// (get) Token: 0x06009E8A RID: 40586 RVA: 0x001A125C File Offset: 0x0019F45C
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002EC2 RID: 11970
		// (get) Token: 0x06009E8B RID: 40587 RVA: 0x001A1270 File Offset: 0x0019F470
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002EC3 RID: 11971
		// (get) Token: 0x06009E8C RID: 40588 RVA: 0x001A1284 File Offset: 0x0019F484
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002EC4 RID: 11972
		// (get) Token: 0x06009E8D RID: 40589 RVA: 0x001A1298 File Offset: 0x0019F498
		public override string fileName
		{
			get
			{
				return "GameSystem/BattleFieldEntrance";
			}
		}

		// Token: 0x17002EC5 RID: 11973
		// (get) Token: 0x06009E8E RID: 40590 RVA: 0x001A12B0 File Offset: 0x0019F4B0
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Battlefield);
			}
		}

		// Token: 0x06009E8F RID: 40591 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void Init()
		{
		}

		// Token: 0x06009E90 RID: 40592 RVA: 0x001A12CC File Offset: 0x0019F4CC
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_Join.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinClicked));
			base.uiBehaviour.m_PointRewardBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPointRewardClicked));
			base.uiBehaviour.m_FallBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFallClicked));
		}

		// Token: 0x06009E91 RID: 40593 RVA: 0x001A136C File Offset: 0x0019F56C
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_Rule.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("BATTLEFIELD_RULE")));
			base.uiBehaviour.m_Time.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("BATTLEFIELD_TIME")));
			this.Refresh();
		}

		// Token: 0x06009E92 RID: 40594 RVA: 0x001A13D4 File Offset: 0x0019F5D4
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

		// Token: 0x06009E93 RID: 40595 RVA: 0x001A14F1 File Offset: 0x0019F6F1
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x06009E94 RID: 40596 RVA: 0x001A14FB File Offset: 0x0019F6FB
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<ItemListHandler>(ref this._ItemListHandler);
			DlgHandlerBase.EnsureUnload<PointRewardHandler>(ref this._PointRewardHandler);
			base.OnUnload();
		}

		// Token: 0x06009E95 RID: 40597 RVA: 0x001A1520 File Offset: 0x0019F720
		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x06009E96 RID: 40598 RVA: 0x001A153C File Offset: 0x0019F73C
		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Battlefield);
			return true;
		}

		// Token: 0x06009E97 RID: 40599 RVA: 0x001A1560 File Offset: 0x0019F760
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
				XBattleFieldEntranceDocument.Doc.ReqJoin();
				result = true;
			}
			return result;
		}

		// Token: 0x06009E98 RID: 40600 RVA: 0x001A1598 File Offset: 0x0019F798
		public bool OnPointRewardClicked(IXUIButton btn)
		{
			XBattleFieldEntranceDocument.Doc.ReqPointRewardInfo();
			DlgHandlerBase.EnsureCreate<PointRewardHandler>(ref this._PointRewardHandler, base.uiBehaviour.m_Bg, false, null);
			bool flag = this._PointRewardHandler.Sys != XSysDefine.XSys_Battlefield;
			if (flag)
			{
				List<BattleFieldPointReward.RowData> pointRewardList = XBattleFieldEntranceDocument.Doc.GetPointRewardList();
				List<PointRewardData> list = new List<PointRewardData>(pointRewardList.Count);
				for (int i = 0; i < pointRewardList.Count; i++)
				{
					PointRewardData pointRewardData = default(PointRewardData);
					pointRewardData.Init();
					pointRewardData.id = pointRewardList[i].id;
					pointRewardData.point = pointRewardList[i].point;
					for (int j = 0; j < pointRewardList[i].reward.Count; j++)
					{
						pointRewardData.rewardItem.Add(pointRewardList[i].reward[j, 0], pointRewardList[i].reward[j, 1]);
					}
					list.Add(pointRewardData);
				}
				this._PointRewardHandler.SetData(list, XSysDefine.XSys_Battlefield);
			}
			this._PointRewardHandler.SetVisible(true);
			return true;
		}

		// Token: 0x06009E99 RID: 40601 RVA: 0x001A16E0 File Offset: 0x0019F8E0
		public bool OnFallClicked(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<ItemListHandler>(ref this._ItemListHandler, base.uiBehaviour.transform, false, null);
			PandoraDocument specificDocument = XDocuments.GetSpecificDocument<PandoraDocument>(PandoraDocument.uuID);
			specificDocument.GetShowItemList(uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("BattleFieldShowFallPandoraid")));
			this._ItemListHandler.ShowItemList(PandoraDocument.ItemList);
			return true;
		}

		// Token: 0x04003853 RID: 14419
		private ItemListHandler _ItemListHandler;

		// Token: 0x04003854 RID: 14420
		public PointRewardHandler _PointRewardHandler;

		// Token: 0x04003855 RID: 14421
		private string[] reward = XSingleton<XGlobalConfig>.singleton.GetValue("BattleFieldShowReward").Split(new char[]
		{
			'|'
		});
	}
}

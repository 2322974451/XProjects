using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class BattleFieldEntranceView : DlgBase<BattleFieldEntranceView, BattleFieldEntranceBehaviour>
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
				return "GameSystem/BattleFieldEntrance";
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Battlefield);
			}
		}

		protected override void Init()
		{
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_Join.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinClicked));
			base.uiBehaviour.m_PointRewardBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPointRewardClicked));
			base.uiBehaviour.m_FallBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFallClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_Rule.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("BATTLEFIELD_RULE")));
			base.uiBehaviour.m_Time.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("BATTLEFIELD_TIME")));
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
			DlgHandlerBase.EnsureUnload<ItemListHandler>(ref this._ItemListHandler);
			DlgHandlerBase.EnsureUnload<PointRewardHandler>(ref this._PointRewardHandler);
			base.OnUnload();
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Battlefield);
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
				XBattleFieldEntranceDocument.Doc.ReqJoin();
				result = true;
			}
			return result;
		}

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

		public bool OnFallClicked(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<ItemListHandler>(ref this._ItemListHandler, base.uiBehaviour.transform, false, null);
			PandoraDocument specificDocument = XDocuments.GetSpecificDocument<PandoraDocument>(PandoraDocument.uuID);
			specificDocument.GetShowItemList(uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("BattleFieldShowFallPandoraid")));
			this._ItemListHandler.ShowItemList(PandoraDocument.ItemList);
			return true;
		}

		private ItemListHandler _ItemListHandler;

		public PointRewardHandler _PointRewardHandler;

		private string[] reward = XSingleton<XGlobalConfig>.singleton.GetValue("BattleFieldShowReward").Split(new char[]
		{
			'|'
		});
	}
}

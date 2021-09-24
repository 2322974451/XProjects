using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class SkyArenaEntranceView : DlgBase<SkyArenaEntranceView, SkyArenaEntranceBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/SkyArena/SkyArenaEntrance";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
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

		public override bool fullscreenui
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

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_MulActivity_SkyArena);
			}
		}

		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XSkyArenaEntranceDocument>(XSkyArenaEntranceDocument.uuID);
			this.doc.View = this;
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_SingleJoin.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartSingleClicked));
			base.uiBehaviour.m_TeamJoin.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartTeamClicked));
			base.uiBehaviour.m_RewardBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRewardClicked));
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_MulActivity_SkyArena);
			return true;
		}

		private bool OnStartSingleClicked(IXUIButton btn)
		{
			this.doc.ReqSingleJoin();
			return true;
		}

		private bool OnStartTeamClicked(IXUIButton btn)
		{
			this.SetVisible(false, true);
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			List<ExpeditionTable.RowData> expeditionList = specificDocument.GetExpeditionList(TeamLevelType.TeamLevelSkyArena);
			XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool flag = expeditionList.Count > 0;
			if (flag)
			{
				specificDocument2.SetAndMatch(expeditionList[0].DNExpeditionID);
			}
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshPage();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<PointRewardHandler>(ref this._PointRewardHandler);
			this.doc.View = null;
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		public void RefreshPage()
		{
			SkyArenaReward.RowData skyArenaRewardShow = this.doc.GetSkyArenaRewardShow();
			base.uiBehaviour.m_RewardPool.FakeReturnAll();
			for (int i = 0; i < skyArenaRewardShow.Reward.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_RewardPool.FetchGameObject(false);
				IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
				int spriteWidth = ixuisprite.spriteWidth;
				gameObject.transform.localPosition = new Vector3(((float)i + 0.5f - (float)skyArenaRewardShow.Reward.Count / 2f) * (float)spriteWidth, 0f, 0f);
				uint num = skyArenaRewardShow.Reward[i, 0];
				Transform transform = gameObject.transform.Find("Item");
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform.gameObject, (int)num, 0, false);
				IXUISprite ixuisprite2 = transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.ID = (ulong)num;
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClick));
			}
			base.uiBehaviour.m_RewardPool.ActualReturnAll(false);
			base.uiBehaviour.m_Time.SetText(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_TIME"));
		}

		private void _OnItemClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
		}

		public bool OnRewardClicked(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<PointRewardHandler>(ref this._PointRewardHandler, base.uiBehaviour.m_Bg, false, null);
			this.OpenReward(this._PointRewardHandler);
			return true;
		}

		public void OpenReward(PointRewardHandler handler)
		{
			bool flag = handler.Sys != XSysDefine.XSys_MulActivity_SkyArena;
			if (flag)
			{
				List<SkyArenaReward.RowData> skyArenaRewardList = XSkyArenaEntranceDocument.Doc.GetSkyArenaRewardList();
				List<PointRewardData> list = new List<PointRewardData>(skyArenaRewardList.Count);
				for (int i = 0; i < skyArenaRewardList.Count; i++)
				{
					PointRewardData pointRewardData = default(PointRewardData);
					pointRewardData.Init();
					pointRewardData.point = skyArenaRewardList[i].Floor;
					for (int j = 0; j < skyArenaRewardList[i].Reward.Count; j++)
					{
						pointRewardData.rewardItem.Add((int)skyArenaRewardList[i].Reward[j, 0], (int)skyArenaRewardList[i].Reward[j, 1]);
					}
					list.Add(pointRewardData);
				}
				handler.SetData(list, XSysDefine.XSys_MulActivity_SkyArena);
			}
			handler.SetVisible(true);
		}

		private XSkyArenaEntranceDocument doc = null;

		private PointRewardHandler _PointRewardHandler;
	}
}

using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E5A RID: 3674
	internal class XOnlineRewardView : DlgBase<XOnlineRewardView, XOnlineRewardBehaviour>
	{
		// Token: 0x17003479 RID: 13433
		// (get) Token: 0x0600C4D7 RID: 50391 RVA: 0x002B2070 File Offset: 0x002B0270
		public override string fileName
		{
			get
			{
				return "GameSystem/OnlineReward";
			}
		}

		// Token: 0x1700347A RID: 13434
		// (get) Token: 0x0600C4D8 RID: 50392 RVA: 0x002B2088 File Offset: 0x002B0288
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700347B RID: 13435
		// (get) Token: 0x0600C4D9 RID: 50393 RVA: 0x002B209C File Offset: 0x002B029C
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C4DA RID: 50394 RVA: 0x002B20B0 File Offset: 0x002B02B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.m_GetReward.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetRewardClick));
		}

		// Token: 0x0600C4DB RID: 50395 RVA: 0x002B2100 File Offset: 0x002B0300
		private bool OnCloseClick(IXUIButton button)
		{
			base.uiBehaviour.m_BgTween.PlayTween(false, -1f);
			base.uiBehaviour.m_BgTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnPlayTweenFinish));
			return true;
		}

		// Token: 0x0600C4DC RID: 50396 RVA: 0x002B2148 File Offset: 0x002B0348
		private bool OnGetRewardClick(IXUIButton button)
		{
			this._doc.SendGetReward(this._doc.CurrentID);
			return true;
		}

		// Token: 0x0600C4DD RID: 50397 RVA: 0x002B2172 File Offset: 0x002B0372
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XOnlineRewardDocument>(XOnlineRewardDocument.uuID);
		}

		// Token: 0x0600C4DE RID: 50398 RVA: 0x002B218C File Offset: 0x002B038C
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_ItemPool.FakeReturnAll();
			this._doc.QueryStatus();
			this.RefreshItemList();
			bool flag = this._doc.Status.Count > this._doc.CurrentID;
			if (flag)
			{
				this.SetGetRewardLabel(this._doc.Status[this._doc.CurrentID]);
			}
			else
			{
				this.SetGetRewardLabel(1);
			}
			base.uiBehaviour.m_BgTween.PlayTween(true, -1f);
			base.uiBehaviour.m_BgTween.RegisterOnFinishEventHandler(null);
		}

		// Token: 0x0600C4DF RID: 50399 RVA: 0x002B223F File Offset: 0x002B043F
		protected override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timeToken);
			base.OnUnload();
		}

		// Token: 0x0600C4E0 RID: 50400 RVA: 0x002B225C File Offset: 0x002B045C
		public void RefreshItemList()
		{
			base.uiBehaviour.m_ItemPool.FakeReturnAll();
			float num = base.uiBehaviour.m_ItemPool.TplPos.x - (float)(XOnlineRewardDocument.RewardTable.Table[this._doc.CurrentID].reward.Count - 1) / 2f * (float)base.uiBehaviour.m_ItemPool.TplWidth;
			for (int i = 0; i < XOnlineRewardDocument.RewardTable.Table[this._doc.CurrentID].reward.Count; i++)
			{
				uint num2 = XOnlineRewardDocument.RewardTable.Table[this._doc.CurrentID].reward[i, 0];
				uint itemCount = XOnlineRewardDocument.RewardTable.Table[this._doc.CurrentID].reward[i, 1];
				GameObject gameObject = base.uiBehaviour.m_ItemPool.FetchGameObject(false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)num2;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)num2, (int)itemCount, false);
				gameObject.transform.localPosition = new Vector3(num + (float)(i * base.uiBehaviour.m_ItemPool.TplWidth), base.uiBehaviour.m_ItemPool.TplPos.y);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
			base.uiBehaviour.m_ItemPool.ActualReturnAll(false);
		}

		// Token: 0x0600C4E1 RID: 50401 RVA: 0x002B2408 File Offset: 0x002B0608
		public void SetGetRewardLabel(int status)
		{
			bool flag = status == 0;
			if (flag)
			{
				base.uiBehaviour.m_GetReward.SetEnable(false, false);
				base.uiBehaviour.m_GetRewardLabel.SetText(XStringDefineProxy.GetString("SRS_FETCH"));
			}
			else
			{
				bool flag2 = status == 1;
				if (flag2)
				{
					base.uiBehaviour.m_GetReward.SetEnable(true, false);
					base.uiBehaviour.m_GetRewardLabel.SetText(XStringDefineProxy.GetString("SRS_FETCH"));
				}
				else
				{
					bool flag3 = status == 2;
					if (flag3)
					{
						base.uiBehaviour.m_GetReward.SetEnable(false, false);
						base.uiBehaviour.m_GetRewardLabel.SetText(XStringDefineProxy.GetString("SRS_FETCHED"));
					}
				}
			}
			this.SetLeftTime(null);
			base.uiBehaviour.m_TimeTip.SetText(XOnlineRewardDocument.RewardTable.Table[this._doc.CurrentID].RewardTip);
		}

		// Token: 0x0600C4E2 RID: 50402 RVA: 0x002B24F6 File Offset: 0x002B06F6
		public void OnPlayTweenFinish(IXUITweenTool tween)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x0600C4E3 RID: 50403 RVA: 0x002B2504 File Offset: 0x002B0704
		public void SetLeftTime(object o = null)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this._doc.Status.Count > this._doc.CurrentID && this._doc.Status[this._doc.CurrentID] != 2 && XSingleton<XGameSysMgr>.singleton.OnlineRewardRemainTime > 0f;
				if (flag2)
				{
					base.uiBehaviour.m_LeftTime.SetVisible(true);
					base.uiBehaviour.m_LeftTime.SetText(string.Format("{0} {1}", XSingleton<UiUtility>.singleton.TimeFormatString((int)XSingleton<XGameSysMgr>.singleton.OnlineRewardRemainTime, 2, 3, 4, false, true), XStringDefineProxy.GetString("AFTER_TIME_REWARD")));
					XSingleton<XTimerMgr>.singleton.KillTimer(this._timeToken);
					this._timeToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.SetLeftTime), null);
				}
				else
				{
					bool flag3 = base.uiBehaviour.m_LeftTime.IsVisible();
					if (flag3)
					{
						this._doc.QueryStatus();
					}
					base.uiBehaviour.m_LeftTime.SetVisible(false);
				}
			}
		}

		// Token: 0x040055DF RID: 21983
		private XOnlineRewardDocument _doc = null;

		// Token: 0x040055E0 RID: 21984
		private uint _timeToken;
	}
}

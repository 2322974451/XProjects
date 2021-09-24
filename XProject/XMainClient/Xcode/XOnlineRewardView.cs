using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XOnlineRewardView : DlgBase<XOnlineRewardView, XOnlineRewardBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/OnlineReward";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.m_GetReward.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetRewardClick));
		}

		private bool OnCloseClick(IXUIButton button)
		{
			base.uiBehaviour.m_BgTween.PlayTween(false, -1f);
			base.uiBehaviour.m_BgTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnPlayTweenFinish));
			return true;
		}

		private bool OnGetRewardClick(IXUIButton button)
		{
			this._doc.SendGetReward(this._doc.CurrentID);
			return true;
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XOnlineRewardDocument>(XOnlineRewardDocument.uuID);
		}

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

		protected override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timeToken);
			base.OnUnload();
		}

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

		public void OnPlayTweenFinish(IXUITweenTool tween)
		{
			this.SetVisible(false, true);
		}

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

		private XOnlineRewardDocument _doc = null;

		private uint _timeToken;
	}
}

using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D09 RID: 3337
	internal class SpectateHandler : DlgHandlerBase
	{
		// Token: 0x0600BA78 RID: 47736 RVA: 0x00260FF4 File Offset: 0x0025F1F4
		protected override void Init()
		{
			base.Init();
			this.COMMENDCDTIME = (ulong)((long)XSingleton<XGlobalConfig>.singleton.GetInt("WatchCommendTimeSpan"));
			this.COMMENDTIMESLIMIT = XSingleton<XGlobalConfig>.singleton.GetInt("WatchCommendTotalCount");
			this.m_WatchNum = (base.PanelObject.transform.Find("WatchNum").GetComponent("XUILabel") as IXUILabel);
			this.m_CommendNum = (base.PanelObject.transform.Find("CommendNum").GetComponent("XUILabel") as IXUILabel);
			XSpectateSceneDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
			specificDocument.GetTargetNum(false);
			this.m_WatchNum.SetText((specificDocument.WatchNum + 1).ToString());
			this.m_CommendNum.SetText(specificDocument.CommendNum.ToString());
			XSingleton<XDebug>.singleton.AddLog("WatchNum = ", specificDocument.WatchNum.ToString(), "  CommendNum = ", specificDocument.CommendNum.ToString(), null, null, XDebugColor.XDebug_None);
			bool flag = specificDocument.WatchNum + 1 < specificDocument.WatchTarget && specificDocument.CommendNum < specificDocument.CommendTarget;
			if (flag)
			{
				this.m_WatchNum.gameObject.SetActive(false);
				this.m_CommendNum.gameObject.SetActive(false);
				this._isShow = false;
				XSingleton<XDebug>.singleton.AddLog("WatchNum and Commend Hide", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				this._isShow = true;
				XSingleton<XDebug>.singleton.AddLog("WatchNum and Commend Show", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			this.m_CommendBtn = (base.PanelObject.transform.Find("Zan").GetComponent("XUIButton") as IXUIButton);
			this.m_HideBtn = (base.PanelObject.transform.Find("Hide/hide").GetComponent("XUIButton") as IXUIButton);
			this.m_ShowBtn = (base.PanelObject.transform.Find("Hide/unhide").GetComponent("XUIButton") as IXUIButton);
			this.m_ShowBtn.gameObject.transform.localPosition = Vector3.one * (float)XGameUI._far_far_away;
			this.m_EffectPos = base.PanelObject.transform.Find("Effect");
		}

		// Token: 0x0600BA79 RID: 47737 RVA: 0x00261244 File Offset: 0x0025F444
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_ShowBtn.ID = 1UL;
			this.m_HideBtn.ID = 0UL;
			this.m_ShowBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowOrHideBtnClick));
			this.m_HideBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowOrHideBtnClick));
			this.m_CommendBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCommendBtnClick));
		}

		// Token: 0x0600BA7A RID: 47738 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600BA7B RID: 47739 RVA: 0x002612C0 File Offset: 0x0025F4C0
		protected override void OnHide()
		{
			for (int i = this._fxFireworkList.Count - 1; i >= 0; i--)
			{
				bool flag = this._fxFireworkList[i] != null;
				if (flag)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this._fxFireworkList[i], true);
				}
			}
			this._fxFireworkList.Clear();
			base.OnHide();
		}

		// Token: 0x0600BA7C RID: 47740 RVA: 0x00261330 File Offset: 0x0025F530
		public override void OnUnload()
		{
			for (int i = this._fxFireworkList.Count - 1; i >= 0; i--)
			{
				bool flag = this._fxFireworkList[i] != null;
				if (flag)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this._fxFireworkList[i], true);
				}
			}
			this._fxFireworkList.Clear();
			base.OnUnload();
		}

		// Token: 0x0600BA7D RID: 47741 RVA: 0x002613A0 File Offset: 0x0025F5A0
		public bool OnShowOrHideBtnClick(IXUIButton btn)
		{
			bool flag = !DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsVisible();
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = btn.ID == 1UL;
				if (flag2)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.SetVisible(true);
					this.m_ShowBtn.gameObject.transform.localPosition = Vector3.one * (float)XGameUI._far_far_away;
					this.m_HideBtn.gameObject.transform.localPosition = Vector3.zero;
				}
				else
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor.SetVisible(false);
					this.m_ShowBtn.gameObject.transform.localPosition = Vector3.zero;
					this.m_HideBtn.gameObject.transform.localPosition = Vector3.one * (float)XGameUI._far_far_away;
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600BA7E RID: 47742 RVA: 0x00261484 File Offset: 0x0025F684
		public bool OnCommendBtnClick(IXUIButton btn)
		{
			double nowTime = this.GetNowTime();
			ulong num = (ulong)(nowTime - this._lastCommendTime);
			XSpectateSceneDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
			bool flag = this.CurrClickTimes < this.COMMENDTIMESLIMIT;
			bool result;
			if (flag)
			{
				bool flag2 = this.CurrClickTimes == 0;
				if (flag2)
				{
					this._lastCommendTime = nowTime;
				}
				specificDocument.SendCommendBtnClick();
				result = true;
			}
			else
			{
				bool flag3 = num <= this.COMMENDCDTIME;
				if (flag3)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("Spectate_CommendCD_Tips"), this.COMMENDCDTIME - num + 1UL), "fece00");
					result = true;
				}
				else
				{
					this.CurrClickTimes = 0;
					this._lastCommendTime = nowTime;
					specificDocument.SendCommendBtnClick();
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600BA7F RID: 47743 RVA: 0x00261548 File Offset: 0x0025F748
		public void CommendSuccess()
		{
			this.CurrClickTimes++;
			XFx item = XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_gz_xq", this.m_EffectPos, Vector3.zero, Vector3.one, 1f, true, 2f, true);
			this._fxFireworkList.Add(item);
		}

		// Token: 0x0600BA80 RID: 47744 RVA: 0x002615A0 File Offset: 0x0025F7A0
		public void OnMessageChange(int watchNum, int commendNum)
		{
			XSpectateSceneDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
			specificDocument.WatchNum = watchNum;
			specificDocument.CommendNum = commendNum;
			bool isShow = this._isShow;
			if (isShow)
			{
				this.m_WatchNum.SetText(watchNum.ToString());
				this.m_CommendNum.SetText(commendNum.ToString());
			}
			else
			{
				bool flag = watchNum >= specificDocument.WatchTarget || commendNum >= specificDocument.CommendTarget;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddLog("watchNum and commendNum are enough now.", null, null, null, null, null, XDebugColor.XDebug_None);
					this._isShow = true;
					this.m_WatchNum.gameObject.SetActive(true);
					this.m_CommendNum.gameObject.SetActive(true);
					this.m_WatchNum.SetText(watchNum.ToString());
					this.m_CommendNum.SetText(commendNum.ToString());
				}
			}
		}

		// Token: 0x0600BA81 RID: 47745 RVA: 0x00261688 File Offset: 0x0025F888
		private double GetNowTime()
		{
			return (double)(DateTime.Now.Ticks / 10000000L);
		}

		// Token: 0x04004ACB RID: 19147
		private IXUILabel m_WatchNum;

		// Token: 0x04004ACC RID: 19148
		private IXUILabel m_CommendNum;

		// Token: 0x04004ACD RID: 19149
		private IXUIButton m_CommendBtn;

		// Token: 0x04004ACE RID: 19150
		private IXUIButton m_HideBtn;

		// Token: 0x04004ACF RID: 19151
		private IXUIButton m_ShowBtn;

		// Token: 0x04004AD0 RID: 19152
		private double _lastCommendTime = 0.0;

		// Token: 0x04004AD1 RID: 19153
		private bool _isShow;

		// Token: 0x04004AD2 RID: 19154
		private ulong COMMENDCDTIME;

		// Token: 0x04004AD3 RID: 19155
		private int COMMENDTIMESLIMIT;

		// Token: 0x04004AD4 RID: 19156
		public int CurrClickTimes = 0;

		// Token: 0x04004AD5 RID: 19157
		private List<XFx> _fxFireworkList = new List<XFx>();

		// Token: 0x04004AD6 RID: 19158
		private Transform m_EffectPos;
	}
}

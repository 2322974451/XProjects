using System;
using System.Collections.Generic;
using MiniJSON;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200178E RID: 6030
	internal class WebView : DlgBase<WebView, WebViewBehaviour>
	{
		// Token: 0x1700383F RID: 14399
		// (get) Token: 0x0600F8C5 RID: 63685 RVA: 0x0038F52C File Offset: 0x0038D72C
		public override string fileName
		{
			get
			{
				return "GameSystem/PlatformAbility/WebViewDlg";
			}
		}

		// Token: 0x17003840 RID: 14400
		// (get) Token: 0x0600F8C6 RID: 63686 RVA: 0x0038F544 File Offset: 0x0038D744
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003841 RID: 14401
		// (get) Token: 0x0600F8C7 RID: 63687 RVA: 0x0038F558 File Offset: 0x0038D758
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003842 RID: 14402
		// (get) Token: 0x0600F8C8 RID: 63688 RVA: 0x0038F56C File Offset: 0x0038D76C
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003843 RID: 14403
		// (get) Token: 0x0600F8C9 RID: 63689 RVA: 0x0038F580 File Offset: 0x0038D780
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003844 RID: 14404
		// (get) Token: 0x0600F8CA RID: 63690 RVA: 0x0038F594 File Offset: 0x0038D794
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F8CB RID: 63691 RVA: 0x0038F5A7 File Offset: 0x0038D7A7
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
		}

		// Token: 0x0600F8CC RID: 63692 RVA: 0x0038F5C4 File Offset: 0x0038D7C4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.mCloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
			base.uiBehaviour.mBackBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBack));
			base.uiBehaviour.mCheckLive.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnModeChanged));
			base.uiBehaviour.mCheckVideo.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnModeChanged));
			base.uiBehaviour.mCollect.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCollectPage));
			base.uiBehaviour.mTryAgain.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnRetryLabel));
		}

		// Token: 0x0600F8CD RID: 63693 RVA: 0x0038F687 File Offset: 0x0038D887
		private void OnRedPointRefersh(bool show)
		{
			base.uiBehaviour.mRedPoint.SetVisible(show);
		}

		// Token: 0x0600F8CE RID: 63694 RVA: 0x0038F69C File Offset: 0x0038D89C
		protected override void OnShow()
		{
			base.uiBehaviour.mVideoTitle.SetVisible(false);
			base.uiBehaviour.mChoiceSp.SetVisible(true);
			base.uiBehaviour.mRedPoint.SetVisible(false);
			base.uiBehaviour.mTryAgainTip.SetVisible(false);
			this._network_token = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.OnRefreshNetWorkStatus), null);
			this.StartLoading();
			base.uiBehaviour.mCheckLive.bChecked = true;
			XSingleton<XChatIFlyMgr>.singleton.OnOpenWebView();
			base.uiBehaviour.mBackBtn.SetVisible(false);
			base.uiBehaviour.mCloseBtn.SetVisible(true);
			this.SetNetWorkStatus(0);
		}

		// Token: 0x0600F8CF RID: 63695 RVA: 0x0038F764 File Offset: 0x0038D964
		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._network_token);
			this._network_token = 0U;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._loading_token);
			this._loading_token = 0U;
			this._is_loading = false;
		}

		// Token: 0x0600F8D0 RID: 63696 RVA: 0x0038F7B0 File Offset: 0x0038D9B0
		private bool OnClose(IXUIButton btn)
		{
			XSingleton<XChatIFlyMgr>.singleton.OnCloseWebView();
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600F8D1 RID: 63697 RVA: 0x0038F7D8 File Offset: 0x0038D9D8
		private bool OnBack(IXUIButton btn)
		{
			XSingleton<XChatIFlyMgr>.singleton.OnEvalWebViewJs("DNBackClick()");
			return true;
		}

		// Token: 0x0600F8D2 RID: 63698 RVA: 0x0038F7FC File Offset: 0x0038D9FC
		private bool OnCollectPage(IXUIButton btn)
		{
			XSingleton<XChatIFlyMgr>.singleton.OnEvalWebViewJs("DNCollectClick()");
			return true;
		}

		// Token: 0x0600F8D3 RID: 63699 RVA: 0x0038F820 File Offset: 0x0038DA20
		public bool OnModeChanged(IXUICheckBox box)
		{
			bool is_loading = this._is_loading;
			bool result;
			if (is_loading)
			{
				result = false;
			}
			else
			{
				bool bChecked = box.bChecked;
				if (bChecked)
				{
					bool flag = box.ID == 1UL;
					if (flag)
					{
						XSingleton<XDebug>.singleton.AddLog("Live click", null, null, null, null, null, XDebugColor.XDebug_None);
						XSingleton<XChatIFlyMgr>.singleton.OnEvalWebViewJs("DNLiveClick()");
					}
					else
					{
						bool flag2 = box.ID == 2UL;
						if (flag2)
						{
							XSingleton<XDebug>.singleton.AddLog("Video click", null, null, null, null, null, XDebugColor.XDebug_None);
							XSingleton<XChatIFlyMgr>.singleton.OnEvalWebViewJs("DNVideoClick()");
						}
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600F8D4 RID: 63700 RVA: 0x0038F8C0 File Offset: 0x0038DAC0
		public void OnRetryLabel(IXUILabel label)
		{
			this.StartLoading();
			XSingleton<XChatIFlyMgr>.singleton.OnRefreshWebViewShow(true);
		}

		// Token: 0x0600F8D5 RID: 63701 RVA: 0x0038F8D8 File Offset: 0x0038DAD8
		public void OnShowDetail(string label)
		{
			base.uiBehaviour.mVideoTitle.SetVisible(true);
			base.uiBehaviour.mVideoTitle.SetText(label);
			base.uiBehaviour.mChoiceSp.SetVisible(false);
			base.uiBehaviour.mBackBtn.SetVisible(true);
			base.uiBehaviour.mCloseBtn.SetVisible(false);
		}

		// Token: 0x0600F8D6 RID: 63702 RVA: 0x0038F940 File Offset: 0x0038DB40
		public void SetNetWorkStatus(int status)
		{
			bool flag = status == 0;
			if (flag)
			{
				base.uiBehaviour.mNetWorkStaus.SetVisible(false);
				base.uiBehaviour.mNetWorkWifi.SetVisible(true);
			}
			else
			{
				bool flag2 = status == 1;
				if (flag2)
				{
					base.uiBehaviour.mNetWorkStaus.SetVisible(true);
					base.uiBehaviour.mNetWorkWifi.SetVisible(false);
					base.uiBehaviour.mNetWorkStaus.SetSprite("xh_2");
				}
				else
				{
					base.uiBehaviour.mNetWorkStaus.SetVisible(true);
					base.uiBehaviour.mNetWorkWifi.SetVisible(false);
					base.uiBehaviour.mNetWorkStaus.SetSprite("xh_0");
				}
			}
		}

		// Token: 0x0600F8D7 RID: 63703 RVA: 0x0038FA04 File Offset: 0x0038DC04
		public void OnRefreshNetWorkStatus(object obj)
		{
			int netWorkStatus = 0;
			bool flag = Application.internetReachability == 0;
			if (flag)
			{
				netWorkStatus = 2;
			}
			else
			{
				bool flag2 = Application.internetReachability == (NetworkReachability)2;
				if (flag2)
				{
					netWorkStatus = 0;
				}
				else
				{
					bool flag3 = Application.internetReachability == (NetworkReachability)1;
					if (flag3)
					{
						netWorkStatus = 1;
					}
				}
			}
			this.SetNetWorkStatus(netWorkStatus);
			this._network_token = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.OnRefreshNetWorkStatus), null);
		}

		// Token: 0x0600F8D8 RID: 63704 RVA: 0x0038FA6C File Offset: 0x0038DC6C
		public void OnTabLive()
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				base.uiBehaviour.mCheckLive.bChecked = true;
			}
		}

		// Token: 0x0600F8D9 RID: 63705 RVA: 0x0038FA98 File Offset: 0x0038DC98
		private void StartLoading()
		{
			this._is_loading = true;
			this._loading_token = XSingleton<XTimerMgr>.singleton.SetTimer(10f, new XTimerMgr.ElapsedEventHandler(this.OnLoadingFailed), null);
			base.uiBehaviour.mLoading.SetVisible(true);
			base.uiBehaviour.mTryAgainTip.SetVisible(false);
		}

		// Token: 0x0600F8DA RID: 63706 RVA: 0x0038FAF3 File Offset: 0x0038DCF3
		private void OnLoadingFailed(object obj)
		{
			this._is_loading = false;
			base.uiBehaviour.mLoading.SetVisible(false);
			base.uiBehaviour.mTryAgainTip.SetVisible(true);
		}

		// Token: 0x0600F8DB RID: 63707 RVA: 0x0038FB21 File Offset: 0x0038DD21
		public void OnLoadFinished()
		{
			base.uiBehaviour.mLoading.SetVisible(false);
			this._is_loading = false;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._loading_token);
			this._loading_token = 0U;
		}

		// Token: 0x0600F8DC RID: 63708 RVA: 0x0038FB58 File Offset: 0x0038DD58
		public void OnSetWebViewMenu(int menutype)
		{
			bool flag = !base.IsLoaded() || !base.IsVisible();
			if (!flag)
			{
				bool flag2 = menutype == 0;
				if (flag2)
				{
					base.uiBehaviour.mVideoTitle.SetVisible(false);
					base.uiBehaviour.mChoiceSp.SetVisible(true);
				}
				else
				{
					base.uiBehaviour.mVideoTitle.SetVisible(true);
					base.uiBehaviour.mChoiceSp.SetVisible(false);
					base.uiBehaviour.mVideoTitle.SetText("");
					base.uiBehaviour.mBackBtn.SetVisible(true);
					base.uiBehaviour.mCloseBtn.SetVisible(false);
				}
			}
		}

		// Token: 0x0600F8DD RID: 63709 RVA: 0x0038FC14 File Offset: 0x0038DE14
		public void OnWebViewBackGame(int backtype)
		{
			bool flag = !base.IsLoaded() || !base.IsVisible();
			if (!flag)
			{
				bool flag2 = backtype == 0;
				if (flag2)
				{
					base.uiBehaviour.mVideoTitle.SetVisible(false);
					base.uiBehaviour.mChoiceSp.SetVisible(true);
				}
				else
				{
					this.SetVisible(false, true);
				}
			}
		}

		// Token: 0x0600F8DE RID: 63710 RVA: 0x0038FC78 File Offset: 0x0038DE78
		public void OnWebViewRefershRefPoint(string jsonstr)
		{
			bool flag = !base.IsLoaded() || !base.IsVisible();
			if (!flag)
			{
				object obj = Json.Deserialize(jsonstr);
				Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
				bool flag2 = dictionary.ContainsKey("extendMenus");
				if (flag2)
				{
					object obj2 = dictionary["extendMenus"];
					List<object> list = obj2 as List<object>;
					bool flag3 = list != null && list.Count > 0;
					if (flag3)
					{
						Dictionary<string, object> dictionary2 = list[0] as Dictionary<string, object>;
						bool flag4 = dictionary2 != null && dictionary2.ContainsKey("isRed");
						if (flag4)
						{
							int num = 0;
							int.TryParse(dictionary2["isRed"].ToString(), out num);
							base.uiBehaviour.mRedPoint.SetVisible(num == 1);
						}
					}
				}
			}
		}

		// Token: 0x0600F8DF RID: 63711 RVA: 0x0038FD50 File Offset: 0x0038DF50
		public void OnWebViewSetheaderInfo(string jsonstr)
		{
			bool flag = !base.IsLoaded() || !base.IsVisible();
			if (!flag)
			{
				this.OnWebViewRefershRefPoint(jsonstr);
				object obj = Json.Deserialize(jsonstr);
				Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
				bool flag2 = dictionary.ContainsKey("title");
				if (flag2)
				{
					string text = dictionary["title"] as string;
					bool flag3 = !string.IsNullOrEmpty(text);
					if (flag3)
					{
						base.uiBehaviour.mVideoTitle.SetText(text);
						base.uiBehaviour.mBackBtn.SetVisible(true);
						base.uiBehaviour.mCloseBtn.SetVisible(false);
					}
				}
			}
		}

		// Token: 0x0600F8E0 RID: 63712 RVA: 0x0038FE00 File Offset: 0x0038E000
		public void OnWebViewCloseLoading(int show)
		{
			bool flag = !base.IsLoaded() || !base.IsVisible();
			if (!flag)
			{
				bool flag2 = show == 1;
				if (flag2)
				{
					base.uiBehaviour.mLoading.SetVisible(true);
					base.uiBehaviour.mTryAgainTip.SetVisible(false);
					this._is_loading = true;
					this._loading_token = XSingleton<XTimerMgr>.singleton.SetTimer(10f, new XTimerMgr.ElapsedEventHandler(this.OnLoadingFailed), null);
				}
				else
				{
					base.uiBehaviour.mLoading.SetVisible(false);
					XSingleton<XTimerMgr>.singleton.KillTimer(this._loading_token);
					this._loading_token = 0U;
					this._is_loading = false;
				}
			}
		}

		// Token: 0x0600F8E1 RID: 63713 RVA: 0x0038FEB8 File Offset: 0x0038E0B8
		public void OnWebViewShowReconnect(int show)
		{
			bool flag = !base.IsLoaded() || !base.IsVisible();
			if (!flag)
			{
				bool flag2 = show == 1;
				if (flag2)
				{
					base.uiBehaviour.mLoading.SetVisible(false);
					base.uiBehaviour.mTryAgainTip.SetVisible(true);
				}
				else
				{
					base.uiBehaviour.mTryAgainTip.SetVisible(false);
				}
			}
		}

		// Token: 0x0600F8E2 RID: 63714 RVA: 0x0038FF24 File Offset: 0x0038E124
		public void OnScreenLock(bool islock)
		{
			bool flag = !base.IsLoaded() || !base.IsVisible();
			if (!flag)
			{
				XSingleton<XChatIFlyMgr>.singleton.OnWebViewScreenLock(islock);
			}
		}

		// Token: 0x0600F8E3 RID: 63715 RVA: 0x0038FF58 File Offset: 0x0038E158
		public void HandleScreenLock(string msg)
		{
			bool flag = !base.IsLoaded() || !base.IsVisible();
			if (!flag)
			{
				XSingleton<XDebug>.singleton.AddLog("Screen lock: ", msg, null, null, null, null, XDebugColor.XDebug_None);
				object obj = Json.Deserialize(msg);
				Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
				bool flag2 = dictionary.ContainsKey("data");
				if (flag2)
				{
					Dictionary<string, object> dictionary2 = dictionary["data"] as Dictionary<string, object>;
					bool flag3 = dictionary2 != null;
					if (flag3)
					{
						bool flag4 = dictionary2.ContainsKey("flag");
						if (flag4)
						{
							bool flag5 = dictionary2["flag"].ToString() == "lock";
							bool islock = flag5;
							XSingleton<XDebug>.singleton.AddLog("Will eval screen lock: ", islock.ToString(), null, null, null, null, XDebugColor.XDebug_None);
							XSingleton<XChatIFlyMgr>.singleton.OnWebViewScreenLock(islock);
						}
					}
				}
			}
		}

		// Token: 0x04006C92 RID: 27794
		private uint _network_token = 0U;

		// Token: 0x04006C93 RID: 27795
		private uint _loading_token = 0U;

		// Token: 0x04006C94 RID: 27796
		private bool _is_loading = false;

		// Token: 0x04006C95 RID: 27797
		private XMainInterfaceDocument _doc = null;
	}
}

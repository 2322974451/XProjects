using System;
using System.Collections.Generic;
using MiniJSON;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class WebView : DlgBase<WebView, WebViewBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/PlatformAbility/WebViewDlg";
			}
		}

		public override int layer
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

		public override bool pushstack
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

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
		}

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

		private void OnRedPointRefersh(bool show)
		{
			base.uiBehaviour.mRedPoint.SetVisible(show);
		}

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

		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._network_token);
			this._network_token = 0U;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._loading_token);
			this._loading_token = 0U;
			this._is_loading = false;
		}

		private bool OnClose(IXUIButton btn)
		{
			XSingleton<XChatIFlyMgr>.singleton.OnCloseWebView();
			this.SetVisible(false, true);
			return true;
		}

		private bool OnBack(IXUIButton btn)
		{
			XSingleton<XChatIFlyMgr>.singleton.OnEvalWebViewJs("DNBackClick()");
			return true;
		}

		private bool OnCollectPage(IXUIButton btn)
		{
			XSingleton<XChatIFlyMgr>.singleton.OnEvalWebViewJs("DNCollectClick()");
			return true;
		}

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

		public void OnRetryLabel(IXUILabel label)
		{
			this.StartLoading();
			XSingleton<XChatIFlyMgr>.singleton.OnRefreshWebViewShow(true);
		}

		public void OnShowDetail(string label)
		{
			base.uiBehaviour.mVideoTitle.SetVisible(true);
			base.uiBehaviour.mVideoTitle.SetText(label);
			base.uiBehaviour.mChoiceSp.SetVisible(false);
			base.uiBehaviour.mBackBtn.SetVisible(true);
			base.uiBehaviour.mCloseBtn.SetVisible(false);
		}

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

		public void OnTabLive()
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				base.uiBehaviour.mCheckLive.bChecked = true;
			}
		}

		private void StartLoading()
		{
			this._is_loading = true;
			this._loading_token = XSingleton<XTimerMgr>.singleton.SetTimer(10f, new XTimerMgr.ElapsedEventHandler(this.OnLoadingFailed), null);
			base.uiBehaviour.mLoading.SetVisible(true);
			base.uiBehaviour.mTryAgainTip.SetVisible(false);
		}

		private void OnLoadingFailed(object obj)
		{
			this._is_loading = false;
			base.uiBehaviour.mLoading.SetVisible(false);
			base.uiBehaviour.mTryAgainTip.SetVisible(true);
		}

		public void OnLoadFinished()
		{
			base.uiBehaviour.mLoading.SetVisible(false);
			this._is_loading = false;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._loading_token);
			this._loading_token = 0U;
		}

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

		public void OnScreenLock(bool islock)
		{
			bool flag = !base.IsLoaded() || !base.IsVisible();
			if (!flag)
			{
				XSingleton<XChatIFlyMgr>.singleton.OnWebViewScreenLock(islock);
			}
		}

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

		private uint _network_token = 0U;

		private uint _loading_token = 0U;

		private bool _is_loading = false;

		private XMainInterfaceDocument _doc = null;
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using UILib;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI.UICommon
{

	internal class UIManager : XSingleton<UIManager>
	{

		public Transform UIRoot
		{
			get
			{
				return this.m_uiRoot;
			}
			set
			{
				this.m_uiRoot = value;
			}
		}

		public void OnEnterScene()
		{
			this.m_LFU.Clear();
			this.m_ShowedDlg.Clear();
			this.m_TutorialClashUICount = 0;
			this.m_CachedExculsiveUI.Clear();
			this.m_ShowUIStack.Clear();
			this.m_ToBeUnloadDlg.Clear();
			this.m_StoreUIList.Clear();
			this.unloadUICount = 0;
		}

		public void OnLeaveScene(bool transfer)
		{
			for (int i = this.m_iterDlgs.Count - 1; i >= 0; i--)
			{
				bool flag = i < this.m_iterDlgs.Count && this.m_iterDlgs[i] != null;
				if (flag)
				{
					this.m_iterDlgs[i].UnLoad(transfer);
				}
			}
			this.m_AvatarStack.Clear();
			this.unloadUICount = 0;
		}

		public override bool Init()
		{
			RuntimePlatform platform = Application.platform;
			int @int;
			if (platform != (RuntimePlatform)8)
			{
				if (platform != (RuntimePlatform)11)
				{
					@int = XSingleton<XGlobalConfig>.singleton.GetInt("UIUnloadLFUSizeDefault");
				}
				else
				{
					@int = XSingleton<XGlobalConfig>.singleton.GetInt("UIUnloadLFUSizeAndroid");
				}
			}
			else
			{
				@int = XSingleton<XGlobalConfig>.singleton.GetInt("UIUnloadLFUSizeIPhone");
			}
			this.m_LFU = new XLFU<IXUIDlg>(@int);
			return true;
		}

		public override void Uninit()
		{
		}

		public void LoadUI(string strUIFile, LoadUIFinishedEventHandler eventHandler)
		{
			bool flag = eventHandler != null;
			if (flag)
			{
				eventHandler(strUIFile);
			}
		}

		public void Update(float fDeltaT)
		{
			int i = 0;
			while (i < this.m_iterDlgs.Count)
			{
				IXUIDlg ixuidlg = this.m_iterDlgs[i];
				bool flag = ixuidlg != null;
				if (flag)
				{
					bool flag2 = ixuidlg.uiBehaviourInterface == null || ixuidlg.uiBehaviourInterface.gameObject == null;
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("UI missing: ", ixuidlg.fileName, null, null, null, null);
					}
					else
					{
						bool activeInHierarchy = ixuidlg.uiBehaviourInterface.gameObject.activeInHierarchy;
						if (activeInHierarchy)
						{
							ixuidlg.OnUpdate();
						}
					}
				}
				IL_78:
				i++;
				continue;
				goto IL_78;
			}
		}

		public void PostUpdate(float fDeltaT)
		{
			for (int i = 0; i < this.m_iterDlgs.Count; i++)
			{
				bool flag = this.m_iterDlgs[i] != null;
				if (flag)
				{
					this.m_iterDlgs[i].OnPostUpdate();
				}
			}
			bool flag2 = this.m_ToBeUnloadDlg.Count > 0;
			if (flag2)
			{
				for (int j = 0; j < this.m_ToBeUnloadDlg.Count; j++)
				{
					this.m_ToBeUnloadDlg[j].UnLoad(false);
				}
				this.m_ToBeUnloadDlg.Clear();
			}
		}

		public bool IsUIShowed()
		{
			bool flag = this.m_ShowUIStack.Count > 0;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.IsLoaded() && DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.IsVisible();
					if (flag3)
					{
						result = true;
					}
					else
					{
						bool flag4 = XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine.luaUIManager.IsUIShowed();
						result = flag4;
					}
				}
			}
			return result;
		}

		public bool IsHideTutorial()
		{
			return this.m_TutorialClashUICount != 0;
		}

		public int GetUIStackCount()
		{
			return this.m_ShowUIStack.Count;
		}

		public int GetFullScreenUICount()
		{
			int num = 0;
			foreach (IXUIDlg ixuidlg in this.m_ShowUIStack)
			{
				bool fullscreenui = ixuidlg.fullscreenui;
				if (fullscreenui)
				{
					num++;
				}
			}
			return num;
		}

		public void RemoveDlg(IXUIDlg dlg)
		{
			List<IXUIDlg> list = null;
			bool flag = this.m_dicUILayer.TryGetValue(dlg.layer, out list);
			if (flag)
			{
				list.Remove(dlg);
			}
			bool flag2 = this.m_dicDlgs.ContainsKey(dlg.fileName);
			if (flag2)
			{
				this.m_dicDlgs.Remove(dlg.fileName);
				this.m_iterDlgs.Remove(dlg);
			}
			bool flag3 = this.m_GroupDlg.ContainsKey(dlg.group);
			if (flag3)
			{
				this.m_GroupDlg.Remove(dlg.group);
			}
			bool flag4 = this.m_ShowedDlg.Contains(dlg);
			if (flag4)
			{
				bool isHideTutorial = dlg.isHideTutorial;
				if (isHideTutorial)
				{
					this.ChangeTutorialClashUI(false);
				}
				this.m_ShowedDlg.Remove(dlg);
			}
			this.m_LFU.Remove(dlg);
			this.m_AvatarStack.Remove(dlg);
		}

		public bool AddDlg(IXUIDlg dlg)
		{
			bool flag = this.m_dicDlgs.ContainsKey(dlg.fileName);
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("true == m_dicDlgs.ContainsKey(dlg.fileName): ", dlg.fileName, null, null, null, null, XDebugColor.XDebug_None);
				result = false;
			}
			else
			{
				this.m_dicDlgs.Add(dlg.fileName, dlg);
				this.m_iterDlgs.Add(dlg);
				List<IXUIDlg> list = null;
				bool flag2 = this.m_dicUILayer.TryGetValue(dlg.layer, out list);
				if (flag2)
				{
					list.Add(dlg);
				}
				else
				{
					list = new List<IXUIDlg>();
					list.Add(dlg);
					this.m_dicUILayer.Add(dlg.layer, list);
				}
				result = true;
			}
			return result;
		}

		protected void CacheExclusiveUI()
		{
			this.m_CachedExculsiveUI.Clear();
			for (int i = 0; i < this.m_ShowedDlg.Count; i++)
			{
				this.m_CachedExculsiveUI.Add(this.m_ShowedDlg[i]);
			}
		}

		public void CloseAllUI()
		{
			this.ClearUIinStack();
			List<IXUIDlg> list = new List<IXUIDlg>();
			for (int i = 0; i < this.m_ShowedDlg.Count; i++)
			{
				bool flag = !this.m_ShowedDlg[i].isMainUI;
				if (flag)
				{
					list.Add(this.m_ShowedDlg[i]);
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				list[j].SetVisible(false, true);
			}
		}

		public void OnDlgShow(IXUIDlg dlg)
		{
			bool exclusive = dlg.exclusive;
			if (exclusive)
			{
				this.CloseAllUI();
				this.CacheExclusiveUI();
				for (int i = 0; i < this.m_CachedExculsiveUI.Count; i++)
				{
					this.m_CachedExculsiveUI[i].uiBehaviourInterface.uiDlgInterface.SetVisiblePure(false);
				}
				this.ChangeTutorialClashUI(true);
			}
			else
			{
				bool flag = !this.m_ShowedDlg.Contains(dlg);
				if (flag)
				{
					this.m_ShowedDlg.Add(dlg);
					bool isHideTutorial = dlg.isHideTutorial;
					if (isHideTutorial)
					{
						this.ChangeTutorialClashUI(true);
					}
				}
				bool flag2 = !dlg.needOnTop;
				if (flag2)
				{
					this.m_AvatarStack.Remove(dlg);
					this.m_AvatarStack.Add(dlg);
				}
				else
				{
					Vector3 localPosition = dlg.uiBehaviourInterface.gameObject.transform.localPosition;
					localPosition.z = 0f;
					dlg.uiBehaviourInterface.gameObject.transform.localPosition = localPosition;
				}
				float num = 0f;
				for (int j = this.m_AvatarStack.Count - 1; j >= 0; j--)
				{
					IXUIDlg ixuidlg = this.m_AvatarStack[j];
					Vector3 localPosition2 = ixuidlg.uiBehaviourInterface.gameObject.transform.localPosition;
					localPosition2.z = num;
					ixuidlg.uiBehaviourInterface.gameObject.transform.localPosition = localPosition2;
					num += 800f;
				}
			}
			bool pushstack = dlg.pushstack;
			if (pushstack)
			{
				IXUIDlg ixuidlg2 = this.m_LFU.Add(dlg);
				bool flag3 = ixuidlg2 != null;
				if (flag3)
				{
					this.m_ToBeUnloadDlg.Add(ixuidlg2);
					XSingleton<XDebug>.singleton.AddGreenLog("Auto Unload UI: ", ixuidlg2.fileName, " while opening ", dlg.fileName, null, null);
				}
				XSingleton<XVirtualTab>.singleton.Cancel();
			}
			bool hideMainMenu = dlg.hideMainMenu;
			if (hideMainMenu)
			{
				this.UIBlurEffect(true);
			}
			bool pushstack2 = dlg.pushstack;
			if (pushstack2)
			{
				XMainInterfaceDocument specificDocument = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
				bool flag4 = this.m_ShowUIStack.Count > 0;
				if (flag4)
				{
					IXUIDlg ixuidlg3 = this.m_ShowUIStack.Peek();
					ixuidlg3.LeaveStackTop();
					ixuidlg3.uiBehaviourInterface.uiDlgInterface.SetVisiblePure(false);
					Stack<IXUIDlg> stack = new Stack<IXUIDlg>();
					IXUIDlg ixuidlg4 = this.m_ShowUIStack.Pop();
					while (ixuidlg4 != dlg && this.m_ShowUIStack.Count > 0)
					{
						stack.Push(ixuidlg4);
						ixuidlg4 = this.m_ShowUIStack.Pop();
					}
					bool flag5 = ixuidlg4 != dlg;
					if (flag5)
					{
						this.m_ShowUIStack.Push(ixuidlg4);
					}
					while (stack.Count > 0)
					{
						this.m_ShowUIStack.Push(stack.Pop());
					}
				}
				this.m_ShowUIStack.Push(dlg);
				specificDocument.OnTopUIRefreshed(dlg);
			}
			DlgBase<XChatView, XChatBehaviour>.singleton.TryCloseChat(dlg);
		}

		public void UIBlurEffect(bool bOn)
		{
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.FakeShowSelf(!bOn);
			}
		}

		public void OnDlgHide(IXUIDlg dlg)
		{
			bool exclusive = dlg.exclusive;
			if (exclusive)
			{
				for (int i = 0; i < this.m_CachedExculsiveUI.Count; i++)
				{
					this.m_CachedExculsiveUI[i].uiBehaviourInterface.uiDlgInterface.SetVisiblePure(true);
				}
				this.ChangeTutorialClashUI(false);
			}
			else
			{
				this.m_ShowedDlg.Remove(dlg);
				bool isHideTutorial = dlg.isHideTutorial;
				if (isHideTutorial)
				{
					this.ChangeTutorialClashUI(false);
				}
				this.m_AvatarStack.Remove(dlg);
			}
			bool pushstack = dlg.pushstack;
			if (pushstack)
			{
				this.m_LFU.MarkCanPop(dlg, true);
			}
			bool hideMainMenu = dlg.hideMainMenu;
			if (hideMainMenu)
			{
				this.UIBlurEffect(false);
			}
			bool flag = dlg.pushstack && this.m_ShowUIStack.Count > 0;
			if (flag)
			{
				IXUIDlg ixuidlg = this.m_ShowUIStack.Peek();
				bool flag2 = ixuidlg != dlg;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddLog("Not hide top of ui stack!:", dlg.fileName, null, null, null, null, XDebugColor.XDebug_None);
					Stack<IXUIDlg> stack = new Stack<IXUIDlg>();
					for (IXUIDlg ixuidlg2 = this.m_ShowUIStack.Pop(); ixuidlg2 != dlg; ixuidlg2 = this.m_ShowUIStack.Pop())
					{
						stack.Push(ixuidlg2);
						bool flag3 = this.m_ShowUIStack.Count == 0;
						if (flag3)
						{
							StringBuilder sharedStringBuilder = XSingleton<XCommon>.singleton.GetSharedStringBuilder();
							sharedStringBuilder.Length = 0;
							sharedStringBuilder.Append("Hide UI not in stack!!!! : ").Append(dlg.fileName);
							sharedStringBuilder.Append("; UIs in stack: ");
							foreach (IXUIDlg ixuidlg3 in stack)
							{
								sharedStringBuilder.Append(ixuidlg3.fileName).Append(" ");
							}
							XSingleton<XDebug>.singleton.AddErrorLog(sharedStringBuilder.ToString(), null, null, null, null, null);
							break;
						}
					}
					while (stack.Count > 0)
					{
						this.m_ShowUIStack.Push(stack.Pop());
					}
					bool flag4 = this.m_ShowUIStack.Count > 0;
					if (flag4)
					{
						IXUIDlg ixuidlg4 = this.m_ShowUIStack.Peek();
						bool hideMainMenu2 = ixuidlg4.hideMainMenu;
						if (hideMainMenu2)
						{
							this.UIBlurEffect(true);
						}
					}
				}
				else
				{
					this.m_ShowUIStack.Pop();
					XMainInterfaceDocument specificDocument = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
					bool flag5 = this.m_ShowUIStack.Count > 0;
					if (flag5)
					{
						IXUIDlg ixuidlg5 = this.m_ShowUIStack.Peek();
						ixuidlg5.uiBehaviourInterface.uiDlgInterface.SetVisiblePure(true);
						ixuidlg5.StackRefresh();
						specificDocument.OnTopUIRefreshed(ixuidlg5);
						bool hideMainMenu3 = ixuidlg5.hideMainMenu;
						if (hideMainMenu3)
						{
							this.UIBlurEffect(true);
						}
					}
					else
					{
						specificDocument.OnTopUIRefreshed(null);
					}
				}
			}
		}

		public List<IXUIDlg> GetShowedUI()
		{
			return this.m_ShowedDlg;
		}

		public void ClearUIinStack()
		{
			while (this.m_ShowUIStack.Count > 0)
			{
				IXUIDlg ixuidlg = this.m_ShowUIStack.Peek();
				bool flag = ixuidlg != null;
				if (flag)
				{
					ixuidlg.SetVisiblePure(true);
					ixuidlg.SetVisible(false, true);
				}
			}
			this.UIBlurEffect(false);
		}

		public void HideAllUIWithOutCall()
		{
			for (int i = 0; i < this.m_ShowedDlg.Count; i++)
			{
				bool flag = this.m_ShowedDlg[i] == DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton || this.m_ShowedDlg[i] == DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton || this.m_ShowedDlg[i] == DlgBase<XSystemTipView, XSystemTipBehaviour>.singleton;
				if (!flag)
				{
					bool flag2 = this.m_ShowedDlg[i].IsVisible();
					if (flag2)
					{
						this.m_StoreUIList.Add(this.m_ShowedDlg[i]);
						this.m_ShowedDlg[i].SetVisiblePure(false);
					}
				}
			}
		}

		public void RestoreAllUIWithOutCall()
		{
			for (int i = 0; i < this.m_StoreUIList.Count; i++)
			{
				bool flag = this.m_StoreUIList[i] != null;
				if (flag)
				{
					this.m_StoreUIList[i].SetVisiblePure(true);
				}
			}
			this.m_StoreUIList.Clear();
		}

		private void ChangeTutorialClashUI(bool isAdd)
		{
			if (isAdd)
			{
				this.m_TutorialClashUICount++;
				XSingleton<XDebug>.singleton.AddGreenLog("TutorialClashUICount++:" + this.m_TutorialClashUICount, null, null, null, null, null);
			}
			else
			{
				this.m_TutorialClashUICount--;
				XSingleton<XDebug>.singleton.AddGreenLog("TutorialClashUICount--:" + this.m_TutorialClashUICount, null, null, null, null, null);
				bool flag = this.m_TutorialClashUICount < 0;
				if (flag)
				{
					this.m_TutorialClashUICount = 0;
					XSingleton<XDebug>.singleton.AddErrorLog("TutorialClashUICount Error", null, null, null, null, null);
				}
			}
		}

		private Dictionary<string, IXUIDlg> m_dicDlgs = new Dictionary<string, IXUIDlg>();

		private Dictionary<int, List<IXUIDlg>> m_dicUILayer = new Dictionary<int, List<IXUIDlg>>();

		private List<IXUIDlg> m_iterDlgs = new List<IXUIDlg>();

		private Transform m_uiRoot = null;

		private Dictionary<int, IXUIDlg> m_GroupDlg = new Dictionary<int, IXUIDlg>();

		private List<IXUIDlg> m_ShowedDlg = new List<IXUIDlg>();

		private int m_TutorialClashUICount = 0;

		private List<IXUIDlg> m_ToBeUnloadDlg = new List<IXUIDlg>();

		private XLFU<IXUIDlg> m_LFU = new XLFU<IXUIDlg>(5);

		private List<IXUIDlg> m_CachedExculsiveUI = new List<IXUIDlg>();

		private Stack<IXUIDlg> m_ShowUIStack = new Stack<IXUIDlg>();

		private List<IXUIDlg> m_StoreUIList = new List<IXUIDlg>();

		private List<IXUIDlg> m_AvatarStack = new List<IXUIDlg>();

		public int unloadUICount = 0;
	}
}

using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	public class XYuyinView : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Common/YuyinDlg";
			}
		}

		public void ResetPool()
		{
			bool flag = this.m_CommonPool != null;
			if (flag)
			{
				this.m_CommonPool.ReturnAll(false);
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_panel = (base.transform.GetComponent("XUIPanel") as IXUIPanel);
			this.m_tween = (base.transform.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_leftRoot = base.transform.transform.FindChild("leftRoot").gameObject;
			this.m_rightRoot = base.transform.transform.FindChild("rightRoot").gameObject;
			this.m_pool = base.transform.FindChild("pool").gameObject;
			this.m_goCommon = base.transform.FindChild("pool/1").gameObject;
			this.m_btnSetting = (base.transform.FindChild("pool/3").GetComponent("XUIButton") as IXUIButton);
			this.m_btnMusic = (base.transform.FindChild("pool/4/MUSIC").GetComponent("XUIButton") as IXUIButton);
			this.m_btnSpeak = (base.transform.FindChild("pool/4/SPEAK").GetComponent("XUIButton") as IXUIButton);
			this.m_objMusic = base.transform.FindChild("pool/4/MUSIC/close").gameObject;
			this.m_objSpeak = base.transform.FindChild("pool/4/SPEAK/close").gameObject;
			this.m_CommonPool.SetupPool(this.m_pool, this.m_goCommon, 2U, true);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btnSetting.RegisterClickEventHandler(new ButtonClickEventHandler(this.OpenInputView));
			this.m_btnMusic.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnMusicClick));
			this.m_btnSpeak.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSpeakClick));
		}

		public void Init(int depth)
		{
			this.m_panel.SetDepth(depth);
		}

		public override void OnUpdate()
		{
			bool flag = this.chatDoc != null;
			if (flag)
			{
				bool flag2 = false;
				XStage currentStage = XSingleton<XGame>.singleton.CurrentStage;
				bool flag3 = currentStage != null && currentStage.Stage == EXStage.Hall;
				if (flag3)
				{
					bool flag4 = this.chatDoc.CheckTeam() != this.cacheTeam;
					if (flag4)
					{
						flag2 = true;
					}
					bool flag5 = this.chatDoc.CheckGuild() != this.cacheGuild;
					if (flag5)
					{
						flag2 = true;
					}
				}
				bool flag6 = flag2;
				if (flag6)
				{
					this.Refresh(this.mType);
				}
			}
		}

		public void Show(bool active)
		{
			this.m_panel.gameObject.SetActive(active);
		}

		public void Show(YuyinIconType type, int depth = 1)
		{
			this.Show((int)type, depth);
		}

		public void Show(int type, int depth = 1)
		{
			this.mType = type;
			this.Init(depth);
			this.Refresh(type);
		}

		public void Refresh(YuyinIconType type)
		{
			this.Refresh((int)type);
		}

		public void Refresh(int type)
		{
			bool flag = this.chatDoc == null;
			if (flag)
			{
				this.chatDoc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			}
			this.cacheGuild = this.chatDoc.CheckGuild();
			this.cacheTeam = this.chatDoc.CheckTeam();
			this.ResetPool();
			this.m_trans.Clear();
			this.openRow = this.chatDoc.GetYuyinRaw(type);
			this.m_pool.transform.parent = ((this.openRow.pivot == 0) ? this.m_rightRoot.transform : this.m_leftRoot.transform);
			this.m_pool.transform.localPosition = new Vector3((float)this.openRow.posX, (float)this.openRow.posY, 0f);
			this.m_pool.transform.localScale = this.openRow.scale * Vector3.one;
			this.m_panel.SetAlpha(this.openRow.alpha);
			bool flag2 = this.openRow.real <= 0;
			if (flag2)
			{
				List<int> list = this.chatDoc.SortCommonIcons(type);
				int num = Mathf.Min(this.openRow.max, list.Count);
				for (int i = 0; i < num; i++)
				{
					GameObject gameObject = this.m_CommonPool.FetchGameObject(false);
					this.m_trans.Add(gameObject.transform);
					string sprName = this.chatDoc.GetRawData((ChatChannelType)list[i]).sprName;
					IXUISprite ixuisprite = gameObject.transform.Find("Name").GetComponent("XUISprite") as IXUISprite;
					bool flag3 = ixuisprite != null;
					if (flag3)
					{
						ixuisprite.SetSprite(sprName);
					}
					IXUIButton ixuibutton = gameObject.transform.GetComponent("XUIButton") as IXUIButton;
					ixuibutton.ID = (ulong)((long)list[i]);
					ixuibutton.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnItemPress));
					ixuibutton.RegisterDragEventHandler(new ButtonDragEventHandler(this.OnVoiceButtonDrag));
				}
			}
			bool flag4 = this.openRow.fade == 1;
			if (flag4)
			{
				this.m_trans.Add(this.m_btnSetting.gameObject.transform);
			}
			else
			{
				this.m_btnSetting.gameObject.transform.localPosition = this.farway;
			}
			bool flag5 = this.openRow.real > 0;
			if (flag5)
			{
				this.m_trans.Add(this.m_btnMusic.gameObject.transform);
				this.m_trans.Add(this.m_btnSpeak.gameObject.transform);
				bool flag6 = !XYuyinView.hideRealEff;
				if (flag6)
				{
					XYuyinView.hideRealEff = true;
				}
				else
				{
					this.HideVoiceEff(null);
				}
			}
			else
			{
				this.m_btnSpeak.gameObject.transform.localPosition = this.farway;
				this.m_btnMusic.gameObject.transform.localPosition = this.farway;
			}
			this.GridItems(type);
		}

		private void GridItems(int type)
		{
			bool flag = this.openRow == null;
			if (!flag)
			{
				bool flag2 = this.openRow.pivot == 0;
				int num = (this.openRow.real > 0) ? 70 : 55;
				for (int i = 0; i < this.m_trans.Count; i++)
				{
					this.m_trans[i].localPosition = (flag2 ? new Vector3((float)(-(float)num * i), 0f, 0f) : new Vector3((float)(num * i), 0f, 0f));
				}
			}
		}

		public void OnItemPress(IXUIButton btn, bool isPressed)
		{
			GameObject gameObject = btn.gameObject.transform.Find("Effect").gameObject;
			gameObject.SetActive(isPressed);
			ulong id = btn.ID;
			List<GameObject> list = ListPool<GameObject>.Get();
			this.m_CommonPool.GetActiveList(list);
			ListPool<GameObject>.Release(list);
			DlgBase<XChatView, XChatBehaviour>.singleton.SetActiveChannel((ChatChannelType)btn.ID);
			if (isPressed)
			{
				this.m_CancelRecord = false;
				this.m_DragDistance = Vector2.zero;
				bool useApollo = XChatDocument.UseApollo;
				if (useApollo)
				{
					XSingleton<XChatApolloMgr>.singleton.StartRecord(VoiceUsage.CHAT, new EndRecordCallBack(this.ChatOver));
				}
				else
				{
					XSingleton<XChatIFlyMgr>.singleton.StartRecord(VoiceUsage.CHAT, new EndRecordCallBack(this.ChatOver));
				}
			}
			else
			{
				bool useApollo2 = XChatDocument.UseApollo;
				if (useApollo2)
				{
					XSingleton<XChatApolloMgr>.singleton.StopRecord(this.m_CancelRecord);
				}
				else
				{
					XSingleton<XChatIFlyMgr>.singleton.StopRecord(this.m_CancelRecord);
				}
				this.m_CancelRecord = false;
			}
		}

		public void OnVoiceButtonDrag(IXUIButton sp, Vector2 delta)
		{
			this.m_DragDistance += delta;
			this.m_CancelRecord = (this.m_DragDistance.magnitude >= 100f);
		}

		private void ChatOver()
		{
		}

		private bool OpenInputView(IXUIButton btn)
		{
			DlgBase<XChatInputView, XChatInputBehaviour>.singleton.ShowChatInput(new ChatInputStringBack(this.SendInputMsg));
			DlgBase<XChatInputView, XChatInputBehaviour>.singleton.SetInputType(ChatInputType.EMOTION);
			return true;
		}

		public void SendInputMsg(string str)
		{
			bool flag = !XSingleton<UiUtility>.singleton.IsSystemExpress(str);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("input: ", str, null, null, null, null, XDebugColor.XDebug_None);
				DlgBase<XChatView, XChatBehaviour>.singleton.SendChatContent(str, ChatChannelType.Spectate, true, null, false, 0UL, 0f, false, false);
			}
		}

		private void HideVoiceEff(object o = null)
		{
			this.ShowVoiceEff(this.m_btnMusic, false);
			this.ShowVoiceEff(this.m_btnSpeak, false);
		}

		public void ShowVoiceEff(IXUIButton btn, bool show)
		{
			bool flag = btn != null && btn.gameObject != null;
			if (flag)
			{
				Transform transform = btn.gameObject.transform.Find("Effect");
				bool flag2 = transform != null;
				if (flag2)
				{
					transform.gameObject.SetActive(show);
				}
			}
		}

		public bool OnMusicClick(IXUIButton btn)
		{
			this.ShowVoiceEff(btn, false);
			this.OnRealVoiceClick(0);
			return true;
		}

		public void SetMusic(bool on)
		{
			XApolloDocument specificDocument = XDocuments.GetSpecificDocument<XApolloDocument>(XApolloDocument.uuID);
			bool joinRoomSucc = specificDocument.JoinRoomSucc;
			if (joinRoomSucc)
			{
				IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
				bool flag = xapolloManager.openMusic != on;
				if (flag)
				{
					xapolloManager.openMusic = on;
					this.m_objMusic.SetActive(!on);
					specificDocument.PlayGameSound(!on);
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("VOICE_APOLLO_FAIL"), "fece00");
			}
		}

		public bool OnSpeakClick(IXUIButton btn)
		{
			this.ShowVoiceEff(btn, false);
			this.OnRealVoiceClick(1);
			return true;
		}

		public void SetSpeak(bool on)
		{
			XApolloDocument specificDocument = XDocuments.GetSpecificDocument<XApolloDocument>(XApolloDocument.uuID);
			bool joinRoomSucc = specificDocument.JoinRoomSucc;
			if (joinRoomSucc)
			{
				IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
				bool flag = xapolloManager.openSpeak != on;
				if (flag)
				{
					xapolloManager.openSpeak = on;
					this.m_objSpeak.SetActive(!on);
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("VOICE_APOLLO_FAIL"), "fece00");
			}
		}

		private void OnRealVoiceClick(int click)
		{
			IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
			int speak = xapolloManager.openSpeak ? 1 : 0;
			int music = xapolloManager.openMusic ? 1 : 0;
			XApolloDocument specificDocument = XDocuments.GetSpecificDocument<XApolloDocument>(XApolloDocument.uuID);
			XChatDocument specificDocument2 = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			ChatApollo.RowData apollo = specificDocument2.GetApollo(speak, music, click);
			bool flag = apollo != null;
			if (flag)
			{
				bool isWaittingJoinRoom = specificDocument.IsWaittingJoinRoom;
				if (isWaittingJoinRoom)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_APOLLO_WAIT"), "fece00");
				}
				else
				{
					bool joinRoomSucc = specificDocument.JoinRoomSucc;
					if (joinRoomSucc)
					{
						bool flag2 = !string.IsNullOrEmpty(apollo.note);
						if (flag2)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString(apollo.note), "fece00");
						}
						bool flag3 = apollo.opens == 1;
						bool flag4 = xapolloManager.openSpeak != flag3;
						if (flag4)
						{
							xapolloManager.openSpeak = flag3;
						}
						bool flag5 = this.m_objSpeak.activeSelf == flag3;
						if (flag5)
						{
							this.m_objSpeak.SetActive(!flag3);
						}
						bool flag6 = apollo.openm == 1;
						bool flag7 = xapolloManager.openMusic != flag6;
						if (flag7)
						{
							xapolloManager.openMusic = flag6;
						}
						bool flag8 = this.m_objMusic.activeSelf == flag6;
						if (flag8)
						{
							this.m_objMusic.SetActive(!flag6);
						}
						specificDocument.PlayGameSound(!flag6);
					}
					else
					{
						bool flag9 = !string.IsNullOrEmpty(apollo.note2);
						if (flag9)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString(apollo.note2), "fece00");
						}
					}
				}
				uint state = 0U;
				bool joinRoomSucc2 = specificDocument.JoinRoomSucc;
				if (joinRoomSucc2)
				{
					bool flag10 = xapolloManager.openMusic && xapolloManager.openSpeak;
					if (flag10)
					{
						state = 2U;
					}
					else
					{
						bool flag11 = xapolloManager.openSpeak || xapolloManager.openMusic;
						if (flag11)
						{
							state = 1U;
						}
					}
				}
				specificDocument.SendStateServer(state);
			}
		}

		public GameObject m_pool;

		public GameObject m_goCommon;

		public GameObject m_goFriend;

		public IXUIButton m_btnSetting;

		public IXUIButton m_btnMusic;

		public IXUIButton m_btnSpeak;

		public GameObject m_objMusic;

		public GameObject m_objSpeak;

		public IXUIPanel m_panel;

		public GameObject m_leftRoot;

		public GameObject m_rightRoot;

		public IXUITweenTool m_tween;

		public XUIPool m_CommonPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private bool m_CancelRecord = false;

		private Vector2 m_DragDistance = Vector2.zero;

		private int mType = 1;

		private static bool hideRealEff = false;

		public Vector3 farway = new Vector3(2000f, 2000f, 0f);

		private bool cacheGuild = false;

		private bool cacheTeam = false;

		private List<Transform> m_trans = new List<Transform>();

		private XChatDocument chatDoc;

		private ChatOpen.RowData openRow;
	}
}

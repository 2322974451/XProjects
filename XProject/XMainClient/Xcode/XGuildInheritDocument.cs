using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildInheritDocument : XDocComponent
	{

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<GuildInheritDlg, GuildInheritBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.SendInheritList();
			}
		}

		public override uint ID
		{
			get
			{
				return XGuildInheritDocument.uuID;
			}
		}

		public uint TeacherCount
		{
			get
			{
				return this.m_teacherCount;
			}
		}

		public uint StudentCount
		{
			get
			{
				return this.m_studentCount;
			}
		}

		public string GetTeacherLeftTimeString()
		{
			bool flag = this.m_teacherTime > 0f;
			string result;
			if (flag)
			{
				result = XStringDefineProxy.GetString("GUILD_INHERIT_TEACHER_TIME", new object[]
				{
					XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)this.m_teacherTime, 5)
				});
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		public bool TryGetInheritCountString(out string message)
		{
			message = string.Empty;
			bool flag = (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)XSingleton<XGlobalConfig>.singleton.StudentMinLevel);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)XSingleton<XGlobalConfig>.singleton.TeacherMinLevel);
				if (flag2)
				{
					message = XStringDefineProxy.GetString("GUILD_INHERIT_MESSAGE2", new object[]
					{
						XSingleton<XGlobalConfig>.singleton.TeacherMinLevel,
						this.m_studentCount
					});
				}
				else
				{
					message = XStringDefineProxy.GetString("GUILD_INHERIT_MESSAGE1", new object[]
					{
						this.m_teacherCount,
						this.m_studentCount,
						XGuildInheritDocument.InheritLimitRange
					});
				}
				result = true;
			}
			return result;
		}

		public static void TryOutInherit(XEntity entity)
		{
			bool isPlayer = entity.IsPlayer;
			if (isPlayer)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("Player Out Inherit", null, null, null, null, null);
				XSingleton<XInput>.singleton.Freezed = false;
				bool flag = entity.Nav != null;
				if (flag)
				{
					entity.Nav.Interrupt();
					entity.Nav.Enabled = true;
				}
				XGuildInheritDocument specificDocument = XDocuments.GetSpecificDocument<XGuildInheritDocument>(XGuildInheritDocument.uuID);
				specificDocument.StopInherit();
			}
			XInheritComponent xinheritComponent = entity.GetXComponent(XInheritComponent.uuID) as XInheritComponent;
			bool flag2 = xinheritComponent != null;
			if (flag2)
			{
				entity.DetachComponent(XInheritComponent.uuID);
			}
			XBubbleComponent xbubbleComponent = entity.GetXComponent(XBubbleComponent.uuID) as XBubbleComponent;
			bool flag3 = xbubbleComponent != null;
			if (flag3)
			{
				entity.DetachComponent(XBubbleComponent.uuID);
			}
		}

		public void StopInherit()
		{
			this.m_Inheriting = false;
			bool flag = this.m_selectEffect != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_selectEffect, true);
				this.m_selectEffect = null;
			}
			bool flag2 = DlgBase<GuildInheritProcessDlg, GuildInheritProcessBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<GuildInheritProcessDlg, GuildInheritProcessBehaviour>.singleton.HideProcess();
			}
		}

		private static int InheritLimitRange
		{
			get
			{
				XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
				uint sealType = specificDocument.SealType;
				SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("GuildInheritRoleLvlGap", true);
				int i = 0;
				int count = (int)sequenceList.Count;
				while (i < count)
				{
					bool flag = (long)sequenceList[i, 0] == (long)((ulong)sealType);
					if (flag)
					{
						return sequenceList[i, 1];
					}
					i++;
				}
				return sequenceList[(int)(sequenceList.Count - 1), 1];
			}
		}

		public static void TryInInherit(XEntity entity)
		{
			bool isPlayer = entity.IsPlayer;
			if (isPlayer)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("Player in Inherit", null, null, null, null, null);
				XSingleton<XInput>.singleton.Freezed = false;
				XSingleton<XInput>.singleton.Freezed = true;
				bool flag = entity.Nav != null;
				if (flag)
				{
					entity.Nav.Interrupt();
					entity.Nav.Enabled = false;
				}
			}
			XInheritComponent xinheritComponent = entity.GetXComponent(XInheritComponent.uuID) as XInheritComponent;
			bool flag2 = xinheritComponent == null;
			if (flag2)
			{
				XSingleton<XComponentMgr>.singleton.CreateComponent(entity, XInheritComponent.uuID);
			}
		}

		public static bool IsInherit(uint level)
		{
			return XGuildInheritDocument.IsInheritInitiator(level) || XGuildInheritDocument.IsInheritReceiver(level);
		}

		public static bool IsInheritReceiver(uint level)
		{
			bool flag = (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)XSingleton<XGlobalConfig>.singleton.StudentMinLevel) || (ulong)level < (ulong)((long)XSingleton<XGlobalConfig>.singleton.TeacherMinLevel);
			return !flag && level - XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= (uint)XGuildInheritDocument.InheritLimitRange;
		}

		public static bool IsInheritInitiator(uint level)
		{
			bool flag = (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)XSingleton<XGlobalConfig>.singleton.TeacherMinLevel) || (ulong)level < (ulong)((long)XSingleton<XGlobalConfig>.singleton.StudentMinLevel);
			return !flag && XSingleton<XAttributeMgr>.singleton.XPlayerData.Level - level >= (uint)XGuildInheritDocument.InheritLimitRange;
		}

		public List<GuildInheritInfo> InheritList
		{
			get
			{
				return this.m_inheritList;
			}
		}

		public uint bHasAvailableIconShow
		{
			get
			{
				return this.m_avilableReqCount;
			}
			set
			{
				this.m_avilableReqCount = value;
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildInherit, true);
			}
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			bool flag = this.m_teacherTime > 0f;
			if (flag)
			{
				this.m_teacherTime -= fDeltaT;
			}
			else
			{
				this.m_teacherTime = 0f;
			}
			bool inheriting = this.m_Inheriting;
			if (inheriting)
			{
				bool flag2 = this.m_bubbleTime > 0f;
				if (flag2)
				{
					this.m_bubbleTime -= fDeltaT;
				}
				else
				{
					this.m_bubbleTime = 11f;
					this.ShowBubble();
				}
			}
		}

		public void SynInheritExp(synGuildInheritExp res)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("SynInheritExp:", res.teacherId.ToString(), null, null, null, null);
			bool flag = res.turn == 0U;
			if (flag)
			{
				bool flag2 = XSingleton<XSceneMgr>.singleton.GetSceneType(XSingleton<XScene>.singleton.SceneID) == SceneType.SCENE_HALL;
				if (flag2)
				{
					XSingleton<UIManager>.singleton.CloseAllUI();
				}
				this.InheritTeacherID = res.teacherId;
				XSingleton<XDebug>.singleton.AddGreenLog("Start Inherit", null, null, null, null, null);
				this.m_Inheriting = true;
				this.m_bubbleTime = 11f;
				float countdownTime = (float)(XSingleton<XGlobalConfig>.singleton.GetInt("GuildInheritTime") * XSingleton<XGlobalConfig>.singleton.GetInt("GuildInheritTimes"));
				string @string = XStringDefineProxy.GetString("GUILD_INHERIT_PROCESSMESS");
				string string2 = XStringDefineProxy.GetString("GUILD_INHERIT_HELP");
				DlgBase<GuildInheritProcessDlg, GuildInheritProcessBehaviour>.singleton.ShowProcess(countdownTime, @string, string2, null);
				bool flag3 = XSingleton<XSceneMgr>.singleton.GetSceneType(XSingleton<XScene>.singleton.SceneID) == SceneType.SCENE_GUILD_HALL && XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
				if (flag3)
				{
					bool flag4 = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID == res.teacherId;
					if (flag4)
					{
						this.m_teacherCount -= 1U;
					}
					else
					{
						this.m_studentCount -= 1U;
					}
				}
			}
			else
			{
				bool islast = res.islast;
				if (islast)
				{
					this.m_Inheriting = false;
					this.InheritTeacherID = 0UL;
					DlgBase<GuildInheritProcessDlg, GuildInheritProcessBehaviour>.singleton.HideProcess();
					XSingleton<XDebug>.singleton.AddGreenLog("Stop Inherit", null, null, null, null, null);
					ulong num = 0UL;
					bool flag5 = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID != res.roleOne;
					if (flag5)
					{
						num = res.roleOne;
					}
					else
					{
						bool flag6 = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID != res.roleTwo;
						if (flag6)
						{
							num = res.roleTwo;
						}
					}
					bool flag7 = (ulong)res.turn == (ulong)((long)XSingleton<XGlobalConfig>.singleton.GetInt("GuildInheritTimes"));
					if (flag7)
					{
						bool flag8 = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID != this.InheritTeacherID;
						if (flag8)
						{
							DlgBase<XChatView, XChatBehaviour>.singleton.AddChat(XStringDefineProxy.GetString("GUILD_INHERIT_CHAT2"), ChatChannelType.Guild, null, false);
						}
						bool flag9 = num != 0UL && !DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsMyFriend(num);
						if (flag9)
						{
							this.m_SelectFriend = num;
							XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("GUILD_INHERIT_ADDFRIEND"), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this.OnAddFriend));
						}
					}
				}
			}
			bool flag10 = res.islast || this.m_selectEffect != null;
			if (!flag10)
			{
				XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(res.roleOne);
				XEntity entity2 = XSingleton<XEntityMgr>.singleton.GetEntity(res.roleTwo);
				bool flag11 = entity == null || entity2 == null;
				if (!flag11)
				{
					Vector3 position = entity.EngineObject.Position;
					Vector3 position2 = entity2.EngineObject.Position;
					Vector3 position3 = (position + position2) / 2f;
					this.m_selectEffect = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_cg_lx", null, true);
					Quaternion rotation = Quaternion.FromToRotation(position - position2, Vector3.zero);
					this.m_selectEffect.Play(position3, rotation, Vector3.one, 1f);
				}
			}
		}

		private void ShowBubble()
		{
			bool flag = this.InheritTeacherID == 0UL;
			if (!flag)
			{
				XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(this.InheritTeacherID);
				bool flag2 = entity == null;
				if (!flag2)
				{
					XBubbleEventArgs @event = XEventPool<XBubbleEventArgs>.GetEvent();
					@event.bubbletext = XStringDefineProxy.GetString("GUILD_INHERIT_CHAT1");
					@event.existtime = 3f;
					@event.Firer = entity;
					@event.speaker = entity.Name;
					XBubbleComponent xbubbleComponent = entity.GetXComponent(XBubbleComponent.uuID) as XBubbleComponent;
					bool flag3 = xbubbleComponent == null;
					if (flag3)
					{
						XSingleton<XComponentMgr>.singleton.CreateComponent(entity, XBubbleComponent.uuID);
					}
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
			}
		}

		private bool OnAddFriend(IXUIButton btn)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(this.m_SelectFriend);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		public void SynInheritBaseInfo(SynGuildInheritNumInfo res)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("XGuildInheritDocument.SynInheritBaseInfo teacherNumber:", res.teacherNum.ToString(), " teacher:", res.lastTime.ToString(), null, null);
			this.bHasAvailableIconShow = res.reqNum;
			this.m_studentCount = res.studentNum;
			this.m_teacherCount = res.teacherNum;
			bool flag = this.m_teacherCount > 0U;
			if (flag)
			{
				this.m_teacherTime = res.lastTime;
			}
			else
			{
				this.m_teacherTime = 0f;
			}
		}

		public void SendInheritList()
		{
			RpcC2M_ReqGuildInheritInfo rpc = new RpcC2M_ReqGuildInheritInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReceiveInheritList(ReqGuildInheritInfoArg oArg, ReqGuildInheritInfoRes oRes)
		{
			this.m_inheritList.Clear();
			int num = oRes.data.Count - this.m_inheritList.Count;
			bool flag = num < 0;
			if (flag)
			{
				this.m_inheritList.RemoveRange(this.m_inheritList.Count + num, -num);
			}
			else
			{
				for (int i = 0; i < num; i++)
				{
					GuildInheritInfo item = new GuildInheritInfo();
					this.m_inheritList.Add(item);
				}
			}
			int j = 0;
			int count = this.m_inheritList.Count;
			while (j < count)
			{
				this.m_inheritList[j].Set(oRes.data[j]);
				j++;
			}
			this.bHasAvailableIconShow = (uint)this.m_inheritList.Count;
			bool flag2 = DlgBase<GuildInheritDlg, GuildInheritBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<GuildInheritDlg, GuildInheritBehaviour>.singleton.RefreshData();
			}
		}

		public void SendDelInherit()
		{
			RpcC2M_DelGuildInherit rpc = new RpcC2M_DelGuildInherit();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReceiveDelInherit(DelGuildInheritRes res)
		{
			bool flag = res.errorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(res.errorCode, "fece00");
			}
			else
			{
				this.m_inheritList.Clear();
				this.bHasAvailableIconShow = (uint)this.m_inheritList.Count;
			}
		}

		public void SendReqInherit(ulong uid)
		{
			RpcC2M_AddGuildInherit rpcC2M_AddGuildInherit = new RpcC2M_AddGuildInherit();
			rpcC2M_AddGuildInherit.oArg.reqRoleId = uid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_AddGuildInherit);
		}

		public void ReceiveReqInherit(AddGuildInheritArg arg, AddGuildInheritRes res)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("XGuildInheritDocument.ReceiveReqInherit", null, null, null, null, null);
			bool flag = res.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(res.errorcode, "fece00");
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_INHERIT_REQSUCCESS"), "fece00");
			}
		}

		public void SendAccpetInherit(int index)
		{
			bool flag = this.m_inheritList == null || index < 0 || index >= this.m_inheritList.Count;
			if (!flag)
			{
				GuildInheritInfo guildInheritInfo = this.m_inheritList[index];
				bool flag2 = !XGuildInheritDocument.IsInherit(guildInheritInfo.level);
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_GUILD_INHERIT_LVL"), "fece00");
				}
				else
				{
					bool flag3 = XSingleton<XAttributeMgr>.singleton.XPlayerData.Outlook.state.type == OutLookStateType.OutLook_Inherit;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_INHERIT_ING"), "fece00");
					}
					else
					{
						RpcC2M_AceptGuildInherit rpcC2M_AceptGuildInherit = new RpcC2M_AceptGuildInherit();
						rpcC2M_AceptGuildInherit.oArg.roleId = guildInheritInfo.uid;
						XSingleton<XClientNetwork>.singleton.Send(rpcC2M_AceptGuildInherit);
					}
				}
			}
		}

		public void ReceiveAccpetInherit(AceptGuildInheritArg arg, AceptGuildInheritRes res)
		{
			bool flag = false;
			int i = 0;
			int count = this.m_inheritList.Count;
			while (i < count)
			{
				bool flag2 = this.m_inheritList[i].uid == arg.roleId;
				if (flag2)
				{
					this.m_inheritList.RemoveAt(i);
					flag = true;
					break;
				}
				i++;
			}
			bool flag3 = flag;
			if (flag3)
			{
				this.bHasAvailableIconShow = (uint)this.m_inheritList.Count;
			}
			bool flag4 = res.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag4)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(res.errorcode, "fece00");
				bool flag5 = DlgBase<GuildInheritDlg, GuildInheritBehaviour>.singleton.IsVisible();
				if (flag5)
				{
					DlgBase<GuildInheritDlg, GuildInheritBehaviour>.singleton.RefreshData();
				}
			}
			else
			{
				bool flag6 = DlgBase<GuildInheritDlg, GuildInheritBehaviour>.singleton.IsVisible();
				if (flag6)
				{
					DlgBase<GuildInheritDlg, GuildInheritBehaviour>.singleton.SetVisibleWithAnimation(false, null);
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildInheritDocument");

		private uint m_avilableReqCount = 0U;

		private uint m_teacherCount = 0U;

		private uint m_studentCount = 0U;

		private List<GuildInheritInfo> m_inheritList = new List<GuildInheritInfo>();

		private ulong m_SelectFriend = 0UL;

		private float m_teacherTime = 0f;

		private XFx m_selectEffect = null;

		private bool m_Inheriting = false;

		private float m_bubbleTime = 11f;

		private ulong InheritTeacherID = 0UL;
	}
}

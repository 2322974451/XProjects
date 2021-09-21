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
	// Token: 0x02000925 RID: 2341
	internal class XGuildInheritDocument : XDocComponent
	{
		// Token: 0x06008D62 RID: 36194 RVA: 0x0013563C File Offset: 0x0013383C
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<GuildInheritDlg, GuildInheritBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.SendInheritList();
			}
		}

		// Token: 0x17002BB3 RID: 11187
		// (get) Token: 0x06008D63 RID: 36195 RVA: 0x00135660 File Offset: 0x00133860
		public override uint ID
		{
			get
			{
				return XGuildInheritDocument.uuID;
			}
		}

		// Token: 0x17002BB4 RID: 11188
		// (get) Token: 0x06008D64 RID: 36196 RVA: 0x00135678 File Offset: 0x00133878
		public uint TeacherCount
		{
			get
			{
				return this.m_teacherCount;
			}
		}

		// Token: 0x17002BB5 RID: 11189
		// (get) Token: 0x06008D65 RID: 36197 RVA: 0x00135690 File Offset: 0x00133890
		public uint StudentCount
		{
			get
			{
				return this.m_studentCount;
			}
		}

		// Token: 0x06008D66 RID: 36198 RVA: 0x001356A8 File Offset: 0x001338A8
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

		// Token: 0x06008D67 RID: 36199 RVA: 0x001356F8 File Offset: 0x001338F8
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

		// Token: 0x06008D68 RID: 36200 RVA: 0x001357CC File Offset: 0x001339CC
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

		// Token: 0x06008D69 RID: 36201 RVA: 0x00135894 File Offset: 0x00133A94
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

		// Token: 0x17002BB6 RID: 11190
		// (get) Token: 0x06008D6A RID: 36202 RVA: 0x001358EC File Offset: 0x00133AEC
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

		// Token: 0x06008D6B RID: 36203 RVA: 0x00135970 File Offset: 0x00133B70
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

		// Token: 0x06008D6C RID: 36204 RVA: 0x00135A0C File Offset: 0x00133C0C
		public static bool IsInherit(uint level)
		{
			return XGuildInheritDocument.IsInheritInitiator(level) || XGuildInheritDocument.IsInheritReceiver(level);
		}

		// Token: 0x06008D6D RID: 36205 RVA: 0x00135A30 File Offset: 0x00133C30
		public static bool IsInheritReceiver(uint level)
		{
			bool flag = (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)XSingleton<XGlobalConfig>.singleton.StudentMinLevel) || (ulong)level < (ulong)((long)XSingleton<XGlobalConfig>.singleton.TeacherMinLevel);
			return !flag && level - XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= (uint)XGuildInheritDocument.InheritLimitRange;
		}

		// Token: 0x06008D6E RID: 36206 RVA: 0x00135A94 File Offset: 0x00133C94
		public static bool IsInheritInitiator(uint level)
		{
			bool flag = (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)XSingleton<XGlobalConfig>.singleton.TeacherMinLevel) || (ulong)level < (ulong)((long)XSingleton<XGlobalConfig>.singleton.StudentMinLevel);
			return !flag && XSingleton<XAttributeMgr>.singleton.XPlayerData.Level - level >= (uint)XGuildInheritDocument.InheritLimitRange;
		}

		// Token: 0x17002BB7 RID: 11191
		// (get) Token: 0x06008D6F RID: 36207 RVA: 0x00135AF8 File Offset: 0x00133CF8
		public List<GuildInheritInfo> InheritList
		{
			get
			{
				return this.m_inheritList;
			}
		}

		// Token: 0x17002BB8 RID: 11192
		// (get) Token: 0x06008D70 RID: 36208 RVA: 0x00135B10 File Offset: 0x00133D10
		// (set) Token: 0x06008D71 RID: 36209 RVA: 0x00135B28 File Offset: 0x00133D28
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

		// Token: 0x06008D72 RID: 36210 RVA: 0x00135B44 File Offset: 0x00133D44
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

		// Token: 0x06008D73 RID: 36211 RVA: 0x00135BCC File Offset: 0x00133DCC
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

		// Token: 0x06008D74 RID: 36212 RVA: 0x00135F30 File Offset: 0x00134130
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

		// Token: 0x06008D75 RID: 36213 RVA: 0x00135FE0 File Offset: 0x001341E0
		private bool OnAddFriend(IXUIButton btn)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(this.m_SelectFriend);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x06008D76 RID: 36214 RVA: 0x00136010 File Offset: 0x00134210
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

		// Token: 0x06008D77 RID: 36215 RVA: 0x001360A0 File Offset: 0x001342A0
		public void SendInheritList()
		{
			RpcC2M_ReqGuildInheritInfo rpc = new RpcC2M_ReqGuildInheritInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008D78 RID: 36216 RVA: 0x001360C0 File Offset: 0x001342C0
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

		// Token: 0x06008D79 RID: 36217 RVA: 0x001361B8 File Offset: 0x001343B8
		public void SendDelInherit()
		{
			RpcC2M_DelGuildInherit rpc = new RpcC2M_DelGuildInherit();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008D7A RID: 36218 RVA: 0x001361D8 File Offset: 0x001343D8
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

		// Token: 0x06008D7B RID: 36219 RVA: 0x0013622C File Offset: 0x0013442C
		public void SendReqInherit(ulong uid)
		{
			RpcC2M_AddGuildInherit rpcC2M_AddGuildInherit = new RpcC2M_AddGuildInherit();
			rpcC2M_AddGuildInherit.oArg.reqRoleId = uid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_AddGuildInherit);
		}

		// Token: 0x06008D7C RID: 36220 RVA: 0x0013625C File Offset: 0x0013445C
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

		// Token: 0x06008D7D RID: 36221 RVA: 0x001362C0 File Offset: 0x001344C0
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

		// Token: 0x06008D7E RID: 36222 RVA: 0x00136398 File Offset: 0x00134598
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

		// Token: 0x04002DDB RID: 11739
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildInheritDocument");

		// Token: 0x04002DDC RID: 11740
		private uint m_avilableReqCount = 0U;

		// Token: 0x04002DDD RID: 11741
		private uint m_teacherCount = 0U;

		// Token: 0x04002DDE RID: 11742
		private uint m_studentCount = 0U;

		// Token: 0x04002DDF RID: 11743
		private List<GuildInheritInfo> m_inheritList = new List<GuildInheritInfo>();

		// Token: 0x04002DE0 RID: 11744
		private ulong m_SelectFriend = 0UL;

		// Token: 0x04002DE1 RID: 11745
		private float m_teacherTime = 0f;

		// Token: 0x04002DE2 RID: 11746
		private XFx m_selectEffect = null;

		// Token: 0x04002DE3 RID: 11747
		private bool m_Inheriting = false;

		// Token: 0x04002DE4 RID: 11748
		private float m_bubbleTime = 11f;

		// Token: 0x04002DE5 RID: 11749
		private ulong InheritTeacherID = 0UL;
	}
}

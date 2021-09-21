using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200092A RID: 2346
	internal class XDanceDocument : XDocComponent
	{
		// Token: 0x17002BBE RID: 11198
		// (get) Token: 0x06008DA5 RID: 36261 RVA: 0x00136F98 File Offset: 0x00135198
		public override uint ID
		{
			get
			{
				return XDanceDocument.uuID;
			}
		}

		// Token: 0x17002BBF RID: 11199
		// (get) Token: 0x06008DA6 RID: 36262 RVA: 0x00136FB0 File Offset: 0x001351B0
		private bool _playerDancing
		{
			get
			{
				return XSingleton<XAttributeMgr>.singleton.XPlayerData.Outlook.state.bDancing;
			}
		}

		// Token: 0x17002BC0 RID: 11200
		// (get) Token: 0x06008DA7 RID: 36263 RVA: 0x00136FDC File Offset: 0x001351DC
		public static Dictionary<uint, List<DanceConfig.RowData>> DanceConfigData
		{
			get
			{
				return XDanceDocument.m_DanceConfigData;
			}
		}

		// Token: 0x17002BC1 RID: 11201
		// (get) Token: 0x06008DA8 RID: 36264 RVA: 0x00136FF4 File Offset: 0x001351F4
		public List<DanceMotionData> SelfConfigData
		{
			get
			{
				return this.m_SelfConfigData;
			}
		}

		// Token: 0x17002BC2 RID: 11202
		// (get) Token: 0x06008DA9 RID: 36265 RVA: 0x0013700C File Offset: 0x0013520C
		public static XDanceDocument Doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XDanceDocument>(XDanceDocument.uuID);
			}
		}

		// Token: 0x06008DAA RID: 36266 RVA: 0x00137028 File Offset: 0x00135228
		public static void Execute(OnLoadedCallback callback = null)
		{
			XDanceDocument.AsyncLoader.AddTask("Table/DanceConfig", XDanceDocument._DanceConfigReader, false);
			XDanceDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008DAB RID: 36267 RVA: 0x00137050 File Offset: 0x00135250
		public static void OnTableLoaded()
		{
			XDanceDocument.m_DanceConfigData.Clear();
			for (int i = 0; i < XDanceDocument._DanceConfigReader.Table.Length; i++)
			{
				DanceConfig.RowData rowData = XDanceDocument._DanceConfigReader.Table[i];
				List<DanceConfig.RowData> list;
				bool flag = !XDanceDocument.m_DanceConfigData.TryGetValue((uint)rowData.PresentID, out list);
				if (flag)
				{
					list = new List<DanceConfig.RowData>();
				}
				list.Add(rowData);
				XDanceDocument.m_DanceConfigData[(uint)rowData.PresentID] = list;
			}
		}

		// Token: 0x06008DAC RID: 36268 RVA: 0x001370D0 File Offset: 0x001352D0
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_Move, new XComponent.XEventHandler(this.OnStopAnimation));
		}

		// Token: 0x06008DAD RID: 36269 RVA: 0x001370F0 File Offset: 0x001352F0
		protected bool OnStopAnimation(XEventArgs args)
		{
			bool playerDancing = this._playerDancing;
			if (playerDancing)
			{
				this.ReqStopJustDance();
			}
			return true;
		}

		// Token: 0x06008DAE RID: 36270 RVA: 0x00137114 File Offset: 0x00135314
		public static DanceConfig.RowData GetDanceConfig(uint motionID)
		{
			return XDanceDocument._DanceConfigReader.GetByMotionID(motionID);
		}

		// Token: 0x06008DAF RID: 36271 RVA: 0x00137134 File Offset: 0x00135334
		public string GetDanceAction(uint presentID, uint serverMotionID)
		{
			DanceConfig.RowData danceConfig = XDanceDocument.GetDanceConfig(this.GetSelfActualMotionID(presentID, serverMotionID));
			bool flag = danceConfig != null;
			string result;
			if (flag)
			{
				result = danceConfig.Motion;
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x06008DB0 RID: 36272 RVA: 0x0013716C File Offset: 0x0013536C
		private uint GetSelfActualMotionID(uint presentID, uint serverMotionID)
		{
			DanceConfig.RowData danceConfig = XDanceDocument.GetDanceConfig(serverMotionID);
			bool flag = danceConfig == null;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				List<DanceConfig.RowData> list;
				bool flag2 = XDanceDocument.m_DanceConfigData.TryGetValue(presentID, out list);
				if (flag2)
				{
					for (int i = 0; i < list.Count; i++)
					{
						bool flag3 = list[i].MotionType == danceConfig.MotionType;
						if (flag3)
						{
							return list[i].MotionID;
						}
					}
				}
				result = 0U;
			}
			return result;
		}

		// Token: 0x06008DB1 RID: 36273 RVA: 0x001371EF File Offset: 0x001353EF
		public void GetDanceIDs(uint btnType)
		{
			this._currMotionType = btnType;
			this.GetAllDanceIDs();
		}

		// Token: 0x06008DB2 RID: 36274 RVA: 0x00137200 File Offset: 0x00135400
		public void GetAllDanceIDs()
		{
			RpcC2M_GetDanceIds rpcC2M_GetDanceIds = new RpcC2M_GetDanceIds();
			List<DanceConfig.RowData> list;
			bool flag = XDanceDocument.m_DanceConfigData.TryGetValue(XSingleton<XEntityMgr>.singleton.Player.PresentID, out list);
			if (flag)
			{
				for (int i = 0; i < list.Count; i++)
				{
					DanceConfig.RowData rowData = list[i];
					rpcC2M_GetDanceIds.oArg.danceid.Add(rowData.MotionID);
				}
			}
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetDanceIds);
		}

		// Token: 0x06008DB3 RID: 36275 RVA: 0x0013727C File Offset: 0x0013547C
		public void OnGetDanceIDs(GetDanceIdsRes oRes)
		{
			this.m_SelfConfigData.Clear();
			List<DanceMotionData> list = new List<DanceMotionData>();
			for (int i = 0; i < oRes.danceid.Count; i++)
			{
				DanceMotionData danceMotionData = new DanceMotionData();
				danceMotionData.motionID = oRes.danceid[i];
				danceMotionData.valid = oRes.valid[i];
				DanceConfig.RowData danceConfig = XDanceDocument.GetDanceConfig(oRes.danceid[i]);
				bool flag = (this._currMotionType == 1U && !danceConfig.LoverMotion) || (this._currMotionType == 2U && danceConfig.LoverMotion);
				if (flag)
				{
					list.Add(danceMotionData);
				}
				this.m_SelfConfigData.Add(danceMotionData);
			}
			list.Sort(new Comparison<DanceMotionData>(XDanceDocument.SortMotionID));
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshMotionPanel(list);
		}

		// Token: 0x06008DB4 RID: 36276 RVA: 0x00137360 File Offset: 0x00135560
		public static int SortMotionID(DanceMotionData data1, DanceMotionData data2)
		{
			return (int)(data2.valid - data1.valid);
		}

		// Token: 0x06008DB5 RID: 36277 RVA: 0x00137380 File Offset: 0x00135580
		public bool IsUnlock(uint valid, SeqListRef<uint> condition)
		{
			for (int i = 0; i < condition.Count; i++)
			{
				uint type = condition[i, 0];
				bool flag = !this.IsUnlock(valid, type);
				if (flag)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06008DB6 RID: 36278 RVA: 0x001373CC File Offset: 0x001355CC
		public bool IsUnlock(uint valid, uint type)
		{
			uint num = valid & 1U << (int)type;
			return num > 0U;
		}

		// Token: 0x06008DB7 RID: 36279 RVA: 0x001373EC File Offset: 0x001355EC
		public void ReqStartJustDance(uint motionID)
		{
			this._currDancingID = motionID;
			bool playerDancing = this._playerDancing;
			if (playerDancing)
			{
				this.ReqStopJustDance();
			}
			RpcC2G_JustDance rpcC2G_JustDance = new RpcC2G_JustDance();
			rpcC2G_JustDance.oArg.type = (uint)XFastEnumIntEqualityComparer<OutLookStateType>.ToInt(OutLookStateType.OutLook_Dance);
			rpcC2G_JustDance.oArg.danceid = motionID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_JustDance);
		}

		// Token: 0x06008DB8 RID: 36280 RVA: 0x00137444 File Offset: 0x00135644
		public void ReqStopJustDance()
		{
			bool flag = !this._playerDancing;
			if (!flag)
			{
				RpcC2G_JustDance rpcC2G_JustDance = new RpcC2G_JustDance();
				rpcC2G_JustDance.oArg.type = (uint)XFastEnumIntEqualityComparer<OutLookStateType>.ToInt(OutLookStateType.OutLook_Normal);
				rpcC2G_JustDance.oArg.danceid = this._currDancingID;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_JustDance);
			}
		}

		// Token: 0x06008DB9 RID: 36281 RVA: 0x00137498 File Offset: 0x00135698
		public void OnJustDance(JustDanceArg oArg, JustDanceRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
		}

		// Token: 0x06008DBA RID: 36282 RVA: 0x001374CC File Offset: 0x001356CC
		private void StartDance(uint motionID)
		{
			bool dancingEffectPlaying = this._dancingEffectPlaying;
			if (dancingEffectPlaying)
			{
				this.StopDance(motionID);
			}
			DanceConfig.RowData danceConfig = XDanceDocument.GetDanceConfig(motionID);
			bool flag = danceConfig == null;
			if (!flag)
			{
				float num = XSingleton<XEntityMgr>.singleton.Player.PlaySpecifiedAnimationGetLength(danceConfig.Motion);
				XSingleton<XTimerMgr>.singleton.KillTimer(this._timerToken);
				bool flag2 = danceConfig.LoopCount != 0 && num > 0f;
				if (flag2)
				{
					this._timerToken = XSingleton<XTimerMgr>.singleton.SetTimer(num * (float)danceConfig.LoopCount, new XTimerMgr.ElapsedEventHandler(this.OnFishingStateChange), null);
				}
				bool flag3 = danceConfig.Music != "";
				if (flag3)
				{
					XSingleton<XAudioMgr>.singleton.PlaySound(XSingleton<XEntityMgr>.singleton.Player, AudioChannel.Action, danceConfig.Music);
					XSingleton<XAudioMgr>.singleton.PauseBGM();
				}
				this._dancingEffectPlaying = true;
			}
		}

		// Token: 0x06008DBB RID: 36283 RVA: 0x001375AC File Offset: 0x001357AC
		private void OnFishingStateChange(object o = null)
		{
			this.ReqStopJustDance();
		}

		// Token: 0x06008DBC RID: 36284 RVA: 0x001375B8 File Offset: 0x001357B8
		private void StopDance(uint motionID)
		{
			bool flag = !this._dancingEffectPlaying;
			if (!flag)
			{
				DanceConfig.RowData danceConfig = XDanceDocument.GetDanceConfig(motionID);
				bool flag2 = danceConfig == null;
				if (!flag2)
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(this._timerToken);
					bool flag3 = danceConfig.Music != "";
					if (flag3)
					{
						XSingleton<XAudioMgr>.singleton.StopSound(XSingleton<XEntityMgr>.singleton.Player, AudioChannel.Action);
						XSingleton<XAudioMgr>.singleton.ResumeBGM();
					}
					this._dancingEffectPlaying = false;
				}
			}
		}

		// Token: 0x06008DBD RID: 36285 RVA: 0x001375AC File Offset: 0x001357AC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.ReqStopJustDance();
		}

		// Token: 0x06008DBE RID: 36286 RVA: 0x00137638 File Offset: 0x00135838
		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			bool dancingEffectPlaying = this._dancingEffectPlaying;
			if (dancingEffectPlaying)
			{
				XSingleton<XAudioMgr>.singleton.StopSound(XSingleton<XEntityMgr>.singleton.Player, AudioChannel.Action);
			}
			this._dancingEffectPlaying = false;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timerToken);
			this._timerToken = 0U;
		}

		// Token: 0x06008DBF RID: 36287 RVA: 0x0013768C File Offset: 0x0013588C
		public static void OnDance(bool bDancing, XEntity entity, uint motionID)
		{
			motionID = XDanceDocument.Doc.GetSelfActualMotionID(entity.PresentID, motionID);
			bool flag = entity != null && bDancing;
			if (flag)
			{
				DanceConfig.RowData danceConfig = XDanceDocument.GetDanceConfig(motionID);
				bool flag2 = danceConfig != null && danceConfig.EffectPath != "";
				if (flag2)
				{
					XSingleton<XFxMgr>.singleton.CreateAndPlay(danceConfig.EffectPath, entity.MoveObj, Vector3.zero, Vector3.one, 1f, false, danceConfig.EffectTime, true);
				}
			}
			bool flag3 = entity == null || !entity.IsPlayer;
			if (!flag3)
			{
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("NPCRamdom");
				int num = UnityEngine.Random.Range(0, 100);
				List<uint> npcs = XSingleton<XEntityMgr>.singleton.GetNpcs(XSingleton<XScene>.singleton.SceneID);
				bool flag4 = npcs != null && num > @int;
				if (flag4)
				{
					int i = 0;
					int count = npcs.Count;
					while (i < count)
					{
						XNpc npc = XSingleton<XEntityMgr>.singleton.GetNpc(npcs[i]);
						bool flag5 = npc != null;
						if (flag5)
						{
							npc.InteractRoleDance(entity as XRole, bDancing);
						}
						i++;
					}
				}
				XDanceDocument specificDocument = XDocuments.GetSpecificDocument<XDanceDocument>(XDanceDocument.uuID);
				if (bDancing)
				{
					specificDocument.StartDance(motionID);
				}
				else
				{
					specificDocument.StopDance(motionID);
				}
			}
		}

		// Token: 0x04002DFF RID: 11775
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("DanceDocument");

		// Token: 0x04002E00 RID: 11776
		private uint _timerToken;

		// Token: 0x04002E01 RID: 11777
		private bool _dancingEffectPlaying = false;

		// Token: 0x04002E02 RID: 11778
		private uint _currDancingID;

		// Token: 0x04002E03 RID: 11779
		private uint _currMotionType = 0U;

		// Token: 0x04002E04 RID: 11780
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002E05 RID: 11781
		private static DanceConfig _DanceConfigReader = new DanceConfig();

		// Token: 0x04002E06 RID: 11782
		private static Dictionary<uint, List<DanceConfig.RowData>> m_DanceConfigData = new Dictionary<uint, List<DanceConfig.RowData>>();

		// Token: 0x04002E07 RID: 11783
		private List<DanceMotionData> m_SelfConfigData = new List<DanceMotionData>();
	}
}

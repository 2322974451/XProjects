using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDanceDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XDanceDocument.uuID;
			}
		}

		private bool _playerDancing
		{
			get
			{
				return XSingleton<XAttributeMgr>.singleton.XPlayerData.Outlook.state.bDancing;
			}
		}

		public static Dictionary<uint, List<DanceConfig.RowData>> DanceConfigData
		{
			get
			{
				return XDanceDocument.m_DanceConfigData;
			}
		}

		public List<DanceMotionData> SelfConfigData
		{
			get
			{
				return this.m_SelfConfigData;
			}
		}

		public static XDanceDocument Doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XDanceDocument>(XDanceDocument.uuID);
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XDanceDocument.AsyncLoader.AddTask("Table/DanceConfig", XDanceDocument._DanceConfigReader, false);
			XDanceDocument.AsyncLoader.Execute(callback);
		}

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

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_Move, new XComponent.XEventHandler(this.OnStopAnimation));
		}

		protected bool OnStopAnimation(XEventArgs args)
		{
			bool playerDancing = this._playerDancing;
			if (playerDancing)
			{
				this.ReqStopJustDance();
			}
			return true;
		}

		public static DanceConfig.RowData GetDanceConfig(uint motionID)
		{
			return XDanceDocument._DanceConfigReader.GetByMotionID(motionID);
		}

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

		public void GetDanceIDs(uint btnType)
		{
			this._currMotionType = btnType;
			this.GetAllDanceIDs();
		}

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

		public static int SortMotionID(DanceMotionData data1, DanceMotionData data2)
		{
			return (int)(data2.valid - data1.valid);
		}

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

		public bool IsUnlock(uint valid, uint type)
		{
			uint num = valid & 1U << (int)type;
			return num > 0U;
		}

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

		public void OnJustDance(JustDanceArg oArg, JustDanceRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
		}

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

		private void OnFishingStateChange(object o = null)
		{
			this.ReqStopJustDance();
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.ReqStopJustDance();
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("DanceDocument");

		private uint _timerToken;

		private bool _dancingEffectPlaying = false;

		private uint _currDancingID;

		private uint _currMotionType = 0U;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static DanceConfig _DanceConfigReader = new DanceConfig();

		private static Dictionary<uint, List<DanceConfig.RowData>> m_DanceConfigData = new Dictionary<uint, List<DanceConfig.RowData>>();

		private List<DanceMotionData> m_SelfConfigData = new List<DanceMotionData>();
	}
}

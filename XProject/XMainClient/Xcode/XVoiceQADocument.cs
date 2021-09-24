using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XVoiceQADocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XVoiceQADocument.uuID;
			}
		}

		public QAConditionTable QaConfigTable
		{
			get
			{
				return XVoiceQADocument._qaconfigTable;
			}
		}

		public QuestionLibraryTable QuestionTable
		{
			get
			{
				return XVoiceQADocument._questionTable;
			}
		}

		public QALevelRewardTable QaLevelRewardTable
		{
			get
			{
				return XVoiceQADocument._qaLevelRewardTable;
			}
		}

		public List<VoiceAnswer> AnswerList
		{
			get
			{
				return this._answerList;
			}
		}

		public uint CurrentType
		{
			get
			{
				return this._currentType;
			}
			set
			{
				this._currentType = value;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XVoiceQADocument.AsyncLoader.AddTask("Table/QuestionLibrary", XVoiceQADocument._questionTable, false);
			XVoiceQADocument.AsyncLoader.AddTask("Table/QALevelReward", XVoiceQADocument._qaLevelRewardTable, false);
			XVoiceQADocument.AsyncLoader.AddTask("Table/QACondition", XVoiceQADocument._qaconfigTable, false);
			XVoiceQADocument.AsyncLoader.Execute(callback);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.SendQueryVoiceQAInfo();
			}
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool isVoiceQAIng = this.IsVoiceQAIng;
				if (isVoiceQAIng)
				{
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.OnVoiceBtnAppear(0U);
				}
				else
				{
					bool flag2 = this.TempType > 0U;
					if (flag2)
					{
						DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.OnVoiceBtnAppear(this.TempType);
					}
				}
			}
		}

		public void VoiceQAInit(uint type)
		{
			this._currentType = type;
			this.IsAutoPlay = (XSingleton<XClientNetwork>.singleton.IsWifiEnable() || !XSingleton<XChatIFlyMgr>.singleton.IsChannelAutoPlayEnable(ChatChannelType.ZeroChannel));
		}

		public void VoiceQAJoinChoose(bool join, uint type)
		{
			this.TempType = 0U;
			this._answerList.Clear();
			RpcC2G_AgreeQAReq rpcC2G_AgreeQAReq = new RpcC2G_AgreeQAReq();
			rpcC2G_AgreeQAReq.oArg.agree = join;
			rpcC2G_AgreeQAReq.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_AgreeQAReq);
		}

		public void SendAnswer(string ans, ulong audioID, uint audioTime)
		{
			bool flag = ans.Length == 0;
			if (!flag)
			{
				PtcC2M_CommitAnswerNtf ptcC2M_CommitAnswerNtf = new PtcC2M_CommitAnswerNtf();
				ptcC2M_CommitAnswerNtf.Data.audiouid = audioID;
				ptcC2M_CommitAnswerNtf.Data.answer = ans;
				ptcC2M_CommitAnswerNtf.Data.audiotime = audioTime;
				XSingleton<XClientNetwork>.singleton.Send(ptcC2M_CommitAnswerNtf);
			}
		}

		public void SendQueryVoiceQAInfo()
		{
			RpcC2M_GetQADataReq rpc = new RpcC2M_GetQADataReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void SetVoiceQAInfo(GetQADataRes data)
		{
			XSingleton<XDebug>.singleton.AddLog("Get VoiceQA data for server, Time = ", data.leftTime.ToString(), " question id = ", data.serialnum.ToString(), null, null, XDebugColor.XDebug_None);
			bool flag = DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.RefreshPage((int)data.serialnum, data.qid, data.leftTime);
			}
		}

		public void SetRankList(List<QARoomRankData> list, uint myscore)
		{
			this.MyScore = myscore;
			this.ScoreList.Clear();
			for (int i = 0; i < list.Count; i++)
			{
				QARoomRankData qaroomRankData = new QARoomRankData();
				qaroomRankData.uuid = list[i].uuid;
				qaroomRankData.score = list[i].score;
				this.ScoreList.Add(qaroomRankData);
			}
			bool flag = DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.RefreshRank();
			}
		}

		public void SetQuestion(int id, uint index)
		{
			this.IsNowDesRight = false;
			bool flag = DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.SetQuestion(id, index, true, 0.0);
			}
		}

		public void NextQuestionQuery()
		{
			PtcC2M_GiveUpQAQuestionNtf proto = new PtcC2M_GiveUpQAQuestionNtf();
			XSingleton<XClientNetwork>.singleton.Send(proto);
		}

		public void VoiceQAStatement(uint totol, uint right, List<ItemBrief> list)
		{
			this.TempType = 0U;
			this.IsVoiceQAIng = false;
			this.MainInterFaceBtnState = false;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildRelax_VoiceQA, true);
			bool flag = totol == 10000U || right == 10000U;
			if (!flag)
			{
				bool flag2 = DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.VoiceQAEnd(totol, right, list);
				}
			}
		}

		public void DealWithNameIndex(List<QAIDName> list)
		{
			this._nameIndex.Clear();
			this.ScoreList.Clear();
			this.MyScore = 0U;
			for (int i = 0; i < list.Count; i++)
			{
				this._nameIndex[list[i].uuid] = list[i].name;
				QARoomRankData qaroomRankData = new QARoomRankData();
				qaroomRankData.uuid = list[i].uuid;
				qaroomRankData.score = 0U;
				this.ScoreList.Add(qaroomRankData);
			}
			bool flag = DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.RefreshRank();
			}
		}

		public string GetPlayerNameByRoleID(ulong roleID)
		{
			string result = "";
			bool flag = !this._nameIndex.TryGetValue(roleID, out result);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Can't find player name by roleID, roleID = ", roleID.ToString(), null, null, null, null);
			}
			return result;
		}

		public void AddEnterRoomInfo2List(QAEnterRoomNtf data)
		{
			VoiceAnswer voiceAnswer = new VoiceAnswer();
			voiceAnswer.isEnterRoom = true;
			voiceAnswer.roleId = data.roleID;
			voiceAnswer.name = data.name;
			voiceAnswer.profession = data.profession;
			voiceAnswer.answerTime = data.time;
			voiceAnswer.desID = data.coverDesignationID;
			voiceAnswer.times = 0U;
			voiceAnswer.content = "";
			voiceAnswer.right = false;
			voiceAnswer.rank = 999U;
			voiceAnswer.audioTime = 0U;
			voiceAnswer.audioID = 0UL;
			voiceAnswer.isNew = true;
			this._answerList.Add(voiceAnswer);
			this._nameIndex[data.roleID] = data.name;
			QARoomRankData qaroomRankData = new QARoomRankData();
			qaroomRankData.uuid = data.roleID;
			qaroomRankData.score = 0U;
			this.ScoreList.Add(qaroomRankData);
			bool flag = DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.RefreshList();
				DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.RefreshRank();
			}
		}

		public void AddAnswer2List(AnswerAckNtf data)
		{
			VoiceAnswer voiceAnswer = new VoiceAnswer();
			voiceAnswer.isEnterRoom = false;
			voiceAnswer.roleId = data.roleId;
			voiceAnswer.audioID = data.audioUid;
			voiceAnswer.name = data.userName;
			voiceAnswer.content = data.answer;
			voiceAnswer.right = data.correct;
			voiceAnswer.times = data.times;
			voiceAnswer.rank = data.rank;
			voiceAnswer.answerTime = data.answertime;
			voiceAnswer.desID = data.coverDesignationId;
			voiceAnswer.audioTime = data.audioTime;
			voiceAnswer.profession = data.profession;
			voiceAnswer.isNew = true;
			this._answerList.Add(voiceAnswer);
			bool flag = DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.RefreshList();
			}
		}

		public void OpenView()
		{
			DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.SetVisible(true, true);
		}

		public void GetReward()
		{
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			foreach (QALevelRewardTable.RowData rowData in XVoiceQADocument._qaLevelRewardTable.Table)
			{
				bool flag = rowData.QAType == this._currentType && level >= rowData.MinLevel && level <= rowData.MaxLevel;
				if (flag)
				{
					this.Reward = rowData.Reward;
					this.ExtraReward = rowData.ExtraReward;
					return;
				}
			}
			XSingleton<XDebug>.singleton.AddErrorLog("Can't Find QALevelReward!!! Level = ", level.ToString(), "QAType = ", this._currentType.ToString(), null, null);
		}

		public void LevelUp()
		{
			bool flag = this.TempType == 0U;
			if (!flag)
			{
				QAConditionTable.RowData byQAType = XVoiceQADocument._qaconfigTable.GetByQAType((int)this.TempType);
				bool flag2 = byQAType == null;
				if (!flag2)
				{
					uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
					for (int i = 0; i < byQAType.LevelSection.Count; i++)
					{
						bool flag3 = level >= byQAType.LevelSection[i, 0] && level <= byQAType.LevelSection[i, 1];
						if (flag3)
						{
							return;
						}
					}
					this.TempType = 0U;
					this.IsVoiceQAIng = false;
					this.MainInterFaceBtnState = false;
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildRelax_VoiceQA, true);
				}
			}
		}

		public void IDIPClearRoleMsg(ulong roleID)
		{
			for (int i = this._answerList.Count - 1; i >= 0; i--)
			{
				bool flag = this._answerList[i].roleId == roleID;
				if (flag)
				{
					this._answerList.RemoveAt(i);
				}
			}
			bool flag2 = DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.RefreshList();
			}
		}

		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			this.LevelUp();
			return true;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("VoiceQADocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static QAConditionTable _qaconfigTable = new QAConditionTable();

		private static QuestionLibraryTable _questionTable = new QuestionLibraryTable();

		private static QALevelRewardTable _qaLevelRewardTable = new QALevelRewardTable();

		private Dictionary<ulong, string> _nameIndex = new Dictionary<ulong, string>();

		private List<VoiceAnswer> _answerList = new List<VoiceAnswer>();

		public SeqListRef<uint> Reward;

		public SeqListRef<uint> ExtraReward;

		public List<QARoomRankData> ScoreList = new List<QARoomRankData>();

		public uint MyScore = 0U;

		private uint _currentType = 1U;

		public uint TempType;

		public bool IsVoiceQAIng = false;

		public bool IsNowDesRight = false;

		public bool IsAutoPlay = true;

		public bool IsFirstOpenUI = false;

		public bool MainInterFaceBtnState = false;
	}
}

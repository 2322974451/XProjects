using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A07 RID: 2567
	internal class XVoiceQADocument : XDocComponent
	{
		// Token: 0x17002E8C RID: 11916
		// (get) Token: 0x06009D3A RID: 40250 RVA: 0x00199260 File Offset: 0x00197460
		public override uint ID
		{
			get
			{
				return XVoiceQADocument.uuID;
			}
		}

		// Token: 0x17002E8D RID: 11917
		// (get) Token: 0x06009D3B RID: 40251 RVA: 0x00199278 File Offset: 0x00197478
		public QAConditionTable QaConfigTable
		{
			get
			{
				return XVoiceQADocument._qaconfigTable;
			}
		}

		// Token: 0x17002E8E RID: 11918
		// (get) Token: 0x06009D3C RID: 40252 RVA: 0x00199290 File Offset: 0x00197490
		public QuestionLibraryTable QuestionTable
		{
			get
			{
				return XVoiceQADocument._questionTable;
			}
		}

		// Token: 0x17002E8F RID: 11919
		// (get) Token: 0x06009D3D RID: 40253 RVA: 0x001992A8 File Offset: 0x001974A8
		public QALevelRewardTable QaLevelRewardTable
		{
			get
			{
				return XVoiceQADocument._qaLevelRewardTable;
			}
		}

		// Token: 0x17002E90 RID: 11920
		// (get) Token: 0x06009D3E RID: 40254 RVA: 0x001992C0 File Offset: 0x001974C0
		public List<VoiceAnswer> AnswerList
		{
			get
			{
				return this._answerList;
			}
		}

		// Token: 0x17002E91 RID: 11921
		// (get) Token: 0x06009D3F RID: 40255 RVA: 0x001992D8 File Offset: 0x001974D8
		// (set) Token: 0x06009D40 RID: 40256 RVA: 0x001992F0 File Offset: 0x001974F0
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

		// Token: 0x06009D41 RID: 40257 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06009D42 RID: 40258 RVA: 0x001992FC File Offset: 0x001974FC
		public static void Execute(OnLoadedCallback callback = null)
		{
			XVoiceQADocument.AsyncLoader.AddTask("Table/QuestionLibrary", XVoiceQADocument._questionTable, false);
			XVoiceQADocument.AsyncLoader.AddTask("Table/QALevelReward", XVoiceQADocument._qaLevelRewardTable, false);
			XVoiceQADocument.AsyncLoader.AddTask("Table/QACondition", XVoiceQADocument._qaconfigTable, false);
			XVoiceQADocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009D43 RID: 40259 RVA: 0x00199358 File Offset: 0x00197558
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		// Token: 0x06009D44 RID: 40260 RVA: 0x0019937C File Offset: 0x0019757C
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.SendQueryVoiceQAInfo();
			}
		}

		// Token: 0x06009D45 RID: 40261 RVA: 0x001993A0 File Offset: 0x001975A0
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

		// Token: 0x06009D46 RID: 40262 RVA: 0x00199401 File Offset: 0x00197601
		public void VoiceQAInit(uint type)
		{
			this._currentType = type;
			this.IsAutoPlay = (XSingleton<XClientNetwork>.singleton.IsWifiEnable() || !XSingleton<XChatIFlyMgr>.singleton.IsChannelAutoPlayEnable(ChatChannelType.ZeroChannel));
		}

		// Token: 0x06009D47 RID: 40263 RVA: 0x00199430 File Offset: 0x00197630
		public void VoiceQAJoinChoose(bool join, uint type)
		{
			this.TempType = 0U;
			this._answerList.Clear();
			RpcC2G_AgreeQAReq rpcC2G_AgreeQAReq = new RpcC2G_AgreeQAReq();
			rpcC2G_AgreeQAReq.oArg.agree = join;
			rpcC2G_AgreeQAReq.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_AgreeQAReq);
		}

		// Token: 0x06009D48 RID: 40264 RVA: 0x00199480 File Offset: 0x00197680
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

		// Token: 0x06009D49 RID: 40265 RVA: 0x001994D8 File Offset: 0x001976D8
		public void SendQueryVoiceQAInfo()
		{
			RpcC2M_GetQADataReq rpc = new RpcC2M_GetQADataReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009D4A RID: 40266 RVA: 0x001994F8 File Offset: 0x001976F8
		public void SetVoiceQAInfo(GetQADataRes data)
		{
			XSingleton<XDebug>.singleton.AddLog("Get VoiceQA data for server, Time = ", data.leftTime.ToString(), " question id = ", data.serialnum.ToString(), null, null, XDebugColor.XDebug_None);
			bool flag = DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.RefreshPage((int)data.serialnum, data.qid, data.leftTime);
			}
		}

		// Token: 0x06009D4B RID: 40267 RVA: 0x00199568 File Offset: 0x00197768
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

		// Token: 0x06009D4C RID: 40268 RVA: 0x001995F4 File Offset: 0x001977F4
		public void SetQuestion(int id, uint index)
		{
			this.IsNowDesRight = false;
			bool flag = DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.SetQuestion(id, index, true, 0.0);
			}
		}

		// Token: 0x06009D4D RID: 40269 RVA: 0x00199630 File Offset: 0x00197830
		public void NextQuestionQuery()
		{
			PtcC2M_GiveUpQAQuestionNtf proto = new PtcC2M_GiveUpQAQuestionNtf();
			XSingleton<XClientNetwork>.singleton.Send(proto);
		}

		// Token: 0x06009D4E RID: 40270 RVA: 0x00199650 File Offset: 0x00197850
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

		// Token: 0x06009D4F RID: 40271 RVA: 0x001996BC File Offset: 0x001978BC
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

		// Token: 0x06009D50 RID: 40272 RVA: 0x0019976C File Offset: 0x0019796C
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

		// Token: 0x06009D51 RID: 40273 RVA: 0x001997B8 File Offset: 0x001979B8
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

		// Token: 0x06009D52 RID: 40274 RVA: 0x001998BC File Offset: 0x00197ABC
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

		// Token: 0x06009D53 RID: 40275 RVA: 0x00199988 File Offset: 0x00197B88
		public void OpenView()
		{
			DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.SetVisible(true, true);
		}

		// Token: 0x06009D54 RID: 40276 RVA: 0x00199998 File Offset: 0x00197B98
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

		// Token: 0x06009D55 RID: 40277 RVA: 0x00199A48 File Offset: 0x00197C48
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

		// Token: 0x06009D56 RID: 40278 RVA: 0x00199B0C File Offset: 0x00197D0C
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

		// Token: 0x06009D57 RID: 40279 RVA: 0x00199B7C File Offset: 0x00197D7C
		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			this.LevelUp();
			return true;
		}

		// Token: 0x0400375C RID: 14172
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("VoiceQADocument");

		// Token: 0x0400375D RID: 14173
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x0400375E RID: 14174
		private static QAConditionTable _qaconfigTable = new QAConditionTable();

		// Token: 0x0400375F RID: 14175
		private static QuestionLibraryTable _questionTable = new QuestionLibraryTable();

		// Token: 0x04003760 RID: 14176
		private static QALevelRewardTable _qaLevelRewardTable = new QALevelRewardTable();

		// Token: 0x04003761 RID: 14177
		private Dictionary<ulong, string> _nameIndex = new Dictionary<ulong, string>();

		// Token: 0x04003762 RID: 14178
		private List<VoiceAnswer> _answerList = new List<VoiceAnswer>();

		// Token: 0x04003763 RID: 14179
		public SeqListRef<uint> Reward;

		// Token: 0x04003764 RID: 14180
		public SeqListRef<uint> ExtraReward;

		// Token: 0x04003765 RID: 14181
		public List<QARoomRankData> ScoreList = new List<QARoomRankData>();

		// Token: 0x04003766 RID: 14182
		public uint MyScore = 0U;

		// Token: 0x04003767 RID: 14183
		private uint _currentType = 1U;

		// Token: 0x04003768 RID: 14184
		public uint TempType;

		// Token: 0x04003769 RID: 14185
		public bool IsVoiceQAIng = false;

		// Token: 0x0400376A RID: 14186
		public bool IsNowDesRight = false;

		// Token: 0x0400376B RID: 14187
		public bool IsAutoPlay = true;

		// Token: 0x0400376C RID: 14188
		public bool IsFirstOpenUI = false;

		// Token: 0x0400376D RID: 14189
		public bool MainInterFaceBtnState = false;
	}
}

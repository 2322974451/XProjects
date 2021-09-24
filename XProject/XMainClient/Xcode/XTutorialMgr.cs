using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	public class XTutorialMgr : XSingleton<XTutorialMgr>, IXTutorial, IXInterface
	{

		public bool InTutorial
		{
			get
			{
				return this._currentCmd != null && this._currentCmd.state == XCmdState.Cmd_In_Process && this._currentCmd.cmd != "noforceclick";
			}
		}

		public bool NeedTutorail { get; set; }

		public bool Exculsive { get; set; }

		public bool NoforceClick { get; set; }

		public bool ExculsiveOnGeneric { get; set; }

		public bool ExculsiveOnEntity { get; set; }

		public bool Deprecated { get; set; }

		public XTutorialMgr()
		{
			this.Exculsive = false;
			this.NeedTutorail = false;
		}

		public override bool Init()
		{
			return true;
		}

		public override void Uninit()
		{
			this._externalString.Clear();
			this.SubTutorialExecution.Clear();
			bool flag = this._subTutorials != null;
			if (flag)
			{
				this._subTutorials.Clear();
			}
			bool flag2 = this._subQueue != null;
			if (flag2)
			{
				this._subQueue.Clear();
			}
			this._currentCmd = null;
			this.NeedTutorail = false;
		}

		public void OnLeaveScene()
		{
			bool flag = this._currentCmd != null && this._currentCmd.state == XCmdState.Cmd_In_Process;
			if (flag)
			{
				this._executor.OnCmdFinish(ref this._currentCmd);
			}
		}

		public void Reset(byte[] tutorialBitsArray)
		{
			XSingleton<XInterfaceMgr>.singleton.AttachInterface<IXTutorial>(XSingleton<XCommon>.singleton.XHash("XTutorial"), this);
			this.Reset();
			this._parser = new XTutorialCmdParser();
			this._executor = new XTutorialCmdExecutor();
			this._subTutorials = new List<XTutorialMainCmd>();
			string file = "Table/Tutorial/TutorialEntrance";
			this._parser.Parse(file, ref this._subTutorials, ref this._SysIdToTutorial);
			this.NeedTutorail = true;
			int num = 0;
			while ((long)num < (long)((ulong)XTutorialMgr.TUTORIAL_CELL_MAX))
			{
				bool flag = tutorialBitsArray != null && tutorialBitsArray.Length > num;
				if (flag)
				{
					this.TutorialBitsArray[num] = tutorialBitsArray[num];
				}
				else
				{
					this.TutorialBitsArray[num] = 0;
				}
				num++;
			}
			XSingleton<XTutorialHelper>.singleton.Init();
			this.SubTutorialExecution.Clear();
		}

		private bool TutorialFinished(int bit)
		{
			bit--;
			int num = bit % 8;
			int num2 = bit / 8;
			return ((int)this.TutorialBitsArray[num2] & 1 << num) > 0;
		}

		protected void Reset()
		{
			this._currentCmd = null;
			this._externalString.Clear();
			bool flag = this._subQueue != null;
			if (flag)
			{
				this._subQueue.Clear();
			}
			this.Exculsive = false;
			this.NeedTutorail = false;
			this.NoforceClick = false;
			this.ExculsiveOnGeneric = false;
			this._LastStartTutorial = 0f;
		}

		public void NewSubQueue(string script, int savebit)
		{
			bool flag = this._subQueue == null;
			if (flag)
			{
				this._subQueue = new Queue<XTutorialCmd>();
			}
			this._subQueue.Clear();
			this._parser.Parse(script, 0, ref this._subQueue, savebit);
		}

		public void AddSubQueue(string script, int savebit)
		{
			Queue<XTutorialCmd> queue = new Queue<XTutorialCmd>();
			this._parser.Parse(script, 0, ref queue, savebit);
			bool flag = this._subQueue == null;
			if (flag)
			{
				this._subQueue = new Queue<XTutorialCmd>();
			}
			while (queue.Count > 0)
			{
				this._subQueue.Enqueue(queue.Dequeue());
			}
		}

		protected bool SubTutorialExecuted(int id)
		{
			bool flag = this.SubTutorialExecution.ContainsKey(id);
			return flag && this.SubTutorialExecution[id];
		}

		protected void SetSubTutorialExecution(int id)
		{
			bool flag = this.SubTutorialExecution.ContainsKey(id);
			if (flag)
			{
				this.SubTutorialExecution[id] = true;
			}
			else
			{
				this.SubTutorialExecution.Add(id, true);
			}
		}

		private bool LookupNewTutorial()
		{
			for (int i = 0; i < this._subTutorials.Count; i++)
			{
				bool flag = this.TutorialFinished(this._subTutorials[i].savebit);
				if (!flag)
				{
					bool flag2 = this.SubTutorialExecuted(this._subTutorials[i].savebit);
					if (!flag2)
					{
						bool flag3 = this._executor.CanTutorialExecute(this._subTutorials[i]);
						if (flag3)
						{
							this.SetSubTutorialExecution(this._subTutorials[i].savebit);
							XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
							bool flag4 = specificDocument.GetValue(XOptionsDefine.OD_SKIP_TUTORIAL) == 1 && !this._subTutorials[i].isMust;
							if (!flag4)
							{
								string script = "Table/Tutorial/" + this._subTutorials[i].subTutorial;
								bool flag5 = Time.time - this._LastStartTutorial > 1f;
								if (flag5)
								{
									bool flag6 = this._currentCmd != null;
									if (flag6)
									{
										this.OnCmdFinished();
									}
									bool flag7 = this._currentCmd != null && this._currentCmd.state == XCmdState.Cmd_In_Queue;
									if (flag7)
									{
										this._currentCmd.state = XCmdState.Cmd_Finished;
									}
									this.NewSubQueue(script, this._subTutorials[i].savebit);
									bool flag8 = this._subQueue != null && this._subQueue.Count > 0;
									if (flag8)
									{
										this._currentCmd = this._subQueue.Dequeue();
										this._currentSubTutorial = this._subTutorials[i].subTutorial;
										XSingleton<XDebug>.singleton.AddLog(string.Concat(new object[]
										{
											this._subTutorials[i].savebit,
											": ",
											this._currentSubTutorial,
											" start !"
										}), null, null, null, null, null, XDebugColor.XDebug_None);
									}
								}
								else
								{
									this.AddSubQueue(script, this._subTutorials[i].savebit);
									XSingleton<XDebug>.singleton.AddLog(string.Concat(new object[]
									{
										this._subTutorials[i].savebit,
										": ",
										this._subTutorials[i].subTutorial,
										" append !"
									}), null, null, null, null, null, XDebugColor.XDebug_None);
								}
								this._LastStartTutorial = Time.time;
								return true;
							}
							XSingleton<XDebug>.singleton.AddLog(string.Concat(new object[]
							{
								this._subTutorials[i].savebit,
								": ",
								this._subTutorials[i].subTutorial,
								" skip"
							}), null, null, null, null, null, XDebugColor.XDebug_None);
							this.UpdateTutorialState(this._subTutorials[i].savebit);
						}
					}
				}
			}
			return false;
		}

		private XTutorialCmd FetchNewCmd()
		{
			XTutorialCmd result = null;
			bool flag = this._subQueue != null && this._subQueue.Count > 0;
			if (flag)
			{
				result = this._subQueue.Dequeue();
			}
			XSingleton<XTutorialHelper>.singleton.NextCmdClear();
			return result;
		}

		public bool IsNextCmdOverlay()
		{
			bool flag = this._subQueue == null || this._subQueue.Count == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XTutorialCmd xtutorialCmd = this._subQueue.Peek();
				bool flag2 = xtutorialCmd != null && xtutorialCmd.cmd == "forceclick";
				result = flag2;
			}
			return result;
		}

		public void SkipCurrentTutorial(bool isAll = false)
		{
			for (;;)
			{
				this.OnCmdFinished();
				this._currentCmd = this.FetchNewCmd();
				bool flag = this._currentCmd == null;
				if (flag)
				{
					break;
				}
				bool bLastCmdInQueue = this._currentCmd.bLastCmdInQueue;
				if (bLastCmdInQueue)
				{
					this.UpdateTutorialState(this._currentCmd.step);
					bool flag2 = !isAll;
					if (flag2)
					{
						goto Block_3;
					}
				}
			}
			return;
			Block_3:
			XSingleton<XDebug>.singleton.AddLog("Skip Current Tutorial:" + this._currentCmd.step, null, null, null, null, null, XDebugColor.XDebug_None);
			this._currentCmd = this.FetchNewCmd();
		}

		public void CloseAllTutorial()
		{
			int num = 1;
			while ((long)num < (long)((ulong)(8U * XTutorialMgr.TUTORIAL_CELL_MAX)))
			{
				this.UpdateTutorialState(num);
				num++;
			}
		}

		public void ReExecuteCurrentCmd()
		{
			bool flag = this._currentCmd != null && this._currentCmd.state == XCmdState.Cmd_In_Process;
			if (flag)
			{
				this._currentCmd.state = XCmdState.Cmd_In_Queue;
				bool flag2 = this._executor.CanCmdExecute(this._currentCmd);
				if (flag2)
				{
					this._executor.ExecuteCmd(ref this._currentCmd);
				}
			}
		}

		public void Update()
		{
			bool flag = XSingleton<XClientNetwork>.singleton.XConnect.GetSocketState() == SocketState.State_Closed;
			if (flag)
			{
				bool flag2 = this._currentSubTutorial != "NewbieLevel";
				if (flag2)
				{
					this.SkipCurrentTutorial(false);
					return;
				}
			}
			bool flag3 = this.LookupNewTutorial();
			if (!flag3)
			{
				bool flag4 = this._currentCmd == null || this._currentCmd.state == XCmdState.Cmd_Finished;
				if (flag4)
				{
					this._currentCmd = this.FetchNewCmd();
				}
			}
			bool flag5 = this._currentCmd != null && this._executor.CanCmdExecute(this._currentCmd);
			if (flag5)
			{
				this._executor.ExecuteCmd(ref this._currentCmd);
			}
			bool flag6 = this._currentCmd != null && this._currentCmd.state == XCmdState.Cmd_In_Process;
			if (flag6)
			{
				this._executor.UpdateCmd(ref this._currentCmd);
			}
		}

		public void OnTutorialClicked()
		{
			bool flag = this._currentCmd.endcondition == XTutorialCmdFinishCondition.No_Condition;
			if (flag)
			{
				this.OnCmdFinished();
			}
		}

		protected void UpdateTutorialState(int bit)
		{
			PtcC2G_UpdateTutorial ptcC2G_UpdateTutorial = new PtcC2G_UpdateTutorial();
			ptcC2G_UpdateTutorial.Data.tutorialID = (uint)bit;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_UpdateTutorial);
			bit--;
			int num = bit % 8;
			int num2 = bit / 8;
			byte[] tutorialBitsArray = this.TutorialBitsArray;
			int num3 = num2;
			tutorialBitsArray[num3] |= (byte)(1 << num);
		}

		public void OnCmdFinished()
		{
			bool flag = this._currentCmd != null && this._executor != null && this._currentCmd.state == XCmdState.Cmd_In_Process;
			if (flag)
			{
				this._executor.OnCmdFinish(ref this._currentCmd);
				XSingleton<XDebug>.singleton.AddLog("t step finished ", this._currentCmd.step.ToString(), ":", this._currentCmd.tag, null, null, XDebugColor.XDebug_None);
				bool flag2 = this._currentCmd.step != -1;
				if (flag2)
				{
					this.UpdateTutorialState(this._currentCmd.step);
				}
			}
		}

		public void StopTutorial()
		{
			bool flag = this._currentCmd != null && this._executor != null && this._currentCmd.state == XCmdState.Cmd_In_Process;
			if (flag)
			{
				this._executor.StopCmd();
			}
			this.NeedTutorail = false;
			XSingleton<XInterfaceMgr>.singleton.DetachInterface(XSingleton<XCommon>.singleton.XHash("XTutorial"));
		}

		public void SetExternalString(string str)
		{
			this._externalString.Add(str);
		}

		public bool QueryExternalString(string str, bool autoRemove)
		{
			bool flag = false;
			foreach (string a in this._externalString)
			{
				bool flag2 = a == str;
				if (flag2)
				{
					flag = true;
				}
			}
			bool flag3 = flag && autoRemove;
			if (flag3)
			{
				this._externalString.Remove(str);
			}
			return flag;
		}

		public bool IsImmediatelyOpenSystem(uint sysID)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			XTutorialMainCmd xtutorialMainCmd;
			bool flag = this._SysIdToTutorial.TryGetValue(sysID, out xtutorialMainCmd);
			if (flag)
			{
				byte b = this.TutorialBitsArray[xtutorialMainCmd.savebit / 8];
				int num = xtutorialMainCmd.savebit % 8;
				bool flag2 = ((int)b & 1 << num) != 0;
				if (flag2)
				{
					return true;
				}
				bool flag3 = specificDocument.GetValue(XOptionsDefine.OD_SKIP_TUTORIAL) == 0 || xtutorialMainCmd.isMust;
				if (flag3)
				{
					return false;
				}
			}
			return true;
		}

		public int GetCurrentCmdStep()
		{
			bool flag = this._currentCmd == null || this._currentCmd.state == XCmdState.Cmd_Finished;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				result = this._currentCmd.mainTutorialBit;
			}
			return result;
		}

		private XTutorialCmdParser _parser;

		private XTutorialCmdExecutor _executor;

		private List<XTutorialMainCmd> _subTutorials;

		private Queue<XTutorialCmd> _subQueue;

		private XTutorialCmd _currentCmd;

		private static readonly uint TUTORIAL_CELL_MAX = 16U;

		public byte[] TutorialBitsArray = new byte[XTutorialMgr.TUTORIAL_CELL_MAX];

		public List<string> _externalString = new List<string>();

		private string _currentSubTutorial;

		private XBetterDictionary<uint, XTutorialMainCmd> _SysIdToTutorial = new XBetterDictionary<uint, XTutorialMainCmd>(0);

		private Dictionary<int, bool> SubTutorialExecution = new Dictionary<int, bool>();

		private float _LastStartTutorial = 0f;
	}
}

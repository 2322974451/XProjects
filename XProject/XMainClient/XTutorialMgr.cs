using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E03 RID: 3587
	public class XTutorialMgr : XSingleton<XTutorialMgr>, IXTutorial, IXInterface
	{
		// Token: 0x170033F0 RID: 13296
		// (get) Token: 0x0600C183 RID: 49539 RVA: 0x00296028 File Offset: 0x00294228
		public bool InTutorial
		{
			get
			{
				return this._currentCmd != null && this._currentCmd.state == XCmdState.Cmd_In_Process && this._currentCmd.cmd != "noforceclick";
			}
		}

		// Token: 0x170033F1 RID: 13297
		// (get) Token: 0x0600C184 RID: 49540 RVA: 0x00296068 File Offset: 0x00294268
		// (set) Token: 0x0600C185 RID: 49541 RVA: 0x00296070 File Offset: 0x00294270
		public bool NeedTutorail { get; set; }

		// Token: 0x170033F2 RID: 13298
		// (get) Token: 0x0600C186 RID: 49542 RVA: 0x00296079 File Offset: 0x00294279
		// (set) Token: 0x0600C187 RID: 49543 RVA: 0x00296081 File Offset: 0x00294281
		public bool Exculsive { get; set; }

		// Token: 0x170033F3 RID: 13299
		// (get) Token: 0x0600C188 RID: 49544 RVA: 0x0029608A File Offset: 0x0029428A
		// (set) Token: 0x0600C189 RID: 49545 RVA: 0x00296092 File Offset: 0x00294292
		public bool NoforceClick { get; set; }

		// Token: 0x170033F4 RID: 13300
		// (get) Token: 0x0600C18A RID: 49546 RVA: 0x0029609B File Offset: 0x0029429B
		// (set) Token: 0x0600C18B RID: 49547 RVA: 0x002960A3 File Offset: 0x002942A3
		public bool ExculsiveOnGeneric { get; set; }

		// Token: 0x170033F5 RID: 13301
		// (get) Token: 0x0600C18C RID: 49548 RVA: 0x002960AC File Offset: 0x002942AC
		// (set) Token: 0x0600C18D RID: 49549 RVA: 0x002960B4 File Offset: 0x002942B4
		public bool ExculsiveOnEntity { get; set; }

		// Token: 0x170033F6 RID: 13302
		// (get) Token: 0x0600C18E RID: 49550 RVA: 0x002960BD File Offset: 0x002942BD
		// (set) Token: 0x0600C18F RID: 49551 RVA: 0x002960C5 File Offset: 0x002942C5
		public bool Deprecated { get; set; }

		// Token: 0x0600C190 RID: 49552 RVA: 0x002960D0 File Offset: 0x002942D0
		public XTutorialMgr()
		{
			this.Exculsive = false;
			this.NeedTutorail = false;
		}

		// Token: 0x0600C191 RID: 49553 RVA: 0x00296134 File Offset: 0x00294334
		public override bool Init()
		{
			return true;
		}

		// Token: 0x0600C192 RID: 49554 RVA: 0x00296148 File Offset: 0x00294348
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

		// Token: 0x0600C193 RID: 49555 RVA: 0x002961B0 File Offset: 0x002943B0
		public void OnLeaveScene()
		{
			bool flag = this._currentCmd != null && this._currentCmd.state == XCmdState.Cmd_In_Process;
			if (flag)
			{
				this._executor.OnCmdFinish(ref this._currentCmd);
			}
		}

		// Token: 0x0600C194 RID: 49556 RVA: 0x002961F0 File Offset: 0x002943F0
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

		// Token: 0x0600C195 RID: 49557 RVA: 0x002962C4 File Offset: 0x002944C4
		private bool TutorialFinished(int bit)
		{
			bit--;
			int num = bit % 8;
			int num2 = bit / 8;
			return ((int)this.TutorialBitsArray[num2] & 1 << num) > 0;
		}

		// Token: 0x0600C196 RID: 49558 RVA: 0x002962F8 File Offset: 0x002944F8
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

		// Token: 0x0600C197 RID: 49559 RVA: 0x00296360 File Offset: 0x00294560
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

		// Token: 0x0600C198 RID: 49560 RVA: 0x002963A8 File Offset: 0x002945A8
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

		// Token: 0x0600C199 RID: 49561 RVA: 0x00296408 File Offset: 0x00294608
		protected bool SubTutorialExecuted(int id)
		{
			bool flag = this.SubTutorialExecution.ContainsKey(id);
			return flag && this.SubTutorialExecution[id];
		}

		// Token: 0x0600C19A RID: 49562 RVA: 0x0029643C File Offset: 0x0029463C
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

		// Token: 0x0600C19B RID: 49563 RVA: 0x00296478 File Offset: 0x00294678
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

		// Token: 0x0600C19C RID: 49564 RVA: 0x00296790 File Offset: 0x00294990
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

		// Token: 0x0600C19D RID: 49565 RVA: 0x002967DC File Offset: 0x002949DC
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

		// Token: 0x0600C19E RID: 49566 RVA: 0x0029683C File Offset: 0x00294A3C
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

		// Token: 0x0600C19F RID: 49567 RVA: 0x002968E0 File Offset: 0x00294AE0
		public void CloseAllTutorial()
		{
			int num = 1;
			while ((long)num < (long)((ulong)(8U * XTutorialMgr.TUTORIAL_CELL_MAX)))
			{
				this.UpdateTutorialState(num);
				num++;
			}
		}

		// Token: 0x0600C1A0 RID: 49568 RVA: 0x00296910 File Offset: 0x00294B10
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

		// Token: 0x0600C1A1 RID: 49569 RVA: 0x00296974 File Offset: 0x00294B74
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

		// Token: 0x0600C1A2 RID: 49570 RVA: 0x00296A60 File Offset: 0x00294C60
		public void OnTutorialClicked()
		{
			bool flag = this._currentCmd.endcondition == XTutorialCmdFinishCondition.No_Condition;
			if (flag)
			{
				this.OnCmdFinished();
			}
		}

		// Token: 0x0600C1A3 RID: 49571 RVA: 0x00296A88 File Offset: 0x00294C88
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

		// Token: 0x0600C1A4 RID: 49572 RVA: 0x00296ADC File Offset: 0x00294CDC
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

		// Token: 0x0600C1A5 RID: 49573 RVA: 0x00296B80 File Offset: 0x00294D80
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

		// Token: 0x0600C1A6 RID: 49574 RVA: 0x00296BE3 File Offset: 0x00294DE3
		public void SetExternalString(string str)
		{
			this._externalString.Add(str);
		}

		// Token: 0x0600C1A7 RID: 49575 RVA: 0x00296BF4 File Offset: 0x00294DF4
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

		// Token: 0x0600C1A8 RID: 49576 RVA: 0x00296C78 File Offset: 0x00294E78
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

		// Token: 0x0600C1A9 RID: 49577 RVA: 0x00296D00 File Offset: 0x00294F00
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

		// Token: 0x04005219 RID: 21017
		private XTutorialCmdParser _parser;

		// Token: 0x0400521A RID: 21018
		private XTutorialCmdExecutor _executor;

		// Token: 0x0400521B RID: 21019
		private List<XTutorialMainCmd> _subTutorials;

		// Token: 0x0400521C RID: 21020
		private Queue<XTutorialCmd> _subQueue;

		// Token: 0x0400521D RID: 21021
		private XTutorialCmd _currentCmd;

		// Token: 0x0400521E RID: 21022
		private static readonly uint TUTORIAL_CELL_MAX = 16U;

		// Token: 0x0400521F RID: 21023
		public byte[] TutorialBitsArray = new byte[XTutorialMgr.TUTORIAL_CELL_MAX];

		// Token: 0x04005221 RID: 21025
		public List<string> _externalString = new List<string>();

		// Token: 0x04005222 RID: 21026
		private string _currentSubTutorial;

		// Token: 0x04005227 RID: 21031
		private XBetterDictionary<uint, XTutorialMainCmd> _SysIdToTutorial = new XBetterDictionary<uint, XTutorialMainCmd>(0);

		// Token: 0x04005228 RID: 21032
		private Dictionary<int, bool> SubTutorialExecution = new Dictionary<int, bool>();

		// Token: 0x04005229 RID: 21033
		private float _LastStartTutorial = 0f;
	}
}

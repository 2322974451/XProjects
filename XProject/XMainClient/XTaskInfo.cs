using System;
using System.Collections.Generic;
using System.IO;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A8D RID: 2701
	internal class XTaskInfo
	{
		// Token: 0x17002FBF RID: 12223
		// (get) Token: 0x0600A43B RID: 42043 RVA: 0x001C554C File Offset: 0x001C374C
		public uint ID
		{
			get
			{
				return this.m_ID;
			}
		}

		// Token: 0x17002FC0 RID: 12224
		// (get) Token: 0x0600A43C RID: 42044 RVA: 0x001C5564 File Offset: 0x001C3764
		public TaskStatus Status
		{
			get
			{
				return this.m_Status;
			}
		}

		// Token: 0x17002FC1 RID: 12225
		// (get) Token: 0x0600A43D RID: 42045 RVA: 0x001C557C File Offset: 0x001C377C
		public NpcTaskState NpcState
		{
			get
			{
				return this.m_State;
			}
		}

		// Token: 0x17002FC2 RID: 12226
		// (get) Token: 0x0600A43E RID: 42046 RVA: 0x001C5594 File Offset: 0x001C3794
		public List<TaskConditionInfo> Conds
		{
			get
			{
				return this.m_Conditions;
			}
		}

		// Token: 0x17002FC3 RID: 12227
		// (get) Token: 0x0600A43F RID: 42047 RVA: 0x001C55AC File Offset: 0x001C37AC
		public TaskTableNew.RowData TableData
		{
			get
			{
				return this.m_TableData;
			}
		}

		// Token: 0x17002FC4 RID: 12228
		// (get) Token: 0x0600A440 RID: 42048 RVA: 0x001C55C4 File Offset: 0x001C37C4
		public XTaskDialog BeginDialog
		{
			get
			{
				return this._GetDialog(0);
			}
		}

		// Token: 0x17002FC5 RID: 12229
		// (get) Token: 0x0600A441 RID: 42049 RVA: 0x001C55E0 File Offset: 0x001C37E0
		public XTaskDialog InprocessDialog
		{
			get
			{
				return this._GetDialog(1);
			}
		}

		// Token: 0x17002FC6 RID: 12230
		// (get) Token: 0x0600A442 RID: 42050 RVA: 0x001C55FC File Offset: 0x001C37FC
		public XTaskDialog EndDialog
		{
			get
			{
				return this._GetDialog(2);
			}
		}

		// Token: 0x0600A443 RID: 42051 RVA: 0x001C5618 File Offset: 0x001C3818
		public bool Init(TaskInfo info)
		{
			this.m_ID = info.id;
			this.m_Status = info.status;
			this.m_State = XTaskDocument.TaskStatus2TaskState(this.m_Status);
			this.m_Conditions.Clear();
			for (int i = 0; i < info.conds.Count; i++)
			{
				this.m_Conditions.Add(info.conds[i]);
			}
			this.m_TableData = XTaskDocument.GetTaskData(this.m_ID);
			for (int j = 0; j < this.m_Dialogs.Length; j++)
			{
				this.m_Dialogs[j] = null;
			}
			bool flag = this.m_TableData == null;
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Cant find config for task: ", this.m_ID.ToString(), null, null, null, null);
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600A444 RID: 42052 RVA: 0x001C56FC File Offset: 0x001C38FC
		private XTaskDialog _GetDialog(int index)
		{
			bool flag = index < 0 || index >= this.m_Dialogs.Length;
			XTaskDialog result;
			if (flag)
			{
				result = null;
			}
			else
			{
				XTaskDialog xtaskDialog = this.m_Dialogs[index];
				bool flag2 = xtaskDialog == null;
				if (flag2)
				{
					this._Load(XSingleton<XAttributeMgr>.singleton.XPlayerData.BasicTypeID);
				}
				xtaskDialog = this.m_Dialogs[index];
				result = xtaskDialog;
			}
			return result;
		}

		// Token: 0x0600A445 RID: 42053 RVA: 0x001C5760 File Offset: 0x001C3960
		private void _Load(uint prof)
		{
			string location = XSingleton<XCommon>.singleton.StringCombine("Table/Task/", this.ID.ToString());
			for (int i = 0; i < this.m_Dialogs.Length; i++)
			{
				this.m_Dialogs[i] = new XTaskDialog();
			}
			Stream stream = XSingleton<XResourceLoaderMgr>.singleton.ReadText(location, ".txt", true);
			StreamReader streamReader = new StreamReader(stream);
			XDialogSentence xdialogSentence = default(XDialogSentence);
			XTaskDialog dialog = null;
			bool flag = false;
			string value = prof.ToString();
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				bool flag2 = text.StartsWith("start");
				if (!flag2)
				{
					bool flag3 = text.Length == 0;
					if (!flag3)
					{
						bool flag4 = text.StartsWith("prof");
						if (flag4)
						{
							bool flag5 = flag;
							if (flag5)
							{
								break;
							}
							bool flag6 = text.EndsWith(value) || text.EndsWith("0");
							if (flag6)
							{
								flag = true;
							}
						}
						else
						{
							bool flag7 = !flag;
							if (!flag7)
							{
								bool flag8 = text.StartsWith("begin");
								if (flag8)
								{
									this._AppendPrevious(dialog, ref xdialogSentence);
									dialog = this.m_Dialogs[0];
								}
								else
								{
									bool flag9 = text.StartsWith("inprogress");
									if (flag9)
									{
										this._AppendPrevious(dialog, ref xdialogSentence);
										dialog = this.m_Dialogs[1];
									}
									else
									{
										bool flag10 = text.StartsWith("end");
										if (flag10)
										{
											this._AppendPrevious(dialog, ref xdialogSentence);
											dialog = this.m_Dialogs[2];
										}
										else
										{
											bool flag11 = text.Length == 1;
											if (flag11)
											{
												int talker;
												bool flag12 = int.TryParse(text, out talker);
												if (flag12)
												{
													this._AppendPrevious(dialog, ref xdialogSentence);
													xdialogSentence.Talker = talker;
													continue;
												}
											}
											bool flag13 = !xdialogSentence.Inited;
											if (!flag13)
											{
												bool flag14 = text.StartsWith("[voice]");
												if (flag14)
												{
													xdialogSentence.Voice = text.Substring("[voice]".Length);
												}
												else
												{
													bool flag15 = text.StartsWith("[can_reject]");
													if (flag15)
													{
														xdialogSentence.bCanReject = true;
													}
													else
													{
														xdialogSentence.Content = text;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			this._AppendPrevious(dialog, ref xdialogSentence);
			XSingleton<XResourceLoaderMgr>.singleton.ClearStream(stream);
		}

		// Token: 0x0600A446 RID: 42054 RVA: 0x001C59D0 File Offset: 0x001C3BD0
		private void _AppendPrevious(XTaskDialog dialog, ref XDialogSentence sentence)
		{
			bool flag = dialog != null;
			if (flag)
			{
				dialog.TryAppend(sentence);
			}
			sentence.Reset();
		}

		// Token: 0x17002FC7 RID: 12231
		// (get) Token: 0x0600A447 RID: 42055 RVA: 0x001C59FC File Offset: 0x001C3BFC
		public XTaskDialog CurDialog
		{
			get
			{
				XTaskDialog result;
				switch (this.Status)
				{
				case TaskStatus.TaskStatus_CanTake:
					result = this.BeginDialog;
					break;
				case TaskStatus.TaskStatus_Taked:
					result = this.InprocessDialog;
					break;
				case TaskStatus.TaskStatus_Finish:
					result = this.EndDialog;
					break;
				default:
					result = this.BeginDialog;
					break;
				}
				return result;
			}
		}

		// Token: 0x04003BA9 RID: 15273
		private uint m_ID;

		// Token: 0x04003BAA RID: 15274
		private TaskStatus m_Status;

		// Token: 0x04003BAB RID: 15275
		private NpcTaskState m_State;

		// Token: 0x04003BAC RID: 15276
		private List<TaskConditionInfo> m_Conditions = new List<TaskConditionInfo>();

		// Token: 0x04003BAD RID: 15277
		private TaskTableNew.RowData m_TableData;

		// Token: 0x04003BAE RID: 15278
		private XTaskDialog[] m_Dialogs = new XTaskDialog[3];
	}
}

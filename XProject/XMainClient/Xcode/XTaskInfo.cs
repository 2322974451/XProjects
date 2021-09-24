using System;
using System.Collections.Generic;
using System.IO;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTaskInfo
	{

		public uint ID
		{
			get
			{
				return this.m_ID;
			}
		}

		public TaskStatus Status
		{
			get
			{
				return this.m_Status;
			}
		}

		public NpcTaskState NpcState
		{
			get
			{
				return this.m_State;
			}
		}

		public List<TaskConditionInfo> Conds
		{
			get
			{
				return this.m_Conditions;
			}
		}

		public TaskTableNew.RowData TableData
		{
			get
			{
				return this.m_TableData;
			}
		}

		public XTaskDialog BeginDialog
		{
			get
			{
				return this._GetDialog(0);
			}
		}

		public XTaskDialog InprocessDialog
		{
			get
			{
				return this._GetDialog(1);
			}
		}

		public XTaskDialog EndDialog
		{
			get
			{
				return this._GetDialog(2);
			}
		}

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

		private void _AppendPrevious(XTaskDialog dialog, ref XDialogSentence sentence)
		{
			bool flag = dialog != null;
			if (flag)
			{
				dialog.TryAppend(sentence);
			}
			sentence.Reset();
		}

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

		private uint m_ID;

		private TaskStatus m_Status;

		private NpcTaskState m_State;

		private List<TaskConditionInfo> m_Conditions = new List<TaskConditionInfo>();

		private TaskTableNew.RowData m_TableData;

		private XTaskDialog[] m_Dialogs = new XTaskDialog[3];
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006D5 RID: 1749
	[ProtoContract(Name = "OneMentorTaskInfo")]
	[Serializable]
	public class OneMentorTaskInfo : IExtensible
	{
		// Token: 0x170024CC RID: 9420
		// (get) Token: 0x0600743A RID: 29754 RVA: 0x000DE64C File Offset: 0x000DC84C
		// (set) Token: 0x0600743B RID: 29755 RVA: 0x000DE678 File Offset: 0x000DC878
		[ProtoMember(1, IsRequired = false, Name = "taskID", DataFormat = DataFormat.TwosComplement)]
		public int taskID
		{
			get
			{
				return this._taskID ?? 0;
			}
			set
			{
				this._taskID = new int?(value);
			}
		}

		// Token: 0x170024CD RID: 9421
		// (get) Token: 0x0600743C RID: 29756 RVA: 0x000DE688 File Offset: 0x000DC888
		// (set) Token: 0x0600743D RID: 29757 RVA: 0x000DE6A8 File Offset: 0x000DC8A8
		[XmlIgnore]
		[Browsable(false)]
		public bool taskIDSpecified
		{
			get
			{
				return this._taskID != null;
			}
			set
			{
				bool flag = value == (this._taskID == null);
				if (flag)
				{
					this._taskID = (value ? new int?(this.taskID) : null);
				}
			}
		}

		// Token: 0x0600743E RID: 29758 RVA: 0x000DE6EC File Offset: 0x000DC8EC
		private bool ShouldSerializetaskID()
		{
			return this.taskIDSpecified;
		}

		// Token: 0x0600743F RID: 29759 RVA: 0x000DE704 File Offset: 0x000DC904
		private void ResettaskID()
		{
			this.taskIDSpecified = false;
		}

		// Token: 0x170024CE RID: 9422
		// (get) Token: 0x06007440 RID: 29760 RVA: 0x000DE710 File Offset: 0x000DC910
		// (set) Token: 0x06007441 RID: 29761 RVA: 0x000DE73C File Offset: 0x000DC93C
		[ProtoMember(2, IsRequired = false, Name = "completeProgress", DataFormat = DataFormat.TwosComplement)]
		public int completeProgress
		{
			get
			{
				return this._completeProgress ?? 0;
			}
			set
			{
				this._completeProgress = new int?(value);
			}
		}

		// Token: 0x170024CF RID: 9423
		// (get) Token: 0x06007442 RID: 29762 RVA: 0x000DE74C File Offset: 0x000DC94C
		// (set) Token: 0x06007443 RID: 29763 RVA: 0x000DE76C File Offset: 0x000DC96C
		[XmlIgnore]
		[Browsable(false)]
		public bool completeProgressSpecified
		{
			get
			{
				return this._completeProgress != null;
			}
			set
			{
				bool flag = value == (this._completeProgress == null);
				if (flag)
				{
					this._completeProgress = (value ? new int?(this.completeProgress) : null);
				}
			}
		}

		// Token: 0x06007444 RID: 29764 RVA: 0x000DE7B0 File Offset: 0x000DC9B0
		private bool ShouldSerializecompleteProgress()
		{
			return this.completeProgressSpecified;
		}

		// Token: 0x06007445 RID: 29765 RVA: 0x000DE7C8 File Offset: 0x000DC9C8
		private void ResetcompleteProgress()
		{
			this.completeProgressSpecified = false;
		}

		// Token: 0x170024D0 RID: 9424
		// (get) Token: 0x06007446 RID: 29766 RVA: 0x000DE7D4 File Offset: 0x000DC9D4
		// (set) Token: 0x06007447 RID: 29767 RVA: 0x000DE800 File Offset: 0x000DCA00
		[ProtoMember(3, IsRequired = false, Name = "completeTime", DataFormat = DataFormat.TwosComplement)]
		public int completeTime
		{
			get
			{
				return this._completeTime ?? 0;
			}
			set
			{
				this._completeTime = new int?(value);
			}
		}

		// Token: 0x170024D1 RID: 9425
		// (get) Token: 0x06007448 RID: 29768 RVA: 0x000DE810 File Offset: 0x000DCA10
		// (set) Token: 0x06007449 RID: 29769 RVA: 0x000DE830 File Offset: 0x000DCA30
		[XmlIgnore]
		[Browsable(false)]
		public bool completeTimeSpecified
		{
			get
			{
				return this._completeTime != null;
			}
			set
			{
				bool flag = value == (this._completeTime == null);
				if (flag)
				{
					this._completeTime = (value ? new int?(this.completeTime) : null);
				}
			}
		}

		// Token: 0x0600744A RID: 29770 RVA: 0x000DE874 File Offset: 0x000DCA74
		private bool ShouldSerializecompleteTime()
		{
			return this.completeTimeSpecified;
		}

		// Token: 0x0600744B RID: 29771 RVA: 0x000DE88C File Offset: 0x000DCA8C
		private void ResetcompleteTime()
		{
			this.completeTimeSpecified = false;
		}

		// Token: 0x170024D2 RID: 9426
		// (get) Token: 0x0600744C RID: 29772 RVA: 0x000DE898 File Offset: 0x000DCA98
		[ProtoMember(4, Name = "taskApplyStatus", DataFormat = DataFormat.Default)]
		public List<MapIntItem> taskApplyStatus
		{
			get
			{
				return this._taskApplyStatus;
			}
		}

		// Token: 0x170024D3 RID: 9427
		// (get) Token: 0x0600744D RID: 29773 RVA: 0x000DE8B0 File Offset: 0x000DCAB0
		// (set) Token: 0x0600744E RID: 29774 RVA: 0x000DE8DC File Offset: 0x000DCADC
		[ProtoMember(5, IsRequired = false, Name = "taskType", DataFormat = DataFormat.TwosComplement)]
		public uint taskType
		{
			get
			{
				return this._taskType ?? 0U;
			}
			set
			{
				this._taskType = new uint?(value);
			}
		}

		// Token: 0x170024D4 RID: 9428
		// (get) Token: 0x0600744F RID: 29775 RVA: 0x000DE8EC File Offset: 0x000DCAEC
		// (set) Token: 0x06007450 RID: 29776 RVA: 0x000DE90C File Offset: 0x000DCB0C
		[XmlIgnore]
		[Browsable(false)]
		public bool taskTypeSpecified
		{
			get
			{
				return this._taskType != null;
			}
			set
			{
				bool flag = value == (this._taskType == null);
				if (flag)
				{
					this._taskType = (value ? new uint?(this.taskType) : null);
				}
			}
		}

		// Token: 0x06007451 RID: 29777 RVA: 0x000DE950 File Offset: 0x000DCB50
		private bool ShouldSerializetaskType()
		{
			return this.taskTypeSpecified;
		}

		// Token: 0x06007452 RID: 29778 RVA: 0x000DE968 File Offset: 0x000DCB68
		private void ResettaskType()
		{
			this.taskTypeSpecified = false;
		}

		// Token: 0x170024D5 RID: 9429
		// (get) Token: 0x06007453 RID: 29779 RVA: 0x000DE974 File Offset: 0x000DCB74
		// (set) Token: 0x06007454 RID: 29780 RVA: 0x000DE9A1 File Offset: 0x000DCBA1
		[ProtoMember(6, IsRequired = false, Name = "taskVar", DataFormat = DataFormat.TwosComplement)]
		public ulong taskVar
		{
			get
			{
				return this._taskVar ?? 0UL;
			}
			set
			{
				this._taskVar = new ulong?(value);
			}
		}

		// Token: 0x170024D6 RID: 9430
		// (get) Token: 0x06007455 RID: 29781 RVA: 0x000DE9B0 File Offset: 0x000DCBB0
		// (set) Token: 0x06007456 RID: 29782 RVA: 0x000DE9D0 File Offset: 0x000DCBD0
		[XmlIgnore]
		[Browsable(false)]
		public bool taskVarSpecified
		{
			get
			{
				return this._taskVar != null;
			}
			set
			{
				bool flag = value == (this._taskVar == null);
				if (flag)
				{
					this._taskVar = (value ? new ulong?(this.taskVar) : null);
				}
			}
		}

		// Token: 0x06007457 RID: 29783 RVA: 0x000DEA14 File Offset: 0x000DCC14
		private bool ShouldSerializetaskVar()
		{
			return this.taskVarSpecified;
		}

		// Token: 0x06007458 RID: 29784 RVA: 0x000DEA2C File Offset: 0x000DCC2C
		private void ResettaskVar()
		{
			this.taskVarSpecified = false;
		}

		// Token: 0x06007459 RID: 29785 RVA: 0x000DEA38 File Offset: 0x000DCC38
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B9D RID: 7069
		private int? _taskID;

		// Token: 0x04001B9E RID: 7070
		private int? _completeProgress;

		// Token: 0x04001B9F RID: 7071
		private int? _completeTime;

		// Token: 0x04001BA0 RID: 7072
		private readonly List<MapIntItem> _taskApplyStatus = new List<MapIntItem>();

		// Token: 0x04001BA1 RID: 7073
		private uint? _taskType;

		// Token: 0x04001BA2 RID: 7074
		private ulong? _taskVar;

		// Token: 0x04001BA3 RID: 7075
		private IExtension extensionObject;
	}
}

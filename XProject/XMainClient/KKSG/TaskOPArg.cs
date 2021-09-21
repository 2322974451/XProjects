using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000022 RID: 34
	[ProtoContract(Name = "TaskOPArg")]
	[Serializable]
	public class TaskOPArg : IExtensible
	{
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000278 RID: 632 RVA: 0x000076C4 File Offset: 0x000058C4
		// (set) Token: 0x06000279 RID: 633 RVA: 0x000076F0 File Offset: 0x000058F0
		[ProtoMember(1, IsRequired = false, Name = "taskOP", DataFormat = DataFormat.TwosComplement)]
		public int taskOP
		{
			get
			{
				return this._taskOP ?? 0;
			}
			set
			{
				this._taskOP = new int?(value);
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600027A RID: 634 RVA: 0x00007700 File Offset: 0x00005900
		// (set) Token: 0x0600027B RID: 635 RVA: 0x00007720 File Offset: 0x00005920
		[XmlIgnore]
		[Browsable(false)]
		public bool taskOPSpecified
		{
			get
			{
				return this._taskOP != null;
			}
			set
			{
				bool flag = value == (this._taskOP == null);
				if (flag)
				{
					this._taskOP = (value ? new int?(this.taskOP) : null);
				}
			}
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00007764 File Offset: 0x00005964
		private bool ShouldSerializetaskOP()
		{
			return this.taskOPSpecified;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000777C File Offset: 0x0000597C
		private void ResettaskOP()
		{
			this.taskOPSpecified = false;
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600027E RID: 638 RVA: 0x00007788 File Offset: 0x00005988
		// (set) Token: 0x0600027F RID: 639 RVA: 0x000077B4 File Offset: 0x000059B4
		[ProtoMember(2, IsRequired = false, Name = "taskID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000280 RID: 640 RVA: 0x000077C4 File Offset: 0x000059C4
		// (set) Token: 0x06000281 RID: 641 RVA: 0x000077E4 File Offset: 0x000059E4
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

		// Token: 0x06000282 RID: 642 RVA: 0x00007828 File Offset: 0x00005A28
		private bool ShouldSerializetaskID()
		{
			return this.taskIDSpecified;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00007840 File Offset: 0x00005A40
		private void ResettaskID()
		{
			this.taskIDSpecified = false;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000784C File Offset: 0x00005A4C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000A9 RID: 169
		private int? _taskOP;

		// Token: 0x040000AA RID: 170
		private int? _taskID;

		// Token: 0x040000AB RID: 171
		private IExtension extensionObject;
	}
}

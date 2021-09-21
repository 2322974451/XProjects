using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000310 RID: 784
	[ProtoContract(Name = "MentorMyBeAppliedMsgArg")]
	[Serializable]
	public class MentorMyBeAppliedMsgArg : IExtensible
	{
		// Token: 0x17000D48 RID: 3400
		// (get) Token: 0x06002ADE RID: 10974 RVA: 0x000530F0 File Offset: 0x000512F0
		// (set) Token: 0x06002ADF RID: 10975 RVA: 0x0005311C File Offset: 0x0005131C
		[ProtoMember(1, IsRequired = false, Name = "operation", DataFormat = DataFormat.TwosComplement)]
		public EMentorMsgOpType operation
		{
			get
			{
				return this._operation ?? EMentorMsgOpType.EMentorMsgOp_Get;
			}
			set
			{
				this._operation = new EMentorMsgOpType?(value);
			}
		}

		// Token: 0x17000D49 RID: 3401
		// (get) Token: 0x06002AE0 RID: 10976 RVA: 0x0005312C File Offset: 0x0005132C
		// (set) Token: 0x06002AE1 RID: 10977 RVA: 0x0005314C File Offset: 0x0005134C
		[XmlIgnore]
		[Browsable(false)]
		public bool operationSpecified
		{
			get
			{
				return this._operation != null;
			}
			set
			{
				bool flag = value == (this._operation == null);
				if (flag)
				{
					this._operation = (value ? new EMentorMsgOpType?(this.operation) : null);
				}
			}
		}

		// Token: 0x06002AE2 RID: 10978 RVA: 0x00053190 File Offset: 0x00051390
		private bool ShouldSerializeoperation()
		{
			return this.operationSpecified;
		}

		// Token: 0x06002AE3 RID: 10979 RVA: 0x000531A8 File Offset: 0x000513A8
		private void Resetoperation()
		{
			this.operationSpecified = false;
		}

		// Token: 0x17000D4A RID: 3402
		// (get) Token: 0x06002AE4 RID: 10980 RVA: 0x000531B4 File Offset: 0x000513B4
		// (set) Token: 0x06002AE5 RID: 10981 RVA: 0x000531E1 File Offset: 0x000513E1
		[ProtoMember(2, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		// Token: 0x17000D4B RID: 3403
		// (get) Token: 0x06002AE6 RID: 10982 RVA: 0x000531F0 File Offset: 0x000513F0
		// (set) Token: 0x06002AE7 RID: 10983 RVA: 0x00053210 File Offset: 0x00051410
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		// Token: 0x06002AE8 RID: 10984 RVA: 0x00053254 File Offset: 0x00051454
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x06002AE9 RID: 10985 RVA: 0x0005326C File Offset: 0x0005146C
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x17000D4C RID: 3404
		// (get) Token: 0x06002AEA RID: 10986 RVA: 0x00053278 File Offset: 0x00051478
		// (set) Token: 0x06002AEB RID: 10987 RVA: 0x000532A4 File Offset: 0x000514A4
		[ProtoMember(3, IsRequired = false, Name = "msgType", DataFormat = DataFormat.TwosComplement)]
		public MentorMsgApplyType msgType
		{
			get
			{
				return this._msgType ?? MentorMsgApplyType.MentorMsgApplyMaster;
			}
			set
			{
				this._msgType = new MentorMsgApplyType?(value);
			}
		}

		// Token: 0x17000D4D RID: 3405
		// (get) Token: 0x06002AEC RID: 10988 RVA: 0x000532B4 File Offset: 0x000514B4
		// (set) Token: 0x06002AED RID: 10989 RVA: 0x000532D4 File Offset: 0x000514D4
		[XmlIgnore]
		[Browsable(false)]
		public bool msgTypeSpecified
		{
			get
			{
				return this._msgType != null;
			}
			set
			{
				bool flag = value == (this._msgType == null);
				if (flag)
				{
					this._msgType = (value ? new MentorMsgApplyType?(this.msgType) : null);
				}
			}
		}

		// Token: 0x06002AEE RID: 10990 RVA: 0x00053318 File Offset: 0x00051518
		private bool ShouldSerializemsgType()
		{
			return this.msgTypeSpecified;
		}

		// Token: 0x06002AEF RID: 10991 RVA: 0x00053330 File Offset: 0x00051530
		private void ResetmsgType()
		{
			this.msgTypeSpecified = false;
		}

		// Token: 0x17000D4E RID: 3406
		// (get) Token: 0x06002AF0 RID: 10992 RVA: 0x0005333C File Offset: 0x0005153C
		// (set) Token: 0x06002AF1 RID: 10993 RVA: 0x00053368 File Offset: 0x00051568
		[ProtoMember(4, IsRequired = false, Name = "taskID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000D4F RID: 3407
		// (get) Token: 0x06002AF2 RID: 10994 RVA: 0x00053378 File Offset: 0x00051578
		// (set) Token: 0x06002AF3 RID: 10995 RVA: 0x00053398 File Offset: 0x00051598
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

		// Token: 0x06002AF4 RID: 10996 RVA: 0x000533DC File Offset: 0x000515DC
		private bool ShouldSerializetaskID()
		{
			return this.taskIDSpecified;
		}

		// Token: 0x06002AF5 RID: 10997 RVA: 0x000533F4 File Offset: 0x000515F4
		private void ResettaskID()
		{
			this.taskIDSpecified = false;
		}

		// Token: 0x17000D50 RID: 3408
		// (get) Token: 0x06002AF6 RID: 10998 RVA: 0x00053400 File Offset: 0x00051600
		// (set) Token: 0x06002AF7 RID: 10999 RVA: 0x0005342C File Offset: 0x0005162C
		[ProtoMember(5, IsRequired = false, Name = "operatingAllTask", DataFormat = DataFormat.Default)]
		public bool operatingAllTask
		{
			get
			{
				return this._operatingAllTask ?? false;
			}
			set
			{
				this._operatingAllTask = new bool?(value);
			}
		}

		// Token: 0x17000D51 RID: 3409
		// (get) Token: 0x06002AF8 RID: 11000 RVA: 0x0005343C File Offset: 0x0005163C
		// (set) Token: 0x06002AF9 RID: 11001 RVA: 0x0005345C File Offset: 0x0005165C
		[XmlIgnore]
		[Browsable(false)]
		public bool operatingAllTaskSpecified
		{
			get
			{
				return this._operatingAllTask != null;
			}
			set
			{
				bool flag = value == (this._operatingAllTask == null);
				if (flag)
				{
					this._operatingAllTask = (value ? new bool?(this.operatingAllTask) : null);
				}
			}
		}

		// Token: 0x06002AFA RID: 11002 RVA: 0x000534A0 File Offset: 0x000516A0
		private bool ShouldSerializeoperatingAllTask()
		{
			return this.operatingAllTaskSpecified;
		}

		// Token: 0x06002AFB RID: 11003 RVA: 0x000534B8 File Offset: 0x000516B8
		private void ResetoperatingAllTask()
		{
			this.operatingAllTaskSpecified = false;
		}

		// Token: 0x06002AFC RID: 11004 RVA: 0x000534C4 File Offset: 0x000516C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AA4 RID: 2724
		private EMentorMsgOpType? _operation;

		// Token: 0x04000AA5 RID: 2725
		private ulong? _roleID;

		// Token: 0x04000AA6 RID: 2726
		private MentorMsgApplyType? _msgType;

		// Token: 0x04000AA7 RID: 2727
		private int? _taskID;

		// Token: 0x04000AA8 RID: 2728
		private bool? _operatingAllTask;

		// Token: 0x04000AA9 RID: 2729
		private IExtension extensionObject;
	}
}

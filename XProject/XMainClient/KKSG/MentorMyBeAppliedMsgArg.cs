using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MentorMyBeAppliedMsgArg")]
	[Serializable]
	public class MentorMyBeAppliedMsgArg : IExtensible
	{

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

		private bool ShouldSerializeoperation()
		{
			return this.operationSpecified;
		}

		private void Resetoperation()
		{
			this.operationSpecified = false;
		}

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

		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

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

		private bool ShouldSerializemsgType()
		{
			return this.msgTypeSpecified;
		}

		private void ResetmsgType()
		{
			this.msgTypeSpecified = false;
		}

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

		private bool ShouldSerializetaskID()
		{
			return this.taskIDSpecified;
		}

		private void ResettaskID()
		{
			this.taskIDSpecified = false;
		}

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

		private bool ShouldSerializeoperatingAllTask()
		{
			return this.operatingAllTaskSpecified;
		}

		private void ResetoperatingAllTask()
		{
			this.operatingAllTaskSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private EMentorMsgOpType? _operation;

		private ulong? _roleID;

		private MentorMsgApplyType? _msgType;

		private int? _taskID;

		private bool? _operatingAllTask;

		private IExtension extensionObject;
	}
}

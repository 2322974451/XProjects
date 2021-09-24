using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MentorRelationOpArg")]
	[Serializable]
	public class MentorRelationOpArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "operation", DataFormat = DataFormat.TwosComplement)]
		public MentorRelationOpType operation
		{
			get
			{
				return this._operation ?? MentorRelationOpType.MentorRelationOp_ApplyMaster;
			}
			set
			{
				this._operation = new MentorRelationOpType?(value);
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
					this._operation = (value ? new MentorRelationOpType?(this.operation) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "destRoleID", DataFormat = DataFormat.TwosComplement)]
		public ulong destRoleID
		{
			get
			{
				return this._destRoleID ?? 0UL;
			}
			set
			{
				this._destRoleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool destRoleIDSpecified
		{
			get
			{
				return this._destRoleID != null;
			}
			set
			{
				bool flag = value == (this._destRoleID == null);
				if (flag)
				{
					this._destRoleID = (value ? new ulong?(this.destRoleID) : null);
				}
			}
		}

		private bool ShouldSerializedestRoleID()
		{
			return this.destRoleIDSpecified;
		}

		private void ResetdestRoleID()
		{
			this.destRoleIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "reportTaskID", DataFormat = DataFormat.TwosComplement)]
		public int reportTaskID
		{
			get
			{
				return this._reportTaskID ?? 0;
			}
			set
			{
				this._reportTaskID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reportTaskIDSpecified
		{
			get
			{
				return this._reportTaskID != null;
			}
			set
			{
				bool flag = value == (this._reportTaskID == null);
				if (flag)
				{
					this._reportTaskID = (value ? new int?(this.reportTaskID) : null);
				}
			}
		}

		private bool ShouldSerializereportTaskID()
		{
			return this.reportTaskIDSpecified;
		}

		private void ResetreportTaskID()
		{
			this.reportTaskIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private MentorRelationOpType? _operation;

		private ulong? _destRoleID;

		private int? _reportTaskID;

		private IExtension extensionObject;
	}
}

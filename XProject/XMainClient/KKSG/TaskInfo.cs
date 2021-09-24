using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TaskInfo")]
	[Serializable]
	public class TaskInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		private void Resetid()
		{
			this.idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "status", DataFormat = DataFormat.TwosComplement)]
		public TaskStatus status
		{
			get
			{
				return this._status ?? TaskStatus.TaskStatus_CanTake;
			}
			set
			{
				this._status = new TaskStatus?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool statusSpecified
		{
			get
			{
				return this._status != null;
			}
			set
			{
				bool flag = value == (this._status == null);
				if (flag)
				{
					this._status = (value ? new TaskStatus?(this.status) : null);
				}
			}
		}

		private bool ShouldSerializestatus()
		{
			return this.statusSpecified;
		}

		private void Resetstatus()
		{
			this.statusSpecified = false;
		}

		[ProtoMember(3, Name = "conds", DataFormat = DataFormat.Default)]
		public List<TaskConditionInfo> conds
		{
			get
			{
				return this._conds;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _id;

		private TaskStatus? _status;

		private readonly List<TaskConditionInfo> _conds = new List<TaskConditionInfo>();

		private IExtension extensionObject;
	}
}

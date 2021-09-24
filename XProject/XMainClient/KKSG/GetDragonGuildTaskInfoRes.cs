using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetDragonGuildTaskInfoRes")]
	[Serializable]
	public class GetDragonGuildTaskInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public uint exp
		{
			get
			{
				return this._exp ?? 0U;
			}
			set
			{
				this._exp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new uint?(this.exp) : null);
				}
			}
		}

		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		private void Resetexp()
		{
			this.expSpecified = false;
		}

		[ProtoMember(3, Name = "taskrecord", DataFormat = DataFormat.Default)]
		public List<DragonGuildTaskInfo> taskrecord
		{
			get
			{
				return this._taskrecord;
			}
		}

		[ProtoMember(4, Name = "taskcompleted", DataFormat = DataFormat.Default)]
		public List<bool> taskcompleted
		{
			get
			{
				return this._taskcompleted;
			}
		}

		[ProtoMember(5, Name = "achiverecord", DataFormat = DataFormat.Default)]
		public List<DragonGuildTaskInfo> achiverecord
		{
			get
			{
				return this._achiverecord;
			}
		}

		[ProtoMember(6, Name = "achivecompleted", DataFormat = DataFormat.Default)]
		public List<bool> achivecompleted
		{
			get
			{
				return this._achivecompleted;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "task_refreshtime", DataFormat = DataFormat.Default)]
		public string task_refreshtime
		{
			get
			{
				return this._task_refreshtime ?? "";
			}
			set
			{
				this._task_refreshtime = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool task_refreshtimeSpecified
		{
			get
			{
				return this._task_refreshtime != null;
			}
			set
			{
				bool flag = value == (this._task_refreshtime == null);
				if (flag)
				{
					this._task_refreshtime = (value ? this.task_refreshtime : null);
				}
			}
		}

		private bool ShouldSerializetask_refreshtime()
		{
			return this.task_refreshtimeSpecified;
		}

		private void Resettask_refreshtime()
		{
			this.task_refreshtimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private uint? _exp;

		private readonly List<DragonGuildTaskInfo> _taskrecord = new List<DragonGuildTaskInfo>();

		private readonly List<bool> _taskcompleted = new List<bool>();

		private readonly List<DragonGuildTaskInfo> _achiverecord = new List<DragonGuildTaskInfo>();

		private readonly List<bool> _achivecompleted = new List<bool>();

		private string _task_refreshtime;

		private IExtension extensionObject;
	}
}

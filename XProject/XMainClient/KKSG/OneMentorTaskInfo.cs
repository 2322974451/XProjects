using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OneMentorTaskInfo")]
	[Serializable]
	public class OneMentorTaskInfo : IExtensible
	{

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

		private bool ShouldSerializecompleteProgress()
		{
			return this.completeProgressSpecified;
		}

		private void ResetcompleteProgress()
		{
			this.completeProgressSpecified = false;
		}

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

		private bool ShouldSerializecompleteTime()
		{
			return this.completeTimeSpecified;
		}

		private void ResetcompleteTime()
		{
			this.completeTimeSpecified = false;
		}

		[ProtoMember(4, Name = "taskApplyStatus", DataFormat = DataFormat.Default)]
		public List<MapIntItem> taskApplyStatus
		{
			get
			{
				return this._taskApplyStatus;
			}
		}

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

		private bool ShouldSerializetaskType()
		{
			return this.taskTypeSpecified;
		}

		private void ResettaskType()
		{
			this.taskTypeSpecified = false;
		}

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

		private bool ShouldSerializetaskVar()
		{
			return this.taskVarSpecified;
		}

		private void ResettaskVar()
		{
			this.taskVarSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _taskID;

		private int? _completeProgress;

		private int? _completeTime;

		private readonly List<MapIntItem> _taskApplyStatus = new List<MapIntItem>();

		private uint? _taskType;

		private ulong? _taskVar;

		private IExtension extensionObject;
	}
}

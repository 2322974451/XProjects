using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TaskOPArg")]
	[Serializable]
	public class TaskOPArg : IExtensible
	{

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

		private bool ShouldSerializetaskOP()
		{
			return this.taskOPSpecified;
		}

		private void ResettaskOP()
		{
			this.taskOPSpecified = false;
		}

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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _taskOP;

		private int? _taskID;

		private IExtension extensionObject;
	}
}

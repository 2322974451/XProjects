using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CampTaskInfo")]
	[Serializable]
	public class CampTaskInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "taskID", DataFormat = DataFormat.TwosComplement)]
		public uint taskID
		{
			get
			{
				return this._taskID ?? 0U;
			}
			set
			{
				this._taskID = new uint?(value);
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
					this._taskID = (value ? new uint?(this.taskID) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "taskStatus", DataFormat = DataFormat.TwosComplement)]
		public int taskStatus
		{
			get
			{
				return this._taskStatus ?? 0;
			}
			set
			{
				this._taskStatus = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool taskStatusSpecified
		{
			get
			{
				return this._taskStatus != null;
			}
			set
			{
				bool flag = value == (this._taskStatus == null);
				if (flag)
				{
					this._taskStatus = (value ? new int?(this.taskStatus) : null);
				}
			}
		}

		private bool ShouldSerializetaskStatus()
		{
			return this.taskStatusSpecified;
		}

		private void ResettaskStatus()
		{
			this.taskStatusSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _taskID;

		private int? _taskStatus;

		private IExtension extensionObject;
	}
}

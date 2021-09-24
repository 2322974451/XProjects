using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonGuildTaskInfo")]
	[Serializable]
	public class DragonGuildTaskInfo : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "finishCount", DataFormat = DataFormat.TwosComplement)]
		public uint finishCount
		{
			get
			{
				return this._finishCount ?? 0U;
			}
			set
			{
				this._finishCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool finishCountSpecified
		{
			get
			{
				return this._finishCount != null;
			}
			set
			{
				bool flag = value == (this._finishCount == null);
				if (flag)
				{
					this._finishCount = (value ? new uint?(this.finishCount) : null);
				}
			}
		}

		private bool ShouldSerializefinishCount()
		{
			return this.finishCountSpecified;
		}

		private void ResetfinishCount()
		{
			this.finishCountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "receiveCount", DataFormat = DataFormat.TwosComplement)]
		public uint receiveCount
		{
			get
			{
				return this._receiveCount ?? 0U;
			}
			set
			{
				this._receiveCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool receiveCountSpecified
		{
			get
			{
				return this._receiveCount != null;
			}
			set
			{
				bool flag = value == (this._receiveCount == null);
				if (flag)
				{
					this._receiveCount = (value ? new uint?(this.receiveCount) : null);
				}
			}
		}

		private bool ShouldSerializereceiveCount()
		{
			return this.receiveCountSpecified;
		}

		private void ResetreceiveCount()
		{
			this.receiveCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _taskID;

		private uint? _finishCount;

		private uint? _receiveCount;

		private IExtension extensionObject;
	}
}

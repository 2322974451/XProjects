using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonGuildRoleTaskItem")]
	[Serializable]
	public class DragonGuildRoleTaskItem : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "taskid", DataFormat = DataFormat.TwosComplement)]
		public uint taskid
		{
			get
			{
				return this._taskid ?? 0U;
			}
			set
			{
				this._taskid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool taskidSpecified
		{
			get
			{
				return this._taskid != null;
			}
			set
			{
				bool flag = value == (this._taskid == null);
				if (flag)
				{
					this._taskid = (value ? new uint?(this.taskid) : null);
				}
			}
		}

		private bool ShouldSerializetaskid()
		{
			return this.taskidSpecified;
		}

		private void Resettaskid()
		{
			this.taskidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "received", DataFormat = DataFormat.Default)]
		public bool received
		{
			get
			{
				return this._received ?? false;
			}
			set
			{
				this._received = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool receivedSpecified
		{
			get
			{
				return this._received != null;
			}
			set
			{
				bool flag = value == (this._received == null);
				if (flag)
				{
					this._received = (value ? new bool?(this.received) : null);
				}
			}
		}

		private bool ShouldSerializereceived()
		{
			return this.receivedSpecified;
		}

		private void Resetreceived()
		{
			this.receivedSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _taskid;

		private bool? _received;

		private IExtension extensionObject;
	}
}

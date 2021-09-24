using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "randomtask")]
	[Serializable]
	public class randomtask : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "taskid", DataFormat = DataFormat.TwosComplement)]
		public int taskid
		{
			get
			{
				return this._taskid ?? 0;
			}
			set
			{
				this._taskid = new int?(value);
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
					this._taskid = (value ? new int?(this.taskid) : null);
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _taskid;

		private IExtension extensionObject;
	}
}

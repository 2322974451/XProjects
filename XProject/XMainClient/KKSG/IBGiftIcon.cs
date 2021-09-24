using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "IBGiftIcon")]
	[Serializable]
	public class IBGiftIcon : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "status", DataFormat = DataFormat.Default)]
		public bool status
		{
			get
			{
				return this._status ?? false;
			}
			set
			{
				this._status = new bool?(value);
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
					this._status = (value ? new bool?(this.status) : null);
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _status;

		private IExtension extensionObject;
	}
}

using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CancelRedDot")]
	[Serializable]
	public class CancelRedDot : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "systemid", DataFormat = DataFormat.TwosComplement)]
		public uint systemid
		{
			get
			{
				return this._systemid ?? 0U;
			}
			set
			{
				this._systemid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool systemidSpecified
		{
			get
			{
				return this._systemid != null;
			}
			set
			{
				bool flag = value == (this._systemid == null);
				if (flag)
				{
					this._systemid = (value ? new uint?(this.systemid) : null);
				}
			}
		}

		private bool ShouldSerializesystemid()
		{
			return this.systemidSpecified;
		}

		private void Resetsystemid()
		{
			this.systemidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _systemid;

		private IExtension extensionObject;
	}
}

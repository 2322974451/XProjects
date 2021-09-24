using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PkTimeoutNtf")]
	[Serializable]
	public class PkTimeoutNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "timeout", DataFormat = DataFormat.TwosComplement)]
		public uint timeout
		{
			get
			{
				return this._timeout ?? 0U;
			}
			set
			{
				this._timeout = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeoutSpecified
		{
			get
			{
				return this._timeout != null;
			}
			set
			{
				bool flag = value == (this._timeout == null);
				if (flag)
				{
					this._timeout = (value ? new uint?(this.timeout) : null);
				}
			}
		}

		private bool ShouldSerializetimeout()
		{
			return this.timeoutSpecified;
		}

		private void Resettimeout()
		{
			this.timeoutSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _timeout;

		private IExtension extensionObject;
	}
}

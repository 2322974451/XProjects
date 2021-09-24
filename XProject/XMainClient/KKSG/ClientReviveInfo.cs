using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ClientReviveInfo")]
	[Serializable]
	public class ClientReviveInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "islimit", DataFormat = DataFormat.Default)]
		public bool islimit
		{
			get
			{
				return this._islimit ?? false;
			}
			set
			{
				this._islimit = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool islimitSpecified
		{
			get
			{
				return this._islimit != null;
			}
			set
			{
				bool flag = value == (this._islimit == null);
				if (flag)
				{
					this._islimit = (value ? new bool?(this.islimit) : null);
				}
			}
		}

		private bool ShouldSerializeislimit()
		{
			return this.islimitSpecified;
		}

		private void Resetislimit()
		{
			this.islimitSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _islimit;

		private IExtension extensionObject;
	}
}

using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ClientUpdatePackageData")]
	[Serializable]
	public class ClientUpdatePackageData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "version", DataFormat = DataFormat.Default)]
		public string version
		{
			get
			{
				return this._version ?? "";
			}
			set
			{
				this._version = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool versionSpecified
		{
			get
			{
				return this._version != null;
			}
			set
			{
				bool flag = value == (this._version == null);
				if (flag)
				{
					this._version = (value ? this.version : null);
				}
			}
		}

		private bool ShouldSerializeversion()
		{
			return this.versionSpecified;
		}

		private void Resetversion()
		{
			this.versionSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _version;

		private IExtension extensionObject;
	}
}

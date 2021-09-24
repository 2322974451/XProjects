using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SelfServerData")]
	[Serializable]
	public class SelfServerData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "servers", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LoginGateData servers
		{
			get
			{
				return this._servers;
			}
			set
			{
				this._servers = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private LoginGateData _servers = null;

		private uint? _level;

		private IExtension extensionObject;
	}
}

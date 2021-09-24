using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GmfHalfRoles")]
	[Serializable]
	public class GmfHalfRoles : IExtensible
	{

		[ProtoMember(1, Name = "roles", DataFormat = DataFormat.Default)]
		public List<GmfRole> roles
		{
			get
			{
				return this._roles;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "guildb", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief guildb
		{
			get
			{
				return this._guildb;
			}
			set
			{
				this._guildb = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "inspire", DataFormat = DataFormat.TwosComplement)]
		public uint inspire
		{
			get
			{
				return this._inspire ?? 0U;
			}
			set
			{
				this._inspire = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool inspireSpecified
		{
			get
			{
				return this._inspire != null;
			}
			set
			{
				bool flag = value == (this._inspire == null);
				if (flag)
				{
					this._inspire = (value ? new uint?(this.inspire) : null);
				}
			}
		}

		private bool ShouldSerializeinspire()
		{
			return this.inspireSpecified;
		}

		private void Resetinspire()
		{
			this.inspireSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<GmfRole> _roles = new List<GmfRole>();

		private GmfGuildBrief _guildb = null;

		private uint? _inspire;

		private IExtension extensionObject;
	}
}

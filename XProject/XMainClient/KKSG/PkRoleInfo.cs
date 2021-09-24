using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PkRoleInfo")]
	[Serializable]
	public class PkRoleInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "pkrec", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkRoleRec pkrec
		{
			get
			{
				return this._pkrec;
			}
			set
			{
				this._pkrec = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "rolebrief", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleSmallInfo rolebrief
		{
			get
			{
				return this._rolebrief;
			}
			set
			{
				this._rolebrief = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public uint serverid
		{
			get
			{
				return this._serverid ?? 0U;
			}
			set
			{
				this._serverid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool serveridSpecified
		{
			get
			{
				return this._serverid != null;
			}
			set
			{
				bool flag = value == (this._serverid == null);
				if (flag)
				{
					this._serverid = (value ? new uint?(this.serverid) : null);
				}
			}
		}

		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private PkRoleRec _pkrec = null;

		private RoleSmallInfo _rolebrief = null;

		private uint? _serverid;

		private IExtension extensionObject;
	}
}

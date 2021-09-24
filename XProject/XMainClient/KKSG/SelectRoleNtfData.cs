using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SelectRoleNtfData")]
	[Serializable]
	public class SelectRoleNtfData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleData", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleAllInfo roleData
		{
			get
			{
				return this._roleData;
			}
			set
			{
				this._roleData = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "backflow_firstenter", DataFormat = DataFormat.Default)]
		public bool backflow_firstenter
		{
			get
			{
				return this._backflow_firstenter ?? false;
			}
			set
			{
				this._backflow_firstenter = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool backflow_firstenterSpecified
		{
			get
			{
				return this._backflow_firstenter != null;
			}
			set
			{
				bool flag = value == (this._backflow_firstenter == null);
				if (flag)
				{
					this._backflow_firstenter = (value ? new bool?(this.backflow_firstenter) : null);
				}
			}
		}

		private bool ShouldSerializebackflow_firstenter()
		{
			return this.backflow_firstenterSpecified;
		}

		private void Resetbackflow_firstenter()
		{
			this.backflow_firstenterSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private RoleAllInfo _roleData = null;

		private uint? _serverid;

		private bool? _backflow_firstenter;

		private IExtension extensionObject;
	}
}

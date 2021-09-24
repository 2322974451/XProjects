using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReconnArg")]
	[Serializable]
	public class ReconnArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "session", DataFormat = DataFormat.TwosComplement)]
		public ulong session
		{
			get
			{
				return this._session ?? 0UL;
			}
			set
			{
				this._session = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sessionSpecified
		{
			get
			{
				return this._session != null;
			}
			set
			{
				bool flag = value == (this._session == null);
				if (flag)
				{
					this._session = (value ? new ulong?(this.session) : null);
				}
			}
		}

		private bool ShouldSerializesession()
		{
			return this.sessionSpecified;
		}

		private void Resetsession()
		{
			this.sessionSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public uint sceneid
		{
			get
			{
				return this._sceneid ?? 0U;
			}
			set
			{
				this._sceneid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneidSpecified
		{
			get
			{
				return this._sceneid != null;
			}
			set
			{
				bool flag = value == (this._sceneid == null);
				if (flag)
				{
					this._sceneid = (value ? new uint?(this.sceneid) : null);
				}
			}
		}

		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _session;

		private uint? _sceneid;

		private ulong? _roleid;

		private IExtension extensionObject;
	}
}

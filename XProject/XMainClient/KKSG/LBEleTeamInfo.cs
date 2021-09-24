using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LBEleTeamInfo")]
	[Serializable]
	public class LBEleTeamInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "leagueid", DataFormat = DataFormat.TwosComplement)]
		public ulong leagueid
		{
			get
			{
				return this._leagueid ?? 0UL;
			}
			set
			{
				this._leagueid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leagueidSpecified
		{
			get
			{
				return this._leagueid != null;
			}
			set
			{
				bool flag = value == (this._leagueid == null);
				if (flag)
				{
					this._leagueid = (value ? new ulong?(this.leagueid) : null);
				}
			}
		}

		private bool ShouldSerializeleagueid()
		{
			return this.leagueidSpecified;
		}

		private void Resetleagueid()
		{
			this.leagueidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
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

		[ProtoMember(4, IsRequired = false, Name = "servername", DataFormat = DataFormat.Default)]
		public string servername
		{
			get
			{
				return this._servername ?? "";
			}
			set
			{
				this._servername = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool servernameSpecified
		{
			get
			{
				return this._servername != null;
			}
			set
			{
				bool flag = value == (this._servername == null);
				if (flag)
				{
					this._servername = (value ? this.servername : null);
				}
			}
		}

		private bool ShouldSerializeservername()
		{
			return this.servernameSpecified;
		}

		private void Resetservername()
		{
			this.servernameSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "zonename", DataFormat = DataFormat.Default)]
		public string zonename
		{
			get
			{
				return this._zonename ?? "";
			}
			set
			{
				this._zonename = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool zonenameSpecified
		{
			get
			{
				return this._zonename != null;
			}
			set
			{
				bool flag = value == (this._zonename == null);
				if (flag)
				{
					this._zonename = (value ? this.zonename : null);
				}
			}
		}

		private bool ShouldSerializezonename()
		{
			return this.zonenameSpecified;
		}

		private void Resetzonename()
		{
			this.zonenameSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _leagueid;

		private string _name;

		private uint? _serverid;

		private string _servername;

		private string _zonename;

		private IExtension extensionObject;
	}
}

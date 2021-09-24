using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GCFG2CSynPara")]
	[Serializable]
	public class GCFG2CSynPara : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public GCFG2CSynType type
		{
			get
			{
				return this._type ?? GCFG2CSynType.GCF_G2C_SYN_KILL_ONE;
			}
			set
			{
				this._type = new GCFG2CSynType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new GCFG2CSynType?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "killcount", DataFormat = DataFormat.TwosComplement)]
		public uint killcount
		{
			get
			{
				return this._killcount ?? 0U;
			}
			set
			{
				this._killcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killcountSpecified
		{
			get
			{
				return this._killcount != null;
			}
			set
			{
				bool flag = value == (this._killcount == null);
				if (flag)
				{
					this._killcount = (value ? new uint?(this.killcount) : null);
				}
			}
		}

		private bool ShouldSerializekillcount()
		{
			return this.killcountSpecified;
		}

		private void Resetkillcount()
		{
			this.killcountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "killname", DataFormat = DataFormat.Default)]
		public string killname
		{
			get
			{
				return this._killname ?? "";
			}
			set
			{
				this._killname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killnameSpecified
		{
			get
			{
				return this._killname != null;
			}
			set
			{
				bool flag = value == (this._killname == null);
				if (flag)
				{
					this._killname = (value ? this.killname : null);
				}
			}
		}

		private bool ShouldSerializekillname()
		{
			return this.killnameSpecified;
		}

		private void Resetkillname()
		{
			this.killnameSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "deadname", DataFormat = DataFormat.Default)]
		public string deadname
		{
			get
			{
				return this._deadname ?? "";
			}
			set
			{
				this._deadname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool deadnameSpecified
		{
			get
			{
				return this._deadname != null;
			}
			set
			{
				bool flag = value == (this._deadname == null);
				if (flag)
				{
					this._deadname = (value ? this.deadname : null);
				}
			}
		}

		private bool ShouldSerializedeadname()
		{
			return this.deadnameSpecified;
		}

		private void Resetdeadname()
		{
			this.deadnameSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "mapid", DataFormat = DataFormat.TwosComplement)]
		public uint mapid
		{
			get
			{
				return this._mapid ?? 0U;
			}
			set
			{
				this._mapid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mapidSpecified
		{
			get
			{
				return this._mapid != null;
			}
			set
			{
				bool flag = value == (this._mapid == null);
				if (flag)
				{
					this._mapid = (value ? new uint?(this.mapid) : null);
				}
			}
		}

		private bool ShouldSerializemapid()
		{
			return this.mapidSpecified;
		}

		private void Resetmapid()
		{
			this.mapidSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "mulpoint", DataFormat = DataFormat.TwosComplement)]
		public uint mulpoint
		{
			get
			{
				return this._mulpoint ?? 0U;
			}
			set
			{
				this._mulpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mulpointSpecified
		{
			get
			{
				return this._mulpoint != null;
			}
			set
			{
				bool flag = value == (this._mulpoint == null);
				if (flag)
				{
					this._mulpoint = (value ? new uint?(this.mulpoint) : null);
				}
			}
		}

		private bool ShouldSerializemulpoint()
		{
			return this.mulpointSpecified;
		}

		private void Resetmulpoint()
		{
			this.mulpointSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "jvdian", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GCFJvDianInfo jvdian
		{
			get
			{
				return this._jvdian;
			}
			set
			{
				this._jvdian = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "territoryid", DataFormat = DataFormat.TwosComplement)]
		public uint territoryid
		{
			get
			{
				return this._territoryid ?? 0U;
			}
			set
			{
				this._territoryid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool territoryidSpecified
		{
			get
			{
				return this._territoryid != null;
			}
			set
			{
				bool flag = value == (this._territoryid == null);
				if (flag)
				{
					this._territoryid = (value ? new uint?(this.territoryid) : null);
				}
			}
		}

		private bool ShouldSerializeterritoryid()
		{
			return this.territoryidSpecified;
		}

		private void Resetterritoryid()
		{
			this.territoryidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GCFG2CSynType? _type;

		private ulong? _roleid;

		private uint? _killcount;

		private string _killname;

		private string _deadname;

		private uint? _mapid;

		private uint? _mulpoint;

		private GCFJvDianInfo _jvdian = null;

		private uint? _territoryid;

		private IExtension extensionObject;
	}
}

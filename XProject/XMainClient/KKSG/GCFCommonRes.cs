using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GCFCommonRes")]
	[Serializable]
	public class GCFCommonRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(2, Name = "jvdians", DataFormat = DataFormat.Default)]
		public List<GCFJvDianInfo> jvdians
		{
			get
			{
				return this._jvdians;
			}
		}

		[ProtoMember(3, Name = "guilds", DataFormat = DataFormat.Default)]
		public List<GCFGuildBrief> guilds
		{
			get
			{
				return this._guilds;
			}
		}

		[ProtoMember(4, Name = "roles", DataFormat = DataFormat.Default)]
		public List<GCFRoleBrief> roles
		{
			get
			{
				return this._roles;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "myinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GCFRoleBrief myinfo
		{
			get
			{
				return this._myinfo;
			}
			set
			{
				this._myinfo = value;
			}
		}

		[ProtoMember(6, Name = "rewards", DataFormat = DataFormat.Default)]
		public List<ItemBrief> rewards
		{
			get
			{
				return this._rewards;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "territoryid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(8, IsRequired = false, Name = "winguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GCFGuildBrief winguild
		{
			get
			{
				return this._winguild;
			}
			set
			{
				this._winguild = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		[ProtoMember(10, Name = "fields", DataFormat = DataFormat.Default)]
		public List<GCFBattleField> fields
		{
			get
			{
				return this._fields;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private readonly List<GCFJvDianInfo> _jvdians = new List<GCFJvDianInfo>();

		private readonly List<GCFGuildBrief> _guilds = new List<GCFGuildBrief>();

		private readonly List<GCFRoleBrief> _roles = new List<GCFRoleBrief>();

		private GCFRoleBrief _myinfo = null;

		private readonly List<ItemBrief> _rewards = new List<ItemBrief>();

		private uint? _territoryid;

		private GCFGuildBrief _winguild = null;

		private uint? _lefttime;

		private readonly List<GCFBattleField> _fields = new List<GCFBattleField>();

		private IExtension extensionObject;
	}
}

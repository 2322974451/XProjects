using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QueryGateRes")]
	[Serializable]
	public class QueryGateRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "loginToken", DataFormat = DataFormat.Default)]
		public byte[] loginToken
		{
			get
			{
				return this._loginToken ?? null;
			}
			set
			{
				this._loginToken = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool loginTokenSpecified
		{
			get
			{
				return this._loginToken != null;
			}
			set
			{
				bool flag = value == (this._loginToken == null);
				if (flag)
				{
					this._loginToken = (value ? this.loginToken : null);
				}
			}
		}

		private bool ShouldSerializeloginToken()
		{
			return this.loginTokenSpecified;
		}

		private void ResetloginToken()
		{
			this.loginTokenSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "gateconfig", DataFormat = DataFormat.Default)]
		public byte[] gateconfig
		{
			get
			{
				return this._gateconfig ?? null;
			}
			set
			{
				this._gateconfig = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool gateconfigSpecified
		{
			get
			{
				return this._gateconfig != null;
			}
			set
			{
				bool flag = value == (this._gateconfig == null);
				if (flag)
				{
					this._gateconfig = (value ? this.gateconfig : null);
				}
			}
		}

		private bool ShouldSerializegateconfig()
		{
			return this.gateconfigSpecified;
		}

		private void Resetgateconfig()
		{
			this.gateconfigSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "userphone", DataFormat = DataFormat.Default)]
		public string userphone
		{
			get
			{
				return this._userphone ?? "";
			}
			set
			{
				this._userphone = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool userphoneSpecified
		{
			get
			{
				return this._userphone != null;
			}
			set
			{
				bool flag = value == (this._userphone == null);
				if (flag)
				{
					this._userphone = (value ? this.userphone : null);
				}
			}
		}

		private bool ShouldSerializeuserphone()
		{
			return this.userphoneSpecified;
		}

		private void Resetuserphone()
		{
			this.userphoneSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "RecommandGate", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LoginGateData RecommandGate
		{
			get
			{
				return this._RecommandGate;
			}
			set
			{
				this._RecommandGate = value;
			}
		}

		[ProtoMember(5, Name = "servers", DataFormat = DataFormat.Default)]
		public List<SelfServerData> servers
		{
			get
			{
				return this._servers;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "loginzoneid", DataFormat = DataFormat.TwosComplement)]
		public uint loginzoneid
		{
			get
			{
				return this._loginzoneid ?? 0U;
			}
			set
			{
				this._loginzoneid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool loginzoneidSpecified
		{
			get
			{
				return this._loginzoneid != null;
			}
			set
			{
				bool flag = value == (this._loginzoneid == null);
				if (flag)
				{
					this._loginzoneid = (value ? new uint?(this.loginzoneid) : null);
				}
			}
		}

		private bool ShouldSerializeloginzoneid()
		{
			return this.loginzoneidSpecified;
		}

		private void Resetloginzoneid()
		{
			this.loginzoneidSpecified = false;
		}

		[ProtoMember(7, Name = "allservers", DataFormat = DataFormat.Default)]
		public List<LoginGateData> allservers
		{
			get
			{
				return this._allservers;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "in_white_list", DataFormat = DataFormat.Default)]
		public bool in_white_list
		{
			get
			{
				return this._in_white_list ?? false;
			}
			set
			{
				this._in_white_list = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool in_white_listSpecified
		{
			get
			{
				return this._in_white_list != null;
			}
			set
			{
				bool flag = value == (this._in_white_list == null);
				if (flag)
				{
					this._in_white_list = (value ? new bool?(this.in_white_list) : null);
				}
			}
		}

		private bool ShouldSerializein_white_list()
		{
			return this.in_white_listSpecified;
		}

		private void Resetin_white_list()
		{
			this.in_white_listSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "notice", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PlatNotice notice
		{
			get
			{
				return this._notice;
			}
			set
			{
				this._notice = value;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "baninfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PlatBanAccount baninfo
		{
			get
			{
				return this._baninfo;
			}
			set
			{
				this._baninfo = value;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "freeflow", DataFormat = DataFormat.Default)]
		public bool freeflow
		{
			get
			{
				return this._freeflow ?? false;
			}
			set
			{
				this._freeflow = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool freeflowSpecified
		{
			get
			{
				return this._freeflow != null;
			}
			set
			{
				bool flag = value == (this._freeflow == null);
				if (flag)
				{
					this._freeflow = (value ? new bool?(this.freeflow) : null);
				}
			}
		}

		private bool ShouldSerializefreeflow()
		{
			return this.freeflowSpecified;
		}

		private void Resetfreeflow()
		{
			this.freeflowSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "cctype", DataFormat = DataFormat.TwosComplement)]
		public int cctype
		{
			get
			{
				return this._cctype ?? 0;
			}
			set
			{
				this._cctype = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cctypeSpecified
		{
			get
			{
				return this._cctype != null;
			}
			set
			{
				bool flag = value == (this._cctype == null);
				if (flag)
				{
					this._cctype = (value ? new int?(this.cctype) : null);
				}
			}
		}

		private bool ShouldSerializecctype()
		{
			return this.cctypeSpecified;
		}

		private void Resetcctype()
		{
			this.cctypeSpecified = false;
		}

		[ProtoMember(14, Name = "platFriendServers", DataFormat = DataFormat.Default)]
		public List<PlatFriendServer> platFriendServers
		{
			get
			{
				return this._platFriendServers;
			}
		}

		[ProtoMember(15, Name = "bespeakserverids", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bespeakserverids
		{
			get
			{
				return this._bespeakserverids;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private byte[] _loginToken;

		private byte[] _gateconfig;

		private string _userphone;

		private LoginGateData _RecommandGate = null;

		private readonly List<SelfServerData> _servers = new List<SelfServerData>();

		private uint? _loginzoneid;

		private readonly List<LoginGateData> _allservers = new List<LoginGateData>();

		private bool? _in_white_list;

		private PlatNotice _notice = null;

		private ErrorCode? _error;

		private PlatBanAccount _baninfo = null;

		private bool? _freeflow;

		private int? _cctype;

		private readonly List<PlatFriendServer> _platFriendServers = new List<PlatFriendServer>();

		private readonly List<uint> _bespeakserverids = new List<uint>();

		private IExtension extensionObject;
	}
}

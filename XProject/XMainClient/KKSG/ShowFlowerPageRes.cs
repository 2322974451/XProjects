using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ShowFlowerPageRes")]
	[Serializable]
	public class ShowFlowerPageRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "allcount", DataFormat = DataFormat.TwosComplement)]
		public uint allcount
		{
			get
			{
				return this._allcount ?? 0U;
			}
			set
			{
				this._allcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool allcountSpecified
		{
			get
			{
				return this._allcount != null;
			}
			set
			{
				bool flag = value == (this._allcount == null);
				if (flag)
				{
					this._allcount = (value ? new uint?(this.allcount) : null);
				}
			}
		}

		private bool ShouldSerializeallcount()
		{
			return this.allcountSpecified;
		}

		private void Resetallcount()
		{
			this.allcountSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "weekcount", DataFormat = DataFormat.TwosComplement)]
		public uint weekcount
		{
			get
			{
				return this._weekcount ?? 0U;
			}
			set
			{
				this._weekcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekcountSpecified
		{
			get
			{
				return this._weekcount != null;
			}
			set
			{
				bool flag = value == (this._weekcount == null);
				if (flag)
				{
					this._weekcount = (value ? new uint?(this.weekcount) : null);
				}
			}
		}

		private bool ShouldSerializeweekcount()
		{
			return this.weekcountSpecified;
		}

		private void Resetweekcount()
		{
			this.weekcountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "weekrank", DataFormat = DataFormat.TwosComplement)]
		public uint weekrank
		{
			get
			{
				return this._weekrank ?? 0U;
			}
			set
			{
				this._weekrank = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekrankSpecified
		{
			get
			{
				return this._weekrank != null;
			}
			set
			{
				bool flag = value == (this._weekrank == null);
				if (flag)
				{
					this._weekrank = (value ? new uint?(this.weekrank) : null);
				}
			}
		}

		private bool ShouldSerializeweekrank()
		{
			return this.weekrankSpecified;
		}

		private void Resetweekrank()
		{
			this.weekrankSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "cansendcount", DataFormat = DataFormat.TwosComplement)]
		public uint cansendcount
		{
			get
			{
				return this._cansendcount ?? 0U;
			}
			set
			{
				this._cansendcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cansendcountSpecified
		{
			get
			{
				return this._cansendcount != null;
			}
			set
			{
				bool flag = value == (this._cansendcount == null);
				if (flag)
				{
					this._cansendcount = (value ? new uint?(this.cansendcount) : null);
				}
			}
		}

		private bool ShouldSerializecansendcount()
		{
			return this.cansendcountSpecified;
		}

		private void Resetcansendcount()
		{
			this.cansendcountSpecified = false;
		}

		[ProtoMember(5, Name = "cansendstate", DataFormat = DataFormat.TwosComplement)]
		public List<uint> cansendstate
		{
			get
			{
				return this._cansendstate;
			}
		}

		[ProtoMember(6, Name = "recordroleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> recordroleid
		{
			get
			{
				return this._recordroleid;
			}
		}

		[ProtoMember(7, Name = "recordcount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> recordcount
		{
			get
			{
				return this._recordcount;
			}
		}

		[ProtoMember(8, Name = "recordtime", DataFormat = DataFormat.TwosComplement)]
		public List<uint> recordtime
		{
			get
			{
				return this._recordtime;
			}
		}

		[ProtoMember(9, Name = "recordname", DataFormat = DataFormat.Default)]
		public List<string> recordname
		{
			get
			{
				return this._recordname;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "roleprofession", DataFormat = DataFormat.TwosComplement)]
		public uint roleprofession
		{
			get
			{
				return this._roleprofession ?? 0U;
			}
			set
			{
				this._roleprofession = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleprofessionSpecified
		{
			get
			{
				return this._roleprofession != null;
			}
			set
			{
				bool flag = value == (this._roleprofession == null);
				if (flag)
				{
					this._roleprofession = (value ? new uint?(this.roleprofession) : null);
				}
			}
		}

		private bool ShouldSerializeroleprofession()
		{
			return this.roleprofessionSpecified;
		}

		private void Resetroleprofession()
		{
			this.roleprofessionSpecified = false;
		}

		[ProtoMember(12, Name = "otherroleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> otherroleid
		{
			get
			{
				return this._otherroleid;
			}
		}

		[ProtoMember(13, Name = "othername", DataFormat = DataFormat.Default)]
		public List<string> othername
		{
			get
			{
				return this._othername;
			}
		}

		[ProtoMember(14, Name = "othercount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> othercount
		{
			get
			{
				return this._othercount;
			}
		}

		[ProtoMember(15, Name = "otherprofession", DataFormat = DataFormat.TwosComplement)]
		public List<uint> otherprofession
		{
			get
			{
				return this._otherprofession;
			}
		}

		[ProtoMember(16, Name = "updegreelevel", DataFormat = DataFormat.TwosComplement)]
		public List<uint> updegreelevel
		{
			get
			{
				return this._updegreelevel;
			}
		}

		[ProtoMember(17, Name = "sendFlowersTotal", DataFormat = DataFormat.Default)]
		public List<MapIntItem> sendFlowersTotal
		{
			get
			{
				return this._sendFlowersTotal;
			}
		}

		[ProtoMember(18, Name = "sendLog", DataFormat = DataFormat.Default)]
		public List<FlowerInfo2Client> sendLog
		{
			get
			{
				return this._sendLog;
			}
		}

		[ProtoMember(19, Name = "receiveFlowersTotal", DataFormat = DataFormat.Default)]
		public List<MapIntItem> receiveFlowersTotal
		{
			get
			{
				return this._receiveFlowersTotal;
			}
		}

		[ProtoMember(20, Name = "receiveRank", DataFormat = DataFormat.Default)]
		public List<ReceiveRoleFlowerInfo2Client> receiveRank
		{
			get
			{
				return this._receiveRank;
			}
		}

		[ProtoMember(21, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _allcount;

		private uint? _weekcount;

		private uint? _weekrank;

		private uint? _cansendcount;

		private readonly List<uint> _cansendstate = new List<uint>();

		private readonly List<ulong> _recordroleid = new List<ulong>();

		private readonly List<uint> _recordcount = new List<uint>();

		private readonly List<uint> _recordtime = new List<uint>();

		private readonly List<string> _recordname = new List<string>();

		private string _rolename;

		private uint? _roleprofession;

		private readonly List<ulong> _otherroleid = new List<ulong>();

		private readonly List<string> _othername = new List<string>();

		private readonly List<uint> _othercount = new List<uint>();

		private readonly List<uint> _otherprofession = new List<uint>();

		private readonly List<uint> _updegreelevel = new List<uint>();

		private readonly List<MapIntItem> _sendFlowersTotal = new List<MapIntItem>();

		private readonly List<FlowerInfo2Client> _sendLog = new List<FlowerInfo2Client>();

		private readonly List<MapIntItem> _receiveFlowersTotal = new List<MapIntItem>();

		private readonly List<ReceiveRoleFlowerInfo2Client> _receiveRank = new List<ReceiveRoleFlowerInfo2Client>();

		private ErrorCode? _errorcode;

		private IExtension extensionObject;
	}
}

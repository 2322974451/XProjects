using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RandomFriendWaitListRes")]
	[Serializable]
	public class RandomFriendWaitListRes : IExtensible
	{

		[ProtoMember(1, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		[ProtoMember(2, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public List<uint> profession
		{
			get
			{
				return this._profession;
			}
		}

		[ProtoMember(3, Name = "name", DataFormat = DataFormat.Default)]
		public List<string> name
		{
			get
			{
				return this._name;
			}
		}

		[ProtoMember(4, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public List<uint> level
		{
			get
			{
				return this._level;
			}
		}

		[ProtoMember(5, Name = "powerpoint", DataFormat = DataFormat.TwosComplement)]
		public List<uint> powerpoint
		{
			get
			{
				return this._powerpoint;
			}
		}

		[ProtoMember(6, Name = "viplevel", DataFormat = DataFormat.TwosComplement)]
		public List<uint> viplevel
		{
			get
			{
				return this._viplevel;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(8, Name = "lastlogin", DataFormat = DataFormat.TwosComplement)]
		public List<uint> lastlogin
		{
			get
			{
				return this._lastlogin;
			}
		}

		[ProtoMember(9, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> guildid
		{
			get
			{
				return this._guildid;
			}
		}

		[ProtoMember(10, Name = "guildname", DataFormat = DataFormat.Default)]
		public List<string> guildname
		{
			get
			{
				return this._guildname;
			}
		}

		[ProtoMember(11, Name = "nickid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> nickid
		{
			get
			{
				return this._nickid;
			}
		}

		[ProtoMember(12, Name = "titleid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> titleid
		{
			get
			{
				return this._titleid;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ulong> _roleid = new List<ulong>();

		private readonly List<uint> _profession = new List<uint>();

		private readonly List<string> _name = new List<string>();

		private readonly List<uint> _level = new List<uint>();

		private readonly List<uint> _powerpoint = new List<uint>();

		private readonly List<uint> _viplevel = new List<uint>();

		private ErrorCode? _errorcode;

		private readonly List<uint> _lastlogin = new List<uint>();

		private readonly List<ulong> _guildid = new List<ulong>();

		private readonly List<string> _guildname = new List<string>();

		private readonly List<uint> _nickid = new List<uint>();

		private readonly List<uint> _titleid = new List<uint>();

		private IExtension extensionObject;
	}
}

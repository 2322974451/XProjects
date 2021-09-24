using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetOtherGuildBriefRes")]
	[Serializable]
	public class GetOtherGuildBriefRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
		public string guildname
		{
			get
			{
				return this._guildname ?? "";
			}
			set
			{
				this._guildname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildnameSpecified
		{
			get
			{
				return this._guildname != null;
			}
			set
			{
				bool flag = value == (this._guildname == null);
				if (flag)
				{
					this._guildname = (value ? this.guildname : null);
				}
			}
		}

		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "leadername", DataFormat = DataFormat.Default)]
		public string leadername
		{
			get
			{
				return this._leadername ?? "";
			}
			set
			{
				this._leadername = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leadernameSpecified
		{
			get
			{
				return this._leadername != null;
			}
			set
			{
				bool flag = value == (this._leadername == null);
				if (flag)
				{
					this._leadername = (value ? this.leadername : null);
				}
			}
		}

		private bool ShouldSerializeleadername()
		{
			return this.leadernameSpecified;
		}

		private void Resetleadername()
		{
			this.leadernameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "leaderid", DataFormat = DataFormat.TwosComplement)]
		public ulong leaderid
		{
			get
			{
				return this._leaderid ?? 0UL;
			}
			set
			{
				this._leaderid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leaderidSpecified
		{
			get
			{
				return this._leaderid != null;
			}
			set
			{
				bool flag = value == (this._leaderid == null);
				if (flag)
				{
					this._leaderid = (value ? new ulong?(this.leaderid) : null);
				}
			}
		}

		private bool ShouldSerializeleaderid()
		{
			return this.leaderidSpecified;
		}

		private void Resetleaderid()
		{
			this.leaderidSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "guildlevel", DataFormat = DataFormat.TwosComplement)]
		public uint guildlevel
		{
			get
			{
				return this._guildlevel ?? 0U;
			}
			set
			{
				this._guildlevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildlevelSpecified
		{
			get
			{
				return this._guildlevel != null;
			}
			set
			{
				bool flag = value == (this._guildlevel == null);
				if (flag)
				{
					this._guildlevel = (value ? new uint?(this.guildlevel) : null);
				}
			}
		}

		private bool ShouldSerializeguildlevel()
		{
			return this.guildlevelSpecified;
		}

		private void Resetguildlevel()
		{
			this.guildlevelSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "icon", DataFormat = DataFormat.TwosComplement)]
		public uint icon
		{
			get
			{
				return this._icon ?? 0U;
			}
			set
			{
				this._icon = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool iconSpecified
		{
			get
			{
				return this._icon != null;
			}
			set
			{
				bool flag = value == (this._icon == null);
				if (flag)
				{
					this._icon = (value ? new uint?(this.icon) : null);
				}
			}
		}

		private bool ShouldSerializeicon()
		{
			return this.iconSpecified;
		}

		private void Reseticon()
		{
			this.iconSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "announcement", DataFormat = DataFormat.Default)]
		public string announcement
		{
			get
			{
				return this._announcement ?? "";
			}
			set
			{
				this._announcement = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool announcementSpecified
		{
			get
			{
				return this._announcement != null;
			}
			set
			{
				bool flag = value == (this._announcement == null);
				if (flag)
				{
					this._announcement = (value ? this.announcement : null);
				}
			}
		}

		private bool ShouldSerializeannouncement()
		{
			return this.announcementSpecified;
		}

		private void Resetannouncement()
		{
			this.announcementSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "currentcount", DataFormat = DataFormat.TwosComplement)]
		public uint currentcount
		{
			get
			{
				return this._currentcount ?? 0U;
			}
			set
			{
				this._currentcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool currentcountSpecified
		{
			get
			{
				return this._currentcount != null;
			}
			set
			{
				bool flag = value == (this._currentcount == null);
				if (flag)
				{
					this._currentcount = (value ? new uint?(this.currentcount) : null);
				}
			}
		}

		private bool ShouldSerializecurrentcount()
		{
			return this.currentcountSpecified;
		}

		private void Resetcurrentcount()
		{
			this.currentcountSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "allcount", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private string _guildname;

		private string _leadername;

		private ulong? _leaderid;

		private uint? _guildlevel;

		private uint? _icon;

		private string _announcement;

		private uint? _currentcount;

		private uint? _allcount;

		private IExtension extensionObject;
	}
}

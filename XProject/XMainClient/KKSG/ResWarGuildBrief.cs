using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResWarGuildBrief")]
	[Serializable]
	public class ResWarGuildBrief : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public ulong guildid
		{
			get
			{
				return this._guildid ?? 0UL;
			}
			set
			{
				this._guildid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildidSpecified
		{
			get
			{
				return this._guildid != null;
			}
			set
			{
				bool flag = value == (this._guildid == null);
				if (flag)
				{
					this._guildid = (value ? new ulong?(this.guildid) : null);
				}
			}
		}

		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "cd", DataFormat = DataFormat.TwosComplement)]
		public uint cd
		{
			get
			{
				return this._cd ?? 0U;
			}
			set
			{
				this._cd = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cdSpecified
		{
			get
			{
				return this._cd != null;
			}
			set
			{
				bool flag = value == (this._cd == null);
				if (flag)
				{
					this._cd = (value ? new uint?(this.cd) : null);
				}
			}
		}

		private bool ShouldSerializecd()
		{
			return this.cdSpecified;
		}

		private void Resetcd()
		{
			this.cdSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "cardcd", DataFormat = DataFormat.TwosComplement)]
		public uint cardcd
		{
			get
			{
				return this._cardcd ?? 0U;
			}
			set
			{
				this._cardcd = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cardcdSpecified
		{
			get
			{
				return this._cardcd != null;
			}
			set
			{
				bool flag = value == (this._cardcd == null);
				if (flag)
				{
					this._cardcd = (value ? new uint?(this.cardcd) : null);
				}
			}
		}

		private bool ShouldSerializecardcd()
		{
			return this.cardcdSpecified;
		}

		private void Resetcardcd()
		{
			this.cardcdSpecified = false;
		}

		[ProtoMember(5, Name = "item", DataFormat = DataFormat.Default)]
		public List<GuildBuffItem> item
		{
			get
			{
				return this._item;
			}
		}

		[ProtoMember(6, Name = "record", DataFormat = DataFormat.Default)]
		public List<GuildBuffRecord> record
		{
			get
			{
				return this._record;
			}
		}

		[ProtoMember(7, Name = "mineid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> mineid
		{
			get
			{
				return this._mineid;
			}
		}

		[ProtoMember(8, Name = "chatinfo", DataFormat = DataFormat.Default)]
		public List<ChatInfo> chatinfo
		{
			get
			{
				return this._chatinfo;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "totalcd", DataFormat = DataFormat.TwosComplement)]
		public uint totalcd
		{
			get
			{
				return this._totalcd ?? 0U;
			}
			set
			{
				this._totalcd = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalcdSpecified
		{
			get
			{
				return this._totalcd != null;
			}
			set
			{
				bool flag = value == (this._totalcd == null);
				if (flag)
				{
					this._totalcd = (value ? new uint?(this.totalcd) : null);
				}
			}
		}

		private bool ShouldSerializetotalcd()
		{
			return this.totalcdSpecified;
		}

		private void Resettotalcd()
		{
			this.totalcdSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "timecoutdown", DataFormat = DataFormat.TwosComplement)]
		public uint timecoutdown
		{
			get
			{
				return this._timecoutdown ?? 0U;
			}
			set
			{
				this._timecoutdown = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timecoutdownSpecified
		{
			get
			{
				return this._timecoutdown != null;
			}
			set
			{
				bool flag = value == (this._timecoutdown == null);
				if (flag)
				{
					this._timecoutdown = (value ? new uint?(this.timecoutdown) : null);
				}
			}
		}

		private bool ShouldSerializetimecoutdown()
		{
			return this.timecoutdownSpecified;
		}

		private void Resettimecoutdown()
		{
			this.timecoutdownSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "timetype", DataFormat = DataFormat.TwosComplement)]
		public uint timetype
		{
			get
			{
				return this._timetype ?? 0U;
			}
			set
			{
				this._timetype = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timetypeSpecified
		{
			get
			{
				return this._timetype != null;
			}
			set
			{
				bool flag = value == (this._timetype == null);
				if (flag)
				{
					this._timetype = (value ? new uint?(this.timetype) : null);
				}
			}
		}

		private bool ShouldSerializetimetype()
		{
			return this.timetypeSpecified;
		}

		private void Resettimetype()
		{
			this.timetypeSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "rankinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ResWarRankSimpleInfo rankinfo
		{
			get
			{
				return this._rankinfo;
			}
			set
			{
				this._rankinfo = value;
			}
		}

		[ProtoMember(13, Name = "buffinfo", DataFormat = DataFormat.Default)]
		public List<GuildBuffSimpleInfo> buffinfo
		{
			get
			{
				return this._buffinfo;
			}
		}

		[ProtoMember(14, Name = "buffid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> buffid
		{
			get
			{
				return this._buffid;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private ulong? _guildid;

		private uint? _cd;

		private uint? _cardcd;

		private readonly List<GuildBuffItem> _item = new List<GuildBuffItem>();

		private readonly List<GuildBuffRecord> _record = new List<GuildBuffRecord>();

		private readonly List<uint> _mineid = new List<uint>();

		private readonly List<ChatInfo> _chatinfo = new List<ChatInfo>();

		private uint? _totalcd;

		private uint? _timecoutdown;

		private uint? _timetype;

		private ResWarRankSimpleInfo _rankinfo = null;

		private readonly List<GuildBuffSimpleInfo> _buffinfo = new List<GuildBuffSimpleInfo>();

		private readonly List<uint> _buffid = new List<uint>();

		private IExtension extensionObject;
	}
}

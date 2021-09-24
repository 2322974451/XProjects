using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildInfo")]
	[Serializable]
	public class GuildInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		[ProtoMember(2, IsRequired = false, Name = "leaderID", DataFormat = DataFormat.TwosComplement)]
		public ulong leaderID
		{
			get
			{
				return this._leaderID ?? 0UL;
			}
			set
			{
				this._leaderID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leaderIDSpecified
		{
			get
			{
				return this._leaderID != null;
			}
			set
			{
				bool flag = value == (this._leaderID == null);
				if (flag)
				{
					this._leaderID = (value ? new ulong?(this.leaderID) : null);
				}
			}
		}

		private bool ShouldSerializeleaderID()
		{
			return this.leaderIDSpecified;
		}

		private void ResetleaderID()
		{
			this.leaderIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "leaderName", DataFormat = DataFormat.Default)]
		public string leaderName
		{
			get
			{
				return this._leaderName ?? "";
			}
			set
			{
				this._leaderName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leaderNameSpecified
		{
			get
			{
				return this._leaderName != null;
			}
			set
			{
				bool flag = value == (this._leaderName == null);
				if (flag)
				{
					this._leaderName = (value ? this.leaderName : null);
				}
			}
		}

		private bool ShouldSerializeleaderName()
		{
			return this.leaderNameSpecified;
		}

		private void ResetleaderName()
		{
			this.leaderNameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public int level
		{
			get
			{
				return this._level ?? 0;
			}
			set
			{
				this._level = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new int?(this.level) : null);
				}
			}
		}

		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "memberCount", DataFormat = DataFormat.TwosComplement)]
		public int memberCount
		{
			get
			{
				return this._memberCount ?? 0;
			}
			set
			{
				this._memberCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool memberCountSpecified
		{
			get
			{
				return this._memberCount != null;
			}
			set
			{
				bool flag = value == (this._memberCount == null);
				if (flag)
				{
					this._memberCount = (value ? new int?(this.memberCount) : null);
				}
			}
		}

		private bool ShouldSerializememberCount()
		{
			return this.memberCountSpecified;
		}

		private void ResetmemberCount()
		{
			this.memberCountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "isSendApplication", DataFormat = DataFormat.Default)]
		public bool isSendApplication
		{
			get
			{
				return this._isSendApplication ?? false;
			}
			set
			{
				this._isSendApplication = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isSendApplicationSpecified
		{
			get
			{
				return this._isSendApplication != null;
			}
			set
			{
				bool flag = value == (this._isSendApplication == null);
				if (flag)
				{
					this._isSendApplication = (value ? new bool?(this.isSendApplication) : null);
				}
			}
		}

		private bool ShouldSerializeisSendApplication()
		{
			return this.isSendApplicationSpecified;
		}

		private void ResetisSendApplication()
		{
			this.isSendApplicationSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public ulong id
		{
			get
			{
				return this._id ?? 0UL;
			}
			set
			{
				this._id = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new ulong?(this.id) : null);
				}
			}
		}

		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		private void Resetid()
		{
			this.idSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public int ppt
		{
			get
			{
				return this._ppt ?? 0;
			}
			set
			{
				this._ppt = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pptSpecified
		{
			get
			{
				return this._ppt != null;
			}
			set
			{
				bool flag = value == (this._ppt == null);
				if (flag)
				{
					this._ppt = (value ? new int?(this.ppt) : null);
				}
			}
		}

		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "needapproval", DataFormat = DataFormat.TwosComplement)]
		public int needapproval
		{
			get
			{
				return this._needapproval ?? 0;
			}
			set
			{
				this._needapproval = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool needapprovalSpecified
		{
			get
			{
				return this._needapproval != null;
			}
			set
			{
				bool flag = value == (this._needapproval == null);
				if (flag)
				{
					this._needapproval = (value ? new int?(this.needapproval) : null);
				}
			}
		}

		private bool ShouldSerializeneedapproval()
		{
			return this.needapprovalSpecified;
		}

		private void Resetneedapproval()
		{
			this.needapprovalSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "icon", DataFormat = DataFormat.TwosComplement)]
		public int icon
		{
			get
			{
				return this._icon ?? 0;
			}
			set
			{
				this._icon = new int?(value);
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
					this._icon = (value ? new int?(this.icon) : null);
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

		[ProtoMember(11, IsRequired = false, Name = "capacity", DataFormat = DataFormat.TwosComplement)]
		public int capacity
		{
			get
			{
				return this._capacity ?? 0;
			}
			set
			{
				this._capacity = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool capacitySpecified
		{
			get
			{
				return this._capacity != null;
			}
			set
			{
				bool flag = value == (this._capacity == null);
				if (flag)
				{
					this._capacity = (value ? new int?(this.capacity) : null);
				}
			}
		}

		private bool ShouldSerializecapacity()
		{
			return this.capacitySpecified;
		}

		private void Resetcapacity()
		{
			this.capacitySpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "annoucement", DataFormat = DataFormat.Default)]
		public string annoucement
		{
			get
			{
				return this._annoucement ?? "";
			}
			set
			{
				this._annoucement = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool annoucementSpecified
		{
			get
			{
				return this._annoucement != null;
			}
			set
			{
				bool flag = value == (this._annoucement == null);
				if (flag)
				{
					this._annoucement = (value ? this.annoucement : null);
				}
			}
		}

		private bool ShouldSerializeannoucement()
		{
			return this.annoucementSpecified;
		}

		private void Resetannoucement()
		{
			this.annoucementSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "guildExp", DataFormat = DataFormat.TwosComplement)]
		public uint guildExp
		{
			get
			{
				return this._guildExp ?? 0U;
			}
			set
			{
				this._guildExp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildExpSpecified
		{
			get
			{
				return this._guildExp != null;
			}
			set
			{
				bool flag = value == (this._guildExp == null);
				if (flag)
				{
					this._guildExp = (value ? new uint?(this.guildExp) : null);
				}
			}
		}

		private bool ShouldSerializeguildExp()
		{
			return this.guildExpSpecified;
		}

		private void ResetguildExp()
		{
			this.guildExpSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "titleID", DataFormat = DataFormat.TwosComplement)]
		public uint titleID
		{
			get
			{
				return this._titleID ?? 0U;
			}
			set
			{
				this._titleID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool titleIDSpecified
		{
			get
			{
				return this._titleID != null;
			}
			set
			{
				bool flag = value == (this._titleID == null);
				if (flag)
				{
					this._titleID = (value ? new uint?(this.titleID) : null);
				}
			}
		}

		private bool ShouldSerializetitleID()
		{
			return this.titleIDSpecified;
		}

		private void ResettitleID()
		{
			this.titleIDSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "prestige", DataFormat = DataFormat.TwosComplement)]
		public uint prestige
		{
			get
			{
				return this._prestige ?? 0U;
			}
			set
			{
				this._prestige = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool prestigeSpecified
		{
			get
			{
				return this._prestige != null;
			}
			set
			{
				bool flag = value == (this._prestige == null);
				if (flag)
				{
					this._prestige = (value ? new uint?(this.prestige) : null);
				}
			}
		}

		private bool ShouldSerializeprestige()
		{
			return this.prestigeSpecified;
		}

		private void Resetprestige()
		{
			this.prestigeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _name;

		private ulong? _leaderID;

		private string _leaderName;

		private int? _level;

		private int? _memberCount;

		private bool? _isSendApplication;

		private ulong? _id;

		private int? _ppt;

		private int? _needapproval;

		private int? _icon;

		private int? _capacity;

		private string _annoucement;

		private uint? _guildExp;

		private uint? _titleID;

		private uint? _prestige;

		private IExtension extensionObject;
	}
}

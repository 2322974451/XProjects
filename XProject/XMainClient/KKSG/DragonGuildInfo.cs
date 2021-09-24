using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonGuildInfo")]
	[Serializable]
	public class DragonGuildInfo : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "leaderId", DataFormat = DataFormat.TwosComplement)]
		public ulong leaderId
		{
			get
			{
				return this._leaderId ?? 0UL;
			}
			set
			{
				this._leaderId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leaderIdSpecified
		{
			get
			{
				return this._leaderId != null;
			}
			set
			{
				bool flag = value == (this._leaderId == null);
				if (flag)
				{
					this._leaderId = (value ? new ulong?(this.leaderId) : null);
				}
			}
		}

		private bool ShouldSerializeleaderId()
		{
			return this.leaderIdSpecified;
		}

		private void ResetleaderId()
		{
			this.leaderIdSpecified = false;
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

		[ProtoMember(4, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
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
					this._level = (value ? new uint?(this.level) : null);
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

		[ProtoMember(5, IsRequired = false, Name = "membercounts", DataFormat = DataFormat.TwosComplement)]
		public uint membercounts
		{
			get
			{
				return this._membercounts ?? 0U;
			}
			set
			{
				this._membercounts = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool membercountsSpecified
		{
			get
			{
				return this._membercounts != null;
			}
			set
			{
				bool flag = value == (this._membercounts == null);
				if (flag)
				{
					this._membercounts = (value ? new uint?(this.membercounts) : null);
				}
			}
		}

		private bool ShouldSerializemembercounts()
		{
			return this.membercountsSpecified;
		}

		private void Resetmembercounts()
		{
			this.membercountsSpecified = false;
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

		[ProtoMember(8, IsRequired = false, Name = "recruitppt", DataFormat = DataFormat.TwosComplement)]
		public uint recruitppt
		{
			get
			{
				return this._recruitppt ?? 0U;
			}
			set
			{
				this._recruitppt = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool recruitpptSpecified
		{
			get
			{
				return this._recruitppt != null;
			}
			set
			{
				bool flag = value == (this._recruitppt == null);
				if (flag)
				{
					this._recruitppt = (value ? new uint?(this.recruitppt) : null);
				}
			}
		}

		private bool ShouldSerializerecruitppt()
		{
			return this.recruitpptSpecified;
		}

		private void Resetrecruitppt()
		{
			this.recruitpptSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "needapproval", DataFormat = DataFormat.Default)]
		public bool needapproval
		{
			get
			{
				return this._needapproval ?? false;
			}
			set
			{
				this._needapproval = new bool?(value);
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
					this._needapproval = (value ? new bool?(this.needapproval) : null);
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

		[ProtoMember(10, IsRequired = false, Name = "capacity", DataFormat = DataFormat.TwosComplement)]
		public uint capacity
		{
			get
			{
				return this._capacity ?? 0U;
			}
			set
			{
				this._capacity = new uint?(value);
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
					this._capacity = (value ? new uint?(this.capacity) : null);
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

		[ProtoMember(11, IsRequired = false, Name = "announcement", DataFormat = DataFormat.Default)]
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

		[ProtoMember(12, IsRequired = false, Name = "guildExp", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(13, IsRequired = false, Name = "totalPPT", DataFormat = DataFormat.TwosComplement)]
		public ulong totalPPT
		{
			get
			{
				return this._totalPPT ?? 0UL;
			}
			set
			{
				this._totalPPT = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalPPTSpecified
		{
			get
			{
				return this._totalPPT != null;
			}
			set
			{
				bool flag = value == (this._totalPPT == null);
				if (flag)
				{
					this._totalPPT = (value ? new ulong?(this.totalPPT) : null);
				}
			}
		}

		private bool ShouldSerializetotalPPT()
		{
			return this.totalPPTSpecified;
		}

		private void ResettotalPPT()
		{
			this.totalPPTSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "sceneId", DataFormat = DataFormat.TwosComplement)]
		public uint sceneId
		{
			get
			{
				return this._sceneId ?? 0U;
			}
			set
			{
				this._sceneId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneIdSpecified
		{
			get
			{
				return this._sceneId != null;
			}
			set
			{
				bool flag = value == (this._sceneId == null);
				if (flag)
				{
					this._sceneId = (value ? new uint?(this.sceneId) : null);
				}
			}
		}

		private bool ShouldSerializesceneId()
		{
			return this.sceneIdSpecified;
		}

		private void ResetsceneId()
		{
			this.sceneIdSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "sceneCnt", DataFormat = DataFormat.TwosComplement)]
		public uint sceneCnt
		{
			get
			{
				return this._sceneCnt ?? 0U;
			}
			set
			{
				this._sceneCnt = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneCntSpecified
		{
			get
			{
				return this._sceneCnt != null;
			}
			set
			{
				bool flag = value == (this._sceneCnt == null);
				if (flag)
				{
					this._sceneCnt = (value ? new uint?(this.sceneCnt) : null);
				}
			}
		}

		private bool ShouldSerializesceneCnt()
		{
			return this.sceneCntSpecified;
		}

		private void ResetsceneCnt()
		{
			this.sceneCntSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _name;

		private ulong? _leaderId;

		private string _leadername;

		private uint? _level;

		private uint? _membercounts;

		private bool? _isSendApplication;

		private ulong? _id;

		private uint? _recruitppt;

		private bool? _needapproval;

		private uint? _capacity;

		private string _announcement;

		private uint? _guildExp;

		private ulong? _totalPPT;

		private uint? _sceneId;

		private uint? _sceneCnt;

		private IExtension extensionObject;
	}
}

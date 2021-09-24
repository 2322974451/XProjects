using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildBriefRes")]
	[Serializable]
	public class GuildBriefRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "leaderName", DataFormat = DataFormat.Default)]
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

		[ProtoMember(3, IsRequired = false, Name = "annoucement", DataFormat = DataFormat.Default)]
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

		[ProtoMember(4, IsRequired = false, Name = "leaderID", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, IsRequired = false, Name = "membercount", DataFormat = DataFormat.TwosComplement)]
		public int membercount
		{
			get
			{
				return this._membercount ?? 0;
			}
			set
			{
				this._membercount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool membercountSpecified
		{
			get
			{
				return this._membercount != null;
			}
			set
			{
				bool flag = value == (this._membercount == null);
				if (flag)
				{
					this._membercount = (value ? new int?(this.membercount) : null);
				}
			}
		}

		private bool ShouldSerializemembercount()
		{
			return this.membercountSpecified;
		}

		private void Resetmembercount()
		{
			this.membercountSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "capacity", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(8, IsRequired = false, Name = "icon", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(9, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "recuritppt", DataFormat = DataFormat.TwosComplement)]
		public uint recuritppt
		{
			get
			{
				return this._recuritppt ?? 0U;
			}
			set
			{
				this._recuritppt = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool recuritpptSpecified
		{
			get
			{
				return this._recuritppt != null;
			}
			set
			{
				bool flag = value == (this._recuritppt == null);
				if (flag)
				{
					this._recuritppt = (value ? new uint?(this.recuritppt) : null);
				}
			}
		}

		private bool ShouldSerializerecuritppt()
		{
			return this.recuritpptSpecified;
		}

		private void Resetrecuritppt()
		{
			this.recuritpptSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "needApproval", DataFormat = DataFormat.TwosComplement)]
		public int needApproval
		{
			get
			{
				return this._needApproval ?? 0;
			}
			set
			{
				this._needApproval = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool needApprovalSpecified
		{
			get
			{
				return this._needApproval != null;
			}
			set
			{
				bool flag = value == (this._needApproval == null);
				if (flag)
				{
					this._needApproval = (value ? new int?(this.needApproval) : null);
				}
			}
		}

		private bool ShouldSerializeneedApproval()
		{
			return this.needApprovalSpecified;
		}

		private void ResetneedApproval()
		{
			this.needApprovalSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public uint exp
		{
			get
			{
				return this._exp ?? 0U;
			}
			set
			{
				this._exp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new uint?(this.exp) : null);
				}
			}
		}

		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		private void Resetexp()
		{
			this.expSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public int rank
		{
			get
			{
				return this._rank ?? 0;
			}
			set
			{
				this._rank = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new int?(this.rank) : null);
				}
			}
		}

		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "activity", DataFormat = DataFormat.TwosComplement)]
		public uint activity
		{
			get
			{
				return this._activity ?? 0U;
			}
			set
			{
				this._activity = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool activitySpecified
		{
			get
			{
				return this._activity != null;
			}
			set
			{
				bool flag = value == (this._activity == null);
				if (flag)
				{
					this._activity = (value ? new uint?(this.activity) : null);
				}
			}
		}

		private bool ShouldSerializeactivity()
		{
			return this.activitySpecified;
		}

		private void Resetactivity()
		{
			this.activitySpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "activityOne", DataFormat = DataFormat.TwosComplement)]
		public uint activityOne
		{
			get
			{
				return this._activityOne ?? 0U;
			}
			set
			{
				this._activityOne = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool activityOneSpecified
		{
			get
			{
				return this._activityOne != null;
			}
			set
			{
				bool flag = value == (this._activityOne == null);
				if (flag)
				{
					this._activityOne = (value ? new uint?(this.activityOne) : null);
				}
			}
		}

		private bool ShouldSerializeactivityOne()
		{
			return this.activityOneSpecified;
		}

		private void ResetactivityOne()
		{
			this.activityOneSpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "activityTwo", DataFormat = DataFormat.TwosComplement)]
		public uint activityTwo
		{
			get
			{
				return this._activityTwo ?? 0U;
			}
			set
			{
				this._activityTwo = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool activityTwoSpecified
		{
			get
			{
				return this._activityTwo != null;
			}
			set
			{
				bool flag = value == (this._activityTwo == null);
				if (flag)
				{
					this._activityTwo = (value ? new uint?(this.activityTwo) : null);
				}
			}
		}

		private bool ShouldSerializeactivityTwo()
		{
			return this.activityTwoSpecified;
		}

		private void ResetactivityTwo()
		{
			this.activityTwoSpecified = false;
		}

		[ProtoMember(17, IsRequired = false, Name = "activityThree", DataFormat = DataFormat.TwosComplement)]
		public uint activityThree
		{
			get
			{
				return this._activityThree ?? 0U;
			}
			set
			{
				this._activityThree = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool activityThreeSpecified
		{
			get
			{
				return this._activityThree != null;
			}
			set
			{
				bool flag = value == (this._activityThree == null);
				if (flag)
				{
					this._activityThree = (value ? new uint?(this.activityThree) : null);
				}
			}
		}

		private bool ShouldSerializeactivityThree()
		{
			return this.activityThreeSpecified;
		}

		private void ResetactivityThree()
		{
			this.activityThreeSpecified = false;
		}

		[ProtoMember(18, IsRequired = false, Name = "prestige", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(19, IsRequired = false, Name = "schoolpoint", DataFormat = DataFormat.TwosComplement)]
		public uint schoolpoint
		{
			get
			{
				return this._schoolpoint ?? 0U;
			}
			set
			{
				this._schoolpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool schoolpointSpecified
		{
			get
			{
				return this._schoolpoint != null;
			}
			set
			{
				bool flag = value == (this._schoolpoint == null);
				if (flag)
				{
					this._schoolpoint = (value ? new uint?(this.schoolpoint) : null);
				}
			}
		}

		private bool ShouldSerializeschoolpoint()
		{
			return this.schoolpointSpecified;
		}

		private void Resetschoolpoint()
		{
			this.schoolpointSpecified = false;
		}

		[ProtoMember(20, IsRequired = false, Name = "hallpoint", DataFormat = DataFormat.TwosComplement)]
		public uint hallpoint
		{
			get
			{
				return this._hallpoint ?? 0U;
			}
			set
			{
				this._hallpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hallpointSpecified
		{
			get
			{
				return this._hallpoint != null;
			}
			set
			{
				bool flag = value == (this._hallpoint == null);
				if (flag)
				{
					this._hallpoint = (value ? new uint?(this.hallpoint) : null);
				}
			}
		}

		private bool ShouldSerializehallpoint()
		{
			return this.hallpointSpecified;
		}

		private void Resethallpoint()
		{
			this.hallpointSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _name;

		private string _leaderName;

		private string _annoucement;

		private ulong? _leaderID;

		private int? _level;

		private int? _membercount;

		private int? _capacity;

		private int? _icon;

		private ErrorCode? _result;

		private uint? _recuritppt;

		private int? _needApproval;

		private uint? _exp;

		private int? _rank;

		private uint? _activity;

		private uint? _activityOne;

		private uint? _activityTwo;

		private uint? _activityThree;

		private uint? _prestige;

		private uint? _schoolpoint;

		private uint? _hallpoint;

		private IExtension extensionObject;
	}
}

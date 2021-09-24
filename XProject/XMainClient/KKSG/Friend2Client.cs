using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "Friend2Client")]
	[Serializable]
	public class Friend2Client : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new uint?(this.profession) : null);
				}
			}
		}

		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "powerpoint", DataFormat = DataFormat.TwosComplement)]
		public uint powerpoint
		{
			get
			{
				return this._powerpoint ?? 0U;
			}
			set
			{
				this._powerpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool powerpointSpecified
		{
			get
			{
				return this._powerpoint != null;
			}
			set
			{
				bool flag = value == (this._powerpoint == null);
				if (flag)
				{
					this._powerpoint = (value ? new uint?(this.powerpoint) : null);
				}
			}
		}

		private bool ShouldSerializepowerpoint()
		{
			return this.powerpointSpecified;
		}

		private void Resetpowerpoint()
		{
			this.powerpointSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "viplevel", DataFormat = DataFormat.TwosComplement)]
		public uint viplevel
		{
			get
			{
				return this._viplevel ?? 0U;
			}
			set
			{
				this._viplevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool viplevelSpecified
		{
			get
			{
				return this._viplevel != null;
			}
			set
			{
				bool flag = value == (this._viplevel == null);
				if (flag)
				{
					this._viplevel = (value ? new uint?(this.viplevel) : null);
				}
			}
		}

		private bool ShouldSerializeviplevel()
		{
			return this.viplevelSpecified;
		}

		private void Resetviplevel()
		{
			this.viplevelSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "lastlogin", DataFormat = DataFormat.TwosComplement)]
		public uint lastlogin
		{
			get
			{
				return this._lastlogin ?? 0U;
			}
			set
			{
				this._lastlogin = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastloginSpecified
		{
			get
			{
				return this._lastlogin != null;
			}
			set
			{
				bool flag = value == (this._lastlogin == null);
				if (flag)
				{
					this._lastlogin = (value ? new uint?(this.lastlogin) : null);
				}
			}
		}

		private bool ShouldSerializelastlogin()
		{
			return this.lastloginSpecified;
		}

		private void Resetlastlogin()
		{
			this.lastloginSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		[ProtoMember(8, IsRequired = false, Name = "roleaudioid", DataFormat = DataFormat.TwosComplement)]
		public uint roleaudioid
		{
			get
			{
				return this._roleaudioid ?? 0U;
			}
			set
			{
				this._roleaudioid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleaudioidSpecified
		{
			get
			{
				return this._roleaudioid != null;
			}
			set
			{
				bool flag = value == (this._roleaudioid == null);
				if (flag)
				{
					this._roleaudioid = (value ? new uint?(this.roleaudioid) : null);
				}
			}
		}

		private bool ShouldSerializeroleaudioid()
		{
			return this.roleaudioidSpecified;
		}

		private void Resetroleaudioid()
		{
			this.roleaudioidSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "audioid", DataFormat = DataFormat.TwosComplement)]
		public uint audioid
		{
			get
			{
				return this._audioid ?? 0U;
			}
			set
			{
				this._audioid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool audioidSpecified
		{
			get
			{
				return this._audioid != null;
			}
			set
			{
				bool flag = value == (this._audioid == null);
				if (flag)
				{
					this._audioid = (value ? new uint?(this.audioid) : null);
				}
			}
		}

		private bool ShouldSerializeaudioid()
		{
			return this.audioidSpecified;
		}

		private void Resetaudioid()
		{
			this.audioidSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "degreelevel", DataFormat = DataFormat.TwosComplement)]
		public uint degreelevel
		{
			get
			{
				return this._degreelevel ?? 0U;
			}
			set
			{
				this._degreelevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool degreelevelSpecified
		{
			get
			{
				return this._degreelevel != null;
			}
			set
			{
				bool flag = value == (this._degreelevel == null);
				if (flag)
				{
					this._degreelevel = (value ? new uint?(this.degreelevel) : null);
				}
			}
		}

		private bool ShouldSerializedegreelevel()
		{
			return this.degreelevelSpecified;
		}

		private void Resetdegreelevel()
		{
			this.degreelevelSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "degreeleft", DataFormat = DataFormat.TwosComplement)]
		public uint degreeleft
		{
			get
			{
				return this._degreeleft ?? 0U;
			}
			set
			{
				this._degreeleft = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool degreeleftSpecified
		{
			get
			{
				return this._degreeleft != null;
			}
			set
			{
				bool flag = value == (this._degreeleft == null);
				if (flag)
				{
					this._degreeleft = (value ? new uint?(this.degreeleft) : null);
				}
			}
		}

		private bool ShouldSerializedegreeleft()
		{
			return this.degreeleftSpecified;
		}

		private void Resetdegreeleft()
		{
			this.degreeleftSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "daydegree", DataFormat = DataFormat.TwosComplement)]
		public uint daydegree
		{
			get
			{
				return this._daydegree ?? 0U;
			}
			set
			{
				this._daydegree = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daydegreeSpecified
		{
			get
			{
				return this._daydegree != null;
			}
			set
			{
				bool flag = value == (this._daydegree == null);
				if (flag)
				{
					this._daydegree = (value ? new uint?(this.daydegree) : null);
				}
			}
		}

		private bool ShouldSerializedaydegree()
		{
			return this.daydegreeSpecified;
		}

		private void Resetdaydegree()
		{
			this.daydegreeSpecified = false;
		}

		[ProtoMember(13, IsRequired = false, Name = "receivegiftstate", DataFormat = DataFormat.TwosComplement)]
		public uint receivegiftstate
		{
			get
			{
				return this._receivegiftstate ?? 0U;
			}
			set
			{
				this._receivegiftstate = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool receivegiftstateSpecified
		{
			get
			{
				return this._receivegiftstate != null;
			}
			set
			{
				bool flag = value == (this._receivegiftstate == null);
				if (flag)
				{
					this._receivegiftstate = (value ? new uint?(this.receivegiftstate) : null);
				}
			}
		}

		private bool ShouldSerializereceivegiftstate()
		{
			return this.receivegiftstateSpecified;
		}

		private void Resetreceivegiftstate()
		{
			this.receivegiftstateSpecified = false;
		}

		[ProtoMember(14, IsRequired = false, Name = "sendgiftstate", DataFormat = DataFormat.TwosComplement)]
		public uint sendgiftstate
		{
			get
			{
				return this._sendgiftstate ?? 0U;
			}
			set
			{
				this._sendgiftstate = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sendgiftstateSpecified
		{
			get
			{
				return this._sendgiftstate != null;
			}
			set
			{
				bool flag = value == (this._sendgiftstate == null);
				if (flag)
				{
					this._sendgiftstate = (value ? new uint?(this.sendgiftstate) : null);
				}
			}
		}

		private bool ShouldSerializesendgiftstate()
		{
			return this.sendgiftstateSpecified;
		}

		private void Resetsendgiftstate()
		{
			this.sendgiftstateSpecified = false;
		}

		[ProtoMember(15, IsRequired = false, Name = "alldegree", DataFormat = DataFormat.TwosComplement)]
		public uint alldegree
		{
			get
			{
				return this._alldegree ?? 0U;
			}
			set
			{
				this._alldegree = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool alldegreeSpecified
		{
			get
			{
				return this._alldegree != null;
			}
			set
			{
				bool flag = value == (this._alldegree == null);
				if (flag)
				{
					this._alldegree = (value ? new uint?(this.alldegree) : null);
				}
			}
		}

		private bool ShouldSerializealldegree()
		{
			return this.alldegreeSpecified;
		}

		private void Resetalldegree()
		{
			this.alldegreeSpecified = false;
		}

		[ProtoMember(16, IsRequired = false, Name = "receiveall", DataFormat = DataFormat.TwosComplement)]
		public uint receiveall
		{
			get
			{
				return this._receiveall ?? 0U;
			}
			set
			{
				this._receiveall = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool receiveallSpecified
		{
			get
			{
				return this._receiveall != null;
			}
			set
			{
				bool flag = value == (this._receiveall == null);
				if (flag)
				{
					this._receiveall = (value ? new uint?(this.receiveall) : null);
				}
			}
		}

		private bool ShouldSerializereceiveall()
		{
			return this.receiveallSpecified;
		}

		private void Resetreceiveall()
		{
			this.receiveallSpecified = false;
		}

		[ProtoMember(17, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
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

		[ProtoMember(18, IsRequired = false, Name = "receivetime", DataFormat = DataFormat.TwosComplement)]
		public uint receivetime
		{
			get
			{
				return this._receivetime ?? 0U;
			}
			set
			{
				this._receivetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool receivetimeSpecified
		{
			get
			{
				return this._receivetime != null;
			}
			set
			{
				bool flag = value == (this._receivetime == null);
				if (flag)
				{
					this._receivetime = (value ? new uint?(this.receivetime) : null);
				}
			}
		}

		private bool ShouldSerializereceivetime()
		{
			return this.receivetimeSpecified;
		}

		private void Resetreceivetime()
		{
			this.receivetimeSpecified = false;
		}

		[ProtoMember(19, IsRequired = false, Name = "nickid", DataFormat = DataFormat.TwosComplement)]
		public uint nickid
		{
			get
			{
				return this._nickid ?? 0U;
			}
			set
			{
				this._nickid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nickidSpecified
		{
			get
			{
				return this._nickid != null;
			}
			set
			{
				bool flag = value == (this._nickid == null);
				if (flag)
				{
					this._nickid = (value ? new uint?(this.nickid) : null);
				}
			}
		}

		private bool ShouldSerializenickid()
		{
			return this.nickidSpecified;
		}

		private void Resetnickid()
		{
			this.nickidSpecified = false;
		}

		[ProtoMember(20, IsRequired = false, Name = "titleid", DataFormat = DataFormat.TwosComplement)]
		public uint titleid
		{
			get
			{
				return this._titleid ?? 0U;
			}
			set
			{
				this._titleid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool titleidSpecified
		{
			get
			{
				return this._titleid != null;
			}
			set
			{
				bool flag = value == (this._titleid == null);
				if (flag)
				{
					this._titleid = (value ? new uint?(this.titleid) : null);
				}
			}
		}

		private bool ShouldSerializetitleid()
		{
			return this.titleidSpecified;
		}

		private void Resettitleid()
		{
			this.titleidSpecified = false;
		}

		[ProtoMember(21, IsRequired = false, Name = "paymemberid", DataFormat = DataFormat.TwosComplement)]
		public uint paymemberid
		{
			get
			{
				return this._paymemberid ?? 0U;
			}
			set
			{
				this._paymemberid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool paymemberidSpecified
		{
			get
			{
				return this._paymemberid != null;
			}
			set
			{
				bool flag = value == (this._paymemberid == null);
				if (flag)
				{
					this._paymemberid = (value ? new uint?(this.paymemberid) : null);
				}
			}
		}

		private bool ShouldSerializepaymemberid()
		{
			return this.paymemberidSpecified;
		}

		private void Resetpaymemberid()
		{
			this.paymemberidSpecified = false;
		}

		[ProtoMember(22, IsRequired = false, Name = "mentortype", DataFormat = DataFormat.TwosComplement)]
		public EMentorRelationPosition mentortype
		{
			get
			{
				return this._mentortype ?? EMentorRelationPosition.EMentorPosMaster;
			}
			set
			{
				this._mentortype = new EMentorRelationPosition?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mentortypeSpecified
		{
			get
			{
				return this._mentortype != null;
			}
			set
			{
				bool flag = value == (this._mentortype == null);
				if (flag)
				{
					this._mentortype = (value ? new EMentorRelationPosition?(this.mentortype) : null);
				}
			}
		}

		private bool ShouldSerializementortype()
		{
			return this.mentortypeSpecified;
		}

		private void Resetmentortype()
		{
			this.mentortypeSpecified = false;
		}

		[ProtoMember(23, IsRequired = false, Name = "openid", DataFormat = DataFormat.Default)]
		public string openid
		{
			get
			{
				return this._openid ?? "";
			}
			set
			{
				this._openid = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool openidSpecified
		{
			get
			{
				return this._openid != null;
			}
			set
			{
				bool flag = value == (this._openid == null);
				if (flag)
				{
					this._openid = (value ? this.openid : null);
				}
			}
		}

		private bool ShouldSerializeopenid()
		{
			return this.openidSpecified;
		}

		private void Resetopenid()
		{
			this.openidSpecified = false;
		}

		[ProtoMember(24, IsRequired = false, Name = "nickname", DataFormat = DataFormat.Default)]
		public string nickname
		{
			get
			{
				return this._nickname ?? "";
			}
			set
			{
				this._nickname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nicknameSpecified
		{
			get
			{
				return this._nickname != null;
			}
			set
			{
				bool flag = value == (this._nickname == null);
				if (flag)
				{
					this._nickname = (value ? this.nickname : null);
				}
			}
		}

		private bool ShouldSerializenickname()
		{
			return this.nicknameSpecified;
		}

		private void Resetnickname()
		{
			this.nicknameSpecified = false;
		}

		[ProtoMember(25, IsRequired = false, Name = "pre", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayConsume pre
		{
			get
			{
				return this._pre;
			}
			set
			{
				this._pre = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private uint? _profession;

		private uint? _level;

		private uint? _powerpoint;

		private uint? _viplevel;

		private uint? _lastlogin;

		private string _name;

		private uint? _roleaudioid;

		private uint? _audioid;

		private uint? _degreelevel;

		private uint? _degreeleft;

		private uint? _daydegree;

		private uint? _receivegiftstate;

		private uint? _sendgiftstate;

		private uint? _alldegree;

		private uint? _receiveall;

		private string _guildname;

		private uint? _receivetime;

		private uint? _nickid;

		private uint? _titleid;

		private uint? _paymemberid;

		private EMentorRelationPosition? _mentortype;

		private string _openid;

		private string _nickname;

		private PayConsume _pre = null;

		private IExtension extensionObject;
	}
}

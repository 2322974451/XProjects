using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PartnerMemberDetail")]
	[Serializable]
	public class PartnerMemberDetail : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "memberid", DataFormat = DataFormat.TwosComplement)]
		public ulong memberid
		{
			get
			{
				return this._memberid ?? 0UL;
			}
			set
			{
				this._memberid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool memberidSpecified
		{
			get
			{
				return this._memberid != null;
			}
			set
			{
				bool flag = value == (this._memberid == null);
				if (flag)
				{
					this._memberid = (value ? new ulong?(this.memberid) : null);
				}
			}
		}

		private bool ShouldSerializememberid()
		{
			return this.memberidSpecified;
		}

		private void Resetmemberid()
		{
			this.memberidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public RoleType profession
		{
			get
			{
				return this._profession ?? RoleType.Role_INVALID;
			}
			set
			{
				this._profession = new RoleType?(value);
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
					this._profession = (value ? new RoleType?(this.profession) : null);
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

		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		[ProtoMember(5, IsRequired = false, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public uint ppt
		{
			get
			{
				return this._ppt ?? 0U;
			}
			set
			{
				this._ppt = new uint?(value);
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
					this._ppt = (value ? new uint?(this.ppt) : null);
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

		[ProtoMember(6, Name = "fashion", DataFormat = DataFormat.TwosComplement)]
		public List<uint> fashion
		{
			get
			{
				return this._fashion;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "outlook", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLook outlook
		{
			get
			{
				return this._outlook;
			}
			set
			{
				this._outlook = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "viplevel", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(9, IsRequired = false, Name = "paymemberid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(10, IsRequired = false, Name = "is_apply_leave", DataFormat = DataFormat.Default)]
		public bool is_apply_leave
		{
			get
			{
				return this._is_apply_leave ?? false;
			}
			set
			{
				this._is_apply_leave = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool is_apply_leaveSpecified
		{
			get
			{
				return this._is_apply_leave != null;
			}
			set
			{
				bool flag = value == (this._is_apply_leave == null);
				if (flag)
				{
					this._is_apply_leave = (value ? new bool?(this.is_apply_leave) : null);
				}
			}
		}

		private bool ShouldSerializeis_apply_leave()
		{
			return this.is_apply_leaveSpecified;
		}

		private void Resetis_apply_leave()
		{
			this.is_apply_leaveSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "left_leave_time", DataFormat = DataFormat.TwosComplement)]
		public uint left_leave_time
		{
			get
			{
				return this._left_leave_time ?? 0U;
			}
			set
			{
				this._left_leave_time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool left_leave_timeSpecified
		{
			get
			{
				return this._left_leave_time != null;
			}
			set
			{
				bool flag = value == (this._left_leave_time == null);
				if (flag)
				{
					this._left_leave_time = (value ? new uint?(this.left_leave_time) : null);
				}
			}
		}

		private bool ShouldSerializeleft_leave_time()
		{
			return this.left_leave_timeSpecified;
		}

		private void Resetleft_leave_time()
		{
			this.left_leave_timeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _memberid;

		private RoleType? _profession;

		private string _name;

		private uint? _level;

		private uint? _ppt;

		private readonly List<uint> _fashion = new List<uint>();

		private OutLook _outlook = null;

		private uint? _viplevel;

		private uint? _paymemberid;

		private bool? _is_apply_leave;

		private uint? _left_leave_time;

		private IExtension extensionObject;
	}
}

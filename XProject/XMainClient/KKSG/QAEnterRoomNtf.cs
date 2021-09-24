using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QAEnterRoomNtf")]
	[Serializable]
	public class QAEnterRoomNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		[ProtoMember(3, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "vip", DataFormat = DataFormat.TwosComplement)]
		public uint vip
		{
			get
			{
				return this._vip ?? 0U;
			}
			set
			{
				this._vip = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool vipSpecified
		{
			get
			{
				return this._vip != null;
			}
			set
			{
				bool flag = value == (this._vip == null);
				if (flag)
				{
					this._vip = (value ? new uint?(this.vip) : null);
				}
			}
		}

		private bool ShouldSerializevip()
		{
			return this.vipSpecified;
		}

		private void Resetvip()
		{
			this.vipSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		private void Resettime()
		{
			this.timeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "coverDesignationID", DataFormat = DataFormat.TwosComplement)]
		public uint coverDesignationID
		{
			get
			{
				return this._coverDesignationID ?? 0U;
			}
			set
			{
				this._coverDesignationID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool coverDesignationIDSpecified
		{
			get
			{
				return this._coverDesignationID != null;
			}
			set
			{
				bool flag = value == (this._coverDesignationID == null);
				if (flag)
				{
					this._coverDesignationID = (value ? new uint?(this.coverDesignationID) : null);
				}
			}
		}

		private bool ShouldSerializecoverDesignationID()
		{
			return this.coverDesignationIDSpecified;
		}

		private void ResetcoverDesignationID()
		{
			this.coverDesignationIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleID;

		private string _name;

		private uint? _profession;

		private uint? _vip;

		private uint? _time;

		private uint? _coverDesignationID;

		private IExtension extensionObject;
	}
}

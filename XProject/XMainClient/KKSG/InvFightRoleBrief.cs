using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "InvFightRoleBrief")]
	[Serializable]
	public class InvFightRoleBrief : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "invID", DataFormat = DataFormat.TwosComplement)]
		public ulong invID
		{
			get
			{
				return this._invID ?? 0UL;
			}
			set
			{
				this._invID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool invIDSpecified
		{
			get
			{
				return this._invID != null;
			}
			set
			{
				bool flag = value == (this._invID == null);
				if (flag)
				{
					this._invID = (value ? new ulong?(this.invID) : null);
				}
			}
		}

		private bool ShouldSerializeinvID()
		{
			return this.invIDSpecified;
		}

		private void ResetinvID()
		{
			this.invIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "title", DataFormat = DataFormat.TwosComplement)]
		public uint title
		{
			get
			{
				return this._title ?? 0U;
			}
			set
			{
				this._title = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool titleSpecified
		{
			get
			{
				return this._title != null;
			}
			set
			{
				bool flag = value == (this._title == null);
				if (flag)
				{
					this._title = (value ? new uint?(this.title) : null);
				}
			}
		}

		private bool ShouldSerializetitle()
		{
			return this.titleSpecified;
		}

		private void Resettitle()
		{
			this.titleSpecified = false;
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

		[ProtoMember(5, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, IsRequired = false, Name = "ctime", DataFormat = DataFormat.TwosComplement)]
		public uint ctime
		{
			get
			{
				return this._ctime ?? 0U;
			}
			set
			{
				this._ctime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ctimeSpecified
		{
			get
			{
				return this._ctime != null;
			}
			set
			{
				bool flag = value == (this._ctime == null);
				if (flag)
				{
					this._ctime = (value ? new uint?(this.ctime) : null);
				}
			}
		}

		private bool ShouldSerializectime()
		{
			return this.ctimeSpecified;
		}

		private void Resetctime()
		{
			this.ctimeSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "isplatfriend", DataFormat = DataFormat.Default)]
		public bool isplatfriend
		{
			get
			{
				return this._isplatfriend ?? false;
			}
			set
			{
				this._isplatfriend = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isplatfriendSpecified
		{
			get
			{
				return this._isplatfriend != null;
			}
			set
			{
				bool flag = value == (this._isplatfriend == null);
				if (flag)
				{
					this._isplatfriend = (value ? new bool?(this.isplatfriend) : null);
				}
			}
		}

		private bool ShouldSerializeisplatfriend()
		{
			return this.isplatfriendSpecified;
		}

		private void Resetisplatfriend()
		{
			this.isplatfriendSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _invID;

		private uint? _title;

		private string _name;

		private uint? _level;

		private uint? _profession;

		private uint? _ctime;

		private bool? _isplatfriend;

		private IExtension extensionObject;
	}
}

using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CreateOrJoinGuild")]
	[Serializable]
	public class CreateOrJoinGuild : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "iscreate", DataFormat = DataFormat.Default)]
		public bool iscreate
		{
			get
			{
				return this._iscreate ?? false;
			}
			set
			{
				this._iscreate = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool iscreateSpecified
		{
			get
			{
				return this._iscreate != null;
			}
			set
			{
				bool flag = value == (this._iscreate == null);
				if (flag)
				{
					this._iscreate = (value ? new bool?(this.iscreate) : null);
				}
			}
		}

		private bool ShouldSerializeiscreate()
		{
			return this.iscreateSpecified;
		}

		private void Resetiscreate()
		{
			this.iscreateSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "gid", DataFormat = DataFormat.TwosComplement)]
		public ulong gid
		{
			get
			{
				return this._gid ?? 0UL;
			}
			set
			{
				this._gid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool gidSpecified
		{
			get
			{
				return this._gid != null;
			}
			set
			{
				bool flag = value == (this._gid == null);
				if (flag)
				{
					this._gid = (value ? new ulong?(this.gid) : null);
				}
			}
		}

		private bool ShouldSerializegid()
		{
			return this.gidSpecified;
		}

		private void Resetgid()
		{
			this.gidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "gname", DataFormat = DataFormat.Default)]
		public string gname
		{
			get
			{
				return this._gname ?? "";
			}
			set
			{
				this._gname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool gnameSpecified
		{
			get
			{
				return this._gname != null;
			}
			set
			{
				bool flag = value == (this._gname == null);
				if (flag)
				{
					this._gname = (value ? this.gname : null);
				}
			}
		}

		private bool ShouldSerializegname()
		{
			return this.gnameSpecified;
		}

		private void Resetgname()
		{
			this.gnameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "icon", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _iscreate;

		private ulong? _gid;

		private string _gname;

		private int? _icon;

		private IExtension extensionObject;
	}
}

using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FriendDegreeUpNtf")]
	[Serializable]
	public class FriendDegreeUpNtf : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "friendname", DataFormat = DataFormat.Default)]
		public string friendname
		{
			get
			{
				return this._friendname ?? "";
			}
			set
			{
				this._friendname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool friendnameSpecified
		{
			get
			{
				return this._friendname != null;
			}
			set
			{
				bool flag = value == (this._friendname == null);
				if (flag)
				{
					this._friendname = (value ? this.friendname : null);
				}
			}
		}

		private bool ShouldSerializefriendname()
		{
			return this.friendnameSpecified;
		}

		private void Resetfriendname()
		{
			this.friendnameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "orginlevel", DataFormat = DataFormat.TwosComplement)]
		public uint orginlevel
		{
			get
			{
				return this._orginlevel ?? 0U;
			}
			set
			{
				this._orginlevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool orginlevelSpecified
		{
			get
			{
				return this._orginlevel != null;
			}
			set
			{
				bool flag = value == (this._orginlevel == null);
				if (flag)
				{
					this._orginlevel = (value ? new uint?(this.orginlevel) : null);
				}
			}
		}

		private bool ShouldSerializeorginlevel()
		{
			return this.orginlevelSpecified;
		}

		private void Resetorginlevel()
		{
			this.orginlevelSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "currentlevel", DataFormat = DataFormat.TwosComplement)]
		public uint currentlevel
		{
			get
			{
				return this._currentlevel ?? 0U;
			}
			set
			{
				this._currentlevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool currentlevelSpecified
		{
			get
			{
				return this._currentlevel != null;
			}
			set
			{
				bool flag = value == (this._currentlevel == null);
				if (flag)
				{
					this._currentlevel = (value ? new uint?(this.currentlevel) : null);
				}
			}
		}

		private bool ShouldSerializecurrentlevel()
		{
			return this.currentlevelSpecified;
		}

		private void Resetcurrentlevel()
		{
			this.currentlevelSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "currentleft", DataFormat = DataFormat.TwosComplement)]
		public uint currentleft
		{
			get
			{
				return this._currentleft ?? 0U;
			}
			set
			{
				this._currentleft = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool currentleftSpecified
		{
			get
			{
				return this._currentleft != null;
			}
			set
			{
				bool flag = value == (this._currentleft == null);
				if (flag)
				{
					this._currentleft = (value ? new uint?(this.currentleft) : null);
				}
			}
		}

		private bool ShouldSerializecurrentleft()
		{
			return this.currentleftSpecified;
		}

		private void Resetcurrentleft()
		{
			this.currentleftSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "daydegree", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(7, IsRequired = false, Name = "alldegree", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private string _friendname;

		private uint? _orginlevel;

		private uint? _currentlevel;

		private uint? _currentleft;

		private uint? _daydegree;

		private uint? _alldegree;

		private IExtension extensionObject;
	}
}

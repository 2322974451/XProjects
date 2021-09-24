using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonGroupRoleInfo")]
	[Serializable]
	public class DragonGroupRoleInfo : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		private void Resetrolename()
		{
			this.rolenameSpecified = false;
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

		[ProtoMember(4, IsRequired = false, Name = "title", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, IsRequired = false, Name = "fighting", DataFormat = DataFormat.TwosComplement)]
		public uint fighting
		{
			get
			{
				return this._fighting ?? 0U;
			}
			set
			{
				this._fighting = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fightingSpecified
		{
			get
			{
				return this._fighting != null;
			}
			set
			{
				bool flag = value == (this._fighting == null);
				if (flag)
				{
					this._fighting = (value ? new uint?(this.fighting) : null);
				}
			}
		}

		private bool ShouldSerializefighting()
		{
			return this.fightingSpecified;
		}

		private void Resetfighting()
		{
			this.fightingSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "guild", DataFormat = DataFormat.Default)]
		public string guild
		{
			get
			{
				return this._guild ?? "";
			}
			set
			{
				this._guild = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildSpecified
		{
			get
			{
				return this._guild != null;
			}
			set
			{
				bool flag = value == (this._guild == null);
				if (flag)
				{
					this._guild = (value ? this.guild : null);
				}
			}
		}

		private bool ShouldSerializeguild()
		{
			return this.guildSpecified;
		}

		private void Resetguild()
		{
			this.guildSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public uint uid
		{
			get
			{
				return this._uid ?? 0U;
			}
			set
			{
				this._uid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new uint?(this.uid) : null);
				}
			}
		}

		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "stageID", DataFormat = DataFormat.TwosComplement)]
		public uint stageID
		{
			get
			{
				return this._stageID ?? 0U;
			}
			set
			{
				this._stageID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stageIDSpecified
		{
			get
			{
				return this._stageID != null;
			}
			set
			{
				bool flag = value == (this._stageID == null);
				if (flag)
				{
					this._stageID = (value ? new uint?(this.stageID) : null);
				}
			}
		}

		private bool ShouldSerializestageID()
		{
			return this.stageIDSpecified;
		}

		private void ResetstageID()
		{
			this.stageIDSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "stageTime", DataFormat = DataFormat.TwosComplement)]
		public uint stageTime
		{
			get
			{
				return this._stageTime ?? 0U;
			}
			set
			{
				this._stageTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stageTimeSpecified
		{
			get
			{
				return this._stageTime != null;
			}
			set
			{
				bool flag = value == (this._stageTime == null);
				if (flag)
				{
					this._stageTime = (value ? new uint?(this.stageTime) : null);
				}
			}
		}

		private bool ShouldSerializestageTime()
		{
			return this.stageTimeSpecified;
		}

		private void ResetstageTime()
		{
			this.stageTimeSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "stageCount", DataFormat = DataFormat.TwosComplement)]
		public uint stageCount
		{
			get
			{
				return this._stageCount ?? 0U;
			}
			set
			{
				this._stageCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stageCountSpecified
		{
			get
			{
				return this._stageCount != null;
			}
			set
			{
				bool flag = value == (this._stageCount == null);
				if (flag)
				{
					this._stageCount = (value ? new uint?(this.stageCount) : null);
				}
			}
		}

		private bool ShouldSerializestageCount()
		{
			return this.stageCountSpecified;
		}

		private void ResetstageCount()
		{
			this.stageCountSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "pre", DataFormat = DataFormat.Default)]
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

		private string _rolename;

		private uint? _profession;

		private uint? _title;

		private uint? _level;

		private uint? _fighting;

		private string _guild;

		private uint? _uid;

		private uint? _stageID;

		private uint? _stageTime;

		private uint? _stageCount;

		private PayConsume _pre = null;

		private IExtension extensionObject;
	}
}

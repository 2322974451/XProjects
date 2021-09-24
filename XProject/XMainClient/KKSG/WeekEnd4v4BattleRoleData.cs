using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeekEnd4v4BattleRoleData")]
	[Serializable]
	public class WeekEnd4v4BattleRoleData : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "redblue", DataFormat = DataFormat.TwosComplement)]
		public uint redblue
		{
			get
			{
				return this._redblue ?? 0U;
			}
			set
			{
				this._redblue = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool redblueSpecified
		{
			get
			{
				return this._redblue != null;
			}
			set
			{
				bool flag = value == (this._redblue == null);
				if (flag)
				{
					this._redblue = (value ? new uint?(this.redblue) : null);
				}
			}
		}

		private bool ShouldSerializeredblue()
		{
			return this.redblueSpecified;
		}

		private void Resetredblue()
		{
			this.redblueSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "killCount", DataFormat = DataFormat.TwosComplement)]
		public uint killCount
		{
			get
			{
				return this._killCount ?? 0U;
			}
			set
			{
				this._killCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killCountSpecified
		{
			get
			{
				return this._killCount != null;
			}
			set
			{
				bool flag = value == (this._killCount == null);
				if (flag)
				{
					this._killCount = (value ? new uint?(this.killCount) : null);
				}
			}
		}

		private bool ShouldSerializekillCount()
		{
			return this.killCountSpecified;
		}

		private void ResetkillCount()
		{
			this.killCountSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "bekilledCount", DataFormat = DataFormat.TwosComplement)]
		public uint bekilledCount
		{
			get
			{
				return this._bekilledCount ?? 0U;
			}
			set
			{
				this._bekilledCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bekilledCountSpecified
		{
			get
			{
				return this._bekilledCount != null;
			}
			set
			{
				bool flag = value == (this._bekilledCount == null);
				if (flag)
				{
					this._bekilledCount = (value ? new uint?(this.bekilledCount) : null);
				}
			}
		}

		private bool ShouldSerializebekilledCount()
		{
			return this.bekilledCountSpecified;
		}

		private void ResetbekilledCount()
		{
			this.bekilledCountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "timeSeconds", DataFormat = DataFormat.TwosComplement)]
		public uint timeSeconds
		{
			get
			{
				return this._timeSeconds ?? 0U;
			}
			set
			{
				this._timeSeconds = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeSecondsSpecified
		{
			get
			{
				return this._timeSeconds != null;
			}
			set
			{
				bool flag = value == (this._timeSeconds == null);
				if (flag)
				{
					this._timeSeconds = (value ? new uint?(this.timeSeconds) : null);
				}
			}
		}

		private bool ShouldSerializetimeSeconds()
		{
			return this.timeSecondsSpecified;
		}

		private void ResettimeSeconds()
		{
			this.timeSecondsSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
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

		[ProtoMember(8, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(9, IsRequired = false, Name = "rolelevel", DataFormat = DataFormat.TwosComplement)]
		public uint rolelevel
		{
			get
			{
				return this._rolelevel ?? 0U;
			}
			set
			{
				this._rolelevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rolelevelSpecified
		{
			get
			{
				return this._rolelevel != null;
			}
			set
			{
				bool flag = value == (this._rolelevel == null);
				if (flag)
				{
					this._rolelevel = (value ? new uint?(this.rolelevel) : null);
				}
			}
		}

		private bool ShouldSerializerolelevel()
		{
			return this.rolelevelSpecified;
		}

		private void Resetrolelevel()
		{
			this.rolelevelSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
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
					this._rank = (value ? new uint?(this.rank) : null);
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

		[ProtoMember(11, IsRequired = false, Name = "isline", DataFormat = DataFormat.Default)]
		public bool isline
		{
			get
			{
				return this._isline ?? false;
			}
			set
			{
				this._isline = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool islineSpecified
		{
			get
			{
				return this._isline != null;
			}
			set
			{
				bool flag = value == (this._isline == null);
				if (flag)
				{
					this._isline = (value ? new bool?(this.isline) : null);
				}
			}
		}

		private bool ShouldSerializeisline()
		{
			return this.islineSpecified;
		}

		private void Resetisline()
		{
			this.islineSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private uint? _redblue;

		private uint? _score;

		private uint? _killCount;

		private uint? _bekilledCount;

		private uint? _timeSeconds;

		private string _rolename;

		private uint? _profession;

		private uint? _rolelevel;

		private uint? _rank;

		private bool? _isline;

		private IExtension extensionObject;
	}
}

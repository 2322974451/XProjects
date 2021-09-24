using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeeklyTaskData")]
	[Serializable]
	public class WeeklyTaskData : IExtensible
	{

		[ProtoMember(1, Name = "tasks", DataFormat = DataFormat.Default)]
		public List<WeeklyTaskInfo> tasks
		{
			get
			{
				return this._tasks;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "accept_level", DataFormat = DataFormat.TwosComplement)]
		public uint accept_level
		{
			get
			{
				return this._accept_level ?? 0U;
			}
			set
			{
				this._accept_level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool accept_levelSpecified
		{
			get
			{
				return this._accept_level != null;
			}
			set
			{
				bool flag = value == (this._accept_level == null);
				if (flag)
				{
					this._accept_level = (value ? new uint?(this.accept_level) : null);
				}
			}
		}

		private bool ShouldSerializeaccept_level()
		{
			return this.accept_levelSpecified;
		}

		private void Resetaccept_level()
		{
			this.accept_levelSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "rewarded", DataFormat = DataFormat.Default)]
		public bool rewarded
		{
			get
			{
				return this._rewarded ?? false;
			}
			set
			{
				this._rewarded = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rewardedSpecified
		{
			get
			{
				return this._rewarded != null;
			}
			set
			{
				bool flag = value == (this._rewarded == null);
				if (flag)
				{
					this._rewarded = (value ? new bool?(this.rewarded) : null);
				}
			}
		}

		private bool ShouldSerializerewarded()
		{
			return this.rewardedSpecified;
		}

		private void Resetrewarded()
		{
			this.rewardedSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "askhelp_num", DataFormat = DataFormat.TwosComplement)]
		public uint askhelp_num
		{
			get
			{
				return this._askhelp_num ?? 0U;
			}
			set
			{
				this._askhelp_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool askhelp_numSpecified
		{
			get
			{
				return this._askhelp_num != null;
			}
			set
			{
				bool flag = value == (this._askhelp_num == null);
				if (flag)
				{
					this._askhelp_num = (value ? new uint?(this.askhelp_num) : null);
				}
			}
		}

		private bool ShouldSerializeaskhelp_num()
		{
			return this.askhelp_numSpecified;
		}

		private void Resetaskhelp_num()
		{
			this.askhelp_numSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "accept", DataFormat = DataFormat.Default)]
		public bool accept
		{
			get
			{
				return this._accept ?? false;
			}
			set
			{
				this._accept = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool acceptSpecified
		{
			get
			{
				return this._accept != null;
			}
			set
			{
				bool flag = value == (this._accept == null);
				if (flag)
				{
					this._accept = (value ? new bool?(this.accept) : null);
				}
			}
		}

		private bool ShouldSerializeaccept()
		{
			return this.acceptSpecified;
		}

		private void Resetaccept()
		{
			this.acceptSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "accept_count", DataFormat = DataFormat.TwosComplement)]
		public uint accept_count
		{
			get
			{
				return this._accept_count ?? 0U;
			}
			set
			{
				this._accept_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool accept_countSpecified
		{
			get
			{
				return this._accept_count != null;
			}
			set
			{
				bool flag = value == (this._accept_count == null);
				if (flag)
				{
					this._accept_count = (value ? new uint?(this.accept_count) : null);
				}
			}
		}

		private bool ShouldSerializeaccept_count()
		{
			return this.accept_countSpecified;
		}

		private void Resetaccept_count()
		{
			this.accept_countSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(8, Name = "rewarded_box", DataFormat = DataFormat.TwosComplement)]
		public List<uint> rewarded_box
		{
			get
			{
				return this._rewarded_box;
			}
		}

		[ProtoMember(9, Name = "helpinfo", DataFormat = DataFormat.Default)]
		public List<TaskHelpInfo> helpinfo
		{
			get
			{
				return this._helpinfo;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "free_refresh_count", DataFormat = DataFormat.TwosComplement)]
		public uint free_refresh_count
		{
			get
			{
				return this._free_refresh_count ?? 0U;
			}
			set
			{
				this._free_refresh_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool free_refresh_countSpecified
		{
			get
			{
				return this._free_refresh_count != null;
			}
			set
			{
				bool flag = value == (this._free_refresh_count == null);
				if (flag)
				{
					this._free_refresh_count = (value ? new uint?(this.free_refresh_count) : null);
				}
			}
		}

		private bool ShouldSerializefree_refresh_count()
		{
			return this.free_refresh_countSpecified;
		}

		private void Resetfree_refresh_count()
		{
			this.free_refresh_countSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<WeeklyTaskInfo> _tasks = new List<WeeklyTaskInfo>();

		private uint? _accept_level;

		private bool? _rewarded;

		private uint? _askhelp_num;

		private bool? _accept;

		private uint? _accept_count;

		private uint? _score;

		private readonly List<uint> _rewarded_box = new List<uint>();

		private readonly List<TaskHelpInfo> _helpinfo = new List<TaskHelpInfo>();

		private uint? _free_refresh_count;

		private IExtension extensionObject;
	}
}

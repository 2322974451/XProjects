using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetDailyTaskInfoRes")]
	[Serializable]
	public class GetDailyTaskInfoRes : IExtensible
	{

		[ProtoMember(1, Name = "task", DataFormat = DataFormat.Default)]
		public List<DailyTaskInfo> task
		{
			get
			{
				return this._task;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "is_rewarded", DataFormat = DataFormat.Default)]
		public bool is_rewarded
		{
			get
			{
				return this._is_rewarded ?? false;
			}
			set
			{
				this._is_rewarded = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool is_rewardedSpecified
		{
			get
			{
				return this._is_rewarded != null;
			}
			set
			{
				bool flag = value == (this._is_rewarded == null);
				if (flag)
				{
					this._is_rewarded = (value ? new bool?(this.is_rewarded) : null);
				}
			}
		}

		private bool ShouldSerializeis_rewarded()
		{
			return this.is_rewardedSpecified;
		}

		private void Resetis_rewarded()
		{
			this.is_rewardedSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		private void Resetcount()
		{
			this.countSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "accept_level", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = false, Name = "askhelp_num", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(6, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(7, IsRequired = false, Name = "remain_refresh_count", DataFormat = DataFormat.TwosComplement)]
		public uint remain_refresh_count
		{
			get
			{
				return this._remain_refresh_count ?? 0U;
			}
			set
			{
				this._remain_refresh_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool remain_refresh_countSpecified
		{
			get
			{
				return this._remain_refresh_count != null;
			}
			set
			{
				bool flag = value == (this._remain_refresh_count == null);
				if (flag)
				{
					this._remain_refresh_count = (value ? new uint?(this.remain_refresh_count) : null);
				}
			}
		}

		private bool ShouldSerializeremain_refresh_count()
		{
			return this.remain_refresh_countSpecified;
		}

		private void Resetremain_refresh_count()
		{
			this.remain_refresh_countSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "luck", DataFormat = DataFormat.TwosComplement)]
		public uint luck
		{
			get
			{
				return this._luck ?? 0U;
			}
			set
			{
				this._luck = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool luckSpecified
		{
			get
			{
				return this._luck != null;
			}
			set
			{
				bool flag = value == (this._luck == null);
				if (flag)
				{
					this._luck = (value ? new uint?(this.luck) : null);
				}
			}
		}

		private bool ShouldSerializeluck()
		{
			return this.luckSpecified;
		}

		private void Resetluck()
		{
			this.luckSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<DailyTaskInfo> _task = new List<DailyTaskInfo>();

		private bool? _is_rewarded;

		private uint? _count;

		private uint? _accept_level;

		private uint? _askhelp_num;

		private uint? _score;

		private uint? _remain_refresh_count;

		private uint? _luck;

		private IExtension extensionObject;
	}
}

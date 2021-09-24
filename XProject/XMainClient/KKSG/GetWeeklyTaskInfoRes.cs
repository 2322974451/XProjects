using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetWeeklyTaskInfoRes")]
	[Serializable]
	public class GetWeeklyTaskInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, Name = "task", DataFormat = DataFormat.Default)]
		public List<WeeklyTaskInfo> task
		{
			get
			{
				return this._task;
			}
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

		[ProtoMember(5, Name = "rewarded_box", DataFormat = DataFormat.TwosComplement)]
		public List<uint> rewarded_box
		{
			get
			{
				return this._rewarded_box;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "accept_level", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(7, Name = "helpinfo", DataFormat = DataFormat.Default)]
		public List<TaskHelpInfo> helpinfo
		{
			get
			{
				return this._helpinfo;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "remain_free_refresh_count", DataFormat = DataFormat.TwosComplement)]
		public uint remain_free_refresh_count
		{
			get
			{
				return this._remain_free_refresh_count ?? 0U;
			}
			set
			{
				this._remain_free_refresh_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool remain_free_refresh_countSpecified
		{
			get
			{
				return this._remain_free_refresh_count != null;
			}
			set
			{
				bool flag = value == (this._remain_free_refresh_count == null);
				if (flag)
				{
					this._remain_free_refresh_count = (value ? new uint?(this.remain_free_refresh_count) : null);
				}
			}
		}

		private bool ShouldSerializeremain_free_refresh_count()
		{
			return this.remain_free_refresh_countSpecified;
		}

		private void Resetremain_free_refresh_count()
		{
			this.remain_free_refresh_countSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private readonly List<WeeklyTaskInfo> _task = new List<WeeklyTaskInfo>();

		private uint? _score;

		private uint? _askhelp_num;

		private readonly List<uint> _rewarded_box = new List<uint>();

		private uint? _accept_level;

		private readonly List<TaskHelpInfo> _helpinfo = new List<TaskHelpInfo>();

		private uint? _lefttime;

		private uint? _remain_free_refresh_count;

		private IExtension extensionObject;
	}
}

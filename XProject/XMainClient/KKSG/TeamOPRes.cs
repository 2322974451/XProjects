using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamOPRes")]
	[Serializable]
	public class TeamOPRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "problem_roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong problem_roleid
		{
			get
			{
				return this._problem_roleid ?? 0UL;
			}
			set
			{
				this._problem_roleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool problem_roleidSpecified
		{
			get
			{
				return this._problem_roleid != null;
			}
			set
			{
				bool flag = value == (this._problem_roleid == null);
				if (flag)
				{
					this._problem_roleid = (value ? new ulong?(this.problem_roleid) : null);
				}
			}
		}

		private bool ShouldSerializeproblem_roleid()
		{
			return this.problem_roleidSpecified;
		}

		private void Resetproblem_roleid()
		{
			this.problem_roleidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "GoddessGetRewardsCount", DataFormat = DataFormat.TwosComplement)]
		public int GoddessGetRewardsCount
		{
			get
			{
				return this._GoddessGetRewardsCount ?? 0;
			}
			set
			{
				this._GoddessGetRewardsCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool GoddessGetRewardsCountSpecified
		{
			get
			{
				return this._GoddessGetRewardsCount != null;
			}
			set
			{
				bool flag = value == (this._GoddessGetRewardsCount == null);
				if (flag)
				{
					this._GoddessGetRewardsCount = (value ? new int?(this.GoddessGetRewardsCount) : null);
				}
			}
		}

		private bool ShouldSerializeGoddessGetRewardsCount()
		{
			return this.GoddessGetRewardsCountSpecified;
		}

		private void ResetGoddessGetRewardsCount()
		{
			this.GoddessGetRewardsCountSpecified = false;
		}

		[ProtoMember(4, Name = "teamcount", DataFormat = DataFormat.Default)]
		public List<TeamCountClient> teamcount
		{
			get
			{
				return this._teamcount;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "weeknestexpid", DataFormat = DataFormat.TwosComplement)]
		public int weeknestexpid
		{
			get
			{
				return this._weeknestexpid ?? 0;
			}
			set
			{
				this._weeknestexpid = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weeknestexpidSpecified
		{
			get
			{
				return this._weeknestexpid != null;
			}
			set
			{
				bool flag = value == (this._weeknestexpid == null);
				if (flag)
				{
					this._weeknestexpid = (value ? new int?(this.weeknestexpid) : null);
				}
			}
		}

		private bool ShouldSerializeweeknestexpid()
		{
			return this.weeknestexpidSpecified;
		}

		private void Resetweeknestexpid()
		{
			this.weeknestexpidSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "opentime", DataFormat = DataFormat.TwosComplement)]
		public uint opentime
		{
			get
			{
				return this._opentime ?? 0U;
			}
			set
			{
				this._opentime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool opentimeSpecified
		{
			get
			{
				return this._opentime != null;
			}
			set
			{
				bool flag = value == (this._opentime == null);
				if (flag)
				{
					this._opentime = (value ? new uint?(this.opentime) : null);
				}
			}
		}

		private bool ShouldSerializeopentime()
		{
			return this.opentimeSpecified;
		}

		private void Resetopentime()
		{
			this.opentimeSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "wnrewardleftcount", DataFormat = DataFormat.TwosComplement)]
		public uint wnrewardleftcount
		{
			get
			{
				return this._wnrewardleftcount ?? 0U;
			}
			set
			{
				this._wnrewardleftcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool wnrewardleftcountSpecified
		{
			get
			{
				return this._wnrewardleftcount != null;
			}
			set
			{
				bool flag = value == (this._wnrewardleftcount == null);
				if (flag)
				{
					this._wnrewardleftcount = (value ? new uint?(this.wnrewardleftcount) : null);
				}
			}
		}

		private bool ShouldSerializewnrewardleftcount()
		{
			return this.wnrewardleftcountSpecified;
		}

		private void Resetwnrewardleftcount()
		{
			this.wnrewardleftcountSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "wnrewardmaxcount", DataFormat = DataFormat.TwosComplement)]
		public uint wnrewardmaxcount
		{
			get
			{
				return this._wnrewardmaxcount ?? 0U;
			}
			set
			{
				this._wnrewardmaxcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool wnrewardmaxcountSpecified
		{
			get
			{
				return this._wnrewardmaxcount != null;
			}
			set
			{
				bool flag = value == (this._wnrewardmaxcount == null);
				if (flag)
				{
					this._wnrewardmaxcount = (value ? new uint?(this.wnrewardmaxcount) : null);
				}
			}
		}

		private bool ShouldSerializewnrewardmaxcount()
		{
			return this.wnrewardmaxcountSpecified;
		}

		private void Resetwnrewardmaxcount()
		{
			this.wnrewardmaxcountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private ulong? _problem_roleid;

		private int? _GoddessGetRewardsCount;

		private readonly List<TeamCountClient> _teamcount = new List<TeamCountClient>();

		private int? _weeknestexpid;

		private uint? _opentime;

		private uint? _wnrewardleftcount;

		private uint? _wnrewardmaxcount;

		private IExtension extensionObject;
	}
}

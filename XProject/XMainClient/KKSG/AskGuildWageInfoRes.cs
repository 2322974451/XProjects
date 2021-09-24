using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AskGuildWageInfoRes")]
	[Serializable]
	public class AskGuildWageInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "activity", DataFormat = DataFormat.TwosComplement)]
		public uint activity
		{
			get
			{
				return this._activity ?? 0U;
			}
			set
			{
				this._activity = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool activitySpecified
		{
			get
			{
				return this._activity != null;
			}
			set
			{
				bool flag = value == (this._activity == null);
				if (flag)
				{
					this._activity = (value ? new uint?(this.activity) : null);
				}
			}
		}

		private bool ShouldSerializeactivity()
		{
			return this.activitySpecified;
		}

		private void Resetactivity()
		{
			this.activitySpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "rolenum", DataFormat = DataFormat.TwosComplement)]
		public uint rolenum
		{
			get
			{
				return this._rolenum ?? 0U;
			}
			set
			{
				this._rolenum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rolenumSpecified
		{
			get
			{
				return this._rolenum != null;
			}
			set
			{
				bool flag = value == (this._rolenum == null);
				if (flag)
				{
					this._rolenum = (value ? new uint?(this.rolenum) : null);
				}
			}
		}

		private bool ShouldSerializerolenum()
		{
			return this.rolenumSpecified;
		}

		private void Resetrolenum()
		{
			this.rolenumSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "prestige", DataFormat = DataFormat.TwosComplement)]
		public uint prestige
		{
			get
			{
				return this._prestige ?? 0U;
			}
			set
			{
				this._prestige = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool prestigeSpecified
		{
			get
			{
				return this._prestige != null;
			}
			set
			{
				bool flag = value == (this._prestige == null);
				if (flag)
				{
					this._prestige = (value ? new uint?(this.prestige) : null);
				}
			}
		}

		private bool ShouldSerializeprestige()
		{
			return this.prestigeSpecified;
		}

		private void Resetprestige()
		{
			this.prestigeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public uint exp
		{
			get
			{
				return this._exp ?? 0U;
			}
			set
			{
				this._exp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new uint?(this.exp) : null);
				}
			}
		}

		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		private void Resetexp()
		{
			this.expSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "lastScore", DataFormat = DataFormat.TwosComplement)]
		public uint lastScore
		{
			get
			{
				return this._lastScore ?? 0U;
			}
			set
			{
				this._lastScore = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastScoreSpecified
		{
			get
			{
				return this._lastScore != null;
			}
			set
			{
				bool flag = value == (this._lastScore == null);
				if (flag)
				{
					this._lastScore = (value ? new uint?(this.lastScore) : null);
				}
			}
		}

		private bool ShouldSerializelastScore()
		{
			return this.lastScoreSpecified;
		}

		private void ResetlastScore()
		{
			this.lastScoreSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "rewardstate", DataFormat = DataFormat.TwosComplement)]
		public WageRewardState rewardstate
		{
			get
			{
				return this._rewardstate ?? WageRewardState.cannot;
			}
			set
			{
				this._rewardstate = new WageRewardState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rewardstateSpecified
		{
			get
			{
				return this._rewardstate != null;
			}
			set
			{
				bool flag = value == (this._rewardstate == null);
				if (flag)
				{
					this._rewardstate = (value ? new WageRewardState?(this.rewardstate) : null);
				}
			}
		}

		private bool ShouldSerializerewardstate()
		{
			return this.rewardstateSpecified;
		}

		private void Resetrewardstate()
		{
			this.rewardstateSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "wagelvl", DataFormat = DataFormat.TwosComplement)]
		public uint wagelvl
		{
			get
			{
				return this._wagelvl ?? 0U;
			}
			set
			{
				this._wagelvl = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool wagelvlSpecified
		{
			get
			{
				return this._wagelvl != null;
			}
			set
			{
				bool flag = value == (this._wagelvl == null);
				if (flag)
				{
					this._wagelvl = (value ? new uint?(this.wagelvl) : null);
				}
			}
		}

		private bool ShouldSerializewagelvl()
		{
			return this.wagelvlSpecified;
		}

		private void Resetwagelvl()
		{
			this.wagelvlSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "guildlvl", DataFormat = DataFormat.TwosComplement)]
		public uint guildlvl
		{
			get
			{
				return this._guildlvl ?? 0U;
			}
			set
			{
				this._guildlvl = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildlvlSpecified
		{
			get
			{
				return this._guildlvl != null;
			}
			set
			{
				bool flag = value == (this._guildlvl == null);
				if (flag)
				{
					this._guildlvl = (value ? new uint?(this.guildlvl) : null);
				}
			}
		}

		private bool ShouldSerializeguildlvl()
		{
			return this.guildlvlSpecified;
		}

		private void Resetguildlvl()
		{
			this.guildlvlSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "lastposition", DataFormat = DataFormat.TwosComplement)]
		public uint lastposition
		{
			get
			{
				return this._lastposition ?? 0U;
			}
			set
			{
				this._lastposition = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastpositionSpecified
		{
			get
			{
				return this._lastposition != null;
			}
			set
			{
				bool flag = value == (this._lastposition == null);
				if (flag)
				{
					this._lastposition = (value ? new uint?(this.lastposition) : null);
				}
			}
		}

		private bool ShouldSerializelastposition()
		{
			return this.lastpositionSpecified;
		}

		private void Resetlastposition()
		{
			this.lastpositionSpecified = false;
		}

		[ProtoMember(11, Name = "name", DataFormat = DataFormat.Default)]
		public List<string> name
		{
			get
			{
				return this._name;
			}
		}

		[ProtoMember(12, Name = "roles", DataFormat = DataFormat.Default)]
		public List<GuildActivityRole> roles
		{
			get
			{
				return this._roles;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _activity;

		private uint? _rolenum;

		private uint? _prestige;

		private uint? _exp;

		private uint? _lastScore;

		private WageRewardState? _rewardstate;

		private uint? _wagelvl;

		private uint? _guildlvl;

		private ErrorCode? _errorcode;

		private uint? _lastposition;

		private readonly List<string> _name = new List<string>();

		private readonly List<GuildActivityRole> _roles = new List<GuildActivityRole>();

		private IExtension extensionObject;
	}
}

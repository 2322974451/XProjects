using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetHeroBattleInfoRes")]
	[Serializable]
	public class GetHeroBattleInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, Name = "havehero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> havehero
		{
			get
			{
				return this._havehero;
			}
		}

		[ProtoMember(3, Name = "weekhero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> weekhero
		{
			get
			{
				return this._weekhero;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "winthisweek", DataFormat = DataFormat.TwosComplement)]
		public uint winthisweek
		{
			get
			{
				return this._winthisweek ?? 0U;
			}
			set
			{
				this._winthisweek = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winthisweekSpecified
		{
			get
			{
				return this._winthisweek != null;
			}
			set
			{
				bool flag = value == (this._winthisweek == null);
				if (flag)
				{
					this._winthisweek = (value ? new uint?(this.winthisweek) : null);
				}
			}
		}

		private bool ShouldSerializewinthisweek()
		{
			return this.winthisweekSpecified;
		}

		private void Resetwinthisweek()
		{
			this.winthisweekSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "totalnum", DataFormat = DataFormat.TwosComplement)]
		public uint totalnum
		{
			get
			{
				return this._totalnum ?? 0U;
			}
			set
			{
				this._totalnum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalnumSpecified
		{
			get
			{
				return this._totalnum != null;
			}
			set
			{
				bool flag = value == (this._totalnum == null);
				if (flag)
				{
					this._totalnum = (value ? new uint?(this.totalnum) : null);
				}
			}
		}

		private bool ShouldSerializetotalnum()
		{
			return this.totalnumSpecified;
		}

		private void Resettotalnum()
		{
			this.totalnumSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "winnum", DataFormat = DataFormat.TwosComplement)]
		public uint winnum
		{
			get
			{
				return this._winnum ?? 0U;
			}
			set
			{
				this._winnum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winnumSpecified
		{
			get
			{
				return this._winnum != null;
			}
			set
			{
				bool flag = value == (this._winnum == null);
				if (flag)
				{
					this._winnum = (value ? new uint?(this.winnum) : null);
				}
			}
		}

		private bool ShouldSerializewinnum()
		{
			return this.winnumSpecified;
		}

		private void Resetwinnum()
		{
			this.winnumSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "losenum", DataFormat = DataFormat.TwosComplement)]
		public uint losenum
		{
			get
			{
				return this._losenum ?? 0U;
			}
			set
			{
				this._losenum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool losenumSpecified
		{
			get
			{
				return this._losenum != null;
			}
			set
			{
				bool flag = value == (this._losenum == null);
				if (flag)
				{
					this._losenum = (value ? new uint?(this.losenum) : null);
				}
			}
		}

		private bool ShouldSerializelosenum()
		{
			return this.losenumSpecified;
		}

		private void Resetlosenum()
		{
			this.losenumSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "todaygetspcount", DataFormat = DataFormat.TwosComplement)]
		public uint todaygetspcount
		{
			get
			{
				return this._todaygetspcount ?? 0U;
			}
			set
			{
				this._todaygetspcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool todaygetspcountSpecified
		{
			get
			{
				return this._todaygetspcount != null;
			}
			set
			{
				bool flag = value == (this._todaygetspcount == null);
				if (flag)
				{
					this._todaygetspcount = (value ? new uint?(this.todaygetspcount) : null);
				}
			}
		}

		private bool ShouldSerializetodaygetspcount()
		{
			return this.todaygetspcountSpecified;
		}

		private void Resettodaygetspcount()
		{
			this.todaygetspcountSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "weekprize", DataFormat = DataFormat.TwosComplement)]
		public uint weekprize
		{
			get
			{
				return this._weekprize ?? 0U;
			}
			set
			{
				this._weekprize = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekprizeSpecified
		{
			get
			{
				return this._weekprize != null;
			}
			set
			{
				bool flag = value == (this._weekprize == null);
				if (flag)
				{
					this._weekprize = (value ? new uint?(this.weekprize) : null);
				}
			}
		}

		private bool ShouldSerializeweekprize()
		{
			return this.weekprizeSpecified;
		}

		private void Resetweekprize()
		{
			this.weekprizeSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "cangetprize", DataFormat = DataFormat.Default)]
		public bool cangetprize
		{
			get
			{
				return this._cangetprize ?? false;
			}
			set
			{
				this._cangetprize = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cangetprizeSpecified
		{
			get
			{
				return this._cangetprize != null;
			}
			set
			{
				bool flag = value == (this._cangetprize == null);
				if (flag)
				{
					this._cangetprize = (value ? new bool?(this.cangetprize) : null);
				}
			}
		}

		private bool ShouldSerializecangetprize()
		{
			return this.cangetprizeSpecified;
		}

		private void Resetcangetprize()
		{
			this.cangetprizeSpecified = false;
		}

		[ProtoMember(11, Name = "experiencehero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> experiencehero
		{
			get
			{
				return this._experiencehero;
			}
		}

		[ProtoMember(12, Name = "experienceherolefttime", DataFormat = DataFormat.TwosComplement)]
		public List<uint> experienceherolefttime
		{
			get
			{
				return this._experienceherolefttime;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private readonly List<uint> _havehero = new List<uint>();

		private readonly List<uint> _weekhero = new List<uint>();

		private uint? _winthisweek;

		private uint? _totalnum;

		private uint? _winnum;

		private uint? _losenum;

		private uint? _todaygetspcount;

		private uint? _weekprize;

		private bool? _cangetprize;

		private readonly List<uint> _experiencehero = new List<uint>();

		private readonly List<uint> _experienceherolefttime = new List<uint>();

		private IExtension extensionObject;
	}
}

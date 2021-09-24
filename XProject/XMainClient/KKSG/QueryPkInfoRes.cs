using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QueryPkInfoRes")]
	[Serializable]
	public class QueryPkInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "rank1v1", DataFormat = DataFormat.TwosComplement)]
		public uint rank1v1
		{
			get
			{
				return this._rank1v1 ?? 0U;
			}
			set
			{
				this._rank1v1 = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rank1v1Specified
		{
			get
			{
				return this._rank1v1 != null;
			}
			set
			{
				bool flag = value == (this._rank1v1 == null);
				if (flag)
				{
					this._rank1v1 = (value ? new uint?(this.rank1v1) : null);
				}
			}
		}

		private bool ShouldSerializerank1v1()
		{
			return this.rank1v1Specified;
		}

		private void Resetrank1v1()
		{
			this.rank1v1Specified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "rewardcount", DataFormat = DataFormat.TwosComplement)]
		public uint rewardcount
		{
			get
			{
				return this._rewardcount ?? 0U;
			}
			set
			{
				this._rewardcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rewardcountSpecified
		{
			get
			{
				return this._rewardcount != null;
			}
			set
			{
				bool flag = value == (this._rewardcount == null);
				if (flag)
				{
					this._rewardcount = (value ? new uint?(this.rewardcount) : null);
				}
			}
		}

		private bool ShouldSerializerewardcount()
		{
			return this.rewardcountSpecified;
		}

		private void Resetrewardcount()
		{
			this.rewardcountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkRecord info
		{
			get
			{
				return this._info;
			}
			set
			{
				this._info = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "timelimit", DataFormat = DataFormat.TwosComplement)]
		public uint timelimit
		{
			get
			{
				return this._timelimit ?? 0U;
			}
			set
			{
				this._timelimit = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timelimitSpecified
		{
			get
			{
				return this._timelimit != null;
			}
			set
			{
				bool flag = value == (this._timelimit == null);
				if (flag)
				{
					this._timelimit = (value ? new uint?(this.timelimit) : null);
				}
			}
		}

		private bool ShouldSerializetimelimit()
		{
			return this.timelimitSpecified;
		}

		private void Resettimelimit()
		{
			this.timelimitSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "rankrewardleftT", DataFormat = DataFormat.TwosComplement)]
		public uint rankrewardleftT
		{
			get
			{
				return this._rankrewardleftT ?? 0U;
			}
			set
			{
				this._rankrewardleftT = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rankrewardleftTSpecified
		{
			get
			{
				return this._rankrewardleftT != null;
			}
			set
			{
				bool flag = value == (this._rankrewardleftT == null);
				if (flag)
				{
					this._rankrewardleftT = (value ? new uint?(this.rankrewardleftT) : null);
				}
			}
		}

		private bool ShouldSerializerankrewardleftT()
		{
			return this.rankrewardleftTSpecified;
		}

		private void ResetrankrewardleftT()
		{
			this.rankrewardleftTSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "rank2v2", DataFormat = DataFormat.TwosComplement)]
		public uint rank2v2
		{
			get
			{
				return this._rank2v2 ?? 0U;
			}
			set
			{
				this._rank2v2 = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rank2v2Specified
		{
			get
			{
				return this._rank2v2 != null;
			}
			set
			{
				bool flag = value == (this._rank2v2 == null);
				if (flag)
				{
					this._rank2v2 = (value ? new uint?(this.rank2v2) : null);
				}
			}
		}

		private bool ShouldSerializerank2v2()
		{
			return this.rank2v2Specified;
		}

		private void Resetrank2v2()
		{
			this.rank2v2Specified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _rank1v1;

		private uint? _rewardcount;

		private PkRecord _info = null;

		private uint? _timelimit;

		private uint? _rankrewardleftT;

		private uint? _rank2v2;

		private IExtension extensionObject;
	}
}

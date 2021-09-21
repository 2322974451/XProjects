using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006A0 RID: 1696
	[ProtoContract(Name = "QueryPkInfoRes")]
	[Serializable]
	public class QueryPkInfoRes : IExtensible
	{
		// Token: 0x170022EF RID: 8943
		// (get) Token: 0x06006E62 RID: 28258 RVA: 0x000D3368 File Offset: 0x000D1568
		// (set) Token: 0x06006E63 RID: 28259 RVA: 0x000D3394 File Offset: 0x000D1594
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

		// Token: 0x170022F0 RID: 8944
		// (get) Token: 0x06006E64 RID: 28260 RVA: 0x000D33A4 File Offset: 0x000D15A4
		// (set) Token: 0x06006E65 RID: 28261 RVA: 0x000D33C4 File Offset: 0x000D15C4
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

		// Token: 0x06006E66 RID: 28262 RVA: 0x000D3408 File Offset: 0x000D1608
		private bool ShouldSerializerank1v1()
		{
			return this.rank1v1Specified;
		}

		// Token: 0x06006E67 RID: 28263 RVA: 0x000D3420 File Offset: 0x000D1620
		private void Resetrank1v1()
		{
			this.rank1v1Specified = false;
		}

		// Token: 0x170022F1 RID: 8945
		// (get) Token: 0x06006E68 RID: 28264 RVA: 0x000D342C File Offset: 0x000D162C
		// (set) Token: 0x06006E69 RID: 28265 RVA: 0x000D3458 File Offset: 0x000D1658
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

		// Token: 0x170022F2 RID: 8946
		// (get) Token: 0x06006E6A RID: 28266 RVA: 0x000D3468 File Offset: 0x000D1668
		// (set) Token: 0x06006E6B RID: 28267 RVA: 0x000D3488 File Offset: 0x000D1688
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

		// Token: 0x06006E6C RID: 28268 RVA: 0x000D34CC File Offset: 0x000D16CC
		private bool ShouldSerializerewardcount()
		{
			return this.rewardcountSpecified;
		}

		// Token: 0x06006E6D RID: 28269 RVA: 0x000D34E4 File Offset: 0x000D16E4
		private void Resetrewardcount()
		{
			this.rewardcountSpecified = false;
		}

		// Token: 0x170022F3 RID: 8947
		// (get) Token: 0x06006E6E RID: 28270 RVA: 0x000D34F0 File Offset: 0x000D16F0
		// (set) Token: 0x06006E6F RID: 28271 RVA: 0x000D3508 File Offset: 0x000D1708
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

		// Token: 0x170022F4 RID: 8948
		// (get) Token: 0x06006E70 RID: 28272 RVA: 0x000D3514 File Offset: 0x000D1714
		// (set) Token: 0x06006E71 RID: 28273 RVA: 0x000D3540 File Offset: 0x000D1740
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

		// Token: 0x170022F5 RID: 8949
		// (get) Token: 0x06006E72 RID: 28274 RVA: 0x000D3550 File Offset: 0x000D1750
		// (set) Token: 0x06006E73 RID: 28275 RVA: 0x000D3570 File Offset: 0x000D1770
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

		// Token: 0x06006E74 RID: 28276 RVA: 0x000D35B4 File Offset: 0x000D17B4
		private bool ShouldSerializetimelimit()
		{
			return this.timelimitSpecified;
		}

		// Token: 0x06006E75 RID: 28277 RVA: 0x000D35CC File Offset: 0x000D17CC
		private void Resettimelimit()
		{
			this.timelimitSpecified = false;
		}

		// Token: 0x170022F6 RID: 8950
		// (get) Token: 0x06006E76 RID: 28278 RVA: 0x000D35D8 File Offset: 0x000D17D8
		// (set) Token: 0x06006E77 RID: 28279 RVA: 0x000D3604 File Offset: 0x000D1804
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

		// Token: 0x170022F7 RID: 8951
		// (get) Token: 0x06006E78 RID: 28280 RVA: 0x000D3614 File Offset: 0x000D1814
		// (set) Token: 0x06006E79 RID: 28281 RVA: 0x000D3634 File Offset: 0x000D1834
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

		// Token: 0x06006E7A RID: 28282 RVA: 0x000D3678 File Offset: 0x000D1878
		private bool ShouldSerializerankrewardleftT()
		{
			return this.rankrewardleftTSpecified;
		}

		// Token: 0x06006E7B RID: 28283 RVA: 0x000D3690 File Offset: 0x000D1890
		private void ResetrankrewardleftT()
		{
			this.rankrewardleftTSpecified = false;
		}

		// Token: 0x170022F8 RID: 8952
		// (get) Token: 0x06006E7C RID: 28284 RVA: 0x000D369C File Offset: 0x000D189C
		// (set) Token: 0x06006E7D RID: 28285 RVA: 0x000D36C8 File Offset: 0x000D18C8
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

		// Token: 0x170022F9 RID: 8953
		// (get) Token: 0x06006E7E RID: 28286 RVA: 0x000D36D8 File Offset: 0x000D18D8
		// (set) Token: 0x06006E7F RID: 28287 RVA: 0x000D36F8 File Offset: 0x000D18F8
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

		// Token: 0x06006E80 RID: 28288 RVA: 0x000D373C File Offset: 0x000D193C
		private bool ShouldSerializerank2v2()
		{
			return this.rank2v2Specified;
		}

		// Token: 0x06006E81 RID: 28289 RVA: 0x000D3754 File Offset: 0x000D1954
		private void Resetrank2v2()
		{
			this.rank2v2Specified = false;
		}

		// Token: 0x06006E82 RID: 28290 RVA: 0x000D3760 File Offset: 0x000D1960
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A6C RID: 6764
		private uint? _rank1v1;

		// Token: 0x04001A6D RID: 6765
		private uint? _rewardcount;

		// Token: 0x04001A6E RID: 6766
		private PkRecord _info = null;

		// Token: 0x04001A6F RID: 6767
		private uint? _timelimit;

		// Token: 0x04001A70 RID: 6768
		private uint? _rankrewardleftT;

		// Token: 0x04001A71 RID: 6769
		private uint? _rank2v2;

		// Token: 0x04001A72 RID: 6770
		private IExtension extensionObject;
	}
}

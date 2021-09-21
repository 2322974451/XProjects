using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000321 RID: 801
	[ProtoContract(Name = "GetHeroBattleInfoRes")]
	[Serializable]
	public class GetHeroBattleInfoRes : IExtensible
	{
		// Token: 0x17000D9A RID: 3482
		// (get) Token: 0x06002BEA RID: 11242 RVA: 0x0005510C File Offset: 0x0005330C
		// (set) Token: 0x06002BEB RID: 11243 RVA: 0x00055138 File Offset: 0x00053338
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

		// Token: 0x17000D9B RID: 3483
		// (get) Token: 0x06002BEC RID: 11244 RVA: 0x00055148 File Offset: 0x00053348
		// (set) Token: 0x06002BED RID: 11245 RVA: 0x00055168 File Offset: 0x00053368
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

		// Token: 0x06002BEE RID: 11246 RVA: 0x000551AC File Offset: 0x000533AC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002BEF RID: 11247 RVA: 0x000551C4 File Offset: 0x000533C4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000D9C RID: 3484
		// (get) Token: 0x06002BF0 RID: 11248 RVA: 0x000551D0 File Offset: 0x000533D0
		[ProtoMember(2, Name = "havehero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> havehero
		{
			get
			{
				return this._havehero;
			}
		}

		// Token: 0x17000D9D RID: 3485
		// (get) Token: 0x06002BF1 RID: 11249 RVA: 0x000551E8 File Offset: 0x000533E8
		[ProtoMember(3, Name = "weekhero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> weekhero
		{
			get
			{
				return this._weekhero;
			}
		}

		// Token: 0x17000D9E RID: 3486
		// (get) Token: 0x06002BF2 RID: 11250 RVA: 0x00055200 File Offset: 0x00053400
		// (set) Token: 0x06002BF3 RID: 11251 RVA: 0x0005522C File Offset: 0x0005342C
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

		// Token: 0x17000D9F RID: 3487
		// (get) Token: 0x06002BF4 RID: 11252 RVA: 0x0005523C File Offset: 0x0005343C
		// (set) Token: 0x06002BF5 RID: 11253 RVA: 0x0005525C File Offset: 0x0005345C
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

		// Token: 0x06002BF6 RID: 11254 RVA: 0x000552A0 File Offset: 0x000534A0
		private bool ShouldSerializewinthisweek()
		{
			return this.winthisweekSpecified;
		}

		// Token: 0x06002BF7 RID: 11255 RVA: 0x000552B8 File Offset: 0x000534B8
		private void Resetwinthisweek()
		{
			this.winthisweekSpecified = false;
		}

		// Token: 0x17000DA0 RID: 3488
		// (get) Token: 0x06002BF8 RID: 11256 RVA: 0x000552C4 File Offset: 0x000534C4
		// (set) Token: 0x06002BF9 RID: 11257 RVA: 0x000552F0 File Offset: 0x000534F0
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

		// Token: 0x17000DA1 RID: 3489
		// (get) Token: 0x06002BFA RID: 11258 RVA: 0x00055300 File Offset: 0x00053500
		// (set) Token: 0x06002BFB RID: 11259 RVA: 0x00055320 File Offset: 0x00053520
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

		// Token: 0x06002BFC RID: 11260 RVA: 0x00055364 File Offset: 0x00053564
		private bool ShouldSerializetotalnum()
		{
			return this.totalnumSpecified;
		}

		// Token: 0x06002BFD RID: 11261 RVA: 0x0005537C File Offset: 0x0005357C
		private void Resettotalnum()
		{
			this.totalnumSpecified = false;
		}

		// Token: 0x17000DA2 RID: 3490
		// (get) Token: 0x06002BFE RID: 11262 RVA: 0x00055388 File Offset: 0x00053588
		// (set) Token: 0x06002BFF RID: 11263 RVA: 0x000553B4 File Offset: 0x000535B4
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

		// Token: 0x17000DA3 RID: 3491
		// (get) Token: 0x06002C00 RID: 11264 RVA: 0x000553C4 File Offset: 0x000535C4
		// (set) Token: 0x06002C01 RID: 11265 RVA: 0x000553E4 File Offset: 0x000535E4
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

		// Token: 0x06002C02 RID: 11266 RVA: 0x00055428 File Offset: 0x00053628
		private bool ShouldSerializewinnum()
		{
			return this.winnumSpecified;
		}

		// Token: 0x06002C03 RID: 11267 RVA: 0x00055440 File Offset: 0x00053640
		private void Resetwinnum()
		{
			this.winnumSpecified = false;
		}

		// Token: 0x17000DA4 RID: 3492
		// (get) Token: 0x06002C04 RID: 11268 RVA: 0x0005544C File Offset: 0x0005364C
		// (set) Token: 0x06002C05 RID: 11269 RVA: 0x00055478 File Offset: 0x00053678
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

		// Token: 0x17000DA5 RID: 3493
		// (get) Token: 0x06002C06 RID: 11270 RVA: 0x00055488 File Offset: 0x00053688
		// (set) Token: 0x06002C07 RID: 11271 RVA: 0x000554A8 File Offset: 0x000536A8
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

		// Token: 0x06002C08 RID: 11272 RVA: 0x000554EC File Offset: 0x000536EC
		private bool ShouldSerializelosenum()
		{
			return this.losenumSpecified;
		}

		// Token: 0x06002C09 RID: 11273 RVA: 0x00055504 File Offset: 0x00053704
		private void Resetlosenum()
		{
			this.losenumSpecified = false;
		}

		// Token: 0x17000DA6 RID: 3494
		// (get) Token: 0x06002C0A RID: 11274 RVA: 0x00055510 File Offset: 0x00053710
		// (set) Token: 0x06002C0B RID: 11275 RVA: 0x0005553C File Offset: 0x0005373C
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

		// Token: 0x17000DA7 RID: 3495
		// (get) Token: 0x06002C0C RID: 11276 RVA: 0x0005554C File Offset: 0x0005374C
		// (set) Token: 0x06002C0D RID: 11277 RVA: 0x0005556C File Offset: 0x0005376C
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

		// Token: 0x06002C0E RID: 11278 RVA: 0x000555B0 File Offset: 0x000537B0
		private bool ShouldSerializetodaygetspcount()
		{
			return this.todaygetspcountSpecified;
		}

		// Token: 0x06002C0F RID: 11279 RVA: 0x000555C8 File Offset: 0x000537C8
		private void Resettodaygetspcount()
		{
			this.todaygetspcountSpecified = false;
		}

		// Token: 0x17000DA8 RID: 3496
		// (get) Token: 0x06002C10 RID: 11280 RVA: 0x000555D4 File Offset: 0x000537D4
		// (set) Token: 0x06002C11 RID: 11281 RVA: 0x00055600 File Offset: 0x00053800
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

		// Token: 0x17000DA9 RID: 3497
		// (get) Token: 0x06002C12 RID: 11282 RVA: 0x00055610 File Offset: 0x00053810
		// (set) Token: 0x06002C13 RID: 11283 RVA: 0x00055630 File Offset: 0x00053830
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

		// Token: 0x06002C14 RID: 11284 RVA: 0x00055674 File Offset: 0x00053874
		private bool ShouldSerializeweekprize()
		{
			return this.weekprizeSpecified;
		}

		// Token: 0x06002C15 RID: 11285 RVA: 0x0005568C File Offset: 0x0005388C
		private void Resetweekprize()
		{
			this.weekprizeSpecified = false;
		}

		// Token: 0x17000DAA RID: 3498
		// (get) Token: 0x06002C16 RID: 11286 RVA: 0x00055698 File Offset: 0x00053898
		// (set) Token: 0x06002C17 RID: 11287 RVA: 0x000556C4 File Offset: 0x000538C4
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

		// Token: 0x17000DAB RID: 3499
		// (get) Token: 0x06002C18 RID: 11288 RVA: 0x000556D4 File Offset: 0x000538D4
		// (set) Token: 0x06002C19 RID: 11289 RVA: 0x000556F4 File Offset: 0x000538F4
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

		// Token: 0x06002C1A RID: 11290 RVA: 0x00055738 File Offset: 0x00053938
		private bool ShouldSerializecangetprize()
		{
			return this.cangetprizeSpecified;
		}

		// Token: 0x06002C1B RID: 11291 RVA: 0x00055750 File Offset: 0x00053950
		private void Resetcangetprize()
		{
			this.cangetprizeSpecified = false;
		}

		// Token: 0x17000DAC RID: 3500
		// (get) Token: 0x06002C1C RID: 11292 RVA: 0x0005575C File Offset: 0x0005395C
		[ProtoMember(11, Name = "experiencehero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> experiencehero
		{
			get
			{
				return this._experiencehero;
			}
		}

		// Token: 0x17000DAD RID: 3501
		// (get) Token: 0x06002C1D RID: 11293 RVA: 0x00055774 File Offset: 0x00053974
		[ProtoMember(12, Name = "experienceherolefttime", DataFormat = DataFormat.TwosComplement)]
		public List<uint> experienceherolefttime
		{
			get
			{
				return this._experienceherolefttime;
			}
		}

		// Token: 0x06002C1E RID: 11294 RVA: 0x0005578C File Offset: 0x0005398C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AE1 RID: 2785
		private ErrorCode? _errorcode;

		// Token: 0x04000AE2 RID: 2786
		private readonly List<uint> _havehero = new List<uint>();

		// Token: 0x04000AE3 RID: 2787
		private readonly List<uint> _weekhero = new List<uint>();

		// Token: 0x04000AE4 RID: 2788
		private uint? _winthisweek;

		// Token: 0x04000AE5 RID: 2789
		private uint? _totalnum;

		// Token: 0x04000AE6 RID: 2790
		private uint? _winnum;

		// Token: 0x04000AE7 RID: 2791
		private uint? _losenum;

		// Token: 0x04000AE8 RID: 2792
		private uint? _todaygetspcount;

		// Token: 0x04000AE9 RID: 2793
		private uint? _weekprize;

		// Token: 0x04000AEA RID: 2794
		private bool? _cangetprize;

		// Token: 0x04000AEB RID: 2795
		private readonly List<uint> _experiencehero = new List<uint>();

		// Token: 0x04000AEC RID: 2796
		private readonly List<uint> _experienceherolefttime = new List<uint>();

		// Token: 0x04000AED RID: 2797
		private IExtension extensionObject;
	}
}

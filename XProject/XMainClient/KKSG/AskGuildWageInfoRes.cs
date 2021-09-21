using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200028B RID: 651
	[ProtoContract(Name = "AskGuildWageInfoRes")]
	[Serializable]
	public class AskGuildWageInfoRes : IExtensible
	{
		// Token: 0x17000B52 RID: 2898
		// (get) Token: 0x0600246C RID: 9324 RVA: 0x000470B8 File Offset: 0x000452B8
		// (set) Token: 0x0600246D RID: 9325 RVA: 0x000470E4 File Offset: 0x000452E4
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

		// Token: 0x17000B53 RID: 2899
		// (get) Token: 0x0600246E RID: 9326 RVA: 0x000470F4 File Offset: 0x000452F4
		// (set) Token: 0x0600246F RID: 9327 RVA: 0x00047114 File Offset: 0x00045314
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

		// Token: 0x06002470 RID: 9328 RVA: 0x00047158 File Offset: 0x00045358
		private bool ShouldSerializeactivity()
		{
			return this.activitySpecified;
		}

		// Token: 0x06002471 RID: 9329 RVA: 0x00047170 File Offset: 0x00045370
		private void Resetactivity()
		{
			this.activitySpecified = false;
		}

		// Token: 0x17000B54 RID: 2900
		// (get) Token: 0x06002472 RID: 9330 RVA: 0x0004717C File Offset: 0x0004537C
		// (set) Token: 0x06002473 RID: 9331 RVA: 0x000471A8 File Offset: 0x000453A8
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

		// Token: 0x17000B55 RID: 2901
		// (get) Token: 0x06002474 RID: 9332 RVA: 0x000471B8 File Offset: 0x000453B8
		// (set) Token: 0x06002475 RID: 9333 RVA: 0x000471D8 File Offset: 0x000453D8
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

		// Token: 0x06002476 RID: 9334 RVA: 0x0004721C File Offset: 0x0004541C
		private bool ShouldSerializerolenum()
		{
			return this.rolenumSpecified;
		}

		// Token: 0x06002477 RID: 9335 RVA: 0x00047234 File Offset: 0x00045434
		private void Resetrolenum()
		{
			this.rolenumSpecified = false;
		}

		// Token: 0x17000B56 RID: 2902
		// (get) Token: 0x06002478 RID: 9336 RVA: 0x00047240 File Offset: 0x00045440
		// (set) Token: 0x06002479 RID: 9337 RVA: 0x0004726C File Offset: 0x0004546C
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

		// Token: 0x17000B57 RID: 2903
		// (get) Token: 0x0600247A RID: 9338 RVA: 0x0004727C File Offset: 0x0004547C
		// (set) Token: 0x0600247B RID: 9339 RVA: 0x0004729C File Offset: 0x0004549C
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

		// Token: 0x0600247C RID: 9340 RVA: 0x000472E0 File Offset: 0x000454E0
		private bool ShouldSerializeprestige()
		{
			return this.prestigeSpecified;
		}

		// Token: 0x0600247D RID: 9341 RVA: 0x000472F8 File Offset: 0x000454F8
		private void Resetprestige()
		{
			this.prestigeSpecified = false;
		}

		// Token: 0x17000B58 RID: 2904
		// (get) Token: 0x0600247E RID: 9342 RVA: 0x00047304 File Offset: 0x00045504
		// (set) Token: 0x0600247F RID: 9343 RVA: 0x00047330 File Offset: 0x00045530
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

		// Token: 0x17000B59 RID: 2905
		// (get) Token: 0x06002480 RID: 9344 RVA: 0x00047340 File Offset: 0x00045540
		// (set) Token: 0x06002481 RID: 9345 RVA: 0x00047360 File Offset: 0x00045560
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

		// Token: 0x06002482 RID: 9346 RVA: 0x000473A4 File Offset: 0x000455A4
		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		// Token: 0x06002483 RID: 9347 RVA: 0x000473BC File Offset: 0x000455BC
		private void Resetexp()
		{
			this.expSpecified = false;
		}

		// Token: 0x17000B5A RID: 2906
		// (get) Token: 0x06002484 RID: 9348 RVA: 0x000473C8 File Offset: 0x000455C8
		// (set) Token: 0x06002485 RID: 9349 RVA: 0x000473F4 File Offset: 0x000455F4
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

		// Token: 0x17000B5B RID: 2907
		// (get) Token: 0x06002486 RID: 9350 RVA: 0x00047404 File Offset: 0x00045604
		// (set) Token: 0x06002487 RID: 9351 RVA: 0x00047424 File Offset: 0x00045624
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

		// Token: 0x06002488 RID: 9352 RVA: 0x00047468 File Offset: 0x00045668
		private bool ShouldSerializelastScore()
		{
			return this.lastScoreSpecified;
		}

		// Token: 0x06002489 RID: 9353 RVA: 0x00047480 File Offset: 0x00045680
		private void ResetlastScore()
		{
			this.lastScoreSpecified = false;
		}

		// Token: 0x17000B5C RID: 2908
		// (get) Token: 0x0600248A RID: 9354 RVA: 0x0004748C File Offset: 0x0004568C
		// (set) Token: 0x0600248B RID: 9355 RVA: 0x000474B8 File Offset: 0x000456B8
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

		// Token: 0x17000B5D RID: 2909
		// (get) Token: 0x0600248C RID: 9356 RVA: 0x000474C8 File Offset: 0x000456C8
		// (set) Token: 0x0600248D RID: 9357 RVA: 0x000474E8 File Offset: 0x000456E8
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

		// Token: 0x0600248E RID: 9358 RVA: 0x0004752C File Offset: 0x0004572C
		private bool ShouldSerializerewardstate()
		{
			return this.rewardstateSpecified;
		}

		// Token: 0x0600248F RID: 9359 RVA: 0x00047544 File Offset: 0x00045744
		private void Resetrewardstate()
		{
			this.rewardstateSpecified = false;
		}

		// Token: 0x17000B5E RID: 2910
		// (get) Token: 0x06002490 RID: 9360 RVA: 0x00047550 File Offset: 0x00045750
		// (set) Token: 0x06002491 RID: 9361 RVA: 0x0004757C File Offset: 0x0004577C
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

		// Token: 0x17000B5F RID: 2911
		// (get) Token: 0x06002492 RID: 9362 RVA: 0x0004758C File Offset: 0x0004578C
		// (set) Token: 0x06002493 RID: 9363 RVA: 0x000475AC File Offset: 0x000457AC
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

		// Token: 0x06002494 RID: 9364 RVA: 0x000475F0 File Offset: 0x000457F0
		private bool ShouldSerializewagelvl()
		{
			return this.wagelvlSpecified;
		}

		// Token: 0x06002495 RID: 9365 RVA: 0x00047608 File Offset: 0x00045808
		private void Resetwagelvl()
		{
			this.wagelvlSpecified = false;
		}

		// Token: 0x17000B60 RID: 2912
		// (get) Token: 0x06002496 RID: 9366 RVA: 0x00047614 File Offset: 0x00045814
		// (set) Token: 0x06002497 RID: 9367 RVA: 0x00047640 File Offset: 0x00045840
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

		// Token: 0x17000B61 RID: 2913
		// (get) Token: 0x06002498 RID: 9368 RVA: 0x00047650 File Offset: 0x00045850
		// (set) Token: 0x06002499 RID: 9369 RVA: 0x00047670 File Offset: 0x00045870
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

		// Token: 0x0600249A RID: 9370 RVA: 0x000476B4 File Offset: 0x000458B4
		private bool ShouldSerializeguildlvl()
		{
			return this.guildlvlSpecified;
		}

		// Token: 0x0600249B RID: 9371 RVA: 0x000476CC File Offset: 0x000458CC
		private void Resetguildlvl()
		{
			this.guildlvlSpecified = false;
		}

		// Token: 0x17000B62 RID: 2914
		// (get) Token: 0x0600249C RID: 9372 RVA: 0x000476D8 File Offset: 0x000458D8
		// (set) Token: 0x0600249D RID: 9373 RVA: 0x00047704 File Offset: 0x00045904
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

		// Token: 0x17000B63 RID: 2915
		// (get) Token: 0x0600249E RID: 9374 RVA: 0x00047714 File Offset: 0x00045914
		// (set) Token: 0x0600249F RID: 9375 RVA: 0x00047734 File Offset: 0x00045934
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

		// Token: 0x060024A0 RID: 9376 RVA: 0x00047778 File Offset: 0x00045978
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060024A1 RID: 9377 RVA: 0x00047790 File Offset: 0x00045990
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000B64 RID: 2916
		// (get) Token: 0x060024A2 RID: 9378 RVA: 0x0004779C File Offset: 0x0004599C
		// (set) Token: 0x060024A3 RID: 9379 RVA: 0x000477C8 File Offset: 0x000459C8
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

		// Token: 0x17000B65 RID: 2917
		// (get) Token: 0x060024A4 RID: 9380 RVA: 0x000477D8 File Offset: 0x000459D8
		// (set) Token: 0x060024A5 RID: 9381 RVA: 0x000477F8 File Offset: 0x000459F8
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

		// Token: 0x060024A6 RID: 9382 RVA: 0x0004783C File Offset: 0x00045A3C
		private bool ShouldSerializelastposition()
		{
			return this.lastpositionSpecified;
		}

		// Token: 0x060024A7 RID: 9383 RVA: 0x00047854 File Offset: 0x00045A54
		private void Resetlastposition()
		{
			this.lastpositionSpecified = false;
		}

		// Token: 0x17000B66 RID: 2918
		// (get) Token: 0x060024A8 RID: 9384 RVA: 0x00047860 File Offset: 0x00045A60
		[ProtoMember(11, Name = "name", DataFormat = DataFormat.Default)]
		public List<string> name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x17000B67 RID: 2919
		// (get) Token: 0x060024A9 RID: 9385 RVA: 0x00047878 File Offset: 0x00045A78
		[ProtoMember(12, Name = "roles", DataFormat = DataFormat.Default)]
		public List<GuildActivityRole> roles
		{
			get
			{
				return this._roles;
			}
		}

		// Token: 0x060024AA RID: 9386 RVA: 0x00047890 File Offset: 0x00045A90
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000901 RID: 2305
		private uint? _activity;

		// Token: 0x04000902 RID: 2306
		private uint? _rolenum;

		// Token: 0x04000903 RID: 2307
		private uint? _prestige;

		// Token: 0x04000904 RID: 2308
		private uint? _exp;

		// Token: 0x04000905 RID: 2309
		private uint? _lastScore;

		// Token: 0x04000906 RID: 2310
		private WageRewardState? _rewardstate;

		// Token: 0x04000907 RID: 2311
		private uint? _wagelvl;

		// Token: 0x04000908 RID: 2312
		private uint? _guildlvl;

		// Token: 0x04000909 RID: 2313
		private ErrorCode? _errorcode;

		// Token: 0x0400090A RID: 2314
		private uint? _lastposition;

		// Token: 0x0400090B RID: 2315
		private readonly List<string> _name = new List<string>();

		// Token: 0x0400090C RID: 2316
		private readonly List<GuildActivityRole> _roles = new List<GuildActivityRole>();

		// Token: 0x0400090D RID: 2317
		private IExtension extensionObject;
	}
}

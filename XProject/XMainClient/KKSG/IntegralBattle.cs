using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006C8 RID: 1736
	[ProtoContract(Name = "IntegralBattle")]
	[Serializable]
	public class IntegralBattle : IExtensible
	{
		// Token: 0x1700243D RID: 9277
		// (get) Token: 0x0600727B RID: 29307 RVA: 0x000DB0A0 File Offset: 0x000D92A0
		// (set) Token: 0x0600727C RID: 29308 RVA: 0x000DB0CD File Offset: 0x000D92CD
		[ProtoMember(1, IsRequired = false, Name = "guildone", DataFormat = DataFormat.TwosComplement)]
		public ulong guildone
		{
			get
			{
				return this._guildone ?? 0UL;
			}
			set
			{
				this._guildone = new ulong?(value);
			}
		}

		// Token: 0x1700243E RID: 9278
		// (get) Token: 0x0600727D RID: 29309 RVA: 0x000DB0DC File Offset: 0x000D92DC
		// (set) Token: 0x0600727E RID: 29310 RVA: 0x000DB0FC File Offset: 0x000D92FC
		[XmlIgnore]
		[Browsable(false)]
		public bool guildoneSpecified
		{
			get
			{
				return this._guildone != null;
			}
			set
			{
				bool flag = value == (this._guildone == null);
				if (flag)
				{
					this._guildone = (value ? new ulong?(this.guildone) : null);
				}
			}
		}

		// Token: 0x0600727F RID: 29311 RVA: 0x000DB140 File Offset: 0x000D9340
		private bool ShouldSerializeguildone()
		{
			return this.guildoneSpecified;
		}

		// Token: 0x06007280 RID: 29312 RVA: 0x000DB158 File Offset: 0x000D9358
		private void Resetguildone()
		{
			this.guildoneSpecified = false;
		}

		// Token: 0x1700243F RID: 9279
		// (get) Token: 0x06007281 RID: 29313 RVA: 0x000DB164 File Offset: 0x000D9364
		// (set) Token: 0x06007282 RID: 29314 RVA: 0x000DB191 File Offset: 0x000D9391
		[ProtoMember(2, IsRequired = false, Name = "guildtwo", DataFormat = DataFormat.TwosComplement)]
		public ulong guildtwo
		{
			get
			{
				return this._guildtwo ?? 0UL;
			}
			set
			{
				this._guildtwo = new ulong?(value);
			}
		}

		// Token: 0x17002440 RID: 9280
		// (get) Token: 0x06007283 RID: 29315 RVA: 0x000DB1A0 File Offset: 0x000D93A0
		// (set) Token: 0x06007284 RID: 29316 RVA: 0x000DB1C0 File Offset: 0x000D93C0
		[XmlIgnore]
		[Browsable(false)]
		public bool guildtwoSpecified
		{
			get
			{
				return this._guildtwo != null;
			}
			set
			{
				bool flag = value == (this._guildtwo == null);
				if (flag)
				{
					this._guildtwo = (value ? new ulong?(this.guildtwo) : null);
				}
			}
		}

		// Token: 0x06007285 RID: 29317 RVA: 0x000DB204 File Offset: 0x000D9404
		private bool ShouldSerializeguildtwo()
		{
			return this.guildtwoSpecified;
		}

		// Token: 0x06007286 RID: 29318 RVA: 0x000DB21C File Offset: 0x000D941C
		private void Resetguildtwo()
		{
			this.guildtwoSpecified = false;
		}

		// Token: 0x17002441 RID: 9281
		// (get) Token: 0x06007287 RID: 29319 RVA: 0x000DB228 File Offset: 0x000D9428
		// (set) Token: 0x06007288 RID: 29320 RVA: 0x000DB254 File Offset: 0x000D9454
		[ProtoMember(3, IsRequired = false, Name = "isdo", DataFormat = DataFormat.Default)]
		public bool isdo
		{
			get
			{
				return this._isdo ?? false;
			}
			set
			{
				this._isdo = new bool?(value);
			}
		}

		// Token: 0x17002442 RID: 9282
		// (get) Token: 0x06007289 RID: 29321 RVA: 0x000DB264 File Offset: 0x000D9464
		// (set) Token: 0x0600728A RID: 29322 RVA: 0x000DB284 File Offset: 0x000D9484
		[XmlIgnore]
		[Browsable(false)]
		public bool isdoSpecified
		{
			get
			{
				return this._isdo != null;
			}
			set
			{
				bool flag = value == (this._isdo == null);
				if (flag)
				{
					this._isdo = (value ? new bool?(this.isdo) : null);
				}
			}
		}

		// Token: 0x0600728B RID: 29323 RVA: 0x000DB2C8 File Offset: 0x000D94C8
		private bool ShouldSerializeisdo()
		{
			return this.isdoSpecified;
		}

		// Token: 0x0600728C RID: 29324 RVA: 0x000DB2E0 File Offset: 0x000D94E0
		private void Resetisdo()
		{
			this.isdoSpecified = false;
		}

		// Token: 0x17002443 RID: 9283
		// (get) Token: 0x0600728D RID: 29325 RVA: 0x000DB2EC File Offset: 0x000D94EC
		// (set) Token: 0x0600728E RID: 29326 RVA: 0x000DB318 File Offset: 0x000D9518
		[ProtoMember(4, IsRequired = false, Name = "guildonescore", DataFormat = DataFormat.TwosComplement)]
		public uint guildonescore
		{
			get
			{
				return this._guildonescore ?? 0U;
			}
			set
			{
				this._guildonescore = new uint?(value);
			}
		}

		// Token: 0x17002444 RID: 9284
		// (get) Token: 0x0600728F RID: 29327 RVA: 0x000DB328 File Offset: 0x000D9528
		// (set) Token: 0x06007290 RID: 29328 RVA: 0x000DB348 File Offset: 0x000D9548
		[XmlIgnore]
		[Browsable(false)]
		public bool guildonescoreSpecified
		{
			get
			{
				return this._guildonescore != null;
			}
			set
			{
				bool flag = value == (this._guildonescore == null);
				if (flag)
				{
					this._guildonescore = (value ? new uint?(this.guildonescore) : null);
				}
			}
		}

		// Token: 0x06007291 RID: 29329 RVA: 0x000DB38C File Offset: 0x000D958C
		private bool ShouldSerializeguildonescore()
		{
			return this.guildonescoreSpecified;
		}

		// Token: 0x06007292 RID: 29330 RVA: 0x000DB3A4 File Offset: 0x000D95A4
		private void Resetguildonescore()
		{
			this.guildonescoreSpecified = false;
		}

		// Token: 0x17002445 RID: 9285
		// (get) Token: 0x06007293 RID: 29331 RVA: 0x000DB3B0 File Offset: 0x000D95B0
		// (set) Token: 0x06007294 RID: 29332 RVA: 0x000DB3DC File Offset: 0x000D95DC
		[ProtoMember(5, IsRequired = false, Name = "guildtwoscore", DataFormat = DataFormat.TwosComplement)]
		public uint guildtwoscore
		{
			get
			{
				return this._guildtwoscore ?? 0U;
			}
			set
			{
				this._guildtwoscore = new uint?(value);
			}
		}

		// Token: 0x17002446 RID: 9286
		// (get) Token: 0x06007295 RID: 29333 RVA: 0x000DB3EC File Offset: 0x000D95EC
		// (set) Token: 0x06007296 RID: 29334 RVA: 0x000DB40C File Offset: 0x000D960C
		[XmlIgnore]
		[Browsable(false)]
		public bool guildtwoscoreSpecified
		{
			get
			{
				return this._guildtwoscore != null;
			}
			set
			{
				bool flag = value == (this._guildtwoscore == null);
				if (flag)
				{
					this._guildtwoscore = (value ? new uint?(this.guildtwoscore) : null);
				}
			}
		}

		// Token: 0x06007297 RID: 29335 RVA: 0x000DB450 File Offset: 0x000D9650
		private bool ShouldSerializeguildtwoscore()
		{
			return this.guildtwoscoreSpecified;
		}

		// Token: 0x06007298 RID: 29336 RVA: 0x000DB468 File Offset: 0x000D9668
		private void Resetguildtwoscore()
		{
			this.guildtwoscoreSpecified = false;
		}

		// Token: 0x17002447 RID: 9287
		// (get) Token: 0x06007299 RID: 29337 RVA: 0x000DB474 File Offset: 0x000D9674
		// (set) Token: 0x0600729A RID: 29338 RVA: 0x000DB495 File Offset: 0x000D9695
		[ProtoMember(6, IsRequired = false, Name = "nameone", DataFormat = DataFormat.Default)]
		public string nameone
		{
			get
			{
				return this._nameone ?? "";
			}
			set
			{
				this._nameone = value;
			}
		}

		// Token: 0x17002448 RID: 9288
		// (get) Token: 0x0600729B RID: 29339 RVA: 0x000DB4A0 File Offset: 0x000D96A0
		// (set) Token: 0x0600729C RID: 29340 RVA: 0x000DB4BC File Offset: 0x000D96BC
		[XmlIgnore]
		[Browsable(false)]
		public bool nameoneSpecified
		{
			get
			{
				return this._nameone != null;
			}
			set
			{
				bool flag = value == (this._nameone == null);
				if (flag)
				{
					this._nameone = (value ? this.nameone : null);
				}
			}
		}

		// Token: 0x0600729D RID: 29341 RVA: 0x000DB4EC File Offset: 0x000D96EC
		private bool ShouldSerializenameone()
		{
			return this.nameoneSpecified;
		}

		// Token: 0x0600729E RID: 29342 RVA: 0x000DB504 File Offset: 0x000D9704
		private void Resetnameone()
		{
			this.nameoneSpecified = false;
		}

		// Token: 0x17002449 RID: 9289
		// (get) Token: 0x0600729F RID: 29343 RVA: 0x000DB510 File Offset: 0x000D9710
		// (set) Token: 0x060072A0 RID: 29344 RVA: 0x000DB531 File Offset: 0x000D9731
		[ProtoMember(7, IsRequired = false, Name = "nametwo", DataFormat = DataFormat.Default)]
		public string nametwo
		{
			get
			{
				return this._nametwo ?? "";
			}
			set
			{
				this._nametwo = value;
			}
		}

		// Token: 0x1700244A RID: 9290
		// (get) Token: 0x060072A1 RID: 29345 RVA: 0x000DB53C File Offset: 0x000D973C
		// (set) Token: 0x060072A2 RID: 29346 RVA: 0x000DB558 File Offset: 0x000D9758
		[XmlIgnore]
		[Browsable(false)]
		public bool nametwoSpecified
		{
			get
			{
				return this._nametwo != null;
			}
			set
			{
				bool flag = value == (this._nametwo == null);
				if (flag)
				{
					this._nametwo = (value ? this.nametwo : null);
				}
			}
		}

		// Token: 0x060072A3 RID: 29347 RVA: 0x000DB588 File Offset: 0x000D9788
		private bool ShouldSerializenametwo()
		{
			return this.nametwoSpecified;
		}

		// Token: 0x060072A4 RID: 29348 RVA: 0x000DB5A0 File Offset: 0x000D97A0
		private void Resetnametwo()
		{
			this.nametwoSpecified = false;
		}

		// Token: 0x1700244B RID: 9291
		// (get) Token: 0x060072A5 RID: 29349 RVA: 0x000DB5AC File Offset: 0x000D97AC
		// (set) Token: 0x060072A6 RID: 29350 RVA: 0x000DB5D8 File Offset: 0x000D97D8
		[ProtoMember(8, IsRequired = false, Name = "iconone", DataFormat = DataFormat.TwosComplement)]
		public uint iconone
		{
			get
			{
				return this._iconone ?? 0U;
			}
			set
			{
				this._iconone = new uint?(value);
			}
		}

		// Token: 0x1700244C RID: 9292
		// (get) Token: 0x060072A7 RID: 29351 RVA: 0x000DB5E8 File Offset: 0x000D97E8
		// (set) Token: 0x060072A8 RID: 29352 RVA: 0x000DB608 File Offset: 0x000D9808
		[XmlIgnore]
		[Browsable(false)]
		public bool icononeSpecified
		{
			get
			{
				return this._iconone != null;
			}
			set
			{
				bool flag = value == (this._iconone == null);
				if (flag)
				{
					this._iconone = (value ? new uint?(this.iconone) : null);
				}
			}
		}

		// Token: 0x060072A9 RID: 29353 RVA: 0x000DB64C File Offset: 0x000D984C
		private bool ShouldSerializeiconone()
		{
			return this.icononeSpecified;
		}

		// Token: 0x060072AA RID: 29354 RVA: 0x000DB664 File Offset: 0x000D9864
		private void Reseticonone()
		{
			this.icononeSpecified = false;
		}

		// Token: 0x1700244D RID: 9293
		// (get) Token: 0x060072AB RID: 29355 RVA: 0x000DB670 File Offset: 0x000D9870
		// (set) Token: 0x060072AC RID: 29356 RVA: 0x000DB69C File Offset: 0x000D989C
		[ProtoMember(9, IsRequired = false, Name = "icontwo", DataFormat = DataFormat.TwosComplement)]
		public uint icontwo
		{
			get
			{
				return this._icontwo ?? 0U;
			}
			set
			{
				this._icontwo = new uint?(value);
			}
		}

		// Token: 0x1700244E RID: 9294
		// (get) Token: 0x060072AD RID: 29357 RVA: 0x000DB6AC File Offset: 0x000D98AC
		// (set) Token: 0x060072AE RID: 29358 RVA: 0x000DB6CC File Offset: 0x000D98CC
		[XmlIgnore]
		[Browsable(false)]
		public bool icontwoSpecified
		{
			get
			{
				return this._icontwo != null;
			}
			set
			{
				bool flag = value == (this._icontwo == null);
				if (flag)
				{
					this._icontwo = (value ? new uint?(this.icontwo) : null);
				}
			}
		}

		// Token: 0x060072AF RID: 29359 RVA: 0x000DB710 File Offset: 0x000D9910
		private bool ShouldSerializeicontwo()
		{
			return this.icontwoSpecified;
		}

		// Token: 0x060072B0 RID: 29360 RVA: 0x000DB728 File Offset: 0x000D9928
		private void Reseticontwo()
		{
			this.icontwoSpecified = false;
		}

		// Token: 0x1700244F RID: 9295
		// (get) Token: 0x060072B1 RID: 29361 RVA: 0x000DB734 File Offset: 0x000D9934
		// (set) Token: 0x060072B2 RID: 29362 RVA: 0x000DB760 File Offset: 0x000D9960
		[ProtoMember(10, IsRequired = false, Name = "wartime", DataFormat = DataFormat.TwosComplement)]
		public uint wartime
		{
			get
			{
				return this._wartime ?? 0U;
			}
			set
			{
				this._wartime = new uint?(value);
			}
		}

		// Token: 0x17002450 RID: 9296
		// (get) Token: 0x060072B3 RID: 29363 RVA: 0x000DB770 File Offset: 0x000D9970
		// (set) Token: 0x060072B4 RID: 29364 RVA: 0x000DB790 File Offset: 0x000D9990
		[XmlIgnore]
		[Browsable(false)]
		public bool wartimeSpecified
		{
			get
			{
				return this._wartime != null;
			}
			set
			{
				bool flag = value == (this._wartime == null);
				if (flag)
				{
					this._wartime = (value ? new uint?(this.wartime) : null);
				}
			}
		}

		// Token: 0x060072B5 RID: 29365 RVA: 0x000DB7D4 File Offset: 0x000D99D4
		private bool ShouldSerializewartime()
		{
			return this.wartimeSpecified;
		}

		// Token: 0x060072B6 RID: 29366 RVA: 0x000DB7EC File Offset: 0x000D99EC
		private void Resetwartime()
		{
			this.wartimeSpecified = false;
		}

		// Token: 0x17002451 RID: 9297
		// (get) Token: 0x060072B7 RID: 29367 RVA: 0x000DB7F8 File Offset: 0x000D99F8
		// (set) Token: 0x060072B8 RID: 29368 RVA: 0x000DB824 File Offset: 0x000D9A24
		[ProtoMember(11, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public IntegralState state
		{
			get
			{
				return this._state ?? IntegralState.integralready;
			}
			set
			{
				this._state = new IntegralState?(value);
			}
		}

		// Token: 0x17002452 RID: 9298
		// (get) Token: 0x060072B9 RID: 29369 RVA: 0x000DB834 File Offset: 0x000D9A34
		// (set) Token: 0x060072BA RID: 29370 RVA: 0x000DB854 File Offset: 0x000D9A54
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new IntegralState?(this.state) : null);
				}
			}
		}

		// Token: 0x060072BB RID: 29371 RVA: 0x000DB898 File Offset: 0x000D9A98
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x060072BC RID: 29372 RVA: 0x000DB8B0 File Offset: 0x000D9AB0
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x060072BD RID: 29373 RVA: 0x000DB8BC File Offset: 0x000D9ABC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B46 RID: 6982
		private ulong? _guildone;

		// Token: 0x04001B47 RID: 6983
		private ulong? _guildtwo;

		// Token: 0x04001B48 RID: 6984
		private bool? _isdo;

		// Token: 0x04001B49 RID: 6985
		private uint? _guildonescore;

		// Token: 0x04001B4A RID: 6986
		private uint? _guildtwoscore;

		// Token: 0x04001B4B RID: 6987
		private string _nameone;

		// Token: 0x04001B4C RID: 6988
		private string _nametwo;

		// Token: 0x04001B4D RID: 6989
		private uint? _iconone;

		// Token: 0x04001B4E RID: 6990
		private uint? _icontwo;

		// Token: 0x04001B4F RID: 6991
		private uint? _wartime;

		// Token: 0x04001B50 RID: 6992
		private IntegralState? _state;

		// Token: 0x04001B51 RID: 6993
		private IExtension extensionObject;
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000249 RID: 585
	[ProtoContract(Name = "GuildCardMatchNtf")]
	[Serializable]
	public class GuildCardMatchNtf : IExtensible
	{
		// Token: 0x17000A1B RID: 2587
		// (get) Token: 0x0600206E RID: 8302 RVA: 0x0003F848 File Offset: 0x0003DA48
		// (set) Token: 0x0600206F RID: 8303 RVA: 0x0003F874 File Offset: 0x0003DA74
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

		// Token: 0x17000A1C RID: 2588
		// (get) Token: 0x06002070 RID: 8304 RVA: 0x0003F884 File Offset: 0x0003DA84
		// (set) Token: 0x06002071 RID: 8305 RVA: 0x0003F8A4 File Offset: 0x0003DAA4
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

		// Token: 0x06002072 RID: 8306 RVA: 0x0003F8E8 File Offset: 0x0003DAE8
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002073 RID: 8307 RVA: 0x0003F900 File Offset: 0x0003DB00
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000A1D RID: 2589
		// (get) Token: 0x06002074 RID: 8308 RVA: 0x0003F90C File Offset: 0x0003DB0C
		// (set) Token: 0x06002075 RID: 8309 RVA: 0x0003F938 File Offset: 0x0003DB38
		[ProtoMember(2, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public CardMatchOp op
		{
			get
			{
				return this._op ?? CardMatchOp.CardMatch_Begin;
			}
			set
			{
				this._op = new CardMatchOp?(value);
			}
		}

		// Token: 0x17000A1E RID: 2590
		// (get) Token: 0x06002076 RID: 8310 RVA: 0x0003F948 File Offset: 0x0003DB48
		// (set) Token: 0x06002077 RID: 8311 RVA: 0x0003F968 File Offset: 0x0003DB68
		[XmlIgnore]
		[Browsable(false)]
		public bool opSpecified
		{
			get
			{
				return this._op != null;
			}
			set
			{
				bool flag = value == (this._op == null);
				if (flag)
				{
					this._op = (value ? new CardMatchOp?(this.op) : null);
				}
			}
		}

		// Token: 0x06002078 RID: 8312 RVA: 0x0003F9AC File Offset: 0x0003DBAC
		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		// Token: 0x06002079 RID: 8313 RVA: 0x0003F9C4 File Offset: 0x0003DBC4
		private void Resetop()
		{
			this.opSpecified = false;
		}

		// Token: 0x17000A1F RID: 2591
		// (get) Token: 0x0600207A RID: 8314 RVA: 0x0003F9D0 File Offset: 0x0003DBD0
		// (set) Token: 0x0600207B RID: 8315 RVA: 0x0003F9FC File Offset: 0x0003DBFC
		[ProtoMember(3, IsRequired = false, Name = "timeleft", DataFormat = DataFormat.TwosComplement)]
		public uint timeleft
		{
			get
			{
				return this._timeleft ?? 0U;
			}
			set
			{
				this._timeleft = new uint?(value);
			}
		}

		// Token: 0x17000A20 RID: 2592
		// (get) Token: 0x0600207C RID: 8316 RVA: 0x0003FA0C File Offset: 0x0003DC0C
		// (set) Token: 0x0600207D RID: 8317 RVA: 0x0003FA2C File Offset: 0x0003DC2C
		[XmlIgnore]
		[Browsable(false)]
		public bool timeleftSpecified
		{
			get
			{
				return this._timeleft != null;
			}
			set
			{
				bool flag = value == (this._timeleft == null);
				if (flag)
				{
					this._timeleft = (value ? new uint?(this.timeleft) : null);
				}
			}
		}

		// Token: 0x0600207E RID: 8318 RVA: 0x0003FA70 File Offset: 0x0003DC70
		private bool ShouldSerializetimeleft()
		{
			return this.timeleftSpecified;
		}

		// Token: 0x0600207F RID: 8319 RVA: 0x0003FA88 File Offset: 0x0003DC88
		private void Resettimeleft()
		{
			this.timeleftSpecified = false;
		}

		// Token: 0x17000A21 RID: 2593
		// (get) Token: 0x06002080 RID: 8320 RVA: 0x0003FA94 File Offset: 0x0003DC94
		// (set) Token: 0x06002081 RID: 8321 RVA: 0x0003FAC0 File Offset: 0x0003DCC0
		[ProtoMember(4, IsRequired = false, Name = "changecount", DataFormat = DataFormat.TwosComplement)]
		public uint changecount
		{
			get
			{
				return this._changecount ?? 0U;
			}
			set
			{
				this._changecount = new uint?(value);
			}
		}

		// Token: 0x17000A22 RID: 2594
		// (get) Token: 0x06002082 RID: 8322 RVA: 0x0003FAD0 File Offset: 0x0003DCD0
		// (set) Token: 0x06002083 RID: 8323 RVA: 0x0003FAF0 File Offset: 0x0003DCF0
		[XmlIgnore]
		[Browsable(false)]
		public bool changecountSpecified
		{
			get
			{
				return this._changecount != null;
			}
			set
			{
				bool flag = value == (this._changecount == null);
				if (flag)
				{
					this._changecount = (value ? new uint?(this.changecount) : null);
				}
			}
		}

		// Token: 0x06002084 RID: 8324 RVA: 0x0003FB34 File Offset: 0x0003DD34
		private bool ShouldSerializechangecount()
		{
			return this.changecountSpecified;
		}

		// Token: 0x06002085 RID: 8325 RVA: 0x0003FB4C File Offset: 0x0003DD4C
		private void Resetchangecount()
		{
			this.changecountSpecified = false;
		}

		// Token: 0x17000A23 RID: 2595
		// (get) Token: 0x06002086 RID: 8326 RVA: 0x0003FB58 File Offset: 0x0003DD58
		// (set) Token: 0x06002087 RID: 8327 RVA: 0x0003FB84 File Offset: 0x0003DD84
		[ProtoMember(5, IsRequired = false, Name = "round", DataFormat = DataFormat.TwosComplement)]
		public uint round
		{
			get
			{
				return this._round ?? 0U;
			}
			set
			{
				this._round = new uint?(value);
			}
		}

		// Token: 0x17000A24 RID: 2596
		// (get) Token: 0x06002088 RID: 8328 RVA: 0x0003FB94 File Offset: 0x0003DD94
		// (set) Token: 0x06002089 RID: 8329 RVA: 0x0003FBB4 File Offset: 0x0003DDB4
		[XmlIgnore]
		[Browsable(false)]
		public bool roundSpecified
		{
			get
			{
				return this._round != null;
			}
			set
			{
				bool flag = value == (this._round == null);
				if (flag)
				{
					this._round = (value ? new uint?(this.round) : null);
				}
			}
		}

		// Token: 0x0600208A RID: 8330 RVA: 0x0003FBF8 File Offset: 0x0003DDF8
		private bool ShouldSerializeround()
		{
			return this.roundSpecified;
		}

		// Token: 0x0600208B RID: 8331 RVA: 0x0003FC10 File Offset: 0x0003DE10
		private void Resetround()
		{
			this.roundSpecified = false;
		}

		// Token: 0x17000A25 RID: 2597
		// (get) Token: 0x0600208C RID: 8332 RVA: 0x0003FC1C File Offset: 0x0003DE1C
		// (set) Token: 0x0600208D RID: 8333 RVA: 0x0003FC48 File Offset: 0x0003DE48
		[ProtoMember(6, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public uint result
		{
			get
			{
				return this._result ?? 0U;
			}
			set
			{
				this._result = new uint?(value);
			}
		}

		// Token: 0x17000A26 RID: 2598
		// (get) Token: 0x0600208E RID: 8334 RVA: 0x0003FC58 File Offset: 0x0003DE58
		// (set) Token: 0x0600208F RID: 8335 RVA: 0x0003FC78 File Offset: 0x0003DE78
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
					this._result = (value ? new uint?(this.result) : null);
				}
			}
		}

		// Token: 0x06002090 RID: 8336 RVA: 0x0003FCBC File Offset: 0x0003DEBC
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002091 RID: 8337 RVA: 0x0003FCD4 File Offset: 0x0003DED4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000A27 RID: 2599
		// (get) Token: 0x06002092 RID: 8338 RVA: 0x0003FCE0 File Offset: 0x0003DEE0
		[ProtoMember(7, Name = "cards", DataFormat = DataFormat.TwosComplement)]
		public List<uint> cards
		{
			get
			{
				return this._cards;
			}
		}

		// Token: 0x17000A28 RID: 2600
		// (get) Token: 0x06002093 RID: 8339 RVA: 0x0003FCF8 File Offset: 0x0003DEF8
		// (set) Token: 0x06002094 RID: 8340 RVA: 0x0003FD24 File Offset: 0x0003DF24
		[ProtoMember(8, IsRequired = false, Name = "iscanbegin", DataFormat = DataFormat.Default)]
		public bool iscanbegin
		{
			get
			{
				return this._iscanbegin ?? false;
			}
			set
			{
				this._iscanbegin = new bool?(value);
			}
		}

		// Token: 0x17000A29 RID: 2601
		// (get) Token: 0x06002095 RID: 8341 RVA: 0x0003FD34 File Offset: 0x0003DF34
		// (set) Token: 0x06002096 RID: 8342 RVA: 0x0003FD54 File Offset: 0x0003DF54
		[XmlIgnore]
		[Browsable(false)]
		public bool iscanbeginSpecified
		{
			get
			{
				return this._iscanbegin != null;
			}
			set
			{
				bool flag = value == (this._iscanbegin == null);
				if (flag)
				{
					this._iscanbegin = (value ? new bool?(this.iscanbegin) : null);
				}
			}
		}

		// Token: 0x06002097 RID: 8343 RVA: 0x0003FD98 File Offset: 0x0003DF98
		private bool ShouldSerializeiscanbegin()
		{
			return this.iscanbeginSpecified;
		}

		// Token: 0x06002098 RID: 8344 RVA: 0x0003FDB0 File Offset: 0x0003DFB0
		private void Resetiscanbegin()
		{
			this.iscanbeginSpecified = false;
		}

		// Token: 0x17000A2A RID: 2602
		// (get) Token: 0x06002099 RID: 8345 RVA: 0x0003FDBC File Offset: 0x0003DFBC
		// (set) Token: 0x0600209A RID: 8346 RVA: 0x0003FDE8 File Offset: 0x0003DFE8
		[ProtoMember(9, IsRequired = false, Name = "isbegin", DataFormat = DataFormat.Default)]
		public bool isbegin
		{
			get
			{
				return this._isbegin ?? false;
			}
			set
			{
				this._isbegin = new bool?(value);
			}
		}

		// Token: 0x17000A2B RID: 2603
		// (get) Token: 0x0600209B RID: 8347 RVA: 0x0003FDF8 File Offset: 0x0003DFF8
		// (set) Token: 0x0600209C RID: 8348 RVA: 0x0003FE18 File Offset: 0x0003E018
		[XmlIgnore]
		[Browsable(false)]
		public bool isbeginSpecified
		{
			get
			{
				return this._isbegin != null;
			}
			set
			{
				bool flag = value == (this._isbegin == null);
				if (flag)
				{
					this._isbegin = (value ? new bool?(this.isbegin) : null);
				}
			}
		}

		// Token: 0x0600209D RID: 8349 RVA: 0x0003FE5C File Offset: 0x0003E05C
		private bool ShouldSerializeisbegin()
		{
			return this.isbeginSpecified;
		}

		// Token: 0x0600209E RID: 8350 RVA: 0x0003FE74 File Offset: 0x0003E074
		private void Resetisbegin()
		{
			this.isbeginSpecified = false;
		}

		// Token: 0x17000A2C RID: 2604
		// (get) Token: 0x0600209F RID: 8351 RVA: 0x0003FE80 File Offset: 0x0003E080
		// (set) Token: 0x060020A0 RID: 8352 RVA: 0x0003FEAC File Offset: 0x0003E0AC
		[ProtoMember(10, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public CardMatchState state
		{
			get
			{
				return this._state ?? CardMatchState.CardMatch_StateBegin;
			}
			set
			{
				this._state = new CardMatchState?(value);
			}
		}

		// Token: 0x17000A2D RID: 2605
		// (get) Token: 0x060020A1 RID: 8353 RVA: 0x0003FEBC File Offset: 0x0003E0BC
		// (set) Token: 0x060020A2 RID: 8354 RVA: 0x0003FEDC File Offset: 0x0003E0DC
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
					this._state = (value ? new CardMatchState?(this.state) : null);
				}
			}
		}

		// Token: 0x060020A3 RID: 8355 RVA: 0x0003FF20 File Offset: 0x0003E120
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x060020A4 RID: 8356 RVA: 0x0003FF38 File Offset: 0x0003E138
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x17000A2E RID: 2606
		// (get) Token: 0x060020A5 RID: 8357 RVA: 0x0003FF44 File Offset: 0x0003E144
		// (set) Token: 0x060020A6 RID: 8358 RVA: 0x0003FF70 File Offset: 0x0003E170
		[ProtoMember(11, IsRequired = false, Name = "store", DataFormat = DataFormat.TwosComplement)]
		public uint store
		{
			get
			{
				return this._store ?? 0U;
			}
			set
			{
				this._store = new uint?(value);
			}
		}

		// Token: 0x17000A2F RID: 2607
		// (get) Token: 0x060020A7 RID: 8359 RVA: 0x0003FF80 File Offset: 0x0003E180
		// (set) Token: 0x060020A8 RID: 8360 RVA: 0x0003FFA0 File Offset: 0x0003E1A0
		[XmlIgnore]
		[Browsable(false)]
		public bool storeSpecified
		{
			get
			{
				return this._store != null;
			}
			set
			{
				bool flag = value == (this._store == null);
				if (flag)
				{
					this._store = (value ? new uint?(this.store) : null);
				}
			}
		}

		// Token: 0x060020A9 RID: 8361 RVA: 0x0003FFE4 File Offset: 0x0003E1E4
		private bool ShouldSerializestore()
		{
			return this.storeSpecified;
		}

		// Token: 0x060020AA RID: 8362 RVA: 0x0003FFFC File Offset: 0x0003E1FC
		private void Resetstore()
		{
			this.storeSpecified = false;
		}

		// Token: 0x17000A30 RID: 2608
		// (get) Token: 0x060020AB RID: 8363 RVA: 0x00040008 File Offset: 0x0003E208
		// (set) Token: 0x060020AC RID: 8364 RVA: 0x00040034 File Offset: 0x0003E234
		[ProtoMember(12, IsRequired = false, Name = "sign_up", DataFormat = DataFormat.Default)]
		public bool sign_up
		{
			get
			{
				return this._sign_up ?? false;
			}
			set
			{
				this._sign_up = new bool?(value);
			}
		}

		// Token: 0x17000A31 RID: 2609
		// (get) Token: 0x060020AD RID: 8365 RVA: 0x00040044 File Offset: 0x0003E244
		// (set) Token: 0x060020AE RID: 8366 RVA: 0x00040064 File Offset: 0x0003E264
		[XmlIgnore]
		[Browsable(false)]
		public bool sign_upSpecified
		{
			get
			{
				return this._sign_up != null;
			}
			set
			{
				bool flag = value == (this._sign_up == null);
				if (flag)
				{
					this._sign_up = (value ? new bool?(this.sign_up) : null);
				}
			}
		}

		// Token: 0x060020AF RID: 8367 RVA: 0x000400A8 File Offset: 0x0003E2A8
		private bool ShouldSerializesign_up()
		{
			return this.sign_upSpecified;
		}

		// Token: 0x060020B0 RID: 8368 RVA: 0x000400C0 File Offset: 0x0003E2C0
		private void Resetsign_up()
		{
			this.sign_upSpecified = false;
		}

		// Token: 0x17000A32 RID: 2610
		// (get) Token: 0x060020B1 RID: 8369 RVA: 0x000400CC File Offset: 0x0003E2CC
		// (set) Token: 0x060020B2 RID: 8370 RVA: 0x000400F8 File Offset: 0x0003E2F8
		[ProtoMember(13, IsRequired = false, Name = "match_type", DataFormat = DataFormat.TwosComplement)]
		public uint match_type
		{
			get
			{
				return this._match_type ?? 0U;
			}
			set
			{
				this._match_type = new uint?(value);
			}
		}

		// Token: 0x17000A33 RID: 2611
		// (get) Token: 0x060020B3 RID: 8371 RVA: 0x00040108 File Offset: 0x0003E308
		// (set) Token: 0x060020B4 RID: 8372 RVA: 0x00040128 File Offset: 0x0003E328
		[XmlIgnore]
		[Browsable(false)]
		public bool match_typeSpecified
		{
			get
			{
				return this._match_type != null;
			}
			set
			{
				bool flag = value == (this._match_type == null);
				if (flag)
				{
					this._match_type = (value ? new uint?(this.match_type) : null);
				}
			}
		}

		// Token: 0x060020B5 RID: 8373 RVA: 0x0004016C File Offset: 0x0003E36C
		private bool ShouldSerializematch_type()
		{
			return this.match_typeSpecified;
		}

		// Token: 0x060020B6 RID: 8374 RVA: 0x00040184 File Offset: 0x0003E384
		private void Resetmatch_type()
		{
			this.match_typeSpecified = false;
		}

		// Token: 0x17000A34 RID: 2612
		// (get) Token: 0x060020B7 RID: 8375 RVA: 0x00040190 File Offset: 0x0003E390
		[ProtoMember(14, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x17000A35 RID: 2613
		// (get) Token: 0x060020B8 RID: 8376 RVA: 0x000401A8 File Offset: 0x0003E3A8
		// (set) Token: 0x060020B9 RID: 8377 RVA: 0x000401D4 File Offset: 0x0003E3D4
		[ProtoMember(15, IsRequired = false, Name = "sign_up_num", DataFormat = DataFormat.TwosComplement)]
		public uint sign_up_num
		{
			get
			{
				return this._sign_up_num ?? 0U;
			}
			set
			{
				this._sign_up_num = new uint?(value);
			}
		}

		// Token: 0x17000A36 RID: 2614
		// (get) Token: 0x060020BA RID: 8378 RVA: 0x000401E4 File Offset: 0x0003E3E4
		// (set) Token: 0x060020BB RID: 8379 RVA: 0x00040204 File Offset: 0x0003E404
		[XmlIgnore]
		[Browsable(false)]
		public bool sign_up_numSpecified
		{
			get
			{
				return this._sign_up_num != null;
			}
			set
			{
				bool flag = value == (this._sign_up_num == null);
				if (flag)
				{
					this._sign_up_num = (value ? new uint?(this.sign_up_num) : null);
				}
			}
		}

		// Token: 0x060020BC RID: 8380 RVA: 0x00040248 File Offset: 0x0003E448
		private bool ShouldSerializesign_up_num()
		{
			return this.sign_up_numSpecified;
		}

		// Token: 0x060020BD RID: 8381 RVA: 0x00040260 File Offset: 0x0003E460
		private void Resetsign_up_num()
		{
			this.sign_up_numSpecified = false;
		}

		// Token: 0x060020BE RID: 8382 RVA: 0x0004026C File Offset: 0x0003E46C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000818 RID: 2072
		private ErrorCode? _errorcode;

		// Token: 0x04000819 RID: 2073
		private CardMatchOp? _op;

		// Token: 0x0400081A RID: 2074
		private uint? _timeleft;

		// Token: 0x0400081B RID: 2075
		private uint? _changecount;

		// Token: 0x0400081C RID: 2076
		private uint? _round;

		// Token: 0x0400081D RID: 2077
		private uint? _result;

		// Token: 0x0400081E RID: 2078
		private readonly List<uint> _cards = new List<uint>();

		// Token: 0x0400081F RID: 2079
		private bool? _iscanbegin;

		// Token: 0x04000820 RID: 2080
		private bool? _isbegin;

		// Token: 0x04000821 RID: 2081
		private CardMatchState? _state;

		// Token: 0x04000822 RID: 2082
		private uint? _store;

		// Token: 0x04000823 RID: 2083
		private bool? _sign_up;

		// Token: 0x04000824 RID: 2084
		private uint? _match_type;

		// Token: 0x04000825 RID: 2085
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x04000826 RID: 2086
		private uint? _sign_up_num;

		// Token: 0x04000827 RID: 2087
		private IExtension extensionObject;
	}
}

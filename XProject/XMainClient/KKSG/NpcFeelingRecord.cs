using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000679 RID: 1657
	[ProtoContract(Name = "NpcFeelingRecord")]
	[Serializable]
	public class NpcFeelingRecord : IExtensible
	{
		// Token: 0x17002184 RID: 8580
		// (get) Token: 0x060069F5 RID: 27125 RVA: 0x000CA9AC File Offset: 0x000C8BAC
		// (set) Token: 0x060069F6 RID: 27126 RVA: 0x000CA9D8 File Offset: 0x000C8BD8
		[ProtoMember(1, IsRequired = false, Name = "lastupdaytime", DataFormat = DataFormat.TwosComplement)]
		public uint lastupdaytime
		{
			get
			{
				return this._lastupdaytime ?? 0U;
			}
			set
			{
				this._lastupdaytime = new uint?(value);
			}
		}

		// Token: 0x17002185 RID: 8581
		// (get) Token: 0x060069F7 RID: 27127 RVA: 0x000CA9E8 File Offset: 0x000C8BE8
		// (set) Token: 0x060069F8 RID: 27128 RVA: 0x000CAA08 File Offset: 0x000C8C08
		[XmlIgnore]
		[Browsable(false)]
		public bool lastupdaytimeSpecified
		{
			get
			{
				return this._lastupdaytime != null;
			}
			set
			{
				bool flag = value == (this._lastupdaytime == null);
				if (flag)
				{
					this._lastupdaytime = (value ? new uint?(this.lastupdaytime) : null);
				}
			}
		}

		// Token: 0x060069F9 RID: 27129 RVA: 0x000CAA4C File Offset: 0x000C8C4C
		private bool ShouldSerializelastupdaytime()
		{
			return this.lastupdaytimeSpecified;
		}

		// Token: 0x060069FA RID: 27130 RVA: 0x000CAA64 File Offset: 0x000C8C64
		private void Resetlastupdaytime()
		{
			this.lastupdaytimeSpecified = false;
		}

		// Token: 0x17002186 RID: 8582
		// (get) Token: 0x060069FB RID: 27131 RVA: 0x000CAA70 File Offset: 0x000C8C70
		[ProtoMember(2, Name = "npclist", DataFormat = DataFormat.Default)]
		public List<NpcFeelingOneNpc> npclist
		{
			get
			{
				return this._npclist;
			}
		}

		// Token: 0x17002187 RID: 8583
		// (get) Token: 0x060069FC RID: 27132 RVA: 0x000CAA88 File Offset: 0x000C8C88
		[ProtoMember(3, Name = "unitelist", DataFormat = DataFormat.Default)]
		public List<NpcFeelingUnite> unitelist
		{
			get
			{
				return this._unitelist;
			}
		}

		// Token: 0x17002188 RID: 8584
		// (get) Token: 0x060069FD RID: 27133 RVA: 0x000CAAA0 File Offset: 0x000C8CA0
		// (set) Token: 0x060069FE RID: 27134 RVA: 0x000CAACC File Offset: 0x000C8CCC
		[ProtoMember(4, IsRequired = false, Name = "exchangecount", DataFormat = DataFormat.TwosComplement)]
		public uint exchangecount
		{
			get
			{
				return this._exchangecount ?? 0U;
			}
			set
			{
				this._exchangecount = new uint?(value);
			}
		}

		// Token: 0x17002189 RID: 8585
		// (get) Token: 0x060069FF RID: 27135 RVA: 0x000CAADC File Offset: 0x000C8CDC
		// (set) Token: 0x06006A00 RID: 27136 RVA: 0x000CAAFC File Offset: 0x000C8CFC
		[XmlIgnore]
		[Browsable(false)]
		public bool exchangecountSpecified
		{
			get
			{
				return this._exchangecount != null;
			}
			set
			{
				bool flag = value == (this._exchangecount == null);
				if (flag)
				{
					this._exchangecount = (value ? new uint?(this.exchangecount) : null);
				}
			}
		}

		// Token: 0x06006A01 RID: 27137 RVA: 0x000CAB40 File Offset: 0x000C8D40
		private bool ShouldSerializeexchangecount()
		{
			return this.exchangecountSpecified;
		}

		// Token: 0x06006A02 RID: 27138 RVA: 0x000CAB58 File Offset: 0x000C8D58
		private void Resetexchangecount()
		{
			this.exchangecountSpecified = false;
		}

		// Token: 0x1700218A RID: 8586
		// (get) Token: 0x06006A03 RID: 27139 RVA: 0x000CAB64 File Offset: 0x000C8D64
		// (set) Token: 0x06006A04 RID: 27140 RVA: 0x000CAB90 File Offset: 0x000C8D90
		[ProtoMember(5, IsRequired = false, Name = "returncount", DataFormat = DataFormat.TwosComplement)]
		public uint returncount
		{
			get
			{
				return this._returncount ?? 0U;
			}
			set
			{
				this._returncount = new uint?(value);
			}
		}

		// Token: 0x1700218B RID: 8587
		// (get) Token: 0x06006A05 RID: 27141 RVA: 0x000CABA0 File Offset: 0x000C8DA0
		// (set) Token: 0x06006A06 RID: 27142 RVA: 0x000CABC0 File Offset: 0x000C8DC0
		[XmlIgnore]
		[Browsable(false)]
		public bool returncountSpecified
		{
			get
			{
				return this._returncount != null;
			}
			set
			{
				bool flag = value == (this._returncount == null);
				if (flag)
				{
					this._returncount = (value ? new uint?(this.returncount) : null);
				}
			}
		}

		// Token: 0x06006A07 RID: 27143 RVA: 0x000CAC04 File Offset: 0x000C8E04
		private bool ShouldSerializereturncount()
		{
			return this.returncountSpecified;
		}

		// Token: 0x06006A08 RID: 27144 RVA: 0x000CAC1C File Offset: 0x000C8E1C
		private void Resetreturncount()
		{
			this.returncountSpecified = false;
		}

		// Token: 0x1700218C RID: 8588
		// (get) Token: 0x06006A09 RID: 27145 RVA: 0x000CAC28 File Offset: 0x000C8E28
		// (set) Token: 0x06006A0A RID: 27146 RVA: 0x000CAC54 File Offset: 0x000C8E54
		[ProtoMember(6, IsRequired = false, Name = "givecount", DataFormat = DataFormat.TwosComplement)]
		public uint givecount
		{
			get
			{
				return this._givecount ?? 0U;
			}
			set
			{
				this._givecount = new uint?(value);
			}
		}

		// Token: 0x1700218D RID: 8589
		// (get) Token: 0x06006A0B RID: 27147 RVA: 0x000CAC64 File Offset: 0x000C8E64
		// (set) Token: 0x06006A0C RID: 27148 RVA: 0x000CAC84 File Offset: 0x000C8E84
		[XmlIgnore]
		[Browsable(false)]
		public bool givecountSpecified
		{
			get
			{
				return this._givecount != null;
			}
			set
			{
				bool flag = value == (this._givecount == null);
				if (flag)
				{
					this._givecount = (value ? new uint?(this.givecount) : null);
				}
			}
		}

		// Token: 0x06006A0D RID: 27149 RVA: 0x000CACC8 File Offset: 0x000C8EC8
		private bool ShouldSerializegivecount()
		{
			return this.givecountSpecified;
		}

		// Token: 0x06006A0E RID: 27150 RVA: 0x000CACE0 File Offset: 0x000C8EE0
		private void Resetgivecount()
		{
			this.givecountSpecified = false;
		}

		// Token: 0x1700218E RID: 8590
		// (get) Token: 0x06006A0F RID: 27151 RVA: 0x000CACEC File Offset: 0x000C8EEC
		[ProtoMember(7, Name = "nouse", DataFormat = DataFormat.Default)]
		public List<ItemBrief> nouse
		{
			get
			{
				return this._nouse;
			}
		}

		// Token: 0x1700218F RID: 8591
		// (get) Token: 0x06006A10 RID: 27152 RVA: 0x000CAD04 File Offset: 0x000C8F04
		[ProtoMember(8, Name = "returndrop", DataFormat = DataFormat.Default)]
		public List<NpcFlReturn> returndrop
		{
			get
			{
				return this._returndrop;
			}
		}

		// Token: 0x17002190 RID: 8592
		// (get) Token: 0x06006A11 RID: 27153 RVA: 0x000CAD1C File Offset: 0x000C8F1C
		// (set) Token: 0x06006A12 RID: 27154 RVA: 0x000CAD48 File Offset: 0x000C8F48
		[ProtoMember(9, IsRequired = false, Name = "buycount", DataFormat = DataFormat.TwosComplement)]
		public uint buycount
		{
			get
			{
				return this._buycount ?? 0U;
			}
			set
			{
				this._buycount = new uint?(value);
			}
		}

		// Token: 0x17002191 RID: 8593
		// (get) Token: 0x06006A13 RID: 27155 RVA: 0x000CAD58 File Offset: 0x000C8F58
		// (set) Token: 0x06006A14 RID: 27156 RVA: 0x000CAD78 File Offset: 0x000C8F78
		[XmlIgnore]
		[Browsable(false)]
		public bool buycountSpecified
		{
			get
			{
				return this._buycount != null;
			}
			set
			{
				bool flag = value == (this._buycount == null);
				if (flag)
				{
					this._buycount = (value ? new uint?(this.buycount) : null);
				}
			}
		}

		// Token: 0x06006A15 RID: 27157 RVA: 0x000CADBC File Offset: 0x000C8FBC
		private bool ShouldSerializebuycount()
		{
			return this.buycountSpecified;
		}

		// Token: 0x06006A16 RID: 27158 RVA: 0x000CADD4 File Offset: 0x000C8FD4
		private void Resetbuycount()
		{
			this.buycountSpecified = false;
		}

		// Token: 0x17002192 RID: 8594
		// (get) Token: 0x06006A17 RID: 27159 RVA: 0x000CADE0 File Offset: 0x000C8FE0
		// (set) Token: 0x06006A18 RID: 27160 RVA: 0x000CAE0C File Offset: 0x000C900C
		[ProtoMember(10, IsRequired = false, Name = "triggerfavorcount", DataFormat = DataFormat.TwosComplement)]
		public uint triggerfavorcount
		{
			get
			{
				return this._triggerfavorcount ?? 0U;
			}
			set
			{
				this._triggerfavorcount = new uint?(value);
			}
		}

		// Token: 0x17002193 RID: 8595
		// (get) Token: 0x06006A19 RID: 27161 RVA: 0x000CAE1C File Offset: 0x000C901C
		// (set) Token: 0x06006A1A RID: 27162 RVA: 0x000CAE3C File Offset: 0x000C903C
		[XmlIgnore]
		[Browsable(false)]
		public bool triggerfavorcountSpecified
		{
			get
			{
				return this._triggerfavorcount != null;
			}
			set
			{
				bool flag = value == (this._triggerfavorcount == null);
				if (flag)
				{
					this._triggerfavorcount = (value ? new uint?(this.triggerfavorcount) : null);
				}
			}
		}

		// Token: 0x06006A1B RID: 27163 RVA: 0x000CAE80 File Offset: 0x000C9080
		private bool ShouldSerializetriggerfavorcount()
		{
			return this.triggerfavorcountSpecified;
		}

		// Token: 0x06006A1C RID: 27164 RVA: 0x000CAE98 File Offset: 0x000C9098
		private void Resettriggerfavorcount()
		{
			this.triggerfavorcountSpecified = false;
		}

		// Token: 0x17002194 RID: 8596
		// (get) Token: 0x06006A1D RID: 27165 RVA: 0x000CAEA4 File Offset: 0x000C90A4
		// (set) Token: 0x06006A1E RID: 27166 RVA: 0x000CAED0 File Offset: 0x000C90D0
		[ProtoMember(11, IsRequired = false, Name = "giveleftaddcount", DataFormat = DataFormat.TwosComplement)]
		public uint giveleftaddcount
		{
			get
			{
				return this._giveleftaddcount ?? 0U;
			}
			set
			{
				this._giveleftaddcount = new uint?(value);
			}
		}

		// Token: 0x17002195 RID: 8597
		// (get) Token: 0x06006A1F RID: 27167 RVA: 0x000CAEE0 File Offset: 0x000C90E0
		// (set) Token: 0x06006A20 RID: 27168 RVA: 0x000CAF00 File Offset: 0x000C9100
		[XmlIgnore]
		[Browsable(false)]
		public bool giveleftaddcountSpecified
		{
			get
			{
				return this._giveleftaddcount != null;
			}
			set
			{
				bool flag = value == (this._giveleftaddcount == null);
				if (flag)
				{
					this._giveleftaddcount = (value ? new uint?(this.giveleftaddcount) : null);
				}
			}
		}

		// Token: 0x06006A21 RID: 27169 RVA: 0x000CAF44 File Offset: 0x000C9144
		private bool ShouldSerializegiveleftaddcount()
		{
			return this.giveleftaddcountSpecified;
		}

		// Token: 0x06006A22 RID: 27170 RVA: 0x000CAF5C File Offset: 0x000C915C
		private void Resetgiveleftaddcount()
		{
			this.giveleftaddcountSpecified = false;
		}

		// Token: 0x06006A23 RID: 27171 RVA: 0x000CAF68 File Offset: 0x000C9168
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001986 RID: 6534
		private uint? _lastupdaytime;

		// Token: 0x04001987 RID: 6535
		private readonly List<NpcFeelingOneNpc> _npclist = new List<NpcFeelingOneNpc>();

		// Token: 0x04001988 RID: 6536
		private readonly List<NpcFeelingUnite> _unitelist = new List<NpcFeelingUnite>();

		// Token: 0x04001989 RID: 6537
		private uint? _exchangecount;

		// Token: 0x0400198A RID: 6538
		private uint? _returncount;

		// Token: 0x0400198B RID: 6539
		private uint? _givecount;

		// Token: 0x0400198C RID: 6540
		private readonly List<ItemBrief> _nouse = new List<ItemBrief>();

		// Token: 0x0400198D RID: 6541
		private readonly List<NpcFlReturn> _returndrop = new List<NpcFlReturn>();

		// Token: 0x0400198E RID: 6542
		private uint? _buycount;

		// Token: 0x0400198F RID: 6543
		private uint? _triggerfavorcount;

		// Token: 0x04001990 RID: 6544
		private uint? _giveleftaddcount;

		// Token: 0x04001991 RID: 6545
		private IExtension extensionObject;
	}
}

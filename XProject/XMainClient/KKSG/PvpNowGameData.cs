using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000154 RID: 340
	[ProtoContract(Name = "PvpNowGameData")]
	[Serializable]
	public class PvpNowGameData : IExtensible
	{
		// Token: 0x17000698 RID: 1688
		// (get) Token: 0x060014BC RID: 5308 RVA: 0x00029C14 File Offset: 0x00027E14
		// (set) Token: 0x060014BD RID: 5309 RVA: 0x00029C40 File Offset: 0x00027E40
		[ProtoMember(1, IsRequired = false, Name = "group1WinCount", DataFormat = DataFormat.TwosComplement)]
		public int group1WinCount
		{
			get
			{
				return this._group1WinCount ?? 0;
			}
			set
			{
				this._group1WinCount = new int?(value);
			}
		}

		// Token: 0x17000699 RID: 1689
		// (get) Token: 0x060014BE RID: 5310 RVA: 0x00029C50 File Offset: 0x00027E50
		// (set) Token: 0x060014BF RID: 5311 RVA: 0x00029C70 File Offset: 0x00027E70
		[XmlIgnore]
		[Browsable(false)]
		public bool group1WinCountSpecified
		{
			get
			{
				return this._group1WinCount != null;
			}
			set
			{
				bool flag = value == (this._group1WinCount == null);
				if (flag)
				{
					this._group1WinCount = (value ? new int?(this.group1WinCount) : null);
				}
			}
		}

		// Token: 0x060014C0 RID: 5312 RVA: 0x00029CB4 File Offset: 0x00027EB4
		private bool ShouldSerializegroup1WinCount()
		{
			return this.group1WinCountSpecified;
		}

		// Token: 0x060014C1 RID: 5313 RVA: 0x00029CCC File Offset: 0x00027ECC
		private void Resetgroup1WinCount()
		{
			this.group1WinCountSpecified = false;
		}

		// Token: 0x1700069A RID: 1690
		// (get) Token: 0x060014C2 RID: 5314 RVA: 0x00029CD8 File Offset: 0x00027ED8
		// (set) Token: 0x060014C3 RID: 5315 RVA: 0x00029D04 File Offset: 0x00027F04
		[ProtoMember(2, IsRequired = false, Name = "group2WinCount", DataFormat = DataFormat.TwosComplement)]
		public int group2WinCount
		{
			get
			{
				return this._group2WinCount ?? 0;
			}
			set
			{
				this._group2WinCount = new int?(value);
			}
		}

		// Token: 0x1700069B RID: 1691
		// (get) Token: 0x060014C4 RID: 5316 RVA: 0x00029D14 File Offset: 0x00027F14
		// (set) Token: 0x060014C5 RID: 5317 RVA: 0x00029D34 File Offset: 0x00027F34
		[XmlIgnore]
		[Browsable(false)]
		public bool group2WinCountSpecified
		{
			get
			{
				return this._group2WinCount != null;
			}
			set
			{
				bool flag = value == (this._group2WinCount == null);
				if (flag)
				{
					this._group2WinCount = (value ? new int?(this.group2WinCount) : null);
				}
			}
		}

		// Token: 0x060014C6 RID: 5318 RVA: 0x00029D78 File Offset: 0x00027F78
		private bool ShouldSerializegroup2WinCount()
		{
			return this.group2WinCountSpecified;
		}

		// Token: 0x060014C7 RID: 5319 RVA: 0x00029D90 File Offset: 0x00027F90
		private void Resetgroup2WinCount()
		{
			this.group2WinCountSpecified = false;
		}

		// Token: 0x1700069C RID: 1692
		// (get) Token: 0x060014C8 RID: 5320 RVA: 0x00029D9C File Offset: 0x00027F9C
		// (set) Token: 0x060014C9 RID: 5321 RVA: 0x00029DC8 File Offset: 0x00027FC8
		[ProtoMember(3, IsRequired = false, Name = "drawWinCount", DataFormat = DataFormat.TwosComplement)]
		public int drawWinCount
		{
			get
			{
				return this._drawWinCount ?? 0;
			}
			set
			{
				this._drawWinCount = new int?(value);
			}
		}

		// Token: 0x1700069D RID: 1693
		// (get) Token: 0x060014CA RID: 5322 RVA: 0x00029DD8 File Offset: 0x00027FD8
		// (set) Token: 0x060014CB RID: 5323 RVA: 0x00029DF8 File Offset: 0x00027FF8
		[XmlIgnore]
		[Browsable(false)]
		public bool drawWinCountSpecified
		{
			get
			{
				return this._drawWinCount != null;
			}
			set
			{
				bool flag = value == (this._drawWinCount == null);
				if (flag)
				{
					this._drawWinCount = (value ? new int?(this.drawWinCount) : null);
				}
			}
		}

		// Token: 0x060014CC RID: 5324 RVA: 0x00029E3C File Offset: 0x0002803C
		private bool ShouldSerializedrawWinCount()
		{
			return this.drawWinCountSpecified;
		}

		// Token: 0x060014CD RID: 5325 RVA: 0x00029E54 File Offset: 0x00028054
		private void ResetdrawWinCount()
		{
			this.drawWinCountSpecified = false;
		}

		// Token: 0x1700069E RID: 1694
		// (get) Token: 0x060014CE RID: 5326 RVA: 0x00029E60 File Offset: 0x00028060
		// (set) Token: 0x060014CF RID: 5327 RVA: 0x00029E8C File Offset: 0x0002808C
		[ProtoMember(4, IsRequired = false, Name = "LeftTime", DataFormat = DataFormat.TwosComplement)]
		public uint LeftTime
		{
			get
			{
				return this._LeftTime ?? 0U;
			}
			set
			{
				this._LeftTime = new uint?(value);
			}
		}

		// Token: 0x1700069F RID: 1695
		// (get) Token: 0x060014D0 RID: 5328 RVA: 0x00029E9C File Offset: 0x0002809C
		// (set) Token: 0x060014D1 RID: 5329 RVA: 0x00029EBC File Offset: 0x000280BC
		[XmlIgnore]
		[Browsable(false)]
		public bool LeftTimeSpecified
		{
			get
			{
				return this._LeftTime != null;
			}
			set
			{
				bool flag = value == (this._LeftTime == null);
				if (flag)
				{
					this._LeftTime = (value ? new uint?(this.LeftTime) : null);
				}
			}
		}

		// Token: 0x060014D2 RID: 5330 RVA: 0x00029F00 File Offset: 0x00028100
		private bool ShouldSerializeLeftTime()
		{
			return this.LeftTimeSpecified;
		}

		// Token: 0x060014D3 RID: 5331 RVA: 0x00029F18 File Offset: 0x00028118
		private void ResetLeftTime()
		{
			this.LeftTimeSpecified = false;
		}

		// Token: 0x170006A0 RID: 1696
		// (get) Token: 0x060014D4 RID: 5332 RVA: 0x00029F24 File Offset: 0x00028124
		// (set) Token: 0x060014D5 RID: 5333 RVA: 0x00029F50 File Offset: 0x00028150
		[ProtoMember(5, IsRequired = false, Name = "isAllEnd", DataFormat = DataFormat.Default)]
		public bool isAllEnd
		{
			get
			{
				return this._isAllEnd ?? false;
			}
			set
			{
				this._isAllEnd = new bool?(value);
			}
		}

		// Token: 0x170006A1 RID: 1697
		// (get) Token: 0x060014D6 RID: 5334 RVA: 0x00029F60 File Offset: 0x00028160
		// (set) Token: 0x060014D7 RID: 5335 RVA: 0x00029F80 File Offset: 0x00028180
		[XmlIgnore]
		[Browsable(false)]
		public bool isAllEndSpecified
		{
			get
			{
				return this._isAllEnd != null;
			}
			set
			{
				bool flag = value == (this._isAllEnd == null);
				if (flag)
				{
					this._isAllEnd = (value ? new bool?(this.isAllEnd) : null);
				}
			}
		}

		// Token: 0x060014D8 RID: 5336 RVA: 0x00029FC4 File Offset: 0x000281C4
		private bool ShouldSerializeisAllEnd()
		{
			return this.isAllEndSpecified;
		}

		// Token: 0x060014D9 RID: 5337 RVA: 0x00029FDC File Offset: 0x000281DC
		private void ResetisAllEnd()
		{
			this.isAllEndSpecified = false;
		}

		// Token: 0x170006A2 RID: 1698
		// (get) Token: 0x060014DA RID: 5338 RVA: 0x00029FE8 File Offset: 0x000281E8
		// (set) Token: 0x060014DB RID: 5339 RVA: 0x0002A015 File Offset: 0x00028215
		[ProtoMember(6, IsRequired = false, Name = "group1Leader", DataFormat = DataFormat.TwosComplement)]
		public ulong group1Leader
		{
			get
			{
				return this._group1Leader ?? 0UL;
			}
			set
			{
				this._group1Leader = new ulong?(value);
			}
		}

		// Token: 0x170006A3 RID: 1699
		// (get) Token: 0x060014DC RID: 5340 RVA: 0x0002A024 File Offset: 0x00028224
		// (set) Token: 0x060014DD RID: 5341 RVA: 0x0002A044 File Offset: 0x00028244
		[XmlIgnore]
		[Browsable(false)]
		public bool group1LeaderSpecified
		{
			get
			{
				return this._group1Leader != null;
			}
			set
			{
				bool flag = value == (this._group1Leader == null);
				if (flag)
				{
					this._group1Leader = (value ? new ulong?(this.group1Leader) : null);
				}
			}
		}

		// Token: 0x060014DE RID: 5342 RVA: 0x0002A088 File Offset: 0x00028288
		private bool ShouldSerializegroup1Leader()
		{
			return this.group1LeaderSpecified;
		}

		// Token: 0x060014DF RID: 5343 RVA: 0x0002A0A0 File Offset: 0x000282A0
		private void Resetgroup1Leader()
		{
			this.group1LeaderSpecified = false;
		}

		// Token: 0x170006A4 RID: 1700
		// (get) Token: 0x060014E0 RID: 5344 RVA: 0x0002A0AC File Offset: 0x000282AC
		// (set) Token: 0x060014E1 RID: 5345 RVA: 0x0002A0D9 File Offset: 0x000282D9
		[ProtoMember(7, IsRequired = false, Name = "group2Leader", DataFormat = DataFormat.TwosComplement)]
		public ulong group2Leader
		{
			get
			{
				return this._group2Leader ?? 0UL;
			}
			set
			{
				this._group2Leader = new ulong?(value);
			}
		}

		// Token: 0x170006A5 RID: 1701
		// (get) Token: 0x060014E2 RID: 5346 RVA: 0x0002A0E8 File Offset: 0x000282E8
		// (set) Token: 0x060014E3 RID: 5347 RVA: 0x0002A108 File Offset: 0x00028308
		[XmlIgnore]
		[Browsable(false)]
		public bool group2LeaderSpecified
		{
			get
			{
				return this._group2Leader != null;
			}
			set
			{
				bool flag = value == (this._group2Leader == null);
				if (flag)
				{
					this._group2Leader = (value ? new ulong?(this.group2Leader) : null);
				}
			}
		}

		// Token: 0x060014E4 RID: 5348 RVA: 0x0002A14C File Offset: 0x0002834C
		private bool ShouldSerializegroup2Leader()
		{
			return this.group2LeaderSpecified;
		}

		// Token: 0x060014E5 RID: 5349 RVA: 0x0002A164 File Offset: 0x00028364
		private void Resetgroup2Leader()
		{
			this.group2LeaderSpecified = false;
		}

		// Token: 0x170006A6 RID: 1702
		// (get) Token: 0x060014E6 RID: 5350 RVA: 0x0002A170 File Offset: 0x00028370
		[ProtoMember(8, Name = "nowUnitdData", DataFormat = DataFormat.Default)]
		public List<PvpNowUnitData> nowUnitdData
		{
			get
			{
				return this._nowUnitdData;
			}
		}

		// Token: 0x170006A7 RID: 1703
		// (get) Token: 0x060014E7 RID: 5351 RVA: 0x0002A188 File Offset: 0x00028388
		// (set) Token: 0x060014E8 RID: 5352 RVA: 0x0002A1B4 File Offset: 0x000283B4
		[ProtoMember(9, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170006A8 RID: 1704
		// (get) Token: 0x060014E9 RID: 5353 RVA: 0x0002A1C4 File Offset: 0x000283C4
		// (set) Token: 0x060014EA RID: 5354 RVA: 0x0002A1E4 File Offset: 0x000283E4
		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		// Token: 0x060014EB RID: 5355 RVA: 0x0002A228 File Offset: 0x00028428
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x060014EC RID: 5356 RVA: 0x0002A240 File Offset: 0x00028440
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x060014ED RID: 5357 RVA: 0x0002A24C File Offset: 0x0002844C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000528 RID: 1320
		private int? _group1WinCount;

		// Token: 0x04000529 RID: 1321
		private int? _group2WinCount;

		// Token: 0x0400052A RID: 1322
		private int? _drawWinCount;

		// Token: 0x0400052B RID: 1323
		private uint? _LeftTime;

		// Token: 0x0400052C RID: 1324
		private bool? _isAllEnd;

		// Token: 0x0400052D RID: 1325
		private ulong? _group1Leader;

		// Token: 0x0400052E RID: 1326
		private ulong? _group2Leader;

		// Token: 0x0400052F RID: 1327
		private readonly List<PvpNowUnitData> _nowUnitdData = new List<PvpNowUnitData>();

		// Token: 0x04000530 RID: 1328
		private ErrorCode? _errcode;

		// Token: 0x04000531 RID: 1329
		private IExtension extensionObject;
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001AA RID: 426
	[ProtoContract(Name = "BattleWatcherNtf")]
	[Serializable]
	public class BattleWatcherNtf : IExtensible
	{
		// Token: 0x170007F0 RID: 2032
		// (get) Token: 0x0600192D RID: 6445 RVA: 0x00032058 File Offset: 0x00030258
		[ProtoMember(1, Name = "data", DataFormat = DataFormat.Default)]
		public List<BattleStatisticsData> data
		{
			get
			{
				return this._data;
			}
		}

		// Token: 0x170007F1 RID: 2033
		// (get) Token: 0x0600192E RID: 6446 RVA: 0x00032070 File Offset: 0x00030270
		// (set) Token: 0x0600192F RID: 6447 RVA: 0x00032088 File Offset: 0x00030288
		[ProtoMember(2, IsRequired = false, Name = "watchinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public StageWatchInfo watchinfo
		{
			get
			{
				return this._watchinfo;
			}
			set
			{
				this._watchinfo = value;
			}
		}

		// Token: 0x170007F2 RID: 2034
		// (get) Token: 0x06001930 RID: 6448 RVA: 0x00032094 File Offset: 0x00030294
		// (set) Token: 0x06001931 RID: 6449 RVA: 0x000320C1 File Offset: 0x000302C1
		[ProtoMember(3, IsRequired = false, Name = "mvp", DataFormat = DataFormat.TwosComplement)]
		public ulong mvp
		{
			get
			{
				return this._mvp ?? 0UL;
			}
			set
			{
				this._mvp = new ulong?(value);
			}
		}

		// Token: 0x170007F3 RID: 2035
		// (get) Token: 0x06001932 RID: 6450 RVA: 0x000320D0 File Offset: 0x000302D0
		// (set) Token: 0x06001933 RID: 6451 RVA: 0x000320F0 File Offset: 0x000302F0
		[XmlIgnore]
		[Browsable(false)]
		public bool mvpSpecified
		{
			get
			{
				return this._mvp != null;
			}
			set
			{
				bool flag = value == (this._mvp == null);
				if (flag)
				{
					this._mvp = (value ? new ulong?(this.mvp) : null);
				}
			}
		}

		// Token: 0x06001934 RID: 6452 RVA: 0x00032134 File Offset: 0x00030334
		private bool ShouldSerializemvp()
		{
			return this.mvpSpecified;
		}

		// Token: 0x06001935 RID: 6453 RVA: 0x0003214C File Offset: 0x0003034C
		private void Resetmvp()
		{
			this.mvpSpecified = false;
		}

		// Token: 0x170007F4 RID: 2036
		// (get) Token: 0x06001936 RID: 6454 RVA: 0x00032158 File Offset: 0x00030358
		// (set) Token: 0x06001937 RID: 6455 RVA: 0x00032185 File Offset: 0x00030385
		[ProtoMember(4, IsRequired = false, Name = "winuid", DataFormat = DataFormat.TwosComplement)]
		public ulong winuid
		{
			get
			{
				return this._winuid ?? 0UL;
			}
			set
			{
				this._winuid = new ulong?(value);
			}
		}

		// Token: 0x170007F5 RID: 2037
		// (get) Token: 0x06001938 RID: 6456 RVA: 0x00032194 File Offset: 0x00030394
		// (set) Token: 0x06001939 RID: 6457 RVA: 0x000321B4 File Offset: 0x000303B4
		[XmlIgnore]
		[Browsable(false)]
		public bool winuidSpecified
		{
			get
			{
				return this._winuid != null;
			}
			set
			{
				bool flag = value == (this._winuid == null);
				if (flag)
				{
					this._winuid = (value ? new ulong?(this.winuid) : null);
				}
			}
		}

		// Token: 0x0600193A RID: 6458 RVA: 0x000321F8 File Offset: 0x000303F8
		private bool ShouldSerializewinuid()
		{
			return this.winuidSpecified;
		}

		// Token: 0x0600193B RID: 6459 RVA: 0x00032210 File Offset: 0x00030410
		private void Resetwinuid()
		{
			this.winuidSpecified = false;
		}

		// Token: 0x170007F6 RID: 2038
		// (get) Token: 0x0600193C RID: 6460 RVA: 0x0003221C File Offset: 0x0003041C
		[ProtoMember(5, Name = "star", DataFormat = DataFormat.Default)]
		public List<BattleStarData> star
		{
			get
			{
				return this._star;
			}
		}

		// Token: 0x170007F7 RID: 2039
		// (get) Token: 0x0600193D RID: 6461 RVA: 0x00032234 File Offset: 0x00030434
		// (set) Token: 0x0600193E RID: 6462 RVA: 0x00032260 File Offset: 0x00030460
		[ProtoMember(6, IsRequired = false, Name = "scenetype", DataFormat = DataFormat.TwosComplement)]
		public uint scenetype
		{
			get
			{
				return this._scenetype ?? 0U;
			}
			set
			{
				this._scenetype = new uint?(value);
			}
		}

		// Token: 0x170007F8 RID: 2040
		// (get) Token: 0x0600193F RID: 6463 RVA: 0x00032270 File Offset: 0x00030470
		// (set) Token: 0x06001940 RID: 6464 RVA: 0x00032290 File Offset: 0x00030490
		[XmlIgnore]
		[Browsable(false)]
		public bool scenetypeSpecified
		{
			get
			{
				return this._scenetype != null;
			}
			set
			{
				bool flag = value == (this._scenetype == null);
				if (flag)
				{
					this._scenetype = (value ? new uint?(this.scenetype) : null);
				}
			}
		}

		// Token: 0x06001941 RID: 6465 RVA: 0x000322D4 File Offset: 0x000304D4
		private bool ShouldSerializescenetype()
		{
			return this.scenetypeSpecified;
		}

		// Token: 0x06001942 RID: 6466 RVA: 0x000322EC File Offset: 0x000304EC
		private void Resetscenetype()
		{
			this.scenetypeSpecified = false;
		}

		// Token: 0x06001943 RID: 6467 RVA: 0x000322F8 File Offset: 0x000304F8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000640 RID: 1600
		private readonly List<BattleStatisticsData> _data = new List<BattleStatisticsData>();

		// Token: 0x04000641 RID: 1601
		private StageWatchInfo _watchinfo = null;

		// Token: 0x04000642 RID: 1602
		private ulong? _mvp;

		// Token: 0x04000643 RID: 1603
		private ulong? _winuid;

		// Token: 0x04000644 RID: 1604
		private readonly List<BattleStarData> _star = new List<BattleStarData>();

		// Token: 0x04000645 RID: 1605
		private uint? _scenetype;

		// Token: 0x04000646 RID: 1606
		private IExtension extensionObject;
	}
}

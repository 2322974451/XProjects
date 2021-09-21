using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000129 RID: 297
	[ProtoContract(Name = "FiveRewardRes")]
	[Serializable]
	public class FiveRewardRes : IExtensible
	{
		// Token: 0x170005E0 RID: 1504
		// (get) Token: 0x0600125F RID: 4703 RVA: 0x000254E8 File Offset: 0x000236E8
		// (set) Token: 0x06001260 RID: 4704 RVA: 0x00025514 File Offset: 0x00023714
		[ProtoMember(1, IsRequired = false, Name = "twoday", DataFormat = DataFormat.Default)]
		public bool twoday
		{
			get
			{
				return this._twoday ?? false;
			}
			set
			{
				this._twoday = new bool?(value);
			}
		}

		// Token: 0x170005E1 RID: 1505
		// (get) Token: 0x06001261 RID: 4705 RVA: 0x00025524 File Offset: 0x00023724
		// (set) Token: 0x06001262 RID: 4706 RVA: 0x00025544 File Offset: 0x00023744
		[XmlIgnore]
		[Browsable(false)]
		public bool twodaySpecified
		{
			get
			{
				return this._twoday != null;
			}
			set
			{
				bool flag = value == (this._twoday == null);
				if (flag)
				{
					this._twoday = (value ? new bool?(this.twoday) : null);
				}
			}
		}

		// Token: 0x06001263 RID: 4707 RVA: 0x00025588 File Offset: 0x00023788
		private bool ShouldSerializetwoday()
		{
			return this.twodaySpecified;
		}

		// Token: 0x06001264 RID: 4708 RVA: 0x000255A0 File Offset: 0x000237A0
		private void Resettwoday()
		{
			this.twodaySpecified = false;
		}

		// Token: 0x170005E2 RID: 1506
		// (get) Token: 0x06001265 RID: 4709 RVA: 0x000255AC File Offset: 0x000237AC
		// (set) Token: 0x06001266 RID: 4710 RVA: 0x000255D8 File Offset: 0x000237D8
		[ProtoMember(2, IsRequired = false, Name = "fiveday", DataFormat = DataFormat.Default)]
		public bool fiveday
		{
			get
			{
				return this._fiveday ?? false;
			}
			set
			{
				this._fiveday = new bool?(value);
			}
		}

		// Token: 0x170005E3 RID: 1507
		// (get) Token: 0x06001267 RID: 4711 RVA: 0x000255E8 File Offset: 0x000237E8
		// (set) Token: 0x06001268 RID: 4712 RVA: 0x00025608 File Offset: 0x00023808
		[XmlIgnore]
		[Browsable(false)]
		public bool fivedaySpecified
		{
			get
			{
				return this._fiveday != null;
			}
			set
			{
				bool flag = value == (this._fiveday == null);
				if (flag)
				{
					this._fiveday = (value ? new bool?(this.fiveday) : null);
				}
			}
		}

		// Token: 0x06001269 RID: 4713 RVA: 0x0002564C File Offset: 0x0002384C
		private bool ShouldSerializefiveday()
		{
			return this.fivedaySpecified;
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x00025664 File Offset: 0x00023864
		private void Resetfiveday()
		{
			this.fivedaySpecified = false;
		}

		// Token: 0x170005E4 RID: 1508
		// (get) Token: 0x0600126B RID: 4715 RVA: 0x00025670 File Offset: 0x00023870
		// (set) Token: 0x0600126C RID: 4716 RVA: 0x0002569C File Offset: 0x0002389C
		[ProtoMember(3, IsRequired = false, Name = "threeday", DataFormat = DataFormat.Default)]
		public bool threeday
		{
			get
			{
				return this._threeday ?? false;
			}
			set
			{
				this._threeday = new bool?(value);
			}
		}

		// Token: 0x170005E5 RID: 1509
		// (get) Token: 0x0600126D RID: 4717 RVA: 0x000256AC File Offset: 0x000238AC
		// (set) Token: 0x0600126E RID: 4718 RVA: 0x000256CC File Offset: 0x000238CC
		[XmlIgnore]
		[Browsable(false)]
		public bool threedaySpecified
		{
			get
			{
				return this._threeday != null;
			}
			set
			{
				bool flag = value == (this._threeday == null);
				if (flag)
				{
					this._threeday = (value ? new bool?(this.threeday) : null);
				}
			}
		}

		// Token: 0x0600126F RID: 4719 RVA: 0x00025710 File Offset: 0x00023910
		private bool ShouldSerializethreeday()
		{
			return this.threedaySpecified;
		}

		// Token: 0x06001270 RID: 4720 RVA: 0x00025728 File Offset: 0x00023928
		private void Resetthreeday()
		{
			this.threedaySpecified = false;
		}

		// Token: 0x170005E6 RID: 1510
		// (get) Token: 0x06001271 RID: 4721 RVA: 0x00025734 File Offset: 0x00023934
		// (set) Token: 0x06001272 RID: 4722 RVA: 0x00025760 File Offset: 0x00023960
		[ProtoMember(4, IsRequired = false, Name = "sevenday", DataFormat = DataFormat.Default)]
		public bool sevenday
		{
			get
			{
				return this._sevenday ?? false;
			}
			set
			{
				this._sevenday = new bool?(value);
			}
		}

		// Token: 0x170005E7 RID: 1511
		// (get) Token: 0x06001273 RID: 4723 RVA: 0x00025770 File Offset: 0x00023970
		// (set) Token: 0x06001274 RID: 4724 RVA: 0x00025790 File Offset: 0x00023990
		[XmlIgnore]
		[Browsable(false)]
		public bool sevendaySpecified
		{
			get
			{
				return this._sevenday != null;
			}
			set
			{
				bool flag = value == (this._sevenday == null);
				if (flag)
				{
					this._sevenday = (value ? new bool?(this.sevenday) : null);
				}
			}
		}

		// Token: 0x06001275 RID: 4725 RVA: 0x000257D4 File Offset: 0x000239D4
		private bool ShouldSerializesevenday()
		{
			return this.sevendaySpecified;
		}

		// Token: 0x06001276 RID: 4726 RVA: 0x000257EC File Offset: 0x000239EC
		private void Resetsevenday()
		{
			this.sevendaySpecified = false;
		}

		// Token: 0x06001277 RID: 4727 RVA: 0x000257F8 File Offset: 0x000239F8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000498 RID: 1176
		private bool? _twoday;

		// Token: 0x04000499 RID: 1177
		private bool? _fiveday;

		// Token: 0x0400049A RID: 1178
		private bool? _threeday;

		// Token: 0x0400049B RID: 1179
		private bool? _sevenday;

		// Token: 0x0400049C RID: 1180
		private IExtension extensionObject;
	}
}

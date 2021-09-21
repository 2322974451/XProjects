using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005CB RID: 1483
	[ProtoContract(Name = "StageResultInfo")]
	[Serializable]
	public class StageResultInfo : IExtensible
	{
		// Token: 0x170019E1 RID: 6625
		// (get) Token: 0x0600539C RID: 21404 RVA: 0x0009F0C4 File Offset: 0x0009D2C4
		// (set) Token: 0x0600539D RID: 21405 RVA: 0x0009F0F0 File Offset: 0x0009D2F0
		[ProtoMember(1, IsRequired = false, Name = "stageType", DataFormat = DataFormat.TwosComplement)]
		public uint stageType
		{
			get
			{
				return this._stageType ?? 0U;
			}
			set
			{
				this._stageType = new uint?(value);
			}
		}

		// Token: 0x170019E2 RID: 6626
		// (get) Token: 0x0600539E RID: 21406 RVA: 0x0009F100 File Offset: 0x0009D300
		// (set) Token: 0x0600539F RID: 21407 RVA: 0x0009F120 File Offset: 0x0009D320
		[XmlIgnore]
		[Browsable(false)]
		public bool stageTypeSpecified
		{
			get
			{
				return this._stageType != null;
			}
			set
			{
				bool flag = value == (this._stageType == null);
				if (flag)
				{
					this._stageType = (value ? new uint?(this.stageType) : null);
				}
			}
		}

		// Token: 0x060053A0 RID: 21408 RVA: 0x0009F164 File Offset: 0x0009D364
		private bool ShouldSerializestageType()
		{
			return this.stageTypeSpecified;
		}

		// Token: 0x060053A1 RID: 21409 RVA: 0x0009F17C File Offset: 0x0009D37C
		private void ResetstageType()
		{
			this.stageTypeSpecified = false;
		}

		// Token: 0x170019E3 RID: 6627
		// (get) Token: 0x060053A2 RID: 21410 RVA: 0x0009F188 File Offset: 0x0009D388
		// (set) Token: 0x060053A3 RID: 21411 RVA: 0x0009F1B4 File Offset: 0x0009D3B4
		[ProtoMember(2, IsRequired = false, Name = "stageID", DataFormat = DataFormat.TwosComplement)]
		public uint stageID
		{
			get
			{
				return this._stageID ?? 0U;
			}
			set
			{
				this._stageID = new uint?(value);
			}
		}

		// Token: 0x170019E4 RID: 6628
		// (get) Token: 0x060053A4 RID: 21412 RVA: 0x0009F1C4 File Offset: 0x0009D3C4
		// (set) Token: 0x060053A5 RID: 21413 RVA: 0x0009F1E4 File Offset: 0x0009D3E4
		[XmlIgnore]
		[Browsable(false)]
		public bool stageIDSpecified
		{
			get
			{
				return this._stageID != null;
			}
			set
			{
				bool flag = value == (this._stageID == null);
				if (flag)
				{
					this._stageID = (value ? new uint?(this.stageID) : null);
				}
			}
		}

		// Token: 0x060053A6 RID: 21414 RVA: 0x0009F228 File Offset: 0x0009D428
		private bool ShouldSerializestageID()
		{
			return this.stageIDSpecified;
		}

		// Token: 0x060053A7 RID: 21415 RVA: 0x0009F240 File Offset: 0x0009D440
		private void ResetstageID()
		{
			this.stageIDSpecified = false;
		}

		// Token: 0x170019E5 RID: 6629
		// (get) Token: 0x060053A8 RID: 21416 RVA: 0x0009F24C File Offset: 0x0009D44C
		// (set) Token: 0x060053A9 RID: 21417 RVA: 0x0009F278 File Offset: 0x0009D478
		[ProtoMember(3, IsRequired = false, Name = "isStageFailed", DataFormat = DataFormat.Default)]
		public bool isStageFailed
		{
			get
			{
				return this._isStageFailed ?? false;
			}
			set
			{
				this._isStageFailed = new bool?(value);
			}
		}

		// Token: 0x170019E6 RID: 6630
		// (get) Token: 0x060053AA RID: 21418 RVA: 0x0009F288 File Offset: 0x0009D488
		// (set) Token: 0x060053AB RID: 21419 RVA: 0x0009F2A8 File Offset: 0x0009D4A8
		[XmlIgnore]
		[Browsable(false)]
		public bool isStageFailedSpecified
		{
			get
			{
				return this._isStageFailed != null;
			}
			set
			{
				bool flag = value == (this._isStageFailed == null);
				if (flag)
				{
					this._isStageFailed = (value ? new bool?(this.isStageFailed) : null);
				}
			}
		}

		// Token: 0x060053AC RID: 21420 RVA: 0x0009F2EC File Offset: 0x0009D4EC
		private bool ShouldSerializeisStageFailed()
		{
			return this.isStageFailedSpecified;
		}

		// Token: 0x060053AD RID: 21421 RVA: 0x0009F304 File Offset: 0x0009D504
		private void ResetisStageFailed()
		{
			this.isStageFailedSpecified = false;
		}

		// Token: 0x170019E7 RID: 6631
		// (get) Token: 0x060053AE RID: 21422 RVA: 0x0009F310 File Offset: 0x0009D510
		// (set) Token: 0x060053AF RID: 21423 RVA: 0x0009F33C File Offset: 0x0009D53C
		[ProtoMember(4, IsRequired = false, Name = "timespan", DataFormat = DataFormat.TwosComplement)]
		public uint timespan
		{
			get
			{
				return this._timespan ?? 0U;
			}
			set
			{
				this._timespan = new uint?(value);
			}
		}

		// Token: 0x170019E8 RID: 6632
		// (get) Token: 0x060053B0 RID: 21424 RVA: 0x0009F34C File Offset: 0x0009D54C
		// (set) Token: 0x060053B1 RID: 21425 RVA: 0x0009F36C File Offset: 0x0009D56C
		[XmlIgnore]
		[Browsable(false)]
		public bool timespanSpecified
		{
			get
			{
				return this._timespan != null;
			}
			set
			{
				bool flag = value == (this._timespan == null);
				if (flag)
				{
					this._timespan = (value ? new uint?(this.timespan) : null);
				}
			}
		}

		// Token: 0x060053B2 RID: 21426 RVA: 0x0009F3B0 File Offset: 0x0009D5B0
		private bool ShouldSerializetimespan()
		{
			return this.timespanSpecified;
		}

		// Token: 0x060053B3 RID: 21427 RVA: 0x0009F3C8 File Offset: 0x0009D5C8
		private void Resettimespan()
		{
			this.timespanSpecified = false;
		}

		// Token: 0x170019E9 RID: 6633
		// (get) Token: 0x060053B4 RID: 21428 RVA: 0x0009F3D4 File Offset: 0x0009D5D4
		// (set) Token: 0x060053B5 RID: 21429 RVA: 0x0009F400 File Offset: 0x0009D600
		[ProtoMember(5, IsRequired = false, Name = "abyssid", DataFormat = DataFormat.TwosComplement)]
		public uint abyssid
		{
			get
			{
				return this._abyssid ?? 0U;
			}
			set
			{
				this._abyssid = new uint?(value);
			}
		}

		// Token: 0x170019EA RID: 6634
		// (get) Token: 0x060053B6 RID: 21430 RVA: 0x0009F410 File Offset: 0x0009D610
		// (set) Token: 0x060053B7 RID: 21431 RVA: 0x0009F430 File Offset: 0x0009D630
		[XmlIgnore]
		[Browsable(false)]
		public bool abyssidSpecified
		{
			get
			{
				return this._abyssid != null;
			}
			set
			{
				bool flag = value == (this._abyssid == null);
				if (flag)
				{
					this._abyssid = (value ? new uint?(this.abyssid) : null);
				}
			}
		}

		// Token: 0x060053B8 RID: 21432 RVA: 0x0009F474 File Offset: 0x0009D674
		private bool ShouldSerializeabyssid()
		{
			return this.abyssidSpecified;
		}

		// Token: 0x060053B9 RID: 21433 RVA: 0x0009F48C File Offset: 0x0009D68C
		private void Resetabyssid()
		{
			this.abyssidSpecified = false;
		}

		// Token: 0x170019EB RID: 6635
		// (get) Token: 0x060053BA RID: 21434 RVA: 0x0009F498 File Offset: 0x0009D698
		// (set) Token: 0x060053BB RID: 21435 RVA: 0x0009F4B0 File Offset: 0x0009D6B0
		[ProtoMember(6, IsRequired = false, Name = "mobabattle", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MobaBattleResult mobabattle
		{
			get
			{
				return this._mobabattle;
			}
			set
			{
				this._mobabattle = value;
			}
		}

		// Token: 0x170019EC RID: 6636
		// (get) Token: 0x060053BC RID: 21436 RVA: 0x0009F4BC File Offset: 0x0009D6BC
		// (set) Token: 0x060053BD RID: 21437 RVA: 0x0009F4D4 File Offset: 0x0009D6D4
		[ProtoMember(7, IsRequired = false, Name = "weekend4v4tmresult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WeekEnd4v4TeamResult weekend4v4tmresult
		{
			get
			{
				return this._weekend4v4tmresult;
			}
			set
			{
				this._weekend4v4tmresult = value;
			}
		}

		// Token: 0x170019ED RID: 6637
		// (get) Token: 0x060053BE RID: 21438 RVA: 0x0009F4E0 File Offset: 0x0009D6E0
		// (set) Token: 0x060053BF RID: 21439 RVA: 0x0009F50C File Offset: 0x0009D70C
		[ProtoMember(8, IsRequired = false, Name = "end", DataFormat = DataFormat.Default)]
		public bool end
		{
			get
			{
				return this._end ?? false;
			}
			set
			{
				this._end = new bool?(value);
			}
		}

		// Token: 0x170019EE RID: 6638
		// (get) Token: 0x060053C0 RID: 21440 RVA: 0x0009F51C File Offset: 0x0009D71C
		// (set) Token: 0x060053C1 RID: 21441 RVA: 0x0009F53C File Offset: 0x0009D73C
		[XmlIgnore]
		[Browsable(false)]
		public bool endSpecified
		{
			get
			{
				return this._end != null;
			}
			set
			{
				bool flag = value == (this._end == null);
				if (flag)
				{
					this._end = (value ? new bool?(this.end) : null);
				}
			}
		}

		// Token: 0x060053C2 RID: 21442 RVA: 0x0009F580 File Offset: 0x0009D780
		private bool ShouldSerializeend()
		{
			return this.endSpecified;
		}

		// Token: 0x060053C3 RID: 21443 RVA: 0x0009F598 File Offset: 0x0009D798
		private void Resetend()
		{
			this.endSpecified = false;
		}

		// Token: 0x060053C4 RID: 21444 RVA: 0x0009F5A4 File Offset: 0x0009D7A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400146B RID: 5227
		private uint? _stageType;

		// Token: 0x0400146C RID: 5228
		private uint? _stageID;

		// Token: 0x0400146D RID: 5229
		private bool? _isStageFailed;

		// Token: 0x0400146E RID: 5230
		private uint? _timespan;

		// Token: 0x0400146F RID: 5231
		private uint? _abyssid;

		// Token: 0x04001470 RID: 5232
		private MobaBattleResult _mobabattle = null;

		// Token: 0x04001471 RID: 5233
		private WeekEnd4v4TeamResult _weekend4v4tmresult = null;

		// Token: 0x04001472 RID: 5234
		private bool? _end;

		// Token: 0x04001473 RID: 5235
		private IExtension extensionObject;
	}
}

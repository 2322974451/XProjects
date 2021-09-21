using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200011E RID: 286
	[ProtoContract(Name = "LevelSealInfo")]
	[Serializable]
	public class LevelSealInfo : IExtensible
	{
		// Token: 0x170005AB RID: 1451
		// (get) Token: 0x060011B3 RID: 4531 RVA: 0x000240B4 File Offset: 0x000222B4
		// (set) Token: 0x060011B4 RID: 4532 RVA: 0x000240E0 File Offset: 0x000222E0
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x170005AC RID: 1452
		// (get) Token: 0x060011B5 RID: 4533 RVA: 0x000240F0 File Offset: 0x000222F0
		// (set) Token: 0x060011B6 RID: 4534 RVA: 0x00024110 File Offset: 0x00022310
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x060011B7 RID: 4535 RVA: 0x00024154 File Offset: 0x00022354
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060011B8 RID: 4536 RVA: 0x0002416C File Offset: 0x0002236C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170005AD RID: 1453
		// (get) Token: 0x060011B9 RID: 4537 RVA: 0x00024178 File Offset: 0x00022378
		// (set) Token: 0x060011BA RID: 4538 RVA: 0x000241A4 File Offset: 0x000223A4
		[ProtoMember(2, IsRequired = false, Name = "endTime", DataFormat = DataFormat.TwosComplement)]
		public uint endTime
		{
			get
			{
				return this._endTime ?? 0U;
			}
			set
			{
				this._endTime = new uint?(value);
			}
		}

		// Token: 0x170005AE RID: 1454
		// (get) Token: 0x060011BB RID: 4539 RVA: 0x000241B4 File Offset: 0x000223B4
		// (set) Token: 0x060011BC RID: 4540 RVA: 0x000241D4 File Offset: 0x000223D4
		[XmlIgnore]
		[Browsable(false)]
		public bool endTimeSpecified
		{
			get
			{
				return this._endTime != null;
			}
			set
			{
				bool flag = value == (this._endTime == null);
				if (flag)
				{
					this._endTime = (value ? new uint?(this.endTime) : null);
				}
			}
		}

		// Token: 0x060011BD RID: 4541 RVA: 0x00024218 File Offset: 0x00022418
		private bool ShouldSerializeendTime()
		{
			return this.endTimeSpecified;
		}

		// Token: 0x060011BE RID: 4542 RVA: 0x00024230 File Offset: 0x00022430
		private void ResetendTime()
		{
			this.endTimeSpecified = false;
		}

		// Token: 0x170005AF RID: 1455
		// (get) Token: 0x060011BF RID: 4543 RVA: 0x0002423C File Offset: 0x0002243C
		// (set) Token: 0x060011C0 RID: 4544 RVA: 0x00024268 File Offset: 0x00022468
		[ProtoMember(3, IsRequired = false, Name = "unLockBossCount", DataFormat = DataFormat.TwosComplement)]
		public uint unLockBossCount
		{
			get
			{
				return this._unLockBossCount ?? 0U;
			}
			set
			{
				this._unLockBossCount = new uint?(value);
			}
		}

		// Token: 0x170005B0 RID: 1456
		// (get) Token: 0x060011C1 RID: 4545 RVA: 0x00024278 File Offset: 0x00022478
		// (set) Token: 0x060011C2 RID: 4546 RVA: 0x00024298 File Offset: 0x00022498
		[XmlIgnore]
		[Browsable(false)]
		public bool unLockBossCountSpecified
		{
			get
			{
				return this._unLockBossCount != null;
			}
			set
			{
				bool flag = value == (this._unLockBossCount == null);
				if (flag)
				{
					this._unLockBossCount = (value ? new uint?(this.unLockBossCount) : null);
				}
			}
		}

		// Token: 0x060011C3 RID: 4547 RVA: 0x000242DC File Offset: 0x000224DC
		private bool ShouldSerializeunLockBossCount()
		{
			return this.unLockBossCountSpecified;
		}

		// Token: 0x060011C4 RID: 4548 RVA: 0x000242F4 File Offset: 0x000224F4
		private void ResetunLockBossCount()
		{
			this.unLockBossCountSpecified = false;
		}

		// Token: 0x170005B1 RID: 1457
		// (get) Token: 0x060011C5 RID: 4549 RVA: 0x00024300 File Offset: 0x00022500
		// (set) Token: 0x060011C6 RID: 4550 RVA: 0x0002432C File Offset: 0x0002252C
		[ProtoMember(4, IsRequired = false, Name = "status", DataFormat = DataFormat.TwosComplement)]
		public uint status
		{
			get
			{
				return this._status ?? 0U;
			}
			set
			{
				this._status = new uint?(value);
			}
		}

		// Token: 0x170005B2 RID: 1458
		// (get) Token: 0x060011C7 RID: 4551 RVA: 0x0002433C File Offset: 0x0002253C
		// (set) Token: 0x060011C8 RID: 4552 RVA: 0x0002435C File Offset: 0x0002255C
		[XmlIgnore]
		[Browsable(false)]
		public bool statusSpecified
		{
			get
			{
				return this._status != null;
			}
			set
			{
				bool flag = value == (this._status == null);
				if (flag)
				{
					this._status = (value ? new uint?(this.status) : null);
				}
			}
		}

		// Token: 0x060011C9 RID: 4553 RVA: 0x000243A0 File Offset: 0x000225A0
		private bool ShouldSerializestatus()
		{
			return this.statusSpecified;
		}

		// Token: 0x060011CA RID: 4554 RVA: 0x000243B8 File Offset: 0x000225B8
		private void Resetstatus()
		{
			this.statusSpecified = false;
		}

		// Token: 0x170005B3 RID: 1459
		// (get) Token: 0x060011CB RID: 4555 RVA: 0x000243C4 File Offset: 0x000225C4
		// (set) Token: 0x060011CC RID: 4556 RVA: 0x000243F0 File Offset: 0x000225F0
		[ProtoMember(5, IsRequired = false, Name = "totalCollectCount", DataFormat = DataFormat.TwosComplement)]
		public uint totalCollectCount
		{
			get
			{
				return this._totalCollectCount ?? 0U;
			}
			set
			{
				this._totalCollectCount = new uint?(value);
			}
		}

		// Token: 0x170005B4 RID: 1460
		// (get) Token: 0x060011CD RID: 4557 RVA: 0x00024400 File Offset: 0x00022600
		// (set) Token: 0x060011CE RID: 4558 RVA: 0x00024420 File Offset: 0x00022620
		[XmlIgnore]
		[Browsable(false)]
		public bool totalCollectCountSpecified
		{
			get
			{
				return this._totalCollectCount != null;
			}
			set
			{
				bool flag = value == (this._totalCollectCount == null);
				if (flag)
				{
					this._totalCollectCount = (value ? new uint?(this.totalCollectCount) : null);
				}
			}
		}

		// Token: 0x060011CF RID: 4559 RVA: 0x00024464 File Offset: 0x00022664
		private bool ShouldSerializetotalCollectCount()
		{
			return this.totalCollectCountSpecified;
		}

		// Token: 0x060011D0 RID: 4560 RVA: 0x0002447C File Offset: 0x0002267C
		private void ResettotalCollectCount()
		{
			this.totalCollectCountSpecified = false;
		}

		// Token: 0x170005B5 RID: 1461
		// (get) Token: 0x060011D1 RID: 4561 RVA: 0x00024488 File Offset: 0x00022688
		// (set) Token: 0x060011D2 RID: 4562 RVA: 0x000244B4 File Offset: 0x000226B4
		[ProtoMember(6, IsRequired = false, Name = "selfCollectCount", DataFormat = DataFormat.TwosComplement)]
		public uint selfCollectCount
		{
			get
			{
				return this._selfCollectCount ?? 0U;
			}
			set
			{
				this._selfCollectCount = new uint?(value);
			}
		}

		// Token: 0x170005B6 RID: 1462
		// (get) Token: 0x060011D3 RID: 4563 RVA: 0x000244C4 File Offset: 0x000226C4
		// (set) Token: 0x060011D4 RID: 4564 RVA: 0x000244E4 File Offset: 0x000226E4
		[XmlIgnore]
		[Browsable(false)]
		public bool selfCollectCountSpecified
		{
			get
			{
				return this._selfCollectCount != null;
			}
			set
			{
				bool flag = value == (this._selfCollectCount == null);
				if (flag)
				{
					this._selfCollectCount = (value ? new uint?(this.selfCollectCount) : null);
				}
			}
		}

		// Token: 0x060011D5 RID: 4565 RVA: 0x00024528 File Offset: 0x00022728
		private bool ShouldSerializeselfCollectCount()
		{
			return this.selfCollectCountSpecified;
		}

		// Token: 0x060011D6 RID: 4566 RVA: 0x00024540 File Offset: 0x00022740
		private void ResetselfCollectCount()
		{
			this.selfCollectCountSpecified = false;
		}

		// Token: 0x170005B7 RID: 1463
		// (get) Token: 0x060011D7 RID: 4567 RVA: 0x0002454C File Offset: 0x0002274C
		// (set) Token: 0x060011D8 RID: 4568 RVA: 0x00024578 File Offset: 0x00022778
		[ProtoMember(7, IsRequired = false, Name = "selfAwardCountIndex", DataFormat = DataFormat.TwosComplement)]
		public int selfAwardCountIndex
		{
			get
			{
				return this._selfAwardCountIndex ?? 0;
			}
			set
			{
				this._selfAwardCountIndex = new int?(value);
			}
		}

		// Token: 0x170005B8 RID: 1464
		// (get) Token: 0x060011D9 RID: 4569 RVA: 0x00024588 File Offset: 0x00022788
		// (set) Token: 0x060011DA RID: 4570 RVA: 0x000245A8 File Offset: 0x000227A8
		[XmlIgnore]
		[Browsable(false)]
		public bool selfAwardCountIndexSpecified
		{
			get
			{
				return this._selfAwardCountIndex != null;
			}
			set
			{
				bool flag = value == (this._selfAwardCountIndex == null);
				if (flag)
				{
					this._selfAwardCountIndex = (value ? new int?(this.selfAwardCountIndex) : null);
				}
			}
		}

		// Token: 0x060011DB RID: 4571 RVA: 0x000245EC File Offset: 0x000227EC
		private bool ShouldSerializeselfAwardCountIndex()
		{
			return this.selfAwardCountIndexSpecified;
		}

		// Token: 0x060011DC RID: 4572 RVA: 0x00024604 File Offset: 0x00022804
		private void ResetselfAwardCountIndex()
		{
			this.selfAwardCountIndexSpecified = false;
		}

		// Token: 0x060011DD RID: 4573 RVA: 0x00024610 File Offset: 0x00022810
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400046F RID: 1135
		private uint? _type;

		// Token: 0x04000470 RID: 1136
		private uint? _endTime;

		// Token: 0x04000471 RID: 1137
		private uint? _unLockBossCount;

		// Token: 0x04000472 RID: 1138
		private uint? _status;

		// Token: 0x04000473 RID: 1139
		private uint? _totalCollectCount;

		// Token: 0x04000474 RID: 1140
		private uint? _selfCollectCount;

		// Token: 0x04000475 RID: 1141
		private int? _selfAwardCountIndex;

		// Token: 0x04000476 RID: 1142
		private IExtension extensionObject;
	}
}

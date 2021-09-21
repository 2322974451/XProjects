using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200056F RID: 1391
	[ProtoContract(Name = "BuffInfo")]
	[Serializable]
	public class BuffInfo : IExtensible
	{
		// Token: 0x170015E8 RID: 5608
		// (get) Token: 0x0600478B RID: 18315 RVA: 0x00087EF8 File Offset: 0x000860F8
		// (set) Token: 0x0600478C RID: 18316 RVA: 0x00087F24 File Offset: 0x00086124
		[ProtoMember(1, IsRequired = false, Name = "BuffID", DataFormat = DataFormat.TwosComplement)]
		public uint BuffID
		{
			get
			{
				return this._BuffID ?? 0U;
			}
			set
			{
				this._BuffID = new uint?(value);
			}
		}

		// Token: 0x170015E9 RID: 5609
		// (get) Token: 0x0600478D RID: 18317 RVA: 0x00087F34 File Offset: 0x00086134
		// (set) Token: 0x0600478E RID: 18318 RVA: 0x00087F54 File Offset: 0x00086154
		[XmlIgnore]
		[Browsable(false)]
		public bool BuffIDSpecified
		{
			get
			{
				return this._BuffID != null;
			}
			set
			{
				bool flag = value == (this._BuffID == null);
				if (flag)
				{
					this._BuffID = (value ? new uint?(this.BuffID) : null);
				}
			}
		}

		// Token: 0x0600478F RID: 18319 RVA: 0x00087F98 File Offset: 0x00086198
		private bool ShouldSerializeBuffID()
		{
			return this.BuffIDSpecified;
		}

		// Token: 0x06004790 RID: 18320 RVA: 0x00087FB0 File Offset: 0x000861B0
		private void ResetBuffID()
		{
			this.BuffIDSpecified = false;
		}

		// Token: 0x170015EA RID: 5610
		// (get) Token: 0x06004791 RID: 18321 RVA: 0x00087FBC File Offset: 0x000861BC
		// (set) Token: 0x06004792 RID: 18322 RVA: 0x00087FE8 File Offset: 0x000861E8
		[ProtoMember(2, IsRequired = false, Name = "BuffLevel", DataFormat = DataFormat.TwosComplement)]
		public uint BuffLevel
		{
			get
			{
				return this._BuffLevel ?? 0U;
			}
			set
			{
				this._BuffLevel = new uint?(value);
			}
		}

		// Token: 0x170015EB RID: 5611
		// (get) Token: 0x06004793 RID: 18323 RVA: 0x00087FF8 File Offset: 0x000861F8
		// (set) Token: 0x06004794 RID: 18324 RVA: 0x00088018 File Offset: 0x00086218
		[XmlIgnore]
		[Browsable(false)]
		public bool BuffLevelSpecified
		{
			get
			{
				return this._BuffLevel != null;
			}
			set
			{
				bool flag = value == (this._BuffLevel == null);
				if (flag)
				{
					this._BuffLevel = (value ? new uint?(this.BuffLevel) : null);
				}
			}
		}

		// Token: 0x06004795 RID: 18325 RVA: 0x0008805C File Offset: 0x0008625C
		private bool ShouldSerializeBuffLevel()
		{
			return this.BuffLevelSpecified;
		}

		// Token: 0x06004796 RID: 18326 RVA: 0x00088074 File Offset: 0x00086274
		private void ResetBuffLevel()
		{
			this.BuffLevelSpecified = false;
		}

		// Token: 0x170015EC RID: 5612
		// (get) Token: 0x06004797 RID: 18327 RVA: 0x00088080 File Offset: 0x00086280
		// (set) Token: 0x06004798 RID: 18328 RVA: 0x000880AC File Offset: 0x000862AC
		[ProtoMember(3, IsRequired = false, Name = "LeftTime", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170015ED RID: 5613
		// (get) Token: 0x06004799 RID: 18329 RVA: 0x000880BC File Offset: 0x000862BC
		// (set) Token: 0x0600479A RID: 18330 RVA: 0x000880DC File Offset: 0x000862DC
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

		// Token: 0x0600479B RID: 18331 RVA: 0x00088120 File Offset: 0x00086320
		private bool ShouldSerializeLeftTime()
		{
			return this.LeftTimeSpecified;
		}

		// Token: 0x0600479C RID: 18332 RVA: 0x00088138 File Offset: 0x00086338
		private void ResetLeftTime()
		{
			this.LeftTimeSpecified = false;
		}

		// Token: 0x170015EE RID: 5614
		// (get) Token: 0x0600479D RID: 18333 RVA: 0x00088144 File Offset: 0x00086344
		// (set) Token: 0x0600479E RID: 18334 RVA: 0x00088171 File Offset: 0x00086371
		[ProtoMember(4, IsRequired = false, Name = "MobUID", DataFormat = DataFormat.TwosComplement)]
		public ulong MobUID
		{
			get
			{
				return this._MobUID ?? 0UL;
			}
			set
			{
				this._MobUID = new ulong?(value);
			}
		}

		// Token: 0x170015EF RID: 5615
		// (get) Token: 0x0600479F RID: 18335 RVA: 0x00088180 File Offset: 0x00086380
		// (set) Token: 0x060047A0 RID: 18336 RVA: 0x000881A0 File Offset: 0x000863A0
		[XmlIgnore]
		[Browsable(false)]
		public bool MobUIDSpecified
		{
			get
			{
				return this._MobUID != null;
			}
			set
			{
				bool flag = value == (this._MobUID == null);
				if (flag)
				{
					this._MobUID = (value ? new ulong?(this.MobUID) : null);
				}
			}
		}

		// Token: 0x060047A1 RID: 18337 RVA: 0x000881E4 File Offset: 0x000863E4
		private bool ShouldSerializeMobUID()
		{
			return this.MobUIDSpecified;
		}

		// Token: 0x060047A2 RID: 18338 RVA: 0x000881FC File Offset: 0x000863FC
		private void ResetMobUID()
		{
			this.MobUIDSpecified = false;
		}

		// Token: 0x170015F0 RID: 5616
		// (get) Token: 0x060047A3 RID: 18339 RVA: 0x00088208 File Offset: 0x00086408
		// (set) Token: 0x060047A4 RID: 18340 RVA: 0x0008823C File Offset: 0x0008643C
		[ProtoMember(5, IsRequired = false, Name = "MaxHP", DataFormat = DataFormat.TwosComplement)]
		public double MaxHP
		{
			get
			{
				return this._MaxHP ?? 0.0;
			}
			set
			{
				this._MaxHP = new double?(value);
			}
		}

		// Token: 0x170015F1 RID: 5617
		// (get) Token: 0x060047A5 RID: 18341 RVA: 0x0008824C File Offset: 0x0008644C
		// (set) Token: 0x060047A6 RID: 18342 RVA: 0x0008826C File Offset: 0x0008646C
		[XmlIgnore]
		[Browsable(false)]
		public bool MaxHPSpecified
		{
			get
			{
				return this._MaxHP != null;
			}
			set
			{
				bool flag = value == (this._MaxHP == null);
				if (flag)
				{
					this._MaxHP = (value ? new double?(this.MaxHP) : null);
				}
			}
		}

		// Token: 0x060047A7 RID: 18343 RVA: 0x000882B0 File Offset: 0x000864B0
		private bool ShouldSerializeMaxHP()
		{
			return this.MaxHPSpecified;
		}

		// Token: 0x060047A8 RID: 18344 RVA: 0x000882C8 File Offset: 0x000864C8
		private void ResetMaxHP()
		{
			this.MaxHPSpecified = false;
		}

		// Token: 0x170015F2 RID: 5618
		// (get) Token: 0x060047A9 RID: 18345 RVA: 0x000882D4 File Offset: 0x000864D4
		// (set) Token: 0x060047AA RID: 18346 RVA: 0x00088308 File Offset: 0x00086508
		[ProtoMember(6, IsRequired = false, Name = "CurHP", DataFormat = DataFormat.TwosComplement)]
		public double CurHP
		{
			get
			{
				return this._CurHP ?? 0.0;
			}
			set
			{
				this._CurHP = new double?(value);
			}
		}

		// Token: 0x170015F3 RID: 5619
		// (get) Token: 0x060047AB RID: 18347 RVA: 0x00088318 File Offset: 0x00086518
		// (set) Token: 0x060047AC RID: 18348 RVA: 0x00088338 File Offset: 0x00086538
		[XmlIgnore]
		[Browsable(false)]
		public bool CurHPSpecified
		{
			get
			{
				return this._CurHP != null;
			}
			set
			{
				bool flag = value == (this._CurHP == null);
				if (flag)
				{
					this._CurHP = (value ? new double?(this.CurHP) : null);
				}
			}
		}

		// Token: 0x060047AD RID: 18349 RVA: 0x0008837C File Offset: 0x0008657C
		private bool ShouldSerializeCurHP()
		{
			return this.CurHPSpecified;
		}

		// Token: 0x060047AE RID: 18350 RVA: 0x00088394 File Offset: 0x00086594
		private void ResetCurHP()
		{
			this.CurHPSpecified = false;
		}

		// Token: 0x170015F4 RID: 5620
		// (get) Token: 0x060047AF RID: 18351 RVA: 0x000883A0 File Offset: 0x000865A0
		// (set) Token: 0x060047B0 RID: 18352 RVA: 0x000883CC File Offset: 0x000865CC
		[ProtoMember(7, IsRequired = false, Name = "StackCount", DataFormat = DataFormat.TwosComplement)]
		public uint StackCount
		{
			get
			{
				return this._StackCount ?? 0U;
			}
			set
			{
				this._StackCount = new uint?(value);
			}
		}

		// Token: 0x170015F5 RID: 5621
		// (get) Token: 0x060047B1 RID: 18353 RVA: 0x000883DC File Offset: 0x000865DC
		// (set) Token: 0x060047B2 RID: 18354 RVA: 0x000883FC File Offset: 0x000865FC
		[XmlIgnore]
		[Browsable(false)]
		public bool StackCountSpecified
		{
			get
			{
				return this._StackCount != null;
			}
			set
			{
				bool flag = value == (this._StackCount == null);
				if (flag)
				{
					this._StackCount = (value ? new uint?(this.StackCount) : null);
				}
			}
		}

		// Token: 0x060047B3 RID: 18355 RVA: 0x00088440 File Offset: 0x00086640
		private bool ShouldSerializeStackCount()
		{
			return this.StackCountSpecified;
		}

		// Token: 0x060047B4 RID: 18356 RVA: 0x00088458 File Offset: 0x00086658
		private void ResetStackCount()
		{
			this.StackCountSpecified = false;
		}

		// Token: 0x170015F6 RID: 5622
		// (get) Token: 0x060047B5 RID: 18357 RVA: 0x00088464 File Offset: 0x00086664
		// (set) Token: 0x060047B6 RID: 18358 RVA: 0x00088490 File Offset: 0x00086690
		[ProtoMember(8, IsRequired = false, Name = "bReduceCD", DataFormat = DataFormat.Default)]
		public bool bReduceCD
		{
			get
			{
				return this._bReduceCD ?? false;
			}
			set
			{
				this._bReduceCD = new bool?(value);
			}
		}

		// Token: 0x170015F7 RID: 5623
		// (get) Token: 0x060047B7 RID: 18359 RVA: 0x000884A0 File Offset: 0x000866A0
		// (set) Token: 0x060047B8 RID: 18360 RVA: 0x000884C0 File Offset: 0x000866C0
		[XmlIgnore]
		[Browsable(false)]
		public bool bReduceCDSpecified
		{
			get
			{
				return this._bReduceCD != null;
			}
			set
			{
				bool flag = value == (this._bReduceCD == null);
				if (flag)
				{
					this._bReduceCD = (value ? new bool?(this.bReduceCD) : null);
				}
			}
		}

		// Token: 0x060047B9 RID: 18361 RVA: 0x00088504 File Offset: 0x00086704
		private bool ShouldSerializebReduceCD()
		{
			return this.bReduceCDSpecified;
		}

		// Token: 0x060047BA RID: 18362 RVA: 0x0008851C File Offset: 0x0008671C
		private void ResetbReduceCD()
		{
			this.bReduceCDSpecified = false;
		}

		// Token: 0x170015F8 RID: 5624
		// (get) Token: 0x060047BB RID: 18363 RVA: 0x00088528 File Offset: 0x00086728
		// (set) Token: 0x060047BC RID: 18364 RVA: 0x00088554 File Offset: 0x00086754
		[ProtoMember(9, IsRequired = false, Name = "TransformID", DataFormat = DataFormat.TwosComplement)]
		public int TransformID
		{
			get
			{
				return this._TransformID ?? 0;
			}
			set
			{
				this._TransformID = new int?(value);
			}
		}

		// Token: 0x170015F9 RID: 5625
		// (get) Token: 0x060047BD RID: 18365 RVA: 0x00088564 File Offset: 0x00086764
		// (set) Token: 0x060047BE RID: 18366 RVA: 0x00088584 File Offset: 0x00086784
		[XmlIgnore]
		[Browsable(false)]
		public bool TransformIDSpecified
		{
			get
			{
				return this._TransformID != null;
			}
			set
			{
				bool flag = value == (this._TransformID == null);
				if (flag)
				{
					this._TransformID = (value ? new int?(this.TransformID) : null);
				}
			}
		}

		// Token: 0x060047BF RID: 18367 RVA: 0x000885C8 File Offset: 0x000867C8
		private bool ShouldSerializeTransformID()
		{
			return this.TransformIDSpecified;
		}

		// Token: 0x060047C0 RID: 18368 RVA: 0x000885E0 File Offset: 0x000867E0
		private void ResetTransformID()
		{
			this.TransformIDSpecified = false;
		}

		// Token: 0x060047C1 RID: 18369 RVA: 0x000885EC File Offset: 0x000867EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040011E2 RID: 4578
		private uint? _BuffID;

		// Token: 0x040011E3 RID: 4579
		private uint? _BuffLevel;

		// Token: 0x040011E4 RID: 4580
		private uint? _LeftTime;

		// Token: 0x040011E5 RID: 4581
		private ulong? _MobUID;

		// Token: 0x040011E6 RID: 4582
		private double? _MaxHP;

		// Token: 0x040011E7 RID: 4583
		private double? _CurHP;

		// Token: 0x040011E8 RID: 4584
		private uint? _StackCount;

		// Token: 0x040011E9 RID: 4585
		private bool? _bReduceCD;

		// Token: 0x040011EA RID: 4586
		private int? _TransformID;

		// Token: 0x040011EB RID: 4587
		private IExtension extensionObject;
	}
}

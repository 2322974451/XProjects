using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000683 RID: 1667
	[ProtoContract(Name = "StepSyncData")]
	[Serializable]
	public class StepSyncData : IExtensible
	{
		// Token: 0x170021DB RID: 8667
		// (get) Token: 0x06006AF8 RID: 27384 RVA: 0x000CC978 File Offset: 0x000CAB78
		// (set) Token: 0x06006AF9 RID: 27385 RVA: 0x000CC9A4 File Offset: 0x000CABA4
		[ProtoMember(1, IsRequired = false, Name = "PosXZ", DataFormat = DataFormat.TwosComplement)]
		public int PosXZ
		{
			get
			{
				return this._PosXZ ?? 0;
			}
			set
			{
				this._PosXZ = new int?(value);
			}
		}

		// Token: 0x170021DC RID: 8668
		// (get) Token: 0x06006AFA RID: 27386 RVA: 0x000CC9B4 File Offset: 0x000CABB4
		// (set) Token: 0x06006AFB RID: 27387 RVA: 0x000CC9D4 File Offset: 0x000CABD4
		[XmlIgnore]
		[Browsable(false)]
		public bool PosXZSpecified
		{
			get
			{
				return this._PosXZ != null;
			}
			set
			{
				bool flag = value == (this._PosXZ == null);
				if (flag)
				{
					this._PosXZ = (value ? new int?(this.PosXZ) : null);
				}
			}
		}

		// Token: 0x06006AFC RID: 27388 RVA: 0x000CCA18 File Offset: 0x000CAC18
		private bool ShouldSerializePosXZ()
		{
			return this.PosXZSpecified;
		}

		// Token: 0x06006AFD RID: 27389 RVA: 0x000CCA30 File Offset: 0x000CAC30
		private void ResetPosXZ()
		{
			this.PosXZSpecified = false;
		}

		// Token: 0x170021DD RID: 8669
		// (get) Token: 0x06006AFE RID: 27390 RVA: 0x000CCA3C File Offset: 0x000CAC3C
		// (set) Token: 0x06006AFF RID: 27391 RVA: 0x000CCA69 File Offset: 0x000CAC69
		[ProtoMember(2, IsRequired = false, Name = "EntityID", DataFormat = DataFormat.TwosComplement)]
		public ulong EntityID
		{
			get
			{
				return this._EntityID ?? 0UL;
			}
			set
			{
				this._EntityID = new ulong?(value);
			}
		}

		// Token: 0x170021DE RID: 8670
		// (get) Token: 0x06006B00 RID: 27392 RVA: 0x000CCA78 File Offset: 0x000CAC78
		// (set) Token: 0x06006B01 RID: 27393 RVA: 0x000CCA98 File Offset: 0x000CAC98
		[XmlIgnore]
		[Browsable(false)]
		public bool EntityIDSpecified
		{
			get
			{
				return this._EntityID != null;
			}
			set
			{
				bool flag = value == (this._EntityID == null);
				if (flag)
				{
					this._EntityID = (value ? new ulong?(this.EntityID) : null);
				}
			}
		}

		// Token: 0x06006B02 RID: 27394 RVA: 0x000CCADC File Offset: 0x000CACDC
		private bool ShouldSerializeEntityID()
		{
			return this.EntityIDSpecified;
		}

		// Token: 0x06006B03 RID: 27395 RVA: 0x000CCAF4 File Offset: 0x000CACF4
		private void ResetEntityID()
		{
			this.EntityIDSpecified = false;
		}

		// Token: 0x170021DF RID: 8671
		// (get) Token: 0x06006B04 RID: 27396 RVA: 0x000CCB00 File Offset: 0x000CAD00
		// (set) Token: 0x06006B05 RID: 27397 RVA: 0x000CCB2C File Offset: 0x000CAD2C
		[ProtoMember(3, IsRequired = false, Name = "Skillid", DataFormat = DataFormat.TwosComplement)]
		public int Skillid
		{
			get
			{
				return this._Skillid ?? 0;
			}
			set
			{
				this._Skillid = new int?(value);
			}
		}

		// Token: 0x170021E0 RID: 8672
		// (get) Token: 0x06006B06 RID: 27398 RVA: 0x000CCB3C File Offset: 0x000CAD3C
		// (set) Token: 0x06006B07 RID: 27399 RVA: 0x000CCB5C File Offset: 0x000CAD5C
		[XmlIgnore]
		[Browsable(false)]
		public bool SkillidSpecified
		{
			get
			{
				return this._Skillid != null;
			}
			set
			{
				bool flag = value == (this._Skillid == null);
				if (flag)
				{
					this._Skillid = (value ? new int?(this.Skillid) : null);
				}
			}
		}

		// Token: 0x06006B08 RID: 27400 RVA: 0x000CCBA0 File Offset: 0x000CADA0
		private bool ShouldSerializeSkillid()
		{
			return this.SkillidSpecified;
		}

		// Token: 0x06006B09 RID: 27401 RVA: 0x000CCBB8 File Offset: 0x000CADB8
		private void ResetSkillid()
		{
			this.SkillidSpecified = false;
		}

		// Token: 0x170021E1 RID: 8673
		// (get) Token: 0x06006B0A RID: 27402 RVA: 0x000CCBC4 File Offset: 0x000CADC4
		// (set) Token: 0x06006B0B RID: 27403 RVA: 0x000CCBF0 File Offset: 0x000CADF0
		[ProtoMember(4, IsRequired = false, Name = "HitIdx", DataFormat = DataFormat.TwosComplement)]
		public int HitIdx
		{
			get
			{
				return this._HitIdx ?? 0;
			}
			set
			{
				this._HitIdx = new int?(value);
			}
		}

		// Token: 0x170021E2 RID: 8674
		// (get) Token: 0x06006B0C RID: 27404 RVA: 0x000CCC00 File Offset: 0x000CAE00
		// (set) Token: 0x06006B0D RID: 27405 RVA: 0x000CCC20 File Offset: 0x000CAE20
		[XmlIgnore]
		[Browsable(false)]
		public bool HitIdxSpecified
		{
			get
			{
				return this._HitIdx != null;
			}
			set
			{
				bool flag = value == (this._HitIdx == null);
				if (flag)
				{
					this._HitIdx = (value ? new int?(this.HitIdx) : null);
				}
			}
		}

		// Token: 0x06006B0E RID: 27406 RVA: 0x000CCC64 File Offset: 0x000CAE64
		private bool ShouldSerializeHitIdx()
		{
			return this.HitIdxSpecified;
		}

		// Token: 0x06006B0F RID: 27407 RVA: 0x000CCC7C File Offset: 0x000CAE7C
		private void ResetHitIdx()
		{
			this.HitIdxSpecified = false;
		}

		// Token: 0x170021E3 RID: 8675
		// (get) Token: 0x06006B10 RID: 27408 RVA: 0x000CCC88 File Offset: 0x000CAE88
		// (set) Token: 0x06006B11 RID: 27409 RVA: 0x000CCCB5 File Offset: 0x000CAEB5
		[ProtoMember(5, IsRequired = false, Name = "OpposerID", DataFormat = DataFormat.TwosComplement)]
		public ulong OpposerID
		{
			get
			{
				return this._OpposerID ?? 0UL;
			}
			set
			{
				this._OpposerID = new ulong?(value);
			}
		}

		// Token: 0x170021E4 RID: 8676
		// (get) Token: 0x06006B12 RID: 27410 RVA: 0x000CCCC4 File Offset: 0x000CAEC4
		// (set) Token: 0x06006B13 RID: 27411 RVA: 0x000CCCE4 File Offset: 0x000CAEE4
		[XmlIgnore]
		[Browsable(false)]
		public bool OpposerIDSpecified
		{
			get
			{
				return this._OpposerID != null;
			}
			set
			{
				bool flag = value == (this._OpposerID == null);
				if (flag)
				{
					this._OpposerID = (value ? new ulong?(this.OpposerID) : null);
				}
			}
		}

		// Token: 0x06006B14 RID: 27412 RVA: 0x000CCD28 File Offset: 0x000CAF28
		private bool ShouldSerializeOpposerID()
		{
			return this.OpposerIDSpecified;
		}

		// Token: 0x06006B15 RID: 27413 RVA: 0x000CCD40 File Offset: 0x000CAF40
		private void ResetOpposerID()
		{
			this.OpposerIDSpecified = false;
		}

		// Token: 0x170021E5 RID: 8677
		// (get) Token: 0x06006B16 RID: 27414 RVA: 0x000CCD4C File Offset: 0x000CAF4C
		// (set) Token: 0x06006B17 RID: 27415 RVA: 0x000CCD78 File Offset: 0x000CAF78
		[ProtoMember(6, IsRequired = false, Name = "HitForceToFly", DataFormat = DataFormat.Default)]
		public bool HitForceToFly
		{
			get
			{
				return this._HitForceToFly ?? false;
			}
			set
			{
				this._HitForceToFly = new bool?(value);
			}
		}

		// Token: 0x170021E6 RID: 8678
		// (get) Token: 0x06006B18 RID: 27416 RVA: 0x000CCD88 File Offset: 0x000CAF88
		// (set) Token: 0x06006B19 RID: 27417 RVA: 0x000CCDA8 File Offset: 0x000CAFA8
		[XmlIgnore]
		[Browsable(false)]
		public bool HitForceToFlySpecified
		{
			get
			{
				return this._HitForceToFly != null;
			}
			set
			{
				bool flag = value == (this._HitForceToFly == null);
				if (flag)
				{
					this._HitForceToFly = (value ? new bool?(this.HitForceToFly) : null);
				}
			}
		}

		// Token: 0x06006B1A RID: 27418 RVA: 0x000CCDEC File Offset: 0x000CAFEC
		private bool ShouldSerializeHitForceToFly()
		{
			return this.HitForceToFlySpecified;
		}

		// Token: 0x06006B1B RID: 27419 RVA: 0x000CCE04 File Offset: 0x000CB004
		private void ResetHitForceToFly()
		{
			this.HitForceToFlySpecified = false;
		}

		// Token: 0x170021E7 RID: 8679
		// (get) Token: 0x06006B1C RID: 27420 RVA: 0x000CCE10 File Offset: 0x000CB010
		// (set) Token: 0x06006B1D RID: 27421 RVA: 0x000CCE3C File Offset: 0x000CB03C
		[ProtoMember(7, IsRequired = false, Name = "HitParalyzeFactor", DataFormat = DataFormat.TwosComplement)]
		public int HitParalyzeFactor
		{
			get
			{
				return this._HitParalyzeFactor ?? 0;
			}
			set
			{
				this._HitParalyzeFactor = new int?(value);
			}
		}

		// Token: 0x170021E8 RID: 8680
		// (get) Token: 0x06006B1E RID: 27422 RVA: 0x000CCE4C File Offset: 0x000CB04C
		// (set) Token: 0x06006B1F RID: 27423 RVA: 0x000CCE6C File Offset: 0x000CB06C
		[XmlIgnore]
		[Browsable(false)]
		public bool HitParalyzeFactorSpecified
		{
			get
			{
				return this._HitParalyzeFactor != null;
			}
			set
			{
				bool flag = value == (this._HitParalyzeFactor == null);
				if (flag)
				{
					this._HitParalyzeFactor = (value ? new int?(this.HitParalyzeFactor) : null);
				}
			}
		}

		// Token: 0x06006B20 RID: 27424 RVA: 0x000CCEB0 File Offset: 0x000CB0B0
		private bool ShouldSerializeHitParalyzeFactor()
		{
			return this.HitParalyzeFactorSpecified;
		}

		// Token: 0x06006B21 RID: 27425 RVA: 0x000CCEC8 File Offset: 0x000CB0C8
		private void ResetHitParalyzeFactor()
		{
			this.HitParalyzeFactorSpecified = false;
		}

		// Token: 0x170021E9 RID: 8681
		// (get) Token: 0x06006B22 RID: 27426 RVA: 0x000CCED4 File Offset: 0x000CB0D4
		// (set) Token: 0x06006B23 RID: 27427 RVA: 0x000CCF00 File Offset: 0x000CB100
		[ProtoMember(8, IsRequired = false, Name = "PresentInFreezed", DataFormat = DataFormat.Default)]
		public bool PresentInFreezed
		{
			get
			{
				return this._PresentInFreezed ?? false;
			}
			set
			{
				this._PresentInFreezed = new bool?(value);
			}
		}

		// Token: 0x170021EA RID: 8682
		// (get) Token: 0x06006B24 RID: 27428 RVA: 0x000CCF10 File Offset: 0x000CB110
		// (set) Token: 0x06006B25 RID: 27429 RVA: 0x000CCF30 File Offset: 0x000CB130
		[XmlIgnore]
		[Browsable(false)]
		public bool PresentInFreezedSpecified
		{
			get
			{
				return this._PresentInFreezed != null;
			}
			set
			{
				bool flag = value == (this._PresentInFreezed == null);
				if (flag)
				{
					this._PresentInFreezed = (value ? new bool?(this.PresentInFreezed) : null);
				}
			}
		}

		// Token: 0x06006B26 RID: 27430 RVA: 0x000CCF74 File Offset: 0x000CB174
		private bool ShouldSerializePresentInFreezed()
		{
			return this.PresentInFreezedSpecified;
		}

		// Token: 0x06006B27 RID: 27431 RVA: 0x000CCF8C File Offset: 0x000CB18C
		private void ResetPresentInFreezed()
		{
			this.PresentInFreezedSpecified = false;
		}

		// Token: 0x170021EB RID: 8683
		// (get) Token: 0x06006B28 RID: 27432 RVA: 0x000CCF98 File Offset: 0x000CB198
		// (set) Token: 0x06006B29 RID: 27433 RVA: 0x000CCFC4 File Offset: 0x000CB1C4
		[ProtoMember(9, IsRequired = false, Name = "FreezedFromHit", DataFormat = DataFormat.Default)]
		public bool FreezedFromHit
		{
			get
			{
				return this._FreezedFromHit ?? false;
			}
			set
			{
				this._FreezedFromHit = new bool?(value);
			}
		}

		// Token: 0x170021EC RID: 8684
		// (get) Token: 0x06006B2A RID: 27434 RVA: 0x000CCFD4 File Offset: 0x000CB1D4
		// (set) Token: 0x06006B2B RID: 27435 RVA: 0x000CCFF4 File Offset: 0x000CB1F4
		[XmlIgnore]
		[Browsable(false)]
		public bool FreezedFromHitSpecified
		{
			get
			{
				return this._FreezedFromHit != null;
			}
			set
			{
				bool flag = value == (this._FreezedFromHit == null);
				if (flag)
				{
					this._FreezedFromHit = (value ? new bool?(this.FreezedFromHit) : null);
				}
			}
		}

		// Token: 0x06006B2C RID: 27436 RVA: 0x000CD038 File Offset: 0x000CB238
		private bool ShouldSerializeFreezedFromHit()
		{
			return this.FreezedFromHitSpecified;
		}

		// Token: 0x06006B2D RID: 27437 RVA: 0x000CD050 File Offset: 0x000CB250
		private void ResetFreezedFromHit()
		{
			this.FreezedFromHitSpecified = false;
		}

		// Token: 0x170021ED RID: 8685
		// (get) Token: 0x06006B2E RID: 27438 RVA: 0x000CD05C File Offset: 0x000CB25C
		// (set) Token: 0x06006B2F RID: 27439 RVA: 0x000CD088 File Offset: 0x000CB288
		[ProtoMember(10, IsRequired = false, Name = "Passive", DataFormat = DataFormat.Default)]
		public bool Passive
		{
			get
			{
				return this._Passive ?? false;
			}
			set
			{
				this._Passive = new bool?(value);
			}
		}

		// Token: 0x170021EE RID: 8686
		// (get) Token: 0x06006B30 RID: 27440 RVA: 0x000CD098 File Offset: 0x000CB298
		// (set) Token: 0x06006B31 RID: 27441 RVA: 0x000CD0B8 File Offset: 0x000CB2B8
		[XmlIgnore]
		[Browsable(false)]
		public bool PassiveSpecified
		{
			get
			{
				return this._Passive != null;
			}
			set
			{
				bool flag = value == (this._Passive == null);
				if (flag)
				{
					this._Passive = (value ? new bool?(this.Passive) : null);
				}
			}
		}

		// Token: 0x06006B32 RID: 27442 RVA: 0x000CD0FC File Offset: 0x000CB2FC
		private bool ShouldSerializePassive()
		{
			return this.PassiveSpecified;
		}

		// Token: 0x06006B33 RID: 27443 RVA: 0x000CD114 File Offset: 0x000CB314
		private void ResetPassive()
		{
			this.PassiveSpecified = false;
		}

		// Token: 0x170021EF RID: 8687
		// (get) Token: 0x06006B34 RID: 27444 RVA: 0x000CD120 File Offset: 0x000CB320
		// (set) Token: 0x06006B35 RID: 27445 RVA: 0x000CD14C File Offset: 0x000CB34C
		[ProtoMember(11, IsRequired = false, Name = "Common", DataFormat = DataFormat.TwosComplement)]
		public int Common
		{
			get
			{
				return this._Common ?? 0;
			}
			set
			{
				this._Common = new int?(value);
			}
		}

		// Token: 0x170021F0 RID: 8688
		// (get) Token: 0x06006B36 RID: 27446 RVA: 0x000CD15C File Offset: 0x000CB35C
		// (set) Token: 0x06006B37 RID: 27447 RVA: 0x000CD17C File Offset: 0x000CB37C
		[XmlIgnore]
		[Browsable(false)]
		public bool CommonSpecified
		{
			get
			{
				return this._Common != null;
			}
			set
			{
				bool flag = value == (this._Common == null);
				if (flag)
				{
					this._Common = (value ? new int?(this.Common) : null);
				}
			}
		}

		// Token: 0x06006B38 RID: 27448 RVA: 0x000CD1C0 File Offset: 0x000CB3C0
		private bool ShouldSerializeCommon()
		{
			return this.CommonSpecified;
		}

		// Token: 0x06006B39 RID: 27449 RVA: 0x000CD1D8 File Offset: 0x000CB3D8
		private void ResetCommon()
		{
			this.CommonSpecified = false;
		}

		// Token: 0x170021F1 RID: 8689
		// (get) Token: 0x06006B3A RID: 27450 RVA: 0x000CD1E4 File Offset: 0x000CB3E4
		// (set) Token: 0x06006B3B RID: 27451 RVA: 0x000CD210 File Offset: 0x000CB410
		[ProtoMember(12, IsRequired = false, Name = "Velocity", DataFormat = DataFormat.TwosComplement)]
		public int Velocity
		{
			get
			{
				return this._Velocity ?? 0;
			}
			set
			{
				this._Velocity = new int?(value);
			}
		}

		// Token: 0x170021F2 RID: 8690
		// (get) Token: 0x06006B3C RID: 27452 RVA: 0x000CD220 File Offset: 0x000CB420
		// (set) Token: 0x06006B3D RID: 27453 RVA: 0x000CD240 File Offset: 0x000CB440
		[XmlIgnore]
		[Browsable(false)]
		public bool VelocitySpecified
		{
			get
			{
				return this._Velocity != null;
			}
			set
			{
				bool flag = value == (this._Velocity == null);
				if (flag)
				{
					this._Velocity = (value ? new int?(this.Velocity) : null);
				}
			}
		}

		// Token: 0x06006B3E RID: 27454 RVA: 0x000CD284 File Offset: 0x000CB484
		private bool ShouldSerializeVelocity()
		{
			return this.VelocitySpecified;
		}

		// Token: 0x06006B3F RID: 27455 RVA: 0x000CD29C File Offset: 0x000CB49C
		private void ResetVelocity()
		{
			this.VelocitySpecified = false;
		}

		// Token: 0x170021F3 RID: 8691
		// (get) Token: 0x06006B40 RID: 27456 RVA: 0x000CD2A8 File Offset: 0x000CB4A8
		// (set) Token: 0x06006B41 RID: 27457 RVA: 0x000CD2D4 File Offset: 0x000CB4D4
		[ProtoMember(13, IsRequired = false, Name = "SkillCommon", DataFormat = DataFormat.TwosComplement)]
		public int SkillCommon
		{
			get
			{
				return this._SkillCommon ?? 0;
			}
			set
			{
				this._SkillCommon = new int?(value);
			}
		}

		// Token: 0x170021F4 RID: 8692
		// (get) Token: 0x06006B42 RID: 27458 RVA: 0x000CD2E4 File Offset: 0x000CB4E4
		// (set) Token: 0x06006B43 RID: 27459 RVA: 0x000CD304 File Offset: 0x000CB504
		[XmlIgnore]
		[Browsable(false)]
		public bool SkillCommonSpecified
		{
			get
			{
				return this._SkillCommon != null;
			}
			set
			{
				bool flag = value == (this._SkillCommon == null);
				if (flag)
				{
					this._SkillCommon = (value ? new int?(this.SkillCommon) : null);
				}
			}
		}

		// Token: 0x06006B44 RID: 27460 RVA: 0x000CD348 File Offset: 0x000CB548
		private bool ShouldSerializeSkillCommon()
		{
			return this.SkillCommonSpecified;
		}

		// Token: 0x06006B45 RID: 27461 RVA: 0x000CD360 File Offset: 0x000CB560
		private void ResetSkillCommon()
		{
			this.SkillCommonSpecified = false;
		}

		// Token: 0x06006B46 RID: 27462 RVA: 0x000CD36C File Offset: 0x000CB56C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040019C1 RID: 6593
		private int? _PosXZ;

		// Token: 0x040019C2 RID: 6594
		private ulong? _EntityID;

		// Token: 0x040019C3 RID: 6595
		private int? _Skillid;

		// Token: 0x040019C4 RID: 6596
		private int? _HitIdx;

		// Token: 0x040019C5 RID: 6597
		private ulong? _OpposerID;

		// Token: 0x040019C6 RID: 6598
		private bool? _HitForceToFly;

		// Token: 0x040019C7 RID: 6599
		private int? _HitParalyzeFactor;

		// Token: 0x040019C8 RID: 6600
		private bool? _PresentInFreezed;

		// Token: 0x040019C9 RID: 6601
		private bool? _FreezedFromHit;

		// Token: 0x040019CA RID: 6602
		private bool? _Passive;

		// Token: 0x040019CB RID: 6603
		private int? _Common;

		// Token: 0x040019CC RID: 6604
		private int? _Velocity;

		// Token: 0x040019CD RID: 6605
		private int? _SkillCommon;

		// Token: 0x040019CE RID: 6606
		private IExtension extensionObject;
	}
}

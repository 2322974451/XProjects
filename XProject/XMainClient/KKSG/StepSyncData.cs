using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StepSyncData")]
	[Serializable]
	public class StepSyncData : IExtensible
	{

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

		private bool ShouldSerializePosXZ()
		{
			return this.PosXZSpecified;
		}

		private void ResetPosXZ()
		{
			this.PosXZSpecified = false;
		}

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

		private bool ShouldSerializeEntityID()
		{
			return this.EntityIDSpecified;
		}

		private void ResetEntityID()
		{
			this.EntityIDSpecified = false;
		}

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

		private bool ShouldSerializeSkillid()
		{
			return this.SkillidSpecified;
		}

		private void ResetSkillid()
		{
			this.SkillidSpecified = false;
		}

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

		private bool ShouldSerializeHitIdx()
		{
			return this.HitIdxSpecified;
		}

		private void ResetHitIdx()
		{
			this.HitIdxSpecified = false;
		}

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

		private bool ShouldSerializeOpposerID()
		{
			return this.OpposerIDSpecified;
		}

		private void ResetOpposerID()
		{
			this.OpposerIDSpecified = false;
		}

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

		private bool ShouldSerializeHitForceToFly()
		{
			return this.HitForceToFlySpecified;
		}

		private void ResetHitForceToFly()
		{
			this.HitForceToFlySpecified = false;
		}

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

		private bool ShouldSerializeHitParalyzeFactor()
		{
			return this.HitParalyzeFactorSpecified;
		}

		private void ResetHitParalyzeFactor()
		{
			this.HitParalyzeFactorSpecified = false;
		}

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

		private bool ShouldSerializePresentInFreezed()
		{
			return this.PresentInFreezedSpecified;
		}

		private void ResetPresentInFreezed()
		{
			this.PresentInFreezedSpecified = false;
		}

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

		private bool ShouldSerializeFreezedFromHit()
		{
			return this.FreezedFromHitSpecified;
		}

		private void ResetFreezedFromHit()
		{
			this.FreezedFromHitSpecified = false;
		}

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

		private bool ShouldSerializePassive()
		{
			return this.PassiveSpecified;
		}

		private void ResetPassive()
		{
			this.PassiveSpecified = false;
		}

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

		private bool ShouldSerializeCommon()
		{
			return this.CommonSpecified;
		}

		private void ResetCommon()
		{
			this.CommonSpecified = false;
		}

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

		private bool ShouldSerializeVelocity()
		{
			return this.VelocitySpecified;
		}

		private void ResetVelocity()
		{
			this.VelocitySpecified = false;
		}

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

		private bool ShouldSerializeSkillCommon()
		{
			return this.SkillCommonSpecified;
		}

		private void ResetSkillCommon()
		{
			this.SkillCommonSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _PosXZ;

		private ulong? _EntityID;

		private int? _Skillid;

		private int? _HitIdx;

		private ulong? _OpposerID;

		private bool? _HitForceToFly;

		private int? _HitParalyzeFactor;

		private bool? _PresentInFreezed;

		private bool? _FreezedFromHit;

		private bool? _Passive;

		private int? _Common;

		private int? _Velocity;

		private int? _SkillCommon;

		private IExtension extensionObject;
	}
}

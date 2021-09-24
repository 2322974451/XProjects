using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BuffInfo")]
	[Serializable]
	public class BuffInfo : IExtensible
	{

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

		private bool ShouldSerializeBuffID()
		{
			return this.BuffIDSpecified;
		}

		private void ResetBuffID()
		{
			this.BuffIDSpecified = false;
		}

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

		private bool ShouldSerializeBuffLevel()
		{
			return this.BuffLevelSpecified;
		}

		private void ResetBuffLevel()
		{
			this.BuffLevelSpecified = false;
		}

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

		private bool ShouldSerializeLeftTime()
		{
			return this.LeftTimeSpecified;
		}

		private void ResetLeftTime()
		{
			this.LeftTimeSpecified = false;
		}

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

		private bool ShouldSerializeMobUID()
		{
			return this.MobUIDSpecified;
		}

		private void ResetMobUID()
		{
			this.MobUIDSpecified = false;
		}

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

		private bool ShouldSerializeMaxHP()
		{
			return this.MaxHPSpecified;
		}

		private void ResetMaxHP()
		{
			this.MaxHPSpecified = false;
		}

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

		private bool ShouldSerializeCurHP()
		{
			return this.CurHPSpecified;
		}

		private void ResetCurHP()
		{
			this.CurHPSpecified = false;
		}

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

		private bool ShouldSerializeStackCount()
		{
			return this.StackCountSpecified;
		}

		private void ResetStackCount()
		{
			this.StackCountSpecified = false;
		}

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

		private bool ShouldSerializebReduceCD()
		{
			return this.bReduceCDSpecified;
		}

		private void ResetbReduceCD()
		{
			this.bReduceCDSpecified = false;
		}

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

		private bool ShouldSerializeTransformID()
		{
			return this.TransformIDSpecified;
		}

		private void ResetTransformID()
		{
			this.TransformIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _BuffID;

		private uint? _BuffLevel;

		private uint? _LeftTime;

		private ulong? _MobUID;

		private double? _MaxHP;

		private double? _CurHP;

		private uint? _StackCount;

		private bool? _bReduceCD;

		private int? _TransformID;

		private IExtension extensionObject;
	}
}

using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DamageResult")]
	[Serializable]
	public class DamageResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "Result", DataFormat = DataFormat.TwosComplement)]
		public uint Result
		{
			get
			{
				return this._Result ?? 0U;
			}
			set
			{
				this._Result = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ResultSpecified
		{
			get
			{
				return this._Result != null;
			}
			set
			{
				bool flag = value == (this._Result == null);
				if (flag)
				{
					this._Result = (value ? new uint?(this.Result) : null);
				}
			}
		}

		private bool ShouldSerializeResult()
		{
			return this.ResultSpecified;
		}

		private void ResetResult()
		{
			this.ResultSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "Value", DataFormat = DataFormat.TwosComplement)]
		public double Value
		{
			get
			{
				return this._Value ?? 0.0;
			}
			set
			{
				this._Value = new double?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ValueSpecified
		{
			get
			{
				return this._Value != null;
			}
			set
			{
				bool flag = value == (this._Value == null);
				if (flag)
				{
					this._Value = (value ? new double?(this.Value) : null);
				}
			}
		}

		private bool ShouldSerializeValue()
		{
			return this.ValueSpecified;
		}

		private void ResetValue()
		{
			this.ValueSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "Flag", DataFormat = DataFormat.TwosComplement)]
		public int Flag
		{
			get
			{
				return this._Flag ?? 0;
			}
			set
			{
				this._Flag = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool FlagSpecified
		{
			get
			{
				return this._Flag != null;
			}
			set
			{
				bool flag = value == (this._Flag == null);
				if (flag)
				{
					this._Flag = (value ? new int?(this.Flag) : null);
				}
			}
		}

		private bool ShouldSerializeFlag()
		{
			return this.FlagSpecified;
		}

		private void ResetFlag()
		{
			this.FlagSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "DamageType", DataFormat = DataFormat.TwosComplement)]
		public uint DamageType
		{
			get
			{
				return this._DamageType ?? 0U;
			}
			set
			{
				this._DamageType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool DamageTypeSpecified
		{
			get
			{
				return this._DamageType != null;
			}
			set
			{
				bool flag = value == (this._DamageType == null);
				if (flag)
				{
					this._DamageType = (value ? new uint?(this.DamageType) : null);
				}
			}
		}

		private bool ShouldSerializeDamageType()
		{
			return this.DamageTypeSpecified;
		}

		private void ResetDamageType()
		{
			this.DamageTypeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "ElementType", DataFormat = DataFormat.TwosComplement)]
		public int ElementType
		{
			get
			{
				return this._ElementType ?? 0;
			}
			set
			{
				this._ElementType = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ElementTypeSpecified
		{
			get
			{
				return this._ElementType != null;
			}
			set
			{
				bool flag = value == (this._ElementType == null);
				if (flag)
				{
					this._ElementType = (value ? new int?(this.ElementType) : null);
				}
			}
		}

		private bool ShouldSerializeElementType()
		{
			return this.ElementTypeSpecified;
		}

		private void ResetElementType()
		{
			this.ElementTypeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "IsTargetDead", DataFormat = DataFormat.Default)]
		public bool IsTargetDead
		{
			get
			{
				return this._IsTargetDead ?? false;
			}
			set
			{
				this._IsTargetDead = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool IsTargetDeadSpecified
		{
			get
			{
				return this._IsTargetDead != null;
			}
			set
			{
				bool flag = value == (this._IsTargetDead == null);
				if (flag)
				{
					this._IsTargetDead = (value ? new bool?(this.IsTargetDead) : null);
				}
			}
		}

		private bool ShouldSerializeIsTargetDead()
		{
			return this.IsTargetDeadSpecified;
		}

		private void ResetIsTargetDead()
		{
			this.IsTargetDeadSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "ComboCount", DataFormat = DataFormat.TwosComplement)]
		public int ComboCount
		{
			get
			{
				return this._ComboCount ?? 0;
			}
			set
			{
				this._ComboCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ComboCountSpecified
		{
			get
			{
				return this._ComboCount != null;
			}
			set
			{
				bool flag = value == (this._ComboCount == null);
				if (flag)
				{
					this._ComboCount = (value ? new int?(this.ComboCount) : null);
				}
			}
		}

		private bool ShouldSerializeComboCount()
		{
			return this.ComboCountSpecified;
		}

		private void ResetComboCount()
		{
			this.ComboCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _Result;

		private double? _Value;

		private int? _Flag;

		private uint? _DamageType;

		private int? _ElementType;

		private bool? _IsTargetDead;

		private int? _ComboCount;

		private IExtension extensionObject;
	}
}

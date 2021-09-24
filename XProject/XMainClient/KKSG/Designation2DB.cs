using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "Designation2DB")]
	[Serializable]
	public class Designation2DB : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "coverDesignationID", DataFormat = DataFormat.TwosComplement)]
		public uint coverDesignationID
		{
			get
			{
				return this._coverDesignationID ?? 0U;
			}
			set
			{
				this._coverDesignationID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool coverDesignationIDSpecified
		{
			get
			{
				return this._coverDesignationID != null;
			}
			set
			{
				bool flag = value == (this._coverDesignationID == null);
				if (flag)
				{
					this._coverDesignationID = (value ? new uint?(this.coverDesignationID) : null);
				}
			}
		}

		private bool ShouldSerializecoverDesignationID()
		{
			return this.coverDesignationIDSpecified;
		}

		private void ResetcoverDesignationID()
		{
			this.coverDesignationIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "abilityDesignationID", DataFormat = DataFormat.TwosComplement)]
		public uint abilityDesignationID
		{
			get
			{
				return this._abilityDesignationID ?? 0U;
			}
			set
			{
				this._abilityDesignationID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool abilityDesignationIDSpecified
		{
			get
			{
				return this._abilityDesignationID != null;
			}
			set
			{
				bool flag = value == (this._abilityDesignationID == null);
				if (flag)
				{
					this._abilityDesignationID = (value ? new uint?(this.abilityDesignationID) : null);
				}
			}
		}

		private bool ShouldSerializeabilityDesignationID()
		{
			return this.abilityDesignationIDSpecified;
		}

		private void ResetabilityDesignationID()
		{
			this.abilityDesignationIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "maxAbilityDesignationID", DataFormat = DataFormat.TwosComplement)]
		public uint maxAbilityDesignationID
		{
			get
			{
				return this._maxAbilityDesignationID ?? 0U;
			}
			set
			{
				this._maxAbilityDesignationID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxAbilityDesignationIDSpecified
		{
			get
			{
				return this._maxAbilityDesignationID != null;
			}
			set
			{
				bool flag = value == (this._maxAbilityDesignationID == null);
				if (flag)
				{
					this._maxAbilityDesignationID = (value ? new uint?(this.maxAbilityDesignationID) : null);
				}
			}
		}

		private bool ShouldSerializemaxAbilityDesignationID()
		{
			return this.maxAbilityDesignationIDSpecified;
		}

		private void ResetmaxAbilityDesignationID()
		{
			this.maxAbilityDesignationIDSpecified = false;
		}

		[ProtoMember(4, Name = "designationData", DataFormat = DataFormat.Default)]
		public List<StcDesignationInfo> designationData
		{
			get
			{
				return this._designationData;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _coverDesignationID;

		private uint? _abilityDesignationID;

		private uint? _maxAbilityDesignationID;

		private readonly List<StcDesignationInfo> _designationData = new List<StcDesignationInfo>();

		private IExtension extensionObject;
	}
}

using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OnlyOnceGuildBonusData")]
	[Serializable]
	public class OnlyOnceGuildBonusData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "bonusType", DataFormat = DataFormat.TwosComplement)]
		public uint bonusType
		{
			get
			{
				return this._bonusType ?? 0U;
			}
			set
			{
				this._bonusType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bonusTypeSpecified
		{
			get
			{
				return this._bonusType != null;
			}
			set
			{
				bool flag = value == (this._bonusType == null);
				if (flag)
				{
					this._bonusType = (value ? new uint?(this.bonusType) : null);
				}
			}
		}

		private bool ShouldSerializebonusType()
		{
			return this.bonusTypeSpecified;
		}

		private void ResetbonusType()
		{
			this.bonusTypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "bonusVar", DataFormat = DataFormat.TwosComplement)]
		public uint bonusVar
		{
			get
			{
				return this._bonusVar ?? 0U;
			}
			set
			{
				this._bonusVar = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bonusVarSpecified
		{
			get
			{
				return this._bonusVar != null;
			}
			set
			{
				bool flag = value == (this._bonusVar == null);
				if (flag)
				{
					this._bonusVar = (value ? new uint?(this.bonusVar) : null);
				}
			}
		}

		private bool ShouldSerializebonusVar()
		{
			return this.bonusVarSpecified;
		}

		private void ResetbonusVar()
		{
			this.bonusVarSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _bonusType;

		private uint? _bonusVar;

		private IExtension extensionObject;
	}
}

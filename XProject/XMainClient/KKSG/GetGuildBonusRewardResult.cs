using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGuildBonusRewardResult")]
	[Serializable]
	public class GetGuildBonusRewardResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "getValue", DataFormat = DataFormat.TwosComplement)]
		public uint getValue
		{
			get
			{
				return this._getValue ?? 0U;
			}
			set
			{
				this._getValue = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool getValueSpecified
		{
			get
			{
				return this._getValue != null;
			}
			set
			{
				bool flag = value == (this._getValue == null);
				if (flag)
				{
					this._getValue = (value ? new uint?(this.getValue) : null);
				}
			}
		}

		private bool ShouldSerializegetValue()
		{
			return this.getValueSpecified;
		}

		private void ResetgetValue()
		{
			this.getValueSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "bonusType", DataFormat = DataFormat.TwosComplement)]
		public int bonusType
		{
			get
			{
				return this._bonusType ?? 0;
			}
			set
			{
				this._bonusType = new int?(value);
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
					this._bonusType = (value ? new int?(this.bonusType) : null);
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _getValue;

		private ErrorCode? _errorcode;

		private int? _bonusType;

		private IExtension extensionObject;
	}
}

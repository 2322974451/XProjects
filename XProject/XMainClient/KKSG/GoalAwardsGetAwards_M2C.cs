using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GoalAwardsGetAwards_M2C")]
	[Serializable]
	public class GoalAwardsGetAwards_M2C : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "gottenAwardsIndex", DataFormat = DataFormat.TwosComplement)]
		public uint gottenAwardsIndex
		{
			get
			{
				return this._gottenAwardsIndex ?? 0U;
			}
			set
			{
				this._gottenAwardsIndex = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool gottenAwardsIndexSpecified
		{
			get
			{
				return this._gottenAwardsIndex != null;
			}
			set
			{
				bool flag = value == (this._gottenAwardsIndex == null);
				if (flag)
				{
					this._gottenAwardsIndex = (value ? new uint?(this.gottenAwardsIndex) : null);
				}
			}
		}

		private bool ShouldSerializegottenAwardsIndex()
		{
			return this.gottenAwardsIndexSpecified;
		}

		private void ResetgottenAwardsIndex()
		{
			this.gottenAwardsIndexSpecified = false;
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _gottenAwardsIndex;

		private ErrorCode? _errorcode;

		private IExtension extensionObject;
	}
}

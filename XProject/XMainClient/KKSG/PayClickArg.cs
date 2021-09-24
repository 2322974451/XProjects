using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayClickArg")]
	[Serializable]
	public class PayClickArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "buttonType", DataFormat = DataFormat.TwosComplement)]
		public int buttonType
		{
			get
			{
				return this._buttonType ?? 0;
			}
			set
			{
				this._buttonType = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buttonTypeSpecified
		{
			get
			{
				return this._buttonType != null;
			}
			set
			{
				bool flag = value == (this._buttonType == null);
				if (flag)
				{
					this._buttonType = (value ? new int?(this.buttonType) : null);
				}
			}
		}

		private bool ShouldSerializebuttonType()
		{
			return this.buttonTypeSpecified;
		}

		private void ResetbuttonType()
		{
			this.buttonTypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "memberid", DataFormat = DataFormat.TwosComplement)]
		public int memberid
		{
			get
			{
				return this._memberid ?? 0;
			}
			set
			{
				this._memberid = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool memberidSpecified
		{
			get
			{
				return this._memberid != null;
			}
			set
			{
				bool flag = value == (this._memberid == null);
				if (flag)
				{
					this._memberid = (value ? new int?(this.memberid) : null);
				}
			}
		}

		private bool ShouldSerializememberid()
		{
			return this.memberidSpecified;
		}

		private void Resetmemberid()
		{
			this.memberidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _buttonType;

		private int? _memberid;

		private IExtension extensionObject;
	}
}

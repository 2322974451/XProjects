using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LoginRewardGetReq")]
	[Serializable]
	public class LoginRewardGetReq : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "day", DataFormat = DataFormat.TwosComplement)]
		public int day
		{
			get
			{
				return this._day ?? 0;
			}
			set
			{
				this._day = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool daySpecified
		{
			get
			{
				return this._day != null;
			}
			set
			{
				bool flag = value == (this._day == null);
				if (flag)
				{
					this._day = (value ? new int?(this.day) : null);
				}
			}
		}

		private bool ShouldSerializeday()
		{
			return this.daySpecified;
		}

		private void Resetday()
		{
			this.daySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _day;

		private IExtension extensionObject;
	}
}

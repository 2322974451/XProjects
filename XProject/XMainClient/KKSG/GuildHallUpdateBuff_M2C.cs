using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildHallUpdateBuff_M2C")]
	[Serializable]
	public class GuildHallUpdateBuff_M2C : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "buffdata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GuildHallBuffData buffdata
		{
			get
			{
				return this._buffdata;
			}
			set
			{
				this._buffdata = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "ec", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ec
		{
			get
			{
				return this._ec ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ec = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ecSpecified
		{
			get
			{
				return this._ec != null;
			}
			set
			{
				bool flag = value == (this._ec == null);
				if (flag)
				{
					this._ec = (value ? new ErrorCode?(this.ec) : null);
				}
			}
		}

		private bool ShouldSerializeec()
		{
			return this.ecSpecified;
		}

		private void Resetec()
		{
			this.ecSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GuildHallBuffData _buffdata = null;

		private ErrorCode? _ec;

		private IExtension extensionObject;
	}
}

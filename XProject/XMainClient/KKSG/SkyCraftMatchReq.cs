using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyCraftMatchReq")]
	[Serializable]
	public class SkyCraftMatchReq : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public SkyCraftMatchReqTpe type
		{
			get
			{
				return this._type ?? SkyCraftMatchReqTpe.SCMR_Match;
			}
			set
			{
				this._type = new SkyCraftMatchReqTpe?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new SkyCraftMatchReqTpe?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private SkyCraftMatchReqTpe? _type;

		private IExtension extensionObject;
	}
}

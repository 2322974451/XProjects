using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MulActivityArg")]
	[Serializable]
	public class MulActivityArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "acid", DataFormat = DataFormat.TwosComplement)]
		public int acid
		{
			get
			{
				return this._acid ?? 0;
			}
			set
			{
				this._acid = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool acidSpecified
		{
			get
			{
				return this._acid != null;
			}
			set
			{
				bool flag = value == (this._acid == null);
				if (flag)
				{
					this._acid = (value ? new int?(this.acid) : null);
				}
			}
		}

		private bool ShouldSerializeacid()
		{
			return this.acidSpecified;
		}

		private void Resetacid()
		{
			this.acidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _acid;

		private IExtension extensionObject;
	}
}

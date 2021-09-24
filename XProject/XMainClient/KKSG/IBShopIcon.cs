using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "IBShopIcon")]
	[Serializable]
	public class IBShopIcon : IExtensible
	{

		[ProtoMember(1, Name = "viptag", DataFormat = DataFormat.TwosComplement)]
		public List<uint> viptag
		{
			get
			{
				return this._viptag;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "limittag", DataFormat = DataFormat.Default)]
		public bool limittag
		{
			get
			{
				return this._limittag ?? false;
			}
			set
			{
				this._limittag = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool limittagSpecified
		{
			get
			{
				return this._limittag != null;
			}
			set
			{
				bool flag = value == (this._limittag == null);
				if (flag)
				{
					this._limittag = (value ? new bool?(this.limittag) : null);
				}
			}
		}

		private bool ShouldSerializelimittag()
		{
			return this.limittagSpecified;
		}

		private void Resetlimittag()
		{
			this.limittagSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _viptag = new List<uint>();

		private bool? _limittag;

		private IExtension extensionObject;
	}
}

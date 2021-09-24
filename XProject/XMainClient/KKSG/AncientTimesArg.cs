using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AncientTimesArg")]
	[Serializable]
	public class AncientTimesArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "pos", DataFormat = DataFormat.TwosComplement)]
		public uint pos
		{
			get
			{
				return this._pos ?? 0U;
			}
			set
			{
				this._pos = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool posSpecified
		{
			get
			{
				return this._pos != null;
			}
			set
			{
				bool flag = value == (this._pos == null);
				if (flag)
				{
					this._pos = (value ? new uint?(this.pos) : null);
				}
			}
		}

		private bool ShouldSerializepos()
		{
			return this.posSpecified;
		}

		private void Resetpos()
		{
			this.posSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _pos;

		private IExtension extensionObject;
	}
}

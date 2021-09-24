using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PkPrepareNtf")]
	[Serializable]
	public class PkPrepareNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "beginorend", DataFormat = DataFormat.TwosComplement)]
		public uint beginorend
		{
			get
			{
				return this._beginorend ?? 0U;
			}
			set
			{
				this._beginorend = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool beginorendSpecified
		{
			get
			{
				return this._beginorend != null;
			}
			set
			{
				bool flag = value == (this._beginorend == null);
				if (flag)
				{
					this._beginorend = (value ? new uint?(this.beginorend) : null);
				}
			}
		}

		private bool ShouldSerializebeginorend()
		{
			return this.beginorendSpecified;
		}

		private void Resetbeginorend()
		{
			this.beginorendSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _beginorend;

		private IExtension extensionObject;
	}
}

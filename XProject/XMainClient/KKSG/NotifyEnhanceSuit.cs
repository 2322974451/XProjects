using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NotifyEnhanceSuit")]
	[Serializable]
	public class NotifyEnhanceSuit : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "enhanceSuit", DataFormat = DataFormat.TwosComplement)]
		public uint enhanceSuit
		{
			get
			{
				return this._enhanceSuit ?? 0U;
			}
			set
			{
				this._enhanceSuit = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool enhanceSuitSpecified
		{
			get
			{
				return this._enhanceSuit != null;
			}
			set
			{
				bool flag = value == (this._enhanceSuit == null);
				if (flag)
				{
					this._enhanceSuit = (value ? new uint?(this.enhanceSuit) : null);
				}
			}
		}

		private bool ShouldSerializeenhanceSuit()
		{
			return this.enhanceSuitSpecified;
		}

		private void ResetenhanceSuit()
		{
			this.enhanceSuitSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _enhanceSuit;

		private IExtension extensionObject;
	}
}

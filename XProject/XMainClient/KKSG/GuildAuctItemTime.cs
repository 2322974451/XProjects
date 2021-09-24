using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildAuctItemTime")]
	[Serializable]
	public class GuildAuctItemTime : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "auct_type", DataFormat = DataFormat.TwosComplement)]
		public uint auct_type
		{
			get
			{
				return this._auct_type ?? 0U;
			}
			set
			{
				this._auct_type = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool auct_typeSpecified
		{
			get
			{
				return this._auct_type != null;
			}
			set
			{
				bool flag = value == (this._auct_type == null);
				if (flag)
				{
					this._auct_type = (value ? new uint?(this.auct_type) : null);
				}
			}
		}

		private bool ShouldSerializeauct_type()
		{
			return this.auct_typeSpecified;
		}

		private void Resetauct_type()
		{
			this.auct_typeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _auct_type;

		private IExtension extensionObject;
	}
}

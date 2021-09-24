using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChangeProfessionArg")]
	[Serializable]
	public class ChangeProfessionArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "pro", DataFormat = DataFormat.TwosComplement)]
		public uint pro
		{
			get
			{
				return this._pro ?? 0U;
			}
			set
			{
				this._pro = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool proSpecified
		{
			get
			{
				return this._pro != null;
			}
			set
			{
				bool flag = value == (this._pro == null);
				if (flag)
				{
					this._pro = (value ? new uint?(this.pro) : null);
				}
			}
		}

		private bool ShouldSerializepro()
		{
			return this.proSpecified;
		}

		private void Resetpro()
		{
			this.proSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _pro;

		private IExtension extensionObject;
	}
}

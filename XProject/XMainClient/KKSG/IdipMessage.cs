using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "IdipMessage")]
	[Serializable]
	public class IdipMessage : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "message", DataFormat = DataFormat.Default)]
		public string message
		{
			get
			{
				return this._message ?? "";
			}
			set
			{
				this._message = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool messageSpecified
		{
			get
			{
				return this._message != null;
			}
			set
			{
				bool flag = value == (this._message == null);
				if (flag)
				{
					this._message = (value ? this.message : null);
				}
			}
		}

		private bool ShouldSerializemessage()
		{
			return this.messageSpecified;
		}

		private void Resetmessage()
		{
			this.messageSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _message;

		private IExtension extensionObject;
	}
}

using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LoginReconnectReqArg")]
	[Serializable]
	public class LoginReconnectReqArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "reconnect", DataFormat = DataFormat.Default)]
		public bool reconnect
		{
			get
			{
				return this._reconnect ?? false;
			}
			set
			{
				this._reconnect = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reconnectSpecified
		{
			get
			{
				return this._reconnect != null;
			}
			set
			{
				bool flag = value == (this._reconnect == null);
				if (flag)
				{
					this._reconnect = (value ? new bool?(this.reconnect) : null);
				}
			}
		}

		private bool ShouldSerializereconnect()
		{
			return this.reconnectSpecified;
		}

		private void Resetreconnect()
		{
			this.reconnectSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _reconnect;

		private IExtension extensionObject;
	}
}

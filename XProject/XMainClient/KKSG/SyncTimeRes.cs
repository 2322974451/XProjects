using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SyncTimeRes")]
	[Serializable]
	public class SyncTimeRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "serverTime", DataFormat = DataFormat.TwosComplement)]
		public long serverTime
		{
			get
			{
				return this._serverTime ?? 0L;
			}
			set
			{
				this._serverTime = new long?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool serverTimeSpecified
		{
			get
			{
				return this._serverTime != null;
			}
			set
			{
				bool flag = value == (this._serverTime == null);
				if (flag)
				{
					this._serverTime = (value ? new long?(this.serverTime) : null);
				}
			}
		}

		private bool ShouldSerializeserverTime()
		{
			return this.serverTimeSpecified;
		}

		private void ResetserverTime()
		{
			this.serverTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private long? _serverTime;

		private IExtension extensionObject;
	}
}

using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000436 RID: 1078
	[ProtoContract(Name = "LoginReconnectReqArg")]
	[Serializable]
	public class LoginReconnectReqArg : IExtensible
	{
		// Token: 0x17001181 RID: 4481
		// (get) Token: 0x06003900 RID: 14592 RVA: 0x0006D128 File Offset: 0x0006B328
		// (set) Token: 0x06003901 RID: 14593 RVA: 0x0006D154 File Offset: 0x0006B354
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

		// Token: 0x17001182 RID: 4482
		// (get) Token: 0x06003902 RID: 14594 RVA: 0x0006D164 File Offset: 0x0006B364
		// (set) Token: 0x06003903 RID: 14595 RVA: 0x0006D184 File Offset: 0x0006B384
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

		// Token: 0x06003904 RID: 14596 RVA: 0x0006D1C8 File Offset: 0x0006B3C8
		private bool ShouldSerializereconnect()
		{
			return this.reconnectSpecified;
		}

		// Token: 0x06003905 RID: 14597 RVA: 0x0006D1E0 File Offset: 0x0006B3E0
		private void Resetreconnect()
		{
			this.reconnectSpecified = false;
		}

		// Token: 0x06003906 RID: 14598 RVA: 0x0006D1EC File Offset: 0x0006B3EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E25 RID: 3621
		private bool? _reconnect;

		// Token: 0x04000E26 RID: 3622
		private IExtension extensionObject;
	}
}

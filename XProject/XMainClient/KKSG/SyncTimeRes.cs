using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000010 RID: 16
	[ProtoContract(Name = "SyncTimeRes")]
	[Serializable]
	public class SyncTimeRes : IExtensible
	{
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000143 RID: 323 RVA: 0x0000512C File Offset: 0x0000332C
		// (set) Token: 0x06000144 RID: 324 RVA: 0x00005159 File Offset: 0x00003359
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

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000145 RID: 325 RVA: 0x00005168 File Offset: 0x00003368
		// (set) Token: 0x06000146 RID: 326 RVA: 0x00005188 File Offset: 0x00003388
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

		// Token: 0x06000147 RID: 327 RVA: 0x000051CC File Offset: 0x000033CC
		private bool ShouldSerializeserverTime()
		{
			return this.serverTimeSpecified;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x000051E4 File Offset: 0x000033E4
		private void ResetserverTime()
		{
			this.serverTimeSpecified = false;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x000051F0 File Offset: 0x000033F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000058 RID: 88
		private long? _serverTime;

		// Token: 0x04000059 RID: 89
		private IExtension extensionObject;
	}
}

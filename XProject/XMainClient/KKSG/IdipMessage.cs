using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200022F RID: 559
	[ProtoContract(Name = "IdipMessage")]
	[Serializable]
	public class IdipMessage : IExtensible
	{
		// Token: 0x170009B7 RID: 2487
		// (get) Token: 0x06001F25 RID: 7973 RVA: 0x0003D190 File Offset: 0x0003B390
		// (set) Token: 0x06001F26 RID: 7974 RVA: 0x0003D1B1 File Offset: 0x0003B3B1
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

		// Token: 0x170009B8 RID: 2488
		// (get) Token: 0x06001F27 RID: 7975 RVA: 0x0003D1BC File Offset: 0x0003B3BC
		// (set) Token: 0x06001F28 RID: 7976 RVA: 0x0003D1D8 File Offset: 0x0003B3D8
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

		// Token: 0x06001F29 RID: 7977 RVA: 0x0003D208 File Offset: 0x0003B408
		private bool ShouldSerializemessage()
		{
			return this.messageSpecified;
		}

		// Token: 0x06001F2A RID: 7978 RVA: 0x0003D220 File Offset: 0x0003B420
		private void Resetmessage()
		{
			this.messageSpecified = false;
		}

		// Token: 0x06001F2B RID: 7979 RVA: 0x0003D22C File Offset: 0x0003B42C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007C6 RID: 1990
		private string _message;

		// Token: 0x040007C7 RID: 1991
		private IExtension extensionObject;
	}
}

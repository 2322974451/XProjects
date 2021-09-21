using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200004B RID: 75
	[ProtoContract(Name = "FashionComposeRes")]
	[Serializable]
	public class FashionComposeRes : IExtensible
	{
		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000517 RID: 1303 RVA: 0x0000C6D8 File Offset: 0x0000A8D8
		// (set) Token: 0x06000518 RID: 1304 RVA: 0x0000C704 File Offset: 0x0000A904
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000519 RID: 1305 RVA: 0x0000C714 File Offset: 0x0000A914
		// (set) Token: 0x0600051A RID: 1306 RVA: 0x0000C734 File Offset: 0x0000A934
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x0000C778 File Offset: 0x0000A978
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x0000C790 File Offset: 0x0000A990
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x0000C79C File Offset: 0x0000A99C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400014F RID: 335
		private ErrorCode? _result;

		// Token: 0x04000150 RID: 336
		private IExtension extensionObject;
	}
}

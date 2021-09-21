using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000510 RID: 1296
	[ProtoContract(Name = "FashionIBShopBuyRes")]
	[Serializable]
	public class FashionIBShopBuyRes : IExtensible
	{
		// Token: 0x17001469 RID: 5225
		// (get) Token: 0x060042BB RID: 17083 RVA: 0x0007F004 File Offset: 0x0007D204
		// (set) Token: 0x060042BC RID: 17084 RVA: 0x0007F030 File Offset: 0x0007D230
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

		// Token: 0x1700146A RID: 5226
		// (get) Token: 0x060042BD RID: 17085 RVA: 0x0007F040 File Offset: 0x0007D240
		// (set) Token: 0x060042BE RID: 17086 RVA: 0x0007F060 File Offset: 0x0007D260
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

		// Token: 0x060042BF RID: 17087 RVA: 0x0007F0A4 File Offset: 0x0007D2A4
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060042C0 RID: 17088 RVA: 0x0007F0BC File Offset: 0x0007D2BC
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x060042C1 RID: 17089 RVA: 0x0007F0C8 File Offset: 0x0007D2C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010A5 RID: 4261
		private ErrorCode? _result;

		// Token: 0x040010A6 RID: 4262
		private IExtension extensionObject;
	}
}

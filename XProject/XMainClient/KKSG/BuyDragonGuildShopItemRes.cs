using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004C5 RID: 1221
	[ProtoContract(Name = "BuyDragonGuildShopItemRes")]
	[Serializable]
	public class BuyDragonGuildShopItemRes : IExtensible
	{
		// Token: 0x1700137A RID: 4986
		// (get) Token: 0x06003F8F RID: 16271 RVA: 0x000792B0 File Offset: 0x000774B0
		// (set) Token: 0x06003F90 RID: 16272 RVA: 0x000792DC File Offset: 0x000774DC
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

		// Token: 0x1700137B RID: 4987
		// (get) Token: 0x06003F91 RID: 16273 RVA: 0x000792EC File Offset: 0x000774EC
		// (set) Token: 0x06003F92 RID: 16274 RVA: 0x0007930C File Offset: 0x0007750C
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

		// Token: 0x06003F93 RID: 16275 RVA: 0x00079350 File Offset: 0x00077550
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003F94 RID: 16276 RVA: 0x00079368 File Offset: 0x00077568
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003F95 RID: 16277 RVA: 0x00079374 File Offset: 0x00077574
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FD3 RID: 4051
		private ErrorCode? _result;

		// Token: 0x04000FD4 RID: 4052
		private IExtension extensionObject;
	}
}

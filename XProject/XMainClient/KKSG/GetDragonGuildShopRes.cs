using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004C2 RID: 1218
	[ProtoContract(Name = "GetDragonGuildShopRes")]
	[Serializable]
	public class GetDragonGuildShopRes : IExtensible
	{
		// Token: 0x17001373 RID: 4979
		// (get) Token: 0x06003F76 RID: 16246 RVA: 0x00078FEC File Offset: 0x000771EC
		// (set) Token: 0x06003F77 RID: 16247 RVA: 0x00079018 File Offset: 0x00077218
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

		// Token: 0x17001374 RID: 4980
		// (get) Token: 0x06003F78 RID: 16248 RVA: 0x00079028 File Offset: 0x00077228
		// (set) Token: 0x06003F79 RID: 16249 RVA: 0x00079048 File Offset: 0x00077248
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

		// Token: 0x06003F7A RID: 16250 RVA: 0x0007908C File Offset: 0x0007728C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003F7B RID: 16251 RVA: 0x000790A4 File Offset: 0x000772A4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17001375 RID: 4981
		// (get) Token: 0x06003F7C RID: 16252 RVA: 0x000790B0 File Offset: 0x000772B0
		[ProtoMember(2, Name = "items", DataFormat = DataFormat.Default)]
		public List<DragonGuildShopItemClient> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x06003F7D RID: 16253 RVA: 0x000790C8 File Offset: 0x000772C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FCC RID: 4044
		private ErrorCode? _result;

		// Token: 0x04000FCD RID: 4045
		private readonly List<DragonGuildShopItemClient> _items = new List<DragonGuildShopItemClient>();

		// Token: 0x04000FCE RID: 4046
		private IExtension extensionObject;
	}
}

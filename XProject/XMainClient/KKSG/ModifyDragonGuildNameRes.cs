using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004B8 RID: 1208
	[ProtoContract(Name = "ModifyDragonGuildNameRes")]
	[Serializable]
	public class ModifyDragonGuildNameRes : IExtensible
	{
		// Token: 0x17001347 RID: 4935
		// (get) Token: 0x06003EEE RID: 16110 RVA: 0x0007800C File Offset: 0x0007620C
		// (set) Token: 0x06003EEF RID: 16111 RVA: 0x00078038 File Offset: 0x00076238
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

		// Token: 0x17001348 RID: 4936
		// (get) Token: 0x06003EF0 RID: 16112 RVA: 0x00078048 File Offset: 0x00076248
		// (set) Token: 0x06003EF1 RID: 16113 RVA: 0x00078068 File Offset: 0x00076268
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

		// Token: 0x06003EF2 RID: 16114 RVA: 0x000780AC File Offset: 0x000762AC
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003EF3 RID: 16115 RVA: 0x000780C4 File Offset: 0x000762C4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003EF4 RID: 16116 RVA: 0x000780D0 File Offset: 0x000762D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FA8 RID: 4008
		private ErrorCode? _result;

		// Token: 0x04000FA9 RID: 4009
		private IExtension extensionObject;
	}
}

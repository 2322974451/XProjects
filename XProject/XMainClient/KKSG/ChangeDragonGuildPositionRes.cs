using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004C9 RID: 1225
	[ProtoContract(Name = "ChangeDragonGuildPositionRes")]
	[Serializable]
	public class ChangeDragonGuildPositionRes : IExtensible
	{
		// Token: 0x17001383 RID: 4995
		// (get) Token: 0x06003FB0 RID: 16304 RVA: 0x0007966C File Offset: 0x0007786C
		// (set) Token: 0x06003FB1 RID: 16305 RVA: 0x00079698 File Offset: 0x00077898
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

		// Token: 0x17001384 RID: 4996
		// (get) Token: 0x06003FB2 RID: 16306 RVA: 0x000796A8 File Offset: 0x000778A8
		// (set) Token: 0x06003FB3 RID: 16307 RVA: 0x000796C8 File Offset: 0x000778C8
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

		// Token: 0x06003FB4 RID: 16308 RVA: 0x0007970C File Offset: 0x0007790C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003FB5 RID: 16309 RVA: 0x00079724 File Offset: 0x00077924
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003FB6 RID: 16310 RVA: 0x00079730 File Offset: 0x00077930
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FDC RID: 4060
		private ErrorCode? _result;

		// Token: 0x04000FDD RID: 4061
		private IExtension extensionObject;
	}
}

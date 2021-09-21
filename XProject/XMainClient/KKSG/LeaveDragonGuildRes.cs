using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004B6 RID: 1206
	[ProtoContract(Name = "LeaveDragonGuildRes")]
	[Serializable]
	public class LeaveDragonGuildRes : IExtensible
	{
		// Token: 0x17001343 RID: 4931
		// (get) Token: 0x06003EDE RID: 16094 RVA: 0x00077E6C File Offset: 0x0007606C
		// (set) Token: 0x06003EDF RID: 16095 RVA: 0x00077E98 File Offset: 0x00076098
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

		// Token: 0x17001344 RID: 4932
		// (get) Token: 0x06003EE0 RID: 16096 RVA: 0x00077EA8 File Offset: 0x000760A8
		// (set) Token: 0x06003EE1 RID: 16097 RVA: 0x00077EC8 File Offset: 0x000760C8
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

		// Token: 0x06003EE2 RID: 16098 RVA: 0x00077F0C File Offset: 0x0007610C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003EE3 RID: 16099 RVA: 0x00077F24 File Offset: 0x00076124
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003EE4 RID: 16100 RVA: 0x00077F30 File Offset: 0x00076130
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FA4 RID: 4004
		private ErrorCode? _result;

		// Token: 0x04000FA5 RID: 4005
		private IExtension extensionObject;
	}
}

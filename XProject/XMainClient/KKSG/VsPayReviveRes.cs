using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000549 RID: 1353
	[ProtoContract(Name = "VsPayReviveRes")]
	[Serializable]
	public class VsPayReviveRes : IExtensible
	{
		// Token: 0x17001524 RID: 5412
		// (get) Token: 0x0600452E RID: 17710 RVA: 0x000838A4 File Offset: 0x00081AA4
		// (set) Token: 0x0600452F RID: 17711 RVA: 0x000838D0 File Offset: 0x00081AD0
		[ProtoMember(1, IsRequired = false, Name = "ret", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ret
		{
			get
			{
				return this._ret ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ret = new ErrorCode?(value);
			}
		}

		// Token: 0x17001525 RID: 5413
		// (get) Token: 0x06004530 RID: 17712 RVA: 0x000838E0 File Offset: 0x00081AE0
		// (set) Token: 0x06004531 RID: 17713 RVA: 0x00083900 File Offset: 0x00081B00
		[XmlIgnore]
		[Browsable(false)]
		public bool retSpecified
		{
			get
			{
				return this._ret != null;
			}
			set
			{
				bool flag = value == (this._ret == null);
				if (flag)
				{
					this._ret = (value ? new ErrorCode?(this.ret) : null);
				}
			}
		}

		// Token: 0x06004532 RID: 17714 RVA: 0x00083944 File Offset: 0x00081B44
		private bool ShouldSerializeret()
		{
			return this.retSpecified;
		}

		// Token: 0x06004533 RID: 17715 RVA: 0x0008395C File Offset: 0x00081B5C
		private void Resetret()
		{
			this.retSpecified = false;
		}

		// Token: 0x06004534 RID: 17716 RVA: 0x00083968 File Offset: 0x00081B68
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001149 RID: 4425
		private ErrorCode? _ret;

		// Token: 0x0400114A RID: 4426
		private IExtension extensionObject;
	}
}

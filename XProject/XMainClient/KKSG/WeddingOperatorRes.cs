using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000483 RID: 1155
	[ProtoContract(Name = "WeddingOperatorRes")]
	[Serializable]
	public class WeddingOperatorRes : IExtensible
	{
		// Token: 0x17001281 RID: 4737
		// (get) Token: 0x06003C54 RID: 15444 RVA: 0x000733E0 File Offset: 0x000715E0
		// (set) Token: 0x06003C55 RID: 15445 RVA: 0x0007340C File Offset: 0x0007160C
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

		// Token: 0x17001282 RID: 4738
		// (get) Token: 0x06003C56 RID: 15446 RVA: 0x0007341C File Offset: 0x0007161C
		// (set) Token: 0x06003C57 RID: 15447 RVA: 0x0007343C File Offset: 0x0007163C
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

		// Token: 0x06003C58 RID: 15448 RVA: 0x00073480 File Offset: 0x00071680
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003C59 RID: 15449 RVA: 0x00073498 File Offset: 0x00071698
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003C5A RID: 15450 RVA: 0x000734A4 File Offset: 0x000716A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F06 RID: 3846
		private ErrorCode? _result;

		// Token: 0x04000F07 RID: 3847
		private IExtension extensionObject;
	}
}

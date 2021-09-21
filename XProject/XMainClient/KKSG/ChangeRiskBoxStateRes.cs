using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000211 RID: 529
	[ProtoContract(Name = "ChangeRiskBoxStateRes")]
	[Serializable]
	public class ChangeRiskBoxStateRes : IExtensible
	{
		// Token: 0x17000959 RID: 2393
		// (get) Token: 0x06001DDD RID: 7645 RVA: 0x0003ABA0 File Offset: 0x00038DA0
		// (set) Token: 0x06001DDE RID: 7646 RVA: 0x0003ABCC File Offset: 0x00038DCC
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x1700095A RID: 2394
		// (get) Token: 0x06001DDF RID: 7647 RVA: 0x0003ABDC File Offset: 0x00038DDC
		// (set) Token: 0x06001DE0 RID: 7648 RVA: 0x0003ABFC File Offset: 0x00038DFC
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06001DE1 RID: 7649 RVA: 0x0003AC40 File Offset: 0x00038E40
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001DE2 RID: 7650 RVA: 0x0003AC58 File Offset: 0x00038E58
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x1700095B RID: 2395
		// (get) Token: 0x06001DE3 RID: 7651 RVA: 0x0003AC64 File Offset: 0x00038E64
		[ProtoMember(2, Name = "openBoxRewards", DataFormat = DataFormat.Default)]
		public List<ItemBrief> openBoxRewards
		{
			get
			{
				return this._openBoxRewards;
			}
		}

		// Token: 0x06001DE4 RID: 7652 RVA: 0x0003AC7C File Offset: 0x00038E7C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000775 RID: 1909
		private ErrorCode? _error;

		// Token: 0x04000776 RID: 1910
		private readonly List<ItemBrief> _openBoxRewards = new List<ItemBrief>();

		// Token: 0x04000777 RID: 1911
		private IExtension extensionObject;
	}
}

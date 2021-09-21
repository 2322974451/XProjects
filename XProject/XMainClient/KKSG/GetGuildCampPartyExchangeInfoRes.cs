using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003F3 RID: 1011
	[ProtoContract(Name = "GetGuildCampPartyExchangeInfoRes")]
	[Serializable]
	public class GetGuildCampPartyExchangeInfoRes : IExtensible
	{
		// Token: 0x1700107A RID: 4218
		// (get) Token: 0x06003595 RID: 13717 RVA: 0x00066AD0 File Offset: 0x00064CD0
		// (set) Token: 0x06003596 RID: 13718 RVA: 0x00066AFC File Offset: 0x00064CFC
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

		// Token: 0x1700107B RID: 4219
		// (get) Token: 0x06003597 RID: 13719 RVA: 0x00066B0C File Offset: 0x00064D0C
		// (set) Token: 0x06003598 RID: 13720 RVA: 0x00066B2C File Offset: 0x00064D2C
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

		// Token: 0x06003599 RID: 13721 RVA: 0x00066B70 File Offset: 0x00064D70
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600359A RID: 13722 RVA: 0x00066B88 File Offset: 0x00064D88
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700107C RID: 4220
		// (get) Token: 0x0600359B RID: 13723 RVA: 0x00066B94 File Offset: 0x00064D94
		[ProtoMember(2, Name = "infos", DataFormat = DataFormat.Default)]
		public List<PartyExchangeItemInfo> infos
		{
			get
			{
				return this._infos;
			}
		}

		// Token: 0x0600359C RID: 13724 RVA: 0x00066BAC File Offset: 0x00064DAC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D51 RID: 3409
		private ErrorCode? _result;

		// Token: 0x04000D52 RID: 3410
		private readonly List<PartyExchangeItemInfo> _infos = new List<PartyExchangeItemInfo>();

		// Token: 0x04000D53 RID: 3411
		private IExtension extensionObject;
	}
}

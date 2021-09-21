using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003EF RID: 1007
	[ProtoContract(Name = "GuildCampPartyReqExchangeRes")]
	[Serializable]
	public class GuildCampPartyReqExchangeRes : IExtensible
	{
		// Token: 0x17001070 RID: 4208
		// (get) Token: 0x06003573 RID: 13683 RVA: 0x000666DC File Offset: 0x000648DC
		// (set) Token: 0x06003574 RID: 13684 RVA: 0x00066708 File Offset: 0x00064908
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

		// Token: 0x17001071 RID: 4209
		// (get) Token: 0x06003575 RID: 13685 RVA: 0x00066718 File Offset: 0x00064918
		// (set) Token: 0x06003576 RID: 13686 RVA: 0x00066738 File Offset: 0x00064938
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

		// Token: 0x06003577 RID: 13687 RVA: 0x0006677C File Offset: 0x0006497C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003578 RID: 13688 RVA: 0x00066794 File Offset: 0x00064994
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003579 RID: 13689 RVA: 0x000667A0 File Offset: 0x000649A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D47 RID: 3399
		private ErrorCode? _result;

		// Token: 0x04000D48 RID: 3400
		private IExtension extensionObject;
	}
}

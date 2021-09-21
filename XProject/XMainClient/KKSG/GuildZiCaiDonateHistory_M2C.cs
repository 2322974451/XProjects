using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000542 RID: 1346
	[ProtoContract(Name = "GuildZiCaiDonateHistory_M2C")]
	[Serializable]
	public class GuildZiCaiDonateHistory_M2C : IExtensible
	{
		// Token: 0x1700150D RID: 5389
		// (get) Token: 0x060044DF RID: 17631 RVA: 0x00082FA4 File Offset: 0x000811A4
		[ProtoMember(1, Name = "datalist", DataFormat = DataFormat.Default)]
		public List<GuildZiCaiDonateHistoryData> datalist
		{
			get
			{
				return this._datalist;
			}
		}

		// Token: 0x1700150E RID: 5390
		// (get) Token: 0x060044E0 RID: 17632 RVA: 0x00082FBC File Offset: 0x000811BC
		// (set) Token: 0x060044E1 RID: 17633 RVA: 0x00082FE8 File Offset: 0x000811E8
		[ProtoMember(2, IsRequired = false, Name = "ec", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ec
		{
			get
			{
				return this._ec ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ec = new ErrorCode?(value);
			}
		}

		// Token: 0x1700150F RID: 5391
		// (get) Token: 0x060044E2 RID: 17634 RVA: 0x00082FF8 File Offset: 0x000811F8
		// (set) Token: 0x060044E3 RID: 17635 RVA: 0x00083018 File Offset: 0x00081218
		[XmlIgnore]
		[Browsable(false)]
		public bool ecSpecified
		{
			get
			{
				return this._ec != null;
			}
			set
			{
				bool flag = value == (this._ec == null);
				if (flag)
				{
					this._ec = (value ? new ErrorCode?(this.ec) : null);
				}
			}
		}

		// Token: 0x060044E4 RID: 17636 RVA: 0x0008305C File Offset: 0x0008125C
		private bool ShouldSerializeec()
		{
			return this.ecSpecified;
		}

		// Token: 0x060044E5 RID: 17637 RVA: 0x00083074 File Offset: 0x00081274
		private void Resetec()
		{
			this.ecSpecified = false;
		}

		// Token: 0x060044E6 RID: 17638 RVA: 0x00083080 File Offset: 0x00081280
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001135 RID: 4405
		private readonly List<GuildZiCaiDonateHistoryData> _datalist = new List<GuildZiCaiDonateHistoryData>();

		// Token: 0x04001136 RID: 4406
		private ErrorCode? _ec;

		// Token: 0x04001137 RID: 4407
		private IExtension extensionObject;
	}
}

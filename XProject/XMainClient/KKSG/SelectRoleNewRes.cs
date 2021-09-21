using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000175 RID: 373
	[ProtoContract(Name = "SelectRoleNewRes")]
	[Serializable]
	public class SelectRoleNewRes : IExtensible
	{
		// Token: 0x17000710 RID: 1808
		// (get) Token: 0x0600164F RID: 5711 RVA: 0x0002CAD8 File Offset: 0x0002ACD8
		// (set) Token: 0x06001650 RID: 5712 RVA: 0x0002CB04 File Offset: 0x0002AD04
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

		// Token: 0x17000711 RID: 1809
		// (get) Token: 0x06001651 RID: 5713 RVA: 0x0002CB14 File Offset: 0x0002AD14
		// (set) Token: 0x06001652 RID: 5714 RVA: 0x0002CB34 File Offset: 0x0002AD34
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

		// Token: 0x06001653 RID: 5715 RVA: 0x0002CB78 File Offset: 0x0002AD78
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06001654 RID: 5716 RVA: 0x0002CB90 File Offset: 0x0002AD90
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000712 RID: 1810
		// (get) Token: 0x06001655 RID: 5717 RVA: 0x0002CB9C File Offset: 0x0002AD9C
		// (set) Token: 0x06001656 RID: 5718 RVA: 0x0002CBC8 File Offset: 0x0002ADC8
		[ProtoMember(2, IsRequired = false, Name = "banTime", DataFormat = DataFormat.TwosComplement)]
		public int banTime
		{
			get
			{
				return this._banTime ?? 0;
			}
			set
			{
				this._banTime = new int?(value);
			}
		}

		// Token: 0x17000713 RID: 1811
		// (get) Token: 0x06001657 RID: 5719 RVA: 0x0002CBD8 File Offset: 0x0002ADD8
		// (set) Token: 0x06001658 RID: 5720 RVA: 0x0002CBF8 File Offset: 0x0002ADF8
		[XmlIgnore]
		[Browsable(false)]
		public bool banTimeSpecified
		{
			get
			{
				return this._banTime != null;
			}
			set
			{
				bool flag = value == (this._banTime == null);
				if (flag)
				{
					this._banTime = (value ? new int?(this.banTime) : null);
				}
			}
		}

		// Token: 0x06001659 RID: 5721 RVA: 0x0002CC3C File Offset: 0x0002AE3C
		private bool ShouldSerializebanTime()
		{
			return this.banTimeSpecified;
		}

		// Token: 0x0600165A RID: 5722 RVA: 0x0002CC54 File Offset: 0x0002AE54
		private void ResetbanTime()
		{
			this.banTimeSpecified = false;
		}

		// Token: 0x17000714 RID: 1812
		// (get) Token: 0x0600165B RID: 5723 RVA: 0x0002CC60 File Offset: 0x0002AE60
		// (set) Token: 0x0600165C RID: 5724 RVA: 0x0002CC8C File Offset: 0x0002AE8C
		[ProtoMember(3, IsRequired = false, Name = "endTime", DataFormat = DataFormat.TwosComplement)]
		public int endTime
		{
			get
			{
				return this._endTime ?? 0;
			}
			set
			{
				this._endTime = new int?(value);
			}
		}

		// Token: 0x17000715 RID: 1813
		// (get) Token: 0x0600165D RID: 5725 RVA: 0x0002CC9C File Offset: 0x0002AE9C
		// (set) Token: 0x0600165E RID: 5726 RVA: 0x0002CCBC File Offset: 0x0002AEBC
		[XmlIgnore]
		[Browsable(false)]
		public bool endTimeSpecified
		{
			get
			{
				return this._endTime != null;
			}
			set
			{
				bool flag = value == (this._endTime == null);
				if (flag)
				{
					this._endTime = (value ? new int?(this.endTime) : null);
				}
			}
		}

		// Token: 0x0600165F RID: 5727 RVA: 0x0002CD00 File Offset: 0x0002AF00
		private bool ShouldSerializeendTime()
		{
			return this.endTimeSpecified;
		}

		// Token: 0x06001660 RID: 5728 RVA: 0x0002CD18 File Offset: 0x0002AF18
		private void ResetendTime()
		{
			this.endTimeSpecified = false;
		}

		// Token: 0x17000716 RID: 1814
		// (get) Token: 0x06001661 RID: 5729 RVA: 0x0002CD24 File Offset: 0x0002AF24
		// (set) Token: 0x06001662 RID: 5730 RVA: 0x0002CD45 File Offset: 0x0002AF45
		[ProtoMember(4, IsRequired = false, Name = "reason", DataFormat = DataFormat.Default)]
		public string reason
		{
			get
			{
				return this._reason ?? "";
			}
			set
			{
				this._reason = value;
			}
		}

		// Token: 0x17000717 RID: 1815
		// (get) Token: 0x06001663 RID: 5731 RVA: 0x0002CD50 File Offset: 0x0002AF50
		// (set) Token: 0x06001664 RID: 5732 RVA: 0x0002CD6C File Offset: 0x0002AF6C
		[XmlIgnore]
		[Browsable(false)]
		public bool reasonSpecified
		{
			get
			{
				return this._reason != null;
			}
			set
			{
				bool flag = value == (this._reason == null);
				if (flag)
				{
					this._reason = (value ? this.reason : null);
				}
			}
		}

		// Token: 0x06001665 RID: 5733 RVA: 0x0002CD9C File Offset: 0x0002AF9C
		private bool ShouldSerializereason()
		{
			return this.reasonSpecified;
		}

		// Token: 0x06001666 RID: 5734 RVA: 0x0002CDB4 File Offset: 0x0002AFB4
		private void Resetreason()
		{
			this.reasonSpecified = false;
		}

		// Token: 0x06001667 RID: 5735 RVA: 0x0002CDC0 File Offset: 0x0002AFC0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400058B RID: 1419
		private ErrorCode? _result;

		// Token: 0x0400058C RID: 1420
		private int? _banTime;

		// Token: 0x0400058D RID: 1421
		private int? _endTime;

		// Token: 0x0400058E RID: 1422
		private string _reason;

		// Token: 0x0400058F RID: 1423
		private IExtension extensionObject;
	}
}

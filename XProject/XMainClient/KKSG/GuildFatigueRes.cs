using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000AC RID: 172
	[ProtoContract(Name = "GuildFatigueRes")]
	[Serializable]
	public class GuildFatigueRes : IExtensible
	{
		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x06000BE8 RID: 3048 RVA: 0x00019404 File Offset: 0x00017604
		// (set) Token: 0x06000BE9 RID: 3049 RVA: 0x00019430 File Offset: 0x00017630
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

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x06000BEA RID: 3050 RVA: 0x00019440 File Offset: 0x00017640
		// (set) Token: 0x06000BEB RID: 3051 RVA: 0x00019460 File Offset: 0x00017660
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

		// Token: 0x06000BEC RID: 3052 RVA: 0x000194A4 File Offset: 0x000176A4
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x000194BC File Offset: 0x000176BC
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x06000BEE RID: 3054 RVA: 0x000194C8 File Offset: 0x000176C8
		// (set) Token: 0x06000BEF RID: 3055 RVA: 0x000194F4 File Offset: 0x000176F4
		[ProtoMember(2, IsRequired = false, Name = "totalsend", DataFormat = DataFormat.TwosComplement)]
		public int totalsend
		{
			get
			{
				return this._totalsend ?? 0;
			}
			set
			{
				this._totalsend = new int?(value);
			}
		}

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x06000BF0 RID: 3056 RVA: 0x00019504 File Offset: 0x00017704
		// (set) Token: 0x06000BF1 RID: 3057 RVA: 0x00019524 File Offset: 0x00017724
		[XmlIgnore]
		[Browsable(false)]
		public bool totalsendSpecified
		{
			get
			{
				return this._totalsend != null;
			}
			set
			{
				bool flag = value == (this._totalsend == null);
				if (flag)
				{
					this._totalsend = (value ? new int?(this.totalsend) : null);
				}
			}
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x00019568 File Offset: 0x00017768
		private bool ShouldSerializetotalsend()
		{
			return this.totalsendSpecified;
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x00019580 File Offset: 0x00017780
		private void Resettotalsend()
		{
			this.totalsendSpecified = false;
		}

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x06000BF4 RID: 3060 RVA: 0x0001958C File Offset: 0x0001778C
		// (set) Token: 0x06000BF5 RID: 3061 RVA: 0x000195B8 File Offset: 0x000177B8
		[ProtoMember(3, IsRequired = false, Name = "totalrecv", DataFormat = DataFormat.TwosComplement)]
		public int totalrecv
		{
			get
			{
				return this._totalrecv ?? 0;
			}
			set
			{
				this._totalrecv = new int?(value);
			}
		}

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x06000BF6 RID: 3062 RVA: 0x000195C8 File Offset: 0x000177C8
		// (set) Token: 0x06000BF7 RID: 3063 RVA: 0x000195E8 File Offset: 0x000177E8
		[XmlIgnore]
		[Browsable(false)]
		public bool totalrecvSpecified
		{
			get
			{
				return this._totalrecv != null;
			}
			set
			{
				bool flag = value == (this._totalrecv == null);
				if (flag)
				{
					this._totalrecv = (value ? new int?(this.totalrecv) : null);
				}
			}
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x0001962C File Offset: 0x0001782C
		private bool ShouldSerializetotalrecv()
		{
			return this.totalrecvSpecified;
		}

		// Token: 0x06000BF9 RID: 3065 RVA: 0x00019644 File Offset: 0x00017844
		private void Resettotalrecv()
		{
			this.totalrecvSpecified = false;
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x00019650 File Offset: 0x00017850
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002F6 RID: 758
		private ErrorCode? _result;

		// Token: 0x040002F7 RID: 759
		private int? _totalsend;

		// Token: 0x040002F8 RID: 760
		private int? _totalrecv;

		// Token: 0x040002F9 RID: 761
		private IExtension extensionObject;
	}
}

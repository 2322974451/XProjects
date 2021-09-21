using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000A2 RID: 162
	[ProtoContract(Name = "EndGuildCardRes")]
	[Serializable]
	public class EndGuildCardRes : IExtensible
	{
		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06000B23 RID: 2851 RVA: 0x00017DD4 File Offset: 0x00015FD4
		// (set) Token: 0x06000B24 RID: 2852 RVA: 0x00017E00 File Offset: 0x00016000
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06000B25 RID: 2853 RVA: 0x00017E10 File Offset: 0x00016010
		// (set) Token: 0x06000B26 RID: 2854 RVA: 0x00017E30 File Offset: 0x00016030
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x00017E74 File Offset: 0x00016074
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x00017E8C File Offset: 0x0001608C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06000B29 RID: 2857 RVA: 0x00017E98 File Offset: 0x00016098
		// (set) Token: 0x06000B2A RID: 2858 RVA: 0x00017EC4 File Offset: 0x000160C4
		[ProtoMember(2, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public uint result
		{
			get
			{
				return this._result ?? 0U;
			}
			set
			{
				this._result = new uint?(value);
			}
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06000B2B RID: 2859 RVA: 0x00017ED4 File Offset: 0x000160D4
		// (set) Token: 0x06000B2C RID: 2860 RVA: 0x00017EF4 File Offset: 0x000160F4
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
					this._result = (value ? new uint?(this.result) : null);
				}
			}
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x00017F38 File Offset: 0x00016138
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x00017F50 File Offset: 0x00016150
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x00017F5C File Offset: 0x0001615C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002CB RID: 715
		private ErrorCode? _errorcode;

		// Token: 0x040002CC RID: 716
		private uint? _result;

		// Token: 0x040002CD RID: 717
		private IExtension extensionObject;
	}
}

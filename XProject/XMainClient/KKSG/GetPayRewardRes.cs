using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003B0 RID: 944
	[ProtoContract(Name = "GetPayRewardRes")]
	[Serializable]
	public class GetPayRewardRes : IExtensible
	{
		// Token: 0x17000F97 RID: 3991
		// (get) Token: 0x06003289 RID: 12937 RVA: 0x000612D4 File Offset: 0x0005F4D4
		// (set) Token: 0x0600328A RID: 12938 RVA: 0x00061300 File Offset: 0x0005F500
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

		// Token: 0x17000F98 RID: 3992
		// (get) Token: 0x0600328B RID: 12939 RVA: 0x00061310 File Offset: 0x0005F510
		// (set) Token: 0x0600328C RID: 12940 RVA: 0x00061330 File Offset: 0x0005F530
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

		// Token: 0x0600328D RID: 12941 RVA: 0x00061374 File Offset: 0x0005F574
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x0600328E RID: 12942 RVA: 0x0006138C File Offset: 0x0005F58C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000F99 RID: 3993
		// (get) Token: 0x0600328F RID: 12943 RVA: 0x00061398 File Offset: 0x0005F598
		// (set) Token: 0x06003290 RID: 12944 RVA: 0x000613C4 File Offset: 0x0005F5C4
		[ProtoMember(2, IsRequired = false, Name = "cdTime", DataFormat = DataFormat.TwosComplement)]
		public uint cdTime
		{
			get
			{
				return this._cdTime ?? 0U;
			}
			set
			{
				this._cdTime = new uint?(value);
			}
		}

		// Token: 0x17000F9A RID: 3994
		// (get) Token: 0x06003291 RID: 12945 RVA: 0x000613D4 File Offset: 0x0005F5D4
		// (set) Token: 0x06003292 RID: 12946 RVA: 0x000613F4 File Offset: 0x0005F5F4
		[XmlIgnore]
		[Browsable(false)]
		public bool cdTimeSpecified
		{
			get
			{
				return this._cdTime != null;
			}
			set
			{
				bool flag = value == (this._cdTime == null);
				if (flag)
				{
					this._cdTime = (value ? new uint?(this.cdTime) : null);
				}
			}
		}

		// Token: 0x06003293 RID: 12947 RVA: 0x00061438 File Offset: 0x0005F638
		private bool ShouldSerializecdTime()
		{
			return this.cdTimeSpecified;
		}

		// Token: 0x06003294 RID: 12948 RVA: 0x00061450 File Offset: 0x0005F650
		private void ResetcdTime()
		{
			this.cdTimeSpecified = false;
		}

		// Token: 0x06003295 RID: 12949 RVA: 0x0006145C File Offset: 0x0005F65C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C92 RID: 3218
		private ErrorCode? _errorcode;

		// Token: 0x04000C93 RID: 3219
		private uint? _cdTime;

		// Token: 0x04000C94 RID: 3220
		private IExtension extensionObject;
	}
}

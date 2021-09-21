using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003E5 RID: 997
	[ProtoContract(Name = "GetSkyCraftEliInfoRes")]
	[Serializable]
	public class GetSkyCraftEliInfoRes : IExtensible
	{
		// Token: 0x17001055 RID: 4181
		// (get) Token: 0x06003516 RID: 13590 RVA: 0x00065C68 File Offset: 0x00063E68
		// (set) Token: 0x06003517 RID: 13591 RVA: 0x00065C94 File Offset: 0x00063E94
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

		// Token: 0x17001056 RID: 4182
		// (get) Token: 0x06003518 RID: 13592 RVA: 0x00065CA4 File Offset: 0x00063EA4
		// (set) Token: 0x06003519 RID: 13593 RVA: 0x00065CC4 File Offset: 0x00063EC4
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

		// Token: 0x0600351A RID: 13594 RVA: 0x00065D08 File Offset: 0x00063F08
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600351B RID: 13595 RVA: 0x00065D20 File Offset: 0x00063F20
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17001057 RID: 4183
		// (get) Token: 0x0600351C RID: 13596 RVA: 0x00065D2C File Offset: 0x00063F2C
		[ProtoMember(2, Name = "rounds", DataFormat = DataFormat.Default)]
		public List<SCEliRoundInfo> rounds
		{
			get
			{
				return this._rounds;
			}
		}

		// Token: 0x17001058 RID: 4184
		// (get) Token: 0x0600351D RID: 13597 RVA: 0x00065D44 File Offset: 0x00063F44
		// (set) Token: 0x0600351E RID: 13598 RVA: 0x00065D5C File Offset: 0x00063F5C
		[ProtoMember(3, IsRequired = false, Name = "chamption", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SkyTeamDetail chamption
		{
			get
			{
				return this._chamption;
			}
			set
			{
				this._chamption = value;
			}
		}

		// Token: 0x0600351F RID: 13599 RVA: 0x00065D68 File Offset: 0x00063F68
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D2D RID: 3373
		private ErrorCode? _result;

		// Token: 0x04000D2E RID: 3374
		private readonly List<SCEliRoundInfo> _rounds = new List<SCEliRoundInfo>();

		// Token: 0x04000D2F RID: 3375
		private SkyTeamDetail _chamption = null;

		// Token: 0x04000D30 RID: 3376
		private IExtension extensionObject;
	}
}

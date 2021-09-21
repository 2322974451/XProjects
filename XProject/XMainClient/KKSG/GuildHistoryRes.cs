using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000A8 RID: 168
	[ProtoContract(Name = "GuildHistoryRes")]
	[Serializable]
	public class GuildHistoryRes : IExtensible
	{
		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x06000B89 RID: 2953 RVA: 0x000189AC File Offset: 0x00016BAC
		// (set) Token: 0x06000B8A RID: 2954 RVA: 0x000189D8 File Offset: 0x00016BD8
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

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06000B8B RID: 2955 RVA: 0x000189E8 File Offset: 0x00016BE8
		// (set) Token: 0x06000B8C RID: 2956 RVA: 0x00018A08 File Offset: 0x00016C08
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

		// Token: 0x06000B8D RID: 2957 RVA: 0x00018A4C File Offset: 0x00016C4C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x00018A64 File Offset: 0x00016C64
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x06000B8F RID: 2959 RVA: 0x00018A70 File Offset: 0x00016C70
		[ProtoMember(2, Name = "records", DataFormat = DataFormat.Default)]
		public List<GHisRecord> records
		{
			get
			{
				return this._records;
			}
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x00018A88 File Offset: 0x00016C88
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002E0 RID: 736
		private ErrorCode? _result;

		// Token: 0x040002E1 RID: 737
		private readonly List<GHisRecord> _records = new List<GHisRecord>();

		// Token: 0x040002E2 RID: 738
		private IExtension extensionObject;
	}
}

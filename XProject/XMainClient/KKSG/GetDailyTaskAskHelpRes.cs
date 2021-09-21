using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004FB RID: 1275
	[ProtoContract(Name = "GetDailyTaskAskHelpRes")]
	[Serializable]
	public class GetDailyTaskAskHelpRes : IExtensible
	{
		// Token: 0x1700142B RID: 5163
		// (get) Token: 0x060041E2 RID: 16866 RVA: 0x0007D6F8 File Offset: 0x0007B8F8
		// (set) Token: 0x060041E3 RID: 16867 RVA: 0x0007D724 File Offset: 0x0007B924
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

		// Token: 0x1700142C RID: 5164
		// (get) Token: 0x060041E4 RID: 16868 RVA: 0x0007D734 File Offset: 0x0007B934
		// (set) Token: 0x060041E5 RID: 16869 RVA: 0x0007D754 File Offset: 0x0007B954
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

		// Token: 0x060041E6 RID: 16870 RVA: 0x0007D798 File Offset: 0x0007B998
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060041E7 RID: 16871 RVA: 0x0007D7B0 File Offset: 0x0007B9B0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700142D RID: 5165
		// (get) Token: 0x060041E8 RID: 16872 RVA: 0x0007D7BC File Offset: 0x0007B9BC
		// (set) Token: 0x060041E9 RID: 16873 RVA: 0x0007D7E8 File Offset: 0x0007B9E8
		[ProtoMember(2, IsRequired = false, Name = "help_num", DataFormat = DataFormat.TwosComplement)]
		public uint help_num
		{
			get
			{
				return this._help_num ?? 0U;
			}
			set
			{
				this._help_num = new uint?(value);
			}
		}

		// Token: 0x1700142E RID: 5166
		// (get) Token: 0x060041EA RID: 16874 RVA: 0x0007D7F8 File Offset: 0x0007B9F8
		// (set) Token: 0x060041EB RID: 16875 RVA: 0x0007D818 File Offset: 0x0007BA18
		[XmlIgnore]
		[Browsable(false)]
		public bool help_numSpecified
		{
			get
			{
				return this._help_num != null;
			}
			set
			{
				bool flag = value == (this._help_num == null);
				if (flag)
				{
					this._help_num = (value ? new uint?(this.help_num) : null);
				}
			}
		}

		// Token: 0x060041EC RID: 16876 RVA: 0x0007D85C File Offset: 0x0007BA5C
		private bool ShouldSerializehelp_num()
		{
			return this.help_numSpecified;
		}

		// Token: 0x060041ED RID: 16877 RVA: 0x0007D874 File Offset: 0x0007BA74
		private void Resethelp_num()
		{
			this.help_numSpecified = false;
		}

		// Token: 0x1700142F RID: 5167
		// (get) Token: 0x060041EE RID: 16878 RVA: 0x0007D880 File Offset: 0x0007BA80
		[ProtoMember(3, Name = "askinfos", DataFormat = DataFormat.Default)]
		public List<DailyTaskRefreshRoleInfo> askinfos
		{
			get
			{
				return this._askinfos;
			}
		}

		// Token: 0x17001430 RID: 5168
		// (get) Token: 0x060041EF RID: 16879 RVA: 0x0007D898 File Offset: 0x0007BA98
		// (set) Token: 0x060041F0 RID: 16880 RVA: 0x0007D8C4 File Offset: 0x0007BAC4
		[ProtoMember(4, IsRequired = false, Name = "luck", DataFormat = DataFormat.TwosComplement)]
		public uint luck
		{
			get
			{
				return this._luck ?? 0U;
			}
			set
			{
				this._luck = new uint?(value);
			}
		}

		// Token: 0x17001431 RID: 5169
		// (get) Token: 0x060041F1 RID: 16881 RVA: 0x0007D8D4 File Offset: 0x0007BAD4
		// (set) Token: 0x060041F2 RID: 16882 RVA: 0x0007D8F4 File Offset: 0x0007BAF4
		[XmlIgnore]
		[Browsable(false)]
		public bool luckSpecified
		{
			get
			{
				return this._luck != null;
			}
			set
			{
				bool flag = value == (this._luck == null);
				if (flag)
				{
					this._luck = (value ? new uint?(this.luck) : null);
				}
			}
		}

		// Token: 0x060041F3 RID: 16883 RVA: 0x0007D938 File Offset: 0x0007BB38
		private bool ShouldSerializeluck()
		{
			return this.luckSpecified;
		}

		// Token: 0x060041F4 RID: 16884 RVA: 0x0007D950 File Offset: 0x0007BB50
		private void Resetluck()
		{
			this.luckSpecified = false;
		}

		// Token: 0x060041F5 RID: 16885 RVA: 0x0007D95C File Offset: 0x0007BB5C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400106E RID: 4206
		private ErrorCode? _result;

		// Token: 0x0400106F RID: 4207
		private uint? _help_num;

		// Token: 0x04001070 RID: 4208
		private readonly List<DailyTaskRefreshRoleInfo> _askinfos = new List<DailyTaskRefreshRoleInfo>();

		// Token: 0x04001071 RID: 4209
		private uint? _luck;

		// Token: 0x04001072 RID: 4210
		private IExtension extensionObject;
	}
}

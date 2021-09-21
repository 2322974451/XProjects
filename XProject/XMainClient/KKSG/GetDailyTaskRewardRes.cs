using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002D0 RID: 720
	[ProtoContract(Name = "GetDailyTaskRewardRes")]
	[Serializable]
	public class GetDailyTaskRewardRes : IExtensible
	{
		// Token: 0x17000C5D RID: 3165
		// (get) Token: 0x060027C2 RID: 10178 RVA: 0x0004D4B4 File Offset: 0x0004B6B4
		// (set) Token: 0x060027C3 RID: 10179 RVA: 0x0004D4E0 File Offset: 0x0004B6E0
		[ProtoMember(1, IsRequired = false, Name = "code", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode code
		{
			get
			{
				return this._code ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._code = new ErrorCode?(value);
			}
		}

		// Token: 0x17000C5E RID: 3166
		// (get) Token: 0x060027C4 RID: 10180 RVA: 0x0004D4F0 File Offset: 0x0004B6F0
		// (set) Token: 0x060027C5 RID: 10181 RVA: 0x0004D510 File Offset: 0x0004B710
		[XmlIgnore]
		[Browsable(false)]
		public bool codeSpecified
		{
			get
			{
				return this._code != null;
			}
			set
			{
				bool flag = value == (this._code == null);
				if (flag)
				{
					this._code = (value ? new ErrorCode?(this.code) : null);
				}
			}
		}

		// Token: 0x060027C6 RID: 10182 RVA: 0x0004D554 File Offset: 0x0004B754
		private bool ShouldSerializecode()
		{
			return this.codeSpecified;
		}

		// Token: 0x060027C7 RID: 10183 RVA: 0x0004D56C File Offset: 0x0004B76C
		private void Resetcode()
		{
			this.codeSpecified = false;
		}

		// Token: 0x17000C5F RID: 3167
		// (get) Token: 0x060027C8 RID: 10184 RVA: 0x0004D578 File Offset: 0x0004B778
		[ProtoMember(2, Name = "task", DataFormat = DataFormat.Default)]
		public List<DailyTaskInfo> task
		{
			get
			{
				return this._task;
			}
		}

		// Token: 0x060027C9 RID: 10185 RVA: 0x0004D590 File Offset: 0x0004B790
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009E4 RID: 2532
		private ErrorCode? _code;

		// Token: 0x040009E5 RID: 2533
		private readonly List<DailyTaskInfo> _task = new List<DailyTaskInfo>();

		// Token: 0x040009E6 RID: 2534
		private IExtension extensionObject;
	}
}

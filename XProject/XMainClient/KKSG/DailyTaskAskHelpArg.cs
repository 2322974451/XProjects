using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002D2 RID: 722
	[ProtoContract(Name = "DailyTaskAskHelpArg")]
	[Serializable]
	public class DailyTaskAskHelpArg : IExtensible
	{
		// Token: 0x17000C62 RID: 3170
		// (get) Token: 0x060027D3 RID: 10195 RVA: 0x0004D694 File Offset: 0x0004B894
		// (set) Token: 0x060027D4 RID: 10196 RVA: 0x0004D6C0 File Offset: 0x0004B8C0
		[ProtoMember(1, IsRequired = false, Name = "task_id", DataFormat = DataFormat.TwosComplement)]
		public uint task_id
		{
			get
			{
				return this._task_id ?? 0U;
			}
			set
			{
				this._task_id = new uint?(value);
			}
		}

		// Token: 0x17000C63 RID: 3171
		// (get) Token: 0x060027D5 RID: 10197 RVA: 0x0004D6D0 File Offset: 0x0004B8D0
		// (set) Token: 0x060027D6 RID: 10198 RVA: 0x0004D6F0 File Offset: 0x0004B8F0
		[XmlIgnore]
		[Browsable(false)]
		public bool task_idSpecified
		{
			get
			{
				return this._task_id != null;
			}
			set
			{
				bool flag = value == (this._task_id == null);
				if (flag)
				{
					this._task_id = (value ? new uint?(this.task_id) : null);
				}
			}
		}

		// Token: 0x060027D7 RID: 10199 RVA: 0x0004D734 File Offset: 0x0004B934
		private bool ShouldSerializetask_id()
		{
			return this.task_idSpecified;
		}

		// Token: 0x060027D8 RID: 10200 RVA: 0x0004D74C File Offset: 0x0004B94C
		private void Resettask_id()
		{
			this.task_idSpecified = false;
		}

		// Token: 0x17000C64 RID: 3172
		// (get) Token: 0x060027D9 RID: 10201 RVA: 0x0004D758 File Offset: 0x0004B958
		// (set) Token: 0x060027DA RID: 10202 RVA: 0x0004D784 File Offset: 0x0004B984
		[ProtoMember(2, IsRequired = false, Name = "task_type", DataFormat = DataFormat.TwosComplement)]
		public PeriodTaskType task_type
		{
			get
			{
				return this._task_type ?? PeriodTaskType.PeriodTaskType_Daily;
			}
			set
			{
				this._task_type = new PeriodTaskType?(value);
			}
		}

		// Token: 0x17000C65 RID: 3173
		// (get) Token: 0x060027DB RID: 10203 RVA: 0x0004D794 File Offset: 0x0004B994
		// (set) Token: 0x060027DC RID: 10204 RVA: 0x0004D7B4 File Offset: 0x0004B9B4
		[XmlIgnore]
		[Browsable(false)]
		public bool task_typeSpecified
		{
			get
			{
				return this._task_type != null;
			}
			set
			{
				bool flag = value == (this._task_type == null);
				if (flag)
				{
					this._task_type = (value ? new PeriodTaskType?(this.task_type) : null);
				}
			}
		}

		// Token: 0x060027DD RID: 10205 RVA: 0x0004D7F8 File Offset: 0x0004B9F8
		private bool ShouldSerializetask_type()
		{
			return this.task_typeSpecified;
		}

		// Token: 0x060027DE RID: 10206 RVA: 0x0004D810 File Offset: 0x0004BA10
		private void Resettask_type()
		{
			this.task_typeSpecified = false;
		}

		// Token: 0x060027DF RID: 10207 RVA: 0x0004D81C File Offset: 0x0004BA1C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009E9 RID: 2537
		private uint? _task_id;

		// Token: 0x040009EA RID: 2538
		private PeriodTaskType? _task_type;

		// Token: 0x040009EB RID: 2539
		private IExtension extensionObject;
	}
}

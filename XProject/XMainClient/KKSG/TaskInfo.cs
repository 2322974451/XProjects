using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000237 RID: 567
	[ProtoContract(Name = "TaskInfo")]
	[Serializable]
	public class TaskInfo : IExtensible
	{
		// Token: 0x170009D0 RID: 2512
		// (get) Token: 0x06001F7F RID: 8063 RVA: 0x0003DBE0 File Offset: 0x0003BDE0
		// (set) Token: 0x06001F80 RID: 8064 RVA: 0x0003DC0C File Offset: 0x0003BE0C
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x170009D1 RID: 2513
		// (get) Token: 0x06001F81 RID: 8065 RVA: 0x0003DC1C File Offset: 0x0003BE1C
		// (set) Token: 0x06001F82 RID: 8066 RVA: 0x0003DC3C File Offset: 0x0003BE3C
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x06001F83 RID: 8067 RVA: 0x0003DC80 File Offset: 0x0003BE80
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06001F84 RID: 8068 RVA: 0x0003DC98 File Offset: 0x0003BE98
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x170009D2 RID: 2514
		// (get) Token: 0x06001F85 RID: 8069 RVA: 0x0003DCA4 File Offset: 0x0003BEA4
		// (set) Token: 0x06001F86 RID: 8070 RVA: 0x0003DCD0 File Offset: 0x0003BED0
		[ProtoMember(2, IsRequired = false, Name = "status", DataFormat = DataFormat.TwosComplement)]
		public TaskStatus status
		{
			get
			{
				return this._status ?? TaskStatus.TaskStatus_CanTake;
			}
			set
			{
				this._status = new TaskStatus?(value);
			}
		}

		// Token: 0x170009D3 RID: 2515
		// (get) Token: 0x06001F87 RID: 8071 RVA: 0x0003DCE0 File Offset: 0x0003BEE0
		// (set) Token: 0x06001F88 RID: 8072 RVA: 0x0003DD00 File Offset: 0x0003BF00
		[XmlIgnore]
		[Browsable(false)]
		public bool statusSpecified
		{
			get
			{
				return this._status != null;
			}
			set
			{
				bool flag = value == (this._status == null);
				if (flag)
				{
					this._status = (value ? new TaskStatus?(this.status) : null);
				}
			}
		}

		// Token: 0x06001F89 RID: 8073 RVA: 0x0003DD44 File Offset: 0x0003BF44
		private bool ShouldSerializestatus()
		{
			return this.statusSpecified;
		}

		// Token: 0x06001F8A RID: 8074 RVA: 0x0003DD5C File Offset: 0x0003BF5C
		private void Resetstatus()
		{
			this.statusSpecified = false;
		}

		// Token: 0x170009D4 RID: 2516
		// (get) Token: 0x06001F8B RID: 8075 RVA: 0x0003DD68 File Offset: 0x0003BF68
		[ProtoMember(3, Name = "conds", DataFormat = DataFormat.Default)]
		public List<TaskConditionInfo> conds
		{
			get
			{
				return this._conds;
			}
		}

		// Token: 0x06001F8C RID: 8076 RVA: 0x0003DD80 File Offset: 0x0003BF80
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007DB RID: 2011
		private uint? _id;

		// Token: 0x040007DC RID: 2012
		private TaskStatus? _status;

		// Token: 0x040007DD RID: 2013
		private readonly List<TaskConditionInfo> _conds = new List<TaskConditionInfo>();

		// Token: 0x040007DE RID: 2014
		private IExtension extensionObject;
	}
}

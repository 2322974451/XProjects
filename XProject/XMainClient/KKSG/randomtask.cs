using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000D4 RID: 212
	[ProtoContract(Name = "randomtask")]
	[Serializable]
	public class randomtask : IExtensible
	{
		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x06000D99 RID: 3481 RVA: 0x0001C5D8 File Offset: 0x0001A7D8
		// (set) Token: 0x06000D9A RID: 3482 RVA: 0x0001C604 File Offset: 0x0001A804
		[ProtoMember(1, IsRequired = false, Name = "taskid", DataFormat = DataFormat.TwosComplement)]
		public int taskid
		{
			get
			{
				return this._taskid ?? 0;
			}
			set
			{
				this._taskid = new int?(value);
			}
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x06000D9B RID: 3483 RVA: 0x0001C614 File Offset: 0x0001A814
		// (set) Token: 0x06000D9C RID: 3484 RVA: 0x0001C634 File Offset: 0x0001A834
		[XmlIgnore]
		[Browsable(false)]
		public bool taskidSpecified
		{
			get
			{
				return this._taskid != null;
			}
			set
			{
				bool flag = value == (this._taskid == null);
				if (flag)
				{
					this._taskid = (value ? new int?(this.taskid) : null);
				}
			}
		}

		// Token: 0x06000D9D RID: 3485 RVA: 0x0001C678 File Offset: 0x0001A878
		private bool ShouldSerializetaskid()
		{
			return this.taskidSpecified;
		}

		// Token: 0x06000D9E RID: 3486 RVA: 0x0001C690 File Offset: 0x0001A890
		private void Resettaskid()
		{
			this.taskidSpecified = false;
		}

		// Token: 0x06000D9F RID: 3487 RVA: 0x0001C69C File Offset: 0x0001A89C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400036C RID: 876
		private int? _taskid;

		// Token: 0x0400036D RID: 877
		private IExtension extensionObject;
	}
}

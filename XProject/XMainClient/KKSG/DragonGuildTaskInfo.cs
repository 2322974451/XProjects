using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200072F RID: 1839
	[ProtoContract(Name = "DragonGuildTaskInfo")]
	[Serializable]
	public class DragonGuildTaskInfo : IExtensible
	{
		// Token: 0x17002853 RID: 10323
		// (get) Token: 0x06007F2C RID: 32556 RVA: 0x000F32F4 File Offset: 0x000F14F4
		// (set) Token: 0x06007F2D RID: 32557 RVA: 0x000F3320 File Offset: 0x000F1520
		[ProtoMember(1, IsRequired = false, Name = "taskID", DataFormat = DataFormat.TwosComplement)]
		public uint taskID
		{
			get
			{
				return this._taskID ?? 0U;
			}
			set
			{
				this._taskID = new uint?(value);
			}
		}

		// Token: 0x17002854 RID: 10324
		// (get) Token: 0x06007F2E RID: 32558 RVA: 0x000F3330 File Offset: 0x000F1530
		// (set) Token: 0x06007F2F RID: 32559 RVA: 0x000F3350 File Offset: 0x000F1550
		[XmlIgnore]
		[Browsable(false)]
		public bool taskIDSpecified
		{
			get
			{
				return this._taskID != null;
			}
			set
			{
				bool flag = value == (this._taskID == null);
				if (flag)
				{
					this._taskID = (value ? new uint?(this.taskID) : null);
				}
			}
		}

		// Token: 0x06007F30 RID: 32560 RVA: 0x000F3394 File Offset: 0x000F1594
		private bool ShouldSerializetaskID()
		{
			return this.taskIDSpecified;
		}

		// Token: 0x06007F31 RID: 32561 RVA: 0x000F33AC File Offset: 0x000F15AC
		private void ResettaskID()
		{
			this.taskIDSpecified = false;
		}

		// Token: 0x17002855 RID: 10325
		// (get) Token: 0x06007F32 RID: 32562 RVA: 0x000F33B8 File Offset: 0x000F15B8
		// (set) Token: 0x06007F33 RID: 32563 RVA: 0x000F33E4 File Offset: 0x000F15E4
		[ProtoMember(2, IsRequired = false, Name = "finishCount", DataFormat = DataFormat.TwosComplement)]
		public uint finishCount
		{
			get
			{
				return this._finishCount ?? 0U;
			}
			set
			{
				this._finishCount = new uint?(value);
			}
		}

		// Token: 0x17002856 RID: 10326
		// (get) Token: 0x06007F34 RID: 32564 RVA: 0x000F33F4 File Offset: 0x000F15F4
		// (set) Token: 0x06007F35 RID: 32565 RVA: 0x000F3414 File Offset: 0x000F1614
		[XmlIgnore]
		[Browsable(false)]
		public bool finishCountSpecified
		{
			get
			{
				return this._finishCount != null;
			}
			set
			{
				bool flag = value == (this._finishCount == null);
				if (flag)
				{
					this._finishCount = (value ? new uint?(this.finishCount) : null);
				}
			}
		}

		// Token: 0x06007F36 RID: 32566 RVA: 0x000F3458 File Offset: 0x000F1658
		private bool ShouldSerializefinishCount()
		{
			return this.finishCountSpecified;
		}

		// Token: 0x06007F37 RID: 32567 RVA: 0x000F3470 File Offset: 0x000F1670
		private void ResetfinishCount()
		{
			this.finishCountSpecified = false;
		}

		// Token: 0x17002857 RID: 10327
		// (get) Token: 0x06007F38 RID: 32568 RVA: 0x000F347C File Offset: 0x000F167C
		// (set) Token: 0x06007F39 RID: 32569 RVA: 0x000F34A8 File Offset: 0x000F16A8
		[ProtoMember(3, IsRequired = false, Name = "receiveCount", DataFormat = DataFormat.TwosComplement)]
		public uint receiveCount
		{
			get
			{
				return this._receiveCount ?? 0U;
			}
			set
			{
				this._receiveCount = new uint?(value);
			}
		}

		// Token: 0x17002858 RID: 10328
		// (get) Token: 0x06007F3A RID: 32570 RVA: 0x000F34B8 File Offset: 0x000F16B8
		// (set) Token: 0x06007F3B RID: 32571 RVA: 0x000F34D8 File Offset: 0x000F16D8
		[XmlIgnore]
		[Browsable(false)]
		public bool receiveCountSpecified
		{
			get
			{
				return this._receiveCount != null;
			}
			set
			{
				bool flag = value == (this._receiveCount == null);
				if (flag)
				{
					this._receiveCount = (value ? new uint?(this.receiveCount) : null);
				}
			}
		}

		// Token: 0x06007F3C RID: 32572 RVA: 0x000F351C File Offset: 0x000F171C
		private bool ShouldSerializereceiveCount()
		{
			return this.receiveCountSpecified;
		}

		// Token: 0x06007F3D RID: 32573 RVA: 0x000F3534 File Offset: 0x000F1734
		private void ResetreceiveCount()
		{
			this.receiveCountSpecified = false;
		}

		// Token: 0x06007F3E RID: 32574 RVA: 0x000F3540 File Offset: 0x000F1740
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DD8 RID: 7640
		private uint? _taskID;

		// Token: 0x04001DD9 RID: 7641
		private uint? _finishCount;

		// Token: 0x04001DDA RID: 7642
		private uint? _receiveCount;

		// Token: 0x04001DDB RID: 7643
		private IExtension extensionObject;
	}
}

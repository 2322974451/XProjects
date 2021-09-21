using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000644 RID: 1604
	[ProtoContract(Name = "SpActivityTask")]
	[Serializable]
	public class SpActivityTask : IExtensible
	{
		// Token: 0x17001F6D RID: 8045
		// (get) Token: 0x060063AC RID: 25516 RVA: 0x000BE358 File Offset: 0x000BC558
		// (set) Token: 0x060063AD RID: 25517 RVA: 0x000BE384 File Offset: 0x000BC584
		[ProtoMember(1, IsRequired = false, Name = "taskid", DataFormat = DataFormat.TwosComplement)]
		public uint taskid
		{
			get
			{
				return this._taskid ?? 0U;
			}
			set
			{
				this._taskid = new uint?(value);
			}
		}

		// Token: 0x17001F6E RID: 8046
		// (get) Token: 0x060063AE RID: 25518 RVA: 0x000BE394 File Offset: 0x000BC594
		// (set) Token: 0x060063AF RID: 25519 RVA: 0x000BE3B4 File Offset: 0x000BC5B4
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
					this._taskid = (value ? new uint?(this.taskid) : null);
				}
			}
		}

		// Token: 0x060063B0 RID: 25520 RVA: 0x000BE3F8 File Offset: 0x000BC5F8
		private bool ShouldSerializetaskid()
		{
			return this.taskidSpecified;
		}

		// Token: 0x060063B1 RID: 25521 RVA: 0x000BE410 File Offset: 0x000BC610
		private void Resettaskid()
		{
			this.taskidSpecified = false;
		}

		// Token: 0x17001F6F RID: 8047
		// (get) Token: 0x060063B2 RID: 25522 RVA: 0x000BE41C File Offset: 0x000BC61C
		// (set) Token: 0x060063B3 RID: 25523 RVA: 0x000BE448 File Offset: 0x000BC648
		[ProtoMember(2, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		// Token: 0x17001F70 RID: 8048
		// (get) Token: 0x060063B4 RID: 25524 RVA: 0x000BE458 File Offset: 0x000BC658
		// (set) Token: 0x060063B5 RID: 25525 RVA: 0x000BE478 File Offset: 0x000BC678
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		// Token: 0x060063B6 RID: 25526 RVA: 0x000BE4BC File Offset: 0x000BC6BC
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x060063B7 RID: 25527 RVA: 0x000BE4D4 File Offset: 0x000BC6D4
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x17001F71 RID: 8049
		// (get) Token: 0x060063B8 RID: 25528 RVA: 0x000BE4E0 File Offset: 0x000BC6E0
		// (set) Token: 0x060063B9 RID: 25529 RVA: 0x000BE50C File Offset: 0x000BC70C
		[ProtoMember(3, IsRequired = false, Name = "progress", DataFormat = DataFormat.TwosComplement)]
		public uint progress
		{
			get
			{
				return this._progress ?? 0U;
			}
			set
			{
				this._progress = new uint?(value);
			}
		}

		// Token: 0x17001F72 RID: 8050
		// (get) Token: 0x060063BA RID: 25530 RVA: 0x000BE51C File Offset: 0x000BC71C
		// (set) Token: 0x060063BB RID: 25531 RVA: 0x000BE53C File Offset: 0x000BC73C
		[XmlIgnore]
		[Browsable(false)]
		public bool progressSpecified
		{
			get
			{
				return this._progress != null;
			}
			set
			{
				bool flag = value == (this._progress == null);
				if (flag)
				{
					this._progress = (value ? new uint?(this.progress) : null);
				}
			}
		}

		// Token: 0x060063BC RID: 25532 RVA: 0x000BE580 File Offset: 0x000BC780
		private bool ShouldSerializeprogress()
		{
			return this.progressSpecified;
		}

		// Token: 0x060063BD RID: 25533 RVA: 0x000BE598 File Offset: 0x000BC798
		private void Resetprogress()
		{
			this.progressSpecified = false;
		}

		// Token: 0x060063BE RID: 25534 RVA: 0x000BE5A4 File Offset: 0x000BC7A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001829 RID: 6185
		private uint? _taskid;

		// Token: 0x0400182A RID: 6186
		private uint? _state;

		// Token: 0x0400182B RID: 6187
		private uint? _progress;

		// Token: 0x0400182C RID: 6188
		private IExtension extensionObject;
	}
}

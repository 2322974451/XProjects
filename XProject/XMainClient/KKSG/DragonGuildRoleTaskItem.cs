using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000680 RID: 1664
	[ProtoContract(Name = "DragonGuildRoleTaskItem")]
	[Serializable]
	public class DragonGuildRoleTaskItem : IExtensible
	{
		// Token: 0x170021C6 RID: 8646
		// (get) Token: 0x06006AB9 RID: 27321 RVA: 0x000CC1C0 File Offset: 0x000CA3C0
		// (set) Token: 0x06006ABA RID: 27322 RVA: 0x000CC1EC File Offset: 0x000CA3EC
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

		// Token: 0x170021C7 RID: 8647
		// (get) Token: 0x06006ABB RID: 27323 RVA: 0x000CC1FC File Offset: 0x000CA3FC
		// (set) Token: 0x06006ABC RID: 27324 RVA: 0x000CC21C File Offset: 0x000CA41C
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

		// Token: 0x06006ABD RID: 27325 RVA: 0x000CC260 File Offset: 0x000CA460
		private bool ShouldSerializetaskid()
		{
			return this.taskidSpecified;
		}

		// Token: 0x06006ABE RID: 27326 RVA: 0x000CC278 File Offset: 0x000CA478
		private void Resettaskid()
		{
			this.taskidSpecified = false;
		}

		// Token: 0x170021C8 RID: 8648
		// (get) Token: 0x06006ABF RID: 27327 RVA: 0x000CC284 File Offset: 0x000CA484
		// (set) Token: 0x06006AC0 RID: 27328 RVA: 0x000CC2B0 File Offset: 0x000CA4B0
		[ProtoMember(2, IsRequired = false, Name = "received", DataFormat = DataFormat.Default)]
		public bool received
		{
			get
			{
				return this._received ?? false;
			}
			set
			{
				this._received = new bool?(value);
			}
		}

		// Token: 0x170021C9 RID: 8649
		// (get) Token: 0x06006AC1 RID: 27329 RVA: 0x000CC2C0 File Offset: 0x000CA4C0
		// (set) Token: 0x06006AC2 RID: 27330 RVA: 0x000CC2E0 File Offset: 0x000CA4E0
		[XmlIgnore]
		[Browsable(false)]
		public bool receivedSpecified
		{
			get
			{
				return this._received != null;
			}
			set
			{
				bool flag = value == (this._received == null);
				if (flag)
				{
					this._received = (value ? new bool?(this.received) : null);
				}
			}
		}

		// Token: 0x06006AC3 RID: 27331 RVA: 0x000CC324 File Offset: 0x000CA524
		private bool ShouldSerializereceived()
		{
			return this.receivedSpecified;
		}

		// Token: 0x06006AC4 RID: 27332 RVA: 0x000CC33C File Offset: 0x000CA53C
		private void Resetreceived()
		{
			this.receivedSpecified = false;
		}

		// Token: 0x06006AC5 RID: 27333 RVA: 0x000CC348 File Offset: 0x000CA548
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040019B2 RID: 6578
		private uint? _taskid;

		// Token: 0x040019B3 RID: 6579
		private bool? _received;

		// Token: 0x040019B4 RID: 6580
		private IExtension extensionObject;
	}
}

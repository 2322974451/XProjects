using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000538 RID: 1336
	[ProtoContract(Name = "GuildHallGetBuffList_M2C")]
	[Serializable]
	public class GuildHallGetBuffList_M2C : IExtensible
	{
		// Token: 0x170014F1 RID: 5361
		// (get) Token: 0x0600447E RID: 17534 RVA: 0x0008247C File Offset: 0x0008067C
		[ProtoMember(1, Name = "bufflist", DataFormat = DataFormat.Default)]
		public List<GuildHallBuffData> bufflist
		{
			get
			{
				return this._bufflist;
			}
		}

		// Token: 0x170014F2 RID: 5362
		// (get) Token: 0x0600447F RID: 17535 RVA: 0x00082494 File Offset: 0x00080694
		// (set) Token: 0x06004480 RID: 17536 RVA: 0x000824C0 File Offset: 0x000806C0
		[ProtoMember(2, IsRequired = false, Name = "enableUpdate", DataFormat = DataFormat.Default)]
		public bool enableUpdate
		{
			get
			{
				return this._enableUpdate ?? false;
			}
			set
			{
				this._enableUpdate = new bool?(value);
			}
		}

		// Token: 0x170014F3 RID: 5363
		// (get) Token: 0x06004481 RID: 17537 RVA: 0x000824D0 File Offset: 0x000806D0
		// (set) Token: 0x06004482 RID: 17538 RVA: 0x000824F0 File Offset: 0x000806F0
		[XmlIgnore]
		[Browsable(false)]
		public bool enableUpdateSpecified
		{
			get
			{
				return this._enableUpdate != null;
			}
			set
			{
				bool flag = value == (this._enableUpdate == null);
				if (flag)
				{
					this._enableUpdate = (value ? new bool?(this.enableUpdate) : null);
				}
			}
		}

		// Token: 0x06004483 RID: 17539 RVA: 0x00082534 File Offset: 0x00080734
		private bool ShouldSerializeenableUpdate()
		{
			return this.enableUpdateSpecified;
		}

		// Token: 0x06004484 RID: 17540 RVA: 0x0008254C File Offset: 0x0008074C
		private void ResetenableUpdate()
		{
			this.enableUpdateSpecified = false;
		}

		// Token: 0x170014F4 RID: 5364
		// (get) Token: 0x06004485 RID: 17541 RVA: 0x00082558 File Offset: 0x00080758
		// (set) Token: 0x06004486 RID: 17542 RVA: 0x00082584 File Offset: 0x00080784
		[ProtoMember(3, IsRequired = false, Name = "ec", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ec
		{
			get
			{
				return this._ec ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ec = new ErrorCode?(value);
			}
		}

		// Token: 0x170014F5 RID: 5365
		// (get) Token: 0x06004487 RID: 17543 RVA: 0x00082594 File Offset: 0x00080794
		// (set) Token: 0x06004488 RID: 17544 RVA: 0x000825B4 File Offset: 0x000807B4
		[XmlIgnore]
		[Browsable(false)]
		public bool ecSpecified
		{
			get
			{
				return this._ec != null;
			}
			set
			{
				bool flag = value == (this._ec == null);
				if (flag)
				{
					this._ec = (value ? new ErrorCode?(this.ec) : null);
				}
			}
		}

		// Token: 0x06004489 RID: 17545 RVA: 0x000825F8 File Offset: 0x000807F8
		private bool ShouldSerializeec()
		{
			return this.ecSpecified;
		}

		// Token: 0x0600448A RID: 17546 RVA: 0x00082610 File Offset: 0x00080810
		private void Resetec()
		{
			this.ecSpecified = false;
		}

		// Token: 0x0600448B RID: 17547 RVA: 0x0008261C File Offset: 0x0008081C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400111B RID: 4379
		private readonly List<GuildHallBuffData> _bufflist = new List<GuildHallBuffData>();

		// Token: 0x0400111C RID: 4380
		private bool? _enableUpdate;

		// Token: 0x0400111D RID: 4381
		private ErrorCode? _ec;

		// Token: 0x0400111E RID: 4382
		private IExtension extensionObject;
	}
}

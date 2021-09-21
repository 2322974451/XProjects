using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000528 RID: 1320
	[ProtoContract(Name = "GetRiftGuildRankRes")]
	[Serializable]
	public class GetRiftGuildRankRes : IExtensible
	{
		// Token: 0x170014BC RID: 5308
		// (get) Token: 0x060043D8 RID: 17368 RVA: 0x00081120 File Offset: 0x0007F320
		// (set) Token: 0x060043D9 RID: 17369 RVA: 0x0008114C File Offset: 0x0007F34C
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x170014BD RID: 5309
		// (get) Token: 0x060043DA RID: 17370 RVA: 0x0008115C File Offset: 0x0007F35C
		// (set) Token: 0x060043DB RID: 17371 RVA: 0x0008117C File Offset: 0x0007F37C
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x060043DC RID: 17372 RVA: 0x000811C0 File Offset: 0x0007F3C0
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x060043DD RID: 17373 RVA: 0x000811D8 File Offset: 0x0007F3D8
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x170014BE RID: 5310
		// (get) Token: 0x060043DE RID: 17374 RVA: 0x000811E4 File Offset: 0x0007F3E4
		// (set) Token: 0x060043DF RID: 17375 RVA: 0x00081210 File Offset: 0x0007F410
		[ProtoMember(2, IsRequired = false, Name = "curRiftID", DataFormat = DataFormat.TwosComplement)]
		public int curRiftID
		{
			get
			{
				return this._curRiftID ?? 0;
			}
			set
			{
				this._curRiftID = new int?(value);
			}
		}

		// Token: 0x170014BF RID: 5311
		// (get) Token: 0x060043E0 RID: 17376 RVA: 0x00081220 File Offset: 0x0007F420
		// (set) Token: 0x060043E1 RID: 17377 RVA: 0x00081240 File Offset: 0x0007F440
		[XmlIgnore]
		[Browsable(false)]
		public bool curRiftIDSpecified
		{
			get
			{
				return this._curRiftID != null;
			}
			set
			{
				bool flag = value == (this._curRiftID == null);
				if (flag)
				{
					this._curRiftID = (value ? new int?(this.curRiftID) : null);
				}
			}
		}

		// Token: 0x060043E2 RID: 17378 RVA: 0x00081284 File Offset: 0x0007F484
		private bool ShouldSerializecurRiftID()
		{
			return this.curRiftIDSpecified;
		}

		// Token: 0x060043E3 RID: 17379 RVA: 0x0008129C File Offset: 0x0007F49C
		private void ResetcurRiftID()
		{
			this.curRiftIDSpecified = false;
		}

		// Token: 0x170014C0 RID: 5312
		// (get) Token: 0x060043E4 RID: 17380 RVA: 0x000812A8 File Offset: 0x0007F4A8
		[ProtoMember(3, Name = "buffIDs", DataFormat = DataFormat.Default)]
		public List<Buff> buffIDs
		{
			get
			{
				return this._buffIDs;
			}
		}

		// Token: 0x170014C1 RID: 5313
		// (get) Token: 0x060043E5 RID: 17381 RVA: 0x000812C0 File Offset: 0x0007F4C0
		[ProtoMember(4, Name = "infos", DataFormat = DataFormat.Default)]
		public List<RiftGuildRankInfo> infos
		{
			get
			{
				return this._infos;
			}
		}

		// Token: 0x060043E6 RID: 17382 RVA: 0x000812D8 File Offset: 0x0007F4D8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010EA RID: 4330
		private ErrorCode? _error;

		// Token: 0x040010EB RID: 4331
		private int? _curRiftID;

		// Token: 0x040010EC RID: 4332
		private readonly List<Buff> _buffIDs = new List<Buff>();

		// Token: 0x040010ED RID: 4333
		private readonly List<RiftGuildRankInfo> _infos = new List<RiftGuildRankInfo>();

		// Token: 0x040010EE RID: 4334
		private IExtension extensionObject;
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000318 RID: 792
	[ProtoContract(Name = "TakePartnerChestRes")]
	[Serializable]
	public class TakePartnerChestRes : IExtensible
	{
		// Token: 0x17000D72 RID: 3442
		// (get) Token: 0x06002B68 RID: 11112 RVA: 0x00054190 File Offset: 0x00052390
		// (set) Token: 0x06002B69 RID: 11113 RVA: 0x000541BC File Offset: 0x000523BC
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

		// Token: 0x17000D73 RID: 3443
		// (get) Token: 0x06002B6A RID: 11114 RVA: 0x000541CC File Offset: 0x000523CC
		// (set) Token: 0x06002B6B RID: 11115 RVA: 0x000541EC File Offset: 0x000523EC
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

		// Token: 0x06002B6C RID: 11116 RVA: 0x00054230 File Offset: 0x00052430
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002B6D RID: 11117 RVA: 0x00054248 File Offset: 0x00052448
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000D74 RID: 3444
		// (get) Token: 0x06002B6E RID: 11118 RVA: 0x00054254 File Offset: 0x00052454
		[ProtoMember(2, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> itemid
		{
			get
			{
				return this._itemid;
			}
		}

		// Token: 0x17000D75 RID: 3445
		// (get) Token: 0x06002B6F RID: 11119 RVA: 0x0005426C File Offset: 0x0005246C
		[ProtoMember(3, Name = "itemcount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> itemcount
		{
			get
			{
				return this._itemcount;
			}
		}

		// Token: 0x17000D76 RID: 3446
		// (get) Token: 0x06002B70 RID: 11120 RVA: 0x00054284 File Offset: 0x00052484
		// (set) Token: 0x06002B71 RID: 11121 RVA: 0x000542B0 File Offset: 0x000524B0
		[ProtoMember(4, IsRequired = false, Name = "takedchest", DataFormat = DataFormat.TwosComplement)]
		public uint takedchest
		{
			get
			{
				return this._takedchest ?? 0U;
			}
			set
			{
				this._takedchest = new uint?(value);
			}
		}

		// Token: 0x17000D77 RID: 3447
		// (get) Token: 0x06002B72 RID: 11122 RVA: 0x000542C0 File Offset: 0x000524C0
		// (set) Token: 0x06002B73 RID: 11123 RVA: 0x000542E0 File Offset: 0x000524E0
		[XmlIgnore]
		[Browsable(false)]
		public bool takedchestSpecified
		{
			get
			{
				return this._takedchest != null;
			}
			set
			{
				bool flag = value == (this._takedchest == null);
				if (flag)
				{
					this._takedchest = (value ? new uint?(this.takedchest) : null);
				}
			}
		}

		// Token: 0x06002B74 RID: 11124 RVA: 0x00054324 File Offset: 0x00052524
		private bool ShouldSerializetakedchest()
		{
			return this.takedchestSpecified;
		}

		// Token: 0x06002B75 RID: 11125 RVA: 0x0005433C File Offset: 0x0005253C
		private void Resettakedchest()
		{
			this.takedchestSpecified = false;
		}

		// Token: 0x06002B76 RID: 11126 RVA: 0x00054348 File Offset: 0x00052548
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AC2 RID: 2754
		private ErrorCode? _result;

		// Token: 0x04000AC3 RID: 2755
		private readonly List<uint> _itemid = new List<uint>();

		// Token: 0x04000AC4 RID: 2756
		private readonly List<uint> _itemcount = new List<uint>();

		// Token: 0x04000AC5 RID: 2757
		private uint? _takedchest;

		// Token: 0x04000AC6 RID: 2758
		private IExtension extensionObject;
	}
}

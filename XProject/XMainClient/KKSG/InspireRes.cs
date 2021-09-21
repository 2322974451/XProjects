using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200024B RID: 587
	[ProtoContract(Name = "InspireRes")]
	[Serializable]
	public class InspireRes : IExtensible
	{
		// Token: 0x17000A37 RID: 2615
		// (get) Token: 0x060020C2 RID: 8386 RVA: 0x000402AC File Offset: 0x0003E4AC
		// (set) Token: 0x060020C3 RID: 8387 RVA: 0x000402D8 File Offset: 0x0003E4D8
		[ProtoMember(1, IsRequired = false, Name = "ErrorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ErrorCode
		{
			get
			{
				return this._ErrorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ErrorCode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000A38 RID: 2616
		// (get) Token: 0x060020C4 RID: 8388 RVA: 0x000402E8 File Offset: 0x0003E4E8
		// (set) Token: 0x060020C5 RID: 8389 RVA: 0x00040308 File Offset: 0x0003E508
		[XmlIgnore]
		[Browsable(false)]
		public bool ErrorCodeSpecified
		{
			get
			{
				return this._ErrorCode != null;
			}
			set
			{
				bool flag = value == (this._ErrorCode == null);
				if (flag)
				{
					this._ErrorCode = (value ? new ErrorCode?(this.ErrorCode) : null);
				}
			}
		}

		// Token: 0x060020C6 RID: 8390 RVA: 0x0004034C File Offset: 0x0003E54C
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x060020C7 RID: 8391 RVA: 0x00040364 File Offset: 0x0003E564
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x17000A39 RID: 2617
		// (get) Token: 0x060020C8 RID: 8392 RVA: 0x00040370 File Offset: 0x0003E570
		// (set) Token: 0x060020C9 RID: 8393 RVA: 0x0004039C File Offset: 0x0003E59C
		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x17000A3A RID: 2618
		// (get) Token: 0x060020CA RID: 8394 RVA: 0x000403AC File Offset: 0x0003E5AC
		// (set) Token: 0x060020CB RID: 8395 RVA: 0x000403CC File Offset: 0x0003E5CC
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x060020CC RID: 8396 RVA: 0x00040410 File Offset: 0x0003E610
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x060020CD RID: 8397 RVA: 0x00040428 File Offset: 0x0003E628
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x17000A3B RID: 2619
		// (get) Token: 0x060020CE RID: 8398 RVA: 0x00040434 File Offset: 0x0003E634
		// (set) Token: 0x060020CF RID: 8399 RVA: 0x00040460 File Offset: 0x0003E660
		[ProtoMember(3, IsRequired = false, Name = "cooldowntime", DataFormat = DataFormat.TwosComplement)]
		public uint cooldowntime
		{
			get
			{
				return this._cooldowntime ?? 0U;
			}
			set
			{
				this._cooldowntime = new uint?(value);
			}
		}

		// Token: 0x17000A3C RID: 2620
		// (get) Token: 0x060020D0 RID: 8400 RVA: 0x00040470 File Offset: 0x0003E670
		// (set) Token: 0x060020D1 RID: 8401 RVA: 0x00040490 File Offset: 0x0003E690
		[XmlIgnore]
		[Browsable(false)]
		public bool cooldowntimeSpecified
		{
			get
			{
				return this._cooldowntime != null;
			}
			set
			{
				bool flag = value == (this._cooldowntime == null);
				if (flag)
				{
					this._cooldowntime = (value ? new uint?(this.cooldowntime) : null);
				}
			}
		}

		// Token: 0x060020D2 RID: 8402 RVA: 0x000404D4 File Offset: 0x0003E6D4
		private bool ShouldSerializecooldowntime()
		{
			return this.cooldowntimeSpecified;
		}

		// Token: 0x060020D3 RID: 8403 RVA: 0x000404EC File Offset: 0x0003E6EC
		private void Resetcooldowntime()
		{
			this.cooldowntimeSpecified = false;
		}

		// Token: 0x060020D4 RID: 8404 RVA: 0x000404F8 File Offset: 0x0003E6F8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000829 RID: 2089
		private ErrorCode? _ErrorCode;

		// Token: 0x0400082A RID: 2090
		private uint? _count;

		// Token: 0x0400082B RID: 2091
		private uint? _cooldowntime;

		// Token: 0x0400082C RID: 2092
		private IExtension extensionObject;
	}
}

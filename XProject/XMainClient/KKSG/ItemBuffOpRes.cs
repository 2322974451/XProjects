using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002C3 RID: 707
	[ProtoContract(Name = "ItemBuffOpRes")]
	[Serializable]
	public class ItemBuffOpRes : IExtensible
	{
		// Token: 0x17000C2D RID: 3117
		// (get) Token: 0x0600272C RID: 10028 RVA: 0x0004C314 File Offset: 0x0004A514
		// (set) Token: 0x0600272D RID: 10029 RVA: 0x0004C340 File Offset: 0x0004A540
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000C2E RID: 3118
		// (get) Token: 0x0600272E RID: 10030 RVA: 0x0004C350 File Offset: 0x0004A550
		// (set) Token: 0x0600272F RID: 10031 RVA: 0x0004C370 File Offset: 0x0004A570
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06002730 RID: 10032 RVA: 0x0004C3B4 File Offset: 0x0004A5B4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002731 RID: 10033 RVA: 0x0004C3CC File Offset: 0x0004A5CC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000C2F RID: 3119
		// (get) Token: 0x06002732 RID: 10034 RVA: 0x0004C3D8 File Offset: 0x0004A5D8
		[ProtoMember(2, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> itemid
		{
			get
			{
				return this._itemid;
			}
		}

		// Token: 0x17000C30 RID: 3120
		// (get) Token: 0x06002733 RID: 10035 RVA: 0x0004C3F0 File Offset: 0x0004A5F0
		[ProtoMember(3, Name = "itemcount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> itemcount
		{
			get
			{
				return this._itemcount;
			}
		}

		// Token: 0x17000C31 RID: 3121
		// (get) Token: 0x06002734 RID: 10036 RVA: 0x0004C408 File Offset: 0x0004A608
		[ProtoMember(4, Name = "buffid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> buffid
		{
			get
			{
				return this._buffid;
			}
		}

		// Token: 0x17000C32 RID: 3122
		// (get) Token: 0x06002735 RID: 10037 RVA: 0x0004C420 File Offset: 0x0004A620
		[ProtoMember(5, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public List<uint> lefttime
		{
			get
			{
				return this._lefttime;
			}
		}

		// Token: 0x06002736 RID: 10038 RVA: 0x0004C438 File Offset: 0x0004A638
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009BA RID: 2490
		private ErrorCode? _errorcode;

		// Token: 0x040009BB RID: 2491
		private readonly List<uint> _itemid = new List<uint>();

		// Token: 0x040009BC RID: 2492
		private readonly List<uint> _itemcount = new List<uint>();

		// Token: 0x040009BD RID: 2493
		private readonly List<uint> _buffid = new List<uint>();

		// Token: 0x040009BE RID: 2494
		private readonly List<uint> _lefttime = new List<uint>();

		// Token: 0x040009BF RID: 2495
		private IExtension extensionObject;
	}
}

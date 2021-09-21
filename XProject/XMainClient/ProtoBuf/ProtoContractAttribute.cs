using System;

namespace ProtoBuf
{
	// Token: 0x0200084B RID: 2123
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
	public sealed class ProtoContractAttribute : Attribute
	{
		// Token: 0x17002940 RID: 10560
		// (get) Token: 0x06008274 RID: 33396 RVA: 0x000FA8A0 File Offset: 0x000F8AA0
		// (set) Token: 0x06008275 RID: 33397 RVA: 0x000FA8B8 File Offset: 0x000F8AB8
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x17002941 RID: 10561
		// (get) Token: 0x06008276 RID: 33398 RVA: 0x000FA8C4 File Offset: 0x000F8AC4
		// (set) Token: 0x06008277 RID: 33399 RVA: 0x000FA8DC File Offset: 0x000F8ADC
		public int ImplicitFirstTag
		{
			get
			{
				return this.implicitFirstTag;
			}
			set
			{
				bool flag = value < 1;
				if (flag)
				{
					throw new ArgumentOutOfRangeException("ImplicitFirstTag");
				}
				this.implicitFirstTag = value;
			}
		}

		// Token: 0x17002942 RID: 10562
		// (get) Token: 0x06008278 RID: 33400 RVA: 0x000FA904 File Offset: 0x000F8B04
		// (set) Token: 0x06008279 RID: 33401 RVA: 0x000FA91D File Offset: 0x000F8B1D
		public bool UseProtoMembersOnly
		{
			get
			{
				return this.HasFlag(4);
			}
			set
			{
				this.SetFlag(4, value);
			}
		}

		// Token: 0x17002943 RID: 10563
		// (get) Token: 0x0600827A RID: 33402 RVA: 0x000FA92C File Offset: 0x000F8B2C
		// (set) Token: 0x0600827B RID: 33403 RVA: 0x000FA946 File Offset: 0x000F8B46
		public bool IgnoreListHandling
		{
			get
			{
				return this.HasFlag(16);
			}
			set
			{
				this.SetFlag(16, value);
			}
		}

		// Token: 0x17002944 RID: 10564
		// (get) Token: 0x0600827C RID: 33404 RVA: 0x000FA954 File Offset: 0x000F8B54
		// (set) Token: 0x0600827D RID: 33405 RVA: 0x000FA96C File Offset: 0x000F8B6C
		public ImplicitFields ImplicitFields
		{
			get
			{
				return this.implicitFields;
			}
			set
			{
				this.implicitFields = value;
			}
		}

		// Token: 0x17002945 RID: 10565
		// (get) Token: 0x0600827E RID: 33406 RVA: 0x000FA978 File Offset: 0x000F8B78
		// (set) Token: 0x0600827F RID: 33407 RVA: 0x000FA991 File Offset: 0x000F8B91
		public bool InferTagFromName
		{
			get
			{
				return this.HasFlag(1);
			}
			set
			{
				this.SetFlag(1, value);
				this.SetFlag(2, true);
			}
		}

		// Token: 0x17002946 RID: 10566
		// (get) Token: 0x06008280 RID: 33408 RVA: 0x000FA9A8 File Offset: 0x000F8BA8
		internal bool InferTagFromNameHasValue
		{
			get
			{
				return this.HasFlag(2);
			}
		}

		// Token: 0x17002947 RID: 10567
		// (get) Token: 0x06008281 RID: 33409 RVA: 0x000FA9C4 File Offset: 0x000F8BC4
		// (set) Token: 0x06008282 RID: 33410 RVA: 0x000FA9DC File Offset: 0x000F8BDC
		public int DataMemberOffset
		{
			get
			{
				return this.dataMemberOffset;
			}
			set
			{
				this.dataMemberOffset = value;
			}
		}

		// Token: 0x17002948 RID: 10568
		// (get) Token: 0x06008283 RID: 33411 RVA: 0x000FA9E8 File Offset: 0x000F8BE8
		// (set) Token: 0x06008284 RID: 33412 RVA: 0x000FAA01 File Offset: 0x000F8C01
		public bool SkipConstructor
		{
			get
			{
				return this.HasFlag(8);
			}
			set
			{
				this.SetFlag(8, value);
			}
		}

		// Token: 0x17002949 RID: 10569
		// (get) Token: 0x06008285 RID: 33413 RVA: 0x000FAA10 File Offset: 0x000F8C10
		// (set) Token: 0x06008286 RID: 33414 RVA: 0x000FAA2A File Offset: 0x000F8C2A
		public bool AsReferenceDefault
		{
			get
			{
				return this.HasFlag(32);
			}
			set
			{
				this.SetFlag(32, value);
			}
		}

		// Token: 0x06008287 RID: 33415 RVA: 0x000FAA38 File Offset: 0x000F8C38
		private bool HasFlag(byte flag)
		{
			return (this.flags & flag) == flag;
		}

		// Token: 0x06008288 RID: 33416 RVA: 0x000FAA58 File Offset: 0x000F8C58
		private void SetFlag(byte flag, bool value)
		{
			if (value)
			{
				this.flags |= flag;
			}
			else
			{
				this.flags &= (byte)~flag;
			}
		}

		// Token: 0x1700294A RID: 10570
		// (get) Token: 0x06008289 RID: 33417 RVA: 0x000FAA8C File Offset: 0x000F8C8C
		// (set) Token: 0x0600828A RID: 33418 RVA: 0x000FAAA6 File Offset: 0x000F8CA6
		public bool EnumPassthru
		{
			get
			{
				return this.HasFlag(64);
			}
			set
			{
				this.SetFlag(64, value);
				this.SetFlag(128, true);
			}
		}

		// Token: 0x1700294B RID: 10571
		// (get) Token: 0x0600828B RID: 33419 RVA: 0x000FAAC0 File Offset: 0x000F8CC0
		internal bool EnumPassthruHasValue
		{
			get
			{
				return this.HasFlag(128);
			}
		}

		// Token: 0x04002878 RID: 10360
		private string name;

		// Token: 0x04002879 RID: 10361
		private int implicitFirstTag;

		// Token: 0x0400287A RID: 10362
		private ImplicitFields implicitFields;

		// Token: 0x0400287B RID: 10363
		private int dataMemberOffset;

		// Token: 0x0400287C RID: 10364
		private byte flags;

		// Token: 0x0400287D RID: 10365
		private const byte OPTIONS_InferTagFromName = 1;

		// Token: 0x0400287E RID: 10366
		private const byte OPTIONS_InferTagFromNameHasValue = 2;

		// Token: 0x0400287F RID: 10367
		private const byte OPTIONS_UseProtoMembersOnly = 4;

		// Token: 0x04002880 RID: 10368
		private const byte OPTIONS_SkipConstructor = 8;

		// Token: 0x04002881 RID: 10369
		private const byte OPTIONS_IgnoreListHandling = 16;

		// Token: 0x04002882 RID: 10370
		private const byte OPTIONS_AsReferenceDefault = 32;

		// Token: 0x04002883 RID: 10371
		private const byte OPTIONS_EnumPassthru = 64;

		// Token: 0x04002884 RID: 10372
		private const byte OPTIONS_EnumPassthruHasValue = 128;
	}
}

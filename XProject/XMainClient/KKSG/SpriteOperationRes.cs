using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000201 RID: 513
	[ProtoContract(Name = "SpriteOperationRes")]
	[Serializable]
	public class SpriteOperationRes : IExtensible
	{
		// Token: 0x1700091C RID: 2332
		// (get) Token: 0x06001D18 RID: 7448 RVA: 0x000394C8 File Offset: 0x000376C8
		// (set) Token: 0x06001D19 RID: 7449 RVA: 0x000394F4 File Offset: 0x000376F4
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

		// Token: 0x1700091D RID: 2333
		// (get) Token: 0x06001D1A RID: 7450 RVA: 0x00039504 File Offset: 0x00037704
		// (set) Token: 0x06001D1B RID: 7451 RVA: 0x00039524 File Offset: 0x00037724
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

		// Token: 0x06001D1C RID: 7452 RVA: 0x00039568 File Offset: 0x00037768
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x06001D1D RID: 7453 RVA: 0x00039580 File Offset: 0x00037780
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x1700091E RID: 2334
		// (get) Token: 0x06001D1E RID: 7454 RVA: 0x0003958C File Offset: 0x0003778C
		// (set) Token: 0x06001D1F RID: 7455 RVA: 0x000395B8 File Offset: 0x000377B8
		[ProtoMember(2, IsRequired = false, Name = "Exp", DataFormat = DataFormat.TwosComplement)]
		public uint Exp
		{
			get
			{
				return this._Exp ?? 0U;
			}
			set
			{
				this._Exp = new uint?(value);
			}
		}

		// Token: 0x1700091F RID: 2335
		// (get) Token: 0x06001D20 RID: 7456 RVA: 0x000395C8 File Offset: 0x000377C8
		// (set) Token: 0x06001D21 RID: 7457 RVA: 0x000395E8 File Offset: 0x000377E8
		[XmlIgnore]
		[Browsable(false)]
		public bool ExpSpecified
		{
			get
			{
				return this._Exp != null;
			}
			set
			{
				bool flag = value == (this._Exp == null);
				if (flag)
				{
					this._Exp = (value ? new uint?(this.Exp) : null);
				}
			}
		}

		// Token: 0x06001D22 RID: 7458 RVA: 0x0003962C File Offset: 0x0003782C
		private bool ShouldSerializeExp()
		{
			return this.ExpSpecified;
		}

		// Token: 0x06001D23 RID: 7459 RVA: 0x00039644 File Offset: 0x00037844
		private void ResetExp()
		{
			this.ExpSpecified = false;
		}

		// Token: 0x17000920 RID: 2336
		// (get) Token: 0x06001D24 RID: 7460 RVA: 0x00039650 File Offset: 0x00037850
		// (set) Token: 0x06001D25 RID: 7461 RVA: 0x00039668 File Offset: 0x00037868
		[ProtoMember(3, IsRequired = false, Name = "AwakeSpriteBefore", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SpriteInfo AwakeSpriteBefore
		{
			get
			{
				return this._AwakeSpriteBefore;
			}
			set
			{
				this._AwakeSpriteBefore = value;
			}
		}

		// Token: 0x17000921 RID: 2337
		// (get) Token: 0x06001D26 RID: 7462 RVA: 0x00039674 File Offset: 0x00037874
		// (set) Token: 0x06001D27 RID: 7463 RVA: 0x0003968C File Offset: 0x0003788C
		[ProtoMember(4, IsRequired = false, Name = "AwakeSprite", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SpriteInfo AwakeSprite
		{
			get
			{
				return this._AwakeSprite;
			}
			set
			{
				this._AwakeSprite = value;
			}
		}

		// Token: 0x17000922 RID: 2338
		// (get) Token: 0x06001D28 RID: 7464 RVA: 0x00039698 File Offset: 0x00037898
		[ProtoMember(5, Name = "InFight", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> InFight
		{
			get
			{
				return this._InFight;
			}
		}

		// Token: 0x17000923 RID: 2339
		// (get) Token: 0x06001D29 RID: 7465 RVA: 0x000396B0 File Offset: 0x000378B0
		[ProtoMember(6, Name = "LastTrainAttrID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> LastTrainAttrID
		{
			get
			{
				return this._LastTrainAttrID;
			}
		}

		// Token: 0x17000924 RID: 2340
		// (get) Token: 0x06001D2A RID: 7466 RVA: 0x000396C8 File Offset: 0x000378C8
		[ProtoMember(7, Name = "LastTrainAttrValue", DataFormat = DataFormat.TwosComplement)]
		public List<uint> LastTrainAttrValue
		{
			get
			{
				return this._LastTrainAttrValue;
			}
		}

		// Token: 0x06001D2B RID: 7467 RVA: 0x000396E0 File Offset: 0x000378E0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000741 RID: 1857
		private ErrorCode? _ErrorCode;

		// Token: 0x04000742 RID: 1858
		private uint? _Exp;

		// Token: 0x04000743 RID: 1859
		private SpriteInfo _AwakeSpriteBefore = null;

		// Token: 0x04000744 RID: 1860
		private SpriteInfo _AwakeSprite = null;

		// Token: 0x04000745 RID: 1861
		private readonly List<ulong> _InFight = new List<ulong>();

		// Token: 0x04000746 RID: 1862
		private readonly List<uint> _LastTrainAttrID = new List<uint>();

		// Token: 0x04000747 RID: 1863
		private readonly List<uint> _LastTrainAttrValue = new List<uint>();

		// Token: 0x04000748 RID: 1864
		private IExtension extensionObject;
	}
}

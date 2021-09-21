using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000186 RID: 390
	[ProtoContract(Name = "BossRushRes")]
	[Serializable]
	public class BossRushRes : IExtensible
	{
		// Token: 0x1700076D RID: 1901
		// (get) Token: 0x0600177E RID: 6014 RVA: 0x0002EF18 File Offset: 0x0002D118
		// (set) Token: 0x0600177F RID: 6015 RVA: 0x0002EF44 File Offset: 0x0002D144
		[ProtoMember(1, IsRequired = false, Name = "ret", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ret
		{
			get
			{
				return this._ret ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ret = new ErrorCode?(value);
			}
		}

		// Token: 0x1700076E RID: 1902
		// (get) Token: 0x06001780 RID: 6016 RVA: 0x0002EF54 File Offset: 0x0002D154
		// (set) Token: 0x06001781 RID: 6017 RVA: 0x0002EF74 File Offset: 0x0002D174
		[XmlIgnore]
		[Browsable(false)]
		public bool retSpecified
		{
			get
			{
				return this._ret != null;
			}
			set
			{
				bool flag = value == (this._ret == null);
				if (flag)
				{
					this._ret = (value ? new ErrorCode?(this.ret) : null);
				}
			}
		}

		// Token: 0x06001782 RID: 6018 RVA: 0x0002EFB8 File Offset: 0x0002D1B8
		private bool ShouldSerializeret()
		{
			return this.retSpecified;
		}

		// Token: 0x06001783 RID: 6019 RVA: 0x0002EFD0 File Offset: 0x0002D1D0
		private void Resetret()
		{
			this.retSpecified = false;
		}

		// Token: 0x1700076F RID: 1903
		// (get) Token: 0x06001784 RID: 6020 RVA: 0x0002EFDC File Offset: 0x0002D1DC
		// (set) Token: 0x06001785 RID: 6021 RVA: 0x0002EFF4 File Offset: 0x0002D1F4
		[ProtoMember(2, IsRequired = false, Name = "data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BossRushData data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}

		// Token: 0x17000770 RID: 1904
		// (get) Token: 0x06001786 RID: 6022 RVA: 0x0002F000 File Offset: 0x0002D200
		// (set) Token: 0x06001787 RID: 6023 RVA: 0x0002F018 File Offset: 0x0002D218
		[ProtoMember(3, IsRequired = false, Name = "bossApp", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public UnitAppearance bossApp
		{
			get
			{
				return this._bossApp;
			}
			set
			{
				this._bossApp = value;
			}
		}

		// Token: 0x17000771 RID: 1905
		// (get) Token: 0x06001788 RID: 6024 RVA: 0x0002F024 File Offset: 0x0002D224
		// (set) Token: 0x06001789 RID: 6025 RVA: 0x0002F050 File Offset: 0x0002D250
		[ProtoMember(4, IsRequired = false, Name = "leftcount", DataFormat = DataFormat.TwosComplement)]
		public int leftcount
		{
			get
			{
				return this._leftcount ?? 0;
			}
			set
			{
				this._leftcount = new int?(value);
			}
		}

		// Token: 0x17000772 RID: 1906
		// (get) Token: 0x0600178A RID: 6026 RVA: 0x0002F060 File Offset: 0x0002D260
		// (set) Token: 0x0600178B RID: 6027 RVA: 0x0002F080 File Offset: 0x0002D280
		[XmlIgnore]
		[Browsable(false)]
		public bool leftcountSpecified
		{
			get
			{
				return this._leftcount != null;
			}
			set
			{
				bool flag = value == (this._leftcount == null);
				if (flag)
				{
					this._leftcount = (value ? new int?(this.leftcount) : null);
				}
			}
		}

		// Token: 0x0600178C RID: 6028 RVA: 0x0002F0C4 File Offset: 0x0002D2C4
		private bool ShouldSerializeleftcount()
		{
			return this.leftcountSpecified;
		}

		// Token: 0x0600178D RID: 6029 RVA: 0x0002F0DC File Offset: 0x0002D2DC
		private void Resetleftcount()
		{
			this.leftcountSpecified = false;
		}

		// Token: 0x0600178E RID: 6030 RVA: 0x0002F0E8 File Offset: 0x0002D2E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005CE RID: 1486
		private ErrorCode? _ret;

		// Token: 0x040005CF RID: 1487
		private BossRushData _data = null;

		// Token: 0x040005D0 RID: 1488
		private UnitAppearance _bossApp = null;

		// Token: 0x040005D1 RID: 1489
		private int? _leftcount;

		// Token: 0x040005D2 RID: 1490
		private IExtension extensionObject;
	}
}

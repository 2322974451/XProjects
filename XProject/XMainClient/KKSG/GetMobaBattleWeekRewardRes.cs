using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000446 RID: 1094
	[ProtoContract(Name = "GetMobaBattleWeekRewardRes")]
	[Serializable]
	public class GetMobaBattleWeekRewardRes : IExtensible
	{
		// Token: 0x170011AF RID: 4527
		// (get) Token: 0x060039A3 RID: 14755 RVA: 0x0006E3F4 File Offset: 0x0006C5F4
		// (set) Token: 0x060039A4 RID: 14756 RVA: 0x0006E420 File Offset: 0x0006C620
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

		// Token: 0x170011B0 RID: 4528
		// (get) Token: 0x060039A5 RID: 14757 RVA: 0x0006E430 File Offset: 0x0006C630
		// (set) Token: 0x060039A6 RID: 14758 RVA: 0x0006E450 File Offset: 0x0006C650
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

		// Token: 0x060039A7 RID: 14759 RVA: 0x0006E494 File Offset: 0x0006C694
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060039A8 RID: 14760 RVA: 0x0006E4AC File Offset: 0x0006C6AC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170011B1 RID: 4529
		// (get) Token: 0x060039A9 RID: 14761 RVA: 0x0006E4B8 File Offset: 0x0006C6B8
		// (set) Token: 0x060039AA RID: 14762 RVA: 0x0006E4E4 File Offset: 0x0006C6E4
		[ProtoMember(2, IsRequired = false, Name = "weekprize", DataFormat = DataFormat.TwosComplement)]
		public uint weekprize
		{
			get
			{
				return this._weekprize ?? 0U;
			}
			set
			{
				this._weekprize = new uint?(value);
			}
		}

		// Token: 0x170011B2 RID: 4530
		// (get) Token: 0x060039AB RID: 14763 RVA: 0x0006E4F4 File Offset: 0x0006C6F4
		// (set) Token: 0x060039AC RID: 14764 RVA: 0x0006E514 File Offset: 0x0006C714
		[XmlIgnore]
		[Browsable(false)]
		public bool weekprizeSpecified
		{
			get
			{
				return this._weekprize != null;
			}
			set
			{
				bool flag = value == (this._weekprize == null);
				if (flag)
				{
					this._weekprize = (value ? new uint?(this.weekprize) : null);
				}
			}
		}

		// Token: 0x060039AD RID: 14765 RVA: 0x0006E558 File Offset: 0x0006C758
		private bool ShouldSerializeweekprize()
		{
			return this.weekprizeSpecified;
		}

		// Token: 0x060039AE RID: 14766 RVA: 0x0006E570 File Offset: 0x0006C770
		private void Resetweekprize()
		{
			this.weekprizeSpecified = false;
		}

		// Token: 0x170011B3 RID: 4531
		// (get) Token: 0x060039AF RID: 14767 RVA: 0x0006E57C File Offset: 0x0006C77C
		// (set) Token: 0x060039B0 RID: 14768 RVA: 0x0006E5A8 File Offset: 0x0006C7A8
		[ProtoMember(3, IsRequired = false, Name = "getnextweekprize", DataFormat = DataFormat.Default)]
		public bool getnextweekprize
		{
			get
			{
				return this._getnextweekprize ?? false;
			}
			set
			{
				this._getnextweekprize = new bool?(value);
			}
		}

		// Token: 0x170011B4 RID: 4532
		// (get) Token: 0x060039B1 RID: 14769 RVA: 0x0006E5B8 File Offset: 0x0006C7B8
		// (set) Token: 0x060039B2 RID: 14770 RVA: 0x0006E5D8 File Offset: 0x0006C7D8
		[XmlIgnore]
		[Browsable(false)]
		public bool getnextweekprizeSpecified
		{
			get
			{
				return this._getnextweekprize != null;
			}
			set
			{
				bool flag = value == (this._getnextweekprize == null);
				if (flag)
				{
					this._getnextweekprize = (value ? new bool?(this.getnextweekprize) : null);
				}
			}
		}

		// Token: 0x060039B3 RID: 14771 RVA: 0x0006E61C File Offset: 0x0006C81C
		private bool ShouldSerializegetnextweekprize()
		{
			return this.getnextweekprizeSpecified;
		}

		// Token: 0x060039B4 RID: 14772 RVA: 0x0006E634 File Offset: 0x0006C834
		private void Resetgetnextweekprize()
		{
			this.getnextweekprizeSpecified = false;
		}

		// Token: 0x060039B5 RID: 14773 RVA: 0x0006E640 File Offset: 0x0006C840
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E4E RID: 3662
		private ErrorCode? _errorcode;

		// Token: 0x04000E4F RID: 3663
		private uint? _weekprize;

		// Token: 0x04000E50 RID: 3664
		private bool? _getnextweekprize;

		// Token: 0x04000E51 RID: 3665
		private IExtension extensionObject;
	}
}

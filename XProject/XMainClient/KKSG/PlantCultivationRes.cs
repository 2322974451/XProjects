using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000259 RID: 601
	[ProtoContract(Name = "PlantCultivationRes")]
	[Serializable]
	public class PlantCultivationRes : IExtensible
	{
		// Token: 0x17000A7A RID: 2682
		// (get) Token: 0x0600219F RID: 8607 RVA: 0x00041CB4 File Offset: 0x0003FEB4
		// (set) Token: 0x060021A0 RID: 8608 RVA: 0x00041CE0 File Offset: 0x0003FEE0
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

		// Token: 0x17000A7B RID: 2683
		// (get) Token: 0x060021A1 RID: 8609 RVA: 0x00041CF0 File Offset: 0x0003FEF0
		// (set) Token: 0x060021A2 RID: 8610 RVA: 0x00041D10 File Offset: 0x0003FF10
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

		// Token: 0x060021A3 RID: 8611 RVA: 0x00041D54 File Offset: 0x0003FF54
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060021A4 RID: 8612 RVA: 0x00041D6C File Offset: 0x0003FF6C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000A7C RID: 2684
		// (get) Token: 0x060021A5 RID: 8613 RVA: 0x00041D78 File Offset: 0x0003FF78
		// (set) Token: 0x060021A6 RID: 8614 RVA: 0x00041DA8 File Offset: 0x0003FFA8
		[ProtoMember(2, IsRequired = false, Name = "growup_amount", DataFormat = DataFormat.FixedSize)]
		public float growup_amount
		{
			get
			{
				return this._growup_amount ?? 0f;
			}
			set
			{
				this._growup_amount = new float?(value);
			}
		}

		// Token: 0x17000A7D RID: 2685
		// (get) Token: 0x060021A7 RID: 8615 RVA: 0x00041DB8 File Offset: 0x0003FFB8
		// (set) Token: 0x060021A8 RID: 8616 RVA: 0x00041DD8 File Offset: 0x0003FFD8
		[XmlIgnore]
		[Browsable(false)]
		public bool growup_amountSpecified
		{
			get
			{
				return this._growup_amount != null;
			}
			set
			{
				bool flag = value == (this._growup_amount == null);
				if (flag)
				{
					this._growup_amount = (value ? new float?(this.growup_amount) : null);
				}
			}
		}

		// Token: 0x060021A9 RID: 8617 RVA: 0x00041E1C File Offset: 0x0004001C
		private bool ShouldSerializegrowup_amount()
		{
			return this.growup_amountSpecified;
		}

		// Token: 0x060021AA RID: 8618 RVA: 0x00041E34 File Offset: 0x00040034
		private void Resetgrowup_amount()
		{
			this.growup_amountSpecified = false;
		}

		// Token: 0x17000A7E RID: 2686
		// (get) Token: 0x060021AB RID: 8619 RVA: 0x00041E40 File Offset: 0x00040040
		// (set) Token: 0x060021AC RID: 8620 RVA: 0x00041E6C File Offset: 0x0004006C
		[ProtoMember(3, IsRequired = false, Name = "notice_times", DataFormat = DataFormat.TwosComplement)]
		public uint notice_times
		{
			get
			{
				return this._notice_times ?? 0U;
			}
			set
			{
				this._notice_times = new uint?(value);
			}
		}

		// Token: 0x17000A7F RID: 2687
		// (get) Token: 0x060021AD RID: 8621 RVA: 0x00041E7C File Offset: 0x0004007C
		// (set) Token: 0x060021AE RID: 8622 RVA: 0x00041E9C File Offset: 0x0004009C
		[XmlIgnore]
		[Browsable(false)]
		public bool notice_timesSpecified
		{
			get
			{
				return this._notice_times != null;
			}
			set
			{
				bool flag = value == (this._notice_times == null);
				if (flag)
				{
					this._notice_times = (value ? new uint?(this.notice_times) : null);
				}
			}
		}

		// Token: 0x060021AF RID: 8623 RVA: 0x00041EE0 File Offset: 0x000400E0
		private bool ShouldSerializenotice_times()
		{
			return this.notice_timesSpecified;
		}

		// Token: 0x060021B0 RID: 8624 RVA: 0x00041EF8 File Offset: 0x000400F8
		private void Resetnotice_times()
		{
			this.notice_timesSpecified = false;
		}

		// Token: 0x060021B1 RID: 8625 RVA: 0x00041F04 File Offset: 0x00040104
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400085B RID: 2139
		private ErrorCode? _result;

		// Token: 0x0400085C RID: 2140
		private float? _growup_amount;

		// Token: 0x0400085D RID: 2141
		private uint? _notice_times;

		// Token: 0x0400085E RID: 2142
		private IExtension extensionObject;
	}
}

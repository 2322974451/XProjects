using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000492 RID: 1170
	[ProtoContract(Name = "GetMarriageLivenessRes")]
	[Serializable]
	public class GetMarriageLivenessRes : IExtensible
	{
		// Token: 0x170012AC RID: 4780
		// (get) Token: 0x06003CEB RID: 15595 RVA: 0x000744B4 File Offset: 0x000726B4
		// (set) Token: 0x06003CEC RID: 15596 RVA: 0x000744E0 File Offset: 0x000726E0
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

		// Token: 0x170012AD RID: 4781
		// (get) Token: 0x06003CED RID: 15597 RVA: 0x000744F0 File Offset: 0x000726F0
		// (set) Token: 0x06003CEE RID: 15598 RVA: 0x00074510 File Offset: 0x00072710
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

		// Token: 0x06003CEF RID: 15599 RVA: 0x00074554 File Offset: 0x00072754
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003CF0 RID: 15600 RVA: 0x0007456C File Offset: 0x0007276C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x170012AE RID: 4782
		// (get) Token: 0x06003CF1 RID: 15601 RVA: 0x00074578 File Offset: 0x00072778
		// (set) Token: 0x06003CF2 RID: 15602 RVA: 0x000745A4 File Offset: 0x000727A4
		[ProtoMember(2, IsRequired = false, Name = "liveness", DataFormat = DataFormat.TwosComplement)]
		public uint liveness
		{
			get
			{
				return this._liveness ?? 0U;
			}
			set
			{
				this._liveness = new uint?(value);
			}
		}

		// Token: 0x170012AF RID: 4783
		// (get) Token: 0x06003CF3 RID: 15603 RVA: 0x000745B4 File Offset: 0x000727B4
		// (set) Token: 0x06003CF4 RID: 15604 RVA: 0x000745D4 File Offset: 0x000727D4
		[XmlIgnore]
		[Browsable(false)]
		public bool livenessSpecified
		{
			get
			{
				return this._liveness != null;
			}
			set
			{
				bool flag = value == (this._liveness == null);
				if (flag)
				{
					this._liveness = (value ? new uint?(this.liveness) : null);
				}
			}
		}

		// Token: 0x06003CF5 RID: 15605 RVA: 0x00074618 File Offset: 0x00072818
		private bool ShouldSerializeliveness()
		{
			return this.livenessSpecified;
		}

		// Token: 0x06003CF6 RID: 15606 RVA: 0x00074630 File Offset: 0x00072830
		private void Resetliveness()
		{
			this.livenessSpecified = false;
		}

		// Token: 0x170012B0 RID: 4784
		// (get) Token: 0x06003CF7 RID: 15607 RVA: 0x0007463C File Offset: 0x0007283C
		// (set) Token: 0x06003CF8 RID: 15608 RVA: 0x00074668 File Offset: 0x00072868
		[ProtoMember(3, IsRequired = false, Name = "takedchest", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170012B1 RID: 4785
		// (get) Token: 0x06003CF9 RID: 15609 RVA: 0x00074678 File Offset: 0x00072878
		// (set) Token: 0x06003CFA RID: 15610 RVA: 0x00074698 File Offset: 0x00072898
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

		// Token: 0x06003CFB RID: 15611 RVA: 0x000746DC File Offset: 0x000728DC
		private bool ShouldSerializetakedchest()
		{
			return this.takedchestSpecified;
		}

		// Token: 0x06003CFC RID: 15612 RVA: 0x000746F4 File Offset: 0x000728F4
		private void Resettakedchest()
		{
			this.takedchestSpecified = false;
		}

		// Token: 0x170012B2 RID: 4786
		// (get) Token: 0x06003CFD RID: 15613 RVA: 0x00074700 File Offset: 0x00072900
		[ProtoMember(4, Name = "record", DataFormat = DataFormat.Default)]
		public List<PartnerLivenessItem> record
		{
			get
			{
				return this._record;
			}
		}

		// Token: 0x06003CFE RID: 15614 RVA: 0x00074718 File Offset: 0x00072918
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F2D RID: 3885
		private ErrorCode? _result;

		// Token: 0x04000F2E RID: 3886
		private uint? _liveness;

		// Token: 0x04000F2F RID: 3887
		private uint? _takedchest;

		// Token: 0x04000F30 RID: 3888
		private readonly List<PartnerLivenessItem> _record = new List<PartnerLivenessItem>();

		// Token: 0x04000F31 RID: 3889
		private IExtension extensionObject;
	}
}

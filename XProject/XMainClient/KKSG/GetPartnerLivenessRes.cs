using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200031C RID: 796
	[ProtoContract(Name = "GetPartnerLivenessRes")]
	[Serializable]
	public class GetPartnerLivenessRes : IExtensible
	{
		// Token: 0x17000D85 RID: 3461
		// (get) Token: 0x06002BA3 RID: 11171 RVA: 0x000548A0 File Offset: 0x00052AA0
		// (set) Token: 0x06002BA4 RID: 11172 RVA: 0x000548CC File Offset: 0x00052ACC
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

		// Token: 0x17000D86 RID: 3462
		// (get) Token: 0x06002BA5 RID: 11173 RVA: 0x000548DC File Offset: 0x00052ADC
		// (set) Token: 0x06002BA6 RID: 11174 RVA: 0x000548FC File Offset: 0x00052AFC
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

		// Token: 0x06002BA7 RID: 11175 RVA: 0x00054940 File Offset: 0x00052B40
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002BA8 RID: 11176 RVA: 0x00054958 File Offset: 0x00052B58
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000D87 RID: 3463
		// (get) Token: 0x06002BA9 RID: 11177 RVA: 0x00054964 File Offset: 0x00052B64
		// (set) Token: 0x06002BAA RID: 11178 RVA: 0x00054990 File Offset: 0x00052B90
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

		// Token: 0x17000D88 RID: 3464
		// (get) Token: 0x06002BAB RID: 11179 RVA: 0x000549A0 File Offset: 0x00052BA0
		// (set) Token: 0x06002BAC RID: 11180 RVA: 0x000549C0 File Offset: 0x00052BC0
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

		// Token: 0x06002BAD RID: 11181 RVA: 0x00054A04 File Offset: 0x00052C04
		private bool ShouldSerializeliveness()
		{
			return this.livenessSpecified;
		}

		// Token: 0x06002BAE RID: 11182 RVA: 0x00054A1C File Offset: 0x00052C1C
		private void Resetliveness()
		{
			this.livenessSpecified = false;
		}

		// Token: 0x17000D89 RID: 3465
		// (get) Token: 0x06002BAF RID: 11183 RVA: 0x00054A28 File Offset: 0x00052C28
		// (set) Token: 0x06002BB0 RID: 11184 RVA: 0x00054A54 File Offset: 0x00052C54
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

		// Token: 0x17000D8A RID: 3466
		// (get) Token: 0x06002BB1 RID: 11185 RVA: 0x00054A64 File Offset: 0x00052C64
		// (set) Token: 0x06002BB2 RID: 11186 RVA: 0x00054A84 File Offset: 0x00052C84
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

		// Token: 0x06002BB3 RID: 11187 RVA: 0x00054AC8 File Offset: 0x00052CC8
		private bool ShouldSerializetakedchest()
		{
			return this.takedchestSpecified;
		}

		// Token: 0x06002BB4 RID: 11188 RVA: 0x00054AE0 File Offset: 0x00052CE0
		private void Resettakedchest()
		{
			this.takedchestSpecified = false;
		}

		// Token: 0x17000D8B RID: 3467
		// (get) Token: 0x06002BB5 RID: 11189 RVA: 0x00054AEC File Offset: 0x00052CEC
		[ProtoMember(4, Name = "record", DataFormat = DataFormat.Default)]
		public List<PartnerLivenessItem> record
		{
			get
			{
				return this._record;
			}
		}

		// Token: 0x06002BB6 RID: 11190 RVA: 0x00054B04 File Offset: 0x00052D04
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AD1 RID: 2769
		private ErrorCode? _result;

		// Token: 0x04000AD2 RID: 2770
		private uint? _liveness;

		// Token: 0x04000AD3 RID: 2771
		private uint? _takedchest;

		// Token: 0x04000AD4 RID: 2772
		private readonly List<PartnerLivenessItem> _record = new List<PartnerLivenessItem>();

		// Token: 0x04000AD5 RID: 2773
		private IExtension extensionObject;
	}
}

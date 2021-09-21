using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000502 RID: 1282
	[ProtoContract(Name = "SurviveReqRes")]
	[Serializable]
	public class SurviveReqRes : IExtensible
	{
		// Token: 0x17001441 RID: 5185
		// (get) Token: 0x0600422E RID: 16942 RVA: 0x0007DFC4 File Offset: 0x0007C1C4
		// (set) Token: 0x0600422F RID: 16943 RVA: 0x0007DFF0 File Offset: 0x0007C1F0
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

		// Token: 0x17001442 RID: 5186
		// (get) Token: 0x06004230 RID: 16944 RVA: 0x0007E000 File Offset: 0x0007C200
		// (set) Token: 0x06004231 RID: 16945 RVA: 0x0007E020 File Offset: 0x0007C220
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

		// Token: 0x06004232 RID: 16946 RVA: 0x0007E064 File Offset: 0x0007C264
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06004233 RID: 16947 RVA: 0x0007E07C File Offset: 0x0007C27C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17001443 RID: 5187
		// (get) Token: 0x06004234 RID: 16948 RVA: 0x0007E088 File Offset: 0x0007C288
		// (set) Token: 0x06004235 RID: 16949 RVA: 0x0007E0B4 File Offset: 0x0007C2B4
		[ProtoMember(2, IsRequired = false, Name = "givereward", DataFormat = DataFormat.Default)]
		public bool givereward
		{
			get
			{
				return this._givereward ?? false;
			}
			set
			{
				this._givereward = new bool?(value);
			}
		}

		// Token: 0x17001444 RID: 5188
		// (get) Token: 0x06004236 RID: 16950 RVA: 0x0007E0C4 File Offset: 0x0007C2C4
		// (set) Token: 0x06004237 RID: 16951 RVA: 0x0007E0E4 File Offset: 0x0007C2E4
		[XmlIgnore]
		[Browsable(false)]
		public bool giverewardSpecified
		{
			get
			{
				return this._givereward != null;
			}
			set
			{
				bool flag = value == (this._givereward == null);
				if (flag)
				{
					this._givereward = (value ? new bool?(this.givereward) : null);
				}
			}
		}

		// Token: 0x06004238 RID: 16952 RVA: 0x0007E128 File Offset: 0x0007C328
		private bool ShouldSerializegivereward()
		{
			return this.giverewardSpecified;
		}

		// Token: 0x06004239 RID: 16953 RVA: 0x0007E140 File Offset: 0x0007C340
		private void Resetgivereward()
		{
			this.giverewardSpecified = false;
		}

		// Token: 0x17001445 RID: 5189
		// (get) Token: 0x0600423A RID: 16954 RVA: 0x0007E14C File Offset: 0x0007C34C
		// (set) Token: 0x0600423B RID: 16955 RVA: 0x0007E178 File Offset: 0x0007C378
		[ProtoMember(3, IsRequired = false, Name = "curtopcount", DataFormat = DataFormat.TwosComplement)]
		public uint curtopcount
		{
			get
			{
				return this._curtopcount ?? 0U;
			}
			set
			{
				this._curtopcount = new uint?(value);
			}
		}

		// Token: 0x17001446 RID: 5190
		// (get) Token: 0x0600423C RID: 16956 RVA: 0x0007E188 File Offset: 0x0007C388
		// (set) Token: 0x0600423D RID: 16957 RVA: 0x0007E1A8 File Offset: 0x0007C3A8
		[XmlIgnore]
		[Browsable(false)]
		public bool curtopcountSpecified
		{
			get
			{
				return this._curtopcount != null;
			}
			set
			{
				bool flag = value == (this._curtopcount == null);
				if (flag)
				{
					this._curtopcount = (value ? new uint?(this.curtopcount) : null);
				}
			}
		}

		// Token: 0x0600423E RID: 16958 RVA: 0x0007E1EC File Offset: 0x0007C3EC
		private bool ShouldSerializecurtopcount()
		{
			return this.curtopcountSpecified;
		}

		// Token: 0x0600423F RID: 16959 RVA: 0x0007E204 File Offset: 0x0007C404
		private void Resetcurtopcount()
		{
			this.curtopcountSpecified = false;
		}

		// Token: 0x17001447 RID: 5191
		// (get) Token: 0x06004240 RID: 16960 RVA: 0x0007E210 File Offset: 0x0007C410
		// (set) Token: 0x06004241 RID: 16961 RVA: 0x0007E23C File Offset: 0x0007C43C
		[ProtoMember(4, IsRequired = false, Name = "needtopcount", DataFormat = DataFormat.TwosComplement)]
		public uint needtopcount
		{
			get
			{
				return this._needtopcount ?? 0U;
			}
			set
			{
				this._needtopcount = new uint?(value);
			}
		}

		// Token: 0x17001448 RID: 5192
		// (get) Token: 0x06004242 RID: 16962 RVA: 0x0007E24C File Offset: 0x0007C44C
		// (set) Token: 0x06004243 RID: 16963 RVA: 0x0007E26C File Offset: 0x0007C46C
		[XmlIgnore]
		[Browsable(false)]
		public bool needtopcountSpecified
		{
			get
			{
				return this._needtopcount != null;
			}
			set
			{
				bool flag = value == (this._needtopcount == null);
				if (flag)
				{
					this._needtopcount = (value ? new uint?(this.needtopcount) : null);
				}
			}
		}

		// Token: 0x06004244 RID: 16964 RVA: 0x0007E2B0 File Offset: 0x0007C4B0
		private bool ShouldSerializeneedtopcount()
		{
			return this.needtopcountSpecified;
		}

		// Token: 0x06004245 RID: 16965 RVA: 0x0007E2C8 File Offset: 0x0007C4C8
		private void Resetneedtopcount()
		{
			this.needtopcountSpecified = false;
		}

		// Token: 0x17001449 RID: 5193
		// (get) Token: 0x06004246 RID: 16966 RVA: 0x0007E2D4 File Offset: 0x0007C4D4
		// (set) Token: 0x06004247 RID: 16967 RVA: 0x0007E300 File Offset: 0x0007C500
		[ProtoMember(5, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x1700144A RID: 5194
		// (get) Token: 0x06004248 RID: 16968 RVA: 0x0007E310 File Offset: 0x0007C510
		// (set) Token: 0x06004249 RID: 16969 RVA: 0x0007E330 File Offset: 0x0007C530
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x0600424A RID: 16970 RVA: 0x0007E374 File Offset: 0x0007C574
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x0600424B RID: 16971 RVA: 0x0007E38C File Offset: 0x0007C58C
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x0600424C RID: 16972 RVA: 0x0007E398 File Offset: 0x0007C598
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001081 RID: 4225
		private ErrorCode? _errorcode;

		// Token: 0x04001082 RID: 4226
		private bool? _givereward;

		// Token: 0x04001083 RID: 4227
		private uint? _curtopcount;

		// Token: 0x04001084 RID: 4228
		private uint? _needtopcount;

		// Token: 0x04001085 RID: 4229
		private uint? _point;

		// Token: 0x04001086 RID: 4230
		private IExtension extensionObject;
	}
}

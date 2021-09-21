using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000286 RID: 646
	[ProtoContract(Name = "PayNotifyArg")]
	[Serializable]
	public class PayNotifyArg : IExtensible
	{
		// Token: 0x17000B36 RID: 2870
		// (get) Token: 0x06002411 RID: 9233 RVA: 0x0004667C File Offset: 0x0004487C
		// (set) Token: 0x06002412 RID: 9234 RVA: 0x0004669D File Offset: 0x0004489D
		[ProtoMember(1, IsRequired = false, Name = "p", DataFormat = DataFormat.Default)]
		public string p
		{
			get
			{
				return this._p ?? "";
			}
			set
			{
				this._p = value;
			}
		}

		// Token: 0x17000B37 RID: 2871
		// (get) Token: 0x06002413 RID: 9235 RVA: 0x000466A8 File Offset: 0x000448A8
		// (set) Token: 0x06002414 RID: 9236 RVA: 0x000466C4 File Offset: 0x000448C4
		[XmlIgnore]
		[Browsable(false)]
		public bool pSpecified
		{
			get
			{
				return this._p != null;
			}
			set
			{
				bool flag = value == (this._p == null);
				if (flag)
				{
					this._p = (value ? this.p : null);
				}
			}
		}

		// Token: 0x06002415 RID: 9237 RVA: 0x000466F4 File Offset: 0x000448F4
		private bool ShouldSerializep()
		{
			return this.pSpecified;
		}

		// Token: 0x06002416 RID: 9238 RVA: 0x0004670C File Offset: 0x0004490C
		private void Resetp()
		{
			this.pSpecified = false;
		}

		// Token: 0x17000B38 RID: 2872
		// (get) Token: 0x06002417 RID: 9239 RVA: 0x00046718 File Offset: 0x00044918
		// (set) Token: 0x06002418 RID: 9240 RVA: 0x00046739 File Offset: 0x00044939
		[ProtoMember(2, IsRequired = false, Name = "v", DataFormat = DataFormat.Default)]
		public string v
		{
			get
			{
				return this._v ?? "";
			}
			set
			{
				this._v = value;
			}
		}

		// Token: 0x17000B39 RID: 2873
		// (get) Token: 0x06002419 RID: 9241 RVA: 0x00046744 File Offset: 0x00044944
		// (set) Token: 0x0600241A RID: 9242 RVA: 0x00046760 File Offset: 0x00044960
		[XmlIgnore]
		[Browsable(false)]
		public bool vSpecified
		{
			get
			{
				return this._v != null;
			}
			set
			{
				bool flag = value == (this._v == null);
				if (flag)
				{
					this._v = (value ? this.v : null);
				}
			}
		}

		// Token: 0x0600241B RID: 9243 RVA: 0x00046790 File Offset: 0x00044990
		private bool ShouldSerializev()
		{
			return this.vSpecified;
		}

		// Token: 0x0600241C RID: 9244 RVA: 0x000467A8 File Offset: 0x000449A8
		private void Resetv()
		{
			this.vSpecified = false;
		}

		// Token: 0x17000B3A RID: 2874
		// (get) Token: 0x0600241D RID: 9245 RVA: 0x000467B4 File Offset: 0x000449B4
		// (set) Token: 0x0600241E RID: 9246 RVA: 0x000467D5 File Offset: 0x000449D5
		[ProtoMember(3, IsRequired = false, Name = "ext", DataFormat = DataFormat.Default)]
		public string ext
		{
			get
			{
				return this._ext ?? "";
			}
			set
			{
				this._ext = value;
			}
		}

		// Token: 0x17000B3B RID: 2875
		// (get) Token: 0x0600241F RID: 9247 RVA: 0x000467E0 File Offset: 0x000449E0
		// (set) Token: 0x06002420 RID: 9248 RVA: 0x000467FC File Offset: 0x000449FC
		[XmlIgnore]
		[Browsable(false)]
		public bool extSpecified
		{
			get
			{
				return this._ext != null;
			}
			set
			{
				bool flag = value == (this._ext == null);
				if (flag)
				{
					this._ext = (value ? this.ext : null);
				}
			}
		}

		// Token: 0x06002421 RID: 9249 RVA: 0x0004682C File Offset: 0x00044A2C
		private bool ShouldSerializeext()
		{
			return this.extSpecified;
		}

		// Token: 0x06002422 RID: 9250 RVA: 0x00046844 File Offset: 0x00044A44
		private void Resetext()
		{
			this.extSpecified = false;
		}

		// Token: 0x17000B3C RID: 2876
		// (get) Token: 0x06002423 RID: 9251 RVA: 0x00046850 File Offset: 0x00044A50
		// (set) Token: 0x06002424 RID: 9252 RVA: 0x0004687C File Offset: 0x00044A7C
		[ProtoMember(4, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public PayParamType type
		{
			get
			{
				return this._type ?? PayParamType.PAY_PARAM_NONE;
			}
			set
			{
				this._type = new PayParamType?(value);
			}
		}

		// Token: 0x17000B3D RID: 2877
		// (get) Token: 0x06002425 RID: 9253 RVA: 0x0004688C File Offset: 0x00044A8C
		// (set) Token: 0x06002426 RID: 9254 RVA: 0x000468AC File Offset: 0x00044AAC
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new PayParamType?(this.type) : null);
				}
			}
		}

		// Token: 0x06002427 RID: 9255 RVA: 0x000468F0 File Offset: 0x00044AF0
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06002428 RID: 9256 RVA: 0x00046908 File Offset: 0x00044B08
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000B3E RID: 2878
		// (get) Token: 0x06002429 RID: 9257 RVA: 0x00046914 File Offset: 0x00044B14
		// (set) Token: 0x0600242A RID: 9258 RVA: 0x00046935 File Offset: 0x00044B35
		[ProtoMember(5, IsRequired = false, Name = "paramid", DataFormat = DataFormat.Default)]
		public string paramid
		{
			get
			{
				return this._paramid ?? "";
			}
			set
			{
				this._paramid = value;
			}
		}

		// Token: 0x17000B3F RID: 2879
		// (get) Token: 0x0600242B RID: 9259 RVA: 0x00046940 File Offset: 0x00044B40
		// (set) Token: 0x0600242C RID: 9260 RVA: 0x0004695C File Offset: 0x00044B5C
		[XmlIgnore]
		[Browsable(false)]
		public bool paramidSpecified
		{
			get
			{
				return this._paramid != null;
			}
			set
			{
				bool flag = value == (this._paramid == null);
				if (flag)
				{
					this._paramid = (value ? this.paramid : null);
				}
			}
		}

		// Token: 0x0600242D RID: 9261 RVA: 0x0004698C File Offset: 0x00044B8C
		private bool ShouldSerializeparamid()
		{
			return this.paramidSpecified;
		}

		// Token: 0x0600242E RID: 9262 RVA: 0x000469A4 File Offset: 0x00044BA4
		private void Resetparamid()
		{
			this.paramidSpecified = false;
		}

		// Token: 0x17000B40 RID: 2880
		// (get) Token: 0x0600242F RID: 9263 RVA: 0x000469B0 File Offset: 0x00044BB0
		// (set) Token: 0x06002430 RID: 9264 RVA: 0x000469DC File Offset: 0x00044BDC
		[ProtoMember(6, IsRequired = false, Name = "amount", DataFormat = DataFormat.TwosComplement)]
		public int amount
		{
			get
			{
				return this._amount ?? 0;
			}
			set
			{
				this._amount = new int?(value);
			}
		}

		// Token: 0x17000B41 RID: 2881
		// (get) Token: 0x06002431 RID: 9265 RVA: 0x000469EC File Offset: 0x00044BEC
		// (set) Token: 0x06002432 RID: 9266 RVA: 0x00046A0C File Offset: 0x00044C0C
		[XmlIgnore]
		[Browsable(false)]
		public bool amountSpecified
		{
			get
			{
				return this._amount != null;
			}
			set
			{
				bool flag = value == (this._amount == null);
				if (flag)
				{
					this._amount = (value ? new int?(this.amount) : null);
				}
			}
		}

		// Token: 0x06002433 RID: 9267 RVA: 0x00046A50 File Offset: 0x00044C50
		private bool ShouldSerializeamount()
		{
			return this.amountSpecified;
		}

		// Token: 0x06002434 RID: 9268 RVA: 0x00046A68 File Offset: 0x00044C68
		private void Resetamount()
		{
			this.amountSpecified = false;
		}

		// Token: 0x17000B42 RID: 2882
		// (get) Token: 0x06002435 RID: 9269 RVA: 0x00046A74 File Offset: 0x00044C74
		// (set) Token: 0x06002436 RID: 9270 RVA: 0x00046A8C File Offset: 0x00044C8C
		[ProtoMember(7, IsRequired = false, Name = "data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayParameterInfo data
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

		// Token: 0x17000B43 RID: 2883
		// (get) Token: 0x06002437 RID: 9271 RVA: 0x00046A98 File Offset: 0x00044C98
		// (set) Token: 0x06002438 RID: 9272 RVA: 0x00046AC4 File Offset: 0x00044CC4
		[ProtoMember(8, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public int count
		{
			get
			{
				return this._count ?? 0;
			}
			set
			{
				this._count = new int?(value);
			}
		}

		// Token: 0x17000B44 RID: 2884
		// (get) Token: 0x06002439 RID: 9273 RVA: 0x00046AD4 File Offset: 0x00044CD4
		// (set) Token: 0x0600243A RID: 9274 RVA: 0x00046AF4 File Offset: 0x00044CF4
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
					this._count = (value ? new int?(this.count) : null);
				}
			}
		}

		// Token: 0x0600243B RID: 9275 RVA: 0x00046B38 File Offset: 0x00044D38
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x0600243C RID: 9276 RVA: 0x00046B50 File Offset: 0x00044D50
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x0600243D RID: 9277 RVA: 0x00046B5C File Offset: 0x00044D5C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008ED RID: 2285
		private string _p;

		// Token: 0x040008EE RID: 2286
		private string _v;

		// Token: 0x040008EF RID: 2287
		private string _ext;

		// Token: 0x040008F0 RID: 2288
		private PayParamType? _type;

		// Token: 0x040008F1 RID: 2289
		private string _paramid;

		// Token: 0x040008F2 RID: 2290
		private int? _amount;

		// Token: 0x040008F3 RID: 2291
		private PayParameterInfo _data = null;

		// Token: 0x040008F4 RID: 2292
		private int? _count;

		// Token: 0x040008F5 RID: 2293
		private IExtension extensionObject;
	}
}

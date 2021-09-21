using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000636 RID: 1590
	[ProtoContract(Name = "RiskBoxInfo")]
	[Serializable]
	public class RiskBoxInfo : IExtensible
	{
		// Token: 0x17001ECA RID: 7882
		// (get) Token: 0x060061CC RID: 25036 RVA: 0x000BA928 File Offset: 0x000B8B28
		// (set) Token: 0x060061CD RID: 25037 RVA: 0x000BA954 File Offset: 0x000B8B54
		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public RiskBoxState state
		{
			get
			{
				return this._state ?? RiskBoxState.RISK_BOX_LOCKED;
			}
			set
			{
				this._state = new RiskBoxState?(value);
			}
		}

		// Token: 0x17001ECB RID: 7883
		// (get) Token: 0x060061CE RID: 25038 RVA: 0x000BA964 File Offset: 0x000B8B64
		// (set) Token: 0x060061CF RID: 25039 RVA: 0x000BA984 File Offset: 0x000B8B84
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new RiskBoxState?(this.state) : null);
				}
			}
		}

		// Token: 0x060061D0 RID: 25040 RVA: 0x000BA9C8 File Offset: 0x000B8BC8
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x060061D1 RID: 25041 RVA: 0x000BA9E0 File Offset: 0x000B8BE0
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x17001ECC RID: 7884
		// (get) Token: 0x060061D2 RID: 25042 RVA: 0x000BA9EC File Offset: 0x000B8BEC
		// (set) Token: 0x060061D3 RID: 25043 RVA: 0x000BAA18 File Offset: 0x000B8C18
		[ProtoMember(2, IsRequired = false, Name = "leftTime", DataFormat = DataFormat.TwosComplement)]
		public int leftTime
		{
			get
			{
				return this._leftTime ?? 0;
			}
			set
			{
				this._leftTime = new int?(value);
			}
		}

		// Token: 0x17001ECD RID: 7885
		// (get) Token: 0x060061D4 RID: 25044 RVA: 0x000BAA28 File Offset: 0x000B8C28
		// (set) Token: 0x060061D5 RID: 25045 RVA: 0x000BAA48 File Offset: 0x000B8C48
		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimeSpecified
		{
			get
			{
				return this._leftTime != null;
			}
			set
			{
				bool flag = value == (this._leftTime == null);
				if (flag)
				{
					this._leftTime = (value ? new int?(this.leftTime) : null);
				}
			}
		}

		// Token: 0x060061D6 RID: 25046 RVA: 0x000BAA8C File Offset: 0x000B8C8C
		private bool ShouldSerializeleftTime()
		{
			return this.leftTimeSpecified;
		}

		// Token: 0x060061D7 RID: 25047 RVA: 0x000BAAA4 File Offset: 0x000B8CA4
		private void ResetleftTime()
		{
			this.leftTimeSpecified = false;
		}

		// Token: 0x17001ECE RID: 7886
		// (get) Token: 0x060061D8 RID: 25048 RVA: 0x000BAAB0 File Offset: 0x000B8CB0
		// (set) Token: 0x060061D9 RID: 25049 RVA: 0x000BAAC8 File Offset: 0x000B8CC8
		[ProtoMember(3, IsRequired = false, Name = "item", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief item
		{
			get
			{
				return this._item;
			}
			set
			{
				this._item = value;
			}
		}

		// Token: 0x17001ECF RID: 7887
		// (get) Token: 0x060061DA RID: 25050 RVA: 0x000BAAD4 File Offset: 0x000B8CD4
		// (set) Token: 0x060061DB RID: 25051 RVA: 0x000BAB00 File Offset: 0x000B8D00
		[ProtoMember(4, IsRequired = false, Name = "beginTime", DataFormat = DataFormat.TwosComplement)]
		public int beginTime
		{
			get
			{
				return this._beginTime ?? 0;
			}
			set
			{
				this._beginTime = new int?(value);
			}
		}

		// Token: 0x17001ED0 RID: 7888
		// (get) Token: 0x060061DC RID: 25052 RVA: 0x000BAB10 File Offset: 0x000B8D10
		// (set) Token: 0x060061DD RID: 25053 RVA: 0x000BAB30 File Offset: 0x000B8D30
		[XmlIgnore]
		[Browsable(false)]
		public bool beginTimeSpecified
		{
			get
			{
				return this._beginTime != null;
			}
			set
			{
				bool flag = value == (this._beginTime == null);
				if (flag)
				{
					this._beginTime = (value ? new int?(this.beginTime) : null);
				}
			}
		}

		// Token: 0x060061DE RID: 25054 RVA: 0x000BAB74 File Offset: 0x000B8D74
		private bool ShouldSerializebeginTime()
		{
			return this.beginTimeSpecified;
		}

		// Token: 0x060061DF RID: 25055 RVA: 0x000BAB8C File Offset: 0x000B8D8C
		private void ResetbeginTime()
		{
			this.beginTimeSpecified = false;
		}

		// Token: 0x17001ED1 RID: 7889
		// (get) Token: 0x060061E0 RID: 25056 RVA: 0x000BAB98 File Offset: 0x000B8D98
		// (set) Token: 0x060061E1 RID: 25057 RVA: 0x000BABC4 File Offset: 0x000B8DC4
		[ProtoMember(5, IsRequired = false, Name = "slot", DataFormat = DataFormat.TwosComplement)]
		public int slot
		{
			get
			{
				return this._slot ?? 0;
			}
			set
			{
				this._slot = new int?(value);
			}
		}

		// Token: 0x17001ED2 RID: 7890
		// (get) Token: 0x060061E2 RID: 25058 RVA: 0x000BABD4 File Offset: 0x000B8DD4
		// (set) Token: 0x060061E3 RID: 25059 RVA: 0x000BABF4 File Offset: 0x000B8DF4
		[XmlIgnore]
		[Browsable(false)]
		public bool slotSpecified
		{
			get
			{
				return this._slot != null;
			}
			set
			{
				bool flag = value == (this._slot == null);
				if (flag)
				{
					this._slot = (value ? new int?(this.slot) : null);
				}
			}
		}

		// Token: 0x060061E4 RID: 25060 RVA: 0x000BAC38 File Offset: 0x000B8E38
		private bool ShouldSerializeslot()
		{
			return this.slotSpecified;
		}

		// Token: 0x060061E5 RID: 25061 RVA: 0x000BAC50 File Offset: 0x000B8E50
		private void Resetslot()
		{
			this.slotSpecified = false;
		}

		// Token: 0x060061E6 RID: 25062 RVA: 0x000BAC5C File Offset: 0x000B8E5C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040017BD RID: 6077
		private RiskBoxState? _state;

		// Token: 0x040017BE RID: 6078
		private int? _leftTime;

		// Token: 0x040017BF RID: 6079
		private ItemBrief _item = null;

		// Token: 0x040017C0 RID: 6080
		private int? _beginTime;

		// Token: 0x040017C1 RID: 6081
		private int? _slot;

		// Token: 0x040017C2 RID: 6082
		private IExtension extensionObject;
	}
}

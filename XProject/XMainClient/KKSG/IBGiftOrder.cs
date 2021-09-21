using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200062E RID: 1582
	[ProtoContract(Name = "IBGiftOrder")]
	[Serializable]
	public class IBGiftOrder : IExtensible
	{
		// Token: 0x17001E99 RID: 7833
		// (get) Token: 0x0600613F RID: 24895 RVA: 0x000B9858 File Offset: 0x000B7A58
		// (set) Token: 0x06006140 RID: 24896 RVA: 0x000B9879 File Offset: 0x000B7A79
		[ProtoMember(1, IsRequired = false, Name = "orderid", DataFormat = DataFormat.Default)]
		public string orderid
		{
			get
			{
				return this._orderid ?? "";
			}
			set
			{
				this._orderid = value;
			}
		}

		// Token: 0x17001E9A RID: 7834
		// (get) Token: 0x06006141 RID: 24897 RVA: 0x000B9884 File Offset: 0x000B7A84
		// (set) Token: 0x06006142 RID: 24898 RVA: 0x000B98A0 File Offset: 0x000B7AA0
		[XmlIgnore]
		[Browsable(false)]
		public bool orderidSpecified
		{
			get
			{
				return this._orderid != null;
			}
			set
			{
				bool flag = value == (this._orderid == null);
				if (flag)
				{
					this._orderid = (value ? this.orderid : null);
				}
			}
		}

		// Token: 0x06006143 RID: 24899 RVA: 0x000B98D0 File Offset: 0x000B7AD0
		private bool ShouldSerializeorderid()
		{
			return this.orderidSpecified;
		}

		// Token: 0x06006144 RID: 24900 RVA: 0x000B98E8 File Offset: 0x000B7AE8
		private void Resetorderid()
		{
			this.orderidSpecified = false;
		}

		// Token: 0x17001E9B RID: 7835
		// (get) Token: 0x06006145 RID: 24901 RVA: 0x000B98F4 File Offset: 0x000B7AF4
		// (set) Token: 0x06006146 RID: 24902 RVA: 0x000B9920 File Offset: 0x000B7B20
		[ProtoMember(2, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x17001E9C RID: 7836
		// (get) Token: 0x06006147 RID: 24903 RVA: 0x000B9930 File Offset: 0x000B7B30
		// (set) Token: 0x06006148 RID: 24904 RVA: 0x000B9950 File Offset: 0x000B7B50
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x06006149 RID: 24905 RVA: 0x000B9994 File Offset: 0x000B7B94
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x0600614A RID: 24906 RVA: 0x000B99AC File Offset: 0x000B7BAC
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x0600614B RID: 24907 RVA: 0x000B99B8 File Offset: 0x000B7BB8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001796 RID: 6038
		private string _orderid;

		// Token: 0x04001797 RID: 6039
		private uint? _time;

		// Token: 0x04001798 RID: 6040
		private IExtension extensionObject;
	}
}

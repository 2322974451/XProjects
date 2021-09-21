using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200043F RID: 1087
	[ProtoContract(Name = "BMFightTime")]
	[Serializable]
	public class BMFightTime : IExtensible
	{
		// Token: 0x1700119E RID: 4510
		// (get) Token: 0x06003964 RID: 14692 RVA: 0x0006DCC8 File Offset: 0x0006BEC8
		// (set) Token: 0x06003965 RID: 14693 RVA: 0x0006DCF4 File Offset: 0x0006BEF4
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x1700119F RID: 4511
		// (get) Token: 0x06003966 RID: 14694 RVA: 0x0006DD04 File Offset: 0x0006BF04
		// (set) Token: 0x06003967 RID: 14695 RVA: 0x0006DD24 File Offset: 0x0006BF24
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
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x06003968 RID: 14696 RVA: 0x0006DD68 File Offset: 0x0006BF68
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003969 RID: 14697 RVA: 0x0006DD80 File Offset: 0x0006BF80
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170011A0 RID: 4512
		// (get) Token: 0x0600396A RID: 14698 RVA: 0x0006DD8C File Offset: 0x0006BF8C
		// (set) Token: 0x0600396B RID: 14699 RVA: 0x0006DDB8 File Offset: 0x0006BFB8
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

		// Token: 0x170011A1 RID: 4513
		// (get) Token: 0x0600396C RID: 14700 RVA: 0x0006DDC8 File Offset: 0x0006BFC8
		// (set) Token: 0x0600396D RID: 14701 RVA: 0x0006DDE8 File Offset: 0x0006BFE8
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

		// Token: 0x0600396E RID: 14702 RVA: 0x0006DE2C File Offset: 0x0006C02C
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x0600396F RID: 14703 RVA: 0x0006DE44 File Offset: 0x0006C044
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x06003970 RID: 14704 RVA: 0x0006DE50 File Offset: 0x0006C050
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E3E RID: 3646
		private uint? _type;

		// Token: 0x04000E3F RID: 3647
		private uint? _time;

		// Token: 0x04000E40 RID: 3648
		private IExtension extensionObject;
	}
}

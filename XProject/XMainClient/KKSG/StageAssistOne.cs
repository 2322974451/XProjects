using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005F0 RID: 1520
	[ProtoContract(Name = "StageAssistOne")]
	[Serializable]
	public class StageAssistOne : IExtensible
	{
		// Token: 0x17001C40 RID: 7232
		// (get) Token: 0x06005A5D RID: 23133 RVA: 0x000AC08C File Offset: 0x000AA28C
		// (set) Token: 0x06005A5E RID: 23134 RVA: 0x000AC0B8 File Offset: 0x000AA2B8
		[ProtoMember(1, IsRequired = false, Name = "stageid", DataFormat = DataFormat.TwosComplement)]
		public uint stageid
		{
			get
			{
				return this._stageid ?? 0U;
			}
			set
			{
				this._stageid = new uint?(value);
			}
		}

		// Token: 0x17001C41 RID: 7233
		// (get) Token: 0x06005A5F RID: 23135 RVA: 0x000AC0C8 File Offset: 0x000AA2C8
		// (set) Token: 0x06005A60 RID: 23136 RVA: 0x000AC0E8 File Offset: 0x000AA2E8
		[XmlIgnore]
		[Browsable(false)]
		public bool stageidSpecified
		{
			get
			{
				return this._stageid != null;
			}
			set
			{
				bool flag = value == (this._stageid == null);
				if (flag)
				{
					this._stageid = (value ? new uint?(this.stageid) : null);
				}
			}
		}

		// Token: 0x06005A61 RID: 23137 RVA: 0x000AC12C File Offset: 0x000AA32C
		private bool ShouldSerializestageid()
		{
			return this.stageidSpecified;
		}

		// Token: 0x06005A62 RID: 23138 RVA: 0x000AC144 File Offset: 0x000AA344
		private void Resetstageid()
		{
			this.stageidSpecified = false;
		}

		// Token: 0x17001C42 RID: 7234
		// (get) Token: 0x06005A63 RID: 23139 RVA: 0x000AC150 File Offset: 0x000AA350
		// (set) Token: 0x06005A64 RID: 23140 RVA: 0x000AC17C File Offset: 0x000AA37C
		[ProtoMember(2, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public int point
		{
			get
			{
				return this._point ?? 0;
			}
			set
			{
				this._point = new int?(value);
			}
		}

		// Token: 0x17001C43 RID: 7235
		// (get) Token: 0x06005A65 RID: 23141 RVA: 0x000AC18C File Offset: 0x000AA38C
		// (set) Token: 0x06005A66 RID: 23142 RVA: 0x000AC1AC File Offset: 0x000AA3AC
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
					this._point = (value ? new int?(this.point) : null);
				}
			}
		}

		// Token: 0x06005A67 RID: 23143 RVA: 0x000AC1F0 File Offset: 0x000AA3F0
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06005A68 RID: 23144 RVA: 0x000AC208 File Offset: 0x000AA408
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x06005A69 RID: 23145 RVA: 0x000AC214 File Offset: 0x000AA414
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040015FE RID: 5630
		private uint? _stageid;

		// Token: 0x040015FF RID: 5631
		private int? _point;

		// Token: 0x04001600 RID: 5632
		private IExtension extensionObject;
	}
}

using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000137 RID: 311
	[ProtoContract(Name = "TssSdkAntiData")]
	[Serializable]
	public class TssSdkAntiData : IExtensible
	{
		// Token: 0x1700060E RID: 1550
		// (get) Token: 0x060012FF RID: 4863 RVA: 0x00026774 File Offset: 0x00024974
		// (set) Token: 0x06001300 RID: 4864 RVA: 0x00026791 File Offset: 0x00024991
		[ProtoMember(1, IsRequired = false, Name = "anti_data", DataFormat = DataFormat.Default)]
		public byte[] anti_data
		{
			get
			{
				return this._anti_data ?? null;
			}
			set
			{
				this._anti_data = value;
			}
		}

		// Token: 0x1700060F RID: 1551
		// (get) Token: 0x06001301 RID: 4865 RVA: 0x0002679C File Offset: 0x0002499C
		// (set) Token: 0x06001302 RID: 4866 RVA: 0x000267B8 File Offset: 0x000249B8
		[XmlIgnore]
		[Browsable(false)]
		public bool anti_dataSpecified
		{
			get
			{
				return this._anti_data != null;
			}
			set
			{
				bool flag = value == (this._anti_data == null);
				if (flag)
				{
					this._anti_data = (value ? this.anti_data : null);
				}
			}
		}

		// Token: 0x06001303 RID: 4867 RVA: 0x000267E8 File Offset: 0x000249E8
		private bool ShouldSerializeanti_data()
		{
			return this.anti_dataSpecified;
		}

		// Token: 0x06001304 RID: 4868 RVA: 0x00026800 File Offset: 0x00024A00
		private void Resetanti_data()
		{
			this.anti_dataSpecified = false;
		}

		// Token: 0x17000610 RID: 1552
		// (get) Token: 0x06001305 RID: 4869 RVA: 0x0002680C File Offset: 0x00024A0C
		// (set) Token: 0x06001306 RID: 4870 RVA: 0x00026838 File Offset: 0x00024A38
		[ProtoMember(2, IsRequired = false, Name = "anti_data_len", DataFormat = DataFormat.TwosComplement)]
		public uint anti_data_len
		{
			get
			{
				return this._anti_data_len ?? 0U;
			}
			set
			{
				this._anti_data_len = new uint?(value);
			}
		}

		// Token: 0x17000611 RID: 1553
		// (get) Token: 0x06001307 RID: 4871 RVA: 0x00026848 File Offset: 0x00024A48
		// (set) Token: 0x06001308 RID: 4872 RVA: 0x00026868 File Offset: 0x00024A68
		[XmlIgnore]
		[Browsable(false)]
		public bool anti_data_lenSpecified
		{
			get
			{
				return this._anti_data_len != null;
			}
			set
			{
				bool flag = value == (this._anti_data_len == null);
				if (flag)
				{
					this._anti_data_len = (value ? new uint?(this.anti_data_len) : null);
				}
			}
		}

		// Token: 0x06001309 RID: 4873 RVA: 0x000268AC File Offset: 0x00024AAC
		private bool ShouldSerializeanti_data_len()
		{
			return this.anti_data_lenSpecified;
		}

		// Token: 0x0600130A RID: 4874 RVA: 0x000268C4 File Offset: 0x00024AC4
		private void Resetanti_data_len()
		{
			this.anti_data_lenSpecified = false;
		}

		// Token: 0x0600130B RID: 4875 RVA: 0x000268D0 File Offset: 0x00024AD0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004BF RID: 1215
		private byte[] _anti_data;

		// Token: 0x040004C0 RID: 1216
		private uint? _anti_data_len;

		// Token: 0x040004C1 RID: 1217
		private IExtension extensionObject;
	}
}

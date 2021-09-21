using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000138 RID: 312
	[ProtoContract(Name = "QANotify")]
	[Serializable]
	public class QANotify : IExtensible
	{
		// Token: 0x17000612 RID: 1554
		// (get) Token: 0x0600130D RID: 4877 RVA: 0x000268F0 File Offset: 0x00024AF0
		// (set) Token: 0x0600130E RID: 4878 RVA: 0x0002691C File Offset: 0x00024B1C
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

		// Token: 0x17000613 RID: 1555
		// (get) Token: 0x0600130F RID: 4879 RVA: 0x0002692C File Offset: 0x00024B2C
		// (set) Token: 0x06001310 RID: 4880 RVA: 0x0002694C File Offset: 0x00024B4C
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

		// Token: 0x06001311 RID: 4881 RVA: 0x00026990 File Offset: 0x00024B90
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06001312 RID: 4882 RVA: 0x000269A8 File Offset: 0x00024BA8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000614 RID: 1556
		// (get) Token: 0x06001313 RID: 4883 RVA: 0x000269B4 File Offset: 0x00024BB4
		// (set) Token: 0x06001314 RID: 4884 RVA: 0x000269E0 File Offset: 0x00024BE0
		[ProtoMember(2, IsRequired = false, Name = "is_playing", DataFormat = DataFormat.Default)]
		public bool is_playing
		{
			get
			{
				return this._is_playing ?? false;
			}
			set
			{
				this._is_playing = new bool?(value);
			}
		}

		// Token: 0x17000615 RID: 1557
		// (get) Token: 0x06001315 RID: 4885 RVA: 0x000269F0 File Offset: 0x00024BF0
		// (set) Token: 0x06001316 RID: 4886 RVA: 0x00026A10 File Offset: 0x00024C10
		[XmlIgnore]
		[Browsable(false)]
		public bool is_playingSpecified
		{
			get
			{
				return this._is_playing != null;
			}
			set
			{
				bool flag = value == (this._is_playing == null);
				if (flag)
				{
					this._is_playing = (value ? new bool?(this.is_playing) : null);
				}
			}
		}

		// Token: 0x06001317 RID: 4887 RVA: 0x00026A54 File Offset: 0x00024C54
		private bool ShouldSerializeis_playing()
		{
			return this.is_playingSpecified;
		}

		// Token: 0x06001318 RID: 4888 RVA: 0x00026A6C File Offset: 0x00024C6C
		private void Resetis_playing()
		{
			this.is_playingSpecified = false;
		}

		// Token: 0x17000616 RID: 1558
		// (get) Token: 0x06001319 RID: 4889 RVA: 0x00026A78 File Offset: 0x00024C78
		// (set) Token: 0x0600131A RID: 4890 RVA: 0x00026AA4 File Offset: 0x00024CA4
		[ProtoMember(3, IsRequired = false, Name = "is_over", DataFormat = DataFormat.Default)]
		public bool is_over
		{
			get
			{
				return this._is_over ?? false;
			}
			set
			{
				this._is_over = new bool?(value);
			}
		}

		// Token: 0x17000617 RID: 1559
		// (get) Token: 0x0600131B RID: 4891 RVA: 0x00026AB4 File Offset: 0x00024CB4
		// (set) Token: 0x0600131C RID: 4892 RVA: 0x00026AD4 File Offset: 0x00024CD4
		[XmlIgnore]
		[Browsable(false)]
		public bool is_overSpecified
		{
			get
			{
				return this._is_over != null;
			}
			set
			{
				bool flag = value == (this._is_over == null);
				if (flag)
				{
					this._is_over = (value ? new bool?(this.is_over) : null);
				}
			}
		}

		// Token: 0x0600131D RID: 4893 RVA: 0x00026B18 File Offset: 0x00024D18
		private bool ShouldSerializeis_over()
		{
			return this.is_overSpecified;
		}

		// Token: 0x0600131E RID: 4894 RVA: 0x00026B30 File Offset: 0x00024D30
		private void Resetis_over()
		{
			this.is_overSpecified = false;
		}

		// Token: 0x0600131F RID: 4895 RVA: 0x00026B3C File Offset: 0x00024D3C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004C2 RID: 1218
		private uint? _type;

		// Token: 0x040004C3 RID: 1219
		private bool? _is_playing;

		// Token: 0x040004C4 RID: 1220
		private bool? _is_over;

		// Token: 0x040004C5 RID: 1221
		private IExtension extensionObject;
	}
}

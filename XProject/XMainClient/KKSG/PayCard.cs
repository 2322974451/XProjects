using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200069B RID: 1691
	[ProtoContract(Name = "PayCard")]
	[Serializable]
	public class PayCard : IExtensible
	{
		// Token: 0x170022CF RID: 8911
		// (get) Token: 0x06006DFB RID: 28155 RVA: 0x000D2714 File Offset: 0x000D0914
		// (set) Token: 0x06006DFC RID: 28156 RVA: 0x000D2740 File Offset: 0x000D0940
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

		// Token: 0x170022D0 RID: 8912
		// (get) Token: 0x06006DFD RID: 28157 RVA: 0x000D2750 File Offset: 0x000D0950
		// (set) Token: 0x06006DFE RID: 28158 RVA: 0x000D2770 File Offset: 0x000D0970
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

		// Token: 0x06006DFF RID: 28159 RVA: 0x000D27B4 File Offset: 0x000D09B4
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06006E00 RID: 28160 RVA: 0x000D27CC File Offset: 0x000D09CC
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170022D1 RID: 8913
		// (get) Token: 0x06006E01 RID: 28161 RVA: 0x000D27D8 File Offset: 0x000D09D8
		// (set) Token: 0x06006E02 RID: 28162 RVA: 0x000D2804 File Offset: 0x000D0A04
		[ProtoMember(2, IsRequired = false, Name = "remainedCount", DataFormat = DataFormat.TwosComplement)]
		public uint remainedCount
		{
			get
			{
				return this._remainedCount ?? 0U;
			}
			set
			{
				this._remainedCount = new uint?(value);
			}
		}

		// Token: 0x170022D2 RID: 8914
		// (get) Token: 0x06006E03 RID: 28163 RVA: 0x000D2814 File Offset: 0x000D0A14
		// (set) Token: 0x06006E04 RID: 28164 RVA: 0x000D2834 File Offset: 0x000D0A34
		[XmlIgnore]
		[Browsable(false)]
		public bool remainedCountSpecified
		{
			get
			{
				return this._remainedCount != null;
			}
			set
			{
				bool flag = value == (this._remainedCount == null);
				if (flag)
				{
					this._remainedCount = (value ? new uint?(this.remainedCount) : null);
				}
			}
		}

		// Token: 0x06006E05 RID: 28165 RVA: 0x000D2878 File Offset: 0x000D0A78
		private bool ShouldSerializeremainedCount()
		{
			return this.remainedCountSpecified;
		}

		// Token: 0x06006E06 RID: 28166 RVA: 0x000D2890 File Offset: 0x000D0A90
		private void ResetremainedCount()
		{
			this.remainedCountSpecified = false;
		}

		// Token: 0x170022D3 RID: 8915
		// (get) Token: 0x06006E07 RID: 28167 RVA: 0x000D289C File Offset: 0x000D0A9C
		// (set) Token: 0x06006E08 RID: 28168 RVA: 0x000D28C8 File Offset: 0x000D0AC8
		[ProtoMember(3, IsRequired = false, Name = "isGet", DataFormat = DataFormat.Default)]
		public bool isGet
		{
			get
			{
				return this._isGet ?? false;
			}
			set
			{
				this._isGet = new bool?(value);
			}
		}

		// Token: 0x170022D4 RID: 8916
		// (get) Token: 0x06006E09 RID: 28169 RVA: 0x000D28D8 File Offset: 0x000D0AD8
		// (set) Token: 0x06006E0A RID: 28170 RVA: 0x000D28F8 File Offset: 0x000D0AF8
		[XmlIgnore]
		[Browsable(false)]
		public bool isGetSpecified
		{
			get
			{
				return this._isGet != null;
			}
			set
			{
				bool flag = value == (this._isGet == null);
				if (flag)
				{
					this._isGet = (value ? new bool?(this.isGet) : null);
				}
			}
		}

		// Token: 0x06006E0B RID: 28171 RVA: 0x000D293C File Offset: 0x000D0B3C
		private bool ShouldSerializeisGet()
		{
			return this.isGetSpecified;
		}

		// Token: 0x06006E0C RID: 28172 RVA: 0x000D2954 File Offset: 0x000D0B54
		private void ResetisGet()
		{
			this.isGetSpecified = false;
		}

		// Token: 0x06006E0D RID: 28173 RVA: 0x000D2960 File Offset: 0x000D0B60
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A56 RID: 6742
		private uint? _type;

		// Token: 0x04001A57 RID: 6743
		private uint? _remainedCount;

		// Token: 0x04001A58 RID: 6744
		private bool? _isGet;

		// Token: 0x04001A59 RID: 6745
		private IExtension extensionObject;
	}
}

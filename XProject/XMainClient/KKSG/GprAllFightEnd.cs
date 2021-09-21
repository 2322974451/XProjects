using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200029B RID: 667
	[ProtoContract(Name = "GprAllFightEnd")]
	[Serializable]
	public class GprAllFightEnd : IExtensible
	{
		// Token: 0x17000B8E RID: 2958
		// (get) Token: 0x0600252E RID: 9518 RVA: 0x000486EC File Offset: 0x000468EC
		// (set) Token: 0x0600252F RID: 9519 RVA: 0x00048704 File Offset: 0x00046904
		[ProtoMember(1, IsRequired = false, Name = "winguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief winguild
		{
			get
			{
				return this._winguild;
			}
			set
			{
				this._winguild = value;
			}
		}

		// Token: 0x17000B8F RID: 2959
		// (get) Token: 0x06002530 RID: 9520 RVA: 0x00048710 File Offset: 0x00046910
		// (set) Token: 0x06002531 RID: 9521 RVA: 0x00048728 File Offset: 0x00046928
		[ProtoMember(2, IsRequired = false, Name = "loseguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief loseguild
		{
			get
			{
				return this._loseguild;
			}
			set
			{
				this._loseguild = value;
			}
		}

		// Token: 0x17000B90 RID: 2960
		// (get) Token: 0x06002532 RID: 9522 RVA: 0x00048734 File Offset: 0x00046934
		// (set) Token: 0x06002533 RID: 9523 RVA: 0x00048760 File Offset: 0x00046960
		[ProtoMember(3, IsRequired = false, Name = "winscore", DataFormat = DataFormat.TwosComplement)]
		public uint winscore
		{
			get
			{
				return this._winscore ?? 0U;
			}
			set
			{
				this._winscore = new uint?(value);
			}
		}

		// Token: 0x17000B91 RID: 2961
		// (get) Token: 0x06002534 RID: 9524 RVA: 0x00048770 File Offset: 0x00046970
		// (set) Token: 0x06002535 RID: 9525 RVA: 0x00048790 File Offset: 0x00046990
		[XmlIgnore]
		[Browsable(false)]
		public bool winscoreSpecified
		{
			get
			{
				return this._winscore != null;
			}
			set
			{
				bool flag = value == (this._winscore == null);
				if (flag)
				{
					this._winscore = (value ? new uint?(this.winscore) : null);
				}
			}
		}

		// Token: 0x06002536 RID: 9526 RVA: 0x000487D4 File Offset: 0x000469D4
		private bool ShouldSerializewinscore()
		{
			return this.winscoreSpecified;
		}

		// Token: 0x06002537 RID: 9527 RVA: 0x000487EC File Offset: 0x000469EC
		private void Resetwinscore()
		{
			this.winscoreSpecified = false;
		}

		// Token: 0x17000B92 RID: 2962
		// (get) Token: 0x06002538 RID: 9528 RVA: 0x000487F8 File Offset: 0x000469F8
		// (set) Token: 0x06002539 RID: 9529 RVA: 0x00048824 File Offset: 0x00046A24
		[ProtoMember(4, IsRequired = false, Name = "losescore", DataFormat = DataFormat.TwosComplement)]
		public uint losescore
		{
			get
			{
				return this._losescore ?? 0U;
			}
			set
			{
				this._losescore = new uint?(value);
			}
		}

		// Token: 0x17000B93 RID: 2963
		// (get) Token: 0x0600253A RID: 9530 RVA: 0x00048834 File Offset: 0x00046A34
		// (set) Token: 0x0600253B RID: 9531 RVA: 0x00048854 File Offset: 0x00046A54
		[XmlIgnore]
		[Browsable(false)]
		public bool losescoreSpecified
		{
			get
			{
				return this._losescore != null;
			}
			set
			{
				bool flag = value == (this._losescore == null);
				if (flag)
				{
					this._losescore = (value ? new uint?(this.losescore) : null);
				}
			}
		}

		// Token: 0x0600253C RID: 9532 RVA: 0x00048898 File Offset: 0x00046A98
		private bool ShouldSerializelosescore()
		{
			return this.losescoreSpecified;
		}

		// Token: 0x0600253D RID: 9533 RVA: 0x000488B0 File Offset: 0x00046AB0
		private void Resetlosescore()
		{
			this.losescoreSpecified = false;
		}

		// Token: 0x0600253E RID: 9534 RVA: 0x000488BC File Offset: 0x00046ABC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000935 RID: 2357
		private GmfGuildBrief _winguild = null;

		// Token: 0x04000936 RID: 2358
		private GmfGuildBrief _loseguild = null;

		// Token: 0x04000937 RID: 2359
		private uint? _winscore;

		// Token: 0x04000938 RID: 2360
		private uint? _losescore;

		// Token: 0x04000939 RID: 2361
		private IExtension extensionObject;
	}
}

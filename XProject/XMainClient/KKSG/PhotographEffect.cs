using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200032D RID: 813
	[ProtoContract(Name = "PhotographEffect")]
	[Serializable]
	public class PhotographEffect : IExtensible
	{
		// Token: 0x17000DE0 RID: 3552
		// (get) Token: 0x06002CC3 RID: 11459 RVA: 0x00056A84 File Offset: 0x00054C84
		// (set) Token: 0x06002CC4 RID: 11460 RVA: 0x00056AB0 File Offset: 0x00054CB0
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17000DE1 RID: 3553
		// (get) Token: 0x06002CC5 RID: 11461 RVA: 0x00056AC0 File Offset: 0x00054CC0
		// (set) Token: 0x06002CC6 RID: 11462 RVA: 0x00056AE0 File Offset: 0x00054CE0
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x06002CC7 RID: 11463 RVA: 0x00056B24 File Offset: 0x00054D24
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002CC8 RID: 11464 RVA: 0x00056B3C File Offset: 0x00054D3C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000DE2 RID: 3554
		// (get) Token: 0x06002CC9 RID: 11465 RVA: 0x00056B48 File Offset: 0x00054D48
		[ProtoMember(2, Name = "photograph_effect", DataFormat = DataFormat.TwosComplement)]
		public List<uint> photograph_effect
		{
			get
			{
				return this._photograph_effect;
			}
		}

		// Token: 0x17000DE3 RID: 3555
		// (get) Token: 0x06002CCA RID: 11466 RVA: 0x00056B60 File Offset: 0x00054D60
		// (set) Token: 0x06002CCB RID: 11467 RVA: 0x00056B8C File Offset: 0x00054D8C
		[ProtoMember(3, IsRequired = false, Name = "charm", DataFormat = DataFormat.TwosComplement)]
		public uint charm
		{
			get
			{
				return this._charm ?? 0U;
			}
			set
			{
				this._charm = new uint?(value);
			}
		}

		// Token: 0x17000DE4 RID: 3556
		// (get) Token: 0x06002CCC RID: 11468 RVA: 0x00056B9C File Offset: 0x00054D9C
		// (set) Token: 0x06002CCD RID: 11469 RVA: 0x00056BBC File Offset: 0x00054DBC
		[XmlIgnore]
		[Browsable(false)]
		public bool charmSpecified
		{
			get
			{
				return this._charm != null;
			}
			set
			{
				bool flag = value == (this._charm == null);
				if (flag)
				{
					this._charm = (value ? new uint?(this.charm) : null);
				}
			}
		}

		// Token: 0x06002CCE RID: 11470 RVA: 0x00056C00 File Offset: 0x00054E00
		private bool ShouldSerializecharm()
		{
			return this.charmSpecified;
		}

		// Token: 0x06002CCF RID: 11471 RVA: 0x00056C18 File Offset: 0x00054E18
		private void Resetcharm()
		{
			this.charmSpecified = false;
		}

		// Token: 0x06002CD0 RID: 11472 RVA: 0x00056C24 File Offset: 0x00054E24
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B15 RID: 2837
		private ErrorCode? _result;

		// Token: 0x04000B16 RID: 2838
		private readonly List<uint> _photograph_effect = new List<uint>();

		// Token: 0x04000B17 RID: 2839
		private uint? _charm;

		// Token: 0x04000B18 RID: 2840
		private IExtension extensionObject;
	}
}

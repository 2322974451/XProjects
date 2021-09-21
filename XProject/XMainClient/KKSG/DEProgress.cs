using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006A6 RID: 1702
	[ProtoContract(Name = "DEProgress")]
	[Serializable]
	public class DEProgress : IExtensible
	{
		// Token: 0x17002321 RID: 8993
		// (get) Token: 0x06006EF9 RID: 28409 RVA: 0x000D45C0 File Offset: 0x000D27C0
		// (set) Token: 0x06006EFA RID: 28410 RVA: 0x000D45EC File Offset: 0x000D27EC
		[ProtoMember(1, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public uint sceneID
		{
			get
			{
				return this._sceneID ?? 0U;
			}
			set
			{
				this._sceneID = new uint?(value);
			}
		}

		// Token: 0x17002322 RID: 8994
		// (get) Token: 0x06006EFB RID: 28411 RVA: 0x000D45FC File Offset: 0x000D27FC
		// (set) Token: 0x06006EFC RID: 28412 RVA: 0x000D461C File Offset: 0x000D281C
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneIDSpecified
		{
			get
			{
				return this._sceneID != null;
			}
			set
			{
				bool flag = value == (this._sceneID == null);
				if (flag)
				{
					this._sceneID = (value ? new uint?(this.sceneID) : null);
				}
			}
		}

		// Token: 0x06006EFD RID: 28413 RVA: 0x000D4660 File Offset: 0x000D2860
		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		// Token: 0x06006EFE RID: 28414 RVA: 0x000D4678 File Offset: 0x000D2878
		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		// Token: 0x17002323 RID: 8995
		// (get) Token: 0x06006EFF RID: 28415 RVA: 0x000D4684 File Offset: 0x000D2884
		// (set) Token: 0x06006F00 RID: 28416 RVA: 0x000D46B0 File Offset: 0x000D28B0
		[ProtoMember(2, IsRequired = false, Name = "bossavghppercent", DataFormat = DataFormat.TwosComplement)]
		public int bossavghppercent
		{
			get
			{
				return this._bossavghppercent ?? 0;
			}
			set
			{
				this._bossavghppercent = new int?(value);
			}
		}

		// Token: 0x17002324 RID: 8996
		// (get) Token: 0x06006F01 RID: 28417 RVA: 0x000D46C0 File Offset: 0x000D28C0
		// (set) Token: 0x06006F02 RID: 28418 RVA: 0x000D46E0 File Offset: 0x000D28E0
		[XmlIgnore]
		[Browsable(false)]
		public bool bossavghppercentSpecified
		{
			get
			{
				return this._bossavghppercent != null;
			}
			set
			{
				bool flag = value == (this._bossavghppercent == null);
				if (flag)
				{
					this._bossavghppercent = (value ? new int?(this.bossavghppercent) : null);
				}
			}
		}

		// Token: 0x06006F03 RID: 28419 RVA: 0x000D4724 File Offset: 0x000D2924
		private bool ShouldSerializebossavghppercent()
		{
			return this.bossavghppercentSpecified;
		}

		// Token: 0x06006F04 RID: 28420 RVA: 0x000D473C File Offset: 0x000D293C
		private void Resetbossavghppercent()
		{
			this.bossavghppercentSpecified = false;
		}

		// Token: 0x17002325 RID: 8997
		// (get) Token: 0x06006F05 RID: 28421 RVA: 0x000D4748 File Offset: 0x000D2948
		// (set) Token: 0x06006F06 RID: 28422 RVA: 0x000D4774 File Offset: 0x000D2974
		[ProtoMember(3, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public DEProgressState state
		{
			get
			{
				return this._state ?? DEProgressState.DEPS_FINISH;
			}
			set
			{
				this._state = new DEProgressState?(value);
			}
		}

		// Token: 0x17002326 RID: 8998
		// (get) Token: 0x06006F07 RID: 28423 RVA: 0x000D4784 File Offset: 0x000D2984
		// (set) Token: 0x06006F08 RID: 28424 RVA: 0x000D47A4 File Offset: 0x000D29A4
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
					this._state = (value ? new DEProgressState?(this.state) : null);
				}
			}
		}

		// Token: 0x06006F09 RID: 28425 RVA: 0x000D47E8 File Offset: 0x000D29E8
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06006F0A RID: 28426 RVA: 0x000D4800 File Offset: 0x000D2A00
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x06006F0B RID: 28427 RVA: 0x000D480C File Offset: 0x000D2A0C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A8E RID: 6798
		private uint? _sceneID;

		// Token: 0x04001A8F RID: 6799
		private int? _bossavghppercent;

		// Token: 0x04001A90 RID: 6800
		private DEProgressState? _state;

		// Token: 0x04001A91 RID: 6801
		private IExtension extensionObject;
	}
}

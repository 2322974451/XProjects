using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004A9 RID: 1193
	[ProtoContract(Name = "EnterBattleReadySceneArg")]
	[Serializable]
	public class EnterBattleReadySceneArg : IExtensible
	{
		// Token: 0x170012FD RID: 4861
		// (get) Token: 0x06003DFE RID: 15870 RVA: 0x0007642C File Offset: 0x0007462C
		// (set) Token: 0x06003DFF RID: 15871 RVA: 0x00076458 File Offset: 0x00074658
		[ProtoMember(1, IsRequired = false, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public uint param
		{
			get
			{
				return this._param ?? 0U;
			}
			set
			{
				this._param = new uint?(value);
			}
		}

		// Token: 0x170012FE RID: 4862
		// (get) Token: 0x06003E00 RID: 15872 RVA: 0x00076468 File Offset: 0x00074668
		// (set) Token: 0x06003E01 RID: 15873 RVA: 0x00076488 File Offset: 0x00074688
		[XmlIgnore]
		[Browsable(false)]
		public bool paramSpecified
		{
			get
			{
				return this._param != null;
			}
			set
			{
				bool flag = value == (this._param == null);
				if (flag)
				{
					this._param = (value ? new uint?(this.param) : null);
				}
			}
		}

		// Token: 0x06003E02 RID: 15874 RVA: 0x000764CC File Offset: 0x000746CC
		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		// Token: 0x06003E03 RID: 15875 RVA: 0x000764E4 File Offset: 0x000746E4
		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		// Token: 0x06003E04 RID: 15876 RVA: 0x000764F0 File Offset: 0x000746F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F71 RID: 3953
		private uint? _param;

		// Token: 0x04000F72 RID: 3954
		private IExtension extensionObject;
	}
}

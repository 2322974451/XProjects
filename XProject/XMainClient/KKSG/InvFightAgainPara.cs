using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004A8 RID: 1192
	[ProtoContract(Name = "InvFightAgainPara")]
	[Serializable]
	public class InvFightAgainPara : IExtensible
	{
		// Token: 0x170012FC RID: 4860
		// (get) Token: 0x06003DFA RID: 15866 RVA: 0x000763E8 File Offset: 0x000745E8
		// (set) Token: 0x06003DFB RID: 15867 RVA: 0x00076400 File Offset: 0x00074600
		[ProtoMember(1, IsRequired = false, Name = "data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CreateCrossBattleSceneArg data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}

		// Token: 0x06003DFC RID: 15868 RVA: 0x0007640C File Offset: 0x0007460C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F6F RID: 3951
		private CreateCrossBattleSceneArg _data = null;

		// Token: 0x04000F70 RID: 3952
		private IExtension extensionObject;
	}
}

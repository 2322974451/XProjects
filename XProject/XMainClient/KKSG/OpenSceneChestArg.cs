using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000BE RID: 190
	[ProtoContract(Name = "OpenSceneChestArg")]
	[Serializable]
	public class OpenSceneChestArg : IExtensible
	{
		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x06000CC8 RID: 3272 RVA: 0x0001AE2C File Offset: 0x0001902C
		// (set) Token: 0x06000CC9 RID: 3273 RVA: 0x0001AE58 File Offset: 0x00019058
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

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x06000CCA RID: 3274 RVA: 0x0001AE68 File Offset: 0x00019068
		// (set) Token: 0x06000CCB RID: 3275 RVA: 0x0001AE88 File Offset: 0x00019088
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

		// Token: 0x06000CCC RID: 3276 RVA: 0x0001AECC File Offset: 0x000190CC
		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		// Token: 0x06000CCD RID: 3277 RVA: 0x0001AEE4 File Offset: 0x000190E4
		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		// Token: 0x06000CCE RID: 3278 RVA: 0x0001AEF0 File Offset: 0x000190F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400032D RID: 813
		private uint? _sceneID;

		// Token: 0x0400032E RID: 814
		private IExtension extensionObject;
	}
}

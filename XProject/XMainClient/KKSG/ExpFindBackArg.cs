using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000105 RID: 261
	[ProtoContract(Name = "ExpFindBackArg")]
	[Serializable]
	public class ExpFindBackArg : IExtensible
	{
		// Token: 0x17000561 RID: 1377
		// (get) Token: 0x060010B2 RID: 4274 RVA: 0x00022360 File Offset: 0x00020560
		// (set) Token: 0x060010B3 RID: 4275 RVA: 0x0002238C File Offset: 0x0002058C
		[ProtoMember(1, IsRequired = false, Name = "isFree", DataFormat = DataFormat.Default)]
		public bool isFree
		{
			get
			{
				return this._isFree ?? false;
			}
			set
			{
				this._isFree = new bool?(value);
			}
		}

		// Token: 0x17000562 RID: 1378
		// (get) Token: 0x060010B4 RID: 4276 RVA: 0x0002239C File Offset: 0x0002059C
		// (set) Token: 0x060010B5 RID: 4277 RVA: 0x000223BC File Offset: 0x000205BC
		[XmlIgnore]
		[Browsable(false)]
		public bool isFreeSpecified
		{
			get
			{
				return this._isFree != null;
			}
			set
			{
				bool flag = value == (this._isFree == null);
				if (flag)
				{
					this._isFree = (value ? new bool?(this.isFree) : null);
				}
			}
		}

		// Token: 0x060010B6 RID: 4278 RVA: 0x00022400 File Offset: 0x00020600
		private bool ShouldSerializeisFree()
		{
			return this.isFreeSpecified;
		}

		// Token: 0x060010B7 RID: 4279 RVA: 0x00022418 File Offset: 0x00020618
		private void ResetisFree()
		{
			this.isFreeSpecified = false;
		}

		// Token: 0x060010B8 RID: 4280 RVA: 0x00022424 File Offset: 0x00020624
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400042D RID: 1069
		private bool? _isFree;

		// Token: 0x0400042E RID: 1070
		private IExtension extensionObject;
	}
}

using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000407 RID: 1031
	[ProtoContract(Name = "ChangeLiveVisibleArg")]
	[Serializable]
	public class ChangeLiveVisibleArg : IExtensible
	{
		// Token: 0x170010E4 RID: 4324
		// (get) Token: 0x060036ED RID: 14061 RVA: 0x00069380 File Offset: 0x00067580
		// (set) Token: 0x060036EE RID: 14062 RVA: 0x000693AC File Offset: 0x000675AC
		[ProtoMember(1, IsRequired = false, Name = "visible", DataFormat = DataFormat.Default)]
		public bool visible
		{
			get
			{
				return this._visible ?? false;
			}
			set
			{
				this._visible = new bool?(value);
			}
		}

		// Token: 0x170010E5 RID: 4325
		// (get) Token: 0x060036EF RID: 14063 RVA: 0x000693BC File Offset: 0x000675BC
		// (set) Token: 0x060036F0 RID: 14064 RVA: 0x000693DC File Offset: 0x000675DC
		[XmlIgnore]
		[Browsable(false)]
		public bool visibleSpecified
		{
			get
			{
				return this._visible != null;
			}
			set
			{
				bool flag = value == (this._visible == null);
				if (flag)
				{
					this._visible = (value ? new bool?(this.visible) : null);
				}
			}
		}

		// Token: 0x060036F1 RID: 14065 RVA: 0x00069420 File Offset: 0x00067620
		private bool ShouldSerializevisible()
		{
			return this.visibleSpecified;
		}

		// Token: 0x060036F2 RID: 14066 RVA: 0x00069438 File Offset: 0x00067638
		private void Resetvisible()
		{
			this.visibleSpecified = false;
		}

		// Token: 0x060036F3 RID: 14067 RVA: 0x00069444 File Offset: 0x00067644
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D9E RID: 3486
		private bool? _visible;

		// Token: 0x04000D9F RID: 3487
		private IExtension extensionObject;
	}
}

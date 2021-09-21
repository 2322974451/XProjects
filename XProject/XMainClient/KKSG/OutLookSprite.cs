using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000576 RID: 1398
	[ProtoContract(Name = "OutLookSprite")]
	[Serializable]
	public class OutLookSprite : IExtensible
	{
		// Token: 0x17001619 RID: 5657
		// (get) Token: 0x0600481C RID: 18460 RVA: 0x00088F98 File Offset: 0x00087198
		// (set) Token: 0x0600481D RID: 18461 RVA: 0x00088FC4 File Offset: 0x000871C4
		[ProtoMember(1, IsRequired = false, Name = "leaderid", DataFormat = DataFormat.TwosComplement)]
		public uint leaderid
		{
			get
			{
				return this._leaderid ?? 0U;
			}
			set
			{
				this._leaderid = new uint?(value);
			}
		}

		// Token: 0x1700161A RID: 5658
		// (get) Token: 0x0600481E RID: 18462 RVA: 0x00088FD4 File Offset: 0x000871D4
		// (set) Token: 0x0600481F RID: 18463 RVA: 0x00088FF4 File Offset: 0x000871F4
		[XmlIgnore]
		[Browsable(false)]
		public bool leaderidSpecified
		{
			get
			{
				return this._leaderid != null;
			}
			set
			{
				bool flag = value == (this._leaderid == null);
				if (flag)
				{
					this._leaderid = (value ? new uint?(this.leaderid) : null);
				}
			}
		}

		// Token: 0x06004820 RID: 18464 RVA: 0x00089038 File Offset: 0x00087238
		private bool ShouldSerializeleaderid()
		{
			return this.leaderidSpecified;
		}

		// Token: 0x06004821 RID: 18465 RVA: 0x00089050 File Offset: 0x00087250
		private void Resetleaderid()
		{
			this.leaderidSpecified = false;
		}

		// Token: 0x06004822 RID: 18466 RVA: 0x0008905C File Offset: 0x0008725C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001208 RID: 4616
		private uint? _leaderid;

		// Token: 0x04001209 RID: 4617
		private IExtension extensionObject;
	}
}

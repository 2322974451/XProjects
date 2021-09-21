using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000A3 RID: 163
	[ProtoContract(Name = "ChangeGuildPositionArg")]
	[Serializable]
	public class ChangeGuildPositionArg : IExtensible
	{
		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06000B31 RID: 2865 RVA: 0x00017F7C File Offset: 0x0001617C
		// (set) Token: 0x06000B32 RID: 2866 RVA: 0x00017FA9 File Offset: 0x000161A9
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x06000B33 RID: 2867 RVA: 0x00017FB8 File Offset: 0x000161B8
		// (set) Token: 0x06000B34 RID: 2868 RVA: 0x00017FD8 File Offset: 0x000161D8
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x0001801C File Offset: 0x0001621C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x00018034 File Offset: 0x00016234
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x06000B37 RID: 2871 RVA: 0x00018040 File Offset: 0x00016240
		// (set) Token: 0x06000B38 RID: 2872 RVA: 0x0001806C File Offset: 0x0001626C
		[ProtoMember(2, IsRequired = false, Name = "position", DataFormat = DataFormat.TwosComplement)]
		public int position
		{
			get
			{
				return this._position ?? 0;
			}
			set
			{
				this._position = new int?(value);
			}
		}

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x06000B39 RID: 2873 RVA: 0x0001807C File Offset: 0x0001627C
		// (set) Token: 0x06000B3A RID: 2874 RVA: 0x0001809C File Offset: 0x0001629C
		[XmlIgnore]
		[Browsable(false)]
		public bool positionSpecified
		{
			get
			{
				return this._position != null;
			}
			set
			{
				bool flag = value == (this._position == null);
				if (flag)
				{
					this._position = (value ? new int?(this.position) : null);
				}
			}
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x000180E0 File Offset: 0x000162E0
		private bool ShouldSerializeposition()
		{
			return this.positionSpecified;
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x000180F8 File Offset: 0x000162F8
		private void Resetposition()
		{
			this.positionSpecified = false;
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x00018104 File Offset: 0x00016304
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002CE RID: 718
		private ulong? _roleid;

		// Token: 0x040002CF RID: 719
		private int? _position;

		// Token: 0x040002D0 RID: 720
		private IExtension extensionObject;
	}
}

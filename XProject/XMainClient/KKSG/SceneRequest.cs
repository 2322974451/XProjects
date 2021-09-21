using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200000C RID: 12
	[ProtoContract(Name = "SceneRequest")]
	[Serializable]
	public class SceneRequest : IExtensible
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00003C14 File Offset: 0x00001E14
		// (set) Token: 0x06000097 RID: 151 RVA: 0x00003C40 File Offset: 0x00001E40
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

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00003C50 File Offset: 0x00001E50
		// (set) Token: 0x06000099 RID: 153 RVA: 0x00003C70 File Offset: 0x00001E70
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

		// Token: 0x0600009A RID: 154 RVA: 0x00003CB4 File Offset: 0x00001EB4
		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00003CCC File Offset: 0x00001ECC
		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600009C RID: 156 RVA: 0x00003CD8 File Offset: 0x00001ED8
		// (set) Token: 0x0600009D RID: 157 RVA: 0x00003D05 File Offset: 0x00001F05
		[ProtoMember(2, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600009E RID: 158 RVA: 0x00003D14 File Offset: 0x00001F14
		// (set) Token: 0x0600009F RID: 159 RVA: 0x00003D34 File Offset: 0x00001F34
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003D78 File Offset: 0x00001F78
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003D90 File Offset: 0x00001F90
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x00003D9C File Offset: 0x00001F9C
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x00003DC8 File Offset: 0x00001FC8
		[ProtoMember(3, IsRequired = false, Name = "fortID", DataFormat = DataFormat.TwosComplement)]
		public uint fortID
		{
			get
			{
				return this._fortID ?? 0U;
			}
			set
			{
				this._fortID = new uint?(value);
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00003DD8 File Offset: 0x00001FD8
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x00003DF8 File Offset: 0x00001FF8
		[XmlIgnore]
		[Browsable(false)]
		public bool fortIDSpecified
		{
			get
			{
				return this._fortID != null;
			}
			set
			{
				bool flag = value == (this._fortID == null);
				if (flag)
				{
					this._fortID = (value ? new uint?(this.fortID) : null);
				}
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00003E3C File Offset: 0x0000203C
		private bool ShouldSerializefortID()
		{
			return this.fortIDSpecified;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003E54 File Offset: 0x00002054
		private void ResetfortID()
		{
			this.fortIDSpecified = false;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003E60 File Offset: 0x00002060
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400002D RID: 45
		private uint? _sceneID;

		// Token: 0x0400002E RID: 46
		private ulong? _roleID;

		// Token: 0x0400002F RID: 47
		private uint? _fortID;

		// Token: 0x04000030 RID: 48
		private IExtension extensionObject;
	}
}

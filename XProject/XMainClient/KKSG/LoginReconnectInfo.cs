using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005BB RID: 1467
	[ProtoContract(Name = "LoginReconnectInfo")]
	[Serializable]
	public class LoginReconnectInfo : IExtensible
	{
		// Token: 0x17001948 RID: 6472
		// (get) Token: 0x060051CD RID: 20941 RVA: 0x0009B904 File Offset: 0x00099B04
		// (set) Token: 0x060051CE RID: 20942 RVA: 0x0009B930 File Offset: 0x00099B30
		[ProtoMember(1, IsRequired = false, Name = "scenetemplateid", DataFormat = DataFormat.TwosComplement)]
		public uint scenetemplateid
		{
			get
			{
				return this._scenetemplateid ?? 0U;
			}
			set
			{
				this._scenetemplateid = new uint?(value);
			}
		}

		// Token: 0x17001949 RID: 6473
		// (get) Token: 0x060051CF RID: 20943 RVA: 0x0009B940 File Offset: 0x00099B40
		// (set) Token: 0x060051D0 RID: 20944 RVA: 0x0009B960 File Offset: 0x00099B60
		[XmlIgnore]
		[Browsable(false)]
		public bool scenetemplateidSpecified
		{
			get
			{
				return this._scenetemplateid != null;
			}
			set
			{
				bool flag = value == (this._scenetemplateid == null);
				if (flag)
				{
					this._scenetemplateid = (value ? new uint?(this.scenetemplateid) : null);
				}
			}
		}

		// Token: 0x060051D1 RID: 20945 RVA: 0x0009B9A4 File Offset: 0x00099BA4
		private bool ShouldSerializescenetemplateid()
		{
			return this.scenetemplateidSpecified;
		}

		// Token: 0x060051D2 RID: 20946 RVA: 0x0009B9BC File Offset: 0x00099BBC
		private void Resetscenetemplateid()
		{
			this.scenetemplateidSpecified = false;
		}

		// Token: 0x1700194A RID: 6474
		// (get) Token: 0x060051D3 RID: 20947 RVA: 0x0009B9C8 File Offset: 0x00099BC8
		// (set) Token: 0x060051D4 RID: 20948 RVA: 0x0009B9F4 File Offset: 0x00099BF4
		[ProtoMember(2, IsRequired = false, Name = "scenetime", DataFormat = DataFormat.TwosComplement)]
		public uint scenetime
		{
			get
			{
				return this._scenetime ?? 0U;
			}
			set
			{
				this._scenetime = new uint?(value);
			}
		}

		// Token: 0x1700194B RID: 6475
		// (get) Token: 0x060051D5 RID: 20949 RVA: 0x0009BA04 File Offset: 0x00099C04
		// (set) Token: 0x060051D6 RID: 20950 RVA: 0x0009BA24 File Offset: 0x00099C24
		[XmlIgnore]
		[Browsable(false)]
		public bool scenetimeSpecified
		{
			get
			{
				return this._scenetime != null;
			}
			set
			{
				bool flag = value == (this._scenetime == null);
				if (flag)
				{
					this._scenetime = (value ? new uint?(this.scenetime) : null);
				}
			}
		}

		// Token: 0x060051D7 RID: 20951 RVA: 0x0009BA68 File Offset: 0x00099C68
		private bool ShouldSerializescenetime()
		{
			return this.scenetimeSpecified;
		}

		// Token: 0x060051D8 RID: 20952 RVA: 0x0009BA80 File Offset: 0x00099C80
		private void Resetscenetime()
		{
			this.scenetimeSpecified = false;
		}

		// Token: 0x060051D9 RID: 20953 RVA: 0x0009BA8C File Offset: 0x00099C8C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001406 RID: 5126
		private uint? _scenetemplateid;

		// Token: 0x04001407 RID: 5127
		private uint? _scenetime;

		// Token: 0x04001408 RID: 5128
		private IExtension extensionObject;
	}
}

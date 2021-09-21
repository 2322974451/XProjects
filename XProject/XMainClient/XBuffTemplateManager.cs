using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DB8 RID: 3512
	internal class XBuffTemplateManager : XSingleton<XBuffTemplateManager>
	{
		// Token: 0x0600BE55 RID: 48725 RVA: 0x0027AEE0 File Offset: 0x002790E0
		public int GetBuffKey(int buffID, int buffLevel)
		{
			return buffID << 8 | buffLevel;
		}

		// Token: 0x0600BE56 RID: 48726 RVA: 0x0027AEF7 File Offset: 0x002790F7
		public void GetBuffIdentity(int buffKey, out int buffID, out int buffLevel)
		{
			buffID = buffKey >> 8;
			buffLevel = (buffKey & 15);
		}

		// Token: 0x0600BE57 RID: 48727 RVA: 0x0027AF08 File Offset: 0x00279108
		public override bool Init()
		{
			bool flag = this._async_loader == null;
			if (flag)
			{
				this._async_loader = new XTableAsyncLoader();
				this._async_loader.AddTask("Table/BuffList", this.m_BuffConfig, false);
				this._async_loader.AddTask("Table/BuffListPVP", this.m_BuffConfigPVP, false);
				this._async_loader.Execute(null);
			}
			bool flag2 = !this._async_loader.IsDone;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < this.m_BuffConfig.Table.Length; i++)
				{
					BuffTable.RowData rowData = this.m_BuffConfig.Table[i];
					int buffKey = this.GetBuffKey(rowData.BuffID, (int)rowData.BuffLevel);
					this.m_BuffIndex.Add(buffKey, rowData);
				}
				this.m_BuffConfig.Clear();
				for (int j = 0; j < this.m_BuffConfigPVP.Table.Length; j++)
				{
					BuffTable.RowData rowData2 = this.m_BuffConfigPVP.Table[j];
					int buffKey2 = this.GetBuffKey(rowData2.BuffID, (int)rowData2.BuffLevel);
					this.m_BuffIndexPVP.Add(buffKey2, rowData2);
				}
				this.m_BuffConfigPVP.Clear();
				result = true;
			}
			return result;
		}

		// Token: 0x0600BE58 RID: 48728 RVA: 0x0027B052 File Offset: 0x00279252
		public override void Uninit()
		{
			this.m_BuffIndex.Clear();
			this.m_BuffIndexPVP.Clear();
			this._async_loader = null;
		}

		// Token: 0x0600BE59 RID: 48729 RVA: 0x0027B074 File Offset: 0x00279274
		private bool CanUseBuff(int sceneType, BuffTable.RowData row)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = row.SceneEffect != null && row.SceneEffect.Length != 0;
			if (flag5)
			{
				for (int i = 0; i < row.SceneEffect.Length; i++)
				{
					int num = (int)row.SceneEffect[i];
					bool flag6 = num > 0;
					if (flag6)
					{
						flag4 = true;
						bool flag7 = num == sceneType;
						if (flag7)
						{
							flag2 = true;
						}
					}
					else
					{
						flag3 = true;
						bool flag8 = -num == sceneType;
						if (flag8)
						{
							flag = true;
						}
					}
				}
			}
			bool flag9 = flag4 && flag2;
			bool result;
			if (flag9)
			{
				result = true;
			}
			else
			{
				bool flag10 = flag3 && !flag;
				result = (flag10 || (!flag4 && !flag3));
			}
			return result;
		}

		// Token: 0x0600BE5A RID: 48730 RVA: 0x0027B138 File Offset: 0x00279338
		public XBuff CreateBuff(BuffDesc buffDesc, CombatEffectHelper pEffectHelper)
		{
			int sceneType = XFastEnumIntEqualityComparer<SceneType>.ToInt(XSingleton<XScene>.singleton.SceneType);
			int buffKey = this.GetBuffKey(buffDesc.BuffID, buffDesc.BuffLevel);
			BuffTable.RowData row = null;
			bool flag = true;
			bool flag2 = this.m_BuffIndexPVP.TryGetValue(buffKey, out row);
			if (flag2)
			{
				flag = this.CanUseBuff(sceneType, row);
			}
			row = null;
			bool flag3 = true;
			bool flag4 = this.m_BuffIndex.TryGetValue(buffKey, out row);
			if (flag4)
			{
				flag3 = this.CanUseBuff(sceneType, row);
			}
			bool flag5 = !flag || !flag3;
			XBuff result;
			if (flag5)
			{
				result = null;
			}
			else
			{
				result = new XBuff(pEffectHelper, ref buffDesc);
			}
			return result;
		}

		// Token: 0x0600BE5B RID: 48731 RVA: 0x0027B1D8 File Offset: 0x002793D8
		public int GetBuffTargetType(int BuffID)
		{
			BuffTable.RowData buffData = this.GetBuffData(BuffID, 1);
			bool flag = buffData == null;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				result = (int)buffData.TargetType;
			}
			return result;
		}

		// Token: 0x0600BE5C RID: 48732 RVA: 0x0027B208 File Offset: 0x00279408
		public BuffTable.RowData GetBuffData(int BuffID, int BuffLevel)
		{
			BuffTable.RowData rowData = null;
			int buffKey = this.GetBuffKey(BuffID, BuffLevel);
			bool isPVPScene = XSingleton<XScene>.singleton.IsPVPScene;
			if (isPVPScene)
			{
				this.m_BuffIndexPVP.TryGetValue(buffKey, out rowData);
			}
			bool flag = rowData == null && !this.m_BuffIndex.TryGetValue(buffKey, out rowData);
			BuffTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = rowData;
			}
			return result;
		}

		// Token: 0x04004DBC RID: 19900
		private XTableAsyncLoader _async_loader = null;

		// Token: 0x04004DBD RID: 19901
		private BuffTable m_BuffConfig = new BuffTable();

		// Token: 0x04004DBE RID: 19902
		private BuffTable m_BuffConfigPVP = new BuffTable();

		// Token: 0x04004DBF RID: 19903
		private Dictionary<int, BuffTable.RowData> m_BuffIndex = new Dictionary<int, BuffTable.RowData>();

		// Token: 0x04004DC0 RID: 19904
		private Dictionary<int, BuffTable.RowData> m_BuffIndexPVP = new Dictionary<int, BuffTable.RowData>();

		// Token: 0x020019C0 RID: 6592
		private enum BuffTypeEM
		{
			// Token: 0x04007FBF RID: 32703
			BUFFTYPE_CHANGE_ATTRIBUTE = 1,
			// Token: 0x04007FC0 RID: 32704
			BUFFTYPE_CHANGE_STATUS,
			// Token: 0x04007FC1 RID: 32705
			BUFFTYPE_STUN
		}
	}
}

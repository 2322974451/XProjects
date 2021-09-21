using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B08 RID: 2824
	internal class XCombatEffectManager : XSingleton<XCombatEffectManager>
	{
		// Token: 0x0600A657 RID: 42583 RVA: 0x001D38A5 File Offset: 0x001D1AA5
		public void SetDirty()
		{
			this.m_bDirty = true;
		}

		// Token: 0x0600A658 RID: 42584 RVA: 0x001D38B0 File Offset: 0x001D1AB0
		public override bool Init()
		{
			this.SetDirty();
			return true;
		}

		// Token: 0x0600A659 RID: 42585 RVA: 0x001D38CC File Offset: 0x001D1ACC
		public void InitFromGlobalConfig()
		{
			this.m_ArtifactDisableSceneTypes.Clear();
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("ArtifactDisableSceneTypes");
			bool flag = !string.IsNullOrEmpty(value);
			if (flag)
			{
				string[] array = value.Split(XGlobalConfig.ListSeparator);
				for (int i = 0; i < array.Length; i++)
				{
					this.m_ArtifactDisableSceneTypes.Add((SceneType)int.Parse(array[i]));
				}
			}
			this.m_SkillEmblemDisableSceneTypes.Clear();
			value = XSingleton<XGlobalConfig>.singleton.GetValue("SkillEmblemDisableSceneTypes");
			bool flag2 = !string.IsNullOrEmpty(value);
			if (flag2)
			{
				string[] array2 = value.Split(XGlobalConfig.ListSeparator);
				for (int j = 0; j < array2.Length; j++)
				{
					this.m_SkillEmblemDisableSceneTypes.Add((SceneType)int.Parse(array2[j]));
				}
			}
		}

		// Token: 0x0600A65A RID: 42586 RVA: 0x001D39A8 File Offset: 0x001D1BA8
		public bool IsArtifactEnabled()
		{
			return !this.m_ArtifactDisableSceneTypes.Contains(XSingleton<XScene>.singleton.SceneType);
		}

		// Token: 0x0600A65B RID: 42587 RVA: 0x001D39D4 File Offset: 0x001D1BD4
		public bool IsSkillEmblemEnabled()
		{
			return !this.m_SkillEmblemDisableSceneTypes.Contains(XSingleton<XScene>.singleton.SceneType);
		}

		// Token: 0x0600A65C RID: 42588 RVA: 0x001D3A00 File Offset: 0x001D1C00
		public EffectDataParams GetEffectDataByBuff(uint buffID)
		{
			EffectDataParams result;
			this.m_buff2EffectData.TryGetValue(buffID, out result);
			return result;
		}

		// Token: 0x0600A65D RID: 42589 RVA: 0x001D3A24 File Offset: 0x001D1C24
		public EffectDataParams GetEffectDataBySkill(uint skillID)
		{
			EffectDataParams result;
			this.m_skill2EffectData.TryGetValue(skillID, out result);
			return result;
		}

		// Token: 0x0600A65E RID: 42590 RVA: 0x001D3A48 File Offset: 0x001D1C48
		public void ArrangeEffectData()
		{
			bool flag = !this.m_bDirty || !XStage.IsConcreteStage(XSingleton<XGame>.singleton.CurrentStage.Stage);
			if (!flag)
			{
				this.m_bDirty = false;
				foreach (KeyValuePair<uint, EffectDataParams> keyValuePair in this.m_buff2EffectData)
				{
					keyValuePair.Value.Recycle();
				}
				foreach (KeyValuePair<uint, EffectDataParams> keyValuePair2 in this.m_skill2EffectData)
				{
					keyValuePair2.Value.Recycle();
				}
				this.m_buff2EffectData.Clear();
				this.m_skill2EffectData.Clear();
				XBagDocument specificDocument = XDocuments.GetSpecificDocument<XBagDocument>(XBagDocument.uuID);
				ArtifactDocument specificDocument2 = XDocuments.GetSpecificDocument<ArtifactDocument>(ArtifactDocument.uuID);
				XBodyBag artifactBag = specificDocument.ArtifactBag;
				for (int i = 0; i < XBagDocument.ArtifactMax; i++)
				{
					XArtifactItem xartifactItem = artifactBag[i] as XArtifactItem;
					bool flag2 = xartifactItem == null || xartifactItem.itemID == 0;
					if (!flag2)
					{
						for (int j = 0; j < xartifactItem.EffectInfoList.Count; j++)
						{
							XArtifactEffectInfo xartifactEffectInfo = xartifactItem.EffectInfoList[j];
							bool flag3 = !xartifactEffectInfo.IsValid;
							if (!flag3)
							{
								for (int k = 0; k < xartifactEffectInfo.BuffInfoList.Count; k++)
								{
									XArtifactBuffInfo xartifactBuffInfo = xartifactEffectInfo.BuffInfoList[k];
									bool flag4 = xartifactBuffInfo.Type == 1U;
									EffectTable.RowData artifactSkillEffect;
									Dictionary<uint, EffectDataParams> dictionary;
									if (flag4)
									{
										artifactSkillEffect = specificDocument2.GetArtifactSkillEffect(xartifactEffectInfo.EffectId, xartifactBuffInfo.Id);
										dictionary = this.m_buff2EffectData;
									}
									else
									{
										artifactSkillEffect = specificDocument2.GetArtifactSkillEffect(xartifactEffectInfo.EffectId, xartifactBuffInfo.Id);
										dictionary = this.m_skill2EffectData;
									}
									bool flag5 = artifactSkillEffect == null;
									if (!flag5)
									{
										EffectDataParams effectDataParams = null;
										bool flag6 = !dictionary.TryGetValue(xartifactBuffInfo.Id, out effectDataParams);
										if (flag6)
										{
											effectDataParams = XDataPool<EffectDataParams>.GetData();
											dictionary.Add(xartifactBuffInfo.Id, effectDataParams);
										}
										Dictionary<CombatEffectType, EffectDataParams.TypeData> dictionary2 = DictionaryPool<CombatEffectType, EffectDataParams.TypeData>.Get();
										int num = 0;
										while (num < (int)artifactSkillEffect.EffectParams.count && num < xartifactBuffInfo.Values.Count)
										{
											CombatEffectType combatEffectType = (CombatEffectType)artifactSkillEffect.EffectParams[num, 0];
											EffectDataParams.TypeData data;
											bool flag7 = !dictionary2.TryGetValue(combatEffectType, out data);
											if (flag7)
											{
												EffectDataParams.TypeDataCollection typeDataCollection = effectDataParams.EnsureGetCollection(combatEffectType);
												data = XDataPool<EffectDataParams.TypeData>.GetData();
												data.effectID = xartifactEffectInfo.EffectId;
												data.templatebuffID = artifactSkillEffect.TemplateBuffID;
												typeDataCollection.datas.Add(data);
												dictionary2[combatEffectType] = data;
											}
											data.randomParams.Add(xartifactBuffInfo.Values[num]);
											num++;
										}
										for (int l = 0; l < (int)artifactSkillEffect.ConstantParams.count; l++)
										{
											uint num2;
											bool flag8 = !uint.TryParse(artifactSkillEffect.ConstantParams[l, 0], out num2);
											if (!flag8)
											{
												CombatEffectType combatEffectType2 = (CombatEffectType)num2;
												EffectDataParams.TypeData data2;
												bool flag9 = !dictionary2.TryGetValue(combatEffectType2, out data2);
												if (flag9)
												{
													EffectDataParams.TypeDataCollection typeDataCollection2 = effectDataParams.EnsureGetCollection(combatEffectType2);
													data2 = XDataPool<EffectDataParams.TypeData>.GetData();
													data2.effectID = xartifactEffectInfo.EffectId;
													data2.templatebuffID = artifactSkillEffect.TemplateBuffID;
													typeDataCollection2.datas.Add(data2);
													dictionary2[combatEffectType2] = data2;
												}
												data2.constantParams.Add(artifactSkillEffect.ConstantParams[l, 1]);
											}
										}
										DictionaryPool<CombatEffectType, EffectDataParams.TypeData>.Release(dictionary2);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x04003D32 RID: 15666
		private Dictionary<uint, EffectDataParams> m_buff2EffectData = new Dictionary<uint, EffectDataParams>();

		// Token: 0x04003D33 RID: 15667
		private Dictionary<uint, EffectDataParams> m_skill2EffectData = new Dictionary<uint, EffectDataParams>();

		// Token: 0x04003D34 RID: 15668
		private HashSet<SceneType> m_ArtifactDisableSceneTypes = new HashSet<SceneType>(default(XFastEnumIntEqualityComparer<SceneType>));

		// Token: 0x04003D35 RID: 15669
		private HashSet<SceneType> m_SkillEmblemDisableSceneTypes = new HashSet<SceneType>(default(XFastEnumIntEqualityComparer<SceneType>));

		// Token: 0x04003D36 RID: 15670
		private bool m_bDirty = false;
	}
}

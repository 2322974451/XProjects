using System;
using System.Collections.Generic;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AD4 RID: 2772
	internal class AINodeFactory
	{
		// Token: 0x0600A5A6 RID: 42406 RVA: 0x001CD56C File Offset: 0x001CB76C
		public static AIRunTimeNodeBase CreateAINodeByName(string nodeName, XmlElement xmlNode)
		{
			bool flag = nodeName == "Selector";
			AIRunTimeNodeBase result;
			if (flag)
			{
				result = new AIRunTimeSelectorNode(xmlNode);
			}
			else
			{
				bool flag2 = nodeName == "Sequence";
				if (flag2)
				{
					result = new AIRunTimeSequenceNode(xmlNode);
				}
				else
				{
					bool flag3 = nodeName == "RandomSequence";
					if (flag3)
					{
						result = new AIRunTimeRandomSequenceNode(xmlNode);
					}
					else
					{
						bool flag4 = nodeName == "RandomSelector";
						if (flag4)
						{
							result = new AIRunTimeRandomSelectorNode(xmlNode);
						}
						else
						{
							bool flag5 = nodeName == "Inverter";
							if (flag5)
							{
								result = new AIRunTimeInverter(xmlNode);
							}
							else
							{
								bool flag6 = nodeName == "EntryTask";
								if (flag6)
								{
									result = new AIRunTimeEntryTaskNode(xmlNode);
								}
								else
								{
									bool flag7 = nodeName == "ReturnSuccess";
									if (flag7)
									{
										result = new AIRunTimeReturnSuccess(xmlNode);
									}
									else
									{
										bool flag8 = nodeName == "ReturnFailure";
										if (flag8)
										{
											result = new AIRunTimeReturnFailure(xmlNode);
										}
										else
										{
											bool flag9 = nodeName == "ConditionalEvaluator";
											if (flag9)
											{
												result = new AIRunTimeConditionalEvaluator(xmlNode);
											}
											else
											{
												bool flag10 = nodeName == "Log";
												if (flag10)
												{
													result = new AIRunTimeLog(xmlNode);
												}
												else
												{
													bool flag11 = nodeName == "RandomFloat";
													if (flag11)
													{
														result = new AIRunTimeRandomFloat(xmlNode);
													}
													else
													{
														bool flag12 = nodeName == "FloatOperator";
														if (flag12)
														{
															result = new AIRunTimeFloatOperator(xmlNode);
														}
														else
														{
															bool flag13 = nodeName == "FloatComparison";
															if (flag13)
															{
																result = new AIRunTimeFloatComparison(xmlNode);
															}
															else
															{
																bool flag14 = nodeName == "SetFloat";
																if (flag14)
																{
																	result = new AIRunTimeSetFloat(xmlNode);
																}
																else
																{
																	bool flag15 = nodeName == "SetBool";
																	if (flag15)
																	{
																		result = new AIRunTimeSetBool(xmlNode);
																	}
																	else
																	{
																		bool flag16 = nodeName == "CompareTo";
																		if (flag16)
																		{
																			result = new AIRunTimeCompareTo(xmlNode);
																		}
																		else
																		{
																			bool flag17 = nodeName == "SetInt";
																			if (flag17)
																			{
																				result = new AIRunTimeSetInt(xmlNode);
																			}
																			else
																			{
																				bool flag18 = nodeName == "IntComparison";
																				if (flag18)
																				{
																					result = new AIRunTimeIntComparison(xmlNode);
																				}
																				else
																				{
																					bool flag19 = nodeName == "IntOperator";
																					if (flag19)
																					{
																						result = new AIRunTimeIntOperator(xmlNode);
																					}
																					else
																					{
																						bool flag20 = nodeName == "BoolComparison";
																						if (flag20)
																						{
																							result = new AIRunTimeBoolComparison(xmlNode);
																						}
																						else
																						{
																							bool flag21 = nodeName == "ValueTarget";
																							if (flag21)
																							{
																								result = new AIRunTimeValueTarget(xmlNode);
																							}
																							else
																							{
																								bool flag22 = nodeName == "ValueDistance";
																								if (flag22)
																								{
																									result = new AIRunTimeValueDistance(xmlNode);
																								}
																								else
																								{
																									bool flag23 = nodeName == "ValueHP";
																									if (flag23)
																									{
																										result = new AIRunTimeValueHP(xmlNode);
																									}
																									else
																									{
																										bool flag24 = nodeName == "ValueMP";
																										if (flag24)
																										{
																											result = new AIRunTimeValueMP(xmlNode);
																										}
																										else
																										{
																											bool flag25 = nodeName == "ValueFP";
																											if (flag25)
																											{
																												result = new AIRunTimeValueFP(xmlNode);
																											}
																											else
																											{
																												bool flag26 = nodeName == "StatusIdle";
																												if (flag26)
																												{
																													result = new AIRunTimeStatusIdle(xmlNode);
																												}
																												else
																												{
																													bool flag27 = nodeName == "NavToTarget";
																													if (flag27)
																													{
																														result = new AIRuntimeNavToTarget(xmlNode);
																													}
																													else
																													{
																														bool flag28 = nodeName == "PhysicalAttack";
																														if (flag28)
																														{
																															result = new AIRuntimePhysicalAttack(xmlNode);
																														}
																														else
																														{
																															bool flag29 = nodeName == "TargetByHatredList";
																															if (flag29)
																															{
																																result = new AIRunTimeTargetByHatredList(xmlNode);
																															}
																															else
																															{
																																bool flag30 = nodeName == "FindTargetByDistance";
																																if (flag30)
																																{
																																	result = new AIRunTimeFindTargetByDist(xmlNode);
																																}
																																else
																																{
																																	bool flag31 = nodeName == "TryCastQTE";
																																	if (flag31)
																																	{
																																		result = new AIRuntimeTryCastQTE(xmlNode);
																																	}
																																	else
																																	{
																																		bool flag32 = nodeName == "CastDash";
																																		if (flag32)
																																		{
																																			result = new AIRuntimeCastDash(xmlNode);
																																		}
																																		else
																																		{
																																			bool flag33 = nodeName == "IsOppoCastingSkill";
																																			if (flag33)
																																			{
																																				result = new AIRunTimeIsOppoCastingSkill(xmlNode);
																																			}
																																			else
																																			{
																																				bool flag34 = nodeName == "IsHurtOppo";
																																				if (flag34)
																																				{
																																					result = new AIRunTimeIsHurtOppo(xmlNode);
																																				}
																																				else
																																				{
																																					bool flag35 = nodeName == "IsFixedInCd";
																																					if (flag35)
																																					{
																																						result = new AIRunTimeIsFixedInCd(xmlNode);
																																					}
																																					else
																																					{
																																						bool flag36 = nodeName == "IsWander";
																																						if (flag36)
																																						{
																																							result = new AIRunTimeIsWander(xmlNode);
																																						}
																																						else
																																						{
																																							bool flag37 = nodeName == "IsCastingSkill";
																																							if (flag37)
																																							{
																																								result = new AIRunTimeIsCastingSkill(xmlNode);
																																							}
																																							else
																																							{
																																								bool flag38 = nodeName == "IsQTEState";
																																								if (flag38)
																																								{
																																									result = new AIRunTimeIsQTEState(xmlNode);
																																								}
																																								else
																																								{
																																									bool flag39 = nodeName == "DetectEnimyInSight";
																																									if (flag39)
																																									{
																																										result = new AIRunTimeDetectEnimyInSight(xmlNode);
																																									}
																																									else
																																									{
																																										bool flag40 = nodeName == "FindTargetByHitLevel";
																																										if (flag40)
																																										{
																																											result = new AIRunTimeFindTargetByHitLevel(xmlNode);
																																										}
																																										else
																																										{
																																											bool flag41 = nodeName == "IsFighting";
																																											if (flag41)
																																											{
																																												result = new AIRunTimeIsFighting(xmlNode);
																																											}
																																											else
																																											{
																																												bool flag42 = nodeName == "DoSelectNearest";
																																												if (flag42)
																																												{
																																													result = new AIRunTimeDoSelectNearest(xmlNode);
																																												}
																																												else
																																												{
																																													bool flag43 = nodeName == "FilterSkill";
																																													if (flag43)
																																													{
																																														result = new AIRuntimeFilterSkill(xmlNode);
																																													}
																																													else
																																													{
																																														bool flag44 = nodeName == "DoSelectSkillInOrder";
																																														if (flag44)
																																														{
																																															result = new AIRuntimeDoSelectSkillInOrder(xmlNode);
																																														}
																																														else
																																														{
																																															bool flag45 = nodeName == "DoSelectSkillRandom";
																																															if (flag45)
																																															{
																																																result = new AIRuntimeDoSelectSkillRandom(xmlNode);
																																															}
																																															else
																																															{
																																																bool flag46 = nodeName == "DoCastSkill";
																																																if (flag46)
																																																{
																																																	result = new AIRuntimeDoCastSkill(xmlNode);
																																																}
																																																else
																																																{
																																																	bool flag47 = nodeName == "SetDest";
																																																	if (flag47)
																																																	{
																																																		result = new AIRuntimeSetDest(xmlNode);
																																																	}
																																																	else
																																																	{
																																																		bool flag48 = nodeName == "ActionMove";
																																																		if (flag48)
																																																		{
																																																			result = new AIRuntimeActionMove(xmlNode);
																																																		}
																																																		else
																																																		{
																																																			bool flag49 = nodeName == "ActionRotate";
																																																			if (flag49)
																																																			{
																																																				result = new AIRuntimeActionRotate(xmlNode);
																																																			}
																																																			else
																																																			{
																																																				bool flag50 = nodeName == "FindNavPath";
																																																				if (flag50)
																																																				{
																																																					result = new AIRunTimeFindNavPath(xmlNode);
																																																				}
																																																				else
																																																				{
																																																					bool flag51 = nodeName == "ReceiveAIEvent";
																																																					if (flag51)
																																																					{
																																																						result = new AIRuntimeReceiveAIEvent(xmlNode);
																																																					}
																																																					else
																																																					{
																																																						bool flag52 = nodeName == "SendAIEvent";
																																																						if (flag52)
																																																						{
																																																							result = new AIRuntimeSendAIEvent(xmlNode);
																																																						}
																																																						else
																																																						{
																																																							bool flag53 = nodeName == "SelectMoveTargetById";
																																																							if (flag53)
																																																							{
																																																								result = new AIRunTimeSelectMoveTargetById(xmlNode);
																																																							}
																																																							else
																																																							{
																																																								bool flag54 = nodeName == "SelectItemTarget";
																																																								if (flag54)
																																																								{
																																																									result = new AIRunTimeSelectItemTarget(xmlNode);
																																																								}
																																																								else
																																																								{
																																																									bool flag55 = nodeName == "SelectBuffTarget";
																																																									if (flag55)
																																																									{
																																																										result = new AIRunTimeSelectBuffTarget(xmlNode);
																																																									}
																																																									else
																																																									{
																																																										bool flag56 = nodeName == "SelectTargetBySkillCircle";
																																																										if (flag56)
																																																										{
																																																											result = new AIRunTimeSelectTargetBySkillCircle(xmlNode);
																																																										}
																																																										else
																																																										{
																																																											bool flag57 = nodeName == "SelectNonHartedList";
																																																											if (flag57)
																																																											{
																																																												result = new AIRunTimeSelectNonHartedList(xmlNode);
																																																											}
																																																											else
																																																											{
																																																												bool flag58 = nodeName == "TargetQTEState";
																																																												if (flag58)
																																																												{
																																																													result = new AIRunTimeTargetQTEState(xmlNode);
																																																												}
																																																												else
																																																												{
																																																													bool flag59 = nodeName == "ResetTargets";
																																																													if (flag59)
																																																													{
																																																														result = new AIRunTimeResetTargets(xmlNode);
																																																													}
																																																													else
																																																													{
																																																														bool flag60 = nodeName == "CallMonster";
																																																														if (flag60)
																																																														{
																																																															result = new AIRuntimeCallMonster(xmlNode);
																																																														}
																																																														else
																																																														{
																																																															bool flag61 = nodeName == "MixMonsterPos";
																																																															if (flag61)
																																																															{
																																																																result = new AIRuntimeMixMonsterPos(xmlNode);
																																																															}
																																																															else
																																																															{
																																																																bool flag62 = nodeName == "KillMonster";
																																																																if (flag62)
																																																																{
																																																																	result = new AIRuntimeKillMonster(xmlNode);
																																																																}
																																																																else
																																																																{
																																																																	bool flag63 = nodeName == "ConditionMonsterNum";
																																																																	if (flag63)
																																																																	{
																																																																		result = new AIRunTimeConditionMonsterNum(xmlNode);
																																																																	}
																																																																	else
																																																																	{
																																																																		bool flag64 = nodeName == "AddBuff";
																																																																		if (flag64)
																																																																		{
																																																																			result = new AIRuntimeAddBuff(xmlNode);
																																																																		}
																																																																		else
																																																																		{
																																																																			bool flag65 = nodeName == "RemoveBuff";
																																																																			if (flag65)
																																																																			{
																																																																				result = new AIRuntimeRemoveBuff(xmlNode);
																																																																			}
																																																																			else
																																																																			{
																																																																				bool flag66 = nodeName == "CallScript";
																																																																				if (flag66)
																																																																				{
																																																																					result = new AIRuntimeCallScript(xmlNode);
																																																																				}
																																																																				else
																																																																				{
																																																																					bool flag67 = nodeName == "IsTargetImmortal";
																																																																					if (flag67)
																																																																					{
																																																																						result = new AIRunTimeIsTargetImmortal(xmlNode);
																																																																					}
																																																																					else
																																																																					{
																																																																						bool flag68 = nodeName == "DetectEnemyInRange";
																																																																						if (flag68)
																																																																						{
																																																																							result = new AIRuntimeDetectEnemyInRange(xmlNode);
																																																																						}
																																																																						else
																																																																						{
																																																																							bool flag69 = nodeName == "StopCastingSkill";
																																																																							if (flag69)
																																																																							{
																																																																								result = new AIRuntimeCancelSkill(xmlNode);
																																																																							}
																																																																							else
																																																																							{
																																																																								bool flag70 = nodeName == "XHashFunc";
																																																																								if (flag70)
																																																																								{
																																																																									result = new AIRuntimeXHashFunc(xmlNode);
																																																																								}
																																																																								else
																																																																								{
																																																																									bool flag71 = nodeName == "RemoveSceneBuff";
																																																																									if (flag71)
																																																																									{
																																																																										result = new AIRuntimeRemoveSceneBuff(xmlNode);
																																																																									}
																																																																									else
																																																																									{
																																																																										bool flag72 = nodeName == "CalDistance";
																																																																										if (flag72)
																																																																										{
																																																																											result = new AIRunTimeCalDistance(xmlNode);
																																																																										}
																																																																										else
																																																																										{
																																																																											bool flag73 = nodeName == "Navigation";
																																																																											if (flag73)
																																																																											{
																																																																												result = new AIRuntimeActionNavigation(xmlNode);
																																																																											}
																																																																											else
																																																																											{
																																																																												bool flag74 = nodeName == "RotateToTarget";
																																																																												if (flag74)
																																																																												{
																																																																													result = new AIRuntimeRotateToTarget(xmlNode);
																																																																												}
																																																																												else
																																																																												{
																																																																													bool flag75 = nodeName == "MoveStratage";
																																																																													if (flag75)
																																																																													{
																																																																														result = new AIRuntimeMoveStratage(xmlNode);
																																																																													}
																																																																													else
																																																																													{
																																																																														bool flag76 = nodeName == "GetRealtimeSinceStartup";
																																																																														if (flag76)
																																																																														{
																																																																															result = new AIRunTimeGetRealtimeSinceStartup(xmlNode);
																																																																														}
																																																																														else
																																																																														{
																																																																															bool flag77 = nodeName == "RandomEntityPos";
																																																																															if (flag77)
																																																																															{
																																																																																result = new AIRunTimeRandomEntityPos(xmlNode);
																																																																															}
																																																																															else
																																																																															{
																																																																																bool flag78 = nodeName == "ConditionPlayerNum";
																																																																																if (flag78)
																																																																																{
																																																																																	result = new AIRunTimeConditionPlayerNum(xmlNode);
																																																																																}
																																																																																else
																																																																																{
																																																																																	bool flag79 = nodeName == "DoSelectFarthest";
																																																																																	if (flag79)
																																																																																	{
																																																																																		result = new AIRunTimeDoSelectFarthest(xmlNode);
																																																																																	}
																																																																																	else
																																																																																	{
																																																																																		bool flag80 = nodeName == "SelectPlayerFromList";
																																																																																		if (flag80)
																																																																																		{
																																																																																			result = new SelectPlayerFromList(xmlNode);
																																																																																		}
																																																																																		else
																																																																																		{
																																																																																			bool flag81 = nodeName == "SetEnmity";
																																																																																			if (flag81)
																																																																																			{
																																																																																				result = new AIRunTimeSetEnmity(xmlNode);
																																																																																			}
																																																																																			else
																																																																																			{
																																																																																				XSingleton<XDebug>.singleton.AddErrorLog("Can't find node: ", nodeName, null, null, null, null);
																																																																																				result = new AIRunTimeNodeBase(xmlNode);
																																																																																			}
																																																																																		}
																																																																																	}
																																																																																}
																																																																															}
																																																																														}
																																																																													}
																																																																												}
																																																																											}
																																																																										}
																																																																									}
																																																																								}
																																																																							}
																																																																						}
																																																																					}
																																																																				}
																																																																			}
																																																																		}
																																																																	}
																																																																}
																																																															}
																																																														}
																																																													}
																																																												}
																																																											}
																																																										}
																																																									}
																																																								}
																																																							}
																																																						}
																																																					}
																																																				}
																																																			}
																																																		}
																																																	}
																																																}
																																															}
																																														}
																																													}
																																												}
																																											}
																																										}
																																									}
																																								}
																																							}
																																						}
																																					}
																																				}
																																			}
																																		}
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x04003CA4 RID: 15524
		private static Dictionary<string, AIRunTimeNodeBase> _node_dic = new Dictionary<string, AIRunTimeNodeBase>();
	}
}

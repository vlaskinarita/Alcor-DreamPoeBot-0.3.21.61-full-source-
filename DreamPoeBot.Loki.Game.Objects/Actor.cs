using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Game.Objects;

public class Actor : NetworkObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct139
	{
		public readonly byte byte_0;

		private readonly byte byte_1;

		private readonly byte byte_2;

		private readonly byte byte_3;

		public readonly int int_0;

		public readonly int int_1;

		public readonly int int_2;

		public readonly NativeVector nativeVector_0;

		public readonly int int_3;

		public readonly int int_4;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct140
	{
		public readonly ushort ushort_0;

		public readonly ushort ushort_1;

		public readonly int int_0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct141
	{
		public IntPtr intptr_0;

		public NativeVector nativeVector_0;
	}

	private bool? nullable_20;

	private bool? nullable_21;

	private bool? nullable_22;

	private PerFrameCachedValue<bool> perFrameCachedValue_5;

	private PerFrameCachedValue<ActorFlags> perFrameCachedValue_6;

	public string LeftHandWeaponVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (inventories != null)
			{
				return inventories.LeftHand.Name;
			}
			return "";
		}
	}

	public string RightHandWeaponVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (!(inventories != null))
			{
				return "";
			}
			return inventories.RightHand.Name;
		}
	}

	public string ChestVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (inventories != null)
			{
				return inventories.Chest.Name;
			}
			return "";
		}
	}

	public string HelmVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (inventories != null)
			{
				return inventories.Helm.Name;
			}
			return "";
		}
	}

	public string GlovesVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (inventories != null)
			{
				return inventories.Gloves.Name;
			}
			return "";
		}
	}

	public string BootsVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (inventories != null)
			{
				return inventories.Boots.Name;
			}
			return "";
		}
	}

	public string UnknownVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (!(inventories != null))
			{
				return "";
			}
			return inventories.Unknown.Name;
		}
	}

	public string LeftRingVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (!(inventories != null))
			{
				return "";
			}
			return inventories.LeftRing.Name;
		}
	}

	public string RightRingVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (inventories != null)
			{
				return inventories.RightRing.Name;
			}
			return "";
		}
	}

	public string BeltVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (inventories != null)
			{
				return inventories.Belt.Name;
			}
			return "";
		}
	}

	public bool IsTargetingMe
	{
		get
		{
			if (!HasCurrentAction)
			{
				return false;
			}
			DreamPoeBot.Loki.Components.Actor.ActionWrapper currentAction = CurrentAction;
			if (currentAction != null)
			{
				if (currentAction.Destination.Distance(LokiPoe.LocalData.MyPosition) < 30)
				{
					return true;
				}
				return object.Equals(currentAction.Target, LokiPoe.ObjectManager.Me);
			}
			return false;
		}
	}

	public bool CorpseUsable
	{
		get
		{
			if (perFrameCachedValue_5 == null)
			{
				perFrameCachedValue_5 = new PerFrameCachedValue<bool>(method_8);
			}
			return perFrameCachedValue_5;
		}
	}

	public Dictionary<StatTypeGGG, int> Stats
	{
		get
		{
			Stats stats = ((base.Entity == null) ? null : base.Entity.GetComponent<Stats>());
			if (stats == null)
			{
				return new Dictionary<StatTypeGGG, int>();
			}
			return stats.StatsD;
		}
	}

	public Dictionary<StatTypeGGG, int> ModStats
	{
		get
		{
			ObjectMagicProperties objectMagicProperties = ((base.Entity == null) ? null : base.Entity.GetComponent<ObjectMagicProperties>());
			_ = objectMagicProperties == null;
			return new Dictionary<StatTypeGGG, int>();
		}
	}

	public List<string> ModStatsList
	{
		get
		{
			ObjectMagicProperties objectMagicProperties = ((base.Entity == null) ? null : base.Entity.GetComponent<ObjectMagicProperties>());
			if (!(objectMagicProperties == null))
			{
				return objectMagicProperties.Mods;
			}
			return new List<string>();
		}
	}

	public bool IsMoving => ActorFlags.HasFlag(ActorFlags.Moving);

	public bool IsUsingAbility => ActorFlags.HasFlag(ActorFlags.UsingAbility);

	public bool IsAbilityCooldownActive => ActorFlags.HasFlag(ActorFlags.AbilityCooldownActive);

	public bool InWashedUpState => ActorFlags.HasFlag(ActorFlags.WashedUpState);

	public ActorFlags ActorFlags => (ActorFlags)base.Entity.GetComponent<DreamPoeBot.Loki.Components.Actor>().Flags;

	public List<Aura> Auras
	{
		get
		{
			Buffs buffs = ((base.Entity == null) ? null : base.Entity.GetComponent<Buffs>());
			if (buffs != null)
			{
				return buffs.Auras;
			}
			return new List<Aura>();
		}
	}

	public int Health
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0;
			}
			return life.Health;
		}
	}

	public int MaxHealth
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0;
			}
			return life.MaxHealth;
		}
	}

	public float HealthPercent
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (life != null)
			{
				return life.HealthPercent;
			}
			return 0f;
		}
	}

	public float HealthPercentTotal
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (life != null)
			{
				return life.HealthPercentTotal;
			}
			return 0f;
		}
	}

	public int HealthReserved
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0;
			}
			return life.HealthReserved;
		}
	}

	public int HealthReservedPercent
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0;
			}
			return life.HealthReservedPercent;
		}
	}

	public int Mana
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0;
			}
			return life.Mana;
		}
	}

	public int MaxMana
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0;
			}
			return life.MaxMana;
		}
	}

	public float ManaPercent
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (life != null)
			{
				return life.ManaPercent;
			}
			return 0f;
		}
	}

	public float ManaPercentTotal
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (life != null)
			{
				return life.ManaPercentTotal;
			}
			return 0f;
		}
	}

	public int ManaReserved
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (life != null)
			{
				return life.ManaReserved;
			}
			return 0;
		}
	}

	public float ManaReservedPercent
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0f;
			}
			return life.ManaReservedPercent;
		}
	}

	public int EnergyShield
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0;
			}
			return life.EnergyShield;
		}
	}

	public int EnergyShieldMax
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (life != null)
			{
				return life.EnergyShieldMax;
			}
			return 0;
		}
	}

	public float EnergyShieldPercent
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0f;
			}
			return life.EnergyShieldPercent;
		}
	}

	public float EnergyShieldPercentTotal
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (life != null)
			{
				return life.EnergyShieldPercentTotal;
			}
			return 0f;
		}
	}

	public int EnergyShieldReserved
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (life != null)
			{
				return life.EnergyShieldReserved;
			}
			return 0;
		}
	}

	public float EnergyShieldReservedPercent
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0f;
			}
			return life.EnergyShieldReservedPercent;
		}
	}

	public IEnumerable<Skill> AvailableSkills => base.Entity.GetComponent<DreamPoeBot.Loki.Components.Actor>().AvailableSkills;

	public IEnumerable<Skill> UserSkills => AvailableSkills.Where((Skill x) => x.IsUserSkill);

	public bool IsDead => Health <= 0;

	public IEnumerable<NetworkObject> DeployedObjects
	{
		get
		{
			DreamPoeBot.Loki.Components.Actor actor = ((base.Entity == null) ? null : base.Entity.GetComponent<DreamPoeBot.Loki.Components.Actor>());
			if (actor != null)
			{
				List<NetworkObject> list = new List<NetworkObject>();
				{
					foreach (NetworkObject deployedObject in actor.DeployedObjects)
					{
						list.Add(new NetworkObject(deployedObject.Entity));
					}
					return list;
				}
			}
			return new List<NetworkObject>();
		}
	}

	public int BladeFlurryCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.charged_attack);
			if (!(buff != null))
			{
				return 0;
			}
			return buff.Charges;
		}
	}

	public int FlameblastCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.charged_blast_counter);
			if (buff != null)
			{
				return buff.Charges;
			}
			return 0;
		}
	}

	public int ReaveCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.reave_counter);
			if (buff != null)
			{
				return buff.Charges;
			}
			return 0;
		}
	}

	public int IncinerateCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.incinerate_counter);
			if (buff != null)
			{
				return buff.Charges;
			}
			return 0;
		}
	}

	public int BladeVortexCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.blade_vortex_counter);
			if (buff != null)
			{
				return buff.Charges;
			}
			return 0;
		}
	}

	public Aura PowerChargeAura => Auras.FirstOrDefault((Aura x) => x.Name == "power_charge" && x.TimeLeft.TotalMilliseconds > 0.0);

	public int PowerCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.power_charge);
			if (buff != null)
			{
				return buff.Charges;
			}
			return 0;
		}
	}

	public Aura FrenzyChargeAura => Auras.FirstOrDefault((Aura x) => x.Name == "frenzy_charge" && x.TimeLeft.TotalMilliseconds > 0.0);

	public int FrenzyCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.frenzy_charge);
			if (!(buff != null))
			{
				return 0;
			}
			return buff.Charges;
		}
	}

	public Aura EnduranceChargeAura => Auras.FirstOrDefault((Aura x) => x.Name == "endurance_charge" && x.TimeLeft.TotalMilliseconds > 0.0);

	public int EnduranceCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.endurance_charge);
			if (!(buff != null))
			{
				return 0;
			}
			return buff.Charges;
		}
	}

	public Aura WinterOrbAura => Auras.FirstOrDefault((Aura x) => x.InternalName == "frost_fury_stage" && x.TimeLeft.TotalMilliseconds > 0.0);

	public int WinterOrbCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.frost_fury_stage);
			if (buff != null)
			{
				return buff.Charges;
			}
			return 0;
		}
	}

	public bool HasCurrentAction
	{
		get
		{
			DreamPoeBot.Loki.Components.Actor actor = ((base.Entity == null) ? null : base.Entity.GetComponent<DreamPoeBot.Loki.Components.Actor>());
			if (!(actor != null))
			{
				return false;
			}
			return actor.HasCurrentAction;
		}
	}

	public DreamPoeBot.Loki.Components.Actor.ActionWrapper CurrentAction
	{
		get
		{
			DreamPoeBot.Loki.Components.Actor actor = ((base.Entity == null) ? null : base.Entity.GetComponent<DreamPoeBot.Loki.Components.Actor>());
			if (!(actor != null))
			{
				return null;
			}
			return actor.CurrentAction;
		}
	}

	public bool TormentIsTouched => HasAura("torment_touched");

	public bool TormentIsPossessed => HasAura("torment_possessed");

	public bool HasProximityShield
	{
		get
		{
			if (!HasAura("proximity_shield_aura"))
			{
				return HasAura("proximity_shield_buff");
			}
			return true;
		}
	}

	public bool HasContagion => HasAura("contagion");

	public bool HasWither => HasAura("wither_resistance");

	public int MaxTotemCount
	{
		get
		{
			int stat = GetStat(StatTypeGGG.NumberOfTotemsAllowed);
			if (stat == 0)
			{
				return 1;
			}
			return stat;
		}
	}

	public bool IsSpectating => GetStat(StatTypeGGG.Spectating) == 1;

	public bool IsUsingHealthFlask => HasAura("flask_effect_life");

	public bool IsUsingManaFlask => HasAura("flask_effect_mana");

	public bool IsUsingGraniteFlask => HasAura("flask_utility_ironskin");

	public bool IsUsingQuicksilverFlask => HasAura("flask_utility_sprint");

	public bool IsUsingJadeFlask => HasAura("flask_utility_evasion");

	public bool IsUsingDiamondFlask => HasAura("flask_utility_critical_strike_chance");

	public bool IsUsingSapphireFlask => HasAura("flask_utility_resist_cold");

	public bool IsUsingAmethystFlask => HasAura("flask_utility_resist_chaos");

	public bool IsUsingRubyFlask => HasAura("flask_utility_resist_fire");

	public bool IsUsingTopazFlask => HasAura("flask_utility_resist_lightning");

	public bool IsUsingQuartzFlask => HasAura("flask_utility_phase");

	public bool IsUsingBasaltFlask => HasAura("flask_utility_stone");

	public bool IsUsingAquamarineFlask => HasAura("flask_utility_aquamarine");

	public bool IsUsingBismuthFlask => HasAura("flask_utility_prismatic");

	public bool IsUsingStibniteFlask => HasAura("flask_utility_smoke");

	public bool IsUsingSulphurFlask => HasAura("flask_utility_consecrate");

	public bool IsUsingSilverFlask => HasAura("flask_utility_haste");

	public bool IsChilled => HasAura("chilled");

	public bool IsFrozen => HasAura("frozen");

	public bool IsIgnited => HasAura("ignited");

	public bool IsBurning => IsIgnited;

	public bool IsShocked => HasAura("shocked");

	public bool IsBleeding
	{
		get
		{
			if (!HasAura("puncture"))
			{
				return HasAura("corrupted_blood");
			}
			return true;
		}
	}

	public bool HasLaviangasSpirit => HasAura("unique_flask_laviangas_cup");

	public bool HasDivinationDistillate => HasAura("unique_flask_divination_distillate");

	public bool HasBloodOfTheKarui => HasAura("unique_flask_blood_of_the_karui");

	public bool HasAtzirisPromise => HasAura("unique_flask_atziris_promise");

	public bool HasBloodRageBuff => HasAura("blood_rage");

	public bool HasRighteousFireBuff => HasAura("righteous_fire");

	public bool HasArcticArmourBuff => HasAura("new_arctic_armour");

	public bool HasMoltenShellBuff => HasAura("fire_shield");

	public bool HasTempestShieldBuff => HasAura("lightning_shield");

	public bool HasHeraldOfAshBuff => HasBuff(BuffDefinitionsEnum.herald_of_ash);

	public bool HasHeraldOfIceBuff => HasBuff(BuffDefinitionsEnum.herald_of_ice);

	public bool HasHeraldOfThunderBuff => HasBuff(BuffDefinitionsEnum.herald_of_thunder);

	public bool HasHeraldOfPurityBuff => HasBuff(BuffDefinitionsEnum.herald_of_light);

	public bool HasHeraldOfAgonyBuff => HasBuff(BuffDefinitionsEnum.herald_of_agony);

	public bool HasPetrifiedBloodBuff => HasBuff(BuffDefinitionsEnum.petrified_blood);

	public bool HasSkitterbotsBuff => HasBuff(BuffDefinitionsEnum.skitterbots_buff);

	public bool HasClarityBuff => HasBuff(BuffDefinitionsEnum.player_aura_mana_regen);

	public bool HasVaalDeterminationBuff => HasBuff(BuffDefinitionsEnum.vaal_aura_armour);

	public bool HasVaalVitalityBuff => HasBuff(BuffDefinitionsEnum.vaal_aura_life_regen);

	public bool HasVaalClarityBuff => HasBuff(BuffDefinitionsEnum.vaal_aura_no_mana_cost);

	public bool HasVaalGraceBuff => HasBuff(BuffDefinitionsEnum.vaal_aura_dodge);

	public bool HasVaalDisciplineBuff => HasBuff(BuffDefinitionsEnum.vaal_aura_energy_shield);

	public bool HasVaalHasteBuff => HasBuff(BuffDefinitionsEnum.vaal_aura_speed);

	public bool HasGluttonyOfElementsBuff => HasBuff(BuffDefinitionsEnum.vaal_aura_elemental_damage_healing);

	public bool HasAspectBirdBuff => HasBuff(BuffDefinitionsEnum.bird_aspect);

	public bool HasAspectCatBuff => HasBuff(BuffDefinitionsEnum.cat_aspect);

	public bool HasAspectCrabBuff => HasBuff(BuffDefinitionsEnum.crab_aspect);

	public bool HasAspectSpiderBuff => HasBuff(BuffDefinitionsEnum.spider_aspect);

	public bool HasEnduranceCharge => EnduranceCharges > 0;

	public bool HasPowerCharge => PowerCharges > 0;

	public bool HasFrenzyCharge => FrenzyCharges > 0;

	public bool HasWinterOrbCharge => WinterOrbCharges > 0;

	public bool HasFleshOffering => HasAura("offering_offensive");

	public bool HasBoneOffering => HasAura("offering_defensive");

	public bool HasKaruiSpirit => HasAura("marauder_mission_have_idol");

	public bool Invincible
	{
		get
		{
			if (!HasAura("cannot_be_damaged"))
			{
				return GetStat(StatTypeGGG.CannotBeDamaged) == 1;
			}
			return true;
		}
	}

	public bool IsMissionAreaSpawn => HasAura("visual_display_buff");

	public bool IsMissionMob => HasAura("mission_int_buff");

	public bool IsCorruptedMissionBeast => HasAura("mission_beast_corrupted");

	public bool IsRelicInactive => HasAura("mission_relic_praying");

	public List<NetworkObject> DeployedMines
	{
		get
		{
			List<NetworkObject> list = new List<NetworkObject>();
			foreach (Skill availableSkill in AvailableSkills)
			{
				if (!availableSkill.IsMine)
				{
					continue;
				}
				foreach (NetworkObject deployedObject in availableSkill.DeployedObjects)
				{
					NetworkObject item = new NetworkObject(deployedObject.Entity);
					list.Add(item);
				}
			}
			return list;
		}
	}

	public List<NetworkObject> DeployedTraps
	{
		get
		{
			List<NetworkObject> list = new List<NetworkObject>();
			foreach (Skill availableSkill in AvailableSkills)
			{
				if (!availableSkill.IsTrap)
				{
					continue;
				}
				foreach (NetworkObject deployedObject in availableSkill.DeployedObjects)
				{
					NetworkObject item = new NetworkObject(deployedObject.Entity);
					list.Add(item);
				}
			}
			return list;
		}
	}

	public List<NetworkObject> DeployedTotems
	{
		get
		{
			List<NetworkObject> list = new List<NetworkObject>();
			foreach (Skill availableSkill in AvailableSkills)
			{
				if (!availableSkill.IsTotem)
				{
					continue;
				}
				foreach (NetworkObject deployedObject in availableSkill.DeployedObjects)
				{
					NetworkObject item = new NetworkObject(deployedObject.Entity);
					list.Add(item);
				}
			}
			return list;
		}
	}

	public List<NetworkObject> DeployedMinions
	{
		get
		{
			List<NetworkObject> list = new List<NetworkObject>();
			foreach (Skill availableSkill in AvailableSkills)
			{
				if (!availableSkill.SkillTags.Contains("minion"))
				{
					continue;
				}
				foreach (NetworkObject deployedObject in availableSkill.DeployedObjects)
				{
					NetworkObject item = new NetworkObject(deployedObject.Entity);
					list.Add(item);
				}
			}
			return list;
		}
	}

	public float TimeSinceLastAction
	{
		get
		{
			DreamPoeBot.Loki.Components.Actor actor = ((base.Entity == null) ? null : base.Entity.GetComponent<DreamPoeBot.Loki.Components.Actor>());
			if (actor != null)
			{
				return actor.TimeSinceLastAction;
			}
			return 0f;
		}
	}

	public float TimeSinceLastMove
	{
		get
		{
			DreamPoeBot.Loki.Components.Actor actor = ((base.Entity == null) ? null : base.Entity.GetComponent<DreamPoeBot.Loki.Components.Actor>());
			if (!(actor != null))
			{
				return 0f;
			}
			return actor.TimeSinceLastMove;
		}
	}

	public bool IsCursedWithTemporalChains => HasBuffFromOther(BuffDefinitionsEnum.curse_temporal_chains);

	public bool IsCursedWithNewPunishment => HasBuffFromOther(BuffDefinitionsEnum.curse_newpunishment);

	public bool IsCursedWithPunishment => HasBuffFromOther(BuffDefinitionsEnum.curse_punishment);

	public bool IsCursedWithAssassinsMark => HasBuffFromOther(BuffDefinitionsEnum.curse_assassins_mark);

	public bool IsCursedWithPoachersMark => HasBuffFromOther(BuffDefinitionsEnum.curse_poachers_mark);

	public bool IsCursedWithWarlordsMark => HasBuffFromOther(BuffDefinitionsEnum.curse_warlords_mark);

	public bool IsCursedWithProjectileWeakness => HasBuffFromOther(BuffDefinitionsEnum.curse_projectile_weakness);

	public bool IsCursedWithConductivity => HasBuffFromOther(BuffDefinitionsEnum.curse_lightning_weakness);

	public bool IsCursedWithEnfeeble => HasBuffFromOther(BuffDefinitionsEnum.curse_enfeeble);

	public bool IsCursedWithFrostbite => HasBuffFromOther(BuffDefinitionsEnum.curse_cold_weakness);

	public bool IsCursedWithFlammability => HasBuffFromOther(BuffDefinitionsEnum.curse_fire_weakness);

	public bool IsCursedWithElementalWeakness => HasBuffFromOther(BuffDefinitionsEnum.curse_elemental_weakness);

	public bool IsCursedWithVulnerability => HasBuffFromOther(BuffDefinitionsEnum.curse_vulnerability);

	public bool IsCursedWithDespair => HasBuffFromOther(BuffDefinitionsEnum.curse_chaos_weakness);

	public bool IsCursingWithTemporalChains => HasBuffFromSelf(BuffDefinitionsEnum.curse_temporal_chains);

	public bool IsCursingWithNewPunishment => HasBuffFromSelf(BuffDefinitionsEnum.curse_newpunishment);

	public bool IsCursingWithPunishment => HasBuffFromSelf(BuffDefinitionsEnum.curse_punishment);

	public bool IsCursingWithAssassinsMark => HasBuffFromSelf(BuffDefinitionsEnum.curse_assassins_mark);

	public bool IsCursingWithPoachersMark => HasBuffFromSelf(BuffDefinitionsEnum.curse_poachers_mark);

	public bool IsCursingWithWarlordsMark => HasBuffFromSelf(BuffDefinitionsEnum.curse_warlords_mark);

	public bool IsCursingWithProjectileWeakness => HasBuffFromSelf(BuffDefinitionsEnum.curse_projectile_weakness);

	public bool IsCursingWithConductivity => HasBuffFromSelf(BuffDefinitionsEnum.curse_lightning_weakness);

	public bool IsCursingWithEnfeeble => HasBuffFromSelf(BuffDefinitionsEnum.curse_enfeeble);

	public bool IsCursingWithFrostbite => HasBuffFromSelf(BuffDefinitionsEnum.curse_cold_weakness);

	public bool IsCursingWithFlammability => HasBuffFromSelf(BuffDefinitionsEnum.curse_fire_weakness);

	public bool IsCursingWithElementalWeakness => HasBuffFromSelf(BuffDefinitionsEnum.curse_elemental_weakness);

	public bool IsCursingWithVulnerability => HasBuffFromSelf(BuffDefinitionsEnum.curse_vulnerability);

	public bool IsCursingWithDespair => HasBuffFromSelf(BuffDefinitionsEnum.curse_chaos_weakness);

	public int CurseCount => Auras.Count((Aura x) => x.CasterId != base.Id && x.InternalName.Contains("curse_"));

	public bool IsBreachMonster
	{
		get
		{
			if (!nullable_20.HasValue)
			{
				nullable_20 = GetStat(StatTypeGGG.IsBreachMonster) == 1;
			}
			return nullable_20.Value;
		}
	}

	public bool IsStrongboxMinion
	{
		get
		{
			if (!nullable_21.HasValue)
			{
				nullable_21 = HasBuff(BuffDefinitionsEnum.summoned_monster_epk_buff);
			}
			return nullable_21.Value;
		}
	}

	public bool IsHarbingerMinion
	{
		get
		{
			if (!nullable_22.HasValue)
			{
				nullable_22 = HasBuff(BuffDefinitionsEnum.harbinger_minion_new);
			}
			return nullable_22.Value;
		}
	}

	internal Actor(EntityWrapper entity)
		: base(entity)
	{
	}

	internal Actor(Entity player)
		: base(player)
	{
		EntityWrapper entity = new EntityWrapper(player.Address);
		base._entity = entity;
	}

	private bool method_8()
	{
		Life component = base.Entity.GetComponent<Life>();
		if (!(component != null))
		{
			return false;
		}
		return component.CorpseUsable;
	}

	public int GetStat(StatTypeGGG stat)
	{
		Stats stats = ((base.Entity == null) ? null : base.Entity.GetComponent<Stats>());
		if (stats != null)
		{
			if (!stats.StatsD.ContainsKey(stat))
			{
				return 0;
			}
			return stats.StatsD[stat];
		}
		return 0;
	}

	public bool HasAura(string name)
	{
		return Auras.Any((Aura x) => x.Name == name || x.Name == name + " Aura" || x.Name == name + " aura" || x.InternalName == name || x.InternalName == name + " Aura" || x.InternalName == name + " aura");
	}

	public bool HasAura(IEnumerable<string> names)
	{
		foreach (Aura aura in Auras)
		{
			if (aura.TimeLeft.TotalMilliseconds > 0.0 && names.Any((string x) => x == aura.Name || x + " Aura" == aura.Name || x + " aura" == aura.Name || x == aura.InternalName || x + " Aura" == aura.InternalName || x + " aura" == aura.InternalName))
			{
				return true;
			}
		}
		return false;
	}

	public bool HasBuff(string aura)
	{
		return Auras.Any((Aura x) => x.Name == aura && x.TimeLeft.TotalMilliseconds > 0.0);
	}

	public IEnumerable<Skill> GetSkillsByName(string name)
	{
		return AvailableSkills.Where((Skill x) => x.Name == name);
	}

	public bool HasSkillByName(string name)
	{
		return GetSkillsByName(name).Any();
	}

	public Skill GetSkillById(ushort id)
	{
		return AvailableSkills.FirstOrDefault((Skill x) => x.Id == id);
	}

	public Skill GetSkillByName(string name)
	{
		List<string> list = name.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
		if (list.Count > 1 && int.TryParse(list[list.Count - 1], out var result))
		{
			string text = name.Replace(" " + result, "");
			result--;
			List<Skill> list2 = GetSkillsByName(text).ToList();
			if (result >= 0 && result < list2.Count)
			{
				return list2[result];
			}
			return null;
		}
		return GetSkillsByName(name).FirstOrDefault();
	}

	private uint getUintFromString(string name)
	{
		uint result = 0u;
		if (name == null)
		{
			return result;
		}
		result = 2166136261u;
		for (int i = 0; i < name.Length; i++)
		{
			result = (name[i] ^ result) * 16777619;
		}
		return result;
	}

	public bool HasCurseFrom(string skillName)
	{
		switch (getUintFromString(skillName))
		{
		case 3925853269u:
			if (skillName == "Elemental Weakness")
			{
				return IsCursedWithElementalWeakness;
			}
			goto default;
		case 3713468517u:
			if (skillName == "Projectile Weakness")
			{
				return IsCursedWithProjectileWeakness;
			}
			goto default;
		case 3511870008u:
			if (skillName == "Conductivity")
			{
				return IsCursedWithConductivity;
			}
			goto default;
		case 4153453774u:
			if (skillName == "Flammability")
			{
				return IsCursedWithFlammability;
			}
			goto default;
		case 4105110801u:
			if (skillName == "Vulnerability")
			{
				return IsCursedWithVulnerability;
			}
			goto default;
		case 4009271405u:
			if (skillName == "Warlord's Mark")
			{
				return IsCursedWithWarlordsMark;
			}
			goto default;
		case 4050852692u:
			if (skillName == "Punishment")
			{
				return IsCursedWithNewPunishment;
			}
			goto default;
		case 579956711u:
			if (skillName == "Frostbite")
			{
				return IsCursedWithFrostbite;
			}
			goto default;
		case 571677158u:
			if (skillName == "Poacher's Mark")
			{
				return IsCursedWithPoachersMark;
			}
			goto default;
		case 449755603u:
			if (skillName == "Enfeeble")
			{
				return IsCursedWithEnfeeble;
			}
			goto default;
		case 3510303475u:
			if (skillName == "Assassin's Mark")
			{
				return IsCursedWithAssassinsMark;
			}
			goto default;
		case 1423058859u:
			if (skillName == "Temporal Chains")
			{
				return IsCursedWithTemporalChains;
			}
			goto default;
		case 1299977859u:
			if (skillName == "Despair")
			{
				return IsCursedWithDespair;
			}
			goto default;
		default:
			return false;
		}
	}

	public bool HasConsideredAuraFrom(ActiveSkillsEnum @enum)
	{
		if (@enum <= ActiveSkillsEnum.petrified_blood)
		{
			uint num = default(uint);
			while (true)
			{
				if (@enum != ActiveSkillsEnum.arctic_armour)
				{
					while (true)
					{
						switch (@enum)
						{
						case ActiveSkillsEnum.herald_of_ash:
							goto IL_00c4;
						case ActiveSkillsEnum.herald_of_ice:
							goto IL_00cb;
						case ActiveSkillsEnum.herald_of_thunder:
							goto IL_00d2;
						case ActiveSkillsEnum.herald_of_agony:
							goto IL_00d9;
						case ActiveSkillsEnum.herald_of_light:
							goto IL_00e0;
						case ActiveSkillsEnum.petrified_blood:
							goto IL_00e7;
						}
						int num2 = (int)((num * 1157477640) ^ 0x6D63294C);
						while (true)
						{
							switch ((num = (uint)num2 ^ 0xA12E56F2u) % 20u)
							{
							case 2u:
								num2 = ((int)num * -409205823) ^ -709315311;
								continue;
							case 9u:
								break;
							case 15u:
							case 19u:
								goto end_IL_0091;
							case 11u:
								goto IL_00c4;
							case 18u:
								goto IL_00cb;
							case 5u:
								goto IL_00d2;
							case 4u:
								goto IL_00d9;
							case 17u:
								goto IL_00e0;
							case 12u:
								goto IL_00e7;
							case 7u:
								goto IL_00ee;
							case 16u:
								goto end_IL_00ba;
							case 10u:
								goto IL_0111;
							case 6u:
								goto IL_0119;
							default:
								goto IL_0120;
							case 8u:
								goto IL_0122;
							case 0u:
								goto IL_0129;
							case 3u:
								goto IL_0130;
							case 14u:
								goto IL_0137;
							}
							break;
						}
						continue;
						IL_00cb:
						return HasHeraldOfIceBuff;
						IL_00c4:
						return HasHeraldOfAshBuff;
						IL_00e7:
						return HasPetrifiedBloodBuff;
						IL_00e0:
						return HasHeraldOfPurityBuff;
						IL_00d9:
						return HasHeraldOfAgonyBuff;
						IL_00d2:
						return HasHeraldOfThunderBuff;
						continue;
						end_IL_0091:
						break;
					}
					continue;
				}
				goto IL_00ee;
				IL_00ee:
				return HasArcticArmourBuff;
				continue;
				end_IL_00ba:
				break;
			}
		}
		switch (@enum)
		{
		case ActiveSkillsEnum.aspect_cat:
			goto IL_0122;
		case ActiveSkillsEnum.aspect_bird:
			goto IL_0129;
		case ActiveSkillsEnum.aspect_spider:
			goto IL_0130;
		case ActiveSkillsEnum.aspect_crab:
			goto IL_0137;
		}
		goto IL_0111;
		IL_0111:
		if (@enum == ActiveSkillsEnum.skitterbots)
		{
			goto IL_0119;
		}
		goto IL_0120;
		IL_0119:
		return HasSkitterbotsBuff;
		IL_0129:
		return HasAspectBirdBuff;
		IL_0130:
		return HasAspectSpiderBuff;
		IL_0122:
		return HasAspectCatBuff;
		IL_0137:
		return HasAspectCrabBuff;
		IL_0120:
		return false;
	}

	public bool HasCurseFrom(ActiveSkillsEnum @enum)
	{
		if (@enum <= ActiveSkillsEnum.lightning_weakness)
		{
			uint num = default(uint);
			while (true)
			{
				switch (@enum)
				{
				case ActiveSkillsEnum.temporal_chains:
					goto IL_0107;
				case ActiveSkillsEnum.elemental_weakness:
					goto IL_010e;
				case ActiveSkillsEnum.warlords_mark:
					goto IL_0115;
				case ActiveSkillsEnum.punishment:
					goto IL_011c;
				case ActiveSkillsEnum.enfeeble:
					goto IL_0123;
				case ActiveSkillsEnum.assassins_mark:
					goto IL_012a;
				case ActiveSkillsEnum.projectile_weakness:
					goto IL_0131;
				case ActiveSkillsEnum.vulnerability:
					goto IL_0138;
				}
				int num2 = ((int)num * -1128719126) ^ 0x3836A178;
				while (true)
				{
					switch ((num = (uint)num2 ^ 0x98FF9BA4u) % 23u)
					{
					case 16u:
						switch (@enum)
						{
						case ActiveSkillsEnum.fire_weakness:
							goto IL_00f2;
						case ActiveSkillsEnum.cold_weakness:
							goto IL_00f9;
						case ActiveSkillsEnum.lightning_weakness:
							goto IL_0100;
						}
						num2 = ((int)num * -1617214551) ^ 0x2668F690;
						continue;
					case 7u:
						num2 = ((int)num * -1405213189) ^ -1849182517;
						continue;
					case 6u:
					case 22u:
						break;
					case 2u:
						goto IL_00f2;
					case 15u:
						goto IL_00f9;
					case 20u:
						goto IL_0100;
					case 3u:
						goto IL_0107;
					case 10u:
						goto IL_010e;
					case 21u:
						goto IL_0115;
					case 1u:
						goto IL_011c;
					case 13u:
						goto IL_0123;
					case 18u:
						goto IL_012a;
					case 0u:
						goto IL_0131;
					case 17u:
						goto IL_0138;
					case 12u:
						goto end_IL_00c4;
					case 11u:
						goto IL_0147;
					case 14u:
						goto IL_014e;
					case 8u:
						goto IL_0156;
					case 19u:
						goto IL_015d;
					default:
						goto IL_0165;
					case 5u:
						goto IL_0167;
						IL_0100:
						return IsCursedWithConductivity;
						IL_00f9:
						return IsCursedWithFrostbite;
						IL_00f2:
						return IsCursedWithFlammability;
					}
					break;
				}
				continue;
				IL_010e:
				return IsCursedWithElementalWeakness;
				IL_0107:
				return IsCursedWithTemporalChains;
				IL_0138:
				return IsCursedWithVulnerability;
				IL_0131:
				return IsCursedWithProjectileWeakness;
				IL_012a:
				return IsCursedWithAssassinsMark;
				IL_0123:
				return IsCursedWithEnfeeble;
				IL_011c:
				return IsCursedWithNewPunishment;
				IL_0115:
				return IsCursedWithWarlordsMark;
				continue;
				end_IL_00c4:
				break;
			}
		}
		if (@enum == ActiveSkillsEnum.poachers_mark)
		{
			goto IL_0147;
		}
		goto IL_014e;
		IL_0167:
		return IsCursedWithDespair;
		IL_0156:
		return IsCursedWithNewPunishment;
		IL_014e:
		if (@enum == ActiveSkillsEnum.new_punishment)
		{
			goto IL_0156;
		}
		goto IL_015d;
		IL_0165:
		return false;
		IL_0147:
		return IsCursedWithPoachersMark;
		IL_015d:
		if (@enum != ActiveSkillsEnum.despair)
		{
			goto IL_0165;
		}
		goto IL_0167;
	}

	public bool IsCursingWith(ActiveSkillsEnum @enum)
	{
		if (@enum <= ActiveSkillsEnum.lightning_weakness)
		{
			uint num = default(uint);
			while (true)
			{
				switch (@enum)
				{
				case ActiveSkillsEnum.temporal_chains:
					goto IL_0107;
				case ActiveSkillsEnum.elemental_weakness:
					goto IL_010e;
				case ActiveSkillsEnum.warlords_mark:
					goto IL_0115;
				case ActiveSkillsEnum.punishment:
					goto IL_011c;
				case ActiveSkillsEnum.enfeeble:
					goto IL_0123;
				case ActiveSkillsEnum.assassins_mark:
					goto IL_012a;
				case ActiveSkillsEnum.projectile_weakness:
					goto IL_0131;
				case ActiveSkillsEnum.vulnerability:
					goto IL_0138;
				}
				int num2 = (int)(num * 498833423) ^ -928891966;
				while (true)
				{
					switch ((num = (uint)num2 ^ 0x466C115Fu) % 23u)
					{
					case 12u:
						num2 = (int)(num * 1989003052) ^ -1353752604;
						continue;
					case 5u:
						switch (@enum)
						{
						case ActiveSkillsEnum.fire_weakness:
							goto IL_00f2;
						case ActiveSkillsEnum.lightning_weakness:
							goto IL_00f9;
						case ActiveSkillsEnum.cold_weakness:
							goto IL_0100;
						}
						num2 = ((int)num * -123336506) ^ 0x45D33AFE;
						continue;
					case 6u:
					case 18u:
						break;
					case 0u:
						goto IL_00f2;
					case 2u:
						goto IL_00f9;
					case 22u:
						goto IL_0100;
					case 4u:
						goto IL_0107;
					case 19u:
						goto IL_010e;
					case 17u:
						goto IL_0115;
					case 20u:
						goto IL_011c;
					case 1u:
						goto IL_0123;
					case 14u:
						goto IL_012a;
					case 3u:
						goto IL_0131;
					case 13u:
						goto IL_0138;
					case 21u:
						goto end_IL_00c4;
					case 10u:
						goto IL_0147;
					case 11u:
						goto IL_014e;
					case 9u:
						goto IL_0156;
					case 15u:
						goto IL_015d;
					case 7u:
						goto IL_0165;
					default:
						goto IL_016c;
						IL_0100:
						return IsCursingWithFrostbite;
						IL_00f9:
						return IsCursingWithConductivity;
						IL_00f2:
						return IsCursingWithFlammability;
					}
					break;
				}
				continue;
				IL_010e:
				return IsCursingWithElementalWeakness;
				IL_0107:
				return IsCursingWithTemporalChains;
				IL_0138:
				return IsCursingWithVulnerability;
				IL_0131:
				return IsCursingWithProjectileWeakness;
				IL_012a:
				return IsCursingWithAssassinsMark;
				IL_0123:
				return IsCursingWithEnfeeble;
				IL_011c:
				return IsCursingWithNewPunishment;
				IL_0115:
				return IsCursingWithWarlordsMark;
				continue;
				end_IL_00c4:
				break;
			}
		}
		if (@enum == ActiveSkillsEnum.poachers_mark)
		{
			goto IL_0147;
		}
		goto IL_014e;
		IL_015d:
		if (@enum == ActiveSkillsEnum.despair)
		{
			goto IL_0165;
		}
		goto IL_016c;
		IL_0165:
		return IsCursingWithDespair;
		IL_0156:
		return IsCursingWithNewPunishment;
		IL_0147:
		return IsCursingWithPoachersMark;
		IL_016c:
		return false;
		IL_014e:
		if (@enum == ActiveSkillsEnum.new_punishment)
		{
			goto IL_0156;
		}
		goto IL_015d;
	}

	public bool HasBuffFromSelf(BuffDefinitionsEnum @enum)
	{
		return GetBuffs(@enum).FirstOrDefault((Aura x) => x.OwnerId == base.Id) != null;
	}

	public bool HasBuffFromOther(BuffDefinitionsEnum @enum)
	{
		return GetBuffs(@enum).FirstOrDefault((Aura x) => x.OwnerId != base.Id) != null;
	}

	public IEnumerable<Aura> GetBuffs(BuffDefinitionsEnum @enum)
	{
		return Auras.Where((Aura x) => x.InternalName == @enum.ToString() && x.TimeLeft.TotalMilliseconds > 0.0);
	}

	public Aura GetBuff(BuffDefinitionsEnum @enum)
	{
		return Auras.FirstOrDefault((Aura x) => x.InternalName == @enum.ToString() && x.TimeLeft.TotalMilliseconds > 0.0);
	}

	public bool HasBuff(BuffDefinitionsEnum @enum)
	{
		return GetBuff(@enum) != null;
	}

	public IEnumerable<Skill> GetSkills(ActiveSkillsEnum @enum)
	{
		return AvailableSkills.Where((Skill x) => x.InternalId == @enum.ToString());
	}

	public Skill GetSkill(ActiveSkillsEnum @enum)
	{
		return AvailableSkills.FirstOrDefault((Skill x) => x.InternalId == @enum.ToString());
	}

	public bool HasSkill(ActiveSkillsEnum @enum)
	{
		return GetSkill(@enum) != null;
	}
}

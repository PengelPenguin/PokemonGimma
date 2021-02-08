namespace PokemonGame.Pokemon
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Move
    {
        [JsonProperty("accuracy")]
        public long Accuracy { get; set; }

        [JsonProperty("contest_combos")]
        public ContestCombos ContestCombos { get; set; }

        [JsonProperty("contest_effect")]
        public ContestEffect ContestEffect { get; set; }

        [JsonProperty("contest_type")]
        public ContestType ContestType { get; set; }

        [JsonProperty("damage_class")]
        public ContestType DamageClass { get; set; }

        [JsonProperty("effect_chance")]
        public object EffectChance { get; set; }

        [JsonProperty("effect_changes")]
        public object[] EffectChanges { get; set; }

        [JsonProperty("effect_entries")]
        public EffectEntry[] EffectEntries { get; set; }

        [JsonProperty("flavor_text_entries")]
        public FlavorTextEntry[] FlavorTextEntries { get; set; }

        [JsonProperty("generation")]
        public ContestType Generation { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("learned_by_pokemon")]
        public ContestType[] LearnedByPokemon { get; set; }

        [JsonProperty("machines")]
        public object[] Machines { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("names")]
        public Name[] Names { get; set; }

        [JsonProperty("past_values")]
        public object[] PastValues { get; set; }

        [JsonProperty("power")]
        public long Power { get; set; }

        [JsonProperty("pp")]
        public long Pp { get; set; }

        [JsonProperty("priority")]
        public long Priority { get; set; }

        [JsonProperty("stat_changes")]
        public object[] StatChanges { get; set; }

        [JsonProperty("super_contest_effect")]
        public ContestEffect SuperContestEffect { get; set; }

        [JsonProperty("target")]
        public ContestType Target { get; set; }

        [JsonProperty("type")]
        public ContestType Type { get; set; }
    }

    public partial class ContestCombos
    {
        [JsonProperty("normal")]
        public Normal Normal { get; set; }

        [JsonProperty("super")]
        public Normal Super { get; set; }
    }

    public partial class Normal
    {
        [JsonProperty("use_after")]
        public object UseAfter { get; set; }

        [JsonProperty("use_before")]
        public ContestType[] UseBefore { get; set; }
    }

    public partial class ContestType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class ContestEffect
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class EffectEntry
    {
        [JsonProperty("effect")]
        public string Effect { get; set; }

        [JsonProperty("language")]
        public ContestType Language { get; set; }

        [JsonProperty("short_effect")]
        public string ShortEffect { get; set; }
    }

    public partial class FlavorTextEntry
    {
        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }

        [JsonProperty("language")]
        public ContestType Language { get; set; }

        [JsonProperty("version_group")]
        public ContestType VersionGroup { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("ailment")]
        public ContestType Ailment { get; set; }

        [JsonProperty("ailment_chance")]
        public long AilmentChance { get; set; }

        [JsonProperty("category")]
        public ContestType Category { get; set; }

        [JsonProperty("crit_rate")]
        public long CritRate { get; set; }

        [JsonProperty("drain")]
        public long Drain { get; set; }

        [JsonProperty("flinch_chance")]
        public long FlinchChance { get; set; }

        [JsonProperty("healing")]
        public long Healing { get; set; }

        [JsonProperty("max_hits")]
        public object MaxHits { get; set; }

        [JsonProperty("max_turns")]
        public object MaxTurns { get; set; }

        [JsonProperty("min_hits")]
        public object MinHits { get; set; }

        [JsonProperty("min_turns")]
        public object MinTurns { get; set; }

        [JsonProperty("stat_chance")]
        public long StatChance { get; set; }
    }

    public partial class Name
    {
        [JsonProperty("language")]
        public ContestType Language { get; set; }

        [JsonProperty("name")]
        public string NameName { get; set; }
    }
}
